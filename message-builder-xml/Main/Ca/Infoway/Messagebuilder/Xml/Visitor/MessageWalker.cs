/**
 * Copyright 2013 Canada Health Infoway, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Author:        $LastChangedBy: jmis $
 * Last modified: $LastChangedDate: 2015-05-27 08:43:37 -0400 (Wed, 27 May 2015) $
 * Revision:      $LastChangedRevision: 9535 $
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Service;
using Ca.Infoway.Messagebuilder.Xml.Util;
using Ca.Infoway.Messagebuilder.Xml.Visitor;
using ILOG.J2CsMapping.Collections.Generics;

namespace Ca.Infoway.Messagebuilder.Xml.Visitor
{
	public class MessageWalker
	{
		private readonly MessageDefinitionService service;

		private readonly XmlDocument message;

		private readonly VersionNumber version;

		public MessageWalker(MessageDefinitionService service, XmlDocument message, VersionNumber version)
		{
			this.service = service;
			this.message = message;
			this.version = version;
		}

		public virtual void Accept(MessageVisitor visitor)
		{
			Interaction interaction = GetInteraction(this.message);
			if (interaction != null)
			{
				Walk(interaction, visitor);
			}
			else
			{
				visitor.VisitRoot(this.message.DocumentElement, null);
			}
		}

		private void Walk(Interaction interaction, MessageVisitor visitor)
		{
			XmlElement documentElement = this.message.DocumentElement;
			visitor.VisitRoot(documentElement, interaction);
			MessagePart messagePart = GetMessagePart(interaction.SuperTypeName);
			ProcessAllRelationships(documentElement, interaction, Arrays.AsList(messagePart), visitor);
		}

		private void ProcessAllRelationships(XmlElement element, Interaction interaction, IList<MessagePart> messagePartAndChoiceExtensionParts
			, MessageVisitor visitor)
		{
			ICollection<string> knownItems = new HashSet<string>();
			ValidateElementOrder(messagePartAndChoiceExtensionParts, element, visitor);
			foreach (MessagePart messagePart in messagePartAndChoiceExtensionParts)
			{
				ElementBridge helper = new ElementBridge(element, messagePart, GetInteraction(element.OwnerDocument));
				foreach (RelationshipBridge relationship in helper.GetRelationships())
				{
					knownItems.AddAll(relationship.GetNames());
					ProcessRelationship(interaction, messagePart, relationship, visitor);
				}
			}
			ProcessUnknownStructuralAttributes(new HashSet<string>(knownItems), element, visitor);
			ProcessUnknownChildElements(new HashSet<string>(knownItems), element, visitor);
		}

		private void ProcessUnknownChildElements(ICollection<string> knownItems, XmlElement element, MessageVisitor visitor)
		{
			IList<XmlElement> children = NodeUtil.ToElementList(element);
			foreach (XmlElement child in children)
			{
				if (!NamespaceUtil.IsHl7Node(child))
				{
				}
				else
				{
					// ignore it
					string localOrTagName = NodeUtil.GetLocalOrTagName(child);
					if (!knownItems.Contains(localOrTagName))
					{
						knownItems.Add(localOrTagName);
						// this call will intentionally fail fast with an error (since relationship is null)
						visitor.VisitNonStructuralAttribute(element, Arrays.AsList(child), null);
					}
				}
			}
		}

		private void ProcessUnknownStructuralAttributes(ICollection<string> knownItems, XmlElement element, MessageVisitor visitor
			)
		{
			XmlAttributeCollection attrs = element.Attributes;
			if (attrs != null)
			{
				foreach (XmlNode node in new XmlNamedNodeMapIterable(attrs))
				{
					XmlAttribute item = (XmlAttribute)node;
					if (IsIgnorable(item))
					{
					}
					else
					{
						// skip it
						if (!NamespaceUtil.IsHl7Node(item))
						{
						}
						else
						{
							// skip it
							if (!knownItems.Contains(item.Name))
							{
								knownItems.Add(item.Name);
								// this call will intentionally fail fast with an error (since relationship is null)
								visitor.VisitStructuralAttribute(element, item, null);
							}
						}
					}
				}
			}
		}

		private bool IsIgnorable(XmlAttribute item)
		{
			return StringUtils.Equals("ITSVersion", item.Name) || IsNamespaceIndicator(item);
		}

		private bool IsNamespaceIndicator(XmlAttribute item)
		{
			return item.Name.StartsWith("xmlns");
		}

		private void ProcessRelationship(Interaction interaction, MessagePart messagePart, RelationshipBridge relationship, MessageVisitor
			 visitor)
		{
			if (relationship.IsStructuralAttribute())
			{
				XmlAttribute attr = relationship.GetAttribute();
				visitor.VisitStructuralAttribute(relationship.GetBase(), attr, relationship.GetRelationship());
			}
			else
			{
				if (relationship.IsAssociation())
				{
					visitor.VisitAssociation(relationship.GetBase(), relationship.GetXmlName(), relationship.GetElements(), relationship.GetRelationship
						());
					ProcessEachRelationshipValue(interaction, relationship, visitor);
				}
				else
				{
					visitor.VisitNonStructuralAttribute(relationship.GetBase(), relationship.GetElements(), relationship.GetRelationship());
				}
			}
		}

		private void ProcessEachRelationshipValue(Interaction interaction, RelationshipBridge relationshipBridge, MessageVisitor 
			visitor)
		{
			foreach (XmlElement child in relationshipBridge.GetElements())
			{
				Relationship relationship = relationshipBridge.GetRelationship();
				IList<MessagePart> messageParts = GetMessageParts(relationship, interaction, NodeUtil.GetLocalOrTagName(child));
				if (!messageParts.IsEmpty() && !IsNull(child))
				{
					ProcessAllRelationships(child, interaction, messageParts, visitor);
				}
			}
		}

		private bool IsNull(XmlElement child)
		{
			return child.HasAttribute("nullFlavor");
		}

		private IList<MessagePart> GetMessageParts(Relationship relationship, Interaction interaction, string elementName)
		{
			// error if template and choice
			if (relationship.TemplateRelationship && relationship.Choice)
			{
				throw new Exception("Do not know how to handle relationship " + relationship.Name + ": it is both a choice and a template"
					);
			}
			IList<MessagePart> parts = new List<MessagePart>();
			if (relationship.TemplateRelationship)
			{
				Argument argument = interaction.GetArgumentByTemplateParameterName(relationship.TemplateParameterName);
				// HACK: IW/RC: bug 11067: the data in the messageSets is
				// incomplete. Don't NPE, just carry on.
				if (argument != null)
				{
					AddChoiceParts(parts, argument.Choices, elementName);
					MessagePart messagePart = GetMessagePart(argument.Name);
					if (messagePart != null)
					{
						parts.Add(messagePart);
					}
				}
			}
			else
			{
				AddChoiceParts(parts, relationship.Choices, elementName);
				MessagePart messagePart = GetMessagePart(relationship.Type);
				if (messagePart != null)
				{
					parts.Add(messagePart);
				}
			}
			return parts;
		}

		// TM: RM #16042 - need to also check supertype of choices, as these can also have relationships (and so on, up the chain)
		private bool AddChoiceParts(IList<MessagePart> results, IList<Relationship> choices, string elementName)
		{
			foreach (Relationship relationship in choices)
			{
				if (relationship.Choice)
				{
					if (AddChoiceParts(results, relationship.Choices, elementName))
					{
						results.Add(GetMessagePart(relationship.Type));
						return true;
					}
				}
				else
				{
					if (relationship.Name.Equals(elementName))
					{
						results.Add(GetMessagePart(relationship.Type));
						return true;
					}
				}
			}
			return false;
		}

		private Interaction GetInteraction(XmlDocument message)
		{
			return this.service.GetInteraction(this.version, GetInteractionId(message));
		}

		private string GetInteractionId(XmlDocument message)
		{
			return NodeUtil.GetLocalOrTagName(message.DocumentElement);
		}

		private MessagePart GetMessagePart(string type)
		{
			return this.service.GetMessagePart(this.version, type);
		}

		private void ValidateElementOrder(IList<MessagePart> messagePartAndChoiceExtensionParts, XmlElement element, MessageVisitor
			 visitor)
		{
			// create list of properly ordered names (skipping those not provided, and skipping those without a relationship match)
			IList<string> properlyOrderedProvidedRelationshipNames = CreateListOfProperlyOrderedNames(element, messagePartAndChoiceExtensionParts
				, visitor);
			// create list of xml names in the order provided (collapsing duplicates)
			// remove/ignore any not in properly ordered names
			IList<string> xmlElementNamesInOrderProvided = CreateListOfXmlNamesInOrderProvided(element, properlyOrderedProvidedRelationshipNames
				);
			// iterate proper list, look for exact match
			int expectedSize = properlyOrderedProvidedRelationshipNames.Count;
			int actualSize = xmlElementNamesInOrderProvided.Count;
			bool errorDetected = false;
			for (int i = 0; i < expectedSize; i++)
			{
				string expectedName = properlyOrderedProvidedRelationshipNames[i];
				string actualName = actualSize > i ? xmlElementNamesInOrderProvided[i] : null;
				if (!StringUtils.Equals(expectedName, actualName))
				{
					// if not found, break out and log error "beginning with...", then show expected element order
					errorDetected = true;
					string errorMessage = CreateElementOutOfOrderErrorMessage(properlyOrderedProvidedRelationshipNames, actualName);
					visitor.AddError(errorMessage, element);
					break;
				}
			}
			// the two sets of names should be the same length, but just in case...
			if (!errorDetected && actualSize > expectedSize)
			{
				string errorMessage = CreateElementOutOfOrderErrorMessage(properlyOrderedProvidedRelationshipNames, xmlElementNamesInOrderProvided
					[expectedSize]);
				visitor.AddError(errorMessage, element);
			}
		}

		private string CreateElementOutOfOrderErrorMessage(IList<string> orderedNames, string nameInError)
		{
			string errorLocation = StringUtils.IsBlank(nameInError) ? string.Empty : " starting around '" + nameInError + "'";
			return "Elements appear to be out of expected order" + errorLocation + ". Expected order to be: " + ListNames(orderedNames
				);
		}

		private string ListNames(ICollection<string> orderedNames)
		{
			IEnumerator<string> i = orderedNames.GetEnumerator();
			if (!i.MoveNext())
			{
				return "[]";
			}
			StringBuilder sb = new StringBuilder();
			sb.Append('[');
			for (; ; )
			{
				sb.Append(i.Current);
				if (!i.MoveNext())
				{
					return sb.Append(']').ToString();
				}
				sb.Append(", ");
			}
		}

		private IList<string> CreateListOfXmlNamesInOrderProvided(XmlElement element, IList<string> properlyOrderedProvidedRelationshipNames
			)
		{
			IList<string> xmlElementNamesInOrderProvided = new List<string>();
			foreach (XmlElement currentXmlElement in NodeUtil.ToElementList(element))
			{
				string elementName = NodeUtil.GetLocalOrTagName(currentXmlElement);
				if (properlyOrderedProvidedRelationshipNames.Contains(elementName))
				{
					// remove consecutive dups (ignore garbage/extra in between; they will be caught later)
					if (xmlElementNamesInOrderProvided.IsEmpty() || !xmlElementNamesInOrderProvided[xmlElementNamesInOrderProvided.Count - 1]
						.Equals(elementName))
					{
						xmlElementNamesInOrderProvided.Add(elementName);
					}
				}
			}
			return xmlElementNamesInOrderProvided;
		}

		private IList<string> CreateListOfProperlyOrderedNames(XmlElement element, IList<MessagePart> messagePartAndChoiceExtensionParts
			, MessageVisitor visitor)
		{
			IList<string> properlyOrderedProvidedRelationshipNames = new List<string>();
			foreach (MessagePart messagePart in messagePartAndChoiceExtensionParts)
			{
				ElementBridge helper = new ElementBridge(element, messagePart, GetInteraction(element.OwnerDocument));
				foreach (RelationshipBridge relationshipBridge in helper.GetRelationships())
				{
					if (!relationshipBridge.IsStructuralAttribute())
					{
						ICollection<string> names = relationshipBridge.GetNames();
						if (!names.IsEmpty())
						{
							IEnumerator<string> iterator = names.GetEnumerator();
							if (iterator.MoveNext())
							{
								//For .NET translation
								properlyOrderedProvidedRelationshipNames.Add(iterator.Current);
							}
							if (names.Count > 1)
							{
								// not expecting this to ever happen, but need to know if it does so we can adjust the code
								visitor.AddError("Internal error: found more than one name " + ListNames(names), element);
							}
						}
					}
				}
			}
			return properlyOrderedProvidedRelationshipNames;
		}
	}
}
