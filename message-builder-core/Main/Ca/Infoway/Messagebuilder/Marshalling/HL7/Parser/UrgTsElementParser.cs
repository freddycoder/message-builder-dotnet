using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[DataTypeHandler("URG<TS>")]
	internal class UrgTsElementParser : UrgElementParser<TS, PlatformDate>
	{
		protected override ElementParser GetIvlParser()
		{
			return new IvlTsElementParser(true);
		}
	}
}
