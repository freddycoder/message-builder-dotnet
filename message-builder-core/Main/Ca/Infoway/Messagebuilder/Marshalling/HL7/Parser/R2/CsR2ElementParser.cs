using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>CS (R2)</summary>
	[DataTypeHandler("CS")]
	internal class CsR2ElementParser : AbstractCodedTypeR2ElementParser
	{
		protected override BareANY DoCreateR2DataTypeInstance(ParseContext context)
		{
			return CodedTypeR2Helper.CreateCSInstance(context.GetExpectedReturnType());
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new CS_R2Impl<Code>();
		}
	}
}
