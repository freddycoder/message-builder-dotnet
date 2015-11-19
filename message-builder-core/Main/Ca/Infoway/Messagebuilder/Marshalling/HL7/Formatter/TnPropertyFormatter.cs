using System.Text;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// TN - TrivialName
	/// Represents an TN object as an element:
	/// &lt;element-name&gt;This is a trivial name&lt;/element-name&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-TN
	/// </summary>
	[DataTypeHandler("TN")]
	public class TnPropertyFormatter : AbstractEntityNamePropertyFormatter<TrivialName>
	{
		protected override string FormatNonNullValue(FormatContext context, TrivialName value, int indentLevel)
		{
			StringBuilder buffer = new StringBuilder();
			if (value != null)
			{
				buffer.Append(CreateElement(context, GetUseAttributeMap(value), indentLevel, false, false));
				buffer.Append(XmlStringEscape.Escape(value.Name));
				buffer.Append(CreateElementClosure(context, 0, true));
			}
			return buffer.ToString();
		}
	}
}
