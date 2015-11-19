using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[DataTypeHandler("IVL<PQ>")]
	internal class IvlPqR2ElementParser : IvlR2ElementParser<PhysicalQuantity>
	{
		public IvlPqR2ElementParser() : this(false)
		{
		}

		public IvlPqR2ElementParser(bool isUncertainRange) : base(isUncertainRange)
		{
		}
	}
}
