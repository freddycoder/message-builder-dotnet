using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>CV/CO (R2)</summary>
	[DataTypeHandler(new string[] { "CV", "CO" })]
	internal class CvR2ElementParser : ScR2ElementParser
	{
		protected override BareANY DoCreateR2DataTypeInstance(ParseContext context)
		{
			if ("CO".Equals(context.Type))
			{
				return CodedTypeR2Helper.CreateCOInstance(context.GetExpectedReturnType());
			}
			return CodedTypeR2Helper.CreateCVInstance(context.GetExpectedReturnType());
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			if ("CO".Equals(typeName))
			{
				return new COImpl<Code>();
			}
			return new CV_R2Impl<Code>();
		}

		protected override bool SimpleValueAllowed()
		{
			return false;
		}

		protected override bool OriginalTextAllowed()
		{
			return true;
		}
	}
}
