using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>HXIT (R2)</summary>
	[DataTypeHandler("HXIT<CE>")]
	internal class HxitCeR2ElementParser : CeR2ElementParser
	{
		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new HXITImpl<Code>();
		}

		protected override BareANY DoCreateR2DataTypeInstance(ParseContext context)
		{
			return CodedTypeR2Helper.CreateHXITInstance(context.GetExpectedReturnType());
		}

		protected override bool ValidTimeAllowed()
		{
			return true;
		}
	}
}
