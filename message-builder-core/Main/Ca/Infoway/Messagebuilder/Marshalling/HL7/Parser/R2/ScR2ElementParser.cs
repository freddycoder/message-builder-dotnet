using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>SC (R2)</summary>
	[DataTypeHandler("SC")]
	internal class ScR2ElementParser : CsR2ElementParser
	{
		protected override BareANY DoCreateR2DataTypeInstance(ParseContext context)
		{
			return CodedTypeR2Helper.CreateSCInstance(context.GetExpectedReturnType());
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new SC_R2Impl<Code>();
		}

		protected override bool CodeSystemAllowed()
		{
			return true;
		}

		protected override bool CodeSystemNameAllowed()
		{
			return true;
		}

		protected override bool CodeSystemVersionAllowed()
		{
			return true;
		}

		protected override bool DisplayNameAllowed()
		{
			return true;
		}

		protected override bool SimpleValueAllowed()
		{
			return true;
		}
	}
}
