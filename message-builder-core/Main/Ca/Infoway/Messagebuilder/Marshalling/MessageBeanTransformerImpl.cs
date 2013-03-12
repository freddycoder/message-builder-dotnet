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
using Ca.Infoway.Messagebuilder.Model;
using Ca.Infoway.Messagebuilder.Xml.Service;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	public class MessageBeanTransformerImpl
	{
		private readonly MessageDefinitionService service;

		private readonly RenderMode renderMode;

		private readonly TimeZone dateTimeZone;

		private readonly TimeZone dateTimeTimeZone;

		public MessageBeanTransformerImpl() : this(new MessageDefinitionServiceFactory().Create(), RenderMode.STRICT)
		{
		}

		public MessageBeanTransformerImpl(RenderMode renderMode) : this(new MessageDefinitionServiceFactory().Create(), renderMode
			)
		{
		}

		public MessageBeanTransformerImpl(MessageDefinitionService service, RenderMode renderMode) : this(service, renderMode, null
			, null)
		{
		}

		public MessageBeanTransformerImpl(MessageDefinitionService service, RenderMode renderMode, TimeZone dateTimeZone, TimeZone
			 dateTimeTimeZone)
		{
			this.service = service;
			this.renderMode = renderMode;
			this.dateTimeZone = dateTimeZone;
			this.dateTimeTimeZone = dateTimeTimeZone;
		}

		public virtual XmlToModelResult TransformFromHl7(VersionNumber version, XmlDocument hl7Message)
		{
			return TransformFromHl7(version, hl7Message, this.dateTimeZone, this.dateTimeTimeZone);
		}

		public virtual XmlToModelResult TransformFromHl7(VersionNumber version, XmlDocument hl7Message, TimeZone dateTimeZone, TimeZone
			 dateTimeTimeZone)
		{
			return new Hl7SourceMapper().MapToTeal(new Hl7MessageSource(version, hl7Message, dateTimeZone, dateTimeTimeZone, this.service
				));
		}

		// FIXME - TM - should return ModelToXmlResult (every transformation test will require changing)
		public virtual string TransformToHl7(VersionNumber version, IInteraction messageBean)
		{
			return TransformToHl7AndReturnResult(version, messageBean).GetXmlMessage();
		}

		public virtual string TransformToHl7(VersionNumber version, IInteraction messageBean, TimeZone dateTimeZone, TimeZone dateTimeTimeZone
			)
		{
			return TransformToHl7AndReturnResult(version, messageBean, dateTimeZone, dateTimeTimeZone).GetXmlMessage();
		}

		public virtual ModelToXmlResult TransformToHl7AndReturnResult(VersionNumber version, IInteraction messageBean)
		{
			return TransformToHl7AndReturnResult(version, messageBean, this.dateTimeZone, this.dateTimeTimeZone);
		}

		public virtual ModelToXmlResult TransformToHl7AndReturnResult(VersionNumber version, IInteraction messageBean, TimeZone dateTimeZone
			, TimeZone dateTimeTimeZone)
		{
			XmlRenderingVisitor visitor = new XmlRenderingVisitor();
			new TealBeanRenderWalker(messageBean, version, dateTimeZone, dateTimeTimeZone, this.service).Accept(visitor);
			ModelToXmlResult result = visitor.ToXml();
			if (!result.IsValid() && IsStrict())
			{
				throw new InvalidRenderInputException(result.GetHl7Errors());
			}
			return result;
		}

		private bool IsStrict()
		{
			return this.renderMode == RenderMode.STRICT;
		}
	}
}
