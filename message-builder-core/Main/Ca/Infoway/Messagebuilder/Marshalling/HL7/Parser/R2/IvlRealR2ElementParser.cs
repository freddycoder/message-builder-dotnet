using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[DataTypeHandler("IVL<REAL>")]
	internal class IvlRealR2ElementParser : IvlR2ElementParser<BigDecimal>
	{
		public IvlRealR2ElementParser() : this(false)
		{
		}

		public IvlRealR2ElementParser(bool isUncertainRange) : base(isUncertainRange)
		{
		}
	}
}
