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
namespace Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Iehr.Repc_mt000008ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: Condition History Query Parameters</summary>
     * 
     * <p>Defines the set of parameters that may be used to filter 
     * the query response</p> <p>Root class for query 
     * definition</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT000008CA.ParameterList"})]
    public class ConditionHistoryQueryParameters : MessagePartBean {

        private II conditionIDValue;
        private TS patientBirthDateValue;
        private CV patientGenderValue;
        private II patientIDValue;
        private PN patientNameValue;

        public ConditionHistoryQueryParameters() {
            this.conditionIDValue = new IIImpl();
            this.patientBirthDateValue = new TSImpl();
            this.patientGenderValue = new CVImpl();
            this.patientIDValue = new IIImpl();
            this.patientNameValue = new PNImpl();
        }
        /**
         * <summary>Business Name: F:Condition Identifier</summary>
         * 
         * <remarks>Relationship: REPC_MT000008CA.ConditionID.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Identifier of the 
         * Condition record to be retrieved. This can pertain to an 
         * allergy/intolerance or medical condition record.</p> 
         * <p>Identifies the specific condition record to retrieve and 
         * is therefore mandatory.</p> <p><strong>A KEY204 error issue 
         * will be returned if this ID does exist in PIN.</strong></p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"conditionID/value"})]
        public Identifier ConditionIDValue {
            get { return this.conditionIDValue.Value; }
            set { this.conditionIDValue.Value = value; }
        }

        /**
         * <summary>Business Name: E:Patient Birth Date</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000008CA.PatientBirthDate.value 
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
         * <summary>Business Name: D:Patient Gender</summary>
         * 
         * <remarks>Relationship: REPC_MT000008CA.PatientGender.value 
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
         * <remarks>Relationship: REPC_MT000008CA.PatientID.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Identifier of the 
         * patient who is the subject of the condition history query. 
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
         * <remarks>Relationship: REPC_MT000008CA.PatientName.value 
         * Conformance/Cardinality: MANDATORY (1) <p>The name of the 
         * patient who is the subject of the condition history 
         * query.</p><p>Filter the result set to include only those 
         * records pertaining to the patient with this name.</p> <p>The 
         * name of the patient who is the subject of the condition 
         * history query.</p><p>Filter the result set to include only 
         * those records pertaining to the patient with this name.</p> 
         * <p>Allows filtering of result set by patient name. This is a 
         * mandatory field because a patient name must match the 
         * patient Id for the query to be valid.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"patientName/value"})]
        public PersonName PatientNameValue {
            get { return this.patientNameValue.Value; }
            set { this.patientNameValue.Value = value; }
        }

    }

}