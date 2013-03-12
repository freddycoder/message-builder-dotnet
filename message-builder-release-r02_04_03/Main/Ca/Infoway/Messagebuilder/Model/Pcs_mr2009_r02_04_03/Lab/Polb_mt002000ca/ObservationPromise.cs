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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt002000ca {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt130001ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged;
    using System;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"POLB_MT002000CA.ObservationPromise"})]
    public class ObservationPromise : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt002000ca.IPromiseChoice {

        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.ReportSectionSpecimen specimen;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.Patient_1 recordTargetPatient;
        private II id;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.ElectronicResultReceiver> receiver;
        private CD code;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.IRoleChoice> performerRoleChoice;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt002000ca.PrimaryInformationRecipient primaryInformationRecipient;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.IFulfillmentChoice> inFulfillmentOfFulfillmentChoice;
        private SET<CV, Code> confidentialityCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.Outbreak pertinentInformation1OutbreakEvent;
        private CV methodCode;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.SupportingClinicalInformation> pertinentInformation2SupportingClinicalObservationEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt002000ca.IPromiseChoice> componentPromiseChoice;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt130001ca.VersionInformation subjectOf1ControlActEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.Includes> subjectOf2;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.ResultStatusProcessStep subjectOf3ResultStatusProcessStep;

        public ObservationPromise() {
            this.id = new IIImpl();
            this.receiver = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.ElectronicResultReceiver>();
            this.code = new CDImpl();
            this.performerRoleChoice = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.IRoleChoice>();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.inFulfillmentOfFulfillmentChoice = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.IFulfillmentChoice>();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.methodCode = new CVImpl();
            this.pertinentInformation2SupportingClinicalObservationEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.SupportingClinicalInformation>();
            this.componentPromiseChoice = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt002000ca.IPromiseChoice>();
            this.subjectOf2 = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.Includes>();
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
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"recordTarget/patient"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.Patient_1 RecordTargetPatient {
            get { return this.recordTargetPatient; }
            set { this.recordTargetPatient = value; }
        }

        /**
         * <summary>Business Name: Lab Order Observation Identifier</summary>
         * 
         * <remarks>Relationship: POLB_MT002000CA.ObservationPromise.id 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT002000CA.PromiseChoice.receiver</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-20)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"receiver"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.ElectronicResultReceiver> Receiver {
            get { return this.receiver; }
        }

        /**
         * <summary>Business Name: Orderable Observation Type</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT002000CA.ObservationPromise.code 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ObservationResultableLabType Code {
            get { return (ObservationResultableLabType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Relationship: POLB_MT002000CA.Performer.roleChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"performer/roleChoice"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.IRoleChoice> PerformerRoleChoice {
            get { return this.performerRoleChoice; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT002000CA.PromiseChoice.primaryInformationRecipient</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"primaryInformationRecipient"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt002000ca.PrimaryInformationRecipient PrimaryInformationRecipient {
            get { return this.primaryInformationRecipient; }
            set { this.primaryInformationRecipient = value; }
        }

        /**
         * <summary>Business Name: Order Observation Activated 
         * Date/Time</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT002000CA.ObservationPromise.effectiveTime 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT002000CA.InFulfillmentOf.fulfillmentChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"inFulfillmentOf/fulfillmentChoice"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.IFulfillmentChoice> InFulfillmentOfFulfillmentChoice {
            get { return this.inFulfillmentOfFulfillmentChoice; }
        }

        /**
         * <summary>Business Name: Result Masking Indicator</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT002000CA.ObservationPromise.confidentialityCode 
         * Conformance/Cardinality: REQUIRED (0-2)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_BasicConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_BasicConfidentialityKind>(); }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT002000CA.PertinentInformation1.outbreakEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"pertinentInformation1/outbreakEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.Outbreak PertinentInformation1OutbreakEvent {
            get { return this.pertinentInformation1OutbreakEvent; }
            set { this.pertinentInformation1OutbreakEvent = value; }
        }

        /**
         * <summary>Business Name: Planned Observation Method</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT002000CA.ObservationPromise.methodCode 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"methodCode"})]
        public ObservationMethod MethodCode {
            get { return (ObservationMethod) this.methodCode.Value; }
            set { this.methodCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT002000CA.PertinentInformation2.supportingClinicalObservationEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"pertinentInformation2/supportingClinicalObservationEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.SupportingClinicalInformation> PertinentInformation2SupportingClinicalObservationEvent {
            get { return this.pertinentInformation2SupportingClinicalObservationEvent; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT002000CA.Component.promiseChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component/promiseChoice"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt002000ca.IPromiseChoice> ComponentPromiseChoice {
            get { return this.componentPromiseChoice; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT002000CA.Subject1.controlActEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
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
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf3/resultStatusProcessStep"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.ResultStatusProcessStep SubjectOf3ResultStatusProcessStep {
            get { return this.subjectOf3ResultStatusProcessStep; }
            set { this.subjectOf3ResultStatusProcessStep = value; }
        }

    }

}