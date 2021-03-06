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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt002000ca {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt050007ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090502ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt130001ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged;
    using System;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"POLB_MT002000CA.BatteryPromise"})]
    public class BatteryPromise : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt002000ca.IPromiseChoice {

        private II id;
        private CD code;
        private CS statusCode;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private SET<CV, Code> confidentialityCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.ReportSectionSpecimen specimen;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt050007ca.Patient recordTargetPatient;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt002000ca.IRoleChoice> receiverRoleChoice;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt002000ca.IRoleChoice> performerRoleChoice;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090502ca.HealthcareOrganization primaryInformationRecipientAssignedEntity;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt002000ca.IFulfillmentChoice> inFulfillmentOfFulfillmentChoice;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.Outbreak pertinentInformation1OutbreakEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.SupportingClinicalInformation> pertinentInformation2SupportingClinicalObservationEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt002000ca.IPromiseChoice> componentPromiseChoice;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt130001ca.VersionInformation subjectOf1ControlActEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.Includes> subjectOf2;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.ResultStatusProcessStep subjectOf3ResultStatusProcessStep;

        public BatteryPromise() {
            this.id = new IIImpl();
            this.code = new CDImpl();
            this.statusCode = new CSImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.receiverRoleChoice = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt002000ca.IRoleChoice>();
            this.performerRoleChoice = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt002000ca.IRoleChoice>();
            this.inFulfillmentOfFulfillmentChoice = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt002000ca.IFulfillmentChoice>();
            this.pertinentInformation2SupportingClinicalObservationEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.SupportingClinicalInformation>();
            this.componentPromiseChoice = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt002000ca.IPromiseChoice>();
            this.subjectOf2 = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.Includes>();
        }
        /**
         * <summary>Business Name: Battery Promise Identifier</summary>
         * 
         * <remarks>Relationship: POLB_MT002000CA.BatteryPromise.id 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: Type of Battery Promise</summary>
         * 
         * <remarks>Relationship: POLB_MT002000CA.BatteryPromise.code 
         * Conformance/Cardinality: REQUIRED (1) <p>A code identifying 
         * what was ordered by the lab.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ObservationOrderableLabType Code {
            get { return (ObservationOrderableLabType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Battery Promise Status</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT002000CA.BatteryPromise.statusCode 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: Battery Promise Effective Time</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT002000CA.BatteryPromise.effectiveTime 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: Battery Promise Confidentiality</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT002000CA.BatteryPromise.confidentialityCode 
         * Conformance/Cardinality: REQUIRED (1-2)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_BasicConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_BasicConfidentialityKind>(); }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT002000CA.PromiseChoice.specimen</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"specimen"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.ReportSectionSpecimen Specimen {
            get { return this.specimen; }
            set { this.specimen = value; }
        }

        /**
         * <summary>Relationship: POLB_MT002000CA.RecordTarget.patient</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"recordTarget/patient"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt050007ca.Patient RecordTargetPatient {
            get { return this.recordTargetPatient; }
            set { this.recordTargetPatient = value; }
        }

        /**
         * <summary>Relationship: POLB_MT002000CA.Receiver.roleChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"receiver/roleChoice"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt002000ca.IRoleChoice> ReceiverRoleChoice {
            get { return this.receiverRoleChoice; }
        }

        /**
         * <summary>Relationship: POLB_MT002000CA.Performer.roleChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"performer/roleChoice"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt002000ca.IRoleChoice> PerformerRoleChoice {
            get { return this.performerRoleChoice; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT002000CA.PrimaryInformationRecipient.assignedEntity</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"primaryInformationRecipient/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090502ca.HealthcareOrganization PrimaryInformationRecipientAssignedEntity {
            get { return this.primaryInformationRecipientAssignedEntity; }
            set { this.primaryInformationRecipientAssignedEntity = value; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT002000CA.InFulfillmentOf.fulfillmentChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"inFulfillmentOf/fulfillmentChoice"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt002000ca.IFulfillmentChoice> InFulfillmentOfFulfillmentChoice {
            get { return this.inFulfillmentOfFulfillmentChoice; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT002000CA.PertinentInformation1.outbreakEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"pertinentInformation1/outbreakEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.Outbreak PertinentInformation1OutbreakEvent {
            get { return this.pertinentInformation1OutbreakEvent; }
            set { this.pertinentInformation1OutbreakEvent = value; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT002000CA.PertinentInformation2.supportingClinicalObservationEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"pertinentInformation2/supportingClinicalObservationEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.SupportingClinicalInformation> PertinentInformation2SupportingClinicalObservationEvent {
            get { return this.pertinentInformation2SupportingClinicalObservationEvent; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT002000CA.Component.promiseChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component/promiseChoice"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt002000ca.IPromiseChoice> ComponentPromiseChoice {
            get { return this.componentPromiseChoice; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT002000CA.Subject1.controlActEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf1/controlActEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt130001ca.VersionInformation SubjectOf1ControlActEvent {
            get { return this.subjectOf1ControlActEvent; }
            set { this.subjectOf1ControlActEvent = value; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT002000CA.PromiseChoice.subjectOf2</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-100)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.Includes> SubjectOf2 {
            get { return this.subjectOf2; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT002000CA.Subject3.resultStatusProcessStep</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf3/resultStatusProcessStep"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.ResultStatusProcessStep SubjectOf3ResultStatusProcessStep {
            get { return this.subjectOf3ResultStatusProcessStep; }
            set { this.subjectOf3ResultStatusProcessStep = value; }
        }

    }

}