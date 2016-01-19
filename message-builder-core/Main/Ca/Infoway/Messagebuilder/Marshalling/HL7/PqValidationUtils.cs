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


using System;
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Util.Xml;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	public class PqValidationUtils
	{
		public const int MAXIMUM_INTEGER_DIGITS = 11;

		public const int MAXIMUM_FRACTION_DIGITS = 2;

		public const int MAXIMUM_FRACTION_DIGITS_DRUG_LAB = 4;

		private const int MAX_ORIGINAL_TEXT_LENGTH = 150;

		public static readonly IDictionary<string, Int32?> maximum_fraction_digits_exceptions = new Dictionary<string, Int32?>();

		public static readonly IDictionary<string, Int32?> maximum_integer_digits_exceptions = new Dictionary<string, Int32?>();

		static PqValidationUtils()
		{
			maximum_fraction_digits_exceptions[Hl7BaseVersion.MR2007 + "_PQ.DRUG"] = 2;
			maximum_fraction_digits_exceptions[Hl7BaseVersion.MR2007 + "_PQ.LAB"] = 2;
			maximum_fraction_digits_exceptions[Hl7BaseVersion.CERX + "_PQ.DRUG"] = 2;
			maximum_fraction_digits_exceptions[Hl7BaseVersion.CERX + "_PQ.LAB"] = 2;
			maximum_integer_digits_exceptions[Hl7BaseVersion.CERX + "_PQ.BASIC"] = 8;
			maximum_integer_digits_exceptions[Hl7BaseVersion.CERX + "_PQ.DRUG"] = 8;
			maximum_integer_digits_exceptions[Hl7BaseVersion.CERX + "_PQ.TIME"] = 8;
			maximum_integer_digits_exceptions[Hl7BaseVersion.CERX + "_PQ.HEIGHTWEIGHT"] = 8;
		}

		// CeRx does not specify PQ.LAB or PQ.DISTANCE 
		public virtual int GetMaxFractionDigits(VersionNumber version, string typeAsString)
		{
			int maxFractionDigits = MAXIMUM_FRACTION_DIGITS;
			StandardDataType type = StandardDataType.GetByTypeName(typeAsString);
			if (StandardDataType.PQ_DRUG.Equals(type) || StandardDataType.PQ_LAB.Equals(type))
			{
				maxFractionDigits = MAXIMUM_FRACTION_DIGITS_DRUG_LAB;
			}
			Int32? exceptionValue = maximum_fraction_digits_exceptions.SafeGet(version.GetBaseVersion() + "_" + type);
			return (int)(exceptionValue == null ? maxFractionDigits : exceptionValue);
		}

		public virtual int GetMaxIntDigits(VersionNumber version, string type)
		{
			Int32? exceptionValue = maximum_integer_digits_exceptions.SafeGet(version.GetBaseVersion() + "_" + type);
			return (int)(exceptionValue == null ? MAXIMUM_INTEGER_DIGITS : exceptionValue);
		}

		private Type GetUnitTypeByHl7Type(string typeAsString, XmlElement element, string propertyPath, Hl7Errors errors, bool isR2
			)
		{
			StandardDataType type = StandardDataType.GetByTypeName(typeAsString);
			if (StandardDataType.PQ_BASIC.Equals(type))
			{
				return typeof(x_BasicUnitsOfMeasure);
			}
			else
			{
				if (StandardDataType.PQ_DRUG.Equals(type))
				{
					return typeof(x_DrugUnitsOfMeasure);
				}
				else
				{
					if (StandardDataType.PQ_TIME.Equals(type))
					{
						return typeof(x_TimeUnitsOfMeasure);
					}
					else
					{
						if (StandardDataType.PQ_LAB.Equals(type))
						{
							return typeof(x_LabUnitsOfMeasure);
						}
						else
						{
							if (StandardDataType.PQ_HEIGHTWEIGHT.Equals(type))
							{
								return typeof(x_HeightOrWeightObservationUnitsOfMeasure);
							}
							else
							{
								if (StandardDataType.PQ_DISTANCE.Equals(type))
								{
									return typeof(x_DistanceObservationUnitsOfMeasure);
								}
								else
								{
									if (!isR2)
									{
										CreateWarning(System.String.Format("Type \"{0}\" is not a valid PQ type", typeAsString), element, propertyPath, errors);
									}
									return typeof(Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive);
								}
							}
						}
					}
				}
			}
		}

		public virtual BigDecimal ValidateValue(string value, VersionNumber version, string type, bool hasNullFlavor, XmlElement 
			element, string propertyPath, Hl7Errors errors)
		{
			int maxIntDigits = this.GetMaxIntDigits(version, type);
			int maxFractionDigits = this.GetMaxFractionDigits(version, type);
			bool alreadyWarnedAboutValue = false;
			BigDecimal result = null;
			if (StringUtils.IsBlank(value))
			{
				if (!hasNullFlavor)
				{
					CreateWarning("No value provided for physical quantity", element, propertyPath, errors);
				}
			}
			else
			{
				if (NumberUtil.IsNumber(value))
				{
					string integerPart = value.Contains(".") ? StringUtils.SubstringBefore(value, ".") : value;
					string decimalPart = value.Contains(".") ? StringUtils.SubstringAfter(value, ".") : string.Empty;
					string errorMessage = "PhysicalQuantity for {0}/{1} can contain a maximum of {2} {3} places";
					if (StringUtils.Length(decimalPart) > maxFractionDigits)
					{
						CreateWarning(System.String.Format(errorMessage, version.GetBaseVersion(), type, maxFractionDigits, "decimal"), element, 
							propertyPath, errors);
					}
					if (StringUtils.Length(integerPart) > maxIntDigits)
					{
						CreateWarning(System.String.Format(errorMessage, version.GetBaseVersion(), type, maxIntDigits, "integer"), element, propertyPath
							, errors);
					}
					if (!StringUtils.IsNumeric(integerPart) || !StringUtils.IsNumeric(decimalPart))
					{
						alreadyWarnedAboutValue = true;
						CreateWarning(System.String.Format("value \"{0}\" must contain digits only", value), element, propertyPath, errors);
					}
				}
				try
				{
					result = new BigDecimal(value);
				}
				catch (FormatException)
				{
					if (!alreadyWarnedAboutValue)
					{
						CreateWarning(System.String.Format("value \"{0}\" is not a valid decimal value", value), element, propertyPath, errors);
					}
				}
			}
			return result;
		}

		public virtual BigDecimal ValidateValueR2(string value, VersionNumber version, string type, bool hasNullFlavor, XmlElement
			 element, string propertyPath, Hl7Errors errors)
		{
			BigDecimal result = null;
			if (!StringUtils.IsBlank(value))
			{
				try
				{
					result = new BigDecimal(value);
				}
				catch (FormatException)
				{
					CreateWarning(System.String.Format("value \"{0}\" is not a valid decimal value", value), element, propertyPath, errors);
				}
			}
			return result;
		}

		public virtual Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive ValidateUnits(string type, string unitsAsString
			, XmlElement element, string propertyPath, Hl7Errors errors, bool isR2)
		{
			Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive units = null;
			if (StringUtils.IsNotBlank(unitsAsString))
			{
				units = (Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive)CodeResolverRegistry.Lookup(this.GetUnitTypeByHl7Type
					(type, element, propertyPath, errors, isR2), unitsAsString);
				if (units == null)
				{
					CreateWarning(System.String.Format("Unit \"{0}\" is not valid for type {1}", unitsAsString, type), element, propertyPath, 
						errors);
				}
			}
			return units;
		}

		public virtual void ValidateOriginalText(string typeAsString, string originalText, bool hasAnyValues, bool hasNullFlavor, 
			VersionNumber version, XmlElement element, string propertyPath, Hl7Errors errors)
		{
			StandardDataType type = StandardDataType.GetByTypeName(typeAsString);
			bool hasOriginalText = StringUtils.IsNotBlank(originalText);
			if (hasOriginalText)
			{
				// only PQ.LAB is allowed to have originalText
				if (!StandardDataType.PQ_LAB.Equals(type))
				{
					CreateWarning(System.String.Format("Type {0} not allowed to have originalText. For physical quantity types, originalText is only allowed for PQ.LAB."
						, typeAsString), element, propertyPath, errors);
				}
				else
				{
					// no more than 150 characters
					int length = originalText.Length;
					if (length > MAX_ORIGINAL_TEXT_LENGTH)
					{
						CreateWarning(System.String.Format("PQ.LAB originalText has {0} characters, but only {1} are allowed.", length, MAX_ORIGINAL_TEXT_LENGTH
							), element, propertyPath, errors);
					}
				}
			}
			// TM - HACK: these restrictions don't seem to apply to the R2 datatype version of PQ.LAB; currently only BC using this (refactor when implementing R2 datatypes)
			if (StandardDataType.PQ_LAB.Equals(type) && hasNullFlavor && !SpecificationVersion.IsExactVersion(version, SpecificationVersion
				.V02R04_BC))
			{
				if (!hasOriginalText)
				{
					CreateWarning("For PQ.LAB values, originalText is mandatory when set to a NullFlavor.", element, propertyPath, errors);
				}
				if (hasAnyValues)
				{
					CreateWarning("PQ.LAB can not have quantity or units specified when set to a NullFlavor.", element, propertyPath, errors);
				}
			}
		}

		private void CreateWarning(string errorMessage, XmlElement element, string propertyPath, Hl7Errors errors)
		{
			Hl7Error error = null;
			if (element != null)
			{
				error = new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, ErrorLevel.ERROR, errorMessage + " (" + XmlDescriber.DescribeSingleElement
					(element) + ")", element);
			}
			else
			{
				// assuming this has a property path
				error = new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, ErrorLevel.ERROR, errorMessage, propertyPath);
			}
			errors.AddHl7Error(error);
		}
	}
}
