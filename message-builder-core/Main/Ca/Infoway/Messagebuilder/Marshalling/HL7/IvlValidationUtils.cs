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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	public class IvlValidationUtils
	{
		internal bool isUncertainRangeValidation;

		public IvlValidationUtils() : this(false)
		{
		}

		public IvlValidationUtils(bool isUncertainRangeValidation)
		{
			this.isUncertainRangeValidation = isUncertainRangeValidation;
		}

		public virtual string ValidateSpecializationType(string type, string specializationType, IList<string> errors)
		{
			string resultType = type;
			if (StandardDataType.IVL_FULL_DATE_WITH_TIME.Type.Equals(type))
			{
				// assume type to default to FULLDATETIME
				resultType = StandardDataType.IVL_FULL_DATE_TIME.Type;
				if (StringUtils.IsBlank(specializationType) || "IVL".Equals(specializationType))
				{
					if (Ca.Infoway.Messagebuilder.BooleanUtils.ValueOf(Runtime.GetProperty(TsDateFormats.ABSTRACT_TS_IGNORE_SPECIALIZATION_TYPE_ERROR_PROPERTY_NAME
						)))
					{
					}
					else
					{
						// do nothing - error message is to be suppressed
						errors.Add("IVL<TS.FULLDATEWITHTIME> is an abstract type. A specialization type must be provided. IVL<TS.FULLDATETIME> will be assumed."
							);
					}
				}
				else
				{
					StandardDataType concreteType = StandardDataType.GetByTypeName(specializationType);
					if (concreteType == StandardDataType.IVL_FULL_DATE || concreteType == StandardDataType.IVL_FULL_DATE_TIME || concreteType
						 == StandardDataType.IVL_FULL_DATE_PART_TIME)
					{
						resultType = specializationType;
					}
					else
					{
						errors.Add("Invalid specializationType provided for abstract type IVL<TS.FULLDATEWITHTIME>. IVL<TS.FULLDATETIME> will be assumed."
							);
					}
				}
			}
			return resultType;
		}

		public virtual IList<string> ValidateCorrectElementsProvided(string type, VersionNumber version, bool lowProvided, bool highProvided
			, bool centerProvided, bool widthProvided)
		{
			IList<string> errors = new List<string>();
			StandardDataType standardDataType = StandardDataType.GetByTypeName(type);
			bool isCeRx = SpecificationVersion.IsVersion(standardDataType, version, Hl7BaseVersion.CERX);
			string typeWithoutParameters = Hl7DataTypeName.GetTypeWithoutParameters(type);
			string parameterizedType = Hl7DataTypeName.GetParameterizedType(type);
			string unqualifiedParameterizedType = Hl7DataTypeName.Unqualify(parameterizedType);
			StandardDataType ivlType = StandardDataType.GetByTypeName(typeWithoutParameters);
			StandardDataType innerType = StandardDataType.GetByTypeName(parameterizedType);
			StandardDataType baseInnerType = StandardDataType.GetByTypeName(unqualifiedParameterizedType);
			int numberOfCorrectlyProvidedElements = this.CountProvidedElements(lowProvided, highProvided, centerProvided, widthProvided
				);
			if (lowProvided && this.IsLowProhibited(ivlType))
			{
				numberOfCorrectlyProvidedElements--;
				errors.Add(this.CreateIncorrectElementErrorMessage(type, "low"));
			}
			if (highProvided && this.IsHighProhibited(ivlType))
			{
				numberOfCorrectlyProvidedElements--;
				errors.Add(this.CreateIncorrectElementErrorMessage(type, "high"));
			}
			if (widthProvided && this.IsWidthProhibited(ivlType, innerType, baseInnerType))
			{
				numberOfCorrectlyProvidedElements--;
				errors.Add(this.CreateIncorrectElementErrorMessage(type, "width"));
			}
			if (centerProvided && this.IsCenterProhibited(isCeRx, innerType))
			{
				numberOfCorrectlyProvidedElements--;
				errors.Add(this.CreateIncorrectElementErrorMessage(type, "center"));
			}
			if (this.IncorrectNumberOfElementsProvided(numberOfCorrectlyProvidedElements, ivlType))
			{
				errors.Add(this.CreateWrongNumberOfElementsProvidedErrorMessage(isCeRx, type, ivlType, innerType, baseInnerType));
			}
			return errors;
		}

		public virtual IList<string> ValidateCorrectElementsProvidedForR2(bool lowProvided, bool highProvided, bool centerProvided
			, bool widthProvided)
		{
			IList<string> errors = new List<string>();
			int numProvidedElements = this.CountProvidedElements(lowProvided, highProvided, centerProvided, widthProvided);
			if (numProvidedElements > 2)
			{
				errors.Add("Too many interval properties specified. Intervals allow for at most two of low/high/center/width.");
			}
			// not allowed according to schemas: low/center high/center
			if (centerProvided && (lowProvided || highProvided))
			{
				errors.Add("For intervals, center is only allowed on its own or with width.");
			}
			return errors;
		}

		public virtual IList<string> DoOtherValidations(string type, NullFlavor lowNullFlavor, NullFlavor centerNullFlavor, NullFlavor
			 highNullFlavor, NullFlavor widthNullFlavor, Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive widthTimeUnits
			)
		{
			IList<string> errors = new List<string>();
			string parameterizedType = Hl7DataTypeName.GetParameterizedType(type);
			string unqualifiedParameterizedType = Hl7DataTypeName.Unqualify(parameterizedType);
			StandardDataType innerType = StandardDataType.GetByTypeName(parameterizedType);
			StandardDataType baseInnerType = StandardDataType.GetByTypeName(unqualifiedParameterizedType);
			if (!this.isUncertainRangeValidation)
			{
				if (baseInnerType == StandardDataType.PQ)
				{
					// TODO - VALIDATION - TM - this might apply to URG<PQ.x> (check with Lloyd)
					bool lowNull = (lowNullFlavor != null);
					bool highNull = (highNullFlavor != null);
					if (lowNull && highNull)
					{
						errors.Add("For " + GetIntervalOrRange() + "s of type PQ.x, one of (low, high) must be non-null.");
					}
				}
				else
				{
					EnsureNotPinfOrNinf("low", lowNullFlavor, errors);
					EnsureNotPinfOrNinf("high", highNullFlavor, errors);
					EnsureNotPinfOrNinf("center", centerNullFlavor, errors);
					EnsureNotPinfOrNinf("width", widthNullFlavor, errors);
				}
				// TS.DATE/TS.FULLDATE have width restrictions (does not seem to apply to URG; check with Lloyd)
				if (innerType == StandardDataType.TS_DATE || innerType == StandardDataType.TS_FULLDATE)
				{
					if (widthTimeUnits != null)
					{
						if (!Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit.IsDayBased(widthTimeUnits))
						{
							errors.Add("Width units must be days (d), weeks (wk), months (mo) or years (a).");
						}
					}
				}
			}
			return errors;
		}

		private void EnsureNotPinfOrNinf(string intervalElement, NullFlavor nullFlavor, IList<string> errors)
		{
			if (nullFlavor != null)
			{
				if (Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.POSITIVE_INFINITY.CodeValue.Equals(nullFlavor.CodeValue) 
					|| Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NEGATIVE_INFINITY.CodeValue.Equals(nullFlavor.CodeValue))
				{
					errors.Add("The " + intervalElement + " element can not have a null flavor of PINF or NINF.");
				}
			}
		}

		private bool IncorrectNumberOfElementsProvided(int numberOfCorrectlyProvidedElements, StandardDataType ivlType)
		{
			return ivlType == StandardDataType.IVL ? numberOfCorrectlyProvidedElements != 2 : numberOfCorrectlyProvidedElements != 1;
		}

		private int CountProvidedElements(bool lowProvided, bool highProvided, bool centerProvided, bool widthProvided)
		{
			return (lowProvided ? 1 : 0) + (highProvided ? 1 : 0) + (widthProvided ? 1 : 0) + (centerProvided ? 1 : 0);
		}

		private bool IsCenterProhibited(bool isCeRx, StandardDataType innerType)
		{
			// only allowed for *CeRx* types: IVL<TS.DATE> and IVL<TS.FULLDATE>
			// also allowed for types (of any version): URG<TS.DATE> 
			return !(isCeRx && !this.isUncertainRangeValidation && (innerType == StandardDataType.TS_DATE || innerType == StandardDataType
				.TS_FULLDATE)) && !(this.isUncertainRangeValidation && innerType == StandardDataType.TS_DATE);
		}

		private bool IsWidthProhibited(StandardDataType ivlType, StandardDataType innerType, StandardDataType baseInnerType)
		{
			return ivlType == StandardDataType.IVL_HIGH || ivlType == StandardDataType.IVL_LOW || innerType == StandardDataType.TS_FULLDATETIME
				 || baseInnerType == StandardDataType.PQ;
		}

		private bool IsHighProhibited(StandardDataType ivlType)
		{
			return ivlType == StandardDataType.IVL_WIDTH || ivlType == StandardDataType.IVL_LOW;
		}

		private bool IsLowProhibited(StandardDataType ivlType)
		{
			return ivlType == StandardDataType.IVL_WIDTH || ivlType == StandardDataType.IVL_HIGH;
		}

		private string CreateWrongNumberOfElementsProvidedErrorMessage(bool isCeRx, string type, StandardDataType ivlType, StandardDataType
			 innerType, StandardDataType baseInnerType)
		{
			return GetIntervalOrRange() + "s of type " + type + " must " + (ivlType == StandardDataType.IVL || ivlType == StandardDataType
				.URG ? "provide exactly 2 of" : "only provide") + ": " + (IsLowProhibited(ivlType) ? string.Empty : "low ") + (IsHighProhibited
				(ivlType) ? string.Empty : "high ") + (IsCenterProhibited(isCeRx, innerType) ? string.Empty : "center ") + (IsWidthProhibited
				(ivlType, innerType, baseInnerType) ? string.Empty : "width ");
		}

		private string CreateIncorrectElementErrorMessage(string type, string incorrectElement)
		{
			return "Element " + incorrectElement + " is not allowed for type " + type;
		}

		private string GetIntervalOrRange()
		{
			return this.isUncertainRangeValidation ? "Range" : "Interval";
		}
	}
}
