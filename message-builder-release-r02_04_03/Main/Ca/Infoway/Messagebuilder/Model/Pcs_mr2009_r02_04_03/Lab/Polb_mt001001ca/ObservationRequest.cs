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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt001001ca {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090102ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt130001ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged;
    using System;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"POLB_MT001001CA.ObservationRequest"})]
    public class ObservationRequest : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt001001ca.IRequestChoice {

        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.IRecipientChoice> informationRecipientRecipientChoice;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090102ca.HealthcareWorker> verifierAssignedEntity;
        private II id;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.ParentTest occurrenceOfActParentPointer;
        private CD code;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.SupportingClinicalInformation> pertinentInformationSupportingClinicalObservationEvent;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.LabInitiatedOrderIndicator component1LabInitiatedOrderIndicator;
        private CS statusCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.ReferralRedirectIndicator component2ReferralRedirectIndicator;
        private LIST<GTS, GeneralTimingSpecification> effectiveTime;
        private TS availabilityTime;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.OrderSortKey component3RequestSortKey;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt001001ca.IRequestChoice> component4RequestChoice;
        private CV priorityCode;
        private SET<CV, Code> confidentialityCode;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.Includes> subjectOf1;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt130001ca.VersionInformation subjectOf2ControlActEvent;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.PriorTestRequest componentOf1PriorActRequest;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.CareCompositions> componentOf2PatientCareProvisionEvent;

        public ObservationRequest() {
            this.informationRecipientRecipientChoice = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.IRecipientChoice>();
            this.verifierAssignedEntity = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090102ca.HealthcareWorker>();
            this.id = new IIImpl();
            this.code = new CDImpl();
            this.pertinentInformationSupportingClinicalObservationEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.SupportingClinicalInformation>();
            this.statusCode = new CSImpl();
            this.effectiveTime = new LISTImpl<GTS, GeneralTimingSpecification>(typeof(GTSImpl));
            this.availabilityTime = new TSImpl();
            this.component4RequestChoice = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt001001ca.IRequestChoice>();
            this.priorityCode = new CVImpl();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.subjectOf1 = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.Includes>();
            this.componentOf2PatientCareProvisionEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.CareCompositions>();
        }
        /**
         * <summary>Relationship: 
         * POLB_MT001001CA.InformationRecipient.recipientChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"informationRecipient/recipientChoice"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.IRecipientChoice> InformationRecipientRecipientChoice {
            get { return this.informationRecipientRecipientChoice; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT001001CA.Verifier.assignedEntity</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"verifier/assignedEntity"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090102ca.HealthcareWorker> VerifierAssignedEntity {
            get { return this.verifierAssignedEntity; }
        }

        /**
         * <summary>Business Name: F:Test Identifier</summary>
         * 
         * <remarks>Relationship: POLB_MT001001CA.ObservationRequest.id 
         * Conformance/Cardinality: POPULATED (1) <p>Used to uniquely 
         * identify this test. Necessary for order revisions and 
         * cancellations.</p> <p>Must contain a value assigned by the 
         * order-placing organization that uniquely identifies this 
         * test request among all test requests in the receiving 
         * application.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT001001CA.OccurrenceOf.actParentPointer</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"occurrenceOf/actParentPointer"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.ParentTest OccurrenceOfActParentPointer {
            get { return this.occurrenceOfActParentPointer; }
            set { this.occurrenceOfActParentPointer = value; }
        }

        /**
         * <summary>Business Name: G:Test Code</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT001001CA.ObservationRequest.code 
         * Conformance/Cardinality: POPULATED (1) <p>Specifies the 
         * requested test to be performed.</p> <p>LOINC code for the 
         * ordered test The value set bound to this attribute is a list 
         * of LOINC codes pulled from the pan-Canadian Laboratory 
         * Observation Code Database (pCLOCD). Only those records 
         * flagged as orderable or &quot;both&quot; in the pCLOCD can 
         * be used.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ObservationOrderableLabType Code {
            get { return (ObservationOrderableLabType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT001001CA.PertinentInformation.supportingClinicalObservationEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"pertinentInformation/supportingClinicalObservationEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.SupportingClinicalInformation> PertinentInformationSupportingClinicalObservationEvent {
            get { return this.pertinentInformationSupportingClinicalObservationEvent; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT001001CA.Component.labInitiatedOrderIndicator</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component1/labInitiatedOrderIndicator"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.LabInitiatedOrderIndicator Component1LabInitiatedOrderIndicator {
            get { return this.component1LabInitiatedOrderIndicator; }
            set { this.component1LabInitiatedOrderIndicator = value; }
        }

        /**
         * <summary>Business Name: I:Test Status</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT001001CA.ObservationRequest.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>The statusCode 
         * represents the &quot;state&quot; of the test e.g. active=in 
         * progress or not yet started, complete=resulted and/or 
         * reported.</p> <p>The statusCode represents the 
         * &quot;state&quot; of the act e.g. active=in progress or not 
         * yet started, complete=resulted and/or result reported. It is 
         * up to the order placer to determine when, upon receipt of 
         * one or more results which fulfill this order, the order is 
         * complete.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT001001CA.Component1.referralRedirectIndicator</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component2/referralRedirectIndicator"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.ReferralRedirectIndicator Component2ReferralRedirectIndicator {
            get { return this.component2ReferralRedirectIndicator; }
            set { this.component2ReferralRedirectIndicator = value; }
        }

        /**
         * <summary>Business Name: H:Test Request Time Specification</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT001001CA.ObservationRequest.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-9) <p>Would be used to 
         * communicate that an Order is for a future date.</p> <p>The 
         * time specification for when this test is requested to be 
         * performed or occur or when the changes to the request took 
         * effect or are supposed to take effect. This time 
         * specification includes support for complex, repeating 
         * orders.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public IList<GeneralTimingSpecification> EffectiveTime {
            get { return this.effectiveTime.RawList(); }
        }

        /**
         * <summary>Business Name: L:Test Request Availability Time</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT001001CA.ObservationRequest.availabilityTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>OLIS needs to be 
         * able to communicate the timestamp that it assigns to an 
         * ObservationRequest (test request) when the test request is 
         * created, revised, and whenever result information is added 
         * or revised. ObservationRequest.availabilityTime has been 
         * determined to be the most appropriate field.</p> <p>The 
         * date/time when this order is available.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"availabilityTime"})]
        public PlatformDate AvailabilityTime {
            get { return this.availabilityTime.Value; }
            set { this.availabilityTime.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT001001CA.Component2.requestSortKey</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component3/requestSortKey"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.OrderSortKey Component3RequestSortKey {
            get { return this.component3RequestSortKey; }
            set { this.component3RequestSortKey = value; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT001001CA.Component5.requestChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component4/requestChoice"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt001001ca.IRequestChoice> Component4RequestChoice {
            get { return this.component4RequestChoice; }
        }

        /**
         * <summary>Business Name: J:Test Priority Code</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT001001CA.ObservationRequest.priorityCode 
         * Conformance/Cardinality: POPULATED (1) <p>Communicates 
         * requested test priority (e.g. routine, stat, etc.)</p> 
         * <p>Priority code associated with a specific test.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"priorityCode"})]
        public ActPriority PriorityCode {
            get { return (ActPriority) this.priorityCode.Value; }
            set { this.priorityCode.Value = value; }
        }

        /**
         * <summary>Business Name: K:Test Masking Indicator</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT001001CA.ObservationRequest.confidentialityCode 
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
         * <summary>Relationship: 
         * POLB_MT001001CA.RequestChoice.subjectOf1</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-100)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf1"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.Includes> SubjectOf1 {
            get { return this.subjectOf1; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT001001CA.Subject2.controlActEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2/controlActEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt130001ca.VersionInformation SubjectOf2ControlActEvent {
            get { return this.subjectOf2ControlActEvent; }
            set { this.subjectOf2ControlActEvent = value; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT001001CA.Component3.priorActRequest</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"componentOf1/priorActRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.PriorTestRequest ComponentOf1PriorActRequest {
            get { return this.componentOf1PriorActRequest; }
            set { this.componentOf1PriorActRequest = value; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT001001CA.Component4.patientCareProvisionEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"componentOf2/patientCareProvisionEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.CareCompositions> ComponentOf2PatientCareProvisionEvent {
            get { return this.componentOf2PatientCareProvisionEvent; }
        }

    }

}