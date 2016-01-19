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
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	public class SxcmR2PropertyFormatterHelper
	{
		public virtual void HandleOperator(IDictionary<string, string> attributes, FormatContext context, ANYMetaData wrapper)
		{
			string type = context == null ? null : context.Type;
			bool isSxcm = (type != null && type.StartsWith("SXCM<"));
			bool hasOperator = wrapper != null && wrapper.Operator != null;
			if (hasOperator)
			{
				if (isSxcm)
				{
					attributes["operator"] = wrapper.Operator.CodeValue;
				}
				else
				{
					context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Operator property not applicable for type: "
						 + type, context.GetPropertyPath()));
				}
			}
		}
	}
}
