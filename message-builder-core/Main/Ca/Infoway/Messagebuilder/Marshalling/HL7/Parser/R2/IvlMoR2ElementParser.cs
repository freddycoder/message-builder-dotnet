using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[DataTypeHandler("IVL<MO>")]
	internal class IvlMoR2ElementParser : IvlR2ElementParser<Money>
	{
		public IvlMoR2ElementParser() : this(false)
		{
		}

		public IvlMoR2ElementParser(bool isUncertainRange) : base(isUncertainRange)
		{
		}
	}
}
