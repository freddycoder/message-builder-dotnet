using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Xml.Validator;

namespace Ca.Infoway.Messagebuilder.Xml.Validator
{
	public interface MessageValidator
	{
		MessageValidatorResult Validate(XmlDocument document, VersionNumber version);
	}
}
