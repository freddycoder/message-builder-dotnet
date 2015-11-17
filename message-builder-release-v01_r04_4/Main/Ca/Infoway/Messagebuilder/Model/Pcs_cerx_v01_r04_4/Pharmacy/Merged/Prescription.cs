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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt050203ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt090107ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt220110ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Prescription</summary>
     * 
     * <remarks>PORX_MT060190CA.CombinedMedicationRequest: 
     * Prescription <p>This is a 'core' class of the medication 
     * model and is important for understanding what drugs the 
     * patient is intended to be receiving.</p> <p>Where the 
     * prescription is for a combination of drugs (e.g. 10mg 
     * tablets + 40mg tablets) repeatNumber cannot be populated and 
     * quantity must be expressed in mg.</p> <p>Information 
     * pertaining to a Prescriber's authorization for a drug to be 
     * dispensed to a patient, as well as the instruction on when 
     * and how the drug is to be administered to the patient.</p> 
     * PORX_MT060100CA.SubstanceAdministrationRequest: Prescription 
     * <p>Provides a drill-down link from the prescription to its 
     * corresponding order.</p> <p>Indicates the order being 
     * dispensed</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060100CA.SubstanceAdministrationRequest","PORX_MT060190CA.CombinedMedicationRequest"})]
    public class Prescription : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Porx_mt060190ca.IMedicationRecord {

        private II id;
        private CD code;
        private CS statusCode;
        private CV confidentialityCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt050203ca.Patient subjectPatient;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt220110ca.DrugProduct directTargetMedication;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt090107ca.Provider responsiblePartyAssignedPerson;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Merged.PrescribedBy author;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Merged.RecordedAt location;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.PrescribedBecauseOf> reason;
        private BL preconditionVerificationEventCriterion;
        private BL derivedFromSourceDispense;
        private ST component1AdministrationInstructionsText;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.Component2 component2;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.RemainingDispenseInformation_1 fulfillment1SupplyEventFutureSummary;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.FirstDispenseInformation_1 fulfillment2SupplyEventFirstSummary;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.LastDispenseInformation_1 fulfillment3SupplyEventLastSummary;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.PreviousDispenseInformation_1 fulfillment4SupplyEventPastSummary;
        private BL subjectOf1AnnotationIndicator;
        private BL subjectOf2DetectedIssueIndicator;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.RefusalToFills> subjectOf3RefusalToFill;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.Classifies componentOf;

        public Prescription() {
            this.id = new IIImpl();
            this.code = new CDImpl();
            this.statusCode = new CSImpl();
            this.confidentialityCode = new CVImpl();
            this.reason = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.PrescribedBecauseOf>();
            this.preconditionVerificationEventCriterion = new BLImpl(false);
            this.derivedFromSourceDispense = new BLImpl(false);
            this.component1AdministrationInstructionsText = new STImpl();
            this.subjectOf1AnnotationIndicator = new BLImpl(false);
            this.subjectOf2DetectedIssueIndicator = new BLImpl(false);
            this.subjectOf3RefusalToFill = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.RefusalToFills>();
        }
        /**
         * <summary>Un-merged Business Name: PrescriptionOrderNumber</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060190CA.CombinedMedicationRequest.id 
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
         * edits and validation.</p> Un-merged Business Name: 
         * PrescriptionIdentifier Relationship: 
         * PORX_MT060100CA.SubstanceAdministrationRequest.id 
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
         * <p>Links the dispense to the prescription it fulfilled.</p> 
         * <p>The Prescription Order Number is a globally unique number 
         * assigned to a prescription by the EHR/DIS irrespective of 
         * the source of the order</p><p>It is created by the EHR/DIS 
         * once the prescription has passed all edits and 
         * validation.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: PrescriptionType</summary>
         * 
         * <remarks>Un-merged Business Name: PrescriptionType 
         * Relationship: PORX_MT060190CA.CombinedMedicationRequest.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Needed to convey 
         * the meaning of this class and is therefore 
         * mandatory.</p><p>The element allows 'CD' to provide support 
         * for SNOMED.</p> <p>Indicates that this is a prescription for 
         * a drug as opposed to an immunization. For SNOMED, may also 
         * contain information regarding drug and route.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActCode Code {
            get { return (ActCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: PrescriptionStatus</summary>
         * 
         * <remarks>Un-merged Business Name: PrescriptionStatus 
         * Relationship: 
         * PORX_MT060190CA.CombinedMedicationRequest.statusCode 
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
         * <summary>Business Name: PrescriptionMaskingIndicator</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * PrescriptionMaskingIndicator Relationship: 
         * PORX_MT060190CA.CombinedMedicationRequest.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-1) 
         * <p>Prescription.masked</p> <p>Allows the patient to have 
         * discrete control over access to their medication 
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
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: PORX_MT060190CA.Subject5.patient 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject/patient"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt050203ca.Patient SubjectPatient {
            get { return this.subjectPatient; }
            set { this.subjectPatient = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060190CA.DirectTarget.medication 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"directTarget/medication"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt220110ca.DrugProduct DirectTargetMedication {
            get { return this.directTargetMedication; }
            set { this.directTargetMedication = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060190CA.ResponsibleParty.assignedPerson 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060100CA.ResponsibleParty2.assignedPerson 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/assignedPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt090107ca.Provider ResponsiblePartyAssignedPerson {
            get { return this.responsiblePartyAssignedPerson; }
            set { this.responsiblePartyAssignedPerson = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060190CA.CombinedMedicationRequest.author 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060100CA.SubstanceAdministrationRequest.author 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Merged.PrescribedBy Author {
            get { return this.author; }
            set { this.author = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060190CA.CombinedMedicationRequest.location 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Merged.RecordedAt Location {
            get { return this.location; }
            set { this.location = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060190CA.CombinedMedicationRequest.reason 
         * Conformance/Cardinality: REQUIRED (1-5)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reason"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.PrescribedBecauseOf> Reason {
            get { return this.reason; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060190CA.Precondition.verificationEventCriterion 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"precondition/verificationEventCriterion"})]
        public bool? PreconditionVerificationEventCriterion {
            get { return this.preconditionVerificationEventCriterion.Value; }
            set { this.preconditionVerificationEventCriterion.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060190CA.DerivedFrom.sourceDispense 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"derivedFrom/sourceDispense"})]
        public bool? DerivedFromSourceDispense {
            get { return this.derivedFromSourceDispense.Value; }
            set { this.derivedFromSourceDispense.Value = value; }
        }

        /**
         * <summary>Business Name: RenderedDosageInstruction</summary>
         * 
         * <remarks>Un-merged Business Name: RenderedDosageInstruction 
         * Relationship: 
         * PORX_MT060190CA.AdministrationInstructions.text 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows the 
         * prescriber to verify the structured dosage 
         * instruction.</p><p>Attribute is marked as 
         * &quot;mandatory&quot; as the rendition of the dosage 
         * instruction must always be made available to the 
         * prescriber.</p> <p>A textual rendition of structured (or 
         * non-structure) original dosage instruction specified by the 
         * prescriber.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component1/administrationInstructions/text"})]
        public String Component1AdministrationInstructionsText {
            get { return this.component1AdministrationInstructionsText.Value; }
            set { this.component1AdministrationInstructionsText.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060190CA.CombinedMedicationRequest.component2 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component2"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.Component2 Component2 {
            get { return this.component2; }
            set { this.component2 = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060190CA.InFulfillmentOf4.supplyEventFutureSummary 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"fulfillment1/supplyEventFutureSummary"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.RemainingDispenseInformation_1 Fulfillment1SupplyEventFutureSummary {
            get { return this.fulfillment1SupplyEventFutureSummary; }
            set { this.fulfillment1SupplyEventFutureSummary = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060190CA.InFulfillmentOf5.supplyEventFirstSummary 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"fulfillment2/supplyEventFirstSummary"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.FirstDispenseInformation_1 Fulfillment2SupplyEventFirstSummary {
            get { return this.fulfillment2SupplyEventFirstSummary; }
            set { this.fulfillment2SupplyEventFirstSummary = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060190CA.InFulfillmentOf6.supplyEventLastSummary 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"fulfillment3/supplyEventLastSummary"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.LastDispenseInformation_1 Fulfillment3SupplyEventLastSummary {
            get { return this.fulfillment3SupplyEventLastSummary; }
            set { this.fulfillment3SupplyEventLastSummary = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060190CA.InFulfillmentOf2.supplyEventPastSummary 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"fulfillment4/supplyEventPastSummary"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.PreviousDispenseInformation_1 Fulfillment4SupplyEventPastSummary {
            get { return this.fulfillment4SupplyEventPastSummary; }
            set { this.fulfillment4SupplyEventPastSummary = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060190CA.Subject.annotationIndicator 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf1/annotationIndicator"})]
        public bool? SubjectOf1AnnotationIndicator {
            get { return this.subjectOf1AnnotationIndicator.Value; }
            set { this.subjectOf1AnnotationIndicator.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060190CA.Subject2.detectedIssueIndicator 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2/detectedIssueIndicator"})]
        public bool? SubjectOf2DetectedIssueIndicator {
            get { return this.subjectOf2DetectedIssueIndicator.Value; }
            set { this.subjectOf2DetectedIssueIndicator.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060190CA.Subject3.refusalToFill 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf3/refusalToFill"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.RefusalToFills> SubjectOf3RefusalToFill {
            get { return this.subjectOf3RefusalToFill; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060190CA.CombinedMedicationRequest.componentOf 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"componentOf"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.Classifies ComponentOf {
            get { return this.componentOf; }
            set { this.componentOf = value; }
        }

    }

}