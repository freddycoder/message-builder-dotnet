using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[DataTypeHandler("IVL<PQ>")]
	internal class IvlPqPropertyFormatter : IvlPropertyFormatter<PhysicalQuantity>
	{
	}
}
