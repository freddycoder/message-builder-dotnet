using System.Collections.Generic;
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
			ProcessAllRelationships(documentElement, interaction, messagePart, visitor);
		}

		private void ProcessAllRelationships(XmlElement element, Interaction interaction, MessagePart messagePart, MessageVisitor
			 visitor)
		{
			ICollection<string> knownItems = new HashSet<string>();
			ElementBridge helper = new ElementBridge(element, messagePart, GetInteraction(element.OwnerDocument));
			foreach (RelationshipBridge relationship in helper.GetRelationships())
			{
				knownItems.AddAll(relationship.GetNames());
				ProcessRelationship(interaction, messagePart, relationship, visitor);
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
						visitor.VisitNonStructuralAttribute(element, Arrays.AsList(child), null);
					}
				}
			}
		}

		private void ProcessUnknownStructuralAttributes(ICollection<string> knownItems, XmlElement element, MessageVisitor visitor
			)
		{
			XmlAttributeCollection attrs = element.Attributes;
			int length = attrs == null ? 0 : attrs.Count;
			for (int i = 0; i < length; i++)
			{
				XmlAttribute item = (XmlAttribute)attrs.Item(i);
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
							visitor.VisitStructuralAttribute(element, item, null);
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
				if (relationship.Choice)
				{
					relationship = FindSpecificChoice(child, relationship);
				}
				MessagePart subPart = GetMessagePart(relationship, interaction, NodeUtil.GetLocalOrTagName(child));
				if (subPart != null && !IsNull(child))
				{
					ProcessAllRelationships(child, interaction, subPart, visitor);
				}
			}
		}

		private bool IsNull(XmlElement child)
		{
			return child.HasAttribute("nullFlavor");
		}

		private Relationship FindSpecificChoice(XmlElement child, Relationship relationship)
		{
			return relationship.FindChoiceOption(ChoiceSupport.ChoiceOptionNamePredicate(NodeUtil.GetLocalOrTagName(child)));
		}

		private MessagePart GetMessagePart(Relationship relationship, Interaction interaction, string elementName)
		{
			if (relationship.TemplateRelationship)
			{
				Argument argument = interaction.GetArgumentByTemplateParameterName(relationship.TemplateParameterName);
				if (argument == null)
				{
					// HACK: IW/RC: bug 11067: the data in the messageSets is
					// incomplete. Don't NPE, just carry on.
					return null;
				}
				else
				{
					if (argument.Choice)
					{
						Relationship choice = argument.FindChoiceOption(ChoiceSupport.ChoiceOptionNamePredicate(elementName));
						return choice == null ? null : GetMessagePart(choice.Type);
					}
					else
					{
						return GetMessagePart(argument.Name);
					}
				}
			}
			else
			{
				return GetMessagePart(relationship.Type);
			}
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
	}
}
