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
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Porx_mt060200ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <p>Defines the set of parameters that may be used to filter 
     * the query response.</p>
     * 
     * <p>Root class for query definition</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060200CA.ParameterList"})]
    public class ParameterList : MessagePartBean {

        private IVL<TS, Interval<PlatformDate>> administrationEffectivePeriodValue;
        private IVL<TS, Interval<PlatformDate>> amendedInTimeRangeValue;
        private CV issueFilterCodeValue;
        private BL mostRecentByDrugIndicatorValue;
        private TS patientBirthDateValue;
        private CV patientGenderValue;
        private II patientIDValue;
        private PN patientNameValue;

        public ParameterList() {
            this.administrationEffectivePeriodValue = new IVLImpl<TS, Interval<PlatformDate>>();
            this.amendedInTimeRangeValue = new IVLImpl<TS, Interval<PlatformDate>>();
            this.issueFilterCodeValue = new CVImpl();
            this.mostRecentByDrugIndicatorValue = new BLImpl();
            this.patientBirthDateValue = new TSImpl();
            this.patientGenderValue = new CVImpl();
            this.patientIDValue = new IIImpl();
            this.patientNameValue = new PNImpl();
        }
        /**
         * <summary>Business Name: Administration Effective Period</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060200CA.AdministrationEffectivePeriod.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates the 
         * administration period for which the request/query 
         * applies.</p><p>Filter the result set to include only those 
         * medication records (prescription order, prescription 
         * dispense and other active medication) for which the patient 
         * was deemed to be taking the drug within the specified 
         * period.</p> <p>Indicates the administration period for which 
         * the request/query applies.</p><p>Filter the result set to 
         * include only those medication records (prescription order, 
         * prescription dispense and other active medication) for which 
         * the patient was deemed to be taking the drug within the 
         * specified period.</p> <p>Allows the requester to specify the 
         * administration period of interest for the retrieval. Useful 
         * for constraining run-away queries.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"administrationEffectivePeriod/value"})]
        public Interval<PlatformDate> AdministrationEffectivePeriodValue {
            get { return this.administrationEffectivePeriodValue.Value; }
            set { this.administrationEffectivePeriodValue.Value = value; }
        }

        /**
         * <summary>Business Name: Amended in Time Range</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060200CA.AmendedInTimeRange.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates that the 
         * returned records should be filtered to only include those 
         * which have been amended in some way (had status changed, 
         * been annotated, prescription was dispensed, etc.) within the 
         * indicated time-period. This will commonly be used to 
         * &quot;retrieve everything that has been amended since 
         * xxx&quot;.</p> <p>Allows the requester to specify the event 
         * period of interest for the retrieval of medication 
         * records.</p><p>Useful for constraining run-away queries.</p> 
         * <p>Allows the requester to specify the event period of 
         * interest for the retrieval of medication 
         * records.</p><p>Useful for constraining run-away queries.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"amendedInTimeRange/value"})]
        public Interval<PlatformDate> AmendedInTimeRangeValue {
            get { return this.amendedInTimeRangeValue.Value; }
            set { this.amendedInTimeRangeValue.Value = value; }
        }

        /**
         * <summary>Business Name: Issue Filter Code</summary>
         * 
         * <remarks>Relationship: PORX_MT060200CA.IssueFilterCode.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates whether 
         * records to be returned (e.g. prescription order, 
         * prescription dispense and/or other medication) should be 
         * filtered to those with at least one persistent un-managed 
         * issue (against the record), with at least one persistent 
         * issues or should return all records, independent of the 
         * presence of persistent issues.</p> <p>By filtering returned 
         * records to include only those which have unmanaged issues or 
         * any issues at all, allows a provider to focus on those 
         * aspects of care where extra attention is needed. Because the 
         * attribute must be known, it is mandatory.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"issueFilterCode/value"})]
        public IssueFilterCode IssueFilterCodeValue {
            get { return (IssueFilterCode) this.issueFilterCodeValue.Value; }
            set { this.issueFilterCodeValue.Value = value; }
        }

        /**
         * <summary>Business Name: Most Recent By Drug Indicator</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060200CA.MostRecentByDrugIndicator.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates whether 
         * or not the medication records are to be retrieved based on 
         * the most recent by Drug Code. If true, only the most recent 
         * prescription, dispense or other active medication for a 
         * particular drug generic classification will be returned. The 
         * default is 'FALSE' indicating that retrieval of 
         * prescription, dispense and other active medication records 
         * should not be limited to one per drug.</p> <p>Helps decrease 
         * the volume of records returned, while still maintaining 
         * information on all drugs that the patient is 
         * on.</p><p>Because this is a boolean attribute whose value 
         * must be known to evaluate the query, the attribute is 
         * mandatory.</p> <p>Helps decrease the volume of records 
         * returned, while still maintaining information on all drugs 
         * that the patient is on.</p><p>Because this is a boolean 
         * attribute whose value must be known to evaluate the query, 
         * the attribute is mandatory.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"mostRecentByDrugIndicator/value"})]
        public bool? MostRecentByDrugIndicatorValue {
            get { return this.mostRecentByDrugIndicatorValue.Value; }
            set { this.mostRecentByDrugIndicatorValue.Value = value; }
        }

        /**
         * <summary>Business Name: Patient Birth Date</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060200CA.PatientBirthDate.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates the date 
         * on which the patient was born.</p> <p>Used to confirm the 
         * identity of the patient for the query and is therefore 
         * mandatory.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"patientBirthDate/value"})]
        public PlatformDate PatientBirthDateValue {
            get { return this.patientBirthDateValue.Value; }
            set { this.patientBirthDateValue.Value = value; }
        }

        /**
         * <summary>Business Name: Patient Gender</summary>
         * 
         * <remarks>Relationship: PORX_MT060200CA.PatientGender.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates the 
         * gender (sex) of the patient.</p> <p>Used to confirm the 
         * identity of the patient for the query and is therefore 
         * mandatory.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"patientGender/value"})]
        public AdministrativeGender PatientGenderValue {
            get { return (AdministrativeGender) this.patientGenderValue.Value; }
            set { this.patientGenderValue.Value = value; }
        }

        /**
         * <summary>Business Name: B:Patient ID</summary>
         * 
         * <remarks>Relationship: PORX_MT060200CA.PatientID.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Identifier of the 
         * patient who is the subject of the patient medication query. 
         * Filter the result set to include only those records 
         * pertaining to the patient with this Id.</p> <p>Allows 
         * filtering of result set by patient Id. This is a mandatory 
         * field because a patient must be specified for the query to 
         * be valid</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"patientID/value"})]
        public Identifier PatientIDValue {
            get { return this.patientIDValue.Value; }
            set { this.patientIDValue.Value = value; }
        }

        /**
         * <summary>Business Name: C:Patient Name</summary>
         * 
         * <remarks>Relationship: PORX_MT060200CA.PatientName.value 
         * Conformance/Cardinality: MANDATORY (1) <p>The name of the 
         * patient who is the subject of the patient medication 
         * query.</p><p>Filter the result set to include only those 
         * records pertaining to the patient with this name.</p> <p>The 
         * name of the patient who is the subject of the patient 
         * medication query.</p><p>Filter the result set to include 
         * only those records pertaining to the patient with this 
         * name.</p> <p>Allows filtering of result set by patient name. 
         * This is a mandatory field because a patient name must match 
         * the patient Id for the query to be valid.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"patientName/value"})]
        public PersonName PatientNameValue {
            get { return this.patientNameValue.Value; }
            set { this.patientNameValue.Value = value; }
        }

    }

}