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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pharmacy.Pome_mt010040ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pharmacy.Merged;
    using System;


    /**
     * <summary>Business Name: Monographs</summary>
     * 
     * <p>Guides providers for specifying optimum use of drugs by 
     * patients. May also guide patients in appropriately using 
     * their medication.</p> <p>Information on the composition and 
     * use of a drug.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POME_MT010040CA.Document"})]
    public class Monographs : MessagePartBean {

        private II id;
        private CV code;
        private ED<EncapsulatedData> text;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private CV languageCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pharmacy.Merged.AssignedEntity3 authorAssignedEntity;

        public Monographs() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.text = new EDImpl<EncapsulatedData>();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.languageCode = new CVImpl();
        }
        /**
         * <summary>Business Name: Monograph Id</summary>
         * 
         * <remarks>Relationship: POME_MT010040CA.Document.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows matching 
         * and replacing of locally-stored monographs.</p><p>This 
         * attribute is marked as 'mandatory', as it is always 
         * available.</p> <p>Unique identifier assigned to a monograph 
         * record.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: Monograph Type</summary>
         * 
         * <remarks>Relationship: POME_MT010040CA.Document.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows monograph 
         * types to be distinguished for display, printing, 
         * etc.</p><p>Code is mandatory because an application can't 
         * know what to do with a monograph without knowing its 
         * type.</p> <p>Distinguishes between different kinds of 
         * documents and monographs. Kinds of monographs include: 
         * Clinical Monograph, Patient Education Monograph, etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActMedicationDocumentCode Code {
            get { return (ActMedicationDocumentCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Monograph Content</summary>
         * 
         * <remarks>Relationship: POME_MT010040CA.Document.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows delivery 
         * of the monograph information to the provider either embedded 
         * or by reference</p> <p>Includes either the full-blown 
         * content of the monograph (as a PDF, HTML or HL7 CDA 
         * document), or provides a reference to where the monograph 
         * can be accessed on the network via HTTP or FTP</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public EncapsulatedData Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Business Name: Monograph Effective/Expiry Date</summary>
         * 
         * <remarks>Relationship: 
         * POME_MT010040CA.Document.effectiveTime 
         * Conformance/Cardinality: REQUIRED (1) <p>Indicates currency 
         * of information or when monograph no longer applies. 
         * Different systems may update their monographs at different 
         * times, and it is important to know what version contains the 
         * most current information.</p><p>Monograph effective and/or 
         * expiry date should be available in most situations and is 
         * clinically relevant; thus attribute is marked as 
         * 'populated'.</p> <p>The date on which the information in the 
         * monograph became effective, and/or the date on which the 
         * information in the monograph was superseded</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: Written in</summary>
         * 
         * <remarks>Relationship: POME_MT010040CA.Document.languageCode 
         * Conformance/Cardinality: REQUIRED (1) <p>Allows providers to 
         * request or display monographs in the language of their 
         * choice.</p><p>This attribute is marked as 'populated' 
         * because the language of the monograph must always be 
         * known/available or a null flavor must be specified.</p> <p>A 
         * coded value denoting the language in which the monograph is 
         * written.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"languageCode"})]
        public HumanLanguage LanguageCode {
            get { return (HumanLanguage) this.languageCode.Value; }
            set { this.languageCode.Value = value; }
        }

        /**
         * <summary>Relationship: POME_MT010040CA.Author.assignedEntity</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pharmacy.Merged.AssignedEntity3 AuthorAssignedEntity {
            get { return this.authorAssignedEntity; }
            set { this.authorAssignedEntity = value; }
        }

    }

}