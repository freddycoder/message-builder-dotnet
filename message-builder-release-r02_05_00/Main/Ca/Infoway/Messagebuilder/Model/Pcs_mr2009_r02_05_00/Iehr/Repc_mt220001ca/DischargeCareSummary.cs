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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Repc_mt220001ca {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt011001ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Discharge-Care Summary</summary>
     * 
     * <p>Allows the capture of patient health data in an 
     * encapsulated, contextualized manner with capability of 
     * displaying rendered content and communication between simple 
     * systems.</p> <p>Represents a particular health-related 
     * document pertaining to a single patient.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT220001CA.Document"})]
    public class DischargeCareSummary : MessagePartBean {

        private SET<II, Identifier> id;
        private CV code;
        private ST title;
        private CS statusCode;
        private SET<CV, Code> confidentialityCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.RequestedBy author;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.IRecipients> primaryInformationRecipientRecipients;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.AuthenticatedBy authenticator;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.ReplacesRecordIds> predecessorOldClinicalDocumentEvent;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Repc_mt220001ca.IDocumentContent component1DocumentContent;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Repc_mt220001ca.Section component2StructuredBodyComponentSection;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.Includes subjectOf;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt011001ca.CareCompositions> componentOfPatientCareProvisionEvent;

        public DischargeCareSummary() {
            this.id = new SETImpl<II, Identifier>(typeof(IIImpl));
            this.code = new CVImpl();
            this.title = new STImpl();
            this.statusCode = new CSImpl();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.primaryInformationRecipientRecipients = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.IRecipients>();
            this.predecessorOldClinicalDocumentEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.ReplacesRecordIds>();
            this.componentOfPatientCareProvisionEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt011001ca.CareCompositions>();
        }
        /**
         * <summary>Business Name: Document Identifier</summary>
         * 
         * <remarks>Relationship: REPC_MT220001CA.Document.id 
         * Conformance/Cardinality: MANDATORY (1-2)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public ICollection<Identifier> Id {
            get { return this.id.RawSet(); }
        }

        /**
         * <summary>Business Name: B: Document Category</summary>
         * 
         * <remarks>Relationship: REPC_MT220001CA.Document.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Document Category 
         * is used for searching and for organizing Discharge-Care 
         * Summary records as well as sorting them for 
         * presentation.</p><p>This is a key attribute for 
         * understanding the type of record and is therefore 
         * mandatory.</p> <p>Identifies the type of Discharge-Care 
         * Summary represented by this record. e.g. summarization of 
         * episode note; discharge summarization note.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public CareSummaryDocumentType Code {
            get { return (CareSummaryDocumentType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: J: Document Title</summary>
         * 
         * <remarks>Relationship: REPC_MT220001CA.Document.title 
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
         * <summary>Business Name: Preliminary/Final Indicator</summary>
         * 
         * <remarks>Relationship: REPC_MT220001CA.Document.statusCode 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: E: Document Masking Indicators</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT220001CA.Document.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-2) <p>The value 
         * specified for a particular record may be overridden by a 
         * higher level masking applied to an indication, a care 
         * composition, a type of record or even all patient 
         * records.</p> <p>Communicates the desire of the patient to 
         * restrict access to this Discharge-Care Summary record. 
         * Provides support for additional confidentiality constraint, 
         * giving patients a level of control over their information. 
         * Methods for accessing masked event records will be governed 
         * by each jurisdiction(e.g. court orders, shared 
         * secret/consent, etc.).</p><p>Can also be used 
         * to</p><p>communicate that the information is deemed to be 
         * sensitive and should not be communicated or exposed to the 
         * patient (at least without the guidance of the authoring or 
         * other responsible healthcare provider).</p><p>Valid values 
         * are: 'normal' (denotes 'Not Masked'); 'restricted' (denotes 
         * 'Masked') and 'taboo' (denotes 'patient restricted'). The 
         * default is 'normal' signifying 'Not Masked'. Either or both 
         * of the other codes can be asserted to indicate masking by 
         * the patient from providers or masking by a provider from the 
         * patient, respectively. 'normal' should never be asserted 
         * with one of the other codes.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_BasicConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_BasicConfidentialityKind>(); }
        }

        /**
         * <summary>Relationship: REPC_MT220001CA.Document.author</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.RequestedBy Author {
            get { return this.author; }
            set { this.author = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT220001CA.InformationRecipient.recipients</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"primaryInformationRecipient/recipients"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.IRecipients> PrimaryInformationRecipientRecipients {
            get { return this.primaryInformationRecipientRecipients; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT220001CA.Document.authenticator</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"authenticator"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.AuthenticatedBy Authenticator {
            get { return this.authenticator; }
            set { this.authenticator = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT220001CA.Predecessor2.oldClinicalDocumentEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"predecessor/oldClinicalDocumentEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.ReplacesRecordIds> PredecessorOldClinicalDocumentEvent {
            get { return this.predecessorOldClinicalDocumentEvent; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT220001CA.Component4.documentContent</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component1/documentContent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Repc_mt220001ca.IDocumentContent Component1DocumentContent {
            get { return this.component1DocumentContent; }
            set { this.component1DocumentContent = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Repc_mt220001ca.DischargeCareSummaryReport Component1DocumentContentAsPatientCareProvisionEvent {
            get { return this.component1DocumentContent is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Repc_mt220001ca.DischargeCareSummaryReport ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Repc_mt220001ca.DischargeCareSummaryReport) this.component1DocumentContent : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Repc_mt220001ca.DischargeCareSummaryReport) null; }
        }
        public bool HasComponent1DocumentContentAsPatientCareProvisionEvent() {
            return (this.component1DocumentContent is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Repc_mt220001ca.DischargeCareSummaryReport);
        }

        /**
         * <summary>Relationship: REPC_MT220001CA.Component3.section</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component2/structuredBody/component/section"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Repc_mt220001ca.Section Component2StructuredBodyComponentSection {
            get { return this.component2StructuredBodyComponentSection; }
            set { this.component2StructuredBodyComponentSection = value; }
        }

        /**
         * <summary>Relationship: REPC_MT220001CA.Document.subjectOf</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.Includes SubjectOf {
            get { return this.subjectOf; }
            set { this.subjectOf = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT220001CA.Component6.patientCareProvisionEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"componentOf/patientCareProvisionEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt011001ca.CareCompositions> ComponentOfPatientCareProvisionEvent {
            get { return this.componentOfPatientCareProvisionEvent; }
        }

    }

}