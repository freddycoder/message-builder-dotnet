using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Platform;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// ED.DOCORREF - Encapsulated Data (Document or Reference)
	/// Represents a String as an element:
	/// &lt;element-name mediaType="text/plain"&gt;This is some
	/// text.&lt;/element-name&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-ED
	/// </summary>
	[DataTypeHandler("ED")]
	public class EdPropertyFormatter : AbstractNullFlavorPropertyFormatter<EncapsulatedData>
	{
		public static readonly string REPRESENTATION_B64 = "B64";

		public static readonly string ATTRIBUTE_COMPRESSION = "compression";

		public static readonly string ATTRIBUTE_LANGUAGE = "language";

		public static readonly string ATTRIBUTE_REPRESENTATION = "representation";

		public static readonly string ATTRIBUTE_MEDIA_TYPE = "mediaType";

		public static readonly string ATTRIBUTE_REFERENCE = "reference";

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		internal override string FormatNonNullValue(FormatContext context, EncapsulatedData data, int indentLevel)
		{
			ValidateContext(context);
			StringBuilder buffer = new StringBuilder();
			IDictionary<string, string> attributes = new Dictionary<string, string>();
			AddCompressedDataAttributes(data, attributes);
			byte[] content = GetContent(data);
			bool base64 = IsBase64(data, content);
			AddEncapsulatedDataAttributes(data, attributes, base64);
			buffer.Append(CreateElement(context, attributes, indentLevel, false, false));
			if (data != null && content != null && base64)
			{
				buffer.Append(Base64.EncodeBase64String(content));
			}
			else
			{
				if (data != null && content != null && data is EncapsulatedString)
				{
					buffer.Append(XmlStringEscape.Escape(((EncapsulatedString)data).ContentAsString));
				}
				else
				{
					if (data != null && content != null)
					{
						buffer.Append(XmlStringEscape.Escape(System.Text.ASCIIEncoding.ASCII.GetString(content)));
					}
				}
			}
			buffer.Append(CreateElementClosure(context, 0, true));
			return buffer.ToString();
		}

		private void AddEncapsulatedDataAttributes(EncapsulatedData data, IDictionary<string, string> attributes, bool base64)
		{
			if (data != null && data.MediaType != null)
			{
				if (data is CompressedData)
				{
					attributes[ATTRIBUTE_MEDIA_TYPE] = data.MediaType.CodeValue;
				}
				else
				{
					if (data.MediaType != MediaType.PLAIN_TEXT)
					{
						attributes[ATTRIBUTE_MEDIA_TYPE] = data.MediaType.CodeValue;
					}
				}
			}
			if (data != null && data.Reference != null)
			{
				attributes[ATTRIBUTE_REFERENCE] = data.Reference;
			}
			if (base64 == true)
			{
				attributes[ATTRIBUTE_REPRESENTATION] = REPRESENTATION_B64;
			}
		}

		private void AddCompressedDataAttributes(EncapsulatedData data, IDictionary<string, string> attributes)
		{
			if (data != null)
			{
				if (data is CompressedData)
				{
					CompressedData compressedData = (CompressedData)data;
					if (compressedData.Language != null)
					{
						attributes[ATTRIBUTE_LANGUAGE] = compressedData.Language;
					}
					if (compressedData.Compression != null)
					{
						attributes[ATTRIBUTE_COMPRESSION] = compressedData.Compression.CompressionType;
					}
				}
			}
		}

		private bool IsBase64(EncapsulatedData data, byte[] content)
		{
			if (data != null)
			{
				if (data is CompressedData)
				{
					return true;
				}
				else
				{
					if (content != null && data.MediaType != MediaType.PLAIN_TEXT)
					{
						return true;
					}
				}
			}
			return false;
		}

		private byte[] GetContent(EncapsulatedData data)
		{
			byte[] content = null;
			if (data != null)
			{
				if (data is CompressedData)
				{
					CompressedData compressedData = (CompressedData)data;
					content = compressedData.CompressedContent;
				}
				else
				{
					content = data.Content;
				}
			}
			return content;
		}
	}
}
