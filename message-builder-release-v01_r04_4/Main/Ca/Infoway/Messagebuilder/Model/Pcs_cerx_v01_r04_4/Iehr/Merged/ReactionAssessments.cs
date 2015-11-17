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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Iehr.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>REPC_MT000012CA.CausalityAssessment: Reaction 
     * Assessments</summary>
     * 
     * <p>If code is SNOMED, value is not permitted. Otherise code 
     * must be RXNASSESS and value must be RELATED</p> <p>Indicates 
     * both the product and how related they are determined to be 
     * to the reaction.</p> <p>This is a recording of the exposures 
     * and causality assessment deemed to be related to the 
     * reaction.</p> REPC_MT000006CA.CausalityAssessment: Reaction 
     * Assessments <p>Indicates both the product and how related 
     * they are determined to be to the reaction.</p> <p>This is a 
     * recording of the exposures and causality assessment deemed 
     * to be related to the reaction.</p> 
     * REPC_MT000013CA.CausalityAssessment: Reported Reactions 
     * <p>If code is SNOMED, value is not permitted otherwise code 
     * must be RXNASSESS and value must be RELATED</p> <p>Helps 
     * providers to distinguish between proper allergies and 
     * intolerances. Allows the provider recording the allergy to 
     * assign appropriate severity to the allergy. May give insight 
     * on how to mitigate an intolerance that is likely to be 
     * triggered by administering a substance. (E.g. If a given 
     * drug typically causes nausea in the patient, an additional 
     * medication may be co-prescribed to manage the nausea.)</p> 
     * <p>This is a recording of a patient reaction that is 
     * believed to be associated with the allergy/intolerance.</p> 
     * REPC_MT000002CA.CausalityAssessment: Reaction Assessments 
     * <p>Indicates both the product and how related they are 
     * determined to be to the reaction.</p> <p>This is a recording 
     * of the exposures and causality assessment deemed to be 
     * related to the reaction.</p> 
     * REPC_MT000001CA.CausalityAssessment: Reported Reactions 
     * <p>Helps providers to distinguish between proper allergies 
     * and intolerances. Allows the provider recording the allergy 
     * to assign appropriate severity to the allergy. May give 
     * insight on how to mitigate an intolerance that is likely to 
     * be triggered by administering a substance. (E.g. If a given 
     * drug typically causes nausea in the patient, an additional 
     * medication may be co-prescribed to manage the nausea.)</p> 
     * <p>This is a recording of a patient reaction that is 
     * believed to be associated with the allergy/intolerance.</p> 
     * REPC_MT000009CA.CausalityAssessment: Reported Reactions 
     * <p>Helps providers to distinguish between proper allergies 
     * and intolerances. Allows the provider recording the allergy 
     * to assign appropriate severity to the allergy. May give 
     * insight on how to mitigate an intolerance that is likely to 
     * be triggered by administering a substance. (E.g. If a given 
     * drug typically causes nausea in the patient, an additional 
     * medication may be co-prescribed to manage the nausea.)</p> 
     * <p>This is a recording of a patient reaction that is 
     * believed to be associated with the allergy/intolerance.</p> 
     * REPC_MT000005CA.CausalityAssessment: Reported Reactions 
     * <p>Helps providers to distinguish between proper allergies 
     * and intolerances. Allows the provider recording the allergy 
     * to assign appropriate severity to the allergy. May give 
     * insight on how to mitigate an intolerance that is likely to 
     * be triggered by administering a substance. (E.g. If a given 
     * drug typically causes nausea in the patient, an additional 
     * medication may be co-prescribed to manage the nausea.)</p> 
     * <p>This is a recording of a patient reaction that is 
     * believed to be associated with the allergy/intolerance.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT000001CA.CausalityAssessment","REPC_MT000002CA.CausalityAssessment","REPC_MT000005CA.CausalityAssessment","REPC_MT000006CA.CausalityAssessment","REPC_MT000009CA.CausalityAssessment","REPC_MT000012CA.CausalityAssessment","REPC_MT000013CA.CausalityAssessment"})]
    public class ReactionAssessments : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Iehr.Repc_mt000009ca.IRecords, Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Iehr.Repc_mt000005ca.IRecords, Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Iehr.Merged.IRecords {

        private CD code;
        private CV value;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Iehr.Merged.Exposures startsAfterStartOfExposureEvent;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Iehr.Merged.ObservationEvent subjectObservationEvent;

        public ReactionAssessments() {
            this.code = new CDImpl();
            this.value = new CVImpl();
        }
        /**
         * <summary>Business Name: AssessmentType</summary>
         * 
         * <remarks>Un-merged Business Name: AssessmentType 
         * Relationship: REPC_MT000006CA.CausalityAssessment.code 
         * Conformance/Cardinality: MANDATORY (1) <p>'code' is fixed to 
         * RXNASSESS if not using SNOMED</p> <p>Communicates the 
         * relatedness assessment of the exposure to the reaction and 
         * is therefore mandatory. For SNOMED this will communicate the 
         * full assessment. It is expressed as a CD to allow for SNOMED 
         * post-coordination.</p> <p>For SNOMED this will include the 
         * actual assessment. For non-SNOMED, this should be fixed to 
         * RXNASSESS.</p> <p>Indicates the type of assessment being 
         * made</p> Un-merged Business Name: AssessmentType 
         * Relationship: REPC_MT000012CA.CausalityAssessment.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Communicates the 
         * relatedness assessment of the exposure to the reaction and 
         * is therefore mandatory. For SNOMED this will communicate the 
         * full assessment. It is expressed as a CD to allow for SNOMED 
         * post-coordination.</p> <p>For SNOMED this will include the 
         * actual assessment. For non-SNOMED, this should be fixed to 
         * RXNASSES.</p> <p>Indicates the type of assessment being 
         * made</p> Un-merged Business Name: AssessmentType 
         * Relationship: REPC_MT000013CA.CausalityAssessment.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Communicates the 
         * relatedness assessment of the exposure to the reaction and 
         * is therefore mandatory. For SNOMED this will communicate the 
         * full assessment. It is expressed as a CD to allow for SNOMED 
         * post-coordination.</p> <p>For SNOMED this will include the 
         * actual assessment. For non-SNOMED, this should be fixed to 
         * RXNASSES.</p> <p>Indicates the type of assessment being 
         * made</p> Un-merged Business Name: AssessmentType 
         * Relationship: REPC_MT000002CA.CausalityAssessment.code 
         * Conformance/Cardinality: MANDATORY (1) <p>'code' is fixed to 
         * RXNASSESS if not using SNOMED</p> <p>Communicates the 
         * relatedness assessment of the exposure to the reaction and 
         * is therefore mandatory. For SNOMED this will communicate the 
         * full assessment. It is expressed as a CD to allow for SNOMED 
         * post-coordination.</p> <p>For SNOMED this will include the 
         * actual assessment. For non-SNOMED, this should be fixed to 
         * RXNASSES.</p> <p>Indicates the type of assessment being 
         * made</p> Un-merged Business Name: AssessmentType 
         * Relationship: REPC_MT000001CA.CausalityAssessment.code 
         * Conformance/Cardinality: MANDATORY (1) <p>'code' must be 
         * fixed to RXNASSESS if not using SNOMED</p> <p>Communicates 
         * the relatedness assessment of the exposure to the reaction 
         * and is therefore mandatory. For SNOMED this will communicate 
         * the full assessment. It is expressed as a CD to allow for 
         * SNOMED post-coordination.</p> <p>For SNOMED this will 
         * include the actual assessment. For non-SNOMED, this should 
         * be fixed to RXNASSES.</p> <p>Indicates the type of 
         * assessment being made</p> Un-merged Business Name: 
         * AssessmentType Relationship: 
         * REPC_MT000009CA.CausalityAssessment.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Communicates the 
         * relatedness assessment of the exposure to the reaction and 
         * is therefore mandatory. For SNOMED this will communicate the 
         * full assessment. It is expressed as a CD to allow for SNOMED 
         * post-coordination.</p> <p>For SNOMED this will include the 
         * actual assessment. For non-SNOMED, this should be fixed to 
         * RXNASSESS.</p> <p>Indicates the type of assessment being 
         * made</p> Un-merged Business Name: AssessmentType 
         * Relationship: REPC_MT000005CA.CausalityAssessment.code 
         * Conformance/Cardinality: MANDATORY (1) <p>'code' must be 
         * fixed to RXNASSESS if not using SNOMED</p> <p>Communicates 
         * the relatedness assessment of the exposure to the reaction 
         * and is therefore mandatory. For SNOMED this will communicate 
         * the full assessment. It is expressed as a CD to allow for 
         * SNOMED post-coordination.</p> <p>For SNOMED this will 
         * include the actual assessment. For non-SNOMED, this should 
         * be fixed to RXNASSESS.</p> <p>Indicates the type of 
         * assessment being made</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActCode Code {
            get { return (ActCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: RelatednessAssessment</summary>
         * 
         * <remarks>Un-merged Business Name: RelatednessAssessment 
         * Relationship: REPC_MT000006CA.CausalityAssessment.value 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>'value' is 
         * mandatory if not using SNOMED</p> <p>Creates the link 
         * between the exposure and the reaction. Because the details 
         * of the assessment will be communicated in the 'code' 
         * attribute for SNOMED, this element is optional.</p> <p>This 
         * attribute will not be populated if using SNOMED. Otherwise 
         * it should have a fixed value of &quot;RELATED&quot;.</p> 
         * <p>Indicates whether the reaction is deemed to be related to 
         * the exposure.</p> Un-merged Business Name: 
         * RelatednessAssessment Relationship: 
         * REPC_MT000012CA.CausalityAssessment.value 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Creates the link 
         * between the exposure and the reaction. Because the details 
         * of the assessment will be communicated in the 'code' 
         * attribute for SNOMED, this element is optional.</p> <p>This 
         * attribute will not be populated if using SNOMED. Otherwise 
         * it should have a fixed value of &quot;RELATED&quot;.</p> 
         * <p>Indicates whether the reaction is deemed to be related to 
         * the exposure.</p> Un-merged Business Name: 
         * RelatednessAssessment Relationship: 
         * REPC_MT000013CA.CausalityAssessment.value 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Creates the link 
         * between the exposure and the reaction. Because the details 
         * of the assessment will be communicated in the 'code' 
         * attribute for SNOMED, this element is optional.</p> <p>This 
         * attribute will not be populated if using SNOMED. Otherwise 
         * it should have a fixed value of &quot;RELATED&quot;.</p> 
         * <p>Indicates whether the reaction is deemed to be related to 
         * the exposure.</p> Un-merged Business Name: 
         * RelatednessAssessment Relationship: 
         * REPC_MT000002CA.CausalityAssessment.value 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>'value' is 
         * mandatory if not using SNOMED</p> <p>Creates the link 
         * between the exposure and the reaction. Because the details 
         * of the assessment will be communicated in the 'code' 
         * attribute for SNOMED, this element is optional.</p> <p>This 
         * attribute will not be populated if using SNOMED. Otherwise 
         * it should have a fixed value of &quot;RELATED&quot;.</p> 
         * <p>Indicates whether the reaction is deemed to be related to 
         * the exposure.</p> Un-merged Business Name: 
         * RelatednessAssessment Relationship: 
         * REPC_MT000001CA.CausalityAssessment.value 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>'value' is 
         * required if not using SNOMED</p> <p>Creates the link between 
         * the exposure and the reaction. Because the details of the 
         * assessment will be communicated in the 'code' attribute for 
         * SNOMED, this element is optional.</p> <p>This attribute will 
         * not be populated if using SNOMED. Otherwise it should have a 
         * fixed value of &quot;RELATED&quot;.</p> <p>Indicates whether 
         * the reaction is deemed to be related to the exposure.</p> 
         * Un-merged Business Name: RelatednessAssessment Relationship: 
         * REPC_MT000009CA.CausalityAssessment.value 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>'value' is 
         * required if not using SNOMED</p> <p>Creates the link between 
         * the exposure and the reaction. Because the details of the 
         * assessment will be communicated in the 'code' attribute for 
         * SNOMED, this element is optional.</p> <p>This attribute will 
         * not be populated if using SNOMED. Otherwise it should have a 
         * fixed value of &quot;RELATED&quot;.</p> <p>Indicates whether 
         * the reaction is deemed to be related to the exposure.</p> 
         * Un-merged Business Name: RelatednessAssessment Relationship: 
         * REPC_MT000005CA.CausalityAssessment.value 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>'value' is 
         * mandatory if not using SNOMED</p> <p>Creates the link 
         * between the exposure and the reaction. Because the details 
         * of the assessment will be communicated in the 'code' 
         * attribute for SNOMED, this element is optional.</p> <p>This 
         * attribute will not be populated if using SNOMED. Otherwise 
         * it should have a fixed value of &quot;RELATED&quot;.</p> 
         * <p>Indicates whether the reaction is deemed to be related to 
         * the exposure.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public ObservationValue Value {
            get { return (ObservationValue) this.value.Value; }
            set { this.value.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000006CA.StartsAfterStartOf.exposureEvent 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000012CA.StartsAfterStartOf.exposureEvent 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000013CA.StartsAfterStartOf.exposureEvent 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000002CA.StartsAfterStartOf.exposureEvent 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000001CA.StartsAfterStartOf.exposureEvent 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000009CA.StartsAfterStartOf.exposureEvent 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000005CA.StartsAfterStartOf.exposureEvent 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"startsAfterStartOf/exposureEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Iehr.Merged.Exposures StartsAfterStartOfExposureEvent {
            get { return this.startsAfterStartOfExposureEvent; }
            set { this.startsAfterStartOfExposureEvent = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000013CA.Subject6.observationEvent 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000001CA.Subject6.observationEvent 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000009CA.Subject6.observationEvent 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000005CA.Subject6.observationEvent 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject/observationEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Iehr.Merged.ObservationEvent SubjectObservationEvent {
            get { return this.subjectObservationEvent; }
            set { this.subjectObservationEvent = value; }
        }

    }

}