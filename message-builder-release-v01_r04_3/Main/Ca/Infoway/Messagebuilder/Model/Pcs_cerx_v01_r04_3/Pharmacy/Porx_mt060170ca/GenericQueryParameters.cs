/**
 * Copyright 2015 Canada Health Infoway, Inc.
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
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Porx_mt060170ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: Generic Query Parameters</summary>
     * 
     * <p>Root class for query definition</p> <p>Defines the set of 
     * parameters that may be used to filter the query 
     * response.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060170CA.ParameterList"})]
    public class GenericQueryParameters : MessagePartBean {

        private IVL<TS, Interval<PlatformDate>> administrationEffectivePeriodValue;
        private IVL<TS, Interval<PlatformDate>> amendedInTimeRangeValue;
        private CV diagnosisCodeValue;
        private CV drugCodeValue;
        private BL includeEventHistoryIndicatorValue;
        private BL includeIssuesIndicatorValue;
        private BL includeNotesIndicatorValue;
        private BL includePendingChangesIndicatorValue;
        private BL mostRecentDispenseForEachRxIndicatorValue;
        private CV otherIndicationCodeValue;
        private TS patientBirthDateValue;
        private CV patientGenderValue;
        private II patientIDValue;
        private PN patientNameValue;
        private CV symptomCodeValue;

        public GenericQueryParameters() {
            this.administrationEffectivePeriodValue = new IVLImpl<TS, Interval<PlatformDate>>();
            this.amendedInTimeRangeValue = new IVLImpl<TS, Interval<PlatformDate>>();
            this.diagnosisCodeValue = new CVImpl();
            this.drugCodeValue = new CVImpl();
            this.includeEventHistoryIndicatorValue = new BLImpl();
            this.includeIssuesIndicatorValue = new BLImpl();
            this.includeNotesIndicatorValue = new BLImpl();
            this.includePendingChangesIndicatorValue = new BLImpl();
            this.mostRecentDispenseForEachRxIndicatorValue = new BLImpl();
            this.otherIndicationCodeValue = new CVImpl();
            this.patientBirthDateValue = new TSImpl();
            this.patientGenderValue = new CVImpl();
            this.patientIDValue = new IIImpl();
            this.patientNameValue = new PNImpl();
            this.symptomCodeValue = new CVImpl();
        }
        /**
         * <summary>Business Name: Administration Effective Period</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060170CA.AdministrationEffectivePeriod.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows the 
         * requester to specify the administration period of interest 
         * for the retrieval. Useful for constraining run-away 
         * queries.</p> <p>For a prescription indicates the period for 
         * which the patient was deemed to be taking the 
         * drug.</p><p>Filter the result set to include only those 
         * medication records (prescription order, prescription 
         * dispense and other medication) for which the patient was 
         * deemed to be taking the drug.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"administrationEffectivePeriod/value"})]
        public Interval<PlatformDate> AdministrationEffectivePeriodValue {
            get { return this.administrationEffectivePeriodValue.Value; }
            set { this.administrationEffectivePeriodValue.Value = value; }
        }

        /**
         * <summary>Business Name: Amended In Time Range</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060170CA.AmendedInTimeRange.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows the 
         * requester to specify the event period of interest for the 
         * retrieval of medication records.</p><p>Useful for 
         * constraining run-away queries.</p> <p>Indicates that the 
         * returned records should be filtered to only include those 
         * which have been amended in some way (had status changed, 
         * been annotated, prescription was dispensed, etc.) within the 
         * indicated time-period. This will commonly be used to 
         * 'retrieve everything that has been amended since xxx'.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"amendedInTimeRange/value"})]
        public Interval<PlatformDate> AmendedInTimeRangeValue {
            get { return this.amendedInTimeRangeValue.Value; }
            set { this.amendedInTimeRangeValue.Value = value; }
        }

        /**
         * <summary>Business Name: Diagnosis Code</summary>
         * 
         * <remarks>Relationship: PORX_MT060170CA.DiagnosisCode.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for the 
         * retrieval of patient's prescriptions and/or dispenses based 
         * on prescribing indications.</p> <p>Indicates that the result 
         * set is to be filtered to include only those records 
         * pertaining to the specified diagnosis indication code.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"diagnosisCode/value"})]
        public DiagnosisValue DiagnosisCodeValue {
            get { return (DiagnosisValue) this.diagnosisCodeValue.Value; }
            set { this.diagnosisCodeValue.Value = value; }
        }

        /**
         * <summary>Business Name: Drug Code</summary>
         * 
         * <remarks>Relationship: PORX_MT060170CA.DrugCode.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for the 
         * retrieval of patient prescriptions and/or dispenses based on 
         * a specific medication that was ordered and/or dispensed. 
         * This will most commonly be used to filter for therapeutic 
         * classifications such as &quot;Anti-hypertensives&quot;.</p> 
         * <p>Indicates that the result set is to be filtered to 
         * include only those records pertaining to the specified drug. 
         * The code may refer to an orderable medication or a higher 
         * level drug classification.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"drugCode/value"})]
        public ClinicalDrug DrugCodeValue {
            get { return (ClinicalDrug) this.drugCodeValue.Value; }
            set { this.drugCodeValue.Value = value; }
        }

        /**
         * <summary>Business Name: Include Event History Indicator</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060170CA.IncludeEventHistoryIndicator.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for the 
         * flexibility of omitting/including history in the retrieval 
         * of the requested information.</p><p>Because the attribute is 
         * boolean, it must explicitly indicate a 'TRUE' or 'FALSE', 
         * and thus it is mandatory.</p> <p>Indicates whether or not 
         * history events associated with a prescription order, 
         * prescription dispense and/or active medications are to be 
         * returned along with the detailed 
         * information.</p><p>&quot;Pending&quot; changes will be 
         * returned regardless of the setting of this flag.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"includeEventHistoryIndicator/value"})]
        public bool? IncludeEventHistoryIndicatorValue {
            get { return this.includeEventHistoryIndicatorValue.Value; }
            set { this.includeEventHistoryIndicatorValue.Value = value; }
        }

        /**
         * <summary>Business Name: Include Issues Indicator</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060170CA.IncludeIssuesIndicator.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for the 
         * flexibility of omitting/including issues in the retrieval of 
         * medication detail profile data.</p><p>Because the attribute 
         * is boolean, it must explicitly indicate a 'TRUE' or 'FALSE', 
         * and thus it is mandatory.</p> <p>Indicates whether or not 
         * Issues (detected and/or managed) attached to the 
         * prescriptions, dispenses and other active medication records 
         * are to be returned along with the detailed information.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"includeIssuesIndicator/value"})]
        public bool? IncludeIssuesIndicatorValue {
            get { return this.includeIssuesIndicatorValue.Value; }
            set { this.includeIssuesIndicatorValue.Value = value; }
        }

        /**
         * <summary>Business Name: Include Notes Indicator</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060170CA.IncludeNotesIndicator.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for the 
         * flexibility of omitting/including notes in the retrieval of 
         * information for medication profile detail 
         * data.</p><p>Because the attribute is boolean, it must 
         * explicitly indicate a 'TRUE' or 'FALSE', and thus it is 
         * mandatory.</p> <p>Indicates whether or not notes attached to 
         * the prescription, dispenses and other active medication 
         * records are to be returned along with the detailed 
         * information.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"includeNotesIndicator/value"})]
        public bool? IncludeNotesIndicatorValue {
            get { return this.includeNotesIndicatorValue.Value; }
            set { this.includeNotesIndicatorValue.Value = value; }
        }

        /**
         * <summary>Business Name: Include Pending Changes Indicator</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060170CA.IncludePendingChangesIndicator.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for the 
         * flexibility of omitting/including future events in the 
         * retrieval of the requested information.</p><p>Because the 
         * attribute is boolean, it must explicitly indicate a 'TRUE' 
         * or 'FALSE', and thus it is mandatory.</p> <p>Indicates 
         * whether to include future changes (e.g. status changes that 
         * aren't effective yet) associated with a prescription order, 
         * prescription dispense and/or active medications are to be 
         * returned along with the detailed information.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"includePendingChangesIndicator/value"})]
        public bool? IncludePendingChangesIndicatorValue {
            get { return this.includePendingChangesIndicatorValue.Value; }
            set { this.includePendingChangesIndicatorValue.Value = value; }
        }

        /**
         * <summary>Business Name: Most Recent Dispense for each Rx 
         * Indicator</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060170CA.MostRecentDispenseForEachRxIndicator.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Helps to trim down 
         * volume of query response by eliminating multiple dispenses 
         * for the same prescription.</p><p>Because this is a boolean 
         * attribute whose value must be known to evaluate the query, 
         * the attribute is mandatory.</p> <p>Indicates whether or not 
         * a prescription dispenses returned on a query should be 
         * limited to only the most recent dispense for a 
         * prescription.</p><p>Allows the returning of at most one 
         * prescription dispense record per a prescription.</p><p>The 
         * default is 'TRUE' indicating that retrieval should be for 
         * only the most recent dispense for a prescription is to be 
         * included in a query result.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"mostRecentDispenseForEachRxIndicator/value"})]
        public bool? MostRecentDispenseForEachRxIndicatorValue {
            get { return this.mostRecentDispenseForEachRxIndicatorValue.Value; }
            set { this.mostRecentDispenseForEachRxIndicatorValue.Value = value; }
        }

        /**
         * <summary>Business Name: Other Indication Code</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060170CA.OtherIndicationCode.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for the 
         * retrieval of patient's prescriptions and/or dispenses based 
         * on prescribing indications.</p> <p>Indicates that the result 
         * set is to be filtered to include only those records 
         * pertaining to the specified non-condition-related indication 
         * code.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"otherIndicationCode/value"})]
        public ActNonConditionIndicationCode OtherIndicationCodeValue {
            get { return (ActNonConditionIndicationCode) this.otherIndicationCodeValue.Value; }
            set { this.otherIndicationCodeValue.Value = value; }
        }

        /**
         * <summary>Business Name: Patient Birth Date</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060170CA.PatientBirthDate.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Used to confirm 
         * the identity of the patient for the query and is therefore 
         * mandatory.</p> <p>Indicates the date on which the patient 
         * was born.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"patientBirthDate/value"})]
        public PlatformDate PatientBirthDateValue {
            get { return this.patientBirthDateValue.Value; }
            set { this.patientBirthDateValue.Value = value; }
        }

        /**
         * <summary>Business Name: Patient Gender</summary>
         * 
         * <remarks>Relationship: PORX_MT060170CA.PatientGender.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Used to confirm 
         * the identity of the patient for the query and is therefore 
         * mandatory.</p> <p>Indicates the gender (sex) of the 
         * patient.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"patientGender/value"})]
        public AdministrativeGender PatientGenderValue {
            get { return (AdministrativeGender) this.patientGenderValue.Value; }
            set { this.patientGenderValue.Value = value; }
        }

        /**
         * <summary>Business Name: B:Patient ID</summary>
         * 
         * <remarks>Relationship: PORX_MT060170CA.PatientID.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows filtering 
         * of result set by patient Id. This is a mandatory field 
         * because a patient must be specified for the query to be 
         * valid</p> <p>Identifier of the patient who is the subject of 
         * the patient medication query. Filter the result set to 
         * include only those records pertaining to the patient with 
         * this Id.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"patientID/value"})]
        public Identifier PatientIDValue {
            get { return this.patientIDValue.Value; }
            set { this.patientIDValue.Value = value; }
        }

        /**
         * <summary>Business Name: C:Patient Name</summary>
         * 
         * <remarks>Relationship: PORX_MT060170CA.PatientName.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Used to confirm 
         * the identity of the patient for the query and is therefore 
         * mandatory.</p> <p>The name by which the patient is 
         * known.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"patientName/value"})]
        public PersonName PatientNameValue {
            get { return this.patientNameValue.Value; }
            set { this.patientNameValue.Value = value; }
        }

        /**
         * <summary>Business Name: Symptom Code</summary>
         * 
         * <remarks>Relationship: PORX_MT060170CA.SymptomCode.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for the 
         * retrieval of patient's prescriptions and/or dispenses based 
         * on prescribing indications.</p> <p>Indicates that the result 
         * set is to be filtered to include only those records 
         * pertaining to the specified symptom indication code.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"symptomCode/value"})]
        public SymptomValue SymptomCodeValue {
            get { return (SymptomValue) this.symptomCodeValue.Value; }
            set { this.symptomCodeValue.Value = value; }
        }

    }

}