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
namespace Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt090107ca;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Merged;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Si.Comt_mt301001ca;
    using System;


    /**
     * <summary>COMT_MT300001CA.Annotation: Comment</summary>
     * 
     * <p>Identifies the comments to be recorded against a 
     * Patient's record.</p> <p>Allows comments to be attached to a 
     * Patient record. A Patient record can pertain to demographic 
     * or clinical (Drug, Condition, Lab, DI, Immunization, etc) 
     * information.</p> COMT_MT300003CA.Annotation: Comment 
     * <p>Identifies the comments to be recorded against a 
     * Patient's record.</p> <p>Allows comments to be attached to a 
     * Patient record. A Patient record can pertain to demographic 
     * or clinical (Drug, Condition, Lab, DI, etc) information.</p> 
     * COMT_MT301001CA.Annotation: Comment <p>Identifies the 
     * comments to be recorded against a Patient's record.</p> 
     * <p>Allows comments to be attached to a Patient record. A 
     * Patient record can pertain to demographic or clinical (Drug, 
     * Condition, Lab, DI, etc) information.</p> 
     * COCT_MT120600CA.Annotation: Notes <p>This is a list of 
     * comments made about the record by providers. Information 
     * captured here includes the provider making the comments; and 
     * excludes information that would render the record invalid. 
     * This information will only be seen when another provider 
     * reviews the record. Urgent or targeted messages should be 
     * sent using a different mechanism (e.g. phone).</p> <p>Public 
     * Health requires all clinical notes to be 'verified' by a 
     * responsible party if not created by physician in charge. 
     * This model conveys the correct semantics, but is 
     * inconsistent with other uses of &quot;author&quot; 
     * participation in POIZ models. Any changes here will have to 
     * be reconciled with other projects using this same cmet.</p> 
     * <p>Allows various Providers to attach comments to an 
     * existing record, and thus improving cross-provider 
     * communications.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT120600CA.Annotation","COMT_MT300001CA.Annotation","COMT_MT300003CA.Annotation","COMT_MT301001CA.Annotation"})]
    public class Comment : MessagePartBean {

        private CV code;
        private ST text;
        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Merged.Patient recordTargetPatient;
        private II id;
        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt090107ca.Provider responsiblePartyAssignedPerson;
        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Merged.RefusedBy author;
        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Merged.RecordedAt location;
        private CV languageCode;
        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Si.Comt_mt301001ca.AnnotatedAct subjectAnnotatedAct;

        public Comment() {
            this.code = new CVImpl();
            this.text = new STImpl();
            this.id = new IIImpl();
            this.languageCode = new CVImpl();
        }
        /**
         * <summary>Business Name: PatientNoteCategory</summary>
         * 
         * <remarks>Un-merged Business Name: PatientNoteCategory 
         * Relationship: COMT_MT300001CA.Annotation.code 
         * Conformance/Cardinality: MANDATORY (1) <p>A coded value 
         * denoting the category of note being attached to a Patient's 
         * record. Categories of note include: General, Medication, 
         * Lab, DI, Immunization, etc</p> <p>Allows patient notes of 
         * different purposes and use, to be attached to a patient. 
         * Attribute is mandatory to ensure that patient notes are 
         * categorized accordingly. This attribute may also be used by 
         * DISs to enforce different access control to different types 
         * of notes.</p> Un-merged Business Name: PatientNoteCategory 
         * Relationship: COMT_MT300003CA.Annotation.code 
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
         * <summary>Un-merged Business Name: PatientNoteText</summary>
         * 
         * <remarks>Relationship: COMT_MT300001CA.Annotation.text 
         * Conformance/Cardinality: MANDATORY (1) <p>Free textual 
         * description of the patient note.</p> <p>Allows a provider to 
         * attach comments to a patient as a whole or to the patient's 
         * profile (such as medication, lab. DI, etc). This attribute 
         * is mandatory because there's no point in having a patient 
         * note unless there's actually content in the note.</p> 
         * Un-merged Business Name: PatientNoteText Relationship: 
         * COMT_MT300003CA.Annotation.text Conformance/Cardinality: 
         * MANDATORY (1) <p>Free textual description of the patient 
         * note.</p> <p>Allows a provider to attach comments to a 
         * patient as a whole or to the patient's profile (such as 
         * medication, lab. DI, etc). This attribute is mandatory 
         * because there's no point in having a patient note unless 
         * there's actually content in the note.</p> Un-merged Business 
         * Name: AnnotationText Relationship: 
         * COMT_MT301001CA.Annotation.text Conformance/Cardinality: 
         * MANDATORY (1) <p>Free text comment to be attached to a 
         * record.</p> <p>Allows a provider to attach arbitrary 
         * comments to clinical records (prescription, dispenses, lab 
         * results, allergies, etc) for communication. This attribute 
         * is mandatory because there's no point in having an 
         * annotation unless there's actually content in the note.</p> 
         * Un-merged Business Name: NoteText Relationship: 
         * COCT_MT120600CA.Annotation.text Conformance/Cardinality: 
         * MANDATORY (1) <p>Free text comments. Additional textual 
         * iinformation entered about an object.</p> <p>Allows a 
         * provider to attach comments to objects for communication. 
         * This attribute is mandatory because there's no point in 
         * having a note class unless there's actually content in the 
         * note.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public String Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Business Name: CommentPertainsTo</summary>
         * 
         * <remarks>Un-merged Business Name: CommentPertainsTo 
         * Relationship: COMT_MT300001CA.RecordTarget.patient 
         * Conformance/Cardinality: MANDATORY (1) <div>This uses 
         * COCT_MT050202CA &ndash; Patient Person&nbsp;Identified 
         * Confirmable.&nbsp;</div> Un-merged Business Name: (no 
         * business name specified) Relationship: 
         * COMT_MT300003CA.RecordTarget.patient 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"recordTarget/patient"})]
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Merged.Patient RecordTargetPatient {
            get { return this.recordTargetPatient; }
            set { this.recordTargetPatient = value; }
        }

        /**
         * <summary>Business Name: PatientNoteId</summary>
         * 
         * <remarks>Un-merged Business Name: PatientNoteId 
         * Relationship: COMT_MT300003CA.Annotation.id 
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
         * <summary>Business Name: SupervisedBy</summary>
         * 
         * <remarks>Un-merged Business Name: SupervisedBy Relationship: 
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
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: COMT_MT300003CA.Annotation.author 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * COCT_MT120600CA.Annotation.author Conformance/Cardinality: 
         * MANDATORY (1) <div>Identifies the provider responsible for 
         * the content of</div> <p>the note.&nbsp;</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Merged.RefusedBy Author {
            get { return this.author; }
            set { this.author = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: COMT_MT300003CA.Annotation.location 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Merged.RecordedAt Location {
            get { return this.location; }
            set { this.location = value; }
        }

        /**
         * <summary>Business Name: WrittenIn</summary>
         * 
         * <remarks>Un-merged Business Name: WrittenIn Relationship: 
         * COMT_MT301001CA.Annotation.languageCode 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: WrittenIn Relationship: 
         * COCT_MT120600CA.Annotation.languageCode 
         * Conformance/Cardinality: POPULATED (1) <p>A coded value 
         * denoting the language in which the note is written.</p> 
         * <p>Allows providers to write notes in the language of their 
         * choice.</p><p>This attribute is marked as 'populated' 
         * because the language of the note must always be 
         * known/available or a null flavor must be specified.</p> 
         * <p>Allows providers to write notes in the language of their 
         * choice.</p><p>This attribute is marked as 'populated' 
         * because the language of the note must always be 
         * known/available or a null flavor must be specified.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"languageCode"})]
        public HumanLanguage LanguageCode {
            get { return (HumanLanguage) this.languageCode.Value; }
            set { this.languageCode.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: COMT_MT301001CA.Subject.annotatedAct 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject/annotatedAct"})]
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Si.Comt_mt301001ca.AnnotatedAct SubjectAnnotatedAct {
            get { return this.subjectAnnotatedAct; }
            set { this.subjectAnnotatedAct = value; }
        }

    }

}