using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[DataTypeHandler(new string[] { "SET" })]
	public class SetR2PropertyFormatter : BaseCollectionPropertyFormatter
	{
		public SetR2PropertyFormatter(FormatterR2Registry formatterR2Registry) : base(formatterR2Registry, true)
		{
		}

		protected override string FormatNonNullValue(FormatContext context, ICollection<BareANY> set, int indentLevel)
		{
			return FormatAllElements(context, CreateSubContext(context), set, indentLevel);
		}
	}
}
