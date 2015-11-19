using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	public interface PropertyFormatter
	{
		string Format(FormatContext formatContext, BareANY dataType);

		string Format(FormatContext formatContext, BareANY dataType, int indentLevel);
	}
}
