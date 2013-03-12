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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Pharmacy.Merged {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt050303ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>PORX_MT020060CA.DeviceDispense: Prescription 
     * Dispense</summary>
     * 
     * <p>Dispensing is an integral part of the overall 
     * prescription process.</p> <p>This is the detailed 
     * information about a device dispense that has been performed 
     * on behalf a patient</p> PORX_MT060020CA.DeviceDispense: 
     * Dispense <p>Communicates an overview of a patient's 
     * dispenses.</p> <p>Represents the dispensing of a device to a 
     * patient.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT020060CA.DeviceDispense","PORX_MT060020CA.DeviceDispense"})]
    public class PrescriptionDispense : MessagePartBean {

        private II id;
        private SET<CV, Code> confidentialityCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt050303ca.AnimalPatient subjectPatient;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Pharmacy.Merged.PrescriptionReference inFulfillmentOfDeviceRequest;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Pharmacy.Merged.ProcedureRequest component1ProcedureRequest;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Pharmacy.Merged.DispenseDetails componentSupplyEvent;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.Includes subjectOf;
        private CS statusCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.HealthcareWorker responsiblePartyAssignedEntity;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.HealthcareWorker performerAssignedEntity;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.OccurredAt location;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Pharmacy.Merged.SupplyOrder fulfillmentSupplyRequest;
        private BL subjectOf1DetectedIssueIndicator;
        private BL subjectOf2AnnotationIndicator;

        public PrescriptionDispense() {
            this.id = new IIImpl();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.statusCode = new CSImpl();
            this.subjectOf1DetectedIssueIndicator = new BLImpl(false);
            this.subjectOf2AnnotationIndicator = new BLImpl(false);
        }
        /**
         * <summary>Business Name: PrescriptionDispenseNumber</summary>
         * 
         * <remarks>Un-merged Business Name: PrescriptionDispenseNumber 
         * Relationship: PORX_MT020060CA.DeviceDispense.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows formal 
         * tracking of centrally recorded dispenses to local records 
         * for audit and related purposes.</p> <p>Identifier assigned 
         * by the dispensing facility.</p> Un-merged Business Name: 
         * PrescriptionDispenseNumber Relationship: 
         * PORX_MT060020CA.DeviceDispense.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Allows for the referencing of a specific 
         * dispense record.</p><p>Identifier for a dispensed record is 
         * needed so that dispenses may be uniquely referenced. Thus 
         * the mandatory requirement.</p> <p>The Prescription Dispense 
         * Number is a globally unique number assigned to a dispense 
         * (single fill) by the EHR/DIS irrespective of the source of 
         * the dispense.</p><p>It is created by the EHR/DIS once the 
         * dispense has passed all edits and validation.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: PrescriptionMaskingIndicators</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * PrescriptionMaskingIndicators Relationship: 
         * PORX_MT020060CA.DeviceDispense.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-2) <p>Can be used to 
         * set a mask for a new dispense, if present in a new dispense 
         * request.</p><p>Allows the patient to have discrete control 
         * over access to their prescription data.</p><p>Taboo allows 
         * the provider to request restricted access to patient or 
         * their care giver.</p><p>Constraint: Cant have both normal 
         * and one of the other codes simultaneously.</p><p>The 
         * attribute is optional because not all systems will support 
         * masking.</p> <p>If a dispense is masked, it implicitly masks 
         * the prescription being dispensed. (There's no point in 
         * masking a dispense if the prescription is unmasked.)</p> 
         * <p>Communicates the intent that the dispense should be 
         * masked if it is created; If the dispense is masked, this 
         * makes the complete prescription and all dispenses 
         * masked.</p><p>Communicates the intent of the patient to 
         * restrict access to their prescriptions.</p><p>Provides 
         * support for additional confidentiality constraint, giving 
         * patients a level of control over their 
         * information.</p><p>Valid values are: 'N' (normal - denotes 
         * 'Not Masked'); 'R' (restricted - denotes 'Masked'); 'V' 
         * (very restricted - denotes very restricted access as 
         * declared by the Privacy Officer of the record holder) and 
         * 'T' (taboo - denotes 'Patient Access Restricted').</p><p>The 
         * default is 'normal' signifying 'Not Masked'.</p> Un-merged 
         * Business Name: PrescriptionMaskingIndicators Relationship: 
         * PORX_MT060020CA.DeviceDispense.confidentialityCode 
         * Conformance/Cardinality: REQUIRED (0-2) <p>Allows the 
         * patient to have discrete control over access to their 
         * medication data.</p><p>Taboo allows the provider to request 
         * restricted access to patient or their care 
         * giver.</p><p>Constraint: Cant have both normal and one of 
         * the other codes simultaneously.</p><p>The attribute is 
         * required because even if a jurisdiction doesn't support 
         * masking on the way in, it will need to need to communicate 
         * masked data returned from other jurisdictions.</p> 
         * <p>Communicates the intent of the patient to restrict access 
         * to their prescriptions.</p><p>Provides support for 
         * additional confidentiality constraint, giving patients a 
         * level of control over their information.</p><p>Allows 
         * providers to request restricted access by 
         * patients.</p><p>Valid values are: 'N' (normal - denotes 'Not 
         * Masked'); 'R' (restricted - denotes 'Masked'); 'V' (very 
         * restricted - denotes very restricted access as declared by 
         * the Privacy Officer of the record holder) and 'T' (taboo - 
         * denotes 'Patient Access Restricted').</p><p>The default is 
         * 'normal' signifying 'Not Masked'.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_BasicConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_BasicConfidentialityKind>(); }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: PORX_MT020060CA.Subject8.patient 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject/patient"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt050303ca.AnimalPatient SubjectPatient {
            get { return this.subjectPatient; }
            set { this.subjectPatient = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT020060CA.InFulfillmentOf1.deviceRequest 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"inFulfillmentOf/deviceRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Pharmacy.Merged.PrescriptionReference InFulfillmentOfDeviceRequest {
            get { return this.inFulfillmentOfDeviceRequest; }
            set { this.inFulfillmentOfDeviceRequest = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT020060CA.Component11.procedureRequest 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component1/procedureRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Pharmacy.Merged.ProcedureRequest Component1ProcedureRequest {
            get { return this.component1ProcedureRequest; }
            set { this.component1ProcedureRequest = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: PORX_MT020060CA.Component.supplyEvent 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060020CA.Component2.supplyEvent 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component/supplyEvent","component2/supplyEvent"})]
        [Hl7MapByPartType(Name="component", Type="PORX_MT060020CA.Component2")]
        [Hl7MapByPartType(Name="component/supplyEvent", Type="PORX_MT060020CA.SupplyEvent")]
        [Hl7MapByPartType(Name="component2", Type="PORX_MT020060CA.Component")]
        [Hl7MapByPartType(Name="component2/supplyEvent", Type="PORX_MT020060CA.SupplyEvent")]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Pharmacy.Merged.DispenseDetails ComponentSupplyEvent {
            get { return this.componentSupplyEvent; }
            set { this.componentSupplyEvent = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT020060CA.DeviceDispense.subjectOf 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.Includes SubjectOf {
            get { return this.subjectOf; }
            set { this.subjectOf = value; }
        }

        /**
         * <summary>Business Name: DispenseStatus</summary>
         * 
         * <remarks>Un-merged Business Name: DispenseStatus 
         * Relationship: PORX_MT060020CA.DeviceDispense.statusCode 
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
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060020CA.ResponsibleParty.assignedEntity 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.HealthcareWorker ResponsiblePartyAssignedEntity {
            get { return this.responsiblePartyAssignedEntity; }
            set { this.responsiblePartyAssignedEntity = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060020CA.Performer.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"performer/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.HealthcareWorker PerformerAssignedEntity {
            get { return this.performerAssignedEntity; }
            set { this.performerAssignedEntity = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060020CA.DeviceDispense.location 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.OccurredAt Location {
            get { return this.location; }
            set { this.location = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060020CA.InFulfillmentOf.supplyRequest 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"fulfillment/supplyRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Pharmacy.Merged.SupplyOrder FulfillmentSupplyRequest {
            get { return this.fulfillmentSupplyRequest; }
            set { this.fulfillmentSupplyRequest = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060020CA.Subject4.detectedIssueIndicator 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf1/detectedIssueIndicator"})]
        public bool? SubjectOf1DetectedIssueIndicator {
            get { return this.subjectOf1DetectedIssueIndicator.Value; }
            set { this.subjectOf1DetectedIssueIndicator.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060020CA.Subject3.annotationIndicator 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2/annotationIndicator"})]
        public bool? SubjectOf2AnnotationIndicator {
            get { return this.subjectOf2AnnotationIndicator.Value; }
            set { this.subjectOf2AnnotationIndicator.Value = value; }
        }

    }

}