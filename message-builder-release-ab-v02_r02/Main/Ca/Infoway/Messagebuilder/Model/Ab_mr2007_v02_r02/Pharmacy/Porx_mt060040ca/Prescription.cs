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
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Porx_mt060040ca {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt011001ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt141007ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt120600ca;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Prescription</summary>
     * 
     * <p>Reported Issue is only permitted if Issue Indicator is 
     * not present and vice versa.</p><p>Annotation is only 
     * permitted if Annotation Indicator is not present and vice 
     * versa</p> <p>Reported Issue is only permitted if Issue 
     * Indicator is not present and vice versa.</p><p>Annotation is 
     * only permitted if Annotation Indicator is not present and 
     * vice versa</p> <p>Information pertaining to a Prescriber's 
     * authorization for a device to be dispensed to a patient, as 
     * well as the instruction on when and how the device is to be 
     * used by the patient.</p> <p>This is a 'core' class of the 
     * medication model and is important for understanding what 
     * devices the patient is intended to be receiving.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060040CA.DeviceRequest"})]
    public class Prescription : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.IPrescription_1 {

        private II id;
        private CS statusCode;
        private SET<CV, Code> confidentialityCode;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt141007ca.DeviceProduct directTargetManufacturedProduct;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.HealthcareWorker responsiblePartyAssignedEntity;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.Author4 author;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.CreatedAt location;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.ParentPrescription predecessorPriorSupplyRequest;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.PrescribedBecauseOf> reason;
        private BL preconditionVerificationEventCriterion;
        private BL derivedFromSourceDispense;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.CoverageExtensions> coverageCoverage;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.ProcedureRequest component1ProcedureRequest;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.DispenseInstructions_1 component2SupplyRequest;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.LastDispenseInformation fulfillment1SupplyEventLastSummary;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.FirstDispenseInformation fulfillment2SupplyEventFirstSummary;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.RemainingDispenseInformation fulfillment3SupplyEventFutureSummary;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.PreviousDispenseInformation fulfillment4SupplyEventPastSummary;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.PrescriptionDispenses> fulfillment5DeviceDispense;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.Issues> subjectOf1DetectedIssueEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.DispenseStatusChanges> subjectOf2ControlActEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt120600ca.Notes> subjectOf3Annotation;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.RefusalToFills> subjectOf4RefusalToFill;
        private BL subjectOf5DetectedIssueIndicator;
        private BL subjectOf6AnnotationIndicator;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt011001ca.CareCompositions> componentOfPatientCareProvisionEvent;

        public Prescription() {
            this.id = new IIImpl();
            this.statusCode = new CSImpl();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.reason = new List<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.PrescribedBecauseOf>();
            this.preconditionVerificationEventCriterion = new BLImpl(false);
            this.derivedFromSourceDispense = new BLImpl(false);
            this.coverageCoverage = new List<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.CoverageExtensions>();
            this.fulfillment5DeviceDispense = new List<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.PrescriptionDispenses>();
            this.subjectOf1DetectedIssueEvent = new List<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.Issues>();
            this.subjectOf2ControlActEvent = new List<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.DispenseStatusChanges>();
            this.subjectOf3Annotation = new List<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt120600ca.Notes>();
            this.subjectOf4RefusalToFill = new List<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.RefusalToFills>();
            this.subjectOf5DetectedIssueIndicator = new BLImpl(false);
            this.subjectOf6AnnotationIndicator = new BLImpl(false);
            this.componentOfPatientCareProvisionEvent = new List<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt011001ca.CareCompositions>();
        }
        /**
         * <summary>Business Name: A:Prescription Order Number</summary>
         * 
         * <remarks>Relationship: PORX_MT060040CA.DeviceRequest.id 
         * Conformance/Cardinality: MANDATORY (1) <p>The Prescription 
         * Order Number is a globally unique number assigned to a 
         * prescription by the EHR/DIS irrespective of the source of 
         * the order</p><p>It is created by the EHR/DIS once the 
         * prescription has passed all edits and validation.</p> <p>The 
         * Prescription Order Number is a globally unique number 
         * assigned to a prescription by the EHR/DIS irrespective of 
         * the source of the order</p><p>It is created by the EHR/DIS 
         * once the prescription has passed all edits and 
         * validation.</p> <p>Allows prescriptions to be uniquely 
         * referenced.</p><p>The number is mandatory to allow every 
         * prescription record to be uniquely identified.</p> <p>Allows 
         * prescriptions to be uniquely referenced.</p><p>The number is 
         * mandatory to allow every prescription record to be uniquely 
         * identified.</p></remarks>
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
         * Conformance/Cardinality: MANDATORY (1) <p>This denotes the 
         * state of the prescription in the lifecycle of the 
         * prescription. Valid statuses are: NEW, ACTIVE, SUSPENDED, 
         * ABORTED, COMPLETED, OBSOLETE and NULLIFIED.</p> <p>Indicates 
         * what actions are allowed to be performed against a 
         * prescription.</p><p>This is a mandatory field because every 
         * prescription needs to be in some state.</p> <p>Indicates 
         * what actions are allowed to be performed against a 
         * prescription.</p><p>This is a mandatory field because every 
         * prescription needs to be in some state.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: F:Prescription Masking Indicators</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060040CA.DeviceRequest.confidentialityCode 
         * Conformance/Cardinality: REQUIRED (0-2) <p>Communicates the 
         * intent of the patient to restrict access to their 
         * prescriptions.</p><p>Provides support for additional 
         * confidentiality constraint, giving patients a level of 
         * control over their information.</p><p>Allows a provider ro 
         * request restricted access by the patient.</p><p>Valid values 
         * are: 'N' (normal - denotes 'Not Masked'); 'R' (restricted - 
         * denotes 'Masked') and 'T' (taboo - denotes 'Patient Access 
         * Restricted').</p><p>The default is 'normal' signifying 'Not 
         * Masked'.</p> <p>Communicates the intent of the patient to 
         * restrict access to their prescriptions.</p><p>Provides 
         * support for additional confidentiality constraint, giving 
         * patients a level of control over their 
         * information.</p><p>Allows a provider ro request restricted 
         * access by the patient.</p><p>Valid values are: 'N' (normal - 
         * denotes 'Not Masked'); 'R' (restricted - denotes 'Masked') 
         * and 'T' (taboo - denotes 'Patient Access 
         * Restricted').</p><p>The default is 'normal' signifying 'Not 
         * Masked'.</p> <p>Communicates the intent of the patient to 
         * restrict access to their prescriptions.</p><p>Provides 
         * support for additional confidentiality constraint, giving 
         * patients a level of control over their 
         * information.</p><p>Allows a provider ro request restricted 
         * access by the patient.</p><p>Valid values are: 'N' (normal - 
         * denotes 'Not Masked'); 'R' (restricted - denotes 'Masked') 
         * and 'T' (taboo - denotes 'Patient Access 
         * Restricted').</p><p>The default is 'normal' signifying 'Not 
         * Masked'.</p> <p>Communicates the intent of the patient to 
         * restrict access to their prescriptions.</p><p>Provides 
         * support for additional confidentiality constraint, giving 
         * patients a level of control over their 
         * information.</p><p>Allows a provider ro request restricted 
         * access by the patient.</p><p>Valid values are: 'N' (normal - 
         * denotes 'Not Masked'); 'R' (restricted - denotes 'Masked') 
         * and 'T' (taboo - denotes 'Patient Access 
         * Restricted').</p><p>The default is 'normal' signifying 'Not 
         * Masked'.</p> <p>Communicates the intent of the patient to 
         * restrict access to their prescriptions.</p><p>Provides 
         * support for additional confidentiality constraint, giving 
         * patients a level of control over their 
         * information.</p><p>Allows a provider ro request restricted 
         * access by the patient.</p><p>Valid values are: 'N' (normal - 
         * denotes 'Not Masked'); 'R' (restricted - denotes 'Masked') 
         * and 'T' (taboo - denotes 'Patient Access 
         * Restricted').</p><p>The default is 'normal' signifying 'Not 
         * Masked'.</p> <p>Allows the patient to have discrete control 
         * over access to their prescription data.</p><p>Taboo allows 
         * the provider to request restricted access to patient or 
         * their care giver.</p><p>Constraint: Can&#226;&#128;&#153;t 
         * have both normal and one of the other codes 
         * simultaneously.</p><p>The attribute is required because even 
         * if a jurisdiction doesn't support masking on the way in, it 
         * will need to need to communicate masked data returned from 
         * other jurisdictions.</p> <p>Allows the patient to have 
         * discrete control over access to their prescription 
         * data.</p><p>Taboo allows the provider to request restricted 
         * access to patient or their care giver.</p><p>Constraint: 
         * Can&#226;&#128;&#153;t have both normal and one of the other 
         * codes simultaneously.</p><p>The attribute is required 
         * because even if a jurisdiction doesn't support masking on 
         * the way in, it will need to need to communicate masked data 
         * returned from other jurisdictions.</p> <p>Allows the patient 
         * to have discrete control over access to their prescription 
         * data.</p><p>Taboo allows the provider to request restricted 
         * access to patient or their care giver.</p><p>Constraint: 
         * Can&#226;&#128;&#153;t have both normal and one of the other 
         * codes simultaneously.</p><p>The attribute is required 
         * because even if a jurisdiction doesn't support masking on 
         * the way in, it will need to need to communicate masked data 
         * returned from other jurisdictions.</p> <p>Allows the patient 
         * to have discrete control over access to their prescription 
         * data.</p><p>Taboo allows the provider to request restricted 
         * access to patient or their care giver.</p><p>Constraint: 
         * Can&#226;&#128;&#153;t have both normal and one of the other 
         * codes simultaneously.</p><p>The attribute is required 
         * because even if a jurisdiction doesn't support masking on 
         * the way in, it will need to need to communicate masked data 
         * returned from other jurisdictions.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_NormalRestrictedTabooConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_NormalRestrictedTabooConfidentialityKind>(); }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060040CA.DirectTarget.manufacturedProduct</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"directTarget/manufacturedProduct"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt141007ca.DeviceProduct DirectTargetManufacturedProduct {
            get { return this.directTargetManufacturedProduct; }
            set { this.directTargetManufacturedProduct = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060040CA.ResponsibleParty2.assignedEntity</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.HealthcareWorker ResponsiblePartyAssignedEntity {
            get { return this.responsiblePartyAssignedEntity; }
            set { this.responsiblePartyAssignedEntity = value; }
        }

        /**
         * <summary>Relationship: PORX_MT060040CA.DeviceRequest.author</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.Author4 Author {
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
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.CreatedAt Location {
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
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.ParentPrescription PredecessorPriorSupplyRequest {
            get { return this.predecessorPriorSupplyRequest; }
            set { this.predecessorPriorSupplyRequest = value; }
        }

        /**
         * <summary>Relationship: PORX_MT060040CA.DeviceRequest.reason</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1-5)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reason"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.PrescribedBecauseOf> Reason {
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
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.CoverageExtensions> CoverageCoverage {
            get { return this.coverageCoverage; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060040CA.Component1.procedureRequest</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component1/procedureRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.ProcedureRequest Component1ProcedureRequest {
            get { return this.component1ProcedureRequest; }
            set { this.component1ProcedureRequest = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060040CA.Component6.supplyRequest</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component2/supplyRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.DispenseInstructions_1 Component2SupplyRequest {
            get { return this.component2SupplyRequest; }
            set { this.component2SupplyRequest = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060040CA.InFulfillmentOf5.supplyEventLastSummary</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"fulfillment1/supplyEventLastSummary"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.LastDispenseInformation Fulfillment1SupplyEventLastSummary {
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
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.FirstDispenseInformation Fulfillment2SupplyEventFirstSummary {
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
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.RemainingDispenseInformation Fulfillment3SupplyEventFutureSummary {
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
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.PreviousDispenseInformation Fulfillment4SupplyEventPastSummary {
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
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.PrescriptionDispenses> Fulfillment5DeviceDispense {
            get { return this.fulfillment5DeviceDispense; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060040CA.Subject3.detectedIssueEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf1/detectedIssueEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.Issues> SubjectOf1DetectedIssueEvent {
            get { return this.subjectOf1DetectedIssueEvent; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060040CA.Subject9.controlActEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2/controlActEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.DispenseStatusChanges> SubjectOf2ControlActEvent {
            get { return this.subjectOf2ControlActEvent; }
        }

        /**
         * <summary>Relationship: PORX_MT060040CA.Subject4.annotation</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf3/annotation"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt120600ca.Notes> SubjectOf3Annotation {
            get { return this.subjectOf3Annotation; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060040CA.Subject8.refusalToFill</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf4/refusalToFill"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.RefusalToFills> SubjectOf4RefusalToFill {
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

        /**
         * <summary>Relationship: 
         * PORX_MT060040CA.Component2.patientCareProvisionEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"componentOf/patientCareProvisionEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt011001ca.CareCompositions> ComponentOfPatientCareProvisionEvent {
            get { return this.componentOfPatientCareProvisionEvent; }
        }

    }

}