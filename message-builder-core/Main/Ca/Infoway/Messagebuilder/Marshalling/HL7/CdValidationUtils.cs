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
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	public class CdValidationUtils
	{
		private const int MAX_TRANSLATIONS = 10;

		private const int MAX_CODE_LENGTH = 200;

		private const int MAX_CODE_LENGTH_CERX_MR2007 = 20;

		private const int MAX_CODE_SYSTEM_LENGTH = 100;

		private const int MAX_ORIGINAL_TEXT_LENGTH = 150;

		public virtual void ValidateCodedType(CD codeWrapper, string codeAsString, bool isCwe, bool isCne, bool isTranslation, string
			 type, Hl7BaseVersion baseVersion, XmlElement element, string propertyPath, Hl7Errors errors)
		{
			// validations use codeAsString instead of codeWrapper.getValue().getCodeValue() in case the code specified wasn't found by a lookup
			//    - this ensures we validate exactly what was passed in, and redundant errors aren't recorded (in most cases, at least)
			Code code = codeWrapper.Value;
			string codeSystem = (code == null ? null : code.CodeSystem);
			IList<CD> translations = codeWrapper.Translations;
			bool hasCode = (codeAsString != null);
			bool hasNonBlankCode = (StringUtils.IsNotBlank(codeAsString));
			bool hasNullFlavor = codeWrapper.NullFlavor != null;
			if (StandardDataType.CS.Type.Equals(type))
			{
				ValidateCs(codeWrapper, codeAsString, translations, baseVersion, element, propertyPath, errors);
			}
			else
			{
				// CD/CE/CV
				ValidateCodeLength(codeAsString, baseVersion, element, propertyPath, errors, isTranslation);
				ValidateValueLength("codeSystem", code == null ? null : codeSystem, MAX_CODE_SYSTEM_LENGTH, element, propertyPath, errors
					, isTranslation);
				ValidateValueLength("originalText", codeWrapper.OriginalText, MAX_ORIGINAL_TEXT_LENGTH, element, propertyPath, errors, isTranslation
					);
				if (hasNullFlavor && hasCode)
				{
					CreateError("Code cannot be provided along with a nullFlavor.", element, propertyPath, errors, isTranslation);
				}
				if (!isTranslation && (!StandardDataType.CD_LAB.Type.Equals(type) || hasNullFlavor))
				{
					ValidateUnallowedValue("displayName", codeWrapper.DisplayName, element, propertyPath, errors, isTranslation);
				}
				if (!isTranslation)
				{
					ValidateTranslations(translations, type, isCwe, isCne, hasNullFlavor, baseVersion, element, propertyPath, errors);
				}
				// codes can be one of CWE or CNE (unsure if they can be *neither*)
				if (isCwe && !hasNullFlavor)
				{
					// cwe = 1 of code/originalText must be non-null; code present = codeSystem mandatory
					if (!hasNonBlankCode && StringUtils.IsBlank(codeWrapper.OriginalText))
					{
						CreateError("For codes with codingStrength of CWE, one of code or originalText must be provided.", element, propertyPath, 
							errors, isTranslation);
					}
					if (hasCode && StringUtils.IsBlank(codeSystem))
					{
						CreateError("For codes with codingStrength of CWE, the codeSystem property must be provided when the code property is included."
							, element, propertyPath, errors, isTranslation);
					}
				}
				else
				{
					if (isCne)
					{
						// cne = code and codeSystem mandatory if non-null; if NF=OTH then originalText mandatory and no other properties allowed
						if (hasNullFlavor)
						{
							if (Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER.CodeValue.Equals(codeWrapper.NullFlavor.CodeValue))
							{
								if (StringUtils.IsBlank(codeWrapper.OriginalText))
								{
									CreateError("For codes with codingStrength of CNE, originalText is mandatory when NullFlavor is 'OTH'.", element, propertyPath
										, errors, isTranslation);
								}
								if (HasAnyPropertiesProvided(codeWrapper, codeAsString))
								{
									CreateError("For codes with codingStrength of CNE, originalText is the only property allowed when NullFlavor is 'OTH'.", 
										element, propertyPath, errors, isTranslation);
								}
							}
						}
						else
						{
							if (!hasNonBlankCode || StringUtils.IsBlank(codeSystem))
							{
								CreateError("For codes with codingStrength of CNE, code and codeSystem properties must be provided.", element, propertyPath
									, errors, isTranslation);
							}
						}
					}
					else
					{
						// not entirely clear on what should be validated here; code is mandatory, but is code system as well?
						if (!hasNullFlavor || isTranslation)
						{
							if (!hasNonBlankCode || StringUtils.IsBlank(codeSystem))
							{
								CreateError("Code and codeSystem properties must be provided.", element, propertyPath, errors, isTranslation);
							}
						}
					}
				}
			}
		}

		private bool HasAnyPropertiesProvided(CD codeWrapper, string codeAsString)
		{
			Code code = codeWrapper.Value;
			bool hasCode = (codeAsString != null);
			bool hasCodeSystem = (code != null && code.CodeSystem != null);
			bool hasDisplayName = codeWrapper.DisplayName != null;
			bool hasTranslations = !codeWrapper.Translations.IsEmpty();
			return hasCode || hasCodeSystem || hasDisplayName || hasTranslations;
		}

		private void ValidateCs(CD codeWrapper, string codeAsString, IList<CD> translations, Hl7BaseVersion baseVersion, XmlElement
			 element, string propertyPath, Hl7Errors errors)
		{
			bool hasCode = (codeAsString != null);
			bool hasNonBlankCode = (StringUtils.IsNotBlank(codeAsString));
			bool hasNullFlavor = codeWrapper.NullFlavor != null;
			// code mandatory, max length 200 (mr2009)/20 (mr2007 and cerx)
			if (!hasNullFlavor && !hasNonBlankCode)
			{
				CreateError("Code is mandatory for CS types.", element, propertyPath, errors, false);
			}
			else
			{
				if (hasNullFlavor && hasCode)
				{
					CreateError("Code cannot be provided along with a nullFlavor.", element, propertyPath, errors, false);
				}
			}
			ValidateCodeLength(codeAsString, baseVersion, element, propertyPath, errors, false);
			// skip validating codeSystem (codes can be created with a codeSystem even if one wasn't provided, unfortunately)
			// validateUnallowedValue("codeSystem", code == null ? null : code.getCodeSystem(), element, errors);
			ValidateUnallowedValue("originalText", codeWrapper.OriginalText, element, propertyPath, errors, false);
			ValidateUnallowedValue("displayName", codeWrapper.DisplayName, element, propertyPath, errors, false);
			ValidateUnallowedValue("translation", translations.IsEmpty() ? null : string.Empty, element, propertyPath, errors, false);
		}

		private void ValidateCodeLength(string codeAsString, Hl7BaseVersion baseVersion, XmlElement element, string propertyPath, 
			Hl7Errors errors, bool isTranslation)
		{
			ValidateValueLength("code", codeAsString, IsCeRx(baseVersion) || IsMr2007(baseVersion) ? MAX_CODE_LENGTH_CERX_MR2007 : MAX_CODE_LENGTH
				, element, propertyPath, errors, isTranslation);
		}

		private void ValidateTranslations(IList<CD> translations, string type, bool isCwe, bool isCne, bool hasNullFlavor, Hl7BaseVersion
			 baseVersion, XmlElement element, string propertyPath, Hl7Errors errors)
		{
			if (hasNullFlavor && !translations.IsEmpty() && !StandardDataType.CV.Type.Equals(type))
			{
				CreateError("Translations are not allowed when a NullFlavor is specified", element, propertyPath, errors, false);
			}
			if (StandardDataType.CV.Type.Equals(type))
			{
				ValidateUnallowedValue("translation", translations.IsEmpty() ? null : string.Empty, element, propertyPath, errors, false);
			}
			else
			{
				// translation max 10; same type as root; no nesting; no NF
				if (translations.Count > MAX_TRANSLATIONS)
				{
					CreateError("A maximum of " + MAX_TRANSLATIONS + " translations are allowed.", element, propertyPath, errors, false);
				}
				foreach (CD translationCodeWrapper in translations)
				{
					if (!translationCodeWrapper.Translations.IsEmpty())
					{
						CreateError("Translation may not contain other translations.", element, propertyPath, errors, true);
					}
					if (translationCodeWrapper.NullFlavor != null)
					{
						CreateError("Translation may not contain a NullFlavor.", element, propertyPath, errors, true);
					}
					if (translationCodeWrapper.OriginalText != null)
					{
						CreateError("Translation may not contain originalText.", element, propertyPath, errors, true);
					}
					if (translationCodeWrapper.DisplayName != null)
					{
						CreateError("Translation may not contain displayName.", element, propertyPath, errors, true);
					}
					// validate CD
					bool isTranslation = true;
					// this could still result in seeing some redundant error messages if the translation code was invalid; decided this is ok for a little-used feature
					string codeAsString = translationCodeWrapper.Value == null ? null : translationCodeWrapper.Value.CodeValue;
					ValidateCodedType(translationCodeWrapper, codeAsString, false, false, isTranslation, type, baseVersion, element, propertyPath
						, errors);
				}
			}
		}

		private void ValidateUnallowedValue(string propertyName, string value, XmlElement element, string propertyPath, Hl7Errors
			 errors, bool isTranslation)
		{
			if (value != null)
			{
				CreateError("CD should not include the '" + propertyName + "' property.", element, propertyPath, errors, isTranslation);
			}
		}

		private void ValidateValueLength(string propertyName, string value, int maxLength, XmlElement element, string propertyPath
			, Hl7Errors errors, bool isTranslation)
		{
			if (value != null && value.Length > maxLength)
			{
				CreateError("Code type property '" + propertyName + "' is limited to a maximum length of " + maxLength + " (length found: "
					 + value.Length + ")", element, propertyPath, errors, isTranslation);
			}
		}

		private bool IsCeRx(Hl7BaseVersion baseVersion)
		{
			return baseVersion == Hl7BaseVersion.CERX;
		}

		private bool IsMr2007(Hl7BaseVersion baseVersion)
		{
			return baseVersion == Hl7BaseVersion.MR2007 || baseVersion == Hl7BaseVersion.MR2007_V02R01;
		}

		private void CreateError(string errorMessage, XmlElement element, string propertyPath, Hl7Errors errors, bool isTranslation
			)
		{
			errorMessage = (isTranslation ? "(translation level) " : string.Empty) + errorMessage;
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
