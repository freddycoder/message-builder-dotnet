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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT230001CA.Section","REPC_MT230002CA.Section","REPC_MT230003CA.Section"})]
    public class Section_3 : MessagePartBean {

        private ED<EncapsulatedData> text;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.IDocumentContent_3 component1DocumentContent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.DocumentSections> component2SubSection;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.Reference> component3Reference;

        public Section_3() {
            this.text = new EDImpl<EncapsulatedData>();
            this.component2SubSection = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.DocumentSections>();
            this.component3Reference = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.Reference>();
        }
        /**
         * <summary>Business Name: DocumentOverviewContent</summary>
         * 
         * <remarks>Un-merged Business Name: DocumentOverviewContent 
         * Relationship: REPC_MT230003CA.Section.text 
         * Conformance/Cardinality: MANDATORY (1) <p>Represents the 
         * principle content of the document and therefore is 
         * mandatory.</p> <p>There is no guidance provided within the 
         * standard on how report content should be organized or 
         * formatted. Guidance may be provided by professional 
         * colleges, specialty groups or others.</p> <p>Provides the 
         * primary rendered textual content of the document.</p><p>E.g. 
         * The cover letter for a referral, the overview portion of a 
         * report, etc.</p> Un-merged Business Name: 
         * DocumentOverviewContent Relationship: 
         * REPC_MT230001CA.Section.text Conformance/Cardinality: 
         * MANDATORY (1) <p>Represents the principle content of the 
         * document and therefore is mandatory.</p> <p>There is no 
         * guidance provided within the standard on how report content 
         * should be organized or formatted. Guidance may be provided 
         * by professional colleges, specialty groups or others.</p> 
         * <p>Provides the primary rendered textual content of the 
         * document.</p><p>E.g. The cover letter for a referral, the 
         * overview portion of a report, etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public EncapsulatedData Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT230003CA.Component4.documentContent 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT230002CA.Component4.documentContent 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT230001CA.Component4.documentContent 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component/documentContent","component1/documentContent"})]
        [Hl7MapByPartType(Name="component", Type="REPC_MT230002CA.Component4")]
        [Hl7MapByPartType(Name="component/documentContent", Type="REPC_MT230002CA.DocumentContent")]
        [Hl7MapByPartType(Name="component1", Type="REPC_MT230001CA.Component4")]
        [Hl7MapByPartType(Name="component1", Type="REPC_MT230003CA.Component4")]
        [Hl7MapByPartType(Name="component1/documentContent", Type="REPC_MT230001CA.DocumentContent")]
        [Hl7MapByPartType(Name="component1/documentContent", Type="REPC_MT230003CA.DocumentContent")]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.IDocumentContent_3 Component1DocumentContent {
            get { return this.component1DocumentContent; }
            set { this.component1DocumentContent = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: REPC_MT230003CA.Component.subSection 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT230001CA.Component.subSection 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component2/subSection"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.DocumentSections> Component2SubSection {
            get { return this.component2SubSection; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: REPC_MT230003CA.Component5.reference 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT230001CA.Component5.reference 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component3/reference"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.Reference> Component3Reference {
            get { return this.component3Reference; }
        }

    }

}