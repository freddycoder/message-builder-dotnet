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
using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// CS - Coded Simple
	/// Formats a enum into a CS element.
	/// </summary>
	/// <remarks>
	/// CS - Coded Simple
	/// Formats a enum into a CS element. The element looks like this:
	/// &lt;element-name code="RECENT"/&gt;
	/// According to CeRx: code has a limit of 20 characters. This limit is not
	/// currently enforced by this class.
	/// HL7 implies that variations on this type may use a different name than "code" for
	/// the attribute. The use in the controlActProcess is given as an example.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-CS
	/// </remarks>
	[DataTypeHandler(new string[] { "CD", "CE" })]
	internal class CdPropertyFormatter : AbstractCodePropertyFormatter
	{
		internal override IDictionary<string, string> GetAttributeNameValuePairs(FormatContext context, Code code, BareANY bareAny
			)
		{
			IDictionary<string, string> result = base.GetAttributeNameValuePairs(context, code, bareAny);
			if (code != null)
			{
				if (StringUtils.IsNotBlank(code.CodeSystem))
				{
					result["codeSystem"] = code.CodeSystem;
				}
				if (StringUtils.IsNotBlank(((CD)bareAny).DisplayName))
				{
					result["displayName"] = ((CD)bareAny).DisplayName;
				}
			}
			return result;
		}

		protected override bool HasChildContent(CD cd, FormatContext context)
		{
			return HasTranslations(cd) || base.HasChildContent(cd, context);
		}

		private bool HasTranslations(CD cd)
		{
			return !cd.Translations.IsEmpty();
		}

		protected override void CreateChildContent(CD cd, StringBuilder result)
		{
			base.CreateChildContent(cd, result);
			if (HasTranslations(cd))
			{
				foreach (CD translation in cd.Translations)
				{
					IDictionary<string, string> attributes = new Dictionary<string, string>();
					attributes["code"] = translation.Value.CodeValue;
					attributes["codeSystem"] = translation.Value.CodeSystem;
					result.Append(CreateElement("translation", attributes, 0, true, false));
				}
			}
		}
	}
}
