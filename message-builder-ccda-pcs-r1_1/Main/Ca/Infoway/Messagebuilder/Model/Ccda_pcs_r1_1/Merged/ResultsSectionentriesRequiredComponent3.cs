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
    using Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Resultssectionentriesrequired;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"ConsultationNote.ResultsSectionentriesRequiredComponent3","ContinuityOfCareDocumentCCD.ResultsSectionentriesRequiredComponent3","HistoryAndPhysical.ResultsSectionentriesRequiredComponent3","ProgressNote.ResultsSectionentriesRequiredComponent3"})]
    public class ResultsSectionentriesRequiredComponent3 : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Progressnote.IComponent3Choice, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Consultationnote.IComponent3Choice, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Historyandphysical.IComponent3Choice, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Continuityofcaredocumentccd.IComponent3Choice {

        private LIST<CS, Code> realmCode;
        private II typeId;
        private LIST<II, Identifier> templateId;
        private Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Resultssectionentriesrequired.Section section;

        public ResultsSectionentriesRequiredComponent3() {
            this.realmCode = new LISTImpl<CS, Code>(typeof(CSImpl));
            this.typeId = new IIImpl();
            this.templateId = new LISTImpl<II, Identifier>(typeof(IIImpl));
        }
        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * ProgressNote.ResultsSectionentriesRequiredComponent3.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ConsultationNote.ResultsSectionentriesRequiredComponent3.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ContinuityOfCareDocumentCCD.ResultsSectionentriesRequiredComponent3.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * HistoryAndPhysical.ResultsSectionentriesRequiredComponent3.realmCode 
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
         * ProgressNote.ResultsSectionentriesRequiredComponent3.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ConsultationNote.ResultsSectionentriesRequiredComponent3.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ContinuityOfCareDocumentCCD.ResultsSectionentriesRequiredComponent3.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * HistoryAndPhysical.ResultsSectionentriesRequiredComponent3.typeId 
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
         * ProgressNote.ResultsSectionentriesRequiredComponent3.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ConsultationNote.ResultsSectionentriesRequiredComponent3.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ContinuityOfCareDocumentCCD.ResultsSectionentriesRequiredComponent3.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * HistoryAndPhysical.ResultsSectionentriesRequiredComponent3.templateId 
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
         * ProgressNote.ResultsSectionentriesRequiredComponent3.section 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ConsultationNote.ResultsSectionentriesRequiredComponent3.section 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ContinuityOfCareDocumentCCD.ResultsSectionentriesRequiredComponent3.section 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * HistoryAndPhysical.ResultsSectionentriesRequiredComponent3.section 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"section"})]
        public Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Resultssectionentriesrequired.Section Section {
            get { return this.section; }
            set { this.section = value; }
        }

    }

}