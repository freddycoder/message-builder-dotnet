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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Ra.Rcmr_mt010002ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Ra.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Keyword</summary>
     * 
     * <p>Allows a patient to control access to their health 
     * information. Provides authorization for providers to view 
     * patient information.</p> <p>Information pertaining to a 
     * patient's secret password used to control access to his/her 
     * health information.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"RCMR_MT010002CA.KeywordEvent"})]
    public class Keyword : MessagePartBean {

        private ST authorSignatureText;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.IConsenter authorConsenter;
        private IList<CV> subjectRecordTypeCode;

        public Keyword() {
            this.authorSignatureText = new STImpl();
            this.subjectRecordTypeCode = new List<CV>();
        }
        /**
         * <summary>Business Name: Keyword</summary>
         * 
         * <remarks>Relationship: RCMR_MT010002CA.Author.signatureText 
         * Conformance/Cardinality: POPULATED (1) <p>Allows patients to 
         * change their keyword. If explicitly set to null, removes the 
         * keyword for the identified record types. Because of this, 
         * the attribute is set to 'populated'.</p> <p>Indicate the 
         * keyword associated with a particular consent.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author/signatureText"})]
        public String AuthorSignatureText {
            get { return this.authorSignatureText.Value; }
            set { this.authorSignatureText.Value = value; }
        }

        /**
         * <summary>Relationship: RCMR_MT010002CA.Author.consenter</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author/consenter"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.IConsenter AuthorConsenter {
            get { return this.authorConsenter; }
            set { this.authorConsenter = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Ra.Merged.Patient AuthorConsenterAsPatient {
            get { return this.authorConsenter is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Ra.Merged.Patient ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Ra.Merged.Patient) this.authorConsenter : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Ra.Merged.Patient) null; }
        }
        public bool HasAuthorConsenterAsPatient() {
            return (this.authorConsenter is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Ra.Merged.Patient);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.RelatedPerson AuthorConsenterAsPersonalRelationship {
            get { return this.authorConsenter is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.RelatedPerson ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.RelatedPerson) this.authorConsenter : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.RelatedPerson) null; }
        }
        public bool HasAuthorConsenterAsPersonalRelationship() {
            return (this.authorConsenter is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.RelatedPerson);
        }

        /**
         * <summary>Business Name: B:Consent Information Types</summary>
         * 
         * <remarks>Relationship: RCMR_MT010002CA.RecordType.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Different keywords 
         * may be needed to access different types of patient 
         * information (e.g. demographics, medications, allergies, lab 
         * results). Understanding the type of information the keyword 
         * applies to is critical, and therefore the attribute is 
         * mandatory.</p> <p>The type of patient information that can 
         * be accessed or modified. Examples are: demographics, 
         * medications, lab, DI, etc</p><p>The keyword revisioning 
         * process may also involve revising the list of information 
         * types covered by the keyword.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject/recordType/code"})]
        public IList<ActInformationAccessCode> SubjectRecordTypeCode {
            get { return new RawListWrapper<CV, ActInformationAccessCode>(subjectRecordTypeCode, typeof(CVImpl)); }
        }

    }

}