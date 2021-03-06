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

namespace Ca.Infoway.Messagebuilder.Domainvalue.Transport
{
	/// <summary>The Enum HL7TriggerEventCode.</summary>
	/// <remarks>
	/// The Enum HL7TriggerEventCode. The trigger event referenced by the Control Act instance.
	/// Identifies the trigger event that occurred. Values are drawn from the available trigger
	/// events used in the release of HL7 identified by the versionCode.
	/// </remarks>
	[System.Serializable]
	public class HL7TriggerEventCode : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.HL7TriggerEventCode, Describable
	{
		static HL7TriggerEventCode()
		{
		}

		private const long serialVersionUID = 4412605146444745176L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode NEW_PERSON_ADDED = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode
			("NEW_PERSON_ADDED", "PRPA_TE101001CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RESOLVE_DUPLICATE_PERSON_REGISTRATIONS
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RESOLVE_DUPLICATE_PERSON_REGISTRATIONS", "PRPA_TE101004CA"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode GET_PERSON_DEMOGRAPHICS_QUERY = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("GET_PERSON_DEMOGRAPHICS_QUERY", "PRPA_TE101101CA"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode GET_PERSON_DEMOGRAPHICS_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("GET_PERSON_DEMOGRAPHICS_RESPONSE", "PRPA_TE101102CA"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode FIND_CANDIDATES_QUERY = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode
			("FIND_CANDIDATES_QUERY", "PRPA_TE101103CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode FIND_CANDIDATES_RESPONSE = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("FIND_CANDIDATES_RESPONSE", "PRPA_TE101104CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode FIND_ASSOCIATED_PERSON_IDENTIFIERS_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("FIND_ASSOCIATED_PERSON_IDENTIFIERS_QUERY", "PRPA_TE101105CA"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode FIND_ASSOCIATED_PERSON_IDENTIFIERS_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("FIND_ASSOCIATED_PERSON_IDENTIFIERS_RESPONSE"
			, "PRPA_TE101106CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode ADD_PERSON_REQUEST = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode
			("ADD_PERSON_REQUEST", "PRPA_TE101201CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PERSON_CREATE_ACCEPT = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode
			("PERSON_CREATE_ACCEPT", "PRPA_TE101202CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PERSON_CREATE_REJECT = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode
			("PERSON_CREATE_REJECT", "PRPA_TE101203CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode REVISE_PERSON_REQUEST = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode
			("REVISE_PERSON_REQUEST", "PRPA_TE101204CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PERSON_REVISE_ACCEPT = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode
			("PERSON_REVISE_ACCEPT", "PRPA_TE101205CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PERSON_REVISE_REJECT = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode
			("PERSON_REVISE_REJECT", "PRPA_TE101206CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PERSON_NULLIFIED = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode
			("PERSON_NULLIFIED", "PRPA_TE101999CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PERSON_INFORMATION_REVISED = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PERSON_INFORMATION_REVISED", "PRPA_TE101002CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode MEDICATION_PROFILE_SUMMARY_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("MEDICATION_PROFILE_SUMMARY_QUERY", "PORX_TE060300UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode MEDICATION_PROFILE_SUMMARY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("MEDICATION_PROFILE_SUMMARY_RESPONSE", "PORX_TE060310UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode MEDICATION_PRESCRIPTION_DETAIL_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("MEDICATION_PRESCRIPTION_DETAIL_QUERY", "PORX_TE060200UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode MEDICATION_PRESCRIPTION_DETAIL_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("MEDICATION_PRESCRIPTION_DETAIL_RESPONSE", "PORX_TE060220UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode MEDICATION_PRESCRIPTION_SUMMARY_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("MEDICATION_PRESCRIPTION_SUMMARY_QUERY", "PORX_TE060460UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode MEDICATION_PRESCRIPTION_SUMMARY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("MEDICATION_PRESCRIPTION_SUMMARY_RESPONSE", "PORX_TE060480UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode MED_PRESCR_WITH_HIST_AND_DISPENSES_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("MED_PRESCR_WITH_HIST_AND_DISPENSES_QUERY", "PORX_TE060180UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode MED_PRESCR_WITH_HIST_AND_DISPENSES_QUERY_RESP
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("MED_PRESCR_WITH_HIST_AND_DISPENSES_QUERY_RESP"
			, "PORX_TE060240UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_DISPENSE_PROCESSING_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_DISPENSE_PROCESSING_REQUEST_ACCEPTED"
			, "PORX_TE020190UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_DISPENSE_PROCESSING_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_DISPENSE_PROCESSING_REQUEST_REFUSED", 
			"PORX_TE020270UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_DISPENSE_PROCESSING_REQUEST
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_DISPENSE_PROCESSING_REQUEST", "PORX_TE020220UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_DEVICE_DISP_PROCESSING_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_DEVICE_DISP_PROCESSING_REQUEST_ACCEPTED"
			, "PORX_TE020070UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_DEVICE_DISP_PROCESSING_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_DEVICE_DISP_PROCESSING_REQUEST_REFUSED"
			, "PORX_TE020030UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_DEVICE_DISP_PROCESSING_REQUEST
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_DEVICE_DISP_PROCESSING_REQUEST", "PORX_TE020150UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_DISPENSE_PICKUP_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_DISPENSE_PICKUP_REQUEST_ACCEPTED", "PORX_TE020100UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_DISPENSE_PICKUP_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_DISPENSE_PICKUP_REQUEST_REFUSED", "PORX_TE020140UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_DISPENSE_PICKUP_REQUEST
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_DISPENSE_PICKUP_REQUEST", "PORX_TE020170UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode DRUG_SEARCH_QUERY = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode
			("DRUG_SEARCH_QUERY", "POME_TE010100UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode DRUG_SEARCH_QUERY_RESPONSE = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("DRUG_SEARCH_QUERY_RESPONSE", "POME_TE010050UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_MEDICAL_CONDITIONS_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_MEDICAL_CONDITIONS_QUERY", "REPC_TE000012UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_MEDICAL_CONDITIONS_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_MEDICAL_CONDITIONS_QUERY_RESPONSE", 
			"REPC_TE000013UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_MEDICAL_CONDITION_WITH_HISTORY_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_MEDICAL_CONDITION_WITH_HISTORY_QUERY"
			, "REPC_TE000010UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_MEDICAL_CONDITION_WITH_HISTORY_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_MEDICAL_CONDITION_WITH_HISTORY_QUERY_RESPONSE"
			, "REPC_TE000011UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_MEDICAL_CONDITION_REQUEST
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_MEDICAL_CONDITION_REQUEST", "REPC_TE000017UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_MEDICAL_CONDITION_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_MEDICAL_CONDITION_REQUEST_ACCEPTED", 
			"REPC_TE000018UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_MEDICAL_CONDITION_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_MEDICAL_CONDITION_REQUEST_REFUSED", "REPC_TE000019UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode UPDATE_MEDICAL_CONDITION_REQUEST
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("UPDATE_MEDICAL_CONDITION_REQUEST", "REPC_TE000026UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode UPDATE_MEDICAL_CONDITION_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("UPDATE_MEDICAL_CONDITION_REQUEST_ACCEPTED", 
			"REPC_TE000027UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode UPDATE_MEDICAL_CONDITION_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("UPDATE_MEDICAL_CONDITION_REQUEST_REFUSED", "REPC_TE000028UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_ADVERSE_REACTION_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_ADVERSE_REACTION_QUERY", "REPC_TE000004UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_ADVERSE_REACTION_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_ADVERSE_REACTION_QUERY_RESPONSE", "REPC_TE000005UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_ADVERSE_REACTION_REQUEST
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_ADVERSE_REACTION_REQUEST", "REPC_TE000014UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_ADVERSE_REACTION_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_ADVERSE_REACTION_REQUEST_ACCEPTED", "REPC_TE000015UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_ADVERSE_REACTION_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_ADVERSE_REACTION_REQUEST_REFUSED", "REPC_TE000016UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode UPDATE_ADVERSE_REACTION_REQUEST
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("UPDATE_ADVERSE_REACTION_REQUEST", "REPC_TE000020UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode UPDATE_ADVERSE_REACTION_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("UPDATE_ADVERSE_REACTION_REQUEST_ACCEPTED", "REPC_TE000021UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode UPDATE_ADVERSE_REACTION_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("UPDATE_ADVERSE_REACTION_REQUEST_REFUSED", "REPC_TE000022UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode IMMUNIZATION_QUERY = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode
			("IMMUNIZATION_QUERY", "POIZ_TE010060UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode IMMUNIZATION_QUERY_RESPONSE = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("IMMUNIZATION_QUERY_RESPONSE", "POIZ_TE010070UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_IMMUNIZATION_REQUEST = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_IMMUNIZATION_REQUEST", "POIZ_TE010080UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_IMMUNIZATION_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_IMMUNIZATION_REQUEST_ACCEPTED", "POIZ_TE010040UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_IMMUNIZATION_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_IMMUNIZATION_REQUEST_REFUSED", "POIZ_TE010010UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode UPDATE_IMMUNIZATION_REQUEST = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("UPDATE_IMMUNIZATION_REQUEST", "POIZ_TE010090UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode UPDATE_IMMUNIZATION_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("UPDATE_IMMUNIZATION_REQUEST_ACCEPTED", "POIZ_TE010050UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode UPDATE_IMMUNIZATION_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("UPDATE_IMMUNIZATION_REQUEST_REFUSED", "POIZ_TE010020UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_PHARMACY_PROF_SERVICES_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_PHARMACY_PROF_SERVICES_QUERY", "REPC_TE000041UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_PHARMACY_PROF_SERVICES_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_PHARMACY_PROF_SERVICES_QUERY_RESPONSE"
			, "REPC_TE000042UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_REFUSAL_TO_DISPENSE_REQUEST
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_REFUSAL_TO_DISPENSE_REQUEST", "PORX_TE010460UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_REFUSAL_TO_DISPENSE_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_REFUSAL_TO_DISPENSE_REQUEST_ACCEPTED"
			, "PORX_TE010340UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_REFUSAL_TO_DISPENSE_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_REFUSAL_TO_DISPENSE_REQUEST_REFUSED", 
			"PORX_TE010020UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RETRACT_ACTION_REQUEST = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode
			("RETRACT_ACTION_REQUEST", "COMT_TE600003UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RETRACT_ACTION_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RETRACT_ACTION_REQUEST_ACCEPTED", "COMT_TE600001UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RETRACT_ACTION_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RETRACT_ACTION_REQUEST_REFUSED", "COMT_TE600002UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RETRACT_IMMUNIZATION_REQUEST = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RETRACT_IMMUNIZATION_REQUEST", "POIZ_IN010100CA"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RETRACT_IMMUNIZATION_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RETRACT_IMMUNIZATION_REQUEST_ACCEPTED", "POIZ_IN010110CA"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RETRACT_IMMUNIZATION_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RETRACT_IMMUNIZATION_REQUEST_REFUSED", "POIZ_IN010120CA"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode BROADCAST_MESSAGE = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode
			("BROADCAST_MESSAGE", "COMT_TE500001CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode ADD_PATIENT_NOTE_REQUEST = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("ADD_PATIENT_NOTE_REQUEST", "COMT_TE300001UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode ADD_PATIENT_NOTE_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("ADD_PATIENT_NOTE_REQUEST_ACCEPTED", "COMT_TE300002UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode ADD_PATIENT_NOTE_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("ADD_PATIENT_NOTE_REQUEST_REFUSED", "COMT_TE300003UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode DEPRECATE_PATIENT_NOTE_REQUEST
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("DEPRECATE_PATIENT_NOTE_REQUEST", "COMT_TE300101UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode DEPRECATE_PATIENT_NOTE_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("DEPRECATE_PATIENT_NOTE_REQUEST_ACCEPTED", "COMT_TE300102UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode DEPRECATE_PATIENT_NOTE_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("DEPRECATE_PATIENT_NOTE_REQUEST_REFUSED", "COMT_TE300103UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode ADD_NOTE_TO_RECORD_REQUEST = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("ADD_NOTE_TO_RECORD_REQUEST", "COMT_TE301001UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode ADD_NOTE_TO_RECORD_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("ADD_NOTE_TO_RECORD_REQUEST_ACCEPTED", "COMT_TE301002UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode ADD_NOTE_TO_RECORD_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("ADD_NOTE_TO_RECORD_REQUEST_REFUSED", "COMT_TE301003UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_NOTE_QUERY = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode
			("PATIENT_NOTE_QUERY", "COMT_TE300201UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_NOTE_QUERY_RESPONSE = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_NOTE_QUERY_RESPONSE", "COMT_TE300202UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_BASIC_OBSERVATIONS_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_BASIC_OBSERVATIONS_QUERY", "REPC_TE000054UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_BASIC_OBSERVATIONS_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_BASIC_OBSERVATIONS_QUERY_RESPONSE", 
			"REPC_TE000055UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PRESCRIPTION_RENEWAL_REQUEST = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PRESCRIPTION_RENEWAL_REQUEST", "PORX_TE010400UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PRESCRIPTION_RENEWAL_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PRESCRIPTION_RENEWAL_REQUEST_ACCEPTED", "PORX_TE010220UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PRESCRIPTION_RENEWAL_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PRESCRIPTION_RENEWAL_REQUEST_REFUSED", "PORX_TE010140UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode ACTIVATE_DEVICE_PRESCRIPTION_REQUEST
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("ACTIVATE_DEVICE_PRESCRIPTION_REQUEST", "PORX_TE010450UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode ACTIVATE_DEVICE_PRESCRIPTION_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("ACTIVATE_DEVICE_PRESCRIPTION_REQUEST_ACCEPTED"
			, "PORX_TE010180UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode ACTIVATE_DEVICE_PRESCRIPTION_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("ACTIVATE_DEVICE_PRESCRIPTION_REQUEST_REFUSED"
			, "PORX_TE010320UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_PATIENT_BASIC_OBSERVATION_REQUEST
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_PATIENT_BASIC_OBSERVATION_REQUEST", "REPC_TE000051UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_PATIENT_BASIC_OBSERVATION_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_PATIENT_BASIC_OBSERVATION_REQUEST_ACCEPTED"
			, "REPC_TE000052UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_PATIENT_BASIC_OBSERVATION_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_PATIENT_BASIC_OBSERVATION_REQUEST_REFUSED"
			, "REPC_TE000053UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_PROFESSIONAL_SERVICE_REQUEST
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_PROFESSIONAL_SERVICE_REQUEST", "REPC_TE000043UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_PROFESSIONAL_SERVICE_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_PROFESSIONAL_SERVICE_REQUEST_ACCEPTED"
			, "REPC_TE000044UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_PROFESSIONAL_SERVICE_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_PROFESSIONAL_SERVICE_REQUEST_REFUSED"
			, "REPC_TE000045UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_PROFESSIONAL_SERVICES_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_PROFESSIONAL_SERVICES_QUERY", "REPC_TE000041UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_PROFESSIONAL_SERVICES_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_PROFESSIONAL_SERVICES_QUERY_RESPONSE"
			, "REPC_TE000042UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_CONSENT_OR_OVERRIDE_REQUEST
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_CONSENT_OR_OVERRIDE_REQUEST", "RCMR_TE010003UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_CONSENT_OR_OVERRIDE_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_CONSENT_OR_OVERRIDE_REQUEST_ACCEPTED"
			, "RCMR_TE010001UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_CONSENT_OR_OVERRIDE_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_CONSENT_OR_OVERRIDE_REQUEST_REFUSED", 
			"RCMR_TE010002UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode DRUG_PRODUCT_DETAIL_QUERY = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("DRUG_PRODUCT_DETAIL_QUERY", "POME_TE010070UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode DRUG_PRODUCT_DETAIL_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("DRUG_PRODUCT_DETAIL_QUERY_RESPONSE", "POME_TE010020UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode DRUG_DOCUMENT_QUERY = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode
			("DRUG_DOCUMENT_QUERY", "POME_TE010090UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode DRUG_DOCUMENT_QUERY_RESPONSE = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("DRUG_DOCUMENT_QUERY_RESPONSE", "POME_TE010040UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode MEDICATION_DISPENSE_SUMMARY_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("MEDICATION_DISPENSE_SUMMARY_QUERY", "PORX_TE060050UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode MEDICATION_DISPENSE_SUMMARY_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("MEDICATION_DISPENSE_SUMMARY_QUERY_RESPONSE", 
			"PORX_TE060070UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode ABORT_DISPENSE_AUTHORIZATION_REQUEST
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("ABORT_DISPENSE_AUTHORIZATION_REQUEST", "PORX_TE010490UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode ABORT_DISPENSE_AUTHORIZATION_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("ABORT_DISPENSE_AUTHORIZATION_REQUEST_ACCEPTED"
			, "PORX_TE010600UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode ABORT_DISPENSE_AUTHORIZATION_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("ABORT_DISPENSE_AUTHORIZATION_REQUEST_REFUSED"
			, "PORX_TE010160UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode ABORT_PRESCRIPTION_REQUEST = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("ABORT_PRESCRIPTION_REQUEST", "PORX_TE010500UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode ABORT_PRESCRIPTION_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("ABORT_PRESCRIPTION_REQUEST_ACCEPTED", "PORX_TE010260UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode ABORT_PRESCRIPTION_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("ABORT_PRESCRIPTION_REQUEST_REFUSED", "PORX_TE010040UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_DISPENSE_REVERSAL_REQUEST
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_DISPENSE_REVERSAL_REQUEST", "PORX_TE020280UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_DISPENSE_REVERSAL_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_DISPENSE_REVERSAL_REQUEST_ACCEPTED", 
			"PORX_TE020090UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_DISPENSE_REVERSAL_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_DISPENSE_REVERSAL_REQUEST_REFUSED", "PORX_TE020290UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode ACTIVATE_PRESCRIPTION_REQUEST = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("ACTIVATE_PRESCRIPTION_REQUEST", "PORX_TE010730UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode ACTIVATE_PRESCRIPTION_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("ACTIVATE_PRESCRIPTION_REQUEST_ACCEPTED", "PORX_TE010660UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode ACTIVATE_PRESCRIPTION_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("ACTIVATE_PRESCRIPTION_REQUEST_REFUSED", "PORX_TE010700UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode CHANGE_ITEM_MASKING_REQUEST = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("CHANGE_ITEM_MASKING_REQUEST", "COMT_TE400001UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode CHANGE_ITEM_MASKING_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("CHANGE_ITEM_MASKING_REQUEST_ACCEPTED", "COMT_TE400002UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode CHANGE_ITEM_MASKING_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("CHANGE_ITEM_MASKING_REQUEST_REFUSED", "COMT_TE400003UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode ADD_ISSUE_MANAGEMENT_REQUEST = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("ADD_ISSUE_MANAGEMENT_REQUEST", "COMT_TE700001UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode ADD_ISSUE_MANAGEMENT_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("ADD_ISSUE_MANAGEMENT_REQUEST_ACCEPTED", "COMT_TE700002UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode ADD_ISSUE_MANAGEMENT_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("ADD_ISSUE_MANAGEMENT_REQUEST_REFUSED", "COMT_TE700003UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode REVISE_ASSIGNED_DISPENSE_RESPONSIBILITY_REQUEST
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("REVISE_ASSIGNED_DISPENSE_RESPONSIBILITY_REQUEST"
			, "PORX_TE010510UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode REVISE_ASSIGNED_DISPENSE_RESPONSIBILITY_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("REVISE_ASSIGNED_DISPENSE_RESPONSIBILITY_REQUEST_ACCEPTED"
			, "PORX_TE010330UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode REVISE_ASSIGNED_DISPENSE_RESPONSIBILITY_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("REVISE_ASSIGNED_DISPENSE_RESPONSIBILITY_REQUEST_REFUSED"
			, "PORX_TE010150UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode SUSPEND_PRESCRIPTION_REQUEST = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("SUSPEND_PRESCRIPTION_REQUEST", "PORX_TE010420UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode SUSPEND_PRESCRIPTION_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("SUSPEND_PRESCRIPTION_REQUEST_ACCEPTED", "PORX_TE010240UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode SUSPEND_PRESCRIPTION_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("SUSPEND_PRESCRIPTION_REQUEST_REFUSED", "PORX_TE010010UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RESUME_PRESCRIPTION_REQUEST = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RESUME_PRESCRIPTION_REQUEST", "PORX_TE010480UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RESUME_PRESCRIPTION_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RESUME_PRESCRIPTION_REQUEST_ACCEPTED", "PORX_TE010250UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RESUME_PRESCRIPTION_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RESUME_PRESCRIPTION_REQUEST_REFUSED", "PORX_TE010030UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode ADD_ALLERGY_INTOLERANCE_REQUEST
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("ADD_ALLERGY_INTOLERANCE_REQUEST", "REPC_TE000001UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode ADD_ALLERGY_INTOLERANCE_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("ADD_ALLERGY_INTOLERANCE_REQUEST_ACCEPTED", "REPC_TE000002UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode ADD_ALLERGY_INTOLERANCE_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("ADD_ALLERGY_INTOLERANCE_REQUEST_REFUSED", "REPC_TE000003UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode UPDATE_ALLERGY_INTOLERANCE_REQUEST
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("UPDATE_ALLERGY_INTOLERANCE_REQUEST", "REPC_TE000023UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode UPDATE_ALLERGY_INTOLERANCE_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("UPDATE_ALLERGY_INTOLERANCE_REQUEST_ACCEPTED"
			, "REPC_TE000024UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode UPDATE_ALLERGY_INTOLERANCE_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("UPDATE_ALLERGY_INTOLERANCE_REQUEST_REFUSED", 
			"REPC_TE000025UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_ALLERGY_INTOLERANCE_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_ALLERGY_INTOLERANCE_QUERY", "REPC_TE000006UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_ALLERGY_INTOLERANCE_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_ALLERGY_INTOLERANCE_QUERY_RESPONSE", 
			"REPC_TE000007UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_ALLERGY_INTOLERANCE_WITH_HISTORY_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_ALLERGY_INTOLERANCE_WITH_HISTORY_QUERY"
			, "REPC_TE000008UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_ALLERGY_INTOLERANCE_WITH_HISTORY_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_ALLERGY_INTOLERANCE_WITH_HISTORY_QUERY_RESPONSE"
			, "REPC_TE000009UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode MEDICATION_PRESCRIPTION_FILLS_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("MEDICATION_PRESCRIPTION_FILLS_QUERY", "PORX_TE060320UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode MEDICATION_PRESCRIPTION_FILLS_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("MEDICATION_PRESCRIPTION_FILLS_QUERY_RESPONSE"
			, "PORX_TE060340UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode MEDICATION_DISPENSE_DETAIL_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("MEDICATION_DISPENSE_DETAIL_QUERY", "PORX_TE060020UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode MEDICATION_DISPENSE_DETAIL_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("MEDICATION_DISPENSE_DETAIL_QUERY_RESPONSE", 
			"PORX_TE060040UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode OTHER_MEDICATION_DETAIL_QUERY = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("OTHER_MEDICATION_DETAIL_QUERY", "PORX_TE060440UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode OTHER_MEDICATION_DETAIL_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("OTHER_MEDICATION_DETAIL_QUERY_RESPONSE", "PORX_TE060450UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_OTHER_MEDICATION_REQUEST
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_OTHER_MEDICATION_REQUEST", "PORX_TE040060UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_OTHER_MEDICATION_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_OTHER_MEDICATION_REQUEST_ACCEPTED", "PORX_TE040030UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_OTHER_MEDICATION_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_OTHER_MEDICATION_REQUEST_REFUSED", "PORX_TE040010UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode UPDATE_OTHER_MEDICATION_REQUEST
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("UPDATE_OTHER_MEDICATION_REQUEST", "PORX_TE040070UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode UPDATE_OTHER_MEDICATION_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("UPDATE_OTHER_MEDICATION_REQUEST_ACCEPTED", "PORX_TE040040UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode UPDATE_OTHER_MEDICATION_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("UPDATE_OTHER_MEDICATION_REQUEST_REFUSED", "PORX_TE040020UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_SUPPLY_EVENT_REQUEST = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_SUPPLY_EVENT_REQUEST", "PORX_TE020130UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_SUPPLY_EVENT_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_SUPPLY_EVENT_REQUEST_ACCEPTED", "PORX_TE020010UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_SUPPLY_EVENT_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_SUPPLY_EVENT_REQUEST_REFUSED", "PORX_TE020020UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode MEDICATION_PROFILE_DETAIL_GENERIC_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("MEDICATION_PROFILE_DETAIL_GENERIC_QUERY", "PORX_TE060260UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode MEDICATION_PROFILE_DETAIL_GENERIC_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("MEDICATION_PROFILE_DETAIL_GENERIC_QUERY_RESPONSE"
			, "PORX_TE060270UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode DEVICE_PRESCRIPTION_SUMMARY_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("DEVICE_PRESCRIPTION_SUMMARY_QUERY", "PORX_TE060470UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode DEVICE_PRESCRIPTION_SUMMARY_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("DEVICE_PRESCRIPTION_SUMMARY_QUERY_RESPONSE", 
			"PORX_TE060490UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode DEVICE_PRESCRIPTION_DETAILS_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("DEVICE_PRESCRIPTION_DETAILS_QUERY", "PORX_TE060210UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode DEVICE_PRESCRIPTION_DETAILS_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("DEVICE_PRESCRIPTION_DETAILS_QUERY_RESPONSE", 
			"PORX_TE060230UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode DEVICE_PRESCRIPTION_WITH_HISTORY_AND_DISPENSE_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("DEVICE_PRESCRIPTION_WITH_HISTORY_AND_DISPENSE_QUERY"
			, "PORX_TE060190UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode DEVICE_PRESCRIPTION_WITH_HISTORY_AND_DISPENSE_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("DEVICE_PRESCRIPTION_WITH_HISTORY_AND_DISPENSE_QUERY_RESPONSE"
			, "PORX_TE060250UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode MEDICATION_PRESCRIPTION_WITH_HISTORY_AND_DISPENSES_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("MEDICATION_PRESCRIPTION_WITH_HISTORY_AND_DISPENSES_QUERY"
			, "PORX_TE060180UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode MEDICATION_PRESCRIPTION_WITH_HISTORY_AND_DISPENSES_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("MEDICATION_PRESCRIPTION_WITH_HISTORY_AND_DISPENSES_QUERY_RESPONSE"
			, "PORX_TE060240UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode UNFILLED_PRESCRIPTIONS_QUERY = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("UNFILLED_PRESCRIPTIONS_QUERY", "PORX_TE060520UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode UNFILLED_PRESCRIPTIONS_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("UNFILLED_PRESCRIPTIONS_QUERY_RESPONSE", "PORX_TE060530UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PROVIDER_DETAILS_QUERY = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode
			("PROVIDER_DETAILS_QUERY", "PRPM_TE306010CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PROVIDER_DETAILS_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PROVIDER_DETAILS_QUERY_RESPONSE", "PRPM_AR300011CA"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode MEDICATION_ORDER_ORDER_ACTIVATE_REQUEST_DRUG
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("MEDICATION_ORDER_ORDER_ACTIVATE_REQUEST_DRUG"
			, "PORX_TE010730UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_REFERRAL_REQUEST = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_REFERRAL_REQUEST", "REPC_TE000073UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_REFERRAL_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_REFERRAL_REQUEST_ACCEPTED", "REPC_TE000074UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode RECORD_REFERRAL_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("RECORD_REFERRAL_REQUEST_REFUSED", "REPC_TE000075UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_REFERRAL_SUMMARIES_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_REFERRAL_SUMMARIES_QUERY", "REPC_TE000084UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_REFERRAL_SUMMARIES_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_REFERRAL_SUMMARIES_QUERY_RESPONSE", 
			"REPC_TE000085UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_REFERRAL_DETAILS_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_REFERRAL_DETAILS_QUERY", "REPC_TE000090UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_REFERRAL_DETAILS_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_REFERRAL_DETAILS_QUERY_RESPONSE", "REPC_TE000091UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode UPDATE_PASSWORD_REQUEST = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("UPDATE_PASSWORD_REQUEST", "NLPN_TE100200CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode UPDATE_PASSWORD_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("UPDATE_PASSWORD_REQUEST_ACCEPTED", "NLPN_TE100210CA"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode UPDATE_PASSWORD_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("UPDATE_PASSWORD_REQUEST_REFUSED", "NLPN_TE100220CA"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode SEND_POLL_REQUEST = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode
			("SEND_POLL_REQUEST", "MCCI_TE100001UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode SEND_POLL_MESSAGE_ACCEPT_ACKOWLEDGEMENT
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("SEND_POLL_MESSAGE_ACCEPT_ACKOWLEDGEMENT", "MCCI_TE000002UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode ACCEPT_ACK_POLL_FOR_NEXT_MESSAGE_IN_QUEUE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("ACCEPT_ACK_POLL_FOR_NEXT_MESSAGE_IN_QUEUE", 
			"MCCI_TE000003UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode EXCEPTION_ACKOWLEDGEMENT_IN_RESPONSE_TO_POLL_REQUEST
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("EXCEPTION_ACKOWLEDGEMENT_IN_RESPONSE_TO_POLL_REQUEST"
			, "MCCI_TE000004UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode BROADCAST_DETAILS_RESPONSE = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("BROADCAST_DETAILS_RESPONSE", "NLPN_TE100110CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode BROADCAST_TOPICS_QUERY = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode
			("BROADCAST_TOPICS_QUERY", "NLPN_TE100120CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode BROADCAST_TOPICS_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("BROADCAST_TOPICS_QUERY_RESPONSE", "NLPN_TE100130CA"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode SUBSCRIBE_BROADCAST_TOPIC_REQUEST
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("SUBSCRIBE_BROADCAST_TOPIC_REQUEST", "NLPN_TE100140CA"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode SUBSCRIBE_BROADCAST_TOPIC_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("SUBSCRIBE_BROADCAST_TOPIC_REQUEST_ACCEPTED", 
			"NLPN_TE100150CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode SUBSCRIBE_BROADCAST_TOPIC_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("SUBSCRIBE_BROADCAST_TOPIC_REQUEST_REFUSED", 
			"NLPN_TE100160CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode LOCATION_SUMMARY_QUERY = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode
			("LOCATION_SUMMARY_QUERY", "PRLO_TE202010CA", "NEWFOUNDLAND");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode LOCATION_SUMMARY_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("LOCATION_SUMMARY_QUERY_RESPONSE", "PRLO_TE202011CA"
			, "NEWFOUNDLAND");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode LOCATION_DETAILS_QUERY = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode
			("LOCATION_DETAILS_QUERY", "PRLO_TE202012CA", "NEWFOUNDLAND");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode LOCATION_DETAILS_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("LOCATION_DETAILS_QUERY_RESPONSE", "PRLO_TE202013CA"
			, "NEWFOUNDLAND");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_CARE_COMPOSITION_SUMMARIES_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_CARE_COMPOSITION_SUMMARIES_QUERY", "REPC_TE041100UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_CARE_COMPOSITION_SUMMARIES_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_CARE_COMPOSITION_SUMMARIES_QUERY_RESPONSE"
			, "REPC_TE041200UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_DISCHARGE_CARE_SUMMARIES_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_DISCHARGE_CARE_SUMMARIES_QUERY", "REPC_TE000086CA"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_DISCHARGE_CARE_SUMMARIES_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_DISCHARGE_CARE_SUMMARIES_QUERY_RESPONSE"
			, "REPC_TE000087CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_DISCHARGE_CARE_SUMMARY_DETAILS_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_DISCHARGE_CARE_SUMMARY_DETAILS_QUERY"
			, "REPC_TE000092CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_DISCHARGE_CARE_SUMMARY_DETAILS_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_DISCHARGE_CARE_SUMMARY_DETAILS_QUERY_RESPONSE"
			, "REPC_TE000093CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PRESCRIPTION_CLINICAL_PRE_DETERMINATION_REQUEST
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PRESCRIPTION_CLINICAL_PRE_DETERMINATION_REQUEST"
			, "PORX_TE010720CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PRESCRIPTION_CLINICAL_PRE_DETERMINATION_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PRESCRIPTION_CLINICAL_PRE_DETERMINATION_REQUEST_ACCEPTED"
			, "PORX_TE010670CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PRESCRIPTION_CLINICAL_PRE_DETERMINATION_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PRESCRIPTION_CLINICAL_PRE_DETERMINATION_REQUEST_REFUSED"
			, "PORX_TE010690CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_IMMUNIZATION_PROFILE_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_IMMUNIZATION_PROFILE_QUERY", "POIZ_TE070010UV"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_IMMUNIZATION_PROFILE_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_IMMUNIZATION_PROFILE_QUERY_RESPONSE"
			, "POIZ_TE070020UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode LAB_TEST_RESULTS_QUERY = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode
			("LAB_TEST_RESULTS_QUERY", "POLB_TE304000CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode LAB_TEST_RESULTS_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("LAB_TEST_RESULTS_QUERY_RESPONSE", "POLB_TE304001CA"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode UNSOLICITED_LAB_TEST_RESULTS_REQUEST
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("UNSOLICITED_LAB_TEST_RESULTS_REQUEST", "POLB_TE004200CA"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode UNSOLICITED_LAB_TEST_RESULTS_REQUEST_ACCEPTED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("UNSOLICITED_LAB_TEST_RESULTS_REQUEST_ACCEPTED"
			, "POLB_TE004001CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode UNSOLICITED_LAB_TEST_RESULTS_REQUEST_REFUSED
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("UNSOLICITED_LAB_TEST_RESULTS_REQUEST_REFUSED"
			, "POLB_TE004600CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_DRUG_CONTRAINDICATIONS_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_DRUG_CONTRAINDICATIONS_QUERY", "PORX_TE050040CA"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode PATIENT_DRUG_CONTRAINDICATIONS_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("PATIENT_DRUG_CONTRAINDICATIONS_QUERY_RESPONSE"
			, "PORX_TE050030CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode CONTRAINDICATION_CHECKING_SET_OF_DRUGS_QUERY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("CONTRAINDICATION_CHECKING_SET_OF_DRUGS_QUERY"
			, "PORX_TE050040CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode CONTRAINDICATION_CHECKING_SET_OF_DRUGS_QUERY_RESPONSE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode("CONTRAINDICATION_CHECKING_SET_OF_DRUGS_QUERY_RESPONSE"
			, "PORX_TE050030CA");

		private readonly string codeValue;

		private readonly Ca.Infoway.Messagebuilder.Codesystem.CodeSystem codeSystem;

		private readonly string version;

		private HL7TriggerEventCode(string name, string codeValue) : this(name, codeValue, Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			.VOCABULARY_TRIGGER_EVENT_ID, null)
		{
		}

		private HL7TriggerEventCode(string name, string codeValue, string version) : this(name, codeValue, Ca.Infoway.Messagebuilder.Codesystem.CodeSystem
			.VOCABULARY_TRIGGER_EVENT_ID, version)
		{
		}

		private HL7TriggerEventCode(string name, string codeValue, Ca.Infoway.Messagebuilder.Codesystem.CodeSystem codeSystem) : 
			this(name, codeValue, codeSystem, null)
		{
		}

		private HL7TriggerEventCode(string name, string codeValue, Ca.Infoway.Messagebuilder.Codesystem.CodeSystem codeSystem, string
			 version) : base(name)
		{
			// BCH: These seem to vary from version to version
			// TM - NEWFOUNDLAND TEST HACK
			this.codeValue = codeValue;
			this.codeSystem = codeSystem;
			this.version = version;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return this.codeSystem == null ? Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_TRIGGER_EVENT_ID.Root : this.
					codeSystem.Root;
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

		/// <summary>Gets the version.</summary>
		/// <remarks>Gets the version.</remarks>
		/// <returns>the version</returns>
		public virtual string GetVersion()
		{
			return this.version;
		}
	}
}
