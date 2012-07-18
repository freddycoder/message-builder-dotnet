using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Xml.Service;
using Ca.Infoway.Messagebuilder.Xml.Validator;
using Ca.Infoway.Messagebuilder.Xml.Visitor;

namespace Ca.Infoway.Messagebuilder.Xml.Validator
{
	public class Validator
	{
		private readonly MessageWalker messageWalker;

		private readonly VersionNumber version;

		public Validator(MessageDefinitionService service, XmlDocument message, VersionNumber version)
		{
			this.version = version;
			this.messageWalker = new MessageWalker(service, message, version);
		}

		public virtual MessageValidatorResult Validate()
		{
			ValidatingVisitor visitor = new ValidatingVisitor(this.version);
			this.messageWalker.Accept(visitor);
			return visitor.GetResult();
		}
	}
}
