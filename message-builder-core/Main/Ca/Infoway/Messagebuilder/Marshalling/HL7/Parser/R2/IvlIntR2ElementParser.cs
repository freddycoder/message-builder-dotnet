using System;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[DataTypeHandler("IVL<INT>")]
	internal class IvlIntR2ElementParser : IvlR2ElementParser<Int32?>
	{
		public IvlIntR2ElementParser() : this(false)
		{
		}

		public IvlIntR2ElementParser(bool isUncertainRange) : base(isUncertainRange)
		{
		}
	}
}
