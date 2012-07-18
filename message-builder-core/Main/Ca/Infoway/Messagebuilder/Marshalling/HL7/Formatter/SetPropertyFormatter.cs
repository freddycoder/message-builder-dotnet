using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[DataTypeHandler(new string[] { "SET" })]
	public class SetPropertyFormatter : BaseCollectionPropertyFormatter
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		internal override string FormatNonNullValue(FormatContext context, ICollection<BareANY> set, int indentLevel)
		{
			return FormatAllElements(CreateSubContext(context), set, indentLevel);
		}
	}
}
