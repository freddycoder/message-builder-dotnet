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
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt120600ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt090107ca;
    using System;


    /**
     * <summary>Business Name: Notes</summary>
     * 
     * <p>This is a list of comments made about the record by 
     * providers. Information captured here includes the provider 
     * making the comments; and excludes information that would 
     * render the record invalid. This information will only be 
     * seen when another provider reviews the record. Urgent or 
     * targeted messages should be sent using a different mechanism 
     * (e.g. phone).</p> <p>Public Health requires all clinical 
     * notes to be 'verified' by a responsible party if not created 
     * by physician in charge. This model conveys the correct 
     * semantics, but is inconsistent with other uses of 
     * &quot;author&quot; participation in POIZ models. Any changes 
     * here will have to be reconciled with other projects using 
     * this same cmet.</p> <p>Allows various Providers to attach 
     * comments to an existing record, and thus improving 
     * cross-provider communications.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT120600CA.Annotation"})]
    public class Notes : MessagePartBean {

        private ST text;
        private CV languageCode;
        private TS authorTime;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt090107ca.Provider authorAssignedPerson;

        public Notes() {
            this.text = new STImpl();
            this.languageCode = new CVImpl();
            this.authorTime = new TSImpl();
        }
        /**
         * <summary>Business Name: Note Text</summary>
         * 
         * <remarks>Relationship: COCT_MT120600CA.Annotation.text 
         * Conformance/Cardinality: MANDATORY (1) <p>Free text 
         * comments. Additional textual iinformation entered about an 
         * object.</p> <p>Allows a provider to attach comments to 
         * objects for communication. This attribute is mandatory 
         * because there's no point in having a note class unless 
         * there's actually content in the note.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public String Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Business Name: Written in</summary>
         * 
         * <remarks>Relationship: 
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
         * <summary>Business Name: Note Timestamp</summary>
         * 
         * <remarks>Relationship: COCT_MT120600CA.Author.time 
         * Conformance/Cardinality: MANDATORY (1) <p>The date and time 
         * at which the note was posted.</p> <p>Identifies timing of 
         * the annotation for sorting and for audit 
         * purposes.</p><p>This attribute is mandatory because the time 
         * of creation of the annotation will always be known.</p> 
         * <p>Identifies timing of the annotation for sorting and for 
         * audit purposes.</p><p>This attribute is mandatory because 
         * the time of creation of the annotation will always be 
         * known.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author/time"})]
        public PlatformDate AuthorTime {
            get { return this.authorTime.Value; }
            set { this.authorTime.Value = value; }
        }

        /**
         * <summary>Relationship: COCT_MT120600CA.Author.assignedPerson</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author/assignedPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt090107ca.Provider AuthorAssignedPerson {
            get { return this.authorAssignedPerson; }
            set { this.authorAssignedPerson = value; }
        }

    }

}