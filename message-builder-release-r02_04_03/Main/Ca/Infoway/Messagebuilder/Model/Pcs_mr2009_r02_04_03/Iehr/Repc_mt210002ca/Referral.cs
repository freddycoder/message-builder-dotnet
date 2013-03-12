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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Repc_mt210002ca {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090508ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt910108ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt911108ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Referral</summary>
     * 
     * <p>Annotation is only permitted if Annotation Indicator is 
     * not present and vice versa</p> <p>Allows the capture of 
     * patient health data in an encapsulated, contextualized 
     * manner with capability of displaying rendered content and 
     * communication between simple systems.</p> <p>Represents a 
     * particular health-related document pertaining to a single 
     * patient.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT210002CA.Document"})]
    public class Referral : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Comt_mt111111ca.ISHR {

        private II id;
        private CV code;
        private ST title;
        private SET<CV, Code> confidentialityCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt911108ca.IActingPerson responsiblePartyActingPerson;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.RequestedBy author;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.ServiceLocation custodian1ServiceDeliveryLocation;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.EHRRepository custodian2AssignedDevice;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.IRecipients> primaryInformationRecipientRecipients;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.OldClinicalDocumentEvent> predecessorOldClinicalDocumentEvent;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.IDocumentContent_1 componentStructuredBodyComponentSectionComponentDocumentContent;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.NewClinicalDocumentEvent successorNewClinicalDocumentEvent;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.Includes subjectOf1;
        private BL subjectOf2AnnotationIndicator;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.CareCompositions> componentOfPatientCareProvisionEvent;

        public Referral() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.title = new STImpl();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.primaryInformationRecipientRecipients = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.IRecipients>();
            this.predecessorOldClinicalDocumentEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.OldClinicalDocumentEvent>();
            this.subjectOf2AnnotationIndicator = new BLImpl(false);
            this.componentOfPatientCareProvisionEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.CareCompositions>();
        }
        /**
         * <summary>Business Name: A: Document Identifier</summary>
         * 
         * <remarks>Relationship: REPC_MT210002CA.Document.id 
         * Conformance/Cardinality: MANDATORY (1) <p> <i>Allows for 
         * unique identification of the Referral and is therefore 
         * mandatory. Supports drill-down queries, linking of this 
         * record to other records, matching of EHR records to 
         * locally-stored PoS records and is necessary when identifying 
         * records for amending (revising)/directional linking 
         * (superseding).</i> </p> <p> <i>A globally unique identifier 
         * assigned by the EHR to the Referral record.</i> </p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: B: Referral Document Category</summary>
         * 
         * <remarks>Relationship: REPC_MT210002CA.Document.code 
         * Conformance/Cardinality: MANDATORY (1) <p> <i>Referral 
         * Document Category is used for searching and for organizing 
         * Referral records as well as sorting them for 
         * presentation.</i> </p><p> <i>This is a key attribute for 
         * understanding the type of record and is therefore 
         * mandatory.</i> </p> <p> <i>Identifies the type of Referral 
         * represented by this record. e.g. care transfer referral 
         * note, care referral note, cardiology care referral note</i> 
         * </p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ReferralDocumentType Code {
            get { return (ReferralDocumentType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: J: Document Title</summary>
         * 
         * <remarks>Relationship: REPC_MT210002CA.Document.title 
         * Conformance/Cardinality: MANDATORY (1) <p>This is a 
         * human-recognizable name intended to be displayed on the 
         * screen in list transactions and is therefore mandatory. It 
         * provides a good indication of the content of the document at 
         * a quick glance.</p> <p>Titles do not necessarily need to be 
         * unique, but should be precise-enough to give a pretty good 
         * idea of what the document contains. For example &quot;Right 
         * Knee Arthroscopy Report, Jan 3, 2006&quot; would represent a 
         * good title. &quot;Surgery Report&quot; would not.</p> <p>A 
         * human-readable label for this particular document.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"title"})]
        public String Title {
            get { return this.title.Value; }
            set { this.title.Value = value; }
        }

        /**
         * <summary>Business Name: E: Document Masking Indicators</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT210002CA.Document.confidentialityCode 
         * Conformance/Cardinality: REQUIRED (0-2) <p></p> <p> <i>The 
         * value specified for a particular record may be overridden by 
         * a higher level masking applied to an indication, a care 
         * composition, a type of record or even all patient 
         * records.</i> </p> <p> <i>Communicates the desire of the 
         * patient to restrict access to this Referral record. Provides 
         * support for additional confidentiality constraint, giving 
         * patients a level of control over their information. Methods 
         * for accessing masked event records will be governed by each 
         * jurisdiction (e.g. court orders, shared secret/consent, 
         * etc.).</i> </p><p> <i>Can also be used to communicate that 
         * the information is deemed to be sensitive and should not be 
         * communicated or exposed to the patient (at least without the 
         * guidance of the authoring or other responsible healthcare 
         * provider).</i> </p><p> <i>Valid values are: 'normal' 
         * (denotes 'Not Masked'); 'restricted' (denotes 'Masked') and 
         * 'taboo' (denotes 'patient restricted'). The default is 
         * 'normal' signifying 'Not Masked'. Either or both of the 
         * other codes can be asserted to indicate masking by the 
         * patient from providers or masking by a provider from the 
         * patient, respectively. 'normal' should never be asserted 
         * with one of the other codes.</i> </p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_BasicConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_BasicConfidentialityKind>(); }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT210002CA.ResponsibleParty.actingPerson</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/actingPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt911108ca.IActingPerson ResponsiblePartyActingPerson {
            get { return this.responsiblePartyActingPerson; }
            set { this.responsiblePartyActingPerson = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.HealthcareWorker ResponsiblePartyActingPersonAsAssignedEntity1 {
            get { return this.responsiblePartyActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.HealthcareWorker ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.HealthcareWorker) this.responsiblePartyActingPerson : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.HealthcareWorker) null; }
        }
        public bool HasResponsiblePartyActingPersonAsAssignedEntity1() {
            return (this.responsiblePartyActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.HealthcareWorker);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090508ca.HealthcareOrganization ResponsiblePartyActingPersonAsAssignedEntity2 {
            get { return this.responsiblePartyActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090508ca.HealthcareOrganization ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090508ca.HealthcareOrganization) this.responsiblePartyActingPerson : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090508ca.HealthcareOrganization) null; }
        }
        public bool HasResponsiblePartyActingPersonAsAssignedEntity2() {
            return (this.responsiblePartyActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090508ca.HealthcareOrganization);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt910108ca.RelatedPerson ResponsiblePartyActingPersonAsPersonalRelationship {
            get { return this.responsiblePartyActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt910108ca.RelatedPerson ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt910108ca.RelatedPerson) this.responsiblePartyActingPerson : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt910108ca.RelatedPerson) null; }
        }
        public bool HasResponsiblePartyActingPersonAsPersonalRelationship() {
            return (this.responsiblePartyActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt910108ca.RelatedPerson);
        }

        /**
         * <summary>Relationship: REPC_MT210002CA.Document.author</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.RequestedBy Author {
            get { return this.author; }
            set { this.author = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT210002CA.Custodian2.serviceDeliveryLocation</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"custodian1/serviceDeliveryLocation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.ServiceLocation Custodian1ServiceDeliveryLocation {
            get { return this.custodian1ServiceDeliveryLocation; }
            set { this.custodian1ServiceDeliveryLocation = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT210002CA.Custodian.assignedDevice</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"custodian2/assignedDevice"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.EHRRepository Custodian2AssignedDevice {
            get { return this.custodian2AssignedDevice; }
            set { this.custodian2AssignedDevice = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT210002CA.InformationRecipient.recipients</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"primaryInformationRecipient/recipients"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.IRecipients> PrimaryInformationRecipientRecipients {
            get { return this.primaryInformationRecipientRecipients; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT210002CA.Predecessor2.oldClinicalDocumentEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"predecessor/oldClinicalDocumentEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.OldClinicalDocumentEvent> PredecessorOldClinicalDocumentEvent {
            get { return this.predecessorOldClinicalDocumentEvent; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT210002CA.Component4.documentContent</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component/structuredBody/component/section/component/documentContent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.IDocumentContent_1 ComponentStructuredBodyComponentSectionComponentDocumentContent {
            get { return this.componentStructuredBodyComponentSectionComponentDocumentContent; }
            set { this.componentStructuredBodyComponentSectionComponentDocumentContent = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.Referral ComponentStructuredBodyComponentSectionComponentDocumentContentAsPatientCareProvisionRequest {
            get { return this.componentStructuredBodyComponentSectionComponentDocumentContent is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.Referral ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.Referral) this.componentStructuredBodyComponentSectionComponentDocumentContent : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.Referral) null; }
        }
        public bool HasComponentStructuredBodyComponentSectionComponentDocumentContentAsPatientCareProvisionRequest() {
            return (this.componentStructuredBodyComponentSectionComponentDocumentContent is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.Referral);
        }

        /**
         * <summary>Relationship: 
         * REPC_MT210002CA.Predecessor.newClinicalDocumentEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"successor/newClinicalDocumentEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.NewClinicalDocumentEvent SuccessorNewClinicalDocumentEvent {
            get { return this.successorNewClinicalDocumentEvent; }
            set { this.successorNewClinicalDocumentEvent = value; }
        }

        /**
         * <summary>Relationship: REPC_MT210002CA.Document.subjectOf1</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf1"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.Includes SubjectOf1 {
            get { return this.subjectOf1; }
            set { this.subjectOf1 = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT210002CA.Subject3.annotationIndicator</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2/annotationIndicator"})]
        public bool? SubjectOf2AnnotationIndicator {
            get { return this.subjectOf2AnnotationIndicator.Value; }
            set { this.subjectOf2AnnotationIndicator.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT210002CA.Component6.patientCareProvisionEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"componentOf/patientCareProvisionEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.CareCompositions> ComponentOfPatientCareProvisionEvent {
            get { return this.componentOfPatientCareProvisionEvent; }
        }

    }

}