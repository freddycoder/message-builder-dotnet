using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[DataTypeHandler("IVL<TS>")]
	internal class IvlTsPropertyFormatter : IvlPropertyFormatter<PlatformDate>
	{
	}
}
