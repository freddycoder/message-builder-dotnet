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

		public MessageBeanTransformerImpl(MessageDefinitionService service, RenderMode renderMode)
		{
			this.service = service;
			this.renderMode = renderMode;
		}

		public MessageBeanTransformerImpl() : this(new MessageDefinitionServiceFactory().Create(), RenderMode.STRICT)
		{
		}

		public MessageBeanTransformerImpl(RenderMode renderMode) : this(new MessageDefinitionServiceFactory().Create(), renderMode
			)
		{
		}

		public virtual XmlToModelResult TransformFromHl7(VersionNumber version, XmlDocument hl7Message)
		{
			return TransformFromHl7(version, hl7Message, null, null);
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
			return TransformToHl7AndReturnResult(version, messageBean, null, null);
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
