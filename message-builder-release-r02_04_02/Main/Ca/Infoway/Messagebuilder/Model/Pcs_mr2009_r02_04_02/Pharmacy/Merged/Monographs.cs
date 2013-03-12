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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>POME_MT010040CA.Document: Monographs</summary>
     * 
     * <p>Guides providers for specifying optimum use of drugs by 
     * patients. May also guide patients in appropriately using 
     * their medication.</p> <p>Information on the composition and 
     * use of a drug.</p> PORR_MT050016CA.Document: Medication 
     * Documents <p>Guides providers for specifying optimum use of 
     * drugs by patients. May also guide patients in appropriately 
     * using their medication.</p> <p>Information on the 
     * composition and use of a drug.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POME_MT010040CA.Document","PORR_MT050016CA.Document"})]
    public class Monographs : MessagePartBean {

        private II id;
        private CV code;
        private ED<EncapsulatedData> text;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private CV languageCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Merged.AssignedEntity3 authorAssignedEntity;
        private ED<EncapsulatedData> componentDocumentBodyEventText;

        public Monographs() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.text = new EDImpl<EncapsulatedData>();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.languageCode = new CVImpl();
            this.componentDocumentBodyEventText = new EDImpl<EncapsulatedData>();
        }
        /**
         * <summary>Un-merged Business Name: MonographId</summary>
         * 
         * <remarks>Relationship: POME_MT010040CA.Document.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows matching 
         * and replacing of locally-stored monographs.</p><p>This 
         * attribute is marked as 'mandatory', as it is always 
         * available.</p> <p>Unique identifier assigned to a monograph 
         * record.</p> Un-merged Business Name: MedicationDocumentId 
         * Relationship: PORR_MT050016CA.Document.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows matching 
         * and replacing of locally-stored medication 
         * documents.</p><p>This attribute is marked as 'mandatory', as 
         * it is always available.</p> <p>Unique identifier assigned to 
         * a medication document record.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: MonographType</summary>
         * 
         * <remarks>Relationship: POME_MT010040CA.Document.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows monograph 
         * types to be distinguished for display, printing, 
         * etc.</p><p>Code is mandatory because an application can't 
         * know what to do with a monograph without knowing its 
         * type.</p> <p>Distinguishes between different kinds of 
         * documents and monographs. Kinds of monographs include: 
         * Clinical Monograph, Patient Education Monograph, etc.</p> 
         * Un-merged Business Name: MedicationDocumentType 
         * Relationship: PORR_MT050016CA.Document.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows medication 
         * document types to be distinguished for display, printing, 
         * etc. Code is mandatory because an application can't know 
         * what to do with a medication document without knowing its 
         * type.</p> <p>Distinguishes between different kinds of 
         * documents and medication documents. Kinds of medication 
         * documents include: Clinical Medication document, Patient 
         * Education Medication document, Indication Protocol, etc</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActMedicationDocumentCode Code {
            get { return (ActMedicationDocumentCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: MonographContent</summary>
         * 
         * <remarks>Un-merged Business Name: MonographContent 
         * Relationship: POME_MT010040CA.Document.text 
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
         * <summary>Un-merged Business Name: 
         * MonographEffectiveExpiryDate</summary>
         * 
         * <remarks>Relationship: 
         * POME_MT010040CA.Document.effectiveTime 
         * Conformance/Cardinality: POPULATED (1) <p>Indicates currency 
         * of information or when monograph no longer applies. 
         * Different systems may update their monographs at different 
         * times, and it is important to know what version contains the 
         * most current information.</p><p>Monograph effective and/or 
         * expiry date should be available in most situations and is 
         * clinically relevant; thus attribute is marked as 
         * 'populated'.</p> <p>The date on which the information in the 
         * monograph became effective, and/or the date on which the 
         * information in the monograph was superseded</p> Un-merged 
         * Business Name: MedicationDocumentEffectiveExpiryDate 
         * Relationship: PORR_MT050016CA.Document.effectiveTime 
         * Conformance/Cardinality: POPULATED (1) <p>Indicates currency 
         * of information or when monograph no longer applies. 
         * Different systems may update their monographs at different 
         * times, and it is important to know what version contains the 
         * most current information</p><p>Monograph effective and/or 
         * expiry date should be available in most situations and is 
         * clinically relevant; thus attribute is marked as 
         * 'populated'.</p> <p>The date on which the information in the 
         * medication document became effective, and/or the date on 
         * which the information in the medication document was 
         * superseded.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: WrittenIn</summary>
         * 
         * <remarks>Un-merged Business Name: WrittenIn Relationship: 
         * POME_MT010040CA.Document.languageCode 
         * Conformance/Cardinality: POPULATED (1) <p>Allows providers 
         * to request or display monographs in the language of their 
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
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: POME_MT010040CA.Author.assignedEntity 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORR_MT050016CA.Author.assignedEntity 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Merged.AssignedEntity3 AuthorAssignedEntity {
            get { return this.authorAssignedEntity; }
            set { this.authorAssignedEntity = value; }
        }

        /**
         * <summary>Business Name: MedicationDocumentContentLanguage</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * MedicationDocumentContentLanguage Relationship: 
         * PORR_MT050016CA.DocumentBodyEvent.text 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows delivery of 
         * the medication document information to the provider either 
         * embedded or by reference.</p><p>The inclusion of document 
         * language allows providers to determine what language the 
         * medication document is written in.</p><p>The attribute is 
         * mandatory because there is no point in having a medication 
         * document with no content.</p> <p>Includes either the 
         * full-blown content of the medication document (as a PDF, 
         * HTML or HL7 CDA document), or provides a reference to where 
         * the medication document can be accessed on the network via 
         * HTTP or FTP.</p><p>This attribute will also include a coded 
         * value denoting the language in which the medication document 
         * is written.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component/documentBodyEvent/text"})]
        public EncapsulatedData ComponentDocumentBodyEventText {
            get { return this.componentDocumentBodyEventText.Value; }
            set { this.componentDocumentBodyEventText.Value = value; }
        }

    }

}