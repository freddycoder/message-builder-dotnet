using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	/// <summary>CD - Coded Descriptor (R2 datatype variant)</summary>
	[DataTypeHandler("CD")]
	internal class CdR2PropertyFormatter : CeR2PropertyFormatter
	{
		protected virtual string CreateTranslation(CodedTypeR2<Code> translation, int indentLevel, FormatContext newContext)
		{
			return this.Format(newContext, new CD_R2Impl<Code>(translation), indentLevel);
		}

		protected override bool QualifierAllowed()
		{
			return true;
		}
	}
}
