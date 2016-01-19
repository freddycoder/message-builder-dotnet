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
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
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
		protected static readonly AdValidationUtils AD_VALIDATION_UTILS = new AdValidationUtils();

		protected override string FormatNonNullValue(FormatContext context, PostalAddress postalAddress, int indentLevel)
		{
			StringBuilder buffer = new StringBuilder();
			IDictionary<string, string> useAttributeMap = GetUseAttributeMap(context.Type, postalAddress, context.GetVersion().GetBaseVersion
				());
			buffer.Append(CreateElement(context, useAttributeMap, indentLevel, false, false));
			foreach (PostalAddressPart postalAddressPart in postalAddress.Parts)
			{
				if (AD_VALIDATION_UTILS.IsAllowableAddressPart(postalAddressPart.Type, context.Type))
				{
					AppendPostalAddressPart(buffer, postalAddressPart);
				}
			}
			buffer.Append(CreateElementClosure(context, 0, true));
			return buffer.ToString();
		}

		private void AppendPostalAddressPart(StringBuilder buffer, PostalAddressPart postalAddressPart)
		{
			string openTag = string.Empty;
			string closeTag = string.Empty;
			bool isDelimiter = IsDelimiter(postalAddressPart);
			if (postalAddressPart.Type != null)
			{
				if (isDelimiter && StringUtils.IsBlank(postalAddressPart.Value))
				{
					openTag = "<" + postalAddressPart.Type.Value + "/>";
				}
				else
				{
					openTag = "<" + postalAddressPart.Type.Value + FormatCode(postalAddressPart.Code) + ">";
					closeTag = "</" + postalAddressPart.Type.Value + ">";
				}
			}
			buffer.Append(openTag);
			string xmlEscapedValue = XmlStringEscape.Escape(postalAddressPart.Value);
			if (xmlEscapedValue != null)
			{
				buffer.Append(xmlEscapedValue);
			}
			buffer.Append(closeTag);
		}

		private bool IsDelimiter(PostalAddressPart postalAddressPart)
		{
			bool result = false;
			if (postalAddressPart != null && postalAddressPart.Type != null)
			{
				result = PostalAddressPartType.DELIMITER.CodeValue.Equals(postalAddressPart.Type.CodeValue);
			}
			return result;
		}

		private string FormatCode(Code code)
		{
			if (code == null || StringUtils.IsEmpty(code.CodeValue))
			{
				return StringUtils.EMPTY;
			}
			string codeValue = XmlStringEscape.Escape(code.CodeValue);
			string codeSystem = XmlStringEscape.Escape(code.CodeSystem);
			return " code=\"" + codeValue + "\"" + (StringUtils.IsBlank(code.CodeSystem) ? string.Empty : " codeSystem=\"" + codeSystem
				 + "\"");
		}

		private IDictionary<string, string> GetUseAttributeMap(string dataType, PostalAddress value, Hl7BaseVersion baseVersion)
		{
			string uses = string.Empty;
			foreach (Ca.Infoway.Messagebuilder.Domainvalue.PostalAddressUse postalAddressUse in value.Uses)
			{
				if (AD_VALIDATION_UTILS.IsAllowableUse(dataType, postalAddressUse, baseVersion))
				{
					uses += uses.Length == 0 ? string.Empty : " ";
					uses += postalAddressUse.CodeValue;
				}
			}
			IDictionary<string, string> result = new Dictionary<string, string>();
			if (uses.Length > 0)
			{
				result["use"] = uses.Trim();
			}
			return result;
		}
	}
}
