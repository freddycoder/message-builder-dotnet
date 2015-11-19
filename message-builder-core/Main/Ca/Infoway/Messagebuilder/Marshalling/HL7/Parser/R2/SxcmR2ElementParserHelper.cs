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
using System.Xml;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	public class SxcmR2ElementParserHelper
	{
		public virtual SetOperator HandleOperator(XmlElement element, ParseContext context, Hl7Errors errors, ANYMetaData wrapper
			)
		{
			string type = context == null ? null : context.Type;
			bool isSxcm = (type != null && type.StartsWith("SXCM<"));
			bool hasOperator = (element != null && element.HasAttribute("operator"));
			SetOperator result = null;
			if (isSxcm)
			{
				result = SetOperator.INCLUDE;
				// default
				if (hasOperator)
				{
					string operatorString = element.GetAttribute("operator");
					result = SetOperator.FindMatchingOperator(operatorString);
					if (result == null)
					{
						errors.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Operator could not be determined from attribute value: '" 
							+ operatorString + "'", element));
					}
				}
				wrapper.Operator = result;
			}
			else
			{
				if (hasOperator)
				{
					errors.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Operator property not applicable for type: " + type, element
						));
				}
			}
			return result;
		}
	}
}
