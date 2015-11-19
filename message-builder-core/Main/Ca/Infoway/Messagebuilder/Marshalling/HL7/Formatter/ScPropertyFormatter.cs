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
using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// SC - Coded String (CS was already taken for coded simple)
	/// Represents an SC object as an element.
	/// </summary>
	/// <remarks>
	/// SC - Coded String (CS was already taken for coded simple)
	/// Represents an SC object as an element. There is also an optional code attribute.
	/// &lt;element-name&gt;Assistant to the Regional Manager&lt;/element-name&gt;
	/// &lt;element-name code="RM" codeSystem="XX"&gt;Regional Manager&lt;/element-name&gt;
	/// HL7 defines other optional attributes such as code system version and description.
	/// This class is a mix of StPropertyFormatter and CvPropertyFormatter.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-SC
	/// </remarks>
	[DataTypeHandler("SC")]
	internal class ScPropertyFormatter : AbstractNullFlavorPropertyFormatter<CodedString<Code>>
	{
		private CodedStringValidationUtils codedStringValidationUtils = new CodedStringValidationUtils();

		protected override string FormatNonNullValue(FormatContext context, CodedString<Code> value, int indentLevel)
		{
			bool codeProvided = value.Code == null ? false : StringUtils.IsNotBlank(value.Code.CodeValue);
			bool codeSystemProvided = value.Code == null ? false : StringUtils.IsNotBlank(value.Code.CodeSystem);
			this.codedStringValidationUtils.ValidateCodedString(value, codeProvided, codeSystemProvided, null, context.GetPropertyPath
				(), context.GetModelToXmlResult());
			StringBuilder buffer = new StringBuilder();
			buffer.Append(CreateElement(context, GetAttributeNameValuePairs(value), indentLevel, false, false));
			buffer.Append(XmlStringEscape.Escape(value.Value));
			buffer.Append(CreateElementClosure(context, 0, true));
			return buffer.ToString();
		}

		private IDictionary<string, string> GetAttributeNameValuePairs(CodedString<Code> value)
		{
			IDictionary<string, string> result = new Dictionary<string, string>();
			Code code = value.Code;
			if (code != null)
			{
				string codeValue = code.CodeValue;
				if (codeValue == null)
				{
					codeValue = code.ToString();
				}
				result["code"] = codeValue;
				string codeSystem = code.CodeSystem;
				if (StringUtils.IsNotEmpty(codeSystem))
				{
					result["codeSystem"] = codeSystem;
				}
				if (StringUtils.IsNotEmpty(value.DisplayName))
				{
					result["displayName"] = value.DisplayName;
				}
				if (StringUtils.IsNotEmpty(value.CodeSystemName))
				{
					result["codeSystemName"] = value.CodeSystemName;
				}
				if (StringUtils.IsNotEmpty(value.CodeSystemVersion))
				{
					result["codeSystemVersion"] = value.CodeSystemVersion;
				}
			}
			return result;
		}
	}
}
