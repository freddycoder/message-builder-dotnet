using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// ED.SIGNATURE - Encapsulated Data (Signature)
	/// Represents a String as an element:
	/// &lt;element-name mediaType="text/xml"&gt;
	/// &lt;signature xmlns="http://www.w3.org/2000/09/xmldsig#"&gt;signatureString&lt;/signature&gt;
	/// &lt;/element-name&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-ED
	/// This appears to be correct, although all of the examples name the outer element as "text".
	/// </summary>
	/// <remarks>
	/// ED.SIGNATURE - Encapsulated Data (Signature)
	/// Represents a String as an element:
	/// &lt;element-name mediaType="text/xml"&gt;
	/// &lt;signature xmlns="http://www.w3.org/2000/09/xmldsig#"&gt;signatureString&lt;/signature&gt;
	/// &lt;/element-name&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-ED
	/// This appears to be correct, although all of the examples name the outer element as "text".
	/// CeRx notes that this is an evolving standard.
	/// </remarks>
	[DataTypeHandler("ED.SIGNATURE")]
	internal class EdSignaturePropertyFormatter : AbstractNullFlavorPropertyFormatter<string>
	{
		private static readonly IDictionary<string, string> TOP_LEVEL_ATTRIBUTES;

		private static readonly IDictionary<string, string> SIGNATURE_ATTRIBUTES;

		static EdSignaturePropertyFormatter()
		{
			TOP_LEVEL_ATTRIBUTES = new Dictionary<string, string>();
			TOP_LEVEL_ATTRIBUTES["mediaType"] = "text/xml";
			SIGNATURE_ATTRIBUTES = new Dictionary<string, string>();
			SIGNATURE_ATTRIBUTES["xmlns"] = "http://www.w3.org/2000/09/xmldsig#";
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		internal override string FormatNonNullValue(FormatContext context, string signature, int indentLevel)
		{
			ValidateContext(context);
			StringBuilder buffer = new StringBuilder();
			buffer.Append(CreateElement(context, TOP_LEVEL_ATTRIBUTES, indentLevel, false, true));
			buffer.Append(CreateElement("signature", SIGNATURE_ATTRIBUTES, indentLevel + 1, false, false));
			if (signature != null)
			{
				buffer.Append(signature);
			}
			buffer.Append(XmlRenderingUtils.CreateEndElement("signature", 0, true));
			buffer.Append(CreateElementClosure(context, indentLevel, true));
			return buffer.ToString();
		}
	}
}
