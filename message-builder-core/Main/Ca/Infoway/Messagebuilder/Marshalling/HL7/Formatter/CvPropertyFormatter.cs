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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// CV - Coded Value
	/// Formats a enum into a CV element.
	/// </summary>
	/// <remarks>
	/// CV - Coded Value
	/// Formats a enum into a CV element. The element looks like this:
	/// &lt;element-name code="RECENT" /&gt;
	/// According to CeRx: code has a limit of 20 characters. This limit is not
	/// currently enforced by this class.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-CV
	/// CeRx states that attribute codeSystem is mandatory if code is specified. However,
	/// none of the sample messages do this and the HL7 definition of the message domains
	/// do not specify what the codeSystem is for different domains.
	/// There's also an originalText attribute that must be included if code is specified.
	/// Again, the HL7 domain definitions are of little help with that.
	/// Finally: there are two types of attributes that that use this datatype.
	/// CNE (coded no extensibility): code attribute is mandatory.
	/// CWE (coded with extensibility): code attribute is required (that is, must be supported
	/// but not mandatory. originalText may be specified if code is not entered.
	/// Currently this class does nothing with codeSystem or originalText. Therefore it is
	/// identical to the CS class.
	/// </remarks>
	[DataTypeHandler("CV")]
	internal class CvPropertyFormatter : AbstractCodePropertyFormatter
	{
		protected override IDictionary<string, string> GetAttributeNameValuePairs(FormatContext context, Code code, BareANY bareAny
			)
		{
			IDictionary<string, string> result = base.GetAttributeNameValuePairs(context, code, bareAny);
			if (code != null)
			{
				if (StringUtils.IsNotBlank(code.CodeSystem))
				{
					result["codeSystem"] = code.CodeSystem;
				}
			}
			// TM - RM18203 - displayName allowed in CV for older CeRx releases (see validations)
			ANYMetaData anyCv = (ANYMetaData)bareAny;
			if (anyCv != null && StringUtils.IsNotBlank(anyCv.DisplayName))
			{
				result["displayName"] = anyCv.DisplayName;
			}
			return result;
		}
	}
}
