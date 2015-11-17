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
namespace Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Domainvalue;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"ConsultationNote.AssignedAuthor","ContinuityOfCareDocumentCCD.AssignedAuthor","DiagnosticImagingReport.AssignedAuthor","DischargeSummary.AssignedAuthor","HistoryAndPhysical.AssignedAuthor","OperativeNote.AssignedAuthor","ProcedureNote.AssignedAuthor","ProgressNote.AssignedAuthor","USRealmHeader.AssignedAuthor"})]
    public class AssignedAuthor : MessagePartBean {

        private LIST<CS, Code> realmCode;
        private II typeId;
        private LIST<II, Identifier> templateId;
        private LIST<II, Identifier> id;
        private CE code;
        private LIST<AD, PostalAddress> addr;
        private LIST<TEL, TelecommunicationAddress> telecom;
        private Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.IAssignedAuthorChoice assignedAuthorChoice;
        private Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.Organization_1 representedOrganization;

        public AssignedAuthor() {
            this.realmCode = new LISTImpl<CS, Code>(typeof(CSImpl));
            this.typeId = new IIImpl();
            this.templateId = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.id = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.code = new CEImpl();
            this.addr = new LISTImpl<AD, PostalAddress>(typeof(ADImpl));
            this.telecom = new LISTImpl<TEL, TelecommunicationAddress>(typeof(TELImpl));
        }
        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * DischargeSummary.AssignedAuthor.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DiagnosticImagingReport.AssignedAuthor.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * USRealmHeader.AssignedAuthor.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * HistoryAndPhysical.AssignedAuthor.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ContinuityOfCareDocumentCCD.AssignedAuthor.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ConsultationNote.AssignedAuthor.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * OperativeNote.AssignedAuthor.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureNote.AssignedAuthor.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProgressNote.AssignedAuthor.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"realmCode"})]
        public IList<Code> RealmCode {
            get { return this.realmCode.RawList<Code>(); }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * DischargeSummary.AssignedAuthor.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DiagnosticImagingReport.AssignedAuthor.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * USRealmHeader.AssignedAuthor.typeId Conformance/Cardinality: 
         * OPTIONAL (0-1) Un-merged Business Name: (no business name 
         * specified) Relationship: 
         * HistoryAndPhysical.AssignedAuthor.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ContinuityOfCareDocumentCCD.AssignedAuthor.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ConsultationNote.AssignedAuthor.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * OperativeNote.AssignedAuthor.typeId Conformance/Cardinality: 
         * OPTIONAL (0-1) Un-merged Business Name: (no business name 
         * specified) Relationship: ProcedureNote.AssignedAuthor.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProgressNote.AssignedAuthor.typeId Conformance/Cardinality: 
         * OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"typeId"})]
        public Identifier TypeId {
            get { return this.typeId.Value; }
            set { this.typeId.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * DischargeSummary.AssignedAuthor.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DiagnosticImagingReport.AssignedAuthor.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * USRealmHeader.AssignedAuthor.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * HistoryAndPhysical.AssignedAuthor.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ContinuityOfCareDocumentCCD.AssignedAuthor.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ConsultationNote.AssignedAuthor.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * OperativeNote.AssignedAuthor.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureNote.AssignedAuthor.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProgressNote.AssignedAuthor.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"templateId"})]
        public IList<Identifier> TemplateId {
            get { return this.templateId.RawList(); }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: DischargeSummary.AssignedAuthor.id 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DiagnosticImagingReport.AssignedAuthor.id 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * USRealmHeader.AssignedAuthor.id Conformance/Cardinality: 
         * POPULATED (*) Un-merged Business Name: (no business name 
         * specified) Relationship: 
         * HistoryAndPhysical.AssignedAuthor.id 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ContinuityOfCareDocumentCCD.AssignedAuthor.id 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ConsultationNote.AssignedAuthor.id Conformance/Cardinality: 
         * POPULATED (*) Un-merged Business Name: (no business name 
         * specified) Relationship: OperativeNote.AssignedAuthor.id 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureNote.AssignedAuthor.id Conformance/Cardinality: 
         * POPULATED (*) Un-merged Business Name: (no business name 
         * specified) Relationship: ProgressNote.AssignedAuthor.id 
         * Conformance/Cardinality: POPULATED (*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public IList<Identifier> Id {
            get { return this.id.RawList(); }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: DischargeSummary.AssignedAuthor.code 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DiagnosticImagingReport.AssignedAuthor.code 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * USRealmHeader.AssignedAuthor.code Conformance/Cardinality: 
         * OPTIONAL (0-1) Un-merged Business Name: (no business name 
         * specified) Relationship: 
         * HistoryAndPhysical.AssignedAuthor.code 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ContinuityOfCareDocumentCCD.AssignedAuthor.code 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ConsultationNote.AssignedAuthor.code 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * OperativeNote.AssignedAuthor.code Conformance/Cardinality: 
         * OPTIONAL (0-1) Un-merged Business Name: (no business name 
         * specified) Relationship: ProcedureNote.AssignedAuthor.code 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProgressNote.AssignedAuthor.code Conformance/Cardinality: 
         * OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public HealthcareProviderTaxonomy Code {
            get { return (HealthcareProviderTaxonomy) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: DischargeSummary.AssignedAuthor.addr 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DiagnosticImagingReport.AssignedAuthor.addr 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * USRealmHeader.AssignedAuthor.addr Conformance/Cardinality: 
         * POPULATED (*) Un-merged Business Name: (no business name 
         * specified) Relationship: 
         * HistoryAndPhysical.AssignedAuthor.addr 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ContinuityOfCareDocumentCCD.AssignedAuthor.addr 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ConsultationNote.AssignedAuthor.addr 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * OperativeNote.AssignedAuthor.addr Conformance/Cardinality: 
         * POPULATED (*) Un-merged Business Name: (no business name 
         * specified) Relationship: ProcedureNote.AssignedAuthor.addr 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProgressNote.AssignedAuthor.addr Conformance/Cardinality: 
         * POPULATED (*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"addr"})]
        public IList<PostalAddress> Addr {
            get { return this.addr.RawList(); }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * DischargeSummary.AssignedAuthor.telecom 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DiagnosticImagingReport.AssignedAuthor.telecom 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * USRealmHeader.AssignedAuthor.telecom 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * HistoryAndPhysical.AssignedAuthor.telecom 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ContinuityOfCareDocumentCCD.AssignedAuthor.telecom 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ConsultationNote.AssignedAuthor.telecom 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * OperativeNote.AssignedAuthor.telecom 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureNote.AssignedAuthor.telecom 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProgressNote.AssignedAuthor.telecom Conformance/Cardinality: 
         * POPULATED (*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"telecom"})]
        public IList<TelecommunicationAddress> Telecom {
            get { return this.telecom.RawList(); }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * DischargeSummary.AssignedAuthor.assignedAuthorChoice 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DiagnosticImagingReport.AssignedAuthor.assignedAuthorChoice 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * USRealmHeader.AssignedAuthor.assignedAuthorChoice 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * HistoryAndPhysical.AssignedAuthor.assignedAuthorChoice 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ContinuityOfCareDocumentCCD.AssignedAuthor.assignedAuthorChoice 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ConsultationNote.AssignedAuthor.assignedAuthorChoice 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * OperativeNote.AssignedAuthor.assignedAuthorChoice 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureNote.AssignedAuthor.assignedAuthorChoice 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProgressNote.AssignedAuthor.assignedAuthorChoice 
         * Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"assignedAuthorChoice"})]
        public Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.IAssignedAuthorChoice AssignedAuthorChoice {
            get { return this.assignedAuthorChoice; }
            set { this.assignedAuthorChoice = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * DischargeSummary.AssignedAuthor.representedOrganization 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DiagnosticImagingReport.AssignedAuthor.representedOrganization 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * USRealmHeader.AssignedAuthor.representedOrganization 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * HistoryAndPhysical.AssignedAuthor.representedOrganization 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ContinuityOfCareDocumentCCD.AssignedAuthor.representedOrganization 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ConsultationNote.AssignedAuthor.representedOrganization 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * OperativeNote.AssignedAuthor.representedOrganization 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureNote.AssignedAuthor.representedOrganization 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProgressNote.AssignedAuthor.representedOrganization 
         * Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"representedOrganization"})]
        public Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.Organization_1 RepresentedOrganization {
            get { return this.representedOrganization; }
            set { this.representedOrganization = value; }
        }

    }

}