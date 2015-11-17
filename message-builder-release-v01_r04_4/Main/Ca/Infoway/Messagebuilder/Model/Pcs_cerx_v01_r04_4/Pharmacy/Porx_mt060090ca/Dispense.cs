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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Porx_mt060090ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt090107ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt120600ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Porx_mt980030ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Porx_mt980040ca;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Dispense</summary>
     * 
     * <p>Reported Issue is only permitted if Issue Indicator is 
     * not present</p> <p>Annotation is only permitted if 
     * Annotation Indicator is not present</p> <p>This is a 'core' 
     * class of the medication model and is important for 
     * understanding what drugs the patient is actually 
     * receiving.</p> <p>Describes the issuing of a drug in 
     * response to an authorizing prescription.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060090CA.MedicationDispense"})]
    public class Dispense : MessagePartBean {

        private II id;
        private CS statusCode;
        private CV confidentialityCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt090107ca.Provider responsiblePartyAssignedPerson;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt090107ca.Provider performerAssignedPerson;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Merged.RecordedAt location;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.PrescriptionReference inFulfillmentOfSubstanceAdministrationRequest;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Porx_mt980040ca.AdministrationInstructions> component1DosageInstruction;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.Substitution component2SubstitutionMade;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.SupplyEvent component3SupplyEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.StatusChanges> subjectOf1ControlActEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Porx_mt980030ca.Issues> subjectOf2DetectedIssueEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt120600ca.Notes> subjectOf3Annotation;
        private BL subjectOf4DetectedIssueIndicator;
        private BL subjectOf5AnnotationIndicator;

        public Dispense() {
            this.id = new IIImpl();
            this.statusCode = new CSImpl();
            this.confidentialityCode = new CVImpl();
            this.component1DosageInstruction = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Porx_mt980040ca.AdministrationInstructions>();
            this.subjectOf1ControlActEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.StatusChanges>();
            this.subjectOf2DetectedIssueEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Porx_mt980030ca.Issues>();
            this.subjectOf3Annotation = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt120600ca.Notes>();
            this.subjectOf4DetectedIssueIndicator = new BLImpl(false);
            this.subjectOf5AnnotationIndicator = new BLImpl(false);
        }
        /**
         * <summary>Business Name: A:Prescription Dispense Number</summary>
         * 
         * <remarks>Relationship: PORX_MT060090CA.MedicationDispense.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for the 
         * referencing of a specific dispense record.</p><p>Identifier 
         * for a dispensed record is needed so that dispenses may be 
         * uniquely referenced. Thus the mandatory requirement.</p> 
         * <p>The Prescription Dispense Number is a globally unique 
         * number assigned to a dispense (single fill) by the EHR/DIS 
         * irrespective of the source of the dispense.</p><p>It is 
         * created by the EHR/DIS once the dispense has passed all 
         * edits and validation.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: C:Dispense Status</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060090CA.MedicationDispense.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Important in 
         * understanding what medication the patient actually has on 
         * hand, thus the attribute is mandatory. May also influence 
         * the ability of a different pharmacy to dispense the 
         * medication.</p> <p>Indicates the status of the dispense 
         * record created on the EHR/DIS. If 'Active' it means that the 
         * dispense has been processed but not yet given to the 
         * patient. If 'Complete', it indicates that the medication has 
         * been delivered to the patient.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: E:Prescription Masking Indicator</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060090CA.MedicationDispense.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public x_VeryBasicConfidentialityKind ConfidentialityCode {
            get { return (x_VeryBasicConfidentialityKind) this.confidentialityCode.Value; }
            set { this.confidentialityCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060090CA.ResponsibleParty2.assignedPerson</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/assignedPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt090107ca.Provider ResponsiblePartyAssignedPerson {
            get { return this.responsiblePartyAssignedPerson; }
            set { this.responsiblePartyAssignedPerson = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060090CA.Performer3.assignedPerson</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"performer/assignedPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt090107ca.Provider PerformerAssignedPerson {
            get { return this.performerAssignedPerson; }
            set { this.performerAssignedPerson = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060090CA.MedicationDispense.location</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Merged.RecordedAt Location {
            get { return this.location; }
            set { this.location = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060090CA.InFulfillmentOf.substanceAdministrationRequest</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"inFulfillmentOf/substanceAdministrationRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.PrescriptionReference InFulfillmentOfSubstanceAdministrationRequest {
            get { return this.inFulfillmentOfSubstanceAdministrationRequest; }
            set { this.inFulfillmentOfSubstanceAdministrationRequest = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060090CA.Component11.dosageInstruction</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component1/dosageInstruction"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Porx_mt980040ca.AdministrationInstructions> Component1DosageInstruction {
            get { return this.component1DosageInstruction; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060090CA.Component13.substitutionMade</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component2/substitutionMade"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.Substitution Component2SubstitutionMade {
            get { return this.component2SubstitutionMade; }
            set { this.component2SubstitutionMade = value; }
        }

        /**
         * <summary>Relationship: PORX_MT060090CA.Component.supplyEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component3/supplyEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.SupplyEvent Component3SupplyEvent {
            get { return this.component3SupplyEvent; }
            set { this.component3SupplyEvent = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060090CA.Subject.controlActEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf1/controlActEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.StatusChanges> SubjectOf1ControlActEvent {
            get { return this.subjectOf1ControlActEvent; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060090CA.Subject6.detectedIssueEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2/detectedIssueEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Porx_mt980030ca.Issues> SubjectOf2DetectedIssueEvent {
            get { return this.subjectOf2DetectedIssueEvent; }
        }

        /**
         * <summary>Relationship: PORX_MT060090CA.Subject7.annotation</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf3/annotation"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt120600ca.Notes> SubjectOf3Annotation {
            get { return this.subjectOf3Annotation; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060090CA.Subject13.detectedIssueIndicator</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf4/detectedIssueIndicator"})]
        public bool? SubjectOf4DetectedIssueIndicator {
            get { return this.subjectOf4DetectedIssueIndicator.Value; }
            set { this.subjectOf4DetectedIssueIndicator.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060090CA.Subject12.annotationIndicator</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf5/annotationIndicator"})]
        public bool? SubjectOf5AnnotationIndicator {
            get { return this.subjectOf5AnnotationIndicator.Value; }
            set { this.subjectOf5AnnotationIndicator.Value = value; }
        }

    }

}