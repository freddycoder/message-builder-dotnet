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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>POIZ_MT030060CA.IntoleranceCondition: (no business 
     * name)</summary>
     * 
     * <p>Necessary component of a person's overall medication and 
     * clinical profile. Helps with drug contraindication 
     * checking.</p> <p>A record of a patient's allergy or 
     * intolerance.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POIZ_MT030050CA.IntoleranceCondition","POIZ_MT030060CA.IntoleranceCondition","POIZ_MT060150CA.IntoleranceCondition"})]
    public class IntoleranceCondition : MessagePartBean {

        private II id;
        private CD code;
        private BL negationInd;
        private CS statusCode;
        private CV uncertaintyCode;

        public IntoleranceCondition() {
            this.id = new IIImpl();
            this.code = new CDImpl();
            this.negationInd = new BLImpl();
            this.statusCode = new CSImpl();
            this.uncertaintyCode = new CVImpl();
        }
        /**
         * <summary>Business Name: AllergyIntoleranceRecordID</summary>
         * 
         * <remarks>Un-merged Business Name: AllergyIntoleranceRecordID 
         * Relationship: POIZ_MT030060CA.IntoleranceCondition.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Needed to 
         * reference allergy and intolerance records stored in a 
         * patient's logitudinal electronic health record. As a result, 
         * this attribute is mandatory.</p> <p>Unique identifier for 
         * the intolerance condition.</p> Un-merged Business Name: 
         * AllergyIntoleranceRecordID Relationship: 
         * POIZ_MT030050CA.IntoleranceCondition.id 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: AllergyIntoleranceRecordID Relationship: 
         * POIZ_MT060150CA.IntoleranceCondition.id 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: AllergyIntoleranceType</summary>
         * 
         * <remarks>Un-merged Business Name: AllergyIntoleranceType 
         * Relationship: POIZ_MT030060CA.IntoleranceCondition.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for the 
         * separation of allergy and intolerance records. The type of 
         * condition is critical to understanding the record and is 
         * therefore mandatory. It is expressed as a CD to allow for 
         * SNOMED post-coordination.</p> <p>A coded value denoting 
         * whether the record pertains to an intolerance or a true 
         * allergy. (Allergies result from immunologic reactions. 
         * Intolerances do not.)</p> Un-merged Business Name: 
         * AllergyIntoleranceType Relationship: 
         * POIZ_MT030050CA.IntoleranceCondition.code 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: AllergyIntoleranceType Relationship: 
         * POIZ_MT060150CA.IntoleranceCondition.code 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ObservationIntoleranceType Code {
            get { return (ObservationIntoleranceType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: AllergyIntoleranceRefuted</summary>
         * 
         * <remarks>Un-merged Business Name: AllergyIntoleranceRefuted 
         * Relationship: 
         * POIZ_MT030060CA.IntoleranceCondition.negationInd 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows providers 
         * to refute a previously confirmed or suspected allergy. The 
         * attribute is mandatory because it is essential to know 
         * whether a record is refuted or not.</p> <p>An indication 
         * that the allergy/intolerance has been refuted. I.e. A 
         * clinician has positively determined that the patient does 
         * not suffer from a particular allergy or intolerance.</p> 
         * Un-merged Business Name: AllergyIntoleranceRefuted 
         * Relationship: 
         * POIZ_MT030050CA.IntoleranceCondition.negationInd 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: AllergyIntoleranceRefuted Relationship: 
         * POIZ_MT060150CA.IntoleranceCondition.negationInd 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"negationInd"})]
        public bool? NegationInd {
            get { return this.negationInd.Value; }
            set { this.negationInd.Value = value; }
        }

        /**
         * <summary>Business Name: AllergyIntoleranceStatus</summary>
         * 
         * <remarks>Un-merged Business Name: AllergyIntoleranceStatus 
         * Relationship: 
         * POIZ_MT030060CA.IntoleranceCondition.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows providers 
         * to evaluate the relevance of a recorded allergy/intolerance. 
         * The status has a default value of 'ACTIVE' and is therefore 
         * mandatory.</p> <p>A coded value that indicates whether an 
         * allergy/intolerance is 'ACTIVE' or 'COMPLETE' (indicating no 
         * longer active).</p> Un-merged Business Name: 
         * AllergyIntoleranceStatus Relationship: 
         * POIZ_MT030050CA.IntoleranceCondition.statusCode 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: AllergyIntoleranceStatus Relationship: 
         * POIZ_MT060150CA.IntoleranceCondition.statusCode 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: ConfirmedIndicator</summary>
         * 
         * <remarks>Un-merged Business Name: ConfirmedIndicator 
         * Relationship: 
         * POIZ_MT030060CA.IntoleranceCondition.uncertaintyCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Helps other 
         * providers to make appropriate decisions in their management 
         * of allergy or intolerance contraindications. Attribute is 
         * mandatory because an allergy or intolerance record must be 
         * tagged as either 'confirmed' or 'suspected'.</p> <p>An 
         * indication of the level of confidence/surety placed in the 
         * recorded information. The two valid confirmation statuses 
         * are&quot; 'CONFIRMED' and 'SUSPECTED'. An allergy or 
         * intolerance record is always used in drug contraindication 
         * checking whether the record is tagged as 'confirmed' or 
         * 'suspected'.</p> Un-merged Business Name: ConfirmedIndicator 
         * Relationship: 
         * POIZ_MT030050CA.IntoleranceCondition.uncertaintyCode 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: ConfirmedIndicator Relationship: 
         * POIZ_MT060150CA.IntoleranceCondition.uncertaintyCode 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"uncertaintyCode"})]
        public ActUncertainty UncertaintyCode {
            get { return (ActUncertainty) this.uncertaintyCode.Value; }
            set { this.uncertaintyCode.Value = value; }
        }

    }

}