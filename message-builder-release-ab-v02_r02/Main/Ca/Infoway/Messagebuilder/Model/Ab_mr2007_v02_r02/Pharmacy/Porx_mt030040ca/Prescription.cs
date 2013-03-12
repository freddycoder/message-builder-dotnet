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
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Porx_mt030040ca {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt011001ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt220110ca;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Prescription</summary>
     * 
     * <p>Where the prescription is for a combination of drugs 
     * (e.g. 10mg tablets + 40mg tablets) repeatNumber cannot be 
     * populated and quantity must be expressed in mg.</p> <p>This 
     * is a 'core' class of the medication model and is important 
     * for understanding what drugs the patient is intended to be 
     * receiving.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT030040CA.CombinedMedicationRequest"})]
    public class Prescription : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.IPrescription_1 {

        private II id;
        private CD code;
        private CS statusCode;
        private SET<CV, Code> confidentialityCode;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt220110ca.DrugProduct directTargetMedication;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.HealthcareWorker responsiblePartyAssignedEntity;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.ConsentOverriddenBy author;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.PrescribedBecauseOf> reason;
        private BL preconditionVerificationEventCriterion;
        private BL derivedFromSourceDispense;
        private ST component1AdministrationInstructionsText;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.Includes component2;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.RemainingDispenseInformation fulfillment1SupplyEventFutureSummary;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.FirstDispenseInformation fulfillment2SupplyEventFirstSummary;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.LastDispenseInformation fulfillment3SupplyEventLastSummary;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.PreviousDispenseInformation fulfillment4SupplyEventPastSummary;
        private BL subjectOf1AnnotationIndicator;
        private BL subjectOf2DetectedIssueIndicator;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.RefusalToFills> subjectOf3RefusalToFill;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt011001ca.CareCompositions> componentOf1PatientCareProvisionEvent;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.Classifies componentOf2;

        public Prescription() {
            this.id = new IIImpl();
            this.code = new CDImpl();
            this.statusCode = new CSImpl();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.reason = new List<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.PrescribedBecauseOf>();
            this.preconditionVerificationEventCriterion = new BLImpl(false);
            this.derivedFromSourceDispense = new BLImpl(false);
            this.component1AdministrationInstructionsText = new STImpl();
            this.subjectOf1AnnotationIndicator = new BLImpl(false);
            this.subjectOf2DetectedIssueIndicator = new BLImpl(false);
            this.subjectOf3RefusalToFill = new List<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.RefusalToFills>();
            this.componentOf1PatientCareProvisionEvent = new List<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt011001ca.CareCompositions>();
        }
        /**
         * <summary>Business Name: A:Prescription Order Number</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT030040CA.CombinedMedicationRequest.id 
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
         * <summary>Business Name: Prescription Type</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT030040CA.CombinedMedicationRequest.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates that 
         * this is a prescription for a drug as opposed to an 
         * immunization. For SNOMED, may also contain information 
         * regarding drug and route.</p> <p>Needed to convey the 
         * meaning of this class and is therefore mandatory.</p><p>The 
         * element allows 'CD' to provide support for SNOMED.</p> 
         * <p>Needed to convey the meaning of this class and is 
         * therefore mandatory.</p><p>The element allows 'CD' to 
         * provide support for SNOMED.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActCode Code {
            get { return (ActCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: C:Prescription Status</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT030040CA.CombinedMedicationRequest.statusCode 
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
         * PORX_MT030040CA.CombinedMedicationRequest.confidentialityCode 
         * Conformance/Cardinality: REQUIRED (0-2) <p>Communicates the 
         * intent of the patient to restrict access to their 
         * prescriptions.</p><p>Provides support for additional 
         * confidentiality constraint, giving patients a level of 
         * control over their information.</p><p>Valid values are: 'N' 
         * (normal - denotes 'Not Masked'); 'R' (restricted - denotes 
         * 'Masked') and 'T' (taboo - denotes 'Patient Access 
         * Restricted').</p><p>The default is 'normal' signifying 'Not 
         * Masked'.</p> <p>Communicates the intent of the patient to 
         * restrict access to their prescriptions.</p><p>Provides 
         * support for additional confidentiality constraint, giving 
         * patients a level of control over their 
         * information.</p><p>Valid values are: 'N' (normal - denotes 
         * 'Not Masked'); 'R' (restricted - denotes 'Masked') and 'T' 
         * (taboo - denotes 'Patient Access Restricted').</p><p>The 
         * default is 'normal' signifying 'Not Masked'.</p> 
         * <p>Communicates the intent of the patient to restrict access 
         * to their prescriptions.</p><p>Provides support for 
         * additional confidentiality constraint, giving patients a 
         * level of control over their information.</p><p>Valid values 
         * are: 'N' (normal - denotes 'Not Masked'); 'R' (restricted - 
         * denotes 'Masked') and 'T' (taboo - denotes 'Patient Access 
         * Restricted').</p><p>The default is 'normal' signifying 'Not 
         * Masked'.</p> <p>Communicates the intent of the patient to 
         * restrict access to their prescriptions.</p><p>Provides 
         * support for additional confidentiality constraint, giving 
         * patients a level of control over their 
         * information.</p><p>Valid values are: 'N' (normal - denotes 
         * 'Not Masked'); 'R' (restricted - denotes 'Masked') and 'T' 
         * (taboo - denotes 'Patient Access Restricted').</p><p>The 
         * default is 'normal' signifying 'Not Masked'.</p> <p>Allows 
         * the patient to have discrete control over access to their 
         * medication data.</p><p>Taboo allows the provider to request 
         * restricted access to patient or their care 
         * giver.</p><p>Constraint: Can&#226;&#128;&#153;t have both 
         * normal and one of the other codes simultaneously.</p><p>The 
         * attribute is required because even if a jurisdiction doesn't 
         * support masking on the way in, it will need to need to 
         * communicate masked data returned from other 
         * jurisdictions.</p> <p>Allows the patient to have discrete 
         * control over access to their medication data.</p><p>Taboo 
         * allows the provider to request restricted access to patient 
         * or their care giver.</p><p>Constraint: 
         * Can&#226;&#128;&#153;t have both normal and one of the other 
         * codes simultaneously.</p><p>The attribute is required 
         * because even if a jurisdiction doesn't support masking on 
         * the way in, it will need to need to communicate masked data 
         * returned from other jurisdictions.</p> <p>Allows the patient 
         * to have discrete control over access to their medication 
         * data.</p><p>Taboo allows the provider to request restricted 
         * access to patient or their care giver.</p><p>Constraint: 
         * Can&#226;&#128;&#153;t have both normal and one of the other 
         * codes simultaneously.</p><p>The attribute is required 
         * because even if a jurisdiction doesn't support masking on 
         * the way in, it will need to need to communicate masked data 
         * returned from other jurisdictions.</p> <p>Allows the patient 
         * to have discrete control over access to their medication 
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
         * PORX_MT030040CA.DirectTarget.medication</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"directTarget/medication"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt220110ca.DrugProduct DirectTargetMedication {
            get { return this.directTargetMedication; }
            set { this.directTargetMedication = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT030040CA.ResponsibleParty.assignedEntity</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.HealthcareWorker ResponsiblePartyAssignedEntity {
            get { return this.responsiblePartyAssignedEntity; }
            set { this.responsiblePartyAssignedEntity = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT030040CA.CombinedMedicationRequest.author</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.ConsentOverriddenBy Author {
            get { return this.author; }
            set { this.author = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT030040CA.CombinedMedicationRequest.reason</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1-5)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reason"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.PrescribedBecauseOf> Reason {
            get { return this.reason; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT030040CA.Precondition.verificationEventCriterion</summary>
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
         * PORX_MT030040CA.DerivedFrom.sourceDispense</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"derivedFrom/sourceDispense"})]
        public bool? DerivedFromSourceDispense {
            get { return this.derivedFromSourceDispense.Value; }
            set { this.derivedFromSourceDispense.Value = value; }
        }

        /**
         * <summary>Business Name: Rendered Dosage Instruction</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT030040CA.AdministrationInstructions.text 
         * Conformance/Cardinality: MANDATORY (1) <p>A free form 
         * textual specification generated from the input 
         * specifications as created by the provider.</p><p>This is 
         * made up of either an 'Ad-hoc dosage instruction' or 'Textual 
         * rendition of the structured dosage lines', plus route, 
         * dosage unit, and other pertinent administration information 
         * specified by the provider.</p> <p>A free form textual 
         * specification generated from the input specifications as 
         * created by the provider.</p><p>This is made up of either an 
         * 'Ad-hoc dosage instruction' or 'Textual rendition of the 
         * structured dosage lines', plus route, dosage unit, and other 
         * pertinent administration information specified by the 
         * provider.</p> <p>Allows the provider to verify the codified 
         * structured dosage information entered and ensure that the 
         * exploded instruction is consistent with the intended 
         * instructions.</p><p>Also useful in bringing back 
         * administration instructions on query responses. Because all 
         * prescriptions and dispenses have dosage, this attribute is 
         * mandatory.</p> <p>Allows the provider to verify the codified 
         * structured dosage information entered and ensure that the 
         * exploded instruction is consistent with the intended 
         * instructions.</p><p>Also useful in bringing back 
         * administration instructions on query responses. Because all 
         * prescriptions and dispenses have dosage, this attribute is 
         * mandatory.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component1/administrationInstructions/text"})]
        public String Component1AdministrationInstructionsText {
            get { return this.component1AdministrationInstructionsText.Value; }
            set { this.component1AdministrationInstructionsText.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT030040CA.CombinedMedicationRequest.component2</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component2"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.Includes Component2 {
            get { return this.component2; }
            set { this.component2 = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT030040CA.InFulfillmentOf4.supplyEventFutureSummary</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"fulfillment1/supplyEventFutureSummary"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.RemainingDispenseInformation Fulfillment1SupplyEventFutureSummary {
            get { return this.fulfillment1SupplyEventFutureSummary; }
            set { this.fulfillment1SupplyEventFutureSummary = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT030040CA.InFulfillmentOf5.supplyEventFirstSummary</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"fulfillment2/supplyEventFirstSummary"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.FirstDispenseInformation Fulfillment2SupplyEventFirstSummary {
            get { return this.fulfillment2SupplyEventFirstSummary; }
            set { this.fulfillment2SupplyEventFirstSummary = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT030040CA.InFulfillmentOf6.supplyEventLastSummary</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"fulfillment3/supplyEventLastSummary"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.LastDispenseInformation Fulfillment3SupplyEventLastSummary {
            get { return this.fulfillment3SupplyEventLastSummary; }
            set { this.fulfillment3SupplyEventLastSummary = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT030040CA.InFulfillmentOf2.supplyEventPastSummary</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"fulfillment4/supplyEventPastSummary"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.PreviousDispenseInformation Fulfillment4SupplyEventPastSummary {
            get { return this.fulfillment4SupplyEventPastSummary; }
            set { this.fulfillment4SupplyEventPastSummary = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT030040CA.Subject.annotationIndicator</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf1/annotationIndicator"})]
        public bool? SubjectOf1AnnotationIndicator {
            get { return this.subjectOf1AnnotationIndicator.Value; }
            set { this.subjectOf1AnnotationIndicator.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT030040CA.Subject2.detectedIssueIndicator</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2/detectedIssueIndicator"})]
        public bool? SubjectOf2DetectedIssueIndicator {
            get { return this.subjectOf2DetectedIssueIndicator.Value; }
            set { this.subjectOf2DetectedIssueIndicator.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT030040CA.Subject3.refusalToFill</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf3/refusalToFill"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.RefusalToFills> SubjectOf3RefusalToFill {
            get { return this.subjectOf3RefusalToFill; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT030040CA.Component.patientCareProvisionEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"componentOf1/patientCareProvisionEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt011001ca.CareCompositions> ComponentOf1PatientCareProvisionEvent {
            get { return this.componentOf1PatientCareProvisionEvent; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT030040CA.CombinedMedicationRequest.componentOf2</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"componentOf2"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.Classifies ComponentOf2 {
            get { return this.componentOf2; }
            set { this.componentOf2 = value; }
        }

    }

}