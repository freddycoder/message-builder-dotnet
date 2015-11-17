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
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	public class CodedStringValidationUtils
	{
		public virtual void ValidateCodedString(CodedString<Code> codedString, bool codeProvided, bool codeSystemProvided, XmlElement
			 element, string propertyPath, Hl7Errors errors)
		{
			// must have string
			if (StringUtils.IsBlank(codedString.Value))
			{
				CreateError("SC datatypes must have a string value", element, propertyPath, errors);
			}
			// if provide code or code system, must provide other
			if (codeProvided != codeSystemProvided)
			{
				CreateError("For SC datatypes, if code or code system is provided then the other value must also be provided", element, propertyPath
					, errors);
			}
			// if provide codeSystemName or codeSystemVersion, must provide code
			if ((!codeProvided && !codeSystemProvided) && StringUtils.IsNotBlank(codedString.CodeSystemName))
			{
				CreateError("For SC datatypes, can only provide a code system name if a code is also provided", element, propertyPath, errors
					);
			}
			if ((!codeProvided && !codeSystemProvided) && StringUtils.IsNotBlank(codedString.CodeSystemVersion))
			{
				CreateError("For SC datatypes, can only provide a code system version if a code is also provided", element, propertyPath, 
					errors);
			}
		}

		// displayName - requires code?? assume no (for now)
		private void CreateError(string errorMessage, XmlElement element, string propertyPath, Hl7Errors errors)
		{
			Hl7Error error = null;
			if (element != null)
			{
				error = new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, errorMessage + " (" + XmlDescriber.DescribeSingleElement(element) + ")"
					, element);
			}
			else
			{
				// assuming this has a property path
				error = new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, errorMessage, propertyPath);
			}
			errors.AddHl7Error(error);
		}
	}
}
