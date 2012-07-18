using System;
using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// ST - String
	/// Represents an ST object as an element:
	/// &lt;element-name&gt;This is some text&lt;/element-name&gt;
	/// HL7 defines other attributes, but notes that they are optional since
	/// the values are self-evident (representation="TXT" mediaType="text/plain").
	/// </summary>
	/// <remarks>
	/// ST - String
	/// Represents an ST object as an element:
	/// &lt;element-name&gt;This is some text&lt;/element-name&gt;
	/// HL7 defines other attributes, but notes that they are optional since
	/// the values are self-evident (representation="TXT" mediaType="text/plain").
	/// The CeRx documentation makes no mention of these attributes.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-ST
	/// TODO: this should be abstracted if more single-level elements with text nodes are needed.
	/// </remarks>
	[DataTypeHandler("ST")]
	internal class StPropertyFormatter : AbstractNullFlavorPropertyFormatter<string>
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		internal override string FormatNonNullValue(FormatContext context, string value, int indentLevel)
		{
			throw new NotSupportedException("Different formatNonNull handler used for ST");
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		internal override string FormatNonNullDataType(FormatContext context, BareANY dataType, int indentLevel)
		{
			StringBuilder buffer = new StringBuilder();
			IDictionary<string, string> attributes = new Dictionary<string, string>();
			if (dataType is ST && "ST.LANG".Equals(context.Type))
			{
				ST st = (ST)dataType;
				string language = st.Language;
				attributes["language"] = StringUtils.IsBlank(language) ? "en-CA" : language;
			}
			buffer.Append(CreateElement(context, attributes, indentLevel, false, false));
			object bareValue = dataType.BareValue;
			buffer.Append(XmlStringEscape.Escape(bareValue == null ? string.Empty : bareValue.ToString()));
			buffer.Append(CreateElementClosure(context, 0, true));
			return buffer.ToString();
		}
	}
}
