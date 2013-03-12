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
 * Last modified: $LastChangedDate: 2013-03-08 11:06:36 -0500 (Fri, 08 Mar 2013) $
 * Revision:      $LastChangedRevision: 6699 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Immunization.Poiz_mt061140ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Immunization Candidate Query 
     * Parameters</summary>
     * 
     * <p>Root class for the query.</p> <p>Defines the set of 
     * parameters that may be used to filter the query 
     * response.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POIZ_MT061140CA.ParameterList"})]
    public class ImmunizationCandidateQueryParameters : MessagePartBean {

        private IVL<TS, Interval<PlatformDate>> immunizationPeriodValue;
        private IVL<TS, Interval<PlatformDate>> patientBirthDateValue;
        private CV patientGenderValue;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Immunization.Poiz_mt061140ca.PatientID> patientID;
        private PN patientNameValue;
        private ST postalCodeValue;
        private IList<II> serviceDeliveryLocationValue;
        private CV vaccineCodeValue;

        public ImmunizationCandidateQueryParameters() {
            this.immunizationPeriodValue = new IVLImpl<TS, Interval<PlatformDate>>();
            this.patientBirthDateValue = new IVLImpl<TS, Interval<PlatformDate>>();
            this.patientGenderValue = new CVImpl();
            this.patientID = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Immunization.Poiz_mt061140ca.PatientID>();
            this.patientNameValue = new PNImpl();
            this.postalCodeValue = new STImpl();
            this.serviceDeliveryLocationValue = new List<II>();
            this.vaccineCodeValue = new CVImpl();
        }
        /**
         * <summary>Business Name: G:Immunization Period</summary>
         * 
         * <remarks>Relationship: 
         * POIZ_MT061140CA.ImmunizationPeriod.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows the 
         * requester to specify the period of interest for the 
         * retrieval of immunization records.</p><p>Useful for 
         * constraining run-away queries. As a result, this parameter 
         * is required.</p> <p>Indicates that the returned records 
         * should be filtered to only include those immunizations that 
         * occurred within the indicated time-period. This will 
         * commonly be used to retrieve 'all immunizations since 
         * xxx'.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"immunizationPeriod/value"})]
        public Interval<PlatformDate> ImmunizationPeriodValue {
            get { return this.immunizationPeriodValue.Value; }
            set { this.immunizationPeriodValue.Value = value; }
        }

        /**
         * <summary>Business Name: D:Patient Birth Date Range</summary>
         * 
         * <remarks>Relationship: 
         * POIZ_MT061140CA.PatientBirthDate.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Use to confirm 
         * identity of the patient for the query. As a result, this 
         * parameter is required.</p> <p>Indicates the range of on 
         * which the patient was born.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"patientBirthDate/value"})]
        public Interval<PlatformDate> PatientBirthDateValue {
            get { return this.patientBirthDateValue.Value; }
            set { this.patientBirthDateValue.Value = value; }
        }

        /**
         * <summary>Business Name: C:Patient Gender</summary>
         * 
         * <remarks>Relationship: POIZ_MT061140CA.PatientGender.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Used to confirm 
         * the identity of the patient for the query. As a result, this 
         * parameter is required.</p> <p>Indicates the gender (sex) of 
         * the patient.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"patientGender/value"})]
        public AdministrativeGender PatientGenderValue {
            get { return (AdministrativeGender) this.patientGenderValue.Value; }
            set { this.patientGenderValue.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * POIZ_MT061140CA.ParameterList.patientID</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-10000)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"patientID"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Immunization.Poiz_mt061140ca.PatientID> PatientID {
            get { return this.patientID; }
        }

        /**
         * <summary>Business Name: B:Patient Name</summary>
         * 
         * <remarks>Relationship: POIZ_MT061140CA.PatientName.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows filtering 
         * of result set by patient name. As a result, this parameter 
         * is required.</p> <p>names are messaged as iterations of the 
         * PN datatype, with specific name parts identified as a type 
         * declaration in addition to the text string.</p> <p>The name 
         * of the patient who is the subject of the immunization 
         * candidate query.</p><p>Filter the result set to include only 
         * those records pertaining to the patient with this name.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"patientName/value"})]
        public PersonName PatientNameValue {
            get { return this.patientNameValue.Value; }
            set { this.patientNameValue.Value = value; }
        }

        /**
         * <summary>Business Name: I:Postal Code</summary>
         * 
         * <remarks>Relationship: POIZ_MT061140CA.PostalCode.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows the 
         * requester to specify the postal code area of interest for 
         * the retrieval of immunization records.</p><p>Useful for 
         * constraining run-away queries. As a result, this parameter 
         * is required.</p> <p>Indicates that the returned records 
         * should be filtered to only include those immunizations that 
         * occurred within a specified postal code area</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"postalCode/value"})]
        public String PostalCodeValue {
            get { return this.postalCodeValue.Value; }
            set { this.postalCodeValue.Value = value; }
        }

        /**
         * <summary>Business Name: H:Service Delivery Locations</summary>
         * 
         * <remarks>Relationship: 
         * POIZ_MT061140CA.ServiceDeliveryLocation.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows the 
         * requester to specify the service delivery location of 
         * interest for the retrieval of immunization 
         * records.</p><p>Useful for constraining run-away queries. As 
         * a result, this parameter is required.</p> <p>Indicates that 
         * the returned records should be filtered to only include 
         * those immunizations that occurred at an identified service 
         * delivery location</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"serviceDeliveryLocation/value"})]
        public IList<Identifier> ServiceDeliveryLocationValue {
            get { return new RawListWrapper<II, Identifier>(serviceDeliveryLocationValue, typeof(IIImpl)); }
        }

        /**
         * <summary>Business Name: E:Vaccine Code</summary>
         * 
         * <remarks>Relationship: POIZ_MT061140CA.VaccineCode.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for finer 
         * sub-set of immunization records to be retrieved based on the 
         * vaccine code used in the immunization. As a result, this 
         * parameter is required.</p> <p>A coded value indicating a 
         * specific vaccine to be used in searching for patient 
         * immunization record.</p><p>The result set will be filtered 
         * to only include immunization records involving the specific 
         * vaccine code</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"vaccineCode/value"})]
        public ClinicalDrug VaccineCodeValue {
            get { return (ClinicalDrug) this.vaccineCodeValue.Value; }
            set { this.vaccineCodeValue.Value = value; }
        }

    }

}