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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Porx_mt060010ca {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt090108ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt260030ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt120600ca;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Dispense</summary>
     * 
     * <p>Annotation is only permitted if Annotation Indicator is 
     * not present</p><p>Reported Issue is only permitted if Issue 
     * Indicator is not present</p><p>One of DetectedIssueIndicator 
     * or Reported Issues detailed info must be returned, but not 
     * both</p><p>One of AnnotationIndicator or Annotation detail 
     * info must be returned, but not both.</p> <p>Annotation is 
     * only permitted if Annotation Indicator is not 
     * present</p><p>Reported Issue is only permitted if Issue 
     * Indicator is not present</p><p>One of DetectedIssueIndicator 
     * or Reported Issues detailed info must be returned, but not 
     * both</p><p>One of AnnotationIndicator or Annotation detail 
     * info must be returned, but not both.</p> <p>Annotation is 
     * only permitted if Annotation Indicator is not 
     * present</p><p>Reported Issue is only permitted if Issue 
     * Indicator is not present</p><p>One of DetectedIssueIndicator 
     * or Reported Issues detailed info must be returned, but not 
     * both</p><p>One of AnnotationIndicator or Annotation detail 
     * info must be returned, but not both.</p> <p>Annotation is 
     * only permitted if Annotation Indicator is not 
     * present</p><p>Reported Issue is only permitted if Issue 
     * Indicator is not present</p><p>One of DetectedIssueIndicator 
     * or Reported Issues detailed info must be returned, but not 
     * both</p><p>One of AnnotationIndicator or Annotation detail 
     * info must be returned, but not both.</p> <p>Describes the 
     * issuing of a drug in response to an authorizing 
     * prescription.</p> <p>This is a 'core' class of the 
     * medication model and is important for understanding what 
     * drugs the patient is actually receiving.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060010CA.DeviceDispense"})]
    public class Dispense : MessagePartBean {

        private II id;
        private CS statusCode;
        private SET<CV, Code> confidentialityCode;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt090108ca.HealthcareWorker responsiblePartyAssignedEntity;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt090108ca.HealthcareWorker performerAssignedEntity;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.TargetedToPharmacy location;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.ProcedureRequest component1ProcedureRequest;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.DispenseDetails component2SupplyEvent;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.PrescriptionReference_1 fulfillmentSupplyRequest;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.DispenseStatusChanges> subjectOf1ControlActEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt260030ca.Issues> subjectOf2DetectedIssueEvent;
        private BL subjectOf3AnnotationIndicator;
        private BL subjectOf4DetectedIssueIndicator;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt120600ca.Notes> subjectOf5Annotation;

        public Dispense() {
            this.id = new IIImpl();
            this.statusCode = new CSImpl();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.subjectOf1ControlActEvent = new List<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.DispenseStatusChanges>();
            this.subjectOf2DetectedIssueEvent = new List<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt260030ca.Issues>();
            this.subjectOf3AnnotationIndicator = new BLImpl(false);
            this.subjectOf4DetectedIssueIndicator = new BLImpl(false);
            this.subjectOf5Annotation = new List<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt120600ca.Notes>();
        }
        /**
         * <summary>Business Name: A:Prescription Dispense Number</summary>
         * 
         * <remarks>Relationship: PORX_MT060010CA.DeviceDispense.id 
         * Conformance/Cardinality: MANDATORY (1) <p>The Prescription 
         * Dispense Number is a globally unique number assigned to a 
         * prescription dispense by the EHR/DIS irrespective of the 
         * source of the supply event</p><p>It is created by the 
         * EHR/DIS once the dispense has passed all edits and 
         * validation.</p> <p>The Prescription Dispense Number is a 
         * globally unique number assigned to a prescription dispense 
         * by the EHR/DIS irrespective of the source of the supply 
         * event</p><p>It is created by the EHR/DIS once the dispense 
         * has passed all edits and validation.</p> <p>Allows dispense 
         * events to be uniquely referenced and is therefore 
         * mandatory.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: B:Dispense Status</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060010CA.DeviceDispense.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates whether 
         * the dispense has been picked up ('complete') or has just 
         * been processed ('active').</p> <p>Indicates how far along 
         * the process the dispense event is. It should always be known 
         * and is therefore mandatory.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: E:Prescription Masking Indicators</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060010CA.DeviceDispense.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-2) <p>Indicates whether 
         * the dispense (and associated prescription) is 
         * masked.</p><p>Indicates if a provider has requested 
         * restricted access to a patient or care giver.</p> 
         * <p>Indicates whether the dispense (and associated 
         * prescription) is masked.</p><p>Indicates if a provider has 
         * requested restricted access to a patient or care giver.</p> 
         * <p>Allows a patient to control access to 'sensitive' 
         * prescriptions.</p><p>Taboo allows the provider to request 
         * restricted access to patient or their care 
         * giver.</p><p>Constraint: Can&#226;&#128;&#153;t have both 
         * normal and one of the other codes simultaneously.</p><p>The 
         * attribute is optional because not all systems will support 
         * masking.</p> <p>Allows a patient to control access to 
         * 'sensitive' prescriptions.</p><p>Taboo allows the provider 
         * to request restricted access to patient or their care 
         * giver.</p><p>Constraint: Can&#226;&#128;&#153;t have both 
         * normal and one of the other codes simultaneously.</p><p>The 
         * attribute is optional because not all systems will support 
         * masking.</p> <p>Allows a patient to control access to 
         * 'sensitive' prescriptions.</p><p>Taboo allows the provider 
         * to request restricted access to patient or their care 
         * giver.</p><p>Constraint: Can&#226;&#128;&#153;t have both 
         * normal and one of the other codes simultaneously.</p><p>The 
         * attribute is optional because not all systems will support 
         * masking.</p> <p>Allows a patient to control access to 
         * 'sensitive' prescriptions.</p><p>Taboo allows the provider 
         * to request restricted access to patient or their care 
         * giver.</p><p>Constraint: Can&#226;&#128;&#153;t have both 
         * normal and one of the other codes simultaneously.</p><p>The 
         * attribute is optional because not all systems will support 
         * masking.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_NormalRestrictedTabooConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_NormalRestrictedTabooConfidentialityKind>(); }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060010CA.ResponsibleParty.assignedEntity</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt090108ca.HealthcareWorker ResponsiblePartyAssignedEntity {
            get { return this.responsiblePartyAssignedEntity; }
            set { this.responsiblePartyAssignedEntity = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060010CA.Performer3.assignedEntity</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"performer/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt090108ca.HealthcareWorker PerformerAssignedEntity {
            get { return this.performerAssignedEntity; }
            set { this.performerAssignedEntity = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060010CA.DeviceDispense.location</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.TargetedToPharmacy Location {
            get { return this.location; }
            set { this.location = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060010CA.Component11.procedureRequest</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component1/procedureRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.ProcedureRequest Component1ProcedureRequest {
            get { return this.component1ProcedureRequest; }
            set { this.component1ProcedureRequest = value; }
        }

        /**
         * <summary>Relationship: PORX_MT060010CA.Component.supplyEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component2/supplyEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.DispenseDetails Component2SupplyEvent {
            get { return this.component2SupplyEvent; }
            set { this.component2SupplyEvent = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060010CA.InFulfillmentOf.supplyRequest</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"fulfillment/supplyRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.PrescriptionReference_1 FulfillmentSupplyRequest {
            get { return this.fulfillmentSupplyRequest; }
            set { this.fulfillmentSupplyRequest = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060010CA.Subject.controlActEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf1/controlActEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.DispenseStatusChanges> SubjectOf1ControlActEvent {
            get { return this.subjectOf1ControlActEvent; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060010CA.Subject6.detectedIssueEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2/detectedIssueEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt260030ca.Issues> SubjectOf2DetectedIssueEvent {
            get { return this.subjectOf2DetectedIssueEvent; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060010CA.Subject12.annotationIndicator</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf3/annotationIndicator"})]
        public bool? SubjectOf3AnnotationIndicator {
            get { return this.subjectOf3AnnotationIndicator.Value; }
            set { this.subjectOf3AnnotationIndicator.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060010CA.Subject13.detectedIssueIndicator</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf4/detectedIssueIndicator"})]
        public bool? SubjectOf4DetectedIssueIndicator {
            get { return this.subjectOf4DetectedIssueIndicator.Value; }
            set { this.subjectOf4DetectedIssueIndicator.Value = value; }
        }

        /**
         * <summary>Relationship: PORX_MT060010CA.Subject7.annotation</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf5/annotation"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt120600ca.Notes> SubjectOf5Annotation {
            get { return this.subjectOf5Annotation; }
        }

    }

}