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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Polb_mt004200ca {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt130001ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt090502ca;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Diagnosis or Interpretation 
     * Observation</summary>
     * 
     * <p>The observation for communicating pathologists 
     * interpretations regarding a specimen. All observations which 
     * support the diagnosis report section(s) directly associated 
     * with the relevant diagnosis section. This structure for 
     * communicating pathology information is different than the 
     * way the sections are formattted in the printed report (each 
     * section contains all specimens with ordinal numbers).</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POLB_MT004200CA.SectionLevelObservationEvent"})]
    public class DiagnosisOrInterpretationObservation : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Polb_mt004200ca.IObservationChoice {

        private SET<II, Identifier> id;
        private CD code;
        private ST text;
        private CS statusCode;
        private TS effectiveTime;
        private SET<CV, Code> confidentialityCode;
        private ANY<object> value;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.ReportSectionSpecimen> specimen;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.IRoleChoice> receiverRoleChoice;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.WasPerformedBy> performer;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt090502ca.HealthcareOrganization primaryInformationRecipientAssignedEntity;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.IFulfillmentChoice> inFulfillmentOfFulfillmentChoice;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.Outbreak pertinentInformation1OutbreakEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.SupportingClinicalInformation> pertinentInformation2SupportingClinicalObservationEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.ReportableHealthIndicator> component1ReportableTestIndicator;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.ResultSortKey component2ResultSortKey;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Polb_mt004200ca.ReportSectionObservation> component3ReportLevelObservationEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Polb_mt004200ca.IObservationChoice> component4ObservationChoice;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt130001ca.VersionInformation subjectOf1ControlActEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.Includes> subjectOf2;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.ResultStatusProcessStep subjectOf3ResultStatusProcessStep;

        public DiagnosisOrInterpretationObservation() {
            this.id = new SETImpl<II, Identifier>(typeof(IIImpl));
            this.code = new CDImpl();
            this.text = new STImpl();
            this.statusCode = new CSImpl();
            this.effectiveTime = new TSImpl();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.value = new ANYImpl<object>();
            this.specimen = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.ReportSectionSpecimen>();
            this.receiverRoleChoice = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.IRoleChoice>();
            this.performer = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.WasPerformedBy>();
            this.inFulfillmentOfFulfillmentChoice = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.IFulfillmentChoice>();
            this.pertinentInformation2SupportingClinicalObservationEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.SupportingClinicalInformation>();
            this.component1ReportableTestIndicator = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.ReportableHealthIndicator>();
            this.component3ReportLevelObservationEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Polb_mt004200ca.ReportSectionObservation>();
            this.component4ObservationChoice = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Polb_mt004200ca.IObservationChoice>();
            this.subjectOf2 = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.Includes>();
        }
        /**
         * <summary>Business Name: Section Identifier</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT004200CA.SectionLevelObservationEvent.id 
         * Conformance/Cardinality: REQUIRED (0-2) <p>A unique 
         * identifier is mandatory for all updates to any object.</p> 
         * <p>Unique to identify this section of the report.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public ICollection<Identifier> Id {
            get { return this.id.RawSet(); }
        }

        /**
         * <summary>Business Name: Section Type</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT004200CA.SectionLevelObservationEvent.code 
         * Conformance/Cardinality: REQUIRED (1) <p>Describes the type 
         * of diagnostic observation. For cytology, LOINC codes are 
         * used for this attribute and also &quot;carry&quot; the 
         * specimen source e.g. ear, blood, etc. For surgical 
         * pathology, the specimen is indicated in the material entity 
         * and specimen collection procedure.method and text.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public SectionHeadingObservationCode Code {
            get { return (SectionHeadingObservationCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Section Text</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT004200CA.SectionLevelObservationEvent.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Used when the 
         * value attribute is not text-based (coded, for instance) and 
         * additional text information is required to be captured and 
         * communicated.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public String Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Business Name: Observation Status</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT004200CA.SectionLevelObservationEvent.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Status associated 
         * with the Section Level Observation.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: Section Reported Date/Time</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT004200CA.SectionLevelObservationEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The date/time 
         * this section was reported/released for reporting.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public PlatformDate EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: Result Masking Indicator</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT004200CA.SectionLevelObservationEvent.confidentialityCode 
         * Conformance/Cardinality: REQUIRED (0-2) <p>This code allows 
         * for privacy control by patients as well as flagged for 'not 
         * for disclosure to patient' by care providers.</p> <p>Any 
         * piece of information is potentially subject to 'masking', 
         * restricting it's availability from providers who have not 
         * been specifically authorized. Additionally, some clinical 
         * data requires the ability to mark as &quot;not for direct 
         * disclosure to patient&quot;. The values in this attribute 
         * enable the above masking to be represented and messaged.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_BasicConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_BasicConfidentialityKind>(); }
        }

        /**
         * <summary>Business Name: Section Value</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT004200CA.SectionLevelObservationEvent.value 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The value or 
         * pathologist's interpretation for the Section Type provided 
         * in SectionLevelObservationEvent.code. If a coded value 
         * applies, values must be selected from 
         * SectionHeadingObservationValue Concept Domain.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public object Value {
            get { return this.value.Value; }
            set { this.value.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT004200CA.ObservationChoice.specimen</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-10)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"specimen"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.ReportSectionSpecimen> Specimen {
            get { return this.specimen; }
        }

        /**
         * <summary>Relationship: POLB_MT004200CA.Receiver.roleChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"receiver/roleChoice"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.IRoleChoice> ReceiverRoleChoice {
            get { return this.receiverRoleChoice; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT004200CA.ObservationChoice.performer</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1-2)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"performer"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.WasPerformedBy> Performer {
            get { return this.performer; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT004200CA.PrimaryInformationRecipient.assignedEntity</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"primaryInformationRecipient/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt090502ca.HealthcareOrganization PrimaryInformationRecipientAssignedEntity {
            get { return this.primaryInformationRecipientAssignedEntity; }
            set { this.primaryInformationRecipientAssignedEntity = value; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT004200CA.InFulfillmentOf.fulfillmentChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"inFulfillmentOf/fulfillmentChoice"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.IFulfillmentChoice> InFulfillmentOfFulfillmentChoice {
            get { return this.inFulfillmentOfFulfillmentChoice; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT004200CA.PertinentInformation1.outbreakEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"pertinentInformation1/outbreakEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.Outbreak PertinentInformation1OutbreakEvent {
            get { return this.pertinentInformation1OutbreakEvent; }
            set { this.pertinentInformation1OutbreakEvent = value; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT004200CA.PertinentInformation2.supportingClinicalObservationEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"pertinentInformation2/supportingClinicalObservationEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.SupportingClinicalInformation> PertinentInformation2SupportingClinicalObservationEvent {
            get { return this.pertinentInformation2SupportingClinicalObservationEvent; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT004200CA.Component2.reportableTestIndicator</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component1/reportableTestIndicator"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.ReportableHealthIndicator> Component1ReportableTestIndicator {
            get { return this.component1ReportableTestIndicator; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT004200CA.Component3.resultSortKey</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component2/resultSortKey"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.ResultSortKey Component2ResultSortKey {
            get { return this.component2ResultSortKey; }
            set { this.component2ResultSortKey = value; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT004200CA.Component4.reportLevelObservationEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component3/reportLevelObservationEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Polb_mt004200ca.ReportSectionObservation> Component3ReportLevelObservationEvent {
            get { return this.component3ReportLevelObservationEvent; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT004200CA.Component1.observationChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component4/observationChoice"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Polb_mt004200ca.IObservationChoice> Component4ObservationChoice {
            get { return this.component4ObservationChoice; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT004200CA.Subject1.controlActEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf1/controlActEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt130001ca.VersionInformation SubjectOf1ControlActEvent {
            get { return this.subjectOf1ControlActEvent; }
            set { this.subjectOf1ControlActEvent = value; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT004200CA.ObservationChoice.subjectOf2</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-100)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.Includes> SubjectOf2 {
            get { return this.subjectOf2; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT004200CA.Subject3.resultStatusProcessStep</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf3/resultStatusProcessStep"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.ResultStatusProcessStep SubjectOf3ResultStatusProcessStep {
            get { return this.subjectOf3ResultStatusProcessStep; }
            set { this.subjectOf3ResultStatusProcessStep = value; }
        }

    }

}