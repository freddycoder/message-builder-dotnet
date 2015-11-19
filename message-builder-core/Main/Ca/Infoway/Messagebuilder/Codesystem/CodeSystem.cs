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
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Codesystem
{
	/// <summary>The Enum CodeSystem.</summary>
	/// <remarks>The Enum CodeSystem. Groups a number of common Oids.</remarks>
	[System.Serializable]
	public class CodeSystem : EnumPattern, Oid
	{
		static CodeSystem()
		{
		}

		private const long serialVersionUID = 1L;

		/// <summary>The high-level OID for Canada.</summary>
		/// <remarks>
		/// The high-level OID for Canada.
		/// Note that "124" is the ISO 3166-1 3-digit numeric code for Canada.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem CANADA = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("CANADA", "2.16.124");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem HEALTH_CANADA = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("HEALTH_CANADA", "2.16.124.101.1.277");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem PROVINCE_OF_ONTARIO = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("PROVINCE_OF_ONTARIO", "2.16.124.8");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem ONTARIO_PROVINCIAL_GOVERNMENT = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("ONTARIO_PROVINCIAL_GOVERNMENT", "2.16.124.8.101");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem GOVERNMENT_OF_CANADA = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("GOVERNMENT_OF_CANADA", "2.16.124.101");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem SMART_SYSTEMS_FOR_HEALTH_AGENCY = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("SMART_SYSTEMS_FOR_HEALTH_AGENCY", "2.16.124.113588");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem INTELLIWARE = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("INTELLIWARE", "2.16.124.113620");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem INTELLIWARE_APPLICATIONS = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("INTELLIWARE_APPLICATIONS", "2.16.124.113620.1");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem INTELLIWARE_APPLICATIONS_PANACEA = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("INTELLIWARE_APPLICATIONS_PANACEA", "2.16.124.113620.1.1");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem INTELLIWARE_APPLICATIONS_TEAL = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("INTELLIWARE_APPLICATIONS_TEAL", "2.16.124.113620.1.2");

		/// <summary>Health Canada Natural Product Number (NPN).</summary>
		/// <remarks>Health Canada Natural Product Number (NPN).</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem NATURAL_PRODUCT_NUMBER = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("NATURAL_PRODUCT_NUMBER", "2.16.840.1.113883.5.1107");

		/// <summary>Online Product Identification Number Index of Nova Scotia (OPINIONs).</summary>
		/// <remarks>Online Product Identification Number Index of Nova Scotia (OPINIONs).</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem OPINIONS = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("OPINIONS", "2.16.840.1.113883.5.1102");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem ISO_3166_1_ALPHA_2 = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("ISO_3166_1_ALPHA_2", "1.0.3166.1.2.2");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem ISO_3166_1_ALPHA_3 = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("ISO_3166_1_ALPHA_3", "1.0.3166.1.2.3");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem SNOMED = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("SNOMED", "2.16.840.1.113883.6.96");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem DRUG_IDENTIFICATION_NUMBER = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("DRUG_IDENTIFICATION_NUMBER", "2.16.840.1.113883.5.1105");

		/// <summary>Logical Observation Identifier Names and Codes (LOINC).</summary>
		/// <remarks>Logical Observation Identifier Names and Codes (LOINC).</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem LOINC = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("LOINC", "2.16.840.1.113883.6.1");

		/// <summary>ICD10.</summary>
		/// <remarks>ICD10.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem ICD10 = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("ICD10", "2.16.840.1.113883.6.3");

		/// <summary>Newfoundland's health number is the Medical Care Plan (MCP).</summary>
		/// <remarks>Newfoundland's health number is the Medical Care Plan (MCP).</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem MEDICAL_CARE_PLAN = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("MEDICAL_CARE_PLAN", "2.16.840.1.113883.4.52");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem ECID = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("ECID", "2.16.840.1.113883.1.133");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem CANADIAN_CLASSIFICATION_OF_INTERVENTIONS = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("CANADIAN_CLASSIFICATION_OF_INTERVENTIONS", "2.16.840.1.113883.6.95");

		/// <summary>
		/// The unique License Number number assigned by the College of Physicians and Surgeons of Ontario (CPSO),
		/// Canada to identify each individual physician and surgeon.
		/// </summary>
		/// <remarks>
		/// The unique License Number number assigned by the College of Physicians and Surgeons of Ontario (CPSO),
		/// Canada to identify each individual physician and surgeon.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem CPSO_LISENSE_NUMBER = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("CPSO_LISENSE_NUMBER", "2.16.840.1.113883.4.347");

		/// <summary>
		/// This is the Oid used for ActReason code systems in the referrals
		/// application.
		/// </summary>
		/// <remarks>
		/// This is the Oid used for ActReason code systems in the referrals
		/// application.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem REFERRALS_ACT_REASON = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("REFERRALS_ACT_REASON", "2.16.124.8.101.99.1.1.39");

		/// <summary>
		/// This is the Oid used for HL7TriggerEventCode code systems in the referrals
		/// application.
		/// </summary>
		/// <remarks>
		/// This is the Oid used for HL7TriggerEventCode code systems in the referrals
		/// application.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem REFERRALS_TRIGGER_EVENT_CODE = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("REFERRALS_TRIGGER_EVENT_CODE", "2.16.124.8.101.99.1.1.40");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem REFERRALS_OHIP_BILLING_NUMBER = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("REFERRALS_OHIP_BILLING_NUMBER", "2.16.124.8.101.99.1.1.42");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem REFERRALS_OHIP_CARD_NUMBER = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("REFERRALS_OHIP_CARD_NUMBER", "2.16.124.8.101.99.1.2.1.7");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_ACKNOWLEDGEMENT_CONDITION = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_ACKNOWLEDGEMENT_CONDITION", "2.16.840.1.113883.5.1050");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_ACKNOWLEDGEMENT_DETAIL_CODE = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_ACKNOWLEDGEMENT_DETAIL_CODE", "2.16.840.1.113883.5.1100");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_ACKNOWLEDGEMENT_DETAIL_TYPE = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_ACKNOWLEDGEMENT_DETAIL_TYPE", "2.16.840.1.113883.5.1082");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_ACKNOWLEDGEMENT_TYPE = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_ACKNOWLEDGEMENT_TYPE", "2.16.840.1.113883.5.18");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_ACT_CLASS = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_ACT_CLASS", "2.16.840.1.113883.5.6");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_ACT_CODE = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_ACT_CODE", "2.16.840.1.113883.5.4");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_ACT_MOOD = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_ACT_MOOD", "2.16.840.1.113883.5.1001");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_ACT_PRIORITY = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_ACT_PRIORITY", "2.16.840.1.113883.5.7");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_ACT_REASON = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_ACT_REASON", "2.16.840.1.113883.5.8");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_ACT_RELATIONSHIP_SUBSET = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_ACT_RELATIONSHIP_SUBSET", "2.16.840.1.113883.19.5.2");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_ACT_SITE = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_ACT_SITE", "2.16.840.1.113883.5.1052");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_ACT_STATUS = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_ACT_STATUS", "2.16.840.1.113883.5.14");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_ACT_UNCERTAINTY = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_ACT_UNCERTAINTY", "2.16.840.1.113883.5.1053");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_ADMINISTRABLE_DRUG_FORM = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_ADMINISTRABLE_DRUG_FORM", "2.16.840.1.113883.19.5.3");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_ADMINISTRATIVE_GENDER = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_ADMINISTRATIVE_GENDER", "2.16.840.1.113883.5.1");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_ADDRESS_PART_TYPE = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_ADDRESS_PART_TYPE", "2.16.840.1.113883.5.16");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_ALLERGY_TEST_VALUE = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_ALLERGY_TEST_VALUE", "2.16.840.1.113883.5.1063");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_BODY_SITE = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_BODY_SITE", "2.16.840.1.113883.12.163");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_CONFIDENTIALITY = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_CONFIDENTIALITY", "2.16.840.1.113883.5.25");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_DOCUMENT_MEDIA_TYPES = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_DOCUMENT_MEDIA_TYPES", "2.16.840.1.113883.5.79");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_ENTITY_CODE = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_ENTITY_CODE", "2.16.840.1.113883.5.1060");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_ENTITY_NAME_QUALIFIER = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_ENTITY_NAME_QUALIFIER", "2.16.840.1.113883.5.43");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_ENTITY_NAME_USE = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_ENTITY_NAME_USE", "2.16.840.1.113883.5.45");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_HL7_STANDARD_VERSION_CODE = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_HL7_STANDARD_VERSION_CODE", "2.16.840.1.113883.5.1092");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_HUMAN_LANGUAGE = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_HUMAN_LANGUAGE", "2.16.840.1.113883.6.84");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_MESSAGE_WAITING_PRIORITY = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_MESSAGE_WAITING_PRIORITY", "2.16.840.1.113883.5.1083");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_NULL_FLAVOR = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_NULL_FLAVOR", "2.16.840.1.113883.5.1008");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_OBSERVATION_VALUE = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_OBSERVATION_VALUE", "2.16.840.1.113883.5.1063");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_OTHER_IDENTIFIER_ROLE_TYPE = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_OTHER_IDENTIFIER_ROLE_TYPE", "2.16.840.1.113883.2.20.5.2");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_PARTICIPATION_SIGNATURE = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_PARTICIPATION_SIGNATURE", "2.16.840.1.113883.5.89");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_PARTICIPATION_TYPE = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_PARTICIPATION_TYPE", "2.16.840.1.113883.5.90");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_POSTAL_ADDRESS_USE = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_POSTAL_ADDRESS_USE", "2.16.840.1.113883.5.1012");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_PROCESSING_MODE = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_PROCESSING_MODE", "2.16.840.1.113883.5.1064");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_QUERY_REQUEST_LIMIT = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_QUERY_REQUEST_LIMIT", "2.16.840.1.113883.5.1112");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_QUERY_PARAMETER_VALUE = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_QUERY_PARAMETER_VALUE", "2.16.840.1.113883.5.1096");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_QUERY_RESPONSE = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_QUERY_RESPONSE", "2.16.840.1.113883.5.1067");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_RESPONSE_MODE = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_RESPONSE_MODE", "2.16.840.1.113883.19.5.1");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_ROLE_CLASS = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_ROLE_CLASS", "2.16.840.1.113883.5.110");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_ROLE_CODE = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_ROLE_CODE", "2.16.840.1.113883.5.111");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_ROLE_STATUS = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_ROLE_STATUS", "2.16.840.1.113883.5.1068");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_ROUTE_OF_ADMINISTRATION = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_ROUTE_OF_ADMINISTRATION", "2.16.840.1.113883.5.112");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_SEVERITY_OBSERVATION = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_SEVERITY_OBSERVATION", "2.16.840.1.113883.5.1063");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_SUBSTITUTION_CONDITION = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_SUBSTITUTION_CONDITION", "2.16.840.1.113883.5.1071");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_TELECOMMUNICATION_ADDRESS_USE = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_TELECOMMUNICATION_ADDRESS_USE", "2.16.840.1.113883.5.1011");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_TIMING_EVENT = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_TIMING_EVENT", "2.16.840.1.113883.5.139");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_TRIGGER_EVENT_ID = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_TRIGGER_EVENT_ID", "2.16.840.1.113883.1.18");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_UNIFORM_UNIT_OF_MEASURE = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_UNIFORM_UNIT_OF_MEASURE", "2.16.840.1.113883.5.141");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem VOCABULARY_URL_SCHEME = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("VOCABULARY_URL_SCHEME", "2.16.840.1.113883.5.143");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem SC_TEMP = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("SC_TEMP", "2.16.840.1.113883.2.20.5.2");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem TOPIC_PRIORITY = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("TOPIC_PRIORITY", "2.16.840.1.113883.3.133.10.30.101.14");

		public static readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem SUBSCRIPTION_STATUS = new Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			("SUBSCRIPTION_STATUS", "2.16.840.1.113883.3.133.10.30.101.15");

		private readonly string root;

		private CodeSystem(string name, string root) : base(name)
		{
			// ------------------- Standard Vocabulary Domains -----------------------
			// ------------------- Newfoundland Defined Code Systems -----------------------
			this.root = root;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string Root
		{
			get
			{
				return this.root;
			}
		}
	}
}
