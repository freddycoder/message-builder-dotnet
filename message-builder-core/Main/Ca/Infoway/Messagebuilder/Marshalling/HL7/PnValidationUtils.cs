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
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	public class PnValidationUtils
	{
		private const int MAX_PART_LENGTH = 50;

		private const int MAX_PART_LENGTH_CERX = 30;

		private const int MAX_PARTS = 7;

		private static readonly IDictionary<Hl7BaseVersion, ICollection<string>> ALLOWABLE_NAME_USES_BY_VERSION = new Dictionary<
			Hl7BaseVersion, ICollection<string>>();

		private static readonly ICollection<string> ALLOWABLE_NAME_PARTS = new HashSet<string>();

		private static readonly ICollection<string> ALLOWABLE_NAME_PART_QUALIFIERS = new HashSet<string>();

		private static readonly ICollection<string> ALLOWABLE_NAME_USES = new HashSet<string>();

		static PnValidationUtils()
		{
			ICollection<string> mr2007Uses = new HashSet<string>();
			ICollection<string> cerxUses = new HashSet<string>();
			ALLOWABLE_NAME_USES.Add("C");
			// MR2009 allowable uses
			ALLOWABLE_NAME_USES.Add("L");
			ALLOWABLE_NAME_USES.Add("P");
			ALLOWABLE_NAME_USES.Add("OR");
			mr2007Uses.Add("C");
			mr2007Uses.Add("L");
			mr2007Uses.Add("P");
			mr2007Uses.Add("HC");
			cerxUses.Add("L");
			cerxUses.Add("P");
			ALLOWABLE_NAME_USES_BY_VERSION[Hl7BaseVersion.MR2007] = mr2007Uses;
			ALLOWABLE_NAME_USES_BY_VERSION[Hl7BaseVersion.CERX] = cerxUses;
			ALLOWABLE_NAME_PARTS.Add("family");
			ALLOWABLE_NAME_PARTS.Add("given");
			ALLOWABLE_NAME_PARTS.Add("prefix");
			ALLOWABLE_NAME_PARTS.Add("suffix");
			ALLOWABLE_NAME_PART_QUALIFIERS.Add("IN");
			ALLOWABLE_NAME_PART_QUALIFIERS.Add("BR");
			ALLOWABLE_NAME_PART_QUALIFIERS.Add("SP");
			ALLOWABLE_NAME_PART_QUALIFIERS.Add("CL");
		}

		public virtual void ValidatePersonName(PersonName personName, string type, Hl7BaseVersion baseVersion, XmlElement element
			, string propertyPath, Hl7Errors errors)
		{
			ValidatePersonNameUses(personName, type, baseVersion, element, errors, propertyPath);
			ValidatePersonNameParts(personName, type, baseVersion, element, propertyPath, errors);
		}

		private void ValidatePersonNameParts(PersonName personName, string type, Hl7BaseVersion baseVersion, XmlElement element, 
			string propertyPath, Hl7Errors errors)
		{
			bool isBasic = StandardDataType.PN_BASIC.Type.Equals(type);
			bool isSimple = StandardDataType.PN_SIMPLE.Type.Equals(type);
			bool isFull = StandardDataType.PN_FULL.Type.Equals(type);
			bool isSearch = StandardDataType.PN_SEARCH.Type.Equals(type);
			int countBlankParts = 0;
			bool isCeRx = IsCeRx(baseVersion);
			int numParts = personName.Parts.Count;
			if (numParts > MAX_PARTS)
			{
				CreateError("A maximum of " + MAX_PARTS + " name parts are allowed. Found: " + numParts, element, propertyPath, errors);
			}
			foreach (EntityNamePart personNamePart in personName.Parts)
			{
				int partLength = StringUtils.Length(personNamePart.Value);
				if ((isCeRx && partLength > MAX_PART_LENGTH_CERX) || partLength > MAX_PART_LENGTH)
				{
					CreateError("Name part types have a maximum allowed length of " + (isCeRx ? MAX_PART_LENGTH_CERX : MAX_PART_LENGTH) + " (length found: "
						 + partLength + ")", element, propertyPath, errors);
				}
				// error if part type not allowed
				NamePartType partType = personNamePart.Type;
				if (partType == null)
				{
					countBlankParts++;
					// no part type : only allowed for SIMPLE or, if CeRx, BASIC (max 1 in both cases)
					if (!isSimple && !(isBasic && isCeRx))
					{
						CreateError("Names without a part type are not allowed", element, propertyPath, errors);
					}
				}
				else
				{
					if (!ALLOWABLE_NAME_PARTS.Contains(partType.Value))
					{
						CreateError("Part type " + partType.Value + " is not allowed for " + type, element, propertyPath, errors);
					}
				}
				EntityNamePartQualifier qualifier = personNamePart.Qualifier;
				if (qualifier != null)
				{
					if (isCeRx || (!IsMr2007(baseVersion) && isBasic))
					{
						if (!"IN".Equals(qualifier.CodeValue))
						{
							CreateError("Qualifier '" + qualifier.CodeValue + "' not valid. Only 'IN' is allowed.", element, propertyPath, errors);
						}
					}
					else
					{
						if (!ALLOWABLE_NAME_PART_QUALIFIERS.Contains(qualifier.CodeValue))
						{
							CreateError("Qualifier '" + qualifier.CodeValue + "' not valid.", element, propertyPath, errors);
						}
					}
				}
			}
			if (isSimple && (countBlankParts > 1 || numParts > 1 || (numParts > 0 && countBlankParts == 0)))
			{
				CreateError("For PN.SIMPLE, only one simple name (a name without a part type) is allowed, and no other name parts are allowed."
					, element, propertyPath, errors);
			}
			if ((isBasic && isCeRx) && ((countBlankParts > 1) || (countBlankParts == 1 && numParts > 1)))
			{
				CreateError("For CeRx PN.BASIC a name can be provided without a part type, but only a single simple name (i.e. a name without a part type) is allowed in this case. Multiple name parts can be provided, but then all name parts must have part types."
					, element, propertyPath, errors);
			}
			// confirmed with CHI that simple and basic types do not have to provide any name parts 
			if (numParts == 0 && (isFull || isSearch))
			{
				CreateError("At least one name part must be specified.", element, propertyPath, errors);
			}
		}

		private void ValidatePersonNameUses(PersonName personName, string type, Hl7BaseVersion baseVersion, XmlElement element, Hl7Errors
			 errors, string propertyPath)
		{
			bool isSearch = StandardDataType.PN_SEARCH.Type.Equals(type);
			int numUses = personName.Uses.Count;
			// confirmed with CHI that multiple uses are allowed (specs don't indicate either way)
			if (numUses == 0 && !isSearch)
			{
				CreateError("PersonName 'use' property is mandatory.", element, propertyPath, errors);
			}
			foreach (Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse personNameUse in personName.Uses)
			{
				if (!IsAllowableUse(type, personNameUse, baseVersion))
				{
					CreateError("PersonNameUse is not valid: " + (personNameUse == null ? "null" : personNameUse.CodeValue), element, propertyPath
						, errors);
				}
			}
		}

		public virtual bool IsAllowableUse(string dataType, Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse personNameUse
			, Hl7BaseVersion baseVersion)
		{
			ICollection<string> allowableUses = ALLOWABLE_NAME_USES_BY_VERSION.SafeGet(baseVersion);
			if (allowableUses == null)
			{
				allowableUses = ALLOWABLE_NAME_USES;
			}
			return allowableUses.Contains(personNameUse.CodeValue);
		}

		private bool IsCeRx(Hl7BaseVersion baseVersion)
		{
			return baseVersion == Hl7BaseVersion.CERX;
		}

		private bool IsMr2007(Hl7BaseVersion baseVersion)
		{
			return baseVersion == Hl7BaseVersion.MR2007;
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
