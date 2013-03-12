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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: DocumentSections</summary>
     * 
     * <remarks>REPC_MT220001CA.SubSection: Document Sections 
     * <p>Provides contextual information for understanding the 
     * Discharge-Care Summary by sharing a filtered, rendered view 
     * of portions of the patient's record.</p> <p>Used to document 
     * additional relevant information about the patient such as 
     * allergies, medications, problem list, etc.</p> 
     * REPC_MT230003CA.SubSection: Document Sections <p>Provides 
     * contextual information for understanding the Clinical 
     * Observation Document by sharing a filtered, rendered view of 
     * portions of the patient's record.</p> <p>Used to document 
     * additional relevant information about the patient such as 
     * allergies, medications, problem list, etc.</p> 
     * REPC_MT220003CA.SubSection: Document Sections <p>Provides 
     * contextual information for understanding the Discharge-Care 
     * Summary by sharing a filtered, rendered view of portions of 
     * the patient's record.</p> <p>Used to document additional 
     * relevant information about the patient such as allergies, 
     * medications, problem list, etc.</p> 
     * REPC_MT210003CA.SubSection: Document Sections <p>Provides 
     * contextual information for understanding the Referral by 
     * sharing a filtered, rendered view of portions of the 
     * patient's record.</p> <p>Used to document additional 
     * relevant information about the patient such as allergies, 
     * medications, problem list, etc.</p> 
     * REPC_MT230001CA.SubSection: Document Sections <p>Provides 
     * contextual information for understanding the Clinical 
     * Observation Document by sharing a filtered, rendered view of 
     * portions of the patient's record.</p> <p>Used to document 
     * additional relevant information about the patient such as 
     * allergies, medications, problem list, etc.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT210001CA.SubSection","REPC_MT210003CA.SubSection","REPC_MT220001CA.SubSection","REPC_MT220003CA.SubSection","REPC_MT230001CA.SubSection","REPC_MT230003CA.SubSection"})]
    public class DocumentSections : MessagePartBean {

        private CV code;
        private ST title;
        private ED<EncapsulatedData> text;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.Reference> componentReference;

        public DocumentSections() {
            this.code = new CVImpl();
            this.title = new STImpl();
            this.text = new EDImpl<EncapsulatedData>();
            this.componentReference = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.Reference>();
        }
        /**
         * <summary>Business Name: SectionType</summary>
         * 
         * <remarks>Un-merged Business Name: SectionType Relationship: 
         * REPC_MT220001CA.SubSection.code Conformance/Cardinality: 
         * MANDATORY (1) <p> <i>Section Type is used for searching and 
         * for organizing Discharge-Care Summary records as well as 
         * sorting them for presentation.</i> </p><p> <i>This is a key 
         * attribute for understanding the type of record and is 
         * therefore mandatory.</i> </p><p> <i>The element uses CWE to 
         * allow for the capture of Section Type concepts not presently 
         * supported by the approved code system(s). In this case, the 
         * human-to-human benefit of capturing additional non-coded 
         * values outweighs the penalties of capturing some information 
         * that will not be amenable to searching or categorizing.</i> 
         * </p> <p> <i>Identifies the type of Discharge-Care Summary 
         * represented by this record.</i> </p><p>Examples: allergy 
         * list, problem list, medication list, etc.</p> Un-merged 
         * Business Name: SectionType Relationship: 
         * REPC_MT230003CA.SubSection.code Conformance/Cardinality: 
         * MANDATORY (1) <p> <i>Section Type is used for searching and 
         * for organizing Clinical Observation Document records as well 
         * as sorting them for presentation.</i> </p><p> <i>This is a 
         * key attribute for understanding the type of record and is 
         * therefore mandatory.</i> </p><p> <i>The element uses CWE to 
         * allow for the capture of Section Type concepts not presently 
         * supported by the approved code system(s). In this case, the 
         * human-to-human benefit of capturing additional non-coded 
         * values outweighs the penalties of capturing some information 
         * that will not be amenable to searching or categorizing.</i> 
         * </p> <p> <i>Identifies the type of Clinical Observation 
         * Document represented by this record.</i> </p><p>Examples: 
         * allergy list, problem list, medication list, etc.</p> 
         * Un-merged Business Name: SectionType Relationship: 
         * REPC_MT210003CA.SubSection.code Conformance/Cardinality: 
         * MANDATORY (1) <p> <i>Section Type is used for searching and 
         * for organizing Referral records as well as sorting them for 
         * presentation.</i> </p><p> <i>This is a key attribute for 
         * understanding the type of record and is therefore 
         * mandatory.</i> </p><p> <i>The element uses CWE to allow for 
         * the capture of Section Type concepts not presently supported 
         * by the approved code system(s). In this case, the 
         * human-to-human benefit of capturing additional non-coded 
         * values outweighs the penalties of capturing some information 
         * that will not be amenable to searching or categorizing.</i> 
         * </p> <p> <i>Identifies the type of Referral represented by 
         * this record.</i> </p><p>Examples: allergy list, problem 
         * list, medication list, etc.</p> Un-merged Business Name: 
         * SectionType Relationship: REPC_MT220003CA.SubSection.code 
         * Conformance/Cardinality: MANDATORY (1) <p> <i>Section Type 
         * is used for searching and for organizing Discharge-Care 
         * Summary records as well as sorting them for 
         * presentation.</i> </p><p> <i>This is a key attribute for 
         * understanding the type of record and is therefore 
         * mandatory.</i> </p><p> <i>The element uses CWE to allow for 
         * the capture of Section Type concepts not presently supported 
         * by the approved code system(s). In this case, the 
         * human-to-human benefit of capturing additional non-coded 
         * values outweighs the penalties of capturing some information 
         * that will not be amenable to searching or categorizing.</i> 
         * </p> <p> <i>Identifies the type of Discharge-Care Summary 
         * represented by this record.</i> </p><p>Examples: allergy 
         * list, problem list, medication list, etc.</p> Un-merged 
         * Business Name: SectionType Relationship: 
         * REPC_MT230001CA.SubSection.code Conformance/Cardinality: 
         * MANDATORY (1) <p> <i>Section Type is used for searching and 
         * for organizing Clinical Observation Document records as well 
         * as sorting them for presentation.</i> </p><p> <i>This is a 
         * key attribute for understanding the type of record and is 
         * therefore mandatory.</i> </p><p> <i>The element uses CWE to 
         * allow for the capture of Section Type concepts not presently 
         * supported by the approved code system(s). In this case, the 
         * human-to-human benefit of capturing additional non-coded 
         * values outweighs the penalties of capturing some information 
         * that will not be amenable to searching or categorizing.</i> 
         * </p> <p> <i>Identifies the type of Clinical Observation 
         * Document represented by this record.</i> </p><p>Examples: 
         * allergy list, problem list, medication list, etc.</p> 
         * Un-merged Business Name: SectionType Relationship: 
         * REPC_MT210001CA.SubSection.code Conformance/Cardinality: 
         * MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public DocumentSectionType Code {
            get { return (DocumentSectionType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: SectionTitle</summary>
         * 
         * <remarks>Un-merged Business Name: SectionTitle Relationship: 
         * REPC_MT220001CA.SubSection.title Conformance/Cardinality: 
         * MANDATORY (1) <p>Provides a human readable label for the 
         * section. Because it is used as part of the document 
         * rendering, the attribute is mandatory.</p> <p>Represents the 
         * label associated with this particular portion of the 
         * document. These are a human-readable equivalents to the 
         * Section Type code. E.g. &quot;Allergies&quot;, 
         * &quot;Assessment&quot;, &quot;Recommendations&quot;, 
         * etc.</p> Un-merged Business Name: SectionTitle Relationship: 
         * REPC_MT230003CA.SubSection.title Conformance/Cardinality: 
         * MANDATORY (1) <p>Provides a human readable label for the 
         * section. Because it is used as part of the document 
         * rendering, the attribute is mandatory.</p> <p>Represents the 
         * label associated with this particular portion of the 
         * document. These are a human-readable equivalents to the 
         * Section Type code. E.g. &quot;Allergies&quot;, 
         * &quot;Assessment&quot;, &quot;Recommendations&quot;, 
         * etc.</p> Un-merged Business Name: SectionTitle Relationship: 
         * REPC_MT210003CA.SubSection.title Conformance/Cardinality: 
         * MANDATORY (1) <p>Provides a human readable label for the 
         * section. Because it is used as part of the document 
         * rendering, the attribute is mandatory.</p> <p>Represents the 
         * label associated with this particular portion of the 
         * document. These are human-readable equivalents to the 
         * Section Type code. E.g. &quot;Allergies&quot;, 
         * &quot;Assessment&quot;, &quot;Recommendations&quot;, 
         * etc.</p> Un-merged Business Name: SectionTitle Relationship: 
         * REPC_MT220003CA.SubSection.title Conformance/Cardinality: 
         * MANDATORY (1) <p>Provides a human readable label for the 
         * section. Because it is used as part of the document 
         * rendering, the attribute is mandatory.</p> <p>Represents the 
         * label associated with this particular portion of the 
         * document. These are a human-readable equivalents to the 
         * Section Type code. E.g. &quot;Allergies&quot;, 
         * &quot;Assessment&quot;, &quot;Recommendations&quot;, 
         * etc.</p> Un-merged Business Name: SectionTitle Relationship: 
         * REPC_MT230001CA.SubSection.title Conformance/Cardinality: 
         * MANDATORY (1) <p>Provides a human readable label for the 
         * section. Because it is used as part of the document 
         * rendering, the attribute is mandatory.</p> <p>Represents the 
         * label associated with this particular portion of the 
         * document. These are a human-readable equivalents to the 
         * Section Type code. E.g. &quot;Allergies&quot;, 
         * &quot;Assessment&quot;, &quot;Recommendations&quot;, 
         * etc.</p> Un-merged Business Name: SectionTitle Relationship: 
         * REPC_MT210001CA.SubSection.title Conformance/Cardinality: 
         * MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"title"})]
        public String Title {
            get { return this.title.Value; }
            set { this.title.Value = value; }
        }

        /**
         * <summary>Business Name: SectionContent</summary>
         * 
         * <remarks>Un-merged Business Name: SectionContent 
         * Relationship: REPC_MT220001CA.SubSection.text 
         * Conformance/Cardinality: MANDATORY (1) <p>Provides a 
         * human-readable view of data that is accessible without 
         * sophisticated PoS applications. Allows data to be filtered 
         * and rendered in a manner to focus on the content deemed 
         * relevant by the author of the document. Because it conveys 
         * the content, the attribute must be mandatory.</p> 
         * <p>Represents the rendered text content for the section.</p> 
         * Un-merged Business Name: SectionContent Relationship: 
         * REPC_MT230003CA.SubSection.text Conformance/Cardinality: 
         * MANDATORY (1) <p>Provides a human-readable view of data that 
         * is accessible without sophisticated PoS applications. Allows 
         * data to be filtered and rendered in a manner to focus on the 
         * content deemed relevant by the author of the document. 
         * Because it conveys the content, the attribute must be 
         * mandatory.</p> <p>Represents the rendered text content for 
         * the section.</p> Un-merged Business Name: SectionContent 
         * Relationship: REPC_MT210003CA.SubSection.text 
         * Conformance/Cardinality: MANDATORY (1) <p>Provides a 
         * human-readable view of data that is accessible without 
         * sophisticated PoS applications. Allows data to be filtered 
         * and rendered in a manner to focus on the content deemed 
         * relevant by the author of the document. Because it conveys 
         * the content, the attribute must be mandatory.</p> 
         * <p>Represents the rendered text content for the section.</p> 
         * Un-merged Business Name: SectionContent Relationship: 
         * REPC_MT220003CA.SubSection.text Conformance/Cardinality: 
         * MANDATORY (1) <p>Provides a human-readable view of data that 
         * is accessible without sophisticated PoS applications. Allows 
         * data to be filtered and rendered in a manner to focus on the 
         * content deemed relevant by the author of the document. 
         * Because it conveys the content, the attribute must be 
         * mandatory.</p> <p>Represents the rendered text content for 
         * the section.</p> Un-merged Business Name: SectionContent 
         * Relationship: REPC_MT230001CA.SubSection.text 
         * Conformance/Cardinality: MANDATORY (1) <p>Provides a 
         * human-readable view of data that is accessible without 
         * sophisticated PoS applications. Allows data to be filtered 
         * and rendered in a manner to focus on the content deemed 
         * relevant by the author of the document. Because it conveys 
         * the content, the attribute must be mandatory.</p> 
         * <p>Represents the rendered text content for the section.</p> 
         * Un-merged Business Name: SectionContent Relationship: 
         * REPC_MT210001CA.SubSection.text Conformance/Cardinality: 
         * MANDATORY (1)</remarks>
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
         * <remarks>Relationship: REPC_MT220001CA.Component7.reference 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT230003CA.Component7.reference 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT210003CA.Component7.reference 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT220003CA.Component7.reference 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT230001CA.Component7.reference 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT210001CA.Component7.reference 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component/reference"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.Reference> ComponentReference {
            get { return this.componentReference; }
        }

    }

}