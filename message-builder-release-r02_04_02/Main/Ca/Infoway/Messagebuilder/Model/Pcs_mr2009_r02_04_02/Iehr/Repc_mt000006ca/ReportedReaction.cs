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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Repc_mt000006ca {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Reported Reaction</summary>
     * 
     * <p>Useful in tracking reactions when it is not known 
     * precisely what product they are associated with and whether 
     * the reaction is due to an allergy or intolerance, a drug 
     * interaction or some other cause. Effectively gives a 'heads 
     * up' to clinicians using the drug or combination of 
     * drugs.</p> <p>This is a record of an adverse reaction 
     * considered relevant to the patient's clinical record.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT000006CA.ReactionObservationEvent"})]
    public class ReportedReaction : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Comt_mt111111ca.ISHR {

        private II id;
        private CD code;
        private ST text;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private SET<CV, Code> confidentialityCode;
        private CV value;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.HealthcareWorker responsiblePartyAssignedEntity;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.RefusedBy author;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.ReportedBy informant;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.OccurredAt location;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.Includes> subjectOf1;
        private BL subjectOf2AnnotationIndicator;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.ReportedReactions> subjectOf3CausalityAssessment;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.AllergyIntoleranceSeverityLevel subjectOf4SeverityObservation;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.CareCompositions> componentOfPatientCareProvisionEvent;

        public ReportedReaction() {
            this.id = new IIImpl();
            this.code = new CDImpl();
            this.text = new STImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.value = new CVImpl();
            this.subjectOf1 = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.Includes>();
            this.subjectOf2AnnotationIndicator = new BLImpl(false);
            this.subjectOf3CausalityAssessment = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.ReportedReactions>();
            this.componentOfPatientCareProvisionEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.CareCompositions>();
        }
        /**
         * <summary>Business Name: C:Reaction Record Id</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000006CA.ReactionObservationEvent.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Uniquely 
         * identifies the specific reaction record and is therefore 
         * mandatory.</p> <p>An identifier assigned to the record of 
         * the adverse reaction.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: Diagnosis Type</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000006CA.ReactionObservationEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Code is fixed to 
         * DX if not using SNOMED</p> <p>Indicates that the observation 
         * is actually a diagnosis and is therefore mandatory. The 
         * datatype is CD to support SNOMED post-coordination.</p> 
         * <p>If using SNOMED, this will contain the diagnosis. 
         * Otherwise it will be a fixed value of 'DX'.</p> <p>Indicates 
         * the type of diagnosis being captured.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActDiagnosisCode Code {
            get { return (ActDiagnosisCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: G:Description</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000006CA.ReactionObservationEvent.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows for 
         * flexibility in the recording and reporting of the 
         * reaction.</p> <p>A free form description of the 
         * reaction.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public String Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Business Name: F:Reaction Onset Date</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000006CA.ReactionObservationEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Indicates when 
         * evidence of the condition first appeared. May also provide 
         * information on the duration of the reaction.</p> <p>The date 
         * on which the reaction occurrence began.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: G:Adverse Reaction Masking 
         * Indicators</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000006CA.ReactionObservationEvent.confidentialityCode 
         * Conformance/Cardinality: REQUIRED (0-2) <p>Allows the 
         * patient to have discrete control over access to their 
         * adverse reaction data.</p><p>Taboo allows the provider to 
         * request restricted access to patient or their care 
         * giver.</p><p>Constraint: Cant have both normal and one of 
         * the other codes simultaneously.</p><p>The attribute is 
         * required because even if a jurisdiction doesn't support 
         * masking on the way in, it will need to need to communicate 
         * masked data returned from other jurisdictions.</p> 
         * <p>Communicates the desire of the patient to restrict access 
         * to this Health Condition record. Provides support for 
         * additional confidentiality constraint, giving patients a 
         * level of control over their information. Methods for 
         * accessing masked event records will be governed by each 
         * jurisdiction (e.g. court orders, shared secret/consent, 
         * etc.). Can also be used to communicate that the information 
         * is deemed to be sensitive and should not be communicated or 
         * exposed to the patient (at least without the guidance of the 
         * authoring or other responsible healthcare provider). Valid 
         * values are: 'normal' (denotes 'Not Masked'); 'restricted' 
         * (denotes 'Masked'); very restricted (denotes Masked by 
         * Regulation); and 'taboo' (denotes 'patient restricted'). The 
         * default is 'normal' signifying 'Not Masked'. Either or both 
         * of the other codes can be asserted to indicate masking by 
         * the patient from providers or masking by a provider from the 
         * patient, respectively. 'normal' should never be asserted 
         * with one of the other codes.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_BasicConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_BasicConfidentialityKind>(); }
        }

        /**
         * <summary>Business Name: B:Reaction</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000006CA.ReactionObservationEvent.value 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Value is 
         * mandatory if not using SNOMED</p> <p>B.1</p> <p>Ensures 
         * consistency in tracking and categorizing the reaction type. 
         * Helps ensure that only proper allergies are categorized as 
         * allergy. The attribute is optional because it will not be 
         * used for SNOMED. The attribute is CWE because not all 
         * possible types of reactions are expressible by coded 
         * values.</p> <p>Specifies the kind of reaction, as 
         * experienced by the patient.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public SubjectReaction Value {
            get { return (SubjectReaction) this.value.Value; }
            set { this.value.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT000006CA.ResponsibleParty.assignedEntity</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.HealthcareWorker ResponsiblePartyAssignedEntity {
            get { return this.responsiblePartyAssignedEntity; }
            set { this.responsiblePartyAssignedEntity = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT000006CA.ReactionObservationEvent.author</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.RefusedBy Author {
            get { return this.author; }
            set { this.author = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT000006CA.ReactionObservationEvent.informant</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"informant"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.ReportedBy Informant {
            get { return this.informant; }
            set { this.informant = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT000006CA.ReactionObservationEvent.location</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.OccurredAt Location {
            get { return this.location; }
            set { this.location = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT000006CA.ReactionObservationEvent.subjectOf1</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-99)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf1"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.Includes> SubjectOf1 {
            get { return this.subjectOf1; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT000006CA.Subject4.annotationIndicator</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2/annotationIndicator"})]
        public bool? SubjectOf2AnnotationIndicator {
            get { return this.subjectOf2AnnotationIndicator.Value; }
            set { this.subjectOf2AnnotationIndicator.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT000006CA.Subject6.causalityAssessment</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf3/causalityAssessment"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.ReportedReactions> SubjectOf3CausalityAssessment {
            get { return this.subjectOf3CausalityAssessment; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT000006CA.Subject1.severityObservation</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf4/severityObservation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.AllergyIntoleranceSeverityLevel SubjectOf4SeverityObservation {
            get { return this.subjectOf4SeverityObservation; }
            set { this.subjectOf4SeverityObservation = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT000006CA.Component.patientCareProvisionEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"componentOf/patientCareProvisionEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.CareCompositions> ComponentOfPatientCareProvisionEvent {
            get { return this.componentOfPatientCareProvisionEvent; }
        }

    }

}