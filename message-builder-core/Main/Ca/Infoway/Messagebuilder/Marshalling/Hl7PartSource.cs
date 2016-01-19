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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */


using System;
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Service;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class Hl7PartSource : Hl7Source
	{
		private readonly XmlElement currentElement;

		private readonly string hl7Type;

		private readonly Hl7MessageSource hl7InteractionSource;

		private readonly MessagePart messagePart;

		private readonly MessagePart originalMessagePart;

		public Hl7PartSource(Hl7MessageSource hl7InteractionSource, string hl7Type, XmlElement currentElement, string originalHl7Type
			)
		{
			this.hl7InteractionSource = hl7InteractionSource;
			this.hl7Type = hl7Type;
			this.currentElement = currentElement;
			this.messagePart = InitMessagePart(hl7Type);
			this.originalMessagePart = originalHl7Type == null ? this.messagePart : InitMessagePart(originalHl7Type);
		}

		public virtual MessageDefinitionService GetService()
		{
			return this.hl7InteractionSource.GetService();
		}

		private MessagePart InitMessagePart(string type)
		{
			MessagePart result = GetService().GetMessagePart(GetVersion(), type);
			if (result == null)
			{
				throw new MarshallingException("No message part " + type + " for version " + GetVersion());
			}
			else
			{
				return result;
			}
		}

		public virtual XmlElement GetCurrentElement()
		{
			return this.currentElement;
		}

		public virtual VersionNumber GetVersion()
		{
			return this.hl7InteractionSource.GetVersion();
		}

		public virtual TimeZoneInfo GetDateTimeZone()
		{
			return this.hl7InteractionSource.GetDateTimeZone();
		}

		public virtual TimeZoneInfo GetDateTimeTimeZone()
		{
			return this.hl7InteractionSource.GetDateTimeTimeZone();
		}

		public virtual string Type
		{
			get
			{
				return this.hl7Type;
			}
		}

		public virtual XmlToModelResult GetResult()
		{
			return this.hl7InteractionSource.GetResult();
		}

		public virtual Ca.Infoway.Messagebuilder.Marshalling.Hl7PartSource CreatePartSource(Relationship relationship, XmlElement
			 currentElement)
		{
			return CreatePartSourceForSpecificType(relationship, currentElement, null);
		}

		public virtual Ca.Infoway.Messagebuilder.Marshalling.Hl7PartSource CreatePartSourceForSpecificType(Relationship relationship
			, XmlElement currentElement, string type)
		{
			string resolvedType = (type == null ? ResolveType(relationship, currentElement) : type);
			return new Ca.Infoway.Messagebuilder.Marshalling.Hl7PartSource(this.hl7InteractionSource, resolvedType, currentElement, ResolveTopmostType
				(relationship, currentElement));
		}

		private string ResolveType(Relationship relationship, XmlElement currentElement)
		{
			return this.hl7InteractionSource.GetConversionContext().ResolveType(relationship, NodeUtil.GetLocalOrTagName(currentElement
				));
		}

		private string ResolveTopmostType(Relationship relationship, XmlElement currentElement)
		{
			return this.hl7InteractionSource.GetConversionContext().ResolveTopmostType(relationship, NodeUtil.GetLocalOrTagName(currentElement
				));
		}

		public virtual Relationship GetRelationship(string name)
		{
			Relationship result = this.messagePart.GetRelationship(name, null, this.hl7InteractionSource.GetInteraction());
			if (result == null && !StringUtils.Equals(this.messagePart.Name, this.originalMessagePart.Name))
			{
				result = GetNestedRelationship(this.originalMessagePart, name);
			}
			return result;
		}

		// looks for a matching relationship within "supertype"/abstract message parts 
		private Relationship GetNestedRelationship(MessagePart part, string name)
		{
			Relationship relationship = part.GetRelationship(name, null, this.hl7InteractionSource.GetInteraction());
			if (relationship == null)
			{
				foreach (SpecializationChild childType in part.SpecializationChilds)
				{
					if (TypeIsAssignable(childType.Name))
					{
						MessagePart childPart = GetService().GetMessagePart(GetVersion(), childType.Name);
						relationship = GetNestedRelationship(childPart, name);
						if (relationship != null)
						{
							break;
						}
					}
				}
			}
			return relationship;
		}

		public virtual IList<Relationship> GetAllRelationships()
		{
			IList<Relationship> allRelationships = new List<Relationship>();
			GetAllRelationships(this.originalMessagePart, allRelationships);
			return allRelationships;
		}

		private void GetAllRelationships(MessagePart part, IList<Relationship> relationships)
		{
			relationships.AddAll(part.Relationships);
			foreach (SpecializationChild childType in part.SpecializationChilds)
			{
				if (TypeIsAssignable(childType.Name))
				{
					MessagePart childPart = GetService().GetMessagePart(GetVersion(), childType.Name);
					GetAllRelationships(childPart, relationships);
				}
			}
		}

		/// <summary>Is our type an implementation of the given child type?</summary>
		/// <param name="childType"></param>
		/// <returns>whether our type is an implementation of the given child type</returns>
		private bool TypeIsAssignable(string childType)
		{
			bool result = false;
			MessagePart childPart = GetService().GetMessagePart(GetVersion(), childType);
			if (!childPart.IsAbstract)
			{
				result = StringUtils.Equals(Type, childPart.Name);
			}
			else
			{
				foreach (SpecializationChild specializationChild in childPart.SpecializationChilds)
				{
					if (TypeIsAssignable(specializationChild.Name))
					{
						result = true;
						break;
					}
				}
			}
			return result;
		}

		public virtual string GetMessagePartName()
		{
			return this.messagePart.Name;
		}

		public virtual Interaction GetInteraction()
		{
			return this.hl7InteractionSource.GetConversionContext().GetInteraction();
		}

		public virtual bool IsR2()
		{
			return this.hl7InteractionSource.IsR2();
		}

		public virtual bool IsCda()
		{
			return this.hl7InteractionSource.IsCda();
		}
	}
}
