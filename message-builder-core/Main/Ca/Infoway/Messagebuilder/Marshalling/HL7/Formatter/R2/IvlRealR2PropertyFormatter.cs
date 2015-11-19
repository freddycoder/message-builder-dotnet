using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[DataTypeHandler("IVL<REAL>")]
	internal class IvlRealR2PropertyFormatter : IvlR2PropertyFormatter<BigDecimal>
	{
	}
}
