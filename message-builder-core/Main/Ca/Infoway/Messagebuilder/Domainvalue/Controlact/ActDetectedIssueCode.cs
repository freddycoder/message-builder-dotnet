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


using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Controlact
{
	/// <summary>The Enum ActDetectedIssueCode.</summary>
	/// <remarks>The Enum ActDetectedIssueCode. Identifies types of detected issues for Act class "ALRT"</remarks>
	[System.Serializable]
	public class ActDetectedIssueCode : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.ActDetectedIssueCode, Describable
	{
		static ActDetectedIssueCode()
		{
		}

		private const long serialVersionUID = -2117496114393701585L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode INSUFFICIENT_AUTHORIZATION = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("INSUFFICIENT_AUTHORIZATION", "NAT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode VALIDATION_ISSUE = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("VALIDATION_ISSUE", "VALIDAT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode IDENTIFIER_DOES_NOT_EXIST = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("IDENTIFIER_DOES_NOT_EXIST", "KEY204");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode IDENTIFIER_ALREADY_EXISTS = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("IDENTIFIER_ALREADY_EXISTS", "KEY205");

		/// <summary>
		/// The request is missing elements or contains elements which cause it to not meet
		/// the legal standards for actioning.
		/// </summary>
		/// <remarks>
		/// The request is missing elements or contains elements which cause it to not meet
		/// the legal standards for actioning.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode ILLEGAL = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("ILLEGAL", "ILLEGAL");

		/// <summary>The specified element is mandatory and was not included in the instance.</summary>
		/// <remarks>The specified element is mandatory and was not included in the instance.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode MISSING_MANDATORY_ELEMENT = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("MISSING_MANDATORY_ELEMENT", "MISSMAND");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode MISSING_CONDITIONAL_ELEMENT = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("MISSING_CONDITIONAL_ELEMENT", "MISSCOND");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode INVALID_FORMAT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("INVALID_FORMAT", "FORMAT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode LENGTH_OUT_OF_RANGE = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("LENGTH_OUT_OF_RANGE", "LEN_RANGE");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode LENGTH_IS_TOO_SHORT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("LENGTH_IS_TOO_SHORT", "LEN_SHORT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode LENGTH_IS_TOO_LONG = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("LENGTH_IS_TOO_LONG", "LEN_LONG");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode CODE_IS_NOT_VALID = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("CODE_IS_NOT_VALID", "CODE_INVAL");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode CODE_HAS_BEEN_DEPRECATED = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("CODE_HAS_BEEN_DEPRECATED", "CODE_DEPREC");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode DUPLICATE_VALUES_ARE_NOT_PERMITTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("DUPLICATE_VALUES_ARE_NOT_PERMITTED", "NODUPS"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode REPETITIONS_OUT_OF_RANGE = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("REPETITIONS_OUT_OF_RANGE", "REP_RANGE");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode REPETITIONS_BELOW_MINIMUM = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("REPETITIONS_BELOW_MINIMUM", "MINOCCURS");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode REPETITIONS_ABOVE_MAXIMUM = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("REPETITIONS_ABOVE_MAXIMUM", "MAXOCCURS");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode BUSINESS_CONSTRAINT_VIOLATION
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("BUSINESS_CONSTRAINT_VIOLATION", "BUS");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode FOOD_INTERACTION_ALERT = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("FOOD_INTERACTION_ALERT", "FOOD");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode THERAPEUTIC_PRODUCT_ALERT = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("THERAPEUTIC_PRODUCT_ALERT", "TPROD");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode DRUG_INTERACTION_ALERT = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("DRUG_INTERACTION_ALERT", "DRG");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode NATURAL_HEALTH_PRODUCT_ALERT
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("NATURAL_HEALTH_PRODUCT_ALERT", "NHP");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode NON_PRESCRIPTION_INTERACTION_ALERT
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("NON_PRESCRIPTION_INTERACTION_ALERT", "NONRX"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode OBSERVATION_ALERT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("OBSERVATION_ALERT", "OBSA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode AGE_ALERT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("AGE_ALERT", "AGE");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode HIGH_DOSE_FOR_AGE_ALERT = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("HIGH_DOSE_FOR_AGE_ALERT", "DOSEHINDA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode LOW_DOSE_FOR_AGE_ALERT = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("LOW_DOSE_FOR_AGE_ALERT", "DOSELINDA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode CONDITION_ALERT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("CONDITION_ALERT", "COND");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode HIGH_DOSE_FOR_HEIGHT_SURFACE_AREA_ALERT
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("HIGH_DOSE_FOR_HEIGHT_SURFACE_AREA_ALERT", 
			"DOSEHINDSA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode LOW_DOSE_FOR_HEIGHT_SURFACE_AREA_ALERT
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("LOW_DOSE_FOR_HEIGHT_SURFACE_AREA_ALERT", "DOSELINDSA"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode HIGH_DOSE_FOR_WEIGHT_ALERT = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("HIGH_DOSE_FOR_WEIGHT_ALERT", "DOSEHINDW");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode LOW_DOSE_FOR_WEIGHT_ALERT = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("LOW_DOSE_FOR_WEIGHT_ALERT", "DOSELINDW");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode LACTATION_ALERT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("LACTATION_ALERT", "LACT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode PREGNANCY_ALERT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("PREGNANCY_ALERT", "PREG");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode GENETIC_ALERT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("GENETIC_ALERT", "GEN");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode GENDER_ALERT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("GENDER_ALERT", "GEND");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode LAB_ALERT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("LAB_ALERT", "LAB");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode REACTION_ALERT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("REACTION_ALERT", "REACT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode ALLERGY_ALERT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("ALLERGY_ALERT", "ALGY");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode INTOLERANCE_ALERT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("INTOLERANCE_ALERT", "INT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode RELATED_REACTION_ALERT = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("RELATED_REACTION_ALERT", "RREACT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode RELATED_ALLERGY_ALERT = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("RELATED_ALLERGY_ALERT", "RALG");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode RELATED_PRIOR_REACTION_ALERT
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("RELATED_PRIOR_REACTION_ALERT", "RAR");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode RELATED_INTOLERANCE_ALERT = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("RELATED_INTOLERANCE_ALERT", "RINT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode COMMON_REACTION_ALERT = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("COMMON_REACTION_ALERT", "CREACT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode ENDLATE = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("ENDLATE", "ENDLATE");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode STRTLATE = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("STRTLATE", "STRTLATE");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode COMPLIANCE_ALERT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("COMPLIANCE_ALERT", "COMPLY");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode DUPLICATE_THERAPY_ALERT = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("DUPLICATE_THERAPY_ALERT", "DUPTHPY");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode DUPLICATE_THERAPEUTIC_ALASS_ALERT
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("DUPLICATE_THERAPEUTIC_ALASS_ALERT", "DUPTHPCLS"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode DUPLICATE_GENERIC_ALERT = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("DUPLICATE_GENERIC_ALERT", "DUPTHPGEN");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode POTENTIAL_FRAUD = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("POTENTIAL_FRAUD", "FRAUD");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode COMMONLY_ABUSED_MISUSED_ALERT
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("COMMONLY_ABUSED_MISUSED_ALERT", "ABUSE");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode POLY_ORDERER_ALERT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("POLY_ORDERER_ALERT", "PLYDOC");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode POLY_PHARMACY_ALERT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("POLY_PHARMACY_ALERT", "PLYPHRM");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode DOSAGE_PROBLEM = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("DOSAGE_PROBLEM", "DOSE");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode DOSE_DURATION_ALERT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("DOSE_DURATION_ALERT", "DOSEDUR");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode DOSE_DURATION_HIGH_ALERT = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("DOSE_DURATION_HIGH_ALERT", "DOSEDURH");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode DOSE_DURATION_HIGH_FOR_INDICATION_ALERT
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("DOSE_DURATION_HIGH_FOR_INDICATION_ALERT", 
			"DOSEDURHIND");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode DOSE_DURATION_LOW_ALERT = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("DOSE_DURATION_LOW_ALERT", "DOSEDURL");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode DOSE_DURATION_LOW_FOR_INDICATION_ALERT
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("DOSE_DURATION_LOW_FOR_INDICATION_ALERT", "DOSEDURLIND"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode HIGH_DOSE_ALERT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("HIGH_DOSE_ALERT", "DOSEH");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode HIGH_DOSE_FOR_INDICATION_ALERT
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("HIGH_DOSE_FOR_INDICATION_ALERT", "DOSEHIND"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode DOSE_INTERVAL_ALERT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("DOSE_INTERVAL_ALERT", "DOSEIVL");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode DOSE_INTERVAL_FOR_INDICATION_ALERT
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("DOSE_INTERVAL_FOR_INDICATION_ALERT", "DOSEIVLIND"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode LOW_DOSE_ALERT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("LOW_DOSE_ALERT", "DOSEL");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode LOW_DOSE_FOR_INDICATION_ALERT
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("LOW_DOSE_FOR_INDICATION_ALERT", "DOSELIND"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode DOSAGE_CONDITION_ALERT = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("DOSAGE_CONDITION_ALERT", "DOSECOND");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode REFILL_TOO_LATE_ALERT = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("REFILL_TOO_LATE_ALERT", "TOOLATE");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode REFILL_TOO_SOON_ALERT = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode("REFILL_TOO_SOON_ALERT", "TOOSOON");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode PREVINEF = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("PREVINEF", "PREVINEF");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode PATPREF = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("PATPREF", "PATPREF");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode PATPREFALT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("PATPREFALT", "PATPREFALT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode FULFIL = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("FULFIL", "FULFIL");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode NO_LONGER_ACTIONABLE = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("NO_LONGER_ACTIONABLE", "NOTACTN");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode NOTEQUIV = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("NOTEQUIV", "NOTEQUIV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode NOTEQUIVTHER = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("NOTEQUIVTHER", "NOTEQUIVTHER");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode NOTEQUIVGEN = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("NOTEQUIVGEN", "NOTEQUIVGEN");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode TIMING = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("TIMING", "TIMING");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode MINFREQ = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("MINFREQ", "MINFREQ");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode INTERVAL = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("INTERVAL", "INTERVAL");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode ALLDONE = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("ALLDONE", "ALLDONE");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode HELD = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActDetectedIssueCode
			("HELD", "HELD");

		private string codeValue;

		private ActDetectedIssueCode(string name, string codeValue) : base(name)
		{
			// The ID of the patient, order, etc., was not found. Used for transactions other than additions.
			// The ID of the patient, order, etc., already exists. Used in response to addition transactions (Admit, New Order, etc.).
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_ACT_CODE.Root;
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystemName
		{
			get
			{
				return null;
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeValue
		{
			get
			{
				return this.codeValue;
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string Description
		{
			get
			{
				return DescribableUtil.GetDefaultDescription(this);
			}
		}
	}
}
