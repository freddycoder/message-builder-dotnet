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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Repc_mt210003ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Document Sections</summary>
     * 
     * <p>Provides contextual information for understanding the 
     * Referral by sharing a filtered, rendered view of portions of 
     * the patient's record.</p> <p>Used to document additional 
     * relevant information about the patient such as allergies, 
     * medications, problem list, etc.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT210003CA.SubSection"})]
    public class DocumentSections : MessagePartBean {

        private CV code;
        private ST title;
        private ED<EncapsulatedData> text;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.Reference> componentReference;

        public DocumentSections() {
            this.code = new CVImpl();
            this.title = new STImpl();
            this.text = new EDImpl<EncapsulatedData>();
            this.componentReference = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.Reference>();
        }
        /**
         * <summary>Business Name: A: Section Type</summary>
         * 
         * <remarks>Relationship: REPC_MT210003CA.SubSection.code 
         * Conformance/Cardinality: MANDATORY (1) <p> <i>Section Type 
         * is used for searching and for organizing Referral records as 
         * well as sorting them for presentation.</i> </p><p> <i>This 
         * is a key attribute for understanding the type of record and 
         * is therefore mandatory.</i> </p><p> <i>The element uses CWE 
         * to allow for the capture of Section Type concepts not 
         * presently supported by the approved code system(s). In this 
         * case, the human-to-human benefit of capturing additional 
         * non-coded values outweighs the penalties of capturing some 
         * information that will not be amenable to searching or 
         * categorizing.</i> </p> <p> <i>Identifies the type of 
         * Referral represented by this record.</i> </p><p>Examples: 
         * allergy list, problem list, medication list, etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public DocumentSectionType Code {
            get { return (DocumentSectionType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: B: Section Title</summary>
         * 
         * <remarks>Relationship: REPC_MT210003CA.SubSection.title 
         * Conformance/Cardinality: MANDATORY (1) <p>Provides a human 
         * readable label for the section. Because it is used as part 
         * of the document rendering, the attribute is mandatory.</p> 
         * <p>Represents the label associated with this particular 
         * portion of the document. These are human-readable 
         * equivalents to the Section Type code. E.g. 
         * &quot;Allergies&quot;, &quot;Assessment&quot;, 
         * &quot;Recommendations&quot;, etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"title"})]
        public String Title {
            get { return this.title.Value; }
            set { this.title.Value = value; }
        }

        /**
         * <summary>Business Name: M: Section Content</summary>
         * 
         * <remarks>Relationship: REPC_MT210003CA.SubSection.text 
         * Conformance/Cardinality: MANDATORY (1) <p>Provides a 
         * human-readable view of data that is accessible without 
         * sophisticated PoS applications. Allows data to be filtered 
         * and rendered in a manner to focus on the content deemed 
         * relevant by the author of the document. Because it conveys 
         * the content, the attribute must be mandatory.</p> 
         * <p>Represents the rendered text content for the section.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public EncapsulatedData Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Relationship: REPC_MT210003CA.Component7.reference</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component/reference"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.Reference> ComponentReference {
            get { return this.componentReference; }
        }

    }

}