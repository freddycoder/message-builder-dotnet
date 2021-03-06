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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Porx_mt060270ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <p>Root class for query definition</p>
     * 
     * <p>Defines the set of parameters that may be used to filter 
     * the query response.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060270CA.ParameterList"})]
    public class ParameterList : MessagePartBean {

        private IVL<TS, Interval<PlatformDate>> administrationEffectivePeriodValue;
        private TS patientBirthDateValue;
        private CV patientGenderValue;
        private II patientIDValue;
        private PN patientNameValue;
        private II prescriberProviderIDValue;

        public ParameterList() {
            this.administrationEffectivePeriodValue = new IVLImpl<TS, Interval<PlatformDate>>();
            this.patientBirthDateValue = new TSImpl();
            this.patientGenderValue = new CVImpl();
            this.patientIDValue = new IIImpl();
            this.patientNameValue = new PNImpl();
            this.prescriberProviderIDValue = new IIImpl();
        }
        /**
         * <summary>Business Name: E:Administration Effective Period</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060270CA.AdministrationEffectivePeriod.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows the 
         * requester to specify the administration period of interest 
         * for the retrieval. Useful for constraining run-away 
         * queries.</p> <p>Indicates the administration period for 
         * which the request/query applies.</p><p>Filter the result set 
         * to include only those medication records (prescription 
         * order, prescription dispense and other active medication) 
         * for which the patient was deemed to be taking the drug 
         * within the specified period.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"administrationEffectivePeriod/value"})]
        public Interval<PlatformDate> AdministrationEffectivePeriodValue {
            get { return this.administrationEffectivePeriodValue.Value; }
            set { this.administrationEffectivePeriodValue.Value = value; }
        }

        /**
         * <summary>Business Name: Patient Birth Date</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060270CA.PatientBirthDate.value 
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
         * <remarks>Relationship: PORX_MT060270CA.PatientGender.value 
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
         * <remarks>Relationship: PORX_MT060270CA.PatientID.value 
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
         * <remarks>Relationship: PORX_MT060270CA.PatientName.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows filtering 
         * of result set by patient name. This is a mandatory field 
         * because a patient name must match the patient Id for the 
         * query to be valid.</p> <p>The name of the patient who is the 
         * subject of the patient medication query.</p><p>Filter the 
         * result set to include only those records pertaining to the 
         * patient with this name.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"patientName/value"})]
        public PersonName PatientNameValue {
            get { return this.patientNameValue.Value; }
            set { this.patientNameValue.Value = value; }
        }

        /**
         * <summary>Business Name: D:Prescriber Provider ID</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060270CA.PrescriberProviderID.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for the 
         * retrieval of prescriptions based on a specific 
         * prescriber.</p> <p>Identifier of the prescriber who created 
         * and/or supervised the prescriptions being 
         * retrieved.</p><p>The result set will be filtered to only 
         * include records which were either directly created by this 
         * provider, or were created 'under the supervision' of this 
         * provider.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"prescriberProviderID/value"})]
        public Identifier PrescriberProviderIDValue {
            get { return this.prescriberProviderIDValue.Value; }
            set { this.prescriberProviderIDValue.Value = value; }
        }

    }

}