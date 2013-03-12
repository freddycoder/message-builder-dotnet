/**
 * Copyright 2013 Canada Health Infoway, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Author:        $LastChangedBy: tmcgrady $
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System;
using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
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
		private EdValidationUtils edValidationUtils = new EdValidationUtils();

		// FIXME - for reference and content (ED.DOC only)
		internal override string FormatNonNullValue(FormatContext context, EncapsulatedData data, int indentLevel)
		{
			throw new NotSupportedException("ED uses formatNonNullDataType() method instead.");
		}

		internal override string FormatNonNullDataType(FormatContext context, BareANY dataType, int indentLevel)
		{
			EncapsulatedData encapsulatedData = ExtractBareValue(dataType);
			Validate(context, dataType, encapsulatedData);
			StringBuilder buffer = new StringBuilder();
			IDictionary<string, string> attributes = new Dictionary<string, string>();
			AddCompressedDataAttributes(encapsulatedData, attributes);
			byte[] content = GetContent(encapsulatedData);
			bool base64 = this.edValidationUtils.IsBase64(encapsulatedData, content);
			AddEncapsulatedDataAttributes(encapsulatedData, attributes, base64, context.Type, dataType.DataType, context.GetVersion()
				);
			buffer.Append(CreateElement(context, attributes, indentLevel, false, false));
			WriteReference(encapsulatedData, buffer, indentLevel + 1);
			WriteContent(encapsulatedData, buffer, content, base64);
			buffer.Append(CreateElementClosure(context, 0, true));
			return buffer.ToString();
		}

		private void Validate(FormatContext context, BareANY dataType, EncapsulatedData encapsulatedData)
		{
			string type = context.Type;
			string specializationType = dataType.DataType == null ? null : dataType.DataType.Type;
			Hl7BaseVersion baseVersion = context.GetVersion().GetBaseVersion();
			Hl7Errors errors = context.GetModelToXmlResult();
			this.edValidationUtils.DoValidate(encapsulatedData, specializationType, baseVersion, type, context.GetPropertyPath(), errors
				);
		}

		private void WriteReference(EncapsulatedData data, StringBuilder buffer, int indentLevel)
		{
			if (StringUtils.IsNotBlank(data.Reference))
			{
				IDictionary<string, string> attributes = new Dictionary<string, string>();
				attributes[EdValidationUtils.ATTRIBUTE_VALUE] = data.Reference;
				buffer.Append("\n").Append(CreateElement(EdValidationUtils.ELEMENT_REFERENCE, attributes, indentLevel, true, true));
			}
		}

		private void WriteContent(EncapsulatedData data, StringBuilder buffer, byte[] content, bool base64)
		{
			if (content != null)
			{
				if (base64)
				{
					buffer.Append(Base64.EncodeBase64String(content));
				}
				else
				{
					if (data is EncapsulatedString)
					{
						buffer.Append(XmlStringEscape.Escape(((EncapsulatedString)data).ContentAsString));
					}
					else
					{
						buffer.Append(XmlStringEscape.Escape(System.Text.ASCIIEncoding.ASCII.GetString(content)));
					}
				}
			}
		}

		private void AddEncapsulatedDataAttributes(EncapsulatedData data, IDictionary<string, string> attributes, bool base64, string
			 type, StandardDataType specializationType, VersionNumber version)
		{
			if (data.MediaType != null)
			{
				attributes[EdValidationUtils.ATTRIBUTE_MEDIA_TYPE] = data.MediaType.CodeValue;
			}
			if (StringUtils.IsNotBlank(data.Language))
			{
				attributes[EdValidationUtils.ATTRIBUTE_LANGUAGE] = data.Language;
			}
			if (base64 == true)
			{
				attributes[EdValidationUtils.ATTRIBUTE_REPRESENTATION] = EdValidationUtils.REPRESENTATION_B64;
			}
			if (StandardDataType.ED_DOC_OR_REF.Type.Equals(type) && !Hl7BaseVersion.CERX.Equals(version.GetBaseVersion()))
			{
				if (specializationType == StandardDataType.ED_DOC || specializationType == StandardDataType.ED_DOC_REF)
				{
					AddSpecializationType(attributes, specializationType.Type);
				}
				else
				{
					// best guess: check content to decide on DOC or DOC_REF
					AddSpecializationType(attributes, data.Content != null && data.Content.Length > 0 ? StandardDataType.ED_DOC.Type : StandardDataType
						.ED_DOC_REF.Type);
				}
			}
		}

		private void AddCompressedDataAttributes(EncapsulatedData data, IDictionary<string, string> attributes)
		{
			if (data is CompressedData)
			{
				CompressedData compressedData = (CompressedData)data;
				if (compressedData.Compression != null)
				{
					attributes[EdValidationUtils.ATTRIBUTE_COMPRESSION] = compressedData.Compression.CompressionType;
				}
			}
		}

		private byte[] GetContent(EncapsulatedData data)
		{
			byte[] content = null;
			if (data is CompressedData)
			{
				content = ((CompressedData)data).CompressedContent;
			}
			else
			{
				content = data.Content;
			}
			return content;
		}
	}
}
