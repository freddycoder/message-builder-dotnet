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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */
using System;
using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	/// <summary>
	/// ST - String (R2 datatype variant)
	/// Represents an ST object as an element:
	/// &lt;element-name&gt;This is some text&lt;/element-name&gt;
	/// HL7 defines other attributes, but notes that they are optional since
	/// the values are self-evident (representation="TXT" mediaType="text/plain").
	/// </summary>
	/// <remarks>
	/// ST - String (R2 datatype variant)
	/// Represents an ST object as an element:
	/// &lt;element-name&gt;This is some text&lt;/element-name&gt;
	/// HL7 defines other attributes, but notes that they are optional since
	/// the values are self-evident (representation="TXT" mediaType="text/plain").
	/// The CeRx documentation makes no mention of these attributes.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-ST
	/// this should be abstracted if more single-level elements with text nodes are needed.
	/// </remarks>
	[DataTypeHandler("ST")]
	internal class StR2PropertyFormatter : AbstractNullFlavorPropertyFormatter<string>
	{
		protected override string FormatNonNullValue(FormatContext context, string value, int indentLevel)
		{
			throw new NotSupportedException("Different formatNonNull handler used for ST");
		}

		protected override string FormatNonNullDataType(FormatContext context, BareANY dataType, int indentLevel)
		{
			StringBuilder buffer = new StringBuilder();
			IDictionary<string, string> attributes = new Dictionary<string, string>();
			// removed the following attributes; they are fixed, but do not have to be provided
			//    	attributes.put("representation", "TXT");
			//    	attributes.put("mediaType", "text/plain");
			string language = GetLanguage(dataType);
			bool hasLang = (language != null);
			Validate(buffer, indentLevel, context, hasLang, dataType);
			if (hasLang && StringUtils.IsNotBlank(language))
			{
				// no details on how to validate language
				attributes["language"] = language;
			}
			buffer.Append(CreateElement(context, attributes, indentLevel, false, false));
			buffer.Append(CreateText(dataType));
			buffer.Append(CreateElementClosure(context, 0, true));
			return buffer.ToString();
		}

		private string CreateText(BareANY dataType)
		{
			string textValue = GetStringValue(dataType);
			string results = null;
			if (dataType is ANYMetaData && ((ANYMetaData)dataType).IsCdata)
			{
				// RM18719 - do not escape text, but wrap with a CDATA block
				results = "<![CDATA[" + textValue + "]]>";
			}
			else
			{
				results = XmlStringEscape.Escape(textValue);
			}
			return results;
		}

		private string GetStringValue(BareANY dataType)
		{
			object bareValue = dataType.BareValue;
			return bareValue == null ? string.Empty : bareValue.ToString();
		}

		private string GetLanguage(BareANY dataType)
		{
			// could be an ANY; need to be careful extracting metadata 
			return ((ANYMetaData)dataType).Language;
		}

		private void Validate(StringBuilder buffer, int indentLevel, FormatContext context, bool hasLang, BareANY dataType)
		{
			// ST has min length of 1 according to schema, and cannot have both a NF and text
			// no details on what language strings are allowed
			ModelToXmlResult result = context.GetModelToXmlResult();
			if (dataType.HasNullFlavor())
			{
				if (dataType.BareValue != null)
				{
					Hl7Error hl7Error = new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "ST cannot have both a nullFlavour and a text value.", context
						.GetPropertyPath());
					result.AddHl7Error(hl7Error);
				}
			}
			else
			{
				if (StringUtils.IsBlank(GetStringValue(dataType)))
				{
					Hl7Error hl7Error = new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "ST text value must be provided.", context.GetPropertyPath
						());
					result.AddHl7Error(hl7Error);
				}
			}
			if (hasLang && StringUtils.IsBlank(GetLanguage(dataType)))
			{
				Hl7Error hl7Error = new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "ST language attribute, if provided, can not be blank.", context
					.GetPropertyPath());
				result.AddHl7Error(hl7Error);
			}
		}
	}
}
