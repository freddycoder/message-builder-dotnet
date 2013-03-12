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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System;
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

		public Hl7MessageSource(VersionNumber version, XmlDocument document, TimeZone dateTimeZone, TimeZone dateTimeTimeZone, MessageDefinitionService
			 service)
		{
			this.document = document;
			this.context = new ConversionContext(service, version, dateTimeZone, dateTimeTimeZone, GetMessageIdFromDocument());
			this.result = new XmlToModelResult();
			if (this.context.GetInteraction() == null)
			{
				result.AddHl7Error(new Hl7Error(Hl7ErrorCode.UNSUPPORTED_INTERACTION, "The interaction " + GetMessageTypeKey() + " is not supported"
					, document == null ? null : document.DocumentElement));
			}
			else
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

		public virtual TimeZone GetDateTimeZone()
		{
			return this.context.GetDateTimeZone();
		}

		public virtual TimeZone GetDateTimeTimeZone()
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
			string type = this.context.ResolveType(relationship, NodeUtil.GetLocalOrTagName(currentElement));
			return new Hl7PartSource(this, type, currentElement, relationship.Type);
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
			return new MessageTypeKey(GetVersion(), GetMessageIdFromDocument());
		}

		private string GetMessageIdFromDocument()
		{
			return NodeUtil.GetLocalOrTagName(this.document.DocumentElement);
		}

		public virtual Relationship GetRelationship(string name)
		{
			return this.messagePart.GetRelationship(name, GetInteraction());
		}

		public virtual string GetMessagePartName()
		{
			return this.messagePart.Name;
		}
	}
}
