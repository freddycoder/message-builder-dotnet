using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// PN - PersonalName
	/// Represents a PN object as an element:
	/// &lt;element-name&gt;
	/// &lt;given&gt;Adam&lt;/given&gt;
	/// &lt;given&gt;A.&lt;/given&gt;
	/// &lt;family&gt;Everyman&lt;/family&gt;
	/// &lt;/element-name&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-PN
	/// </summary>
	[DataTypeHandler(new string[] { "PN", "PN.FULL", "PN.BASIC", "PN.SEARCH" })]
	internal class PnPropertyFormatter : AbstractEntityNamePropertyFormatter<PersonName>
	{
	}
}
