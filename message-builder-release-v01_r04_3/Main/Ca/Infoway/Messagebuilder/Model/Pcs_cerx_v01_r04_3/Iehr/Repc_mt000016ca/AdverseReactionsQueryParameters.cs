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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Iehr.Repc_mt000016ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: Adverse Reactions Query Parameters</summary>
     * 
     * <p>Root class for query definition</p> <p>Defines the set of 
     * parameters that may be used to filter the query 
     * response.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT000016CA.ParameterList"})]
    public class AdverseReactionsQueryParameters : MessagePartBean {

        private BL includeNotesIndicatorValue;
        private TS patientBirthDateValue;
        private CV patientGenderValue;
        private II patientIDValue;
        private PN patientNameValue;
        private IVL<TS, Interval<PlatformDate>> reactionPeriodValue;
        private CV reactionTypeValue;

        public AdverseReactionsQueryParameters() {
            this.includeNotesIndicatorValue = new BLImpl();
            this.patientBirthDateValue = new TSImpl();
            this.patientGenderValue = new CVImpl();
            this.patientIDValue = new IIImpl();
            this.patientNameValue = new PNImpl();
            this.reactionPeriodValue = new IVLImpl<TS, Interval<PlatformDate>>();
            this.reactionTypeValue = new CVImpl();
        }
        /**
         * <summary>Business Name: Include Notes Indicator</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000016CA.IncludeNotesIndicator.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for the 
         * flexibility of omitting/including notes in the retrieval of 
         * information for adverse reactions data.</p><p>Because the 
         * attribute is boolean, it must explicitly indicate a 'TRUE' 
         * or 'FALSE', and thus it is mandatory.</p> <p>Indicates 
         * whether or not notes attached to the adverse reactions 
         * records are to be returned along with the detailed 
         * information.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"includeNotesIndicator/value"})]
        public bool? IncludeNotesIndicatorValue {
            get { return this.includeNotesIndicatorValue.Value; }
            set { this.includeNotesIndicatorValue.Value = value; }
        }

        /**
         * <summary>Business Name: E:Patient Birth Date</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000016CA.PatientBirthDate.value 
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
         * <summary>Business Name: D:Patient Gender</summary>
         * 
         * <remarks>Relationship: REPC_MT000016CA.PatientGender.value 
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
         * <remarks>Relationship: REPC_MT000016CA.PatientID.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows filtering 
         * of result set by patient Id. This is a mandatory field 
         * because a patient must be specified for the query to be 
         * valid</p> <p>Identifier of the patient who is the subject of 
         * the adverse reaction query. Filter the result set to include 
         * only those records pertaining to the patient with this 
         * Id.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"patientID/value"})]
        public Identifier PatientIDValue {
            get { return this.patientIDValue.Value; }
            set { this.patientIDValue.Value = value; }
        }

        /**
         * <summary>Business Name: C:Patient Name</summary>
         * 
         * <remarks>Relationship: REPC_MT000016CA.PatientName.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows filtering 
         * of result set by patient name. This is a mandatory field 
         * because a patient name must match the patient Id for the 
         * query to be valid.</p> <p>The name of the patient who is the 
         * subject of the adverse reaction query.</p><p>Filter the 
         * result set to include only those records pertaining to the 
         * patient with this name.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"patientName/value"})]
        public PersonName PatientNameValue {
            get { return this.patientNameValue.Value; }
            set { this.patientNameValue.Value = value; }
        }

        /**
         * <summary>Business Name: F:Reaction Period</summary>
         * 
         * <remarks>Relationship: REPC_MT000016CA.ReactionPeriod.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows the 
         * requester to specify the adverse reaction period of interest 
         * for retrieval of adverse reaction records. Useful to avoid 
         * run-away queries.</p> <p>The period in which the recorded 
         * adverse reaction occurred or was updated. I.e. Filters the 
         * result-set to those reactions whose onset occurred within 
         * the time-range specified by this parameter.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reactionPeriod/value"})]
        public Interval<PlatformDate> ReactionPeriodValue {
            get { return this.reactionPeriodValue.Value; }
            set { this.reactionPeriodValue.Value = value; }
        }

        /**
         * <summary>Business Name: G:Reaction Type</summary>
         * 
         * <remarks>Relationship: REPC_MT000016CA.ReactionType.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows the 
         * requester to retrieve only those allergy/intolerance records 
         * for which there was a specific type of reaction.</p> 
         * <p>Indicates that the result set be filtered to include only 
         * those allergy/intolerance records for which specific type of 
         * reaction was recorded.</p><p>Reaction types include: STEVEN 
         * JOHNSON, ANAPHYLAXIS, NAUSEA, etc</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reactionType/value"})]
        public SubjectReaction ReactionTypeValue {
            get { return (SubjectReaction) this.reactionTypeValue.Value; }
            set { this.reactionTypeValue.Value = value; }
        }

    }

}