using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>BXIT (R2)</summary>
	[DataTypeHandler("BXIT<CD>")]
	internal class BxitCdR2ElementParser : CdR2ElementParser
	{
		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new BXITImpl<CodedTypeR2<Code>>();
		}

		protected override BareANY DoCreateR2DataTypeInstance(ParseContext context)
		{
			return CodedTypeR2Helper.CreateBXITInstance(context.GetExpectedReturnType());
		}

		protected override bool QtyAllowed()
		{
			return true;
		}
	}
}
