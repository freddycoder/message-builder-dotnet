using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>CD (R2)</summary>
	[DataTypeHandler("CD")]
	internal class CdR2ElementParser : CeR2ElementParser
	{
		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new CD_R2Impl<Code>();
		}

		protected override BareANY DoCreateR2DataTypeInstance(ParseContext context)
		{
			return CodedTypeR2Helper.CreateCDInstance(context.GetExpectedReturnType());
		}

		protected override bool QualifierAllowed()
		{
			return true;
		}
	}
}
