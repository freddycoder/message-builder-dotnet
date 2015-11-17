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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	/// <summary>
	/// BL - Boolean
	/// Formats a Boolean into a BL element.
	/// </summary>
	/// <remarks>
	/// BL - Boolean
	/// Formats a Boolean into a BL element. The element looks like this:
	/// &lt;element-name value="true"/&gt;		&lt;!-- or value="false" --&gt;
	/// If a Boolean is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-BL
	/// </remarks>
	[DataTypeHandler(new string[] { "BL", "BN" })]
	internal class BlR2PropertyFormatter : AbstractValueNullFlavorPropertyFormatter<Boolean?>
	{
		public override string Format(FormatContext context, BareANY hl7Value, int indentLevel)
		{
			// if type is BN then NFs are not allowed
			if (StringUtils.Equals(context.Type, StandardDataType.BN.Type))
			{
				if (hl7Value == null || hl7Value.BareValue == null || hl7Value.HasNullFlavor())
				{
					context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.MANDATORY_FIELD_NOT_PROVIDED, "BN can not be null or have a nullFlavor"
						, context.GetPropertyPath()));
				}
			}
			return base.Format(context, hl7Value, indentLevel);
		}

		protected override IDictionary<string, string> GetAttributeNameValuePairs(FormatContext context, Boolean? @bool, BareANY 
			bareAny)
		{
			return base.GetAttributeNameValuePairs(context, @bool, bareAny);
		}

		protected override string GetValue(Boolean? booleanValue, FormatContext context, BareANY bareAny)
		{
			return booleanValue.Value ? "true" : "false";
		}
	}
}
