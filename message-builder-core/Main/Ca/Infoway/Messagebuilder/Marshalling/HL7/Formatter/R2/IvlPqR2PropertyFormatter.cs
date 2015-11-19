using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[DataTypeHandler("IVL<PQ>")]
	internal class IvlPqR2PropertyFormatter : IvlR2PropertyFormatter<PhysicalQuantity>
	{
	}
}
