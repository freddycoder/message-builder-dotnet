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
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	public class AdValidationUtils
	{
		private const int MAX_DELIMITED_LINES = 4;

		private const int MAX_PART_LENGTH = 80;

		private const int MAX_USES = 3;

		private static readonly IList<string> ALLOWABLE_ADDRESS_USES = new List<string>();

		static AdValidationUtils()
		{
			ALLOWABLE_ADDRESS_USES.Add("H");
			ALLOWABLE_ADDRESS_USES.Add("PHYS");
			ALLOWABLE_ADDRESS_USES.Add("PST");
			ALLOWABLE_ADDRESS_USES.Add("TMP");
			ALLOWABLE_ADDRESS_USES.Add("WP");
			ALLOWABLE_ADDRESS_USES.Add("CONF");
			ALLOWABLE_ADDRESS_USES.Add("DIR");
		}

		public virtual void ValidatePostalAddress(PostalAddress postalAddress, string type, VersionNumber version, XmlElement element
			, string propertyPath, Hl7Errors errors)
		{
			ValidatePostalAddressUses(postalAddress, type, version, element, propertyPath, errors);
			ValidatePostalAddressParts(postalAddress, type, version, element, propertyPath, errors);
		}

		private void ValidatePostalAddressParts(PostalAddress postalAddress, string type, VersionNumber version, XmlElement element
			, string propertyPath, Hl7Errors errors)
		{
			int countBlankParts = 0;
			bool isBasic = StandardDataType.AD_BASIC.Type.Equals(type);
			bool isSearch = StandardDataType.AD_SEARCH.Type.Equals(type);
			bool isFull = StandardDataType.AD_FULL.Type.Equals(type);
			bool isAd = StandardDataType.AD.Type.Equals(type);
			foreach (PostalAddressPart postalAddressPart in postalAddress.Parts)
			{
				int partLength = StringUtils.Length(postalAddressPart.Value);
				if (partLength > MAX_PART_LENGTH)
				{
					// value max length of 80
					CreateError("Address part types have a maximum allowed length of " + MAX_PART_LENGTH + " (length found: " + partLength + 
						")", element, propertyPath, errors);
				}
				// error if part type not allowed
				PostalAddressPartType partType = postalAddressPart.Type;
				if (partType == null)
				{
					countBlankParts++;
					// no part type : only allowed for BASIC (max 4, plus max 4 delimiter)
					if (!isBasic)
					{
						CreateError("Text without an address part only allowed for AD.BASIC", element, propertyPath, errors);
					}
				}
				else
				{
					if (partType == PostalAddressPartType.DELIMITER)
					{
						if (isSearch)
						{
							CreateError("Part type " + partType.Value + " is not allowed for AD.SEARCH", element, propertyPath, errors);
						}
					}
					else
					{
						if (isFull || isAd)
						{
							if (!PostalAddressPartType.IsFullAddressPartType(partType))
							{
								CreateError("Part type " + partType.Value + " is not allowed for AD or AD.FULL", element, propertyPath, errors);
							}
						}
						else
						{
							if (!PostalAddressPartType.IsBasicAddressPartType(partType))
							{
								CreateError("Part type " + partType.Value + " is not allowed for AD.BASIC or AD.SEARCH", element, propertyPath, errors);
							}
						}
					}
				}
				// code/codesystem are only for state/country
				if (postalAddressPart.Code != null)
				{
					if (partType != PostalAddressPartType.STATE && partType != PostalAddressPartType.COUNTRY)
					{
						CreateError("Part type " + partType.Value + " is not allowed to specify code or codeSystem", element, propertyPath, errors
							);
					}
				}
			}
			if (isBasic && countBlankParts > MAX_DELIMITED_LINES)
			{
				CreateError("AD.BASIC is only allowed a maximum of " + MAX_DELIMITED_LINES + " delimiter-separated address lines (address lines without an address part type)"
					, element, propertyPath, errors);
			}
			if (isSearch && CollUtils.IsEmpty(postalAddress.Parts))
			{
				CreateError("AD.SEARCH must specify at least one part type", element, propertyPath, errors);
			}
			// city/state/postalCode/country mandatory for AD.FULL
			// new change for R02.05 (pre-adopted by R02.04.03 AB) onwards - these fields are now only *required*, not mandatory
			if (isFull && !SpecificationVersion.IsExactVersion(SpecificationVersion.R02_04_03_AB, version))
			{
				ValidatePartTypeProvided(PostalAddressPartType.CITY, postalAddress.Parts, element, propertyPath, errors);
				ValidatePartTypeProvided(PostalAddressPartType.STATE, postalAddress.Parts, element, propertyPath, errors);
				ValidatePartTypeProvided(PostalAddressPartType.POSTAL_CODE, postalAddress.Parts, element, propertyPath, errors);
				ValidatePartTypeProvided(PostalAddressPartType.COUNTRY, postalAddress.Parts, element, propertyPath, errors);
			}
		}

		private void ValidatePartTypeProvided(PostalAddressPartType partType, IList<PostalAddressPart> parts, XmlElement element, 
			string propertyPath, Hl7Errors errors)
		{
			bool found = false;
			foreach (PostalAddressPart postalAddressPart in parts)
			{
				if (postalAddressPart.Type == partType)
				{
					found = true;
					break;
				}
			}
			if (!found)
			{
				CreateError("Part type '" + partType + "' is mandatory for AD.FULL", element, propertyPath, errors);
			}
		}

		private void ValidatePostalAddressUses(PostalAddress postalAddress, string type, VersionNumber version, XmlElement element
			, string propertyPath, Hl7Errors errors)
		{
			int numUses = postalAddress.Uses.Count;
			bool isSearch = StandardDataType.AD_SEARCH.Type.Equals(type);
			if (isSearch && numUses > 0)
			{
				// error if > 0 and SEARCH
				CreateError("PostalAddressUses are not allowed for AD.SEARCH", element, propertyPath, errors);
			}
			else
			{
				if (numUses > MAX_USES)
				{
					// error if more than 3 uses
					CreateError("A maximum of 3 PostalAddressUses are allowed (number found: " + numUses + ")", element, propertyPath, errors
						);
				}
			}
			if (!isSearch)
			{
				foreach (Ca.Infoway.Messagebuilder.Domainvalue.PostalAddressUse postalAddressUse in postalAddress.Uses)
				{
					if (!IsAllowableUse(type, postalAddressUse, version.GetBaseVersion()))
					{
						CreateError("PostalAddressUse is not valid: " + (postalAddressUse == null ? "null" : postalAddressUse.CodeValue), element
							, propertyPath, errors);
					}
				}
			}
		}

		public virtual bool IsAllowableAddressPart(PostalAddressPartType partType, string type)
		{
			bool isBasic = StandardDataType.AD_BASIC.Type.Equals(type);
			bool isFull = StandardDataType.AD_FULL.Type.Equals(type);
			bool isSearch = StandardDataType.AD_SEARCH.Type.Equals(type);
			bool result = true;
			if (partType == null)
			{
				// no part type : only allowed for BASIC (max 4, plus max 4 delimiter)
				if (!isBasic)
				{
					result = false;
				}
			}
			else
			{
				if (partType == PostalAddressPartType.DELIMITER)
				{
					if (isSearch)
					{
						result = false;
					}
				}
				else
				{
					if (isFull)
					{
						if (!PostalAddressPartType.IsFullAddressPartType(partType))
						{
							result = false;
						}
					}
					else
					{
						if (!PostalAddressPartType.IsBasicAddressPartType(partType))
						{
							result = false;
						}
					}
				}
			}
			return result;
		}

		public virtual bool IsAllowableUse(string dataType, Ca.Infoway.Messagebuilder.Domainvalue.PostalAddressUse use, Hl7BaseVersion
			 baseVersion)
		{
			return !StandardDataType.AD_SEARCH.Type.Equals(dataType) && use != null && use.CodeValue != null && ALLOWABLE_ADDRESS_USES
				.Contains(use.CodeValue) && !(IsCeRx(baseVersion) && IsConfOrDir(use));
		}

		// error if CONF/DIR and CeRx
		private bool IsCeRx(Hl7BaseVersion baseVersion)
		{
			return baseVersion == Hl7BaseVersion.CERX;
		}

		private bool IsConfOrDir(Ca.Infoway.Messagebuilder.Domainvalue.PostalAddressUse use)
		{
			return Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.CONFIDENTIAL.CodeValue.Equals(use.CodeValue) ||
				 Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.DIRECT.CodeValue.Equals(use.CodeValue);
		}

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
