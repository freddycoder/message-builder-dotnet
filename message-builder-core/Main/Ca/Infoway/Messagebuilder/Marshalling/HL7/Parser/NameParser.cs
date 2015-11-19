using System.Xml;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	public interface NameParser
	{
		bool IsParseable(XmlNode node, ParseContext parseContext);

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		BareANY Parse(ParseContext context, XmlNode node, XmlToModelResult xmlToModelResult);
	}
}
