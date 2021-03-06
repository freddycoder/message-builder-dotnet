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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */


/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Domainvalue;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"ConsultationNote.LegalAuthenticatorAssignedEntity","ContinuityOfCareDocumentCCD.LegalAuthenticatorAssignedEntity","DiagnosticImagingReport.LegalAuthenticatorAssignedEntity","DischargeSummary.LegalAuthenticatorAssignedEntity","HistoryAndPhysical.LegalAuthenticatorAssignedEntity","OperativeNote.LegalAuthenticatorAssignedEntity","ProcedureNote.LegalAuthenticatorAssignedEntity","ProgressNote.LegalAuthenticatorAssignedEntity","USRealmHeader.LegalAuthenticatorAssignedEntity","UnstructuredDocument.LegalAuthenticatorAssignedEntity"})]
    public class LegalAuthenticatorAssignedEntity : MessagePartBean {

        private II typeId;
        private LIST<II, Identifier> templateId;
        private LIST<II, Identifier> id;
        private CE_R2<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Domainvalue.HealthcareProviderTaxonomy> code;
        private LIST<AD, PostalAddress> addr;
        private LIST<TEL, TelecommunicationAddress> telecom;
        private Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.LegalAuthenticatorPerson assignedPerson;
        private Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Organization_1 representedOrganization;

        public LegalAuthenticatorAssignedEntity() {
            this.typeId = new IIImpl();
            this.templateId = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.id = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.code = new CE_R2Impl<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Domainvalue.HealthcareProviderTaxonomy>();
            this.addr = new LISTImpl<AD, PostalAddress>(typeof(ADImpl));
            this.telecom = new LISTImpl<TEL, TelecommunicationAddress>(typeof(TELImpl));
        }
        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * HistoryAndPhysical.LegalAuthenticatorAssignedEntity.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureNote.LegalAuthenticatorAssignedEntity.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ContinuityOfCareDocumentCCD.LegalAuthenticatorAssignedEntity.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * OperativeNote.LegalAuthenticatorAssignedEntity.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ConsultationNote.LegalAuthenticatorAssignedEntity.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DischargeSummary.LegalAuthenticatorAssignedEntity.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProgressNote.LegalAuthenticatorAssignedEntity.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DiagnosticImagingReport.LegalAuthenticatorAssignedEntity.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * UnstructuredDocument.LegalAuthenticatorAssignedEntity.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * USRealmHeader.LegalAuthenticatorAssignedEntity.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1)</remarks>
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
         * HistoryAndPhysical.LegalAuthenticatorAssignedEntity.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureNote.LegalAuthenticatorAssignedEntity.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ContinuityOfCareDocumentCCD.LegalAuthenticatorAssignedEntity.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * OperativeNote.LegalAuthenticatorAssignedEntity.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ConsultationNote.LegalAuthenticatorAssignedEntity.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DischargeSummary.LegalAuthenticatorAssignedEntity.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProgressNote.LegalAuthenticatorAssignedEntity.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DiagnosticImagingReport.LegalAuthenticatorAssignedEntity.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * UnstructuredDocument.LegalAuthenticatorAssignedEntity.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * USRealmHeader.LegalAuthenticatorAssignedEntity.templateId 
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
         * <remarks>Relationship: 
         * HistoryAndPhysical.LegalAuthenticatorAssignedEntity.id 
         * Conformance/Cardinality: MANDATORY (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureNote.LegalAuthenticatorAssignedEntity.id 
         * Conformance/Cardinality: MANDATORY (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ContinuityOfCareDocumentCCD.LegalAuthenticatorAssignedEntity.id 
         * Conformance/Cardinality: MANDATORY (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * OperativeNote.LegalAuthenticatorAssignedEntity.id 
         * Conformance/Cardinality: MANDATORY (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ConsultationNote.LegalAuthenticatorAssignedEntity.id 
         * Conformance/Cardinality: MANDATORY (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DischargeSummary.LegalAuthenticatorAssignedEntity.id 
         * Conformance/Cardinality: MANDATORY (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProgressNote.LegalAuthenticatorAssignedEntity.id 
         * Conformance/Cardinality: MANDATORY (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DiagnosticImagingReport.LegalAuthenticatorAssignedEntity.id 
         * Conformance/Cardinality: MANDATORY (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * UnstructuredDocument.LegalAuthenticatorAssignedEntity.id 
         * Conformance/Cardinality: MANDATORY (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * USRealmHeader.LegalAuthenticatorAssignedEntity.id 
         * Conformance/Cardinality: MANDATORY (*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public IList<Identifier> Id {
            get { return this.id.RawList(); }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * HistoryAndPhysical.LegalAuthenticatorAssignedEntity.code 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureNote.LegalAuthenticatorAssignedEntity.code 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ContinuityOfCareDocumentCCD.LegalAuthenticatorAssignedEntity.code 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * OperativeNote.LegalAuthenticatorAssignedEntity.code 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ConsultationNote.LegalAuthenticatorAssignedEntity.code 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DischargeSummary.LegalAuthenticatorAssignedEntity.code 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProgressNote.LegalAuthenticatorAssignedEntity.code 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DiagnosticImagingReport.LegalAuthenticatorAssignedEntity.code 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * UnstructuredDocument.LegalAuthenticatorAssignedEntity.code 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * USRealmHeader.LegalAuthenticatorAssignedEntity.code 
         * Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public CodedTypeR2<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Domainvalue.HealthcareProviderTaxonomy> Code {
            get { return (CodedTypeR2<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Domainvalue.HealthcareProviderTaxonomy>) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * HistoryAndPhysical.LegalAuthenticatorAssignedEntity.addr 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureNote.LegalAuthenticatorAssignedEntity.addr 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ContinuityOfCareDocumentCCD.LegalAuthenticatorAssignedEntity.addr 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * OperativeNote.LegalAuthenticatorAssignedEntity.addr 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ConsultationNote.LegalAuthenticatorAssignedEntity.addr 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DischargeSummary.LegalAuthenticatorAssignedEntity.addr 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProgressNote.LegalAuthenticatorAssignedEntity.addr 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DiagnosticImagingReport.LegalAuthenticatorAssignedEntity.addr 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * UnstructuredDocument.LegalAuthenticatorAssignedEntity.addr 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * USRealmHeader.LegalAuthenticatorAssignedEntity.addr 
         * Conformance/Cardinality: POPULATED (*)</remarks>
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
         * HistoryAndPhysical.LegalAuthenticatorAssignedEntity.telecom 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureNote.LegalAuthenticatorAssignedEntity.telecom 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ContinuityOfCareDocumentCCD.LegalAuthenticatorAssignedEntity.telecom 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * OperativeNote.LegalAuthenticatorAssignedEntity.telecom 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ConsultationNote.LegalAuthenticatorAssignedEntity.telecom 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DischargeSummary.LegalAuthenticatorAssignedEntity.telecom 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProgressNote.LegalAuthenticatorAssignedEntity.telecom 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DiagnosticImagingReport.LegalAuthenticatorAssignedEntity.telecom 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * UnstructuredDocument.LegalAuthenticatorAssignedEntity.telecom 
         * Conformance/Cardinality: POPULATED (*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * USRealmHeader.LegalAuthenticatorAssignedEntity.telecom 
         * Conformance/Cardinality: POPULATED (*)</remarks>
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
         * HistoryAndPhysical.LegalAuthenticatorAssignedEntity.assignedPerson 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureNote.LegalAuthenticatorAssignedEntity.assignedPerson 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ContinuityOfCareDocumentCCD.LegalAuthenticatorAssignedEntity.assignedPerson 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * OperativeNote.LegalAuthenticatorAssignedEntity.assignedPerson 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ConsultationNote.LegalAuthenticatorAssignedEntity.assignedPerson 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DischargeSummary.LegalAuthenticatorAssignedEntity.assignedPerson 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProgressNote.LegalAuthenticatorAssignedEntity.assignedPerson 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DiagnosticImagingReport.LegalAuthenticatorAssignedEntity.assignedPerson 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * UnstructuredDocument.LegalAuthenticatorAssignedEntity.assignedPerson 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * USRealmHeader.LegalAuthenticatorAssignedEntity.assignedPerson 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"assignedPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.LegalAuthenticatorPerson AssignedPerson {
            get { return this.assignedPerson; }
            set { this.assignedPerson = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * HistoryAndPhysical.LegalAuthenticatorAssignedEntity.representedOrganization 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureNote.LegalAuthenticatorAssignedEntity.representedOrganization 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ContinuityOfCareDocumentCCD.LegalAuthenticatorAssignedEntity.representedOrganization 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * OperativeNote.LegalAuthenticatorAssignedEntity.representedOrganization 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ConsultationNote.LegalAuthenticatorAssignedEntity.representedOrganization 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DischargeSummary.LegalAuthenticatorAssignedEntity.representedOrganization 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProgressNote.LegalAuthenticatorAssignedEntity.representedOrganization 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DiagnosticImagingReport.LegalAuthenticatorAssignedEntity.representedOrganization 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * UnstructuredDocument.LegalAuthenticatorAssignedEntity.representedOrganization 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * USRealmHeader.LegalAuthenticatorAssignedEntity.representedOrganization 
         * Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"representedOrganization"})]
        public Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Organization_1 RepresentedOrganization {
            get { return this.representedOrganization; }
            set { this.representedOrganization = value; }
        }

    }

}