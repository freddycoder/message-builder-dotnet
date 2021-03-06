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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Polb_mt004000ca {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt050007ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt090508ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt130001ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt090502ca;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Battery Event</summary>
     * 
     * <p>Used to group Observation Events by the batteries that 
     * were ordered by the lab.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POLB_MT004000CA.BatteryEvent"})]
    public class BatteryEvent : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Polb_mt004000ca.IResultChoice {

        private SET<II, Identifier> id;
        private CD code;
        private CS statusCode;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private SET<CV, Code> confidentialityCode;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.ReportSectionSpecimen> specimen;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt050007ca.Patient recordTargetPatient;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.IRoleChoice> receiverRoleChoice;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.IRoleChoice> performerRoleChoice;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Polb_mt004000ca.IRecipientChoice primaryInformationRecipientRecipientChoice;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.IFulfillmentChoice> inFulfillmentOfFulfillmentChoice;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.Outbreak pertinentInformation1OutbreakEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.SupportingClinicalInformation> pertinentInformation2SupportingClinicalObservationEvent;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.ResultSortKey component1ResultSortKey;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.ReportableHealthIndicator> component2ReportableTestIndicator;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Polb_mt004000ca.IResultChoice> component3ResultChoice;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt130001ca.VersionInformation subjectOf1ControlActEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.Includes> subjectOf2;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.ResultStatusProcessStep subjectOf3ResultStatusProcessStep;

        public BatteryEvent() {
            this.id = new SETImpl<II, Identifier>(typeof(IIImpl));
            this.code = new CDImpl();
            this.statusCode = new CSImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.specimen = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.ReportSectionSpecimen>();
            this.receiverRoleChoice = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.IRoleChoice>();
            this.performerRoleChoice = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.IRoleChoice>();
            this.inFulfillmentOfFulfillmentChoice = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.IFulfillmentChoice>();
            this.pertinentInformation2SupportingClinicalObservationEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.SupportingClinicalInformation>();
            this.component2ReportableTestIndicator = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.ReportableHealthIndicator>();
            this.component3ResultChoice = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Polb_mt004000ca.IResultChoice>();
            this.subjectOf2 = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.Includes>();
        }
        /**
         * <summary>Business Name: Battery Event Identifier</summary>
         * 
         * <remarks>Relationship: POLB_MT004000CA.BatteryEvent.id 
         * Conformance/Cardinality: REQUIRED (1-2) <p>This is a unique 
         * identifier for the Battery Event.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public ICollection<Identifier> Id {
            get { return this.id.RawSet(); }
        }

        /**
         * <summary>Business Name: Type of Battery Event</summary>
         * 
         * <remarks>Relationship: POLB_MT004000CA.BatteryEvent.code 
         * Conformance/Cardinality: REQUIRED (1) <p>Code drawn from the 
         * pCLOCD to identify the battery ordered by the lab.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ObservationOrderableLabType Code {
            get { return (ObservationOrderableLabType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Battery Event Status</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT004000CA.BatteryEvent.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Status associated 
         * with all ObservationEvents that are components of this 
         * Battery Event.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: Battery Event Effective Time</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT004000CA.BatteryEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (1) <p>Effective time 
         * associated with the lab order battery.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: Battery Event Confidentiality</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT004000CA.BatteryEvent.confidentialityCode 
         * Conformance/Cardinality: REQUIRED (0-2) <p>Level of 
         * confidentiality assoicated with the reporting of the 
         * Observation Events that are components of this Battery.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_BasicConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_BasicConfidentialityKind>(); }
        }

        /**
         * <summary>Relationship: POLB_MT004000CA.ResultChoice.specimen</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-100)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"specimen"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.ReportSectionSpecimen> Specimen {
            get { return this.specimen; }
        }

        /**
         * <summary>Relationship: POLB_MT004000CA.RecordTarget.patient</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"recordTarget/patient"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt050007ca.Patient RecordTargetPatient {
            get { return this.recordTargetPatient; }
            set { this.recordTargetPatient = value; }
        }

        /**
         * <summary>Relationship: POLB_MT004000CA.Receiver.roleChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"receiver/roleChoice"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.IRoleChoice> ReceiverRoleChoice {
            get { return this.receiverRoleChoice; }
        }

        /**
         * <summary>Relationship: POLB_MT004000CA.Performer.roleChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"performer/roleChoice"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.IRoleChoice> PerformerRoleChoice {
            get { return this.performerRoleChoice; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT004000CA.PrimaryInformationRecipient.recipientChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"primaryInformationRecipient/recipientChoice"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Polb_mt004000ca.IRecipientChoice PrimaryInformationRecipientRecipientChoice {
            get { return this.primaryInformationRecipientRecipientChoice; }
            set { this.primaryInformationRecipientRecipientChoice = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt090508ca.HealthcareOrganization PrimaryInformationRecipientRecipientChoiceAsAssignedEntity1 {
            get { return this.primaryInformationRecipientRecipientChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt090508ca.HealthcareOrganization ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt090508ca.HealthcareOrganization) this.primaryInformationRecipientRecipientChoice : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt090508ca.HealthcareOrganization) null; }
        }
        public bool HasPrimaryInformationRecipientRecipientChoiceAsAssignedEntity1() {
            return (this.primaryInformationRecipientRecipientChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt090508ca.HealthcareOrganization);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt090502ca.HealthcareOrganization PrimaryInformationRecipientRecipientChoiceAsAssignedEntity2 {
            get { return this.primaryInformationRecipientRecipientChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt090502ca.HealthcareOrganization ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt090502ca.HealthcareOrganization) this.primaryInformationRecipientRecipientChoice : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt090502ca.HealthcareOrganization) null; }
        }
        public bool HasPrimaryInformationRecipientRecipientChoiceAsAssignedEntity2() {
            return (this.primaryInformationRecipientRecipientChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt090502ca.HealthcareOrganization);
        }

        /**
         * <summary>Relationship: 
         * POLB_MT004000CA.InFulfillmentOf.fulfillmentChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"inFulfillmentOf/fulfillmentChoice"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.IFulfillmentChoice> InFulfillmentOfFulfillmentChoice {
            get { return this.inFulfillmentOfFulfillmentChoice; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT004000CA.PertinentInformation1.outbreakEvent</summary>
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
         * POLB_MT004000CA.PertinentInformation2.supportingClinicalObservationEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"pertinentInformation2/supportingClinicalObservationEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.SupportingClinicalInformation> PertinentInformation2SupportingClinicalObservationEvent {
            get { return this.pertinentInformation2SupportingClinicalObservationEvent; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT004000CA.Component2.resultSortKey</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component1/resultSortKey"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.ResultSortKey Component1ResultSortKey {
            get { return this.component1ResultSortKey; }
            set { this.component1ResultSortKey = value; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT004000CA.Component3.reportableTestIndicator</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component2/reportableTestIndicator"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.ReportableHealthIndicator> Component2ReportableTestIndicator {
            get { return this.component2ReportableTestIndicator; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT004000CA.Component1.resultChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component3/resultChoice"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Polb_mt004000ca.IResultChoice> Component3ResultChoice {
            get { return this.component3ResultChoice; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT004000CA.Subject1.controlActEvent</summary>
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
         * POLB_MT004000CA.ResultChoice.subjectOf2</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-100)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.Includes> SubjectOf2 {
            get { return this.subjectOf2; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT004000CA.Subject3.resultStatusProcessStep</summary>
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