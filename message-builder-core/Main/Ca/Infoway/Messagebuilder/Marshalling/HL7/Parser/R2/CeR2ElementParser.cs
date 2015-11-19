using System.Xml;
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
	/// <summary>CE (R2)</summary>
	[DataTypeHandler("CE")]
	internal class CeR2ElementParser : CvR2ElementParser
	{
		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new CE_R2Impl<Code>();
		}

		protected override BareANY DoCreateR2DataTypeInstance(ParseContext context)
		{
			return CodedTypeR2Helper.CreateCEInstance(context.GetExpectedReturnType());
		}

		protected override bool TranslationAllowed()
		{
			return true;
		}

		protected override CodedTypeR2<Code> ParseTranslation(XmlElement translationElement, ParseContext newContext, XmlToModelResult
			 result)
		{
			BareANY anyResult = new CdR2ElementParser().Parse(newContext, translationElement, result);
			CodedTypeR2<Code> translation = anyResult == null ? null : (CodedTypeR2<Code>)anyResult.BareValue;
			if (translation != null)
			{
				translation.NullFlavorForTranslationOnly = anyResult == null ? null : anyResult.NullFlavor;
			}
			return translation;
		}
	}
}
