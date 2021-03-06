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
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Document Sections</summary>
     * 
     * <p>Provides contextual information for understanding the 
     * Discharge-Care Summary by sharing a filtered, rendered view 
     * of portions of the patient's record.</p> <p>Used to document 
     * additional relevant information about the patient such as 
     * allergies, medications, problem list, etc.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT220001CA.SubSection"})]
    public class DocumentSections : MessagePartBean {

        private CV code;
        private ST title;
        private ED<EncapsulatedData> text;
        private CS statusCode;
        private SET<CV, Code> confidentialityCode;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Repc_mt220001ca.DocumentSections> component1SubSection;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.IReferenceChoice> component2ReferenceChoice;

        public DocumentSections() {
            this.code = new CVImpl();
            this.title = new STImpl();
            this.text = new EDImpl<EncapsulatedData>();
            this.statusCode = new CSImpl();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.component1SubSection = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Repc_mt220001ca.DocumentSections>();
            this.component2ReferenceChoice = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.IReferenceChoice>();
        }
        /**
         * <summary>Business Name: A: Section Type</summary>
         * 
         * <remarks>Relationship: REPC_MT220001CA.SubSection.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Section Type is 
         * usedfor searching and for organizing Discharge-Care Summary 
         * records as well as sorting them for presentation.</p><p>This 
         * is a key attribute for understanding the type of record and 
         * is therefore mandatory.</p><p>The element uses CWE to allow 
         * for the capture of Section Type concepts not presently 
         * supported by the approved code system(s). In this case, the 
         * human-to-human benefit of capturing additional non-coded 
         * values outweighs the penalties of capturing some information 
         * that will not be amenable to searching or categorizing.</p> 
         * <p>Identifies the type of Discharge-Care Summary represented 
         * by this record.</p><p>Examples: allergy list, problem list, 
         * medication list, etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public DocumentSectionType Code {
            get { return (DocumentSectionType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: B: Section Title</summary>
         * 
         * <remarks>Relationship: REPC_MT220001CA.SubSection.title 
         * Conformance/Cardinality: MANDATORY (1) <p>Provides a human 
         * readable label for the section. Because it is used as part 
         * of the document rendering, the attribute is mandatory.</p> 
         * <p>Represents the label associated with this particular 
         * portion of the document. These are a human-readable 
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
         * <remarks>Relationship: REPC_MT220001CA.SubSection.text 
         * Conformance/Cardinality: MANDATORY (1) <p>Provides a 
         * human-readableview of data that is accessible without 
         * sophisticated PoS applications. Allows data to be filtered 
         * and rendered in a manner to focus on the content deemed 
         * relevant by the author of the document. Because it conveys 
         * the content, the attribute must be mandatory.</p> 
         * <p>Represents the renderedtext content for the section.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public EncapsulatedData Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Business Name: Document Section Status</summary>
         * 
         * <remarks>Relationship: REPC_MT220001CA.SubSection.statusCode 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: Document Section Masking Indicators</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT220001CA.SubSection.confidentialityCode 
         * Conformance/Cardinality: REQUIRED (0-2)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_BasicConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_BasicConfidentialityKind>(); }
        }

        /**
         * <summary>Relationship: REPC_MT220001CA.Component8.subSection</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component1/subSection"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Repc_mt220001ca.DocumentSections> Component1SubSection {
            get { return this.component1SubSection; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT220001CA.Component7.referenceChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component2/referenceChoice"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.IReferenceChoice> Component2ReferenceChoice {
            get { return this.component2ReferenceChoice; }
        }

    }

}