using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[DataTypeHandler(new string[] { "LIST" })]
	internal class ListR2PropertyFormatter : BaseCollectionPropertyFormatter
	{
		public ListR2PropertyFormatter(FormatterR2Registry formatterR2Registry) : base(formatterR2Registry, true)
		{
		}

		protected override string FormatNonNullValue(FormatContext context, ICollection<BareANY> list, int indentLevel)
		{
			return FormatAllElements(context, CreateSubContext(context), list, indentLevel);
		}
	}
}
