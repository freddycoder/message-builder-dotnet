using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[DataTypeHandler(new string[] { "LIST" })]
	internal class ListPropertyFormatter : BaseCollectionPropertyFormatter
	{
		public ListPropertyFormatter(FormatterRegistry formatterRegistry) : base(formatterRegistry, false)
		{
		}

		protected override string FormatNonNullValue(FormatContext context, ICollection<BareANY> list, int indentLevel)
		{
			return FormatAllElements(context, CreateSubContext(context), list, indentLevel);
		}
	}
}
