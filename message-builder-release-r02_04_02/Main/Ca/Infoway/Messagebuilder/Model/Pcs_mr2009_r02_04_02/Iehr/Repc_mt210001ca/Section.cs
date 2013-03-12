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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Repc_mt210001ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT210001CA.Section"})]
    public class Section : MessagePartBean {

        private ED<EncapsulatedData> text;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Repc_mt210001ca.IDocumentContent component1DocumentContent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.DocumentSections> component2SubSection;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.Reference> component3Reference;

        public Section() {
            this.text = new EDImpl<EncapsulatedData>();
            this.component2SubSection = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.DocumentSections>();
            this.component3Reference = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.Reference>();
        }
        /**
         * <summary>Business Name: M: Document Overview Content</summary>
         * 
         * <remarks>Relationship: REPC_MT210001CA.Section.text 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public EncapsulatedData Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT210001CA.Component4.documentContent</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component1/documentContent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Repc_mt210001ca.IDocumentContent Component1DocumentContent {
            get { return this.component1DocumentContent; }
            set { this.component1DocumentContent = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.Referral Component1DocumentContentAsPatientCareProvisionRequest {
            get { return this.component1DocumentContent is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.Referral ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.Referral) this.component1DocumentContent : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.Referral) null; }
        }
        public bool HasComponent1DocumentContentAsPatientCareProvisionRequest() {
            return (this.component1DocumentContent is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.Referral);
        }

        /**
         * <summary>Relationship: REPC_MT210001CA.Component.subSection</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component2/subSection"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.DocumentSections> Component2SubSection {
            get { return this.component2SubSection; }
        }

        /**
         * <summary>Relationship: REPC_MT210001CA.Component5.reference</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component3/reference"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.Reference> Component3Reference {
            get { return this.component3Reference; }
        }

    }

}