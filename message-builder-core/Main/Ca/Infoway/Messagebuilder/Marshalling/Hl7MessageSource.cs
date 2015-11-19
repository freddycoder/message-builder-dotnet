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
 * Author:        $LastChangedBy: tmcgrady $
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
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
	internal class Hl7MessageSource : Hl7Source
	{
		private readonly ConversionContext context;

		private readonly XmlDocument document;

		private readonly XmlToModelResult result;

		private MessagePart messagePart;

		private readonly bool isR2;

		private readonly bool isCda;

		public Hl7MessageSource(VersionNumber version, XmlDocument document, TimeZoneInfo dateTimeZone, TimeZoneInfo dateTimeTimeZone
			, MessageDefinitionService service)
		{
			this.document = document;
			this.isR2 = service.IsR2(version);
			this.isCda = service.IsCda(version);
			string messageIdFromDocument = GetMessageIdFromDocument();
			ICollection<string> templateIdsFromDocument = GetTemplateIdsFromDocument();
			this.result = new XmlToModelResult();
			this.context = new ConversionContext(service, version, dateTimeZone, dateTimeTimeZone, messageIdFromDocument, templateIdsFromDocument
				, result);
			if (this.context.GetInteraction() != null)
			{
				this.messagePart = InitMessagePart();
			}
		}

		public virtual MessageDefinitionService GetService()
		{
			return this.context.GetService();
		}

		private MessagePart InitMessagePart()
		{
			MessagePart messagePart = GetService().GetMessagePart(GetVersion(), Type);
			if (messagePart == null)
			{
				throw new MarshallingException("No message part " + Type + " for version " + GetVersion());
			}
			else
			{
				return messagePart;
			}
		}

		public virtual XmlElement GetCurrentElement()
		{
			return this.document.DocumentElement;
		}

		public virtual VersionNumber GetVersion()
		{
			return this.context.GetVersion();
		}

		public virtual TimeZoneInfo GetDateTimeZone()
		{
			return this.context.GetDateTimeZone();
		}

		public virtual TimeZoneInfo GetDateTimeTimeZone()
		{
			return this.context.GetDateTimeTimeZone();
		}

		public virtual string Type
		{
			get
			{
				return this.context.GetInteraction().SuperTypeName;
			}
		}

		public virtual XmlToModelResult GetResult()
		{
			return this.result;
		}

		public virtual Hl7PartSource CreatePartSource(Relationship relationship, XmlElement currentElement)
		{
			return CreatePartSourceForSpecificType(relationship, currentElement, null);
		}

		public virtual Hl7PartSource CreatePartSourceForSpecificType(Relationship relationship, XmlElement currentElement, string
			 type)
		{
			string resolvedType = (type == null ? this.context.ResolveType(relationship, NodeUtil.GetLocalOrTagName(currentElement)) : 
				type);
			return new Hl7PartSource(this, resolvedType, currentElement, relationship.Type);
		}

		public virtual ConversionContext GetConversionContext()
		{
			return this.context;
		}

		public virtual Interaction GetInteraction()
		{
			return this.context.GetInteraction();
		}

		public virtual MessageTypeKey GetMessageTypeKey()
		{
			return new MessageTypeKey(GetVersion(), GetInteraction().Name);
		}

		private string GetMessageIdFromDocument()
		{
			return NodeUtil.GetLocalOrTagName(this.document.DocumentElement);
		}

		private ICollection<string> GetTemplateIdsFromDocument()
		{
			ICollection<string> result = new HashSet<string>();
			IList<XmlElement> childNodes = NodeUtil.ToElementList(this.document.DocumentElement);
			foreach (XmlElement element in childNodes)
			{
				if (StringUtils.Equals(element.Name, "templateId"))
				{
					if (element.HasAttribute("root"))
					{
						result.Add(element.GetAttribute("root"));
					}
				}
			}
			return result;
		}

		public virtual Relationship GetRelationship(string name)
		{
			return this.messagePart.GetRelationship(name, null, GetInteraction());
		}

		public virtual IList<Relationship> GetAllRelationships()
		{
			return this.messagePart.Relationships;
		}

		public virtual string GetMessagePartName()
		{
			return this.messagePart.Name;
		}

		public virtual bool IsR2()
		{
			return this.isR2;
		}

		public virtual bool IsCda()
		{
			return this.isCda;
		}
	}
}
