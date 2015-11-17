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
namespace Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Si.Comt_mt300003ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt050203ca;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt090107ca;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Merged;
    using System;


    /**
     * <summary>Business Name: Comment</summary>
     * 
     * <p>Identifies the comments to be recorded against a 
     * Patient's record.</p> <p>Allows comments to be attached to a 
     * Patient record. A Patient record can pertain to demographic 
     * or clinical (Drug, Condition, Lab, DI, etc) information.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COMT_MT300003CA.Annotation"})]
    public class Comment : MessagePartBean {

        private II id;
        private CV code;
        private ST text;
        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt050203ca.Patient recordTargetPatient;
        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt090107ca.Provider responsiblePartyAssignedPerson;
        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Merged.RefusedBy author;
        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Merged.RecordedAt location;

        public Comment() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.text = new STImpl();
        }
        /**
         * <summary>Business Name: B:Patient Note Id</summary>
         * 
         * <remarks>Relationship: COMT_MT300003CA.Annotation.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Identifier of the 
         * patient note record.</p> <p>Allows for the unique reference 
         * of a patient note and is therefore mandatory.</p><p>Allows 
         * for referencing of a particular patient note and thus allows 
         * for the removal of the note.</p> <p>Allows for the unique 
         * reference of a patient note and is therefore 
         * mandatory.</p><p>Allows for referencing of a particular 
         * patient note and thus allows for the removal of the 
         * note.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: A:Patient Note Category</summary>
         * 
         * <remarks>Relationship: COMT_MT300003CA.Annotation.code 
         * Conformance/Cardinality: MANDATORY (1) <p>A coded value 
         * denoting the category of note being attached to a Patient's 
         * record. Categories of note include: General, Medication, 
         * Lab, DI, etc.</p> <p>Allows patient notes of different 
         * purposes and use, to be attached to a patient. Attribute is 
         * mandatory to ensure that patient notes are categorized 
         * accordingly. This attribute may also be used by DISs to 
         * enforce different access control to different types of 
         * notes.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActPatientAnnotationCode Code {
            get { return (ActPatientAnnotationCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: C:Patient Note Text</summary>
         * 
         * <remarks>Relationship: COMT_MT300003CA.Annotation.text 
         * Conformance/Cardinality: MANDATORY (1) <p>Free textual 
         * description of the patient note.</p> <p>Allows a provider to 
         * attach comments to a patient as a whole or to the patient's 
         * profile (such as medication, lab. DI, etc). This attribute 
         * is mandatory because there's no point in having a patient 
         * note unless there's actually content in the note.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public String Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Relationship: COMT_MT300003CA.RecordTarget.patient</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"recordTarget/patient"})]
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt050203ca.Patient RecordTargetPatient {
            get { return this.recordTargetPatient; }
            set { this.recordTargetPatient = value; }
        }

        /**
         * <summary>Business Name: Supervised By</summary>
         * 
         * <remarks>Relationship: 
         * COMT_MT300003CA.ResponsibleParty.assignedPerson 
         * Conformance/Cardinality: POPULATED (1) <p>&nbsp;Identifies 
         * the provider who is taking responsibility</p> <div>for the 
         * actions of the author.</div></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/assignedPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt090107ca.Provider ResponsiblePartyAssignedPerson {
            get { return this.responsiblePartyAssignedPerson; }
            set { this.responsiblePartyAssignedPerson = value; }
        }

        /**
         * <summary>Relationship: COMT_MT300003CA.Annotation.author</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Merged.RefusedBy Author {
            get { return this.author; }
            set { this.author = value; }
        }

        /**
         * <summary>Relationship: COMT_MT300003CA.Annotation.location</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Merged.RecordedAt Location {
            get { return this.location; }
            set { this.location = value; }
        }

    }

}