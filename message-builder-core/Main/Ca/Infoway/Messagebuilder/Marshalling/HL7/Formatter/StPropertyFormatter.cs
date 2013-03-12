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
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using ILOG.J2CsMapping.Text;

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
		internal override string FormatNonNullValue(FormatContext context, string value, int indentLevel)
		{
			throw new NotSupportedException("Different formatNonNull handler used for ST");
		}

		internal override string FormatNonNullDataType(FormatContext context, BareANY dataType, int indentLevel)
		{
			StringBuilder buffer = new StringBuilder();
			IDictionary<string, string> attributes = new Dictionary<string, string>();
			bool isStLang = dataType is ST && "ST.LANG".Equals(context.Type);
			Validate(buffer, indentLevel, context, isStLang, dataType);
			if (isStLang)
			{
				ST st = (ST)dataType;
				string language = st.Language;
				attributes["language"] = !STImpl.ALLOWED_LANGUAGES.Contains(language) ? "en-CA" : language;
			}
			buffer.Append(CreateElement(context, attributes, indentLevel, false, false));
			object bareValue = dataType.BareValue;
			buffer.Append(XmlStringEscape.Escape(bareValue == null ? string.Empty : bareValue.ToString()));
			buffer.Append(CreateElementClosure(context, 0, true));
			return buffer.ToString();
		}

		private void Validate(StringBuilder buffer, int indentLevel, FormatContext context, bool isStLang, BareANY dataType)
		{
			// ST.LANG not allowed for CeRx; not checking as this should be controlled by the message set
			// is ST allowed to be 0 length or only whitespace???
			ModelToXmlResult result = context.GetModelToXmlResult();
			string language = ((ST)dataType).Language;
			if (isStLang)
			{
				if (!STImpl.ALLOWED_LANGUAGES.Contains(language))
				{
					Hl7Error hl7Error = new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("The language attribute content ({0}) is not an allowed value. Using en-CA instead."
						, language), context.GetPropertyPath());
					result.AddHl7Error(hl7Error);
				}
			}
			else
			{
				if (language != null)
				{
					Hl7Error hl7Error = new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("The language attribute ({0}) is not allowed for ST element types"
						, language), context.GetPropertyPath());
					result.AddHl7Error(hl7Error);
				}
			}
		}
	}
}
