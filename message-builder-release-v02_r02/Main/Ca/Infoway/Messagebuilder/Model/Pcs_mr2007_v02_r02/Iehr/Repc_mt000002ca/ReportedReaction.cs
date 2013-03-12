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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Iehr.Repc_mt000002ca {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Coct_mt120600ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Iehr.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Reported Reaction</summary>
     * 
     * <p>Value is mandatory if not using SNOMED</p> <p>Code is 
     * fixed to DX if not using SNOMED</p> <p>Useful in tracking 
     * reactions when it is not known precisely what product they 
     * are associated with and whether the reaction is due to an 
     * allergy or intolerance, a drug interaction or some other 
     * cause. Effectively gives a 'heads up' to clinicians using 
     * the drug or combination of drugs.</p> <p>This is a record of 
     * an adverse reaction considered relevant to the patient's 
     * clincal record.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT000002CA.ReactionObservationEvent"})]
    public class ReportedReaction : MessagePartBean {

        private CD code;
        private ST text;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private SET<CV, Code> confidentialityCode;
        private CV value;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Iehr.Merged.ReportedBy informant;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Coct_mt120600ca.Notes subjectOf1Annotation;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Merged.AllergyIntoleranceSeverityLevel subjectOf2SeverityObservation;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Iehr.Merged.ReportedReactions> subjectOf3CausalityAssessment;

        public ReportedReaction() {
            this.code = new CDImpl();
            this.text = new STImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.value = new CVImpl();
            this.subjectOf3CausalityAssessment = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Iehr.Merged.ReportedReactions>();
        }
        /**
         * <summary>Business Name: Diagnosis Type</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000002CA.ReactionObservationEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates that the 
         * observation is actually a diagnosis and is therefore 
         * mandatory. The datatype is CD to support SNOMED 
         * post-coordination.</p> <p>If using SNOMED, this will contain 
         * the diagnosis. Otherwise it will be a fixed value of 
         * 'DX'.</p> <p>Indicates the type of diagnosis being 
         * captured.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActCode Code {
            get { return (ActCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: G:Description</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000002CA.ReactionObservationEvent.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows for 
         * flexibility in the recording and reporting of the 
         * reaction.</p> <p>A free form description of the 
         * reaction.</p><p>This is a specific description of the 
         * reaction, as opposed to annotations on the 
         * reaction.</p><p>Annotations and text are quite different. 
         * Think of it from a user interface. Notes might be things 
         * like &quot;patient didn't have the problem when the took the 
         * medication two weeks earlier&quot; or &quot;patient thinks 
         * it might have been related to the two bottles of scotch they 
         * drank the night prior&quot;, which aren't describing the 
         * reaction but are relevant to the reaction record</p></remarks>
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
         * REPC_MT000002CA.ReactionObservationEvent.effectiveTime 
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
         * REPC_MT000002CA.ReactionObservationEvent.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-2) <p>Allows the 
         * patient to have discrete control over access to their 
         * adverse reaction data.</p><p>Taboo allows the provider to 
         * request restricted access to patient or their care 
         * giver.</p><p>Constraint: Cant have both normal and one of 
         * the other codes simultaneously.</p><p>The attribute is 
         * optional because not all systems will support masking.</p> 
         * <p>Communicates the intent of the patient to restrict access 
         * to their adverse reactions.</p><p>Provides support for 
         * additional confidentiality constraint, giving patients a 
         * level of control over their information.</p><p>Allows a 
         * provider to request restricted access by the 
         * patient.</p><p>Valid values are: 'N' (normal - denotes 'Not 
         * Masked'); 'R' (restricted - denotes 'Masked') and 'T' (taboo 
         * - denotes 'Patient Access Restricted').</p><p>The default is 
         * 'normal' signifying 'Not Masked'.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_NormalRestrictedTabooConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_NormalRestrictedTabooConfidentialityKind>(); }
        }

        /**
         * <summary>Business Name: B:Reaction</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000002CA.ReactionObservationEvent.value 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>B.1</p> 
         * <p>Ensures consistency in tracking and categorizing the 
         * reaction type. Helps ensure that only proper allergies are 
         * categorized as allergy. The attribute is optional because it 
         * will not be used for SNOMED. The attribute is CWE because 
         * not all possible types of reactions are expressible by coded 
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
         * REPC_MT000002CA.ReactionObservationEvent.informant</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"informant"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Iehr.Merged.ReportedBy Informant {
            get { return this.informant; }
            set { this.informant = value; }
        }

        /**
         * <summary>Relationship: REPC_MT000002CA.Subject3.annotation</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf1/annotation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Coct_mt120600ca.Notes SubjectOf1Annotation {
            get { return this.subjectOf1Annotation; }
            set { this.subjectOf1Annotation = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT000002CA.Subject1.severityObservation</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2/severityObservation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Merged.AllergyIntoleranceSeverityLevel SubjectOf2SeverityObservation {
            get { return this.subjectOf2SeverityObservation; }
            set { this.subjectOf2SeverityObservation = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT000002CA.Subject6.causalityAssessment</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf3/causalityAssessment"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Iehr.Merged.ReportedReactions> SubjectOf3CausalityAssessment {
            get { return this.subjectOf3CausalityAssessment; }
        }

    }

}