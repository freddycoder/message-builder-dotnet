using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Xml.Service;
using Ca.Infoway.Messagebuilder.Xml.Validator;

namespace Ca.Infoway.Messagebuilder.Xml.Validator
{
	public class MessageValidatorImpl : MessageValidator
	{
		private readonly MessageDefinitionService service;

		public MessageValidatorImpl() : this(new MessageDefinitionServiceFactory().Create())
		{
		}

		public MessageValidatorImpl(MessageDefinitionService service)
		{
			this.service = service;
		}

		public virtual MessageValidatorResult Validate(XmlDocument message, VersionNumber version)
		{
			return new Ca.Infoway.Messagebuilder.Xml.Validator.Validator(service, message, version).Validate();
		}
	}
}
