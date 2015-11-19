using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Xml.Service;
using Ca.Infoway.Messagebuilder.Xml.Validator;

namespace Ca.Infoway.Messagebuilder.Xml.Validator
{
	public class MessageValidatorImpl : MessageValidator
	{
		private readonly MessageBeanTransformerImpl messageTransformer;

		public MessageValidatorImpl() : this(new MessageDefinitionServiceFactory().Create())
		{
		}

		public MessageValidatorImpl(MessageDefinitionService service)
		{
			this.messageTransformer = new MessageBeanTransformerImpl(service, RenderMode.PERMISSIVE);
		}

		public virtual MessageValidatorResult Validate(XmlDocument message, VersionNumber version)
		{
			return this.Validate(message, version, null);
		}

		public virtual MessageValidatorResult Validate(XmlDocument message, VersionNumber version, GenericCodeResolverRegistry codeResolverRegistryOverride
			)
		{
			XmlToModelResult transformResults = this.messageTransformer.TransformFromHl7(version, message, codeResolverRegistryOverride
				);
			return new MessageValidatorResult(transformResults.GetHl7Errors());
		}
	}
}
