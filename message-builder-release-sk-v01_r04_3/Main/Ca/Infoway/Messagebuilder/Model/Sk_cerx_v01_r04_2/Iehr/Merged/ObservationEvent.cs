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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Iehr.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Merged;
    using System;


    /**
     * <summary>Business Name: ReportedReactions</summary>
     * 
     * <remarks>REPC_MT000005CA.ObservationEvent: Reported 
     * Reactions <p>Value must be mandatory if not using 
     * SNOMED</p><p>Code must be fixed to DX if not using 
     * SNOMED</p> <p>Value must be mandatory if not using 
     * SNOMED</p><p>Code must be fixed to DX if not using 
     * SNOMED</p> <p>This is a recording of a patient reaction that 
     * is believed to be associated with the 
     * allergy/intolerance.</p> <p>Helps providers to distinguish 
     * between proper allergies and intolerances. Allows the 
     * provider recording the allergy to assign appropriate 
     * severity to the allergy. May give insight on how to mitigate 
     * an intolerance that is likely to be triggered by 
     * administering a substance. (E.g. If a given drug typically 
     * causes nausea in the patient, an additional medication may 
     * be co-prescribed to manage the nausea.)</p> 
     * REPC_MT000001CA.ObservationEvent: (no business name) 
     * <p>Value is required if not using SNOMED</p><p>Reaction Code 
     * must be fixed to DX if not using SNOMED</p><p>At least one 
     * of Id or Value must be specified.</p> <p>Value is required 
     * if not using SNOMED</p><p>Reaction Code must be fixed to DX 
     * if not using SNOMED</p><p>At least one of Id or Value must 
     * be specified.</p> <p>Value is required if not using 
     * SNOMED</p><p>Reaction Code must be fixed to DX if not using 
     * SNOMED</p><p>At least one of Id or Value must be 
     * specified.</p> REPC_MT000009CA.ObservationEvent: (no 
     * business name) <p>Value must not be present when using 
     * SNOMED, mandatory otherwise</p> 
     * REPC_MT000013CA.ObservationEvent: (no business name) <p>If 
     * code is SNOMED, value is not permitted, otherwise it is 
     * mandatory and code must be DX</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT000001CA.ObservationEvent","REPC_MT000005CA.ObservationEvent","REPC_MT000009CA.ObservationEvent","REPC_MT000013CA.ObservationEvent"})]
    public class ObservationEvent : MessagePartBean {

        private II id;
        private CD code;
        private BL negationInd;
        private ST text;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private CV value;
        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Merged.AllergyIntoleranceSeverityLevel subjectOfSeverityObservation;

        public ObservationEvent() {
            this.id = new IIImpl();
            this.code = new CDImpl();
            this.negationInd = new BLImpl();
            this.text = new STImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.value = new CVImpl();
        }
        /**
         * <summary>Business Name: ReactionRecordId</summary>
         * 
         * <remarks>Un-merged Business Name: ReactionRecordId 
         * Relationship: REPC_MT000005CA.ObservationEvent.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>An identifier 
         * assigned to the record of the adverse reaction.</p> 
         * <p>Allows for direct referencing of an adverse reaction 
         * record which was previously recorded.</p> Un-merged Business 
         * Name: ReactionRecordId Relationship: 
         * REPC_MT000009CA.ObservationEvent.id Conformance/Cardinality: 
         * REQUIRED (0-1) <p>An identifier assigned to the record of 
         * the adverse reaction.</p> <p>Allows for direct referencing 
         * of an adverse reaction record which was previously 
         * recorded.</p> Un-merged Business Name: ReactionRecordId 
         * Relationship: REPC_MT000013CA.ObservationEvent.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>An identifier 
         * assigned to the record of the adverse reaction.</p> 
         * <p>Allows for direct referencing of an adverse reaction 
         * record which was previously recorded.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: DiagnosisType</summary>
         * 
         * <remarks>Un-merged Business Name: DiagnosisType 
         * Relationship: REPC_MT000005CA.ObservationEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates the type 
         * of diagnosis being captured.</p> <p>Indicates that the 
         * observation is actually a diagnosis and is therefore 
         * mandatory. The datatype is CD to support SNOMED 
         * post-coordination.</p> <p>If using SNOMED, this will contain 
         * the diagnosis. Otherwise it will be a fixed value of 
         * 'DX'.</p> Un-merged Business Name: DiagnosisType 
         * Relationship: REPC_MT000009CA.ObservationEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates the type 
         * of diagnosis being captured.</p> <p>Indicates that the 
         * observation is actually a diagnosis and is therefore 
         * mandatory. The datatype is CD to support SNOMED 
         * post-coordination.</p> <p>If using SNOMED, this will contain 
         * the diagnosis. Otherwise it will be a fixed value of 
         * 'DX'.</p> Un-merged Business Name: DiagnosisType 
         * Relationship: REPC_MT000013CA.ObservationEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates the type 
         * of diagnosis being captured.</p> <p>Indicates that the 
         * observation is actually a diagnosis and is therefore 
         * mandatory. The datatype is CD to support SNOMED 
         * post-coordination.</p> <p>If using SNOMED, this will contain 
         * the diagnosis. Otherwise it will be a fixed value of 
         * 'DX'.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActCode Code {
            get { return (ActCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: NoReactionOccurred</summary>
         * 
         * <remarks>Un-merged Business Name: NoReactionOccurred 
         * Relationship: REPC_MT000005CA.ObservationEvent.negationInd 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates if there 
         * there was an adverse reaction when the patient was exposed 
         * to the agent to which an allergy/intolerance has been 
         * recorded.</p> <p>Allows providers to confirm or eliminate 
         * specific agents as being the cause for the 
         * allergy/intolerance. E.g. If a reaction is recorded for 
         * Tylenol 3, but no reaction is recorded for regular Tylenol 
         * or for coffee, this suggests that the likely cause of the 
         * allergy is Codeine.</p><p>The attribute is mandatory because 
         * it is essential to know whether the reaction occurred or 
         * not.</p> <p>Allows providers to confirm or eliminate 
         * specific agents as being the cause for the 
         * allergy/intolerance. E.g. If a reaction is recorded for 
         * Tylenol 3, but no reaction is recorded for regular Tylenol 
         * or for coffee, this suggests that the likely cause of the 
         * allergy is Codeine.</p><p>The attribute is mandatory because 
         * it is essential to know whether the reaction occurred or 
         * not.</p> Un-merged Business Name: NoReactionOccurred 
         * Relationship: REPC_MT000001CA.ObservationEvent.negationInd 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates if there 
         * was an there was no adverse reaction when the patient was 
         * exposed to the agent .</p> <p>Allows providers to confirm or 
         * eliminate specific agents as being the cause for the 
         * allergy/intolerance. E.g. If a reaction is recorded for 
         * Tylenol 3, but no reaction is recorded for regular Tylenol 
         * or for coffee, this suggests that the likely cause of the 
         * allergy is Codeine.</p><p>The element is mandatory because 
         * it is essential to know for a given record whether the 
         * reaction occurred or not.</p> <p>Allows providers to confirm 
         * or eliminate specific agents as being the cause for the 
         * allergy/intolerance. E.g. If a reaction is recorded for 
         * Tylenol 3, but no reaction is recorded for regular Tylenol 
         * or for coffee, this suggests that the likely cause of the 
         * allergy is Codeine.</p><p>The element is mandatory because 
         * it is essential to know for a given record whether the 
         * reaction occurred or not.</p> Un-merged Business Name: 
         * NoReactionOccurred Relationship: 
         * REPC_MT000009CA.ObservationEvent.negationInd 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates that 
         * there was no adverse reaction when the patient was exposed 
         * to the agent to which an allergy/intolerance has been 
         * recorded.</p> <p>Allows providers to confirm or eliminate 
         * specific agents as being the cause for the 
         * allergy/intolerance. E.g. If a reaction is recorded for 
         * Tylenol 3, but no reaction is recorded for regular Tylenol 
         * or for coffee, this suggests that the likely cause of the 
         * allergy is Codeine.</p><p>Because it is essential to know 
         * whether the record reflects a reaction that did or did not 
         * occur, this attribute is mandatory.</p> <p>Allows providers 
         * to confirm or eliminate specific agents as being the cause 
         * for the allergy/intolerance. E.g. If a reaction is recorded 
         * for Tylenol 3, but no reaction is recorded for regular 
         * Tylenol or for coffee, this suggests that the likely cause 
         * of the allergy is Codeine.</p><p>Because it is essential to 
         * know whether the record reflects a reaction that did or did 
         * not occur, this attribute is mandatory.</p> Un-merged 
         * Business Name: NoReactionOccurred Relationship: 
         * REPC_MT000013CA.ObservationEvent.negationInd 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates that 
         * there was no adverse reaction when the patient was exposed 
         * to the agent to which an allergy/intolerance has been 
         * recorded.</p> <p>Allows providers to confirm or eliminate 
         * specific agents as being the cause for the 
         * allergy/intolerance. E.g. If a reaction is recorded for 
         * Tylenol 3, but no reaction is recorded for regular Tylenol 
         * or for coffee, this suggests that the likely cause of the 
         * allergy is Codeine.</p><p>Because it is essential to know 
         * whether the reaction occurred or not, this attribute is 
         * mandatory.</p> <p>Allows providers to confirm or eliminate 
         * specific agents as being the cause for the 
         * allergy/intolerance. E.g. If a reaction is recorded for 
         * Tylenol 3, but no reaction is recorded for regular Tylenol 
         * or for coffee, this suggests that the likely cause of the 
         * allergy is Codeine.</p><p>Because it is essential to know 
         * whether the reaction occurred or not, this attribute is 
         * mandatory.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"negationInd"})]
        public bool? NegationInd {
            get { return this.negationInd.Value; }
            set { this.negationInd.Value = value; }
        }

        /**
         * <summary>Business Name: Description</summary>
         * 
         * <remarks>Un-merged Business Name: Description Relationship: 
         * REPC_MT000005CA.ObservationEvent.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>A free form 
         * description of the reaction.</p> <p>B.4</p> <p>Allows for 
         * flexibility in the recording and reporting of the 
         * reaction.</p> Un-merged Business Name: Description 
         * Relationship: REPC_MT000001CA.ObservationEvent.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>A free form 
         * description of the reaction.</p> <p>B.4</p> <p>Allows for 
         * flexibility in the recording and reporting of the 
         * reaction.</p> Un-merged Business Name: Description 
         * Relationship: REPC_MT000009CA.ObservationEvent.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>A free form 
         * description of the reaction.</p> <p>B.4</p> <p>Allows for 
         * flexibility in the recording and reporting of the 
         * reaction.</p> Un-merged Business Name: Description 
         * Relationship: REPC_MT000013CA.ObservationEvent.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>A free form 
         * description of the reaction.</p> <p>B.4</p> <p>Allows for 
         * flexibility in the recording and reporting of the 
         * reaction.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public String Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Business Name: ReactionOnsetDate</summary>
         * 
         * <remarks>Un-merged Business Name: ReactionOnsetDate 
         * Relationship: REPC_MT000005CA.ObservationEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The date on which 
         * the reaction occurrence began.</p> <p>Indicates when 
         * evidence of the condition first appeared. May also provide 
         * information on the duration of the reaction.</p> Un-merged 
         * Business Name: ReactionOnsetDate Relationship: 
         * REPC_MT000001CA.ObservationEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The date on which 
         * the reaction occurrence began.</p> <p>Indicates when 
         * evidence of the condition first appeared. May also provide 
         * information on the duration of the reaction.</p> Un-merged 
         * Business Name: ReactionOnsetDate Relationship: 
         * REPC_MT000009CA.ObservationEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The date on which 
         * the reaction occurrence began.</p> <p>Indicates when 
         * evidence of the condition first appeared. May also provide 
         * information on the duration of the reaction.</p> Un-merged 
         * Business Name: ReactionOnsetDate Relationship: 
         * REPC_MT000013CA.ObservationEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The date on which 
         * the reaction occurrence began.</p> <p>Indicates when 
         * evidence of the condition first appeared. May also provide 
         * information on the duration of the reaction.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: Reaction</summary>
         * 
         * <remarks>Un-merged Business Name: Reaction Relationship: 
         * REPC_MT000005CA.ObservationEvent.value 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Specifies the 
         * kind of reaction, as experienced by the patient.</p> 
         * <p>B.1</p> <p>Ensures consistency in tracking and 
         * categorizing the reaction type. Helps ensure that only 
         * proper allergies are categorized as allergy. The attribute 
         * is optional because it will not be used for SNOMED. The 
         * attribute is CWE because not all possible types of reactions 
         * are expressible by coded values.</p> Un-merged Business 
         * Name: Reaction Relationship: 
         * REPC_MT000001CA.ObservationEvent.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Specifies the kind 
         * of reaction, as experienced by the patient.</p> <p>B.1</p> 
         * <p>Ensures consistency in tracking and categorizing the 
         * reaction type. Helps ensure that only proper allergies are 
         * categorized as allergy. The attribute is optional because it 
         * will not be used for SNOMED. The attribute is CWE because 
         * not all possible types of reactions are expressible by coded 
         * values.</p> <p><strong>Specifies the kind of reaction, as 
         * experienced by the patient. Because PIN does not support 
         * ADRs, this field is now mandatory.</strong></p> Un-merged 
         * Business Name: Reaction Relationship: 
         * REPC_MT000009CA.ObservationEvent.value 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Specifies the 
         * kind of reaction, as experienced by the patient.</p> 
         * <p>B.1</p> <p>Ensures consistency in tracking and 
         * categorizing the reaction type. Helps ensure that only 
         * proper allergies are categorized as allergy. The attribute 
         * is optional because it will not be used for SNOMED. The 
         * attribute is CWE because not all possible types of reactions 
         * are expressible by coded values.</p> Un-merged Business 
         * Name: Reaction Relationship: 
         * REPC_MT000013CA.ObservationEvent.value 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Specifies the 
         * kind of reaction, as experienced by the patient.</p> 
         * <p>B.1</p> <p>Ensures consistency in tracking and 
         * categorizing the reaction type. Helps ensure that only 
         * proper allergies are categorized as allergy. The attribute 
         * is optional because it will not be used for SNOMED. The 
         * attribute is CWE because not all possible types of reactions 
         * are expressible by coded values.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public SubjectReaction Value {
            get { return (SubjectReaction) this.value.Value; }
            set { this.value.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000005CA.Subject.severityObservation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000001CA.Subject.severityObservation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000009CA.Subject.severityObservation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000013CA.Subject.severityObservation 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf/severityObservation"})]
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Merged.AllergyIntoleranceSeverityLevel SubjectOfSeverityObservation {
            get { return this.subjectOfSeverityObservation; }
            set { this.subjectOfSeverityObservation = value; }
        }

    }

}