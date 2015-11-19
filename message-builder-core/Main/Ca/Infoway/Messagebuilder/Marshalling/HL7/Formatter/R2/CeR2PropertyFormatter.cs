using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	/// <summary>CE - Coded Data (R2 datatype variant)</summary>
	[DataTypeHandler("CE")]
	internal class CeR2PropertyFormatter : CvR2PropertyFormatter
	{
		protected override bool TranslationAllowed()
		{
			return true;
		}

		protected override string CreateTranslation(CodedTypeR2<Code> translation, CD_R2<Code> cdAny, int indentLevel, FormatContext
			 newContext)
		{
			return this.Format(newContext, cdAny, indentLevel);
		}
	}
}
