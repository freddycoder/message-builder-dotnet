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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Porx_mt060040ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt090107ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt141007ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Prescription</summary>
     * 
     * <p>Reported Issue is only permitted if Issue Indicator is 
     * not present and vice versa.</p> <p>Annotation is only 
     * permitted if Annotation Indicator is not present and vice 
     * versa</p> <p>This is a 'core' class of the medication model 
     * and is important for understanding what devices the patient 
     * is intended to be receiving.</p> <p>Information pertaining 
     * to a Prescriber's authorization for a device to be dispensed 
     * to a patient, as well as the instruction on when and how the 
     * device is to be used by the patient.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060040CA.DeviceRequest"})]
    public class Prescription : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.IPrescription_1 {

        private II id;
        private CS statusCode;
        private CV confidentialityCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt141007ca.DeviceProduct directTargetManufacturedProduct;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Merged.Patient subjectPatient;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt090107ca.Provider responsiblePartyAssignedPerson;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.PrescribedBy author;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged.RecordedAt location;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.ParentPrescription predecessorPriorSupplyRequest;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.PrescribedBecauseOf> reason;
        private BL preconditionVerificationEventCriterion;
        private BL derivedFromSourceDispense;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.CoverageExtensions_1> coverageCoverage;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.ProcedureRequest component1ProcedureRequest;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.Component2_1 component2;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.LastDispenseInformation_2 fulfillment1SupplyEventLastSummary;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.FirstDispenseInformation_2 fulfillment2SupplyEventFirstSummary;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.RemainingDispenseInformation_2 fulfillment3SupplyEventFutureSummary;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.PreviousDispenseInformation_2 fulfillment4SupplyEventPastSummary;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.DeviceDispense_1> fulfillment5DeviceDispense;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.Issues> subjectOf1DetectedIssueEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.StatusChanges> subjectOf2ControlActEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged.Comment> subjectOf3Annotation;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.RefusalToFills> subjectOf4RefusalToFill;
        private BL subjectOf5DetectedIssueIndicator;
        private BL subjectOf6AnnotationIndicator;

        public Prescription() {
            this.id = new IIImpl();
            this.statusCode = new CSImpl();
            this.confidentialityCode = new CVImpl();
            this.reason = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.PrescribedBecauseOf>();
            this.preconditionVerificationEventCriterion = new BLImpl(false);
            this.derivedFromSourceDispense = new BLImpl(false);
            this.coverageCoverage = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.CoverageExtensions_1>();
            this.fulfillment5DeviceDispense = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.DeviceDispense_1>();
            this.subjectOf1DetectedIssueEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.Issues>();
            this.subjectOf2ControlActEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.StatusChanges>();
            this.subjectOf3Annotation = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged.Comment>();
            this.subjectOf4RefusalToFill = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.RefusalToFills>();
            this.subjectOf5DetectedIssueIndicator = new BLImpl(false);
            this.subjectOf6AnnotationIndicator = new BLImpl(false);
        }
        /**
         * <summary>Business Name: A:Prescription Order Number</summary>
         * 
         * <remarks>Relationship: PORX_MT060040CA.DeviceRequest.id 
         * Conformance/Cardinality: MANDATORY (1) 
         * <p>Prescription.prescriptionNumber</p> 
         * <p>Prescription.prescriptionExternalKey</p> <p>D53(ID for 
         * the prescription assigned by pharmacy)</p> <p>D55(ID for the 
         * dispense event)</p> <p>D99.01</p> <p>X0101(id for 
         * prescription)</p> <p>ZDP.5</p> <p>ZDP.6</p> <p>ZDP.22</p> 
         * <p>ZRV.5</p> <p>DRU.080-01(extension)</p> 
         * <p>DRU.080-02(route)</p> <p>Claim.455-EM (route)</p> 
         * <p>Claim.402-D2 (extension)</p> <p>Claim.456-EN</p> 
         * <p>Claim.454-EK</p> <p>A_BillablePharmacyDispense</p> 
         * <p>Allows prescriptions to be uniquely referenced.</p><p>The 
         * number is mandatory to allow every prescription record to be 
         * uniquely identified.</p> <p>The Prescription Order Number is 
         * a globally unique number assigned to a prescription by the 
         * EHR/DIS irrespective of the source of the order</p><p>It is 
         * created by the EHR/DIS once the prescription has passed all 
         * edits and validation.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: C:Prescription Status</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060040CA.DeviceRequest.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Prescription.state 
         * (cannot distinguish between 'Filled' and 'Unfilled', must 
         * look at amounts dispensed to distniguish between those; and 
         * also cannot distinguish modified, need to look at event 
         * history).</p> <p>Prescription Status</p> <p>Indicates what 
         * actions are allowed to be performed against a 
         * prescription.</p><p>This is a mandatory field because every 
         * prescription needs to be in some state.</p> <p>This denotes 
         * the state of the prescription in the lifecycle of the 
         * prescription. Valid statuses are: NEW, ACTIVE, SUSPENDED, 
         * ABORTED, COMPLETED, OBSOLETE and NULLIFIED.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: F:Prescription Masking Indicator</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060040CA.DeviceRequest.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-1) 
         * <p>Prescription.masked</p> <p>Allows the patient to have 
         * discrete control over access to their prescription 
         * data.</p><p>The attribute is optional because not all 
         * systems will support masking.</p> <p>Communicates the intent 
         * of the patient to restrict access to their 
         * prescriptions.</p><p>Provides support for additional 
         * confidentiality constraint, giving patients a level of 
         * control over their information.</p><p>Valid values are: 
         * 'NORMAL' (denotes 'Not Masked'); and 'RESTRICTED' (denotes 
         * 'Masked').</p><p>The default is 'NORMAL' signifying 'Not 
         * Masked'.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public x_VeryBasicConfidentialityKind ConfidentialityCode {
            get { return (x_VeryBasicConfidentialityKind) this.confidentialityCode.Value; }
            set { this.confidentialityCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060040CA.DirectTarget.manufacturedProduct</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"directTarget/manufacturedProduct"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt141007ca.DeviceProduct DirectTargetManufacturedProduct {
            get { return this.directTargetManufacturedProduct; }
            set { this.directTargetManufacturedProduct = value; }
        }

        /**
         * <summary>Relationship: PORX_MT060040CA.Subject5.patient</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject/patient"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Merged.Patient SubjectPatient {
            get { return this.subjectPatient; }
            set { this.subjectPatient = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060040CA.ResponsibleParty2.assignedPerson</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/assignedPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt090107ca.Provider ResponsiblePartyAssignedPerson {
            get { return this.responsiblePartyAssignedPerson; }
            set { this.responsiblePartyAssignedPerson = value; }
        }

        /**
         * <summary>Relationship: PORX_MT060040CA.DeviceRequest.author</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.PrescribedBy Author {
            get { return this.author; }
            set { this.author = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060040CA.DeviceRequest.location</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged.RecordedAt Location {
            get { return this.location; }
            set { this.location = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060040CA.Predecessor.priorSupplyRequest</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"predecessor/priorSupplyRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.ParentPrescription PredecessorPriorSupplyRequest {
            get { return this.predecessorPriorSupplyRequest; }
            set { this.predecessorPriorSupplyRequest = value; }
        }

        /**
         * <summary>Relationship: PORX_MT060040CA.DeviceRequest.reason</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1-5)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reason"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.PrescribedBecauseOf> Reason {
            get { return this.reason; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060040CA.Precondition.verificationEventCriterion</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"precondition/verificationEventCriterion"})]
        public bool? PreconditionVerificationEventCriterion {
            get { return this.preconditionVerificationEventCriterion.Value; }
            set { this.preconditionVerificationEventCriterion.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060040CA.DerivedFrom.sourceDispense</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"derivedFrom/sourceDispense"})]
        public bool? DerivedFromSourceDispense {
            get { return this.derivedFromSourceDispense.Value; }
            set { this.derivedFromSourceDispense.Value = value; }
        }

        /**
         * <summary>Relationship: PORX_MT060040CA.Coverage2.coverage</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"coverage/coverage"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.CoverageExtensions_1> CoverageCoverage {
            get { return this.coverageCoverage; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060040CA.Component1.procedureRequest</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component1/procedureRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.ProcedureRequest Component1ProcedureRequest {
            get { return this.component1ProcedureRequest; }
            set { this.component1ProcedureRequest = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060040CA.DeviceRequest.component2</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component2"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.Component2_1 Component2 {
            get { return this.component2; }
            set { this.component2 = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060040CA.InFulfillmentOf5.supplyEventLastSummary</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"fulfillment1/supplyEventLastSummary"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.LastDispenseInformation_2 Fulfillment1SupplyEventLastSummary {
            get { return this.fulfillment1SupplyEventLastSummary; }
            set { this.fulfillment1SupplyEventLastSummary = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060040CA.InFulfillmentOf4.supplyEventFirstSummary</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"fulfillment2/supplyEventFirstSummary"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.FirstDispenseInformation_2 Fulfillment2SupplyEventFirstSummary {
            get { return this.fulfillment2SupplyEventFirstSummary; }
            set { this.fulfillment2SupplyEventFirstSummary = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060040CA.InFulfillmentOf3.supplyEventFutureSummary</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"fulfillment3/supplyEventFutureSummary"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.RemainingDispenseInformation_2 Fulfillment3SupplyEventFutureSummary {
            get { return this.fulfillment3SupplyEventFutureSummary; }
            set { this.fulfillment3SupplyEventFutureSummary = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060040CA.InFulfillmentOf2.supplyEventPastSummary</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"fulfillment4/supplyEventPastSummary"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.PreviousDispenseInformation_2 Fulfillment4SupplyEventPastSummary {
            get { return this.fulfillment4SupplyEventPastSummary; }
            set { this.fulfillment4SupplyEventPastSummary = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060040CA.InFulfillmentOf1.deviceDispense</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"fulfillment5/deviceDispense"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.DeviceDispense_1> Fulfillment5DeviceDispense {
            get { return this.fulfillment5DeviceDispense; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060040CA.Subject3.detectedIssueEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf1/detectedIssueEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.Issues> SubjectOf1DetectedIssueEvent {
            get { return this.subjectOf1DetectedIssueEvent; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060040CA.Subject9.controlActEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2/controlActEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.StatusChanges> SubjectOf2ControlActEvent {
            get { return this.subjectOf2ControlActEvent; }
        }

        /**
         * <summary>Relationship: PORX_MT060040CA.Subject4.annotation</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf3/annotation"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged.Comment> SubjectOf3Annotation {
            get { return this.subjectOf3Annotation; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060040CA.Subject8.refusalToFill</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf4/refusalToFill"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.RefusalToFills> SubjectOf4RefusalToFill {
            get { return this.subjectOf4RefusalToFill; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060040CA.Subject2.detectedIssueIndicator</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf5/detectedIssueIndicator"})]
        public bool? SubjectOf5DetectedIssueIndicator {
            get { return this.subjectOf5DetectedIssueIndicator.Value; }
            set { this.subjectOf5DetectedIssueIndicator.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060040CA.Subject.annotationIndicator</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf6/annotationIndicator"})]
        public bool? SubjectOf6AnnotationIndicator {
            get { return this.subjectOf6AnnotationIndicator.Value; }
            set { this.subjectOf6AnnotationIndicator.Value = value; }
        }

    }

}