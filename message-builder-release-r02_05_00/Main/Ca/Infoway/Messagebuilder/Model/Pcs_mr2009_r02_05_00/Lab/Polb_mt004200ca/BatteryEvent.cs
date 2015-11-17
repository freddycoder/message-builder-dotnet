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
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt090502ca;
    using System;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"POLB_MT004200CA.BatteryEvent"})]
    public class BatteryEvent : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Polb_mt004200ca.IObservationChoice {

        private SET<II, Identifier> id;
        private CD code;
        private CS statusCode;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private SET<CV, Code> confidentialityCode;
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

        public BatteryEvent() {
            this.id = new SETImpl<II, Identifier>(typeof(IIImpl));
            this.code = new CDImpl();
            this.statusCode = new CSImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
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
         * <summary>Business Name: Battery Event Identifier</summary>
         * 
         * <remarks>Relationship: POLB_MT004200CA.BatteryEvent.id 
         * Conformance/Cardinality: MANDATORY (1-2)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public ICollection<Identifier> Id {
            get { return this.id.RawSet(); }
        }

        /**
         * <summary>Business Name: Type of Battery Event</summary>
         * 
         * <remarks>Relationship: POLB_MT004200CA.BatteryEvent.code 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
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
         * POLB_MT004200CA.BatteryEvent.statusCode 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
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
         * POLB_MT004200CA.BatteryEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (1) <p>Time at which the 
         * lab order became effective.</p></remarks>
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
         * POLB_MT004200CA.BatteryEvent.confidentialityCode 
         * Conformance/Cardinality: REQUIRED (0-2)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_BasicConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_BasicConfidentialityKind>(); }
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