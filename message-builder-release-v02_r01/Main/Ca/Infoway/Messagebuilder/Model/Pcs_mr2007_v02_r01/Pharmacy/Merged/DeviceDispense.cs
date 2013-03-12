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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Merged {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Common.Coct_mt120600ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>PORX_MT060010CA.DeviceDispense: Dispense</summary>
     * 
     * <p>Annotation is only permitted if Annotation Indicator is 
     * not present</p> <p>Reported Issue is only permitted if Issue 
     * Indicator is not present</p> <p>One of 
     * DetectedIssueIndicator or Reported Issues detailed info must 
     * be returned, but not both</p> <p>One of AnnotationIndicator 
     * or Annotation detail info must be returned, but not 
     * both.</p> <p>This is a 'core' class of the medication model 
     * and is important for understanding what drugs the patient is 
     * actually receiving.</p> <p>Describes the issuing of a drug 
     * in response to an authorizing prescription.</p> 
     * PORX_MT060040CA.DeviceDispense: Prescription Dispenses 
     * <p>Reported Issue is only permitted if Issue Indicator is 
     * not present</p> <p>Annotation is only permitted if 
     * Annotation Indicator is not present</p> <p>Dispensing is an 
     * integral part of the overall prescription process.</p> 
     * <p>This is the detailed information about a device dispense 
     * that has been performed on behalf of a patient.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060010CA.DeviceDispense","PORX_MT060040CA.DeviceDispense"})]
    public class DeviceDispense : MessagePartBean {

        private II id;
        private CS statusCode;
        private SET<CV, Code> confidentialityCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Merged.HealthcareWorker responsiblePartyAssignedEntity;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Merged.HealthcareWorker performerAssignedEntity;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Merged.CreatedAt location;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Merged.ProcedureRequest component1ProcedureRequest;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Merged.DispenseDetails component2SupplyEvent;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Merged.PrescriptionReference fulfillmentSupplyRequest;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Merged.StatusChanges> subjectOf1ControlActEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Merged.Issues> subjectOf4DetectedIssueEvent;
        private BL subjectOf2AnnotationIndicator;
        private BL subjectOf3DetectedIssueIndicator;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Common.Coct_mt120600ca.Notes> subjectOf5Annotation;

        public DeviceDispense() {
            this.id = new IIImpl();
            this.statusCode = new CSImpl();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.subjectOf1ControlActEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Merged.StatusChanges>();
            this.subjectOf4DetectedIssueEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Merged.Issues>();
            this.subjectOf2AnnotationIndicator = new BLImpl(false);
            this.subjectOf3DetectedIssueIndicator = new BLImpl(false);
            this.subjectOf5Annotation = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Common.Coct_mt120600ca.Notes>();
        }
        /**
         * <summary>Business Name: PrescriptionDispenseNumber</summary>
         * 
         * <remarks>Un-merged Business Name: PrescriptionDispenseNumber 
         * Relationship: PORX_MT060010CA.DeviceDispense.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows dispense 
         * events to be uniquely referenced and is therefore 
         * mandatory.</p> <p>The Prescription Dispense Number is a 
         * globally unique number assigned to a prescription dispense 
         * by the EHR/DIS irrespective of the source of the supply 
         * event</p><p>It is created by the EHR/DIS once the dispense 
         * has passed all edits and validation.</p> Un-merged Business 
         * Name: PrescriptionDispenseNumber Relationship: 
         * PORX_MT060040CA.DeviceDispense.id Conformance/Cardinality: 
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
         * <summary>Business Name: DispenseStatus</summary>
         * 
         * <remarks>Un-merged Business Name: DispenseStatus 
         * Relationship: PORX_MT060010CA.DeviceDispense.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates how far 
         * along the process the dispense event is. It should always be 
         * known and is therefore mandatory.</p> <p>Indicates whether 
         * the dispense has been picked up ('complete') or has just 
         * been processed ('active').</p> Un-merged Business Name: 
         * DispenseStatus Relationship: 
         * PORX_MT060040CA.DeviceDispense.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Important in 
         * understanding what devices the patient actually has on hand, 
         * thus the attribute is mandatory. May also influence the 
         * ability of a different pharmacy to dispense the device.</p> 
         * <p>Indicates the status of the dispense record created on 
         * the EHR/DIS. If 'Active' it means that the dispense has been 
         * processed but not yet given to the patient. If 'Complete', 
         * it indicates that the device has been delivered to the 
         * patient.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: PrescriptionMaskingIndicators</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * PrescriptionMaskingIndicators Relationship: 
         * PORX_MT060010CA.DeviceDispense.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-2) <p>Allows a patient 
         * to control access to 'sensitive' prescriptions.</p><p>Taboo 
         * allows the provider to request restricted access to patient 
         * or their care giver.</p><p>Constraint: Cant have both normal 
         * and one of the other codes simultaneously.</p><p>The 
         * attribute is optional because not all systems will support 
         * masking.</p> <p>Indicates whether the dispense (and 
         * associated prescription) is masked.</p><p>Indicates if a 
         * provider has requested restricted access to a patient or 
         * care giver.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_NormalRestrictedTabooConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_NormalRestrictedTabooConfidentialityKind>(); }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060010CA.ResponsibleParty.assignedEntity 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060040CA.ResponsibleParty3.assignedEntity 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Merged.HealthcareWorker ResponsiblePartyAssignedEntity {
            get { return this.responsiblePartyAssignedEntity; }
            set { this.responsiblePartyAssignedEntity = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060010CA.Performer3.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060040CA.Performer3.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"performer/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Merged.HealthcareWorker PerformerAssignedEntity {
            get { return this.performerAssignedEntity; }
            set { this.performerAssignedEntity = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060010CA.DeviceDispense.location 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060040CA.DeviceDispense.location 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Merged.CreatedAt Location {
            get { return this.location; }
            set { this.location = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060010CA.Component11.procedureRequest 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060040CA.Component11.procedureRequest 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component1/procedureRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Merged.ProcedureRequest Component1ProcedureRequest {
            get { return this.component1ProcedureRequest; }
            set { this.component1ProcedureRequest = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: PORX_MT060010CA.Component.supplyEvent 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060040CA.Component.supplyEvent 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component2/supplyEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Merged.DispenseDetails Component2SupplyEvent {
            get { return this.component2SupplyEvent; }
            set { this.component2SupplyEvent = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060010CA.InFulfillmentOf.supplyRequest 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"fulfillment/supplyRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Merged.PrescriptionReference FulfillmentSupplyRequest {
            get { return this.fulfillmentSupplyRequest; }
            set { this.fulfillmentSupplyRequest = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060010CA.Subject.controlActEvent 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060040CA.Subject10.controlActEvent 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf1/controlActEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Merged.StatusChanges> SubjectOf1ControlActEvent {
            get { return this.subjectOf1ControlActEvent; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060010CA.Subject6.detectedIssueEvent 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060040CA.Subject6.detectedIssueEvent 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2/detectedIssueEvent","subjectOf4/detectedIssueEvent"})]
        [Hl7MapByPartType(Name="subjectOf2", Type="PORX_MT060010CA.Subject6")]
        [Hl7MapByPartType(Name="subjectOf2/detectedIssueEvent", Type="COCT_MT260030CA.DetectedIssueEvent")]
        [Hl7MapByPartType(Name="subjectOf4", Type="PORX_MT060040CA.Subject6")]
        [Hl7MapByPartType(Name="subjectOf4/detectedIssueEvent", Type="COCT_MT260030CA.DetectedIssueEvent")]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Merged.Issues> SubjectOf4DetectedIssueEvent {
            get { return this.subjectOf4DetectedIssueEvent; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060010CA.Subject12.annotationIndicator 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060040CA.Subject12.annotationIndicator 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2/annotationIndicator","subjectOf3/annotationIndicator"})]
        [Hl7MapByPartType(Name="subjectOf2", Type="PORX_MT060040CA.Subject12")]
        [Hl7MapByPartType(Name="subjectOf2/annotationIndicator", Type="PORX_MT060040CA.AnnotationIndicator")]
        [Hl7MapByPartType(Name="subjectOf3", Type="PORX_MT060010CA.Subject12")]
        [Hl7MapByPartType(Name="subjectOf3/annotationIndicator", Type="PORX_MT060010CA.AnnotationIndicator")]
        public bool? SubjectOf2AnnotationIndicator {
            get { return this.subjectOf2AnnotationIndicator.Value; }
            set { this.subjectOf2AnnotationIndicator.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060010CA.Subject13.detectedIssueIndicator 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060040CA.Subject13.detectedIssueIndicator 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf3/detectedIssueIndicator","subjectOf4/detectedIssueIndicator"})]
        [Hl7MapByPartType(Name="subjectOf3", Type="PORX_MT060040CA.Subject13")]
        [Hl7MapByPartType(Name="subjectOf3/detectedIssueIndicator", Type="PORX_MT060040CA.DetectedIssueIndicator")]
        [Hl7MapByPartType(Name="subjectOf4", Type="PORX_MT060010CA.Subject13")]
        [Hl7MapByPartType(Name="subjectOf4/detectedIssueIndicator", Type="PORX_MT060010CA.DetectedIssueIndicator")]
        public bool? SubjectOf3DetectedIssueIndicator {
            get { return this.subjectOf3DetectedIssueIndicator.Value; }
            set { this.subjectOf3DetectedIssueIndicator.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: PORX_MT060010CA.Subject7.annotation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060040CA.Subject7.annotation Conformance/Cardinality: 
         * POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf5/annotation"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Common.Coct_mt120600ca.Notes> SubjectOf5Annotation {
            get { return this.subjectOf5Annotation; }
        }

    }

}