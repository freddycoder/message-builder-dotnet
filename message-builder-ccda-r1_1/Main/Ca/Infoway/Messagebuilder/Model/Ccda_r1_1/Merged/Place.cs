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
namespace Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"BaseModel.Place","ConsultationNote.Place","ContinuityOfCareDocumentCCD.Place","DiagnosticImagingReport.Place","DischargeSummary.Place","HistoryAndPhysical.Place","OperativeNote.Place","ProcedureNote.Place","ProgressNote.Place","USRealmHeader.Place","UnstructuredDocument.Place"})]
    public class Place : MessagePartBean {

        private LIST<CS_R2<Code>, CodedTypeR2<Code>> realmCode;
        private II typeId;
        private LIST<II, Identifier> templateId;
        private EN<EntityName> name;
        private AD addr;

        public Place() {
            this.realmCode = new LISTImpl<CS_R2<Code>, CodedTypeR2<Code>>(typeof(CS_R2Impl<Code>));
            this.typeId = new IIImpl();
            this.templateId = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.name = new ENImpl<EntityName>();
            this.addr = new ADImpl();
        }
        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: HistoryAndPhysical.Place.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ConsultationNote.Place.realmCode Conformance/Cardinality: 
         * OPTIONAL (0-*) Un-merged Business Name: (no business name 
         * specified) Relationship: ProcedureNote.Place.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * UnstructuredDocument.Place.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ContinuityOfCareDocumentCCD.Place.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProgressNote.Place.realmCode Conformance/Cardinality: 
         * OPTIONAL (0-*) Un-merged Business Name: (no business name 
         * specified) Relationship: OperativeNote.Place.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * USRealmHeader.Place.realmCode Conformance/Cardinality: 
         * OPTIONAL (0-*) Un-merged Business Name: (no business name 
         * specified) Relationship: BaseModel.Place.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DiagnosticImagingReport.Place.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DischargeSummary.Place.realmCode Conformance/Cardinality: 
         * OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"realmCode"})]
        public IList<CodedTypeR2<Code>> RealmCode {
            get { return this.realmCode.RawList<CodedTypeR2<Code>>(); }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: HistoryAndPhysical.Place.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ConsultationNote.Place.typeId Conformance/Cardinality: 
         * OPTIONAL (0-1) Un-merged Business Name: (no business name 
         * specified) Relationship: ProcedureNote.Place.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * UnstructuredDocument.Place.typeId Conformance/Cardinality: 
         * OPTIONAL (0-1) Un-merged Business Name: (no business name 
         * specified) Relationship: 
         * ContinuityOfCareDocumentCCD.Place.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProgressNote.Place.typeId Conformance/Cardinality: OPTIONAL 
         * (0-1) Un-merged Business Name: (no business name specified) 
         * Relationship: OperativeNote.Place.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * USRealmHeader.Place.typeId Conformance/Cardinality: OPTIONAL 
         * (0-1) Un-merged Business Name: (no business name specified) 
         * Relationship: BaseModel.Place.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DiagnosticImagingReport.Place.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DischargeSummary.Place.typeId Conformance/Cardinality: 
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
         * <remarks>Relationship: HistoryAndPhysical.Place.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ConsultationNote.Place.templateId Conformance/Cardinality: 
         * OPTIONAL (0-*) Un-merged Business Name: (no business name 
         * specified) Relationship: ProcedureNote.Place.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * UnstructuredDocument.Place.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ContinuityOfCareDocumentCCD.Place.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProgressNote.Place.templateId Conformance/Cardinality: 
         * OPTIONAL (0-*) Un-merged Business Name: (no business name 
         * specified) Relationship: OperativeNote.Place.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * USRealmHeader.Place.templateId Conformance/Cardinality: 
         * OPTIONAL (0-*) Un-merged Business Name: (no business name 
         * specified) Relationship: BaseModel.Place.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DiagnosticImagingReport.Place.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DischargeSummary.Place.templateId Conformance/Cardinality: 
         * OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"templateId"})]
        public IList<Identifier> TemplateId {
            get { return this.templateId.RawList(); }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: HistoryAndPhysical.Place.name 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ConsultationNote.Place.name Conformance/Cardinality: 
         * OPTIONAL (0-1) Un-merged Business Name: (no business name 
         * specified) Relationship: ProcedureNote.Place.name 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * UnstructuredDocument.Place.name Conformance/Cardinality: 
         * OPTIONAL (0-1) Un-merged Business Name: (no business name 
         * specified) Relationship: 
         * ContinuityOfCareDocumentCCD.Place.name 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProgressNote.Place.name Conformance/Cardinality: OPTIONAL 
         * (0-1) Un-merged Business Name: (no business name specified) 
         * Relationship: OperativeNote.Place.name 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * USRealmHeader.Place.name Conformance/Cardinality: OPTIONAL 
         * (0-1) Un-merged Business Name: (no business name specified) 
         * Relationship: BaseModel.Place.name Conformance/Cardinality: 
         * OPTIONAL (0-1) Un-merged Business Name: (no business name 
         * specified) Relationship: DiagnosticImagingReport.Place.name 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DischargeSummary.Place.name Conformance/Cardinality: 
         * OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"name"})]
        public EntityName Name {
            get { return this.name.Value; }
            set { this.name.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: HistoryAndPhysical.Place.addr 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ConsultationNote.Place.addr Conformance/Cardinality: 
         * POPULATED (1) Un-merged Business Name: (no business name 
         * specified) Relationship: ProcedureNote.Place.addr 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * UnstructuredDocument.Place.addr Conformance/Cardinality: 
         * POPULATED (1) Un-merged Business Name: (no business name 
         * specified) Relationship: 
         * ContinuityOfCareDocumentCCD.Place.addr 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProgressNote.Place.addr Conformance/Cardinality: POPULATED 
         * (1) Un-merged Business Name: (no business name specified) 
         * Relationship: OperativeNote.Place.addr 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * USRealmHeader.Place.addr Conformance/Cardinality: POPULATED 
         * (1) Un-merged Business Name: (no business name specified) 
         * Relationship: BaseModel.Place.addr Conformance/Cardinality: 
         * OPTIONAL (0-1) Un-merged Business Name: (no business name 
         * specified) Relationship: DiagnosticImagingReport.Place.addr 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * DischargeSummary.Place.addr Conformance/Cardinality: 
         * POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"addr"})]
        public PostalAddress Addr {
            get { return this.addr.Value; }
            set { this.addr.Value = value; }
        }

    }

}