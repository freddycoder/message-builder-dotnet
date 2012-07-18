using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// AD - Address
	/// Represents an Address object as an element:
	/// &lt;addr use='WP'&gt;
	/// &lt;houseNumber&gt;1050&lt;/houseNumber&gt;
	/// &lt;direction&gt;W&lt;/direction&gt;
	/// &lt;streetName&gt;Wishard Blvd&lt;/streetName&gt;,
	/// &lt;additionalLocator&gt;RG 5th floor&lt;/additionalLocator&gt;,
	/// &lt;city&gt;Indianapolis&lt;/city&gt;, &lt;state&gt;IN&lt;/state&gt;
	/// &lt;postalCode&gt;46240&lt;/postalCode&gt;
	/// &lt;/addr&gt;
	/// If an object is null, value is replaced by a nullFlavor.
	/// </summary>
	/// <remarks>
	/// AD - Address
	/// Represents an Address object as an element:
	/// &lt;addr use='WP'&gt;
	/// &lt;houseNumber&gt;1050&lt;/houseNumber&gt;
	/// &lt;direction&gt;W&lt;/direction&gt;
	/// &lt;streetName&gt;Wishard Blvd&lt;/streetName&gt;,
	/// &lt;additionalLocator&gt;RG 5th floor&lt;/additionalLocator&gt;,
	/// &lt;city&gt;Indianapolis&lt;/city&gt;, &lt;state&gt;IN&lt;/state&gt;
	/// &lt;postalCode&gt;46240&lt;/postalCode&gt;
	/// &lt;/addr&gt;
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-AD
	/// </remarks>
	public abstract class AbstractAdPropertyFormatter : AbstractNullFlavorPropertyFormatter<PostalAddress>
	{
		internal override string FormatNonNullValue(FormatContext context, PostalAddress postalAddress, int indentLevel)
		{
			StringBuilder buffer = new StringBuilder();
			buffer.Append(CreateElement(context, GetUseAttributeMap(postalAddress), indentLevel, false, false));
			foreach (PostalAddressPart postalAddressPart in postalAddress.Parts)
			{
				AppendPostalAddressPart(buffer, postalAddressPart);
			}
			buffer.Append(CreateElementClosure(context, 0, true));
			return buffer.ToString();
		}

		private void AppendPostalAddressPart(StringBuilder buffer, PostalAddressPart postalAddressPart)
		{
			string openTag = string.Empty;
			string closeTag = string.Empty;
			if (postalAddressPart.Type != null)
			{
				openTag = "<" + postalAddressPart.Type.Value + FormatCode(postalAddressPart.Code) + ">";
				closeTag = "</" + postalAddressPart.Type.Value + ">";
			}
			buffer.Append(openTag);
			string xmlEscapedValue = XmlStringEscape.Escape(postalAddressPart.Value);
			if (xmlEscapedValue != null)
			{
				buffer.Append(xmlEscapedValue);
			}
			buffer.Append(closeTag);
		}

		private string FormatCode(Code code)
		{
			if (code == null || StringUtils.IsEmpty(code.CodeValue))
			{
				return StringUtils.EMPTY;
			}
			string codeValue = XmlStringEscape.Escape(code.CodeValue);
			return " code=\"" + codeValue + "\"";
		}

		private IDictionary<string, string> GetUseAttributeMap(PostalAddress value)
		{
			string uses = string.Empty;
			foreach (Ca.Infoway.Messagebuilder.Domainvalue.PostalAddressUse postalAddressUse in value.Uses)
			{
				uses += uses.Length == 0 ? string.Empty : " ";
				uses += postalAddressUse.CodeValue;
			}
			IDictionary<string, string> result = new Dictionary<string, string>();
			if (uses.Length > 0)
			{
				result["use"] = uses;
			}
			return result;
		}
	}
}
