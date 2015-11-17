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
namespace Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Porr_mt050016ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged;
    using System;


    /**
     * <summary>Business Name: Medication Documents</summary>
     * 
     * <p>Information on the composition and use of a drug.</p> 
     * <p>Guides providers for specifying optimum use of drugs by 
     * patients. May also guide patients in appropriately using 
     * their medication.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORR_MT050016CA.Document"})]
    public class MedicationDocuments : MessagePartBean {

        private II id;
        private CV code;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged.AssignedEntity authorAssignedEntity;
        private ED<EncapsulatedData> componentDocumentBodyEventText;

        public MedicationDocuments() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.componentDocumentBodyEventText = new EDImpl<EncapsulatedData>();
        }
        /**
         * <summary>Business Name: B:Medication Document Id</summary>
         * 
         * <remarks>Relationship: PORR_MT050016CA.Document.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Unique identifier 
         * assigned to a medication document record.</p> 
         * <p>Monograph.monographId</p> <p>Allows matching and 
         * replacing of locally-stored medication documents.</p><p>This 
         * attribute is marked as 'mandatory', as it is always 
         * available.</p> <p>Allows matching and replacing of 
         * locally-stored medication documents.</p><p>This attribute is 
         * marked as 'mandatory', as it is always available.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: A:Medication Document Type</summary>
         * 
         * <remarks>Relationship: PORR_MT050016CA.Document.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Distinguishes 
         * between different kinds of documents and medication 
         * documents. Kinds of medication documents include: Clinical 
         * Medication document, Patient Education Medication document, 
         * Indication Protocol, etc</p> <p>Allows distinction between 
         * Drug Monograph and Patient 
         * Monograph.</p><p>ZPC1.2</p><p>ZPD2.2</p> <p>Allows 
         * distinction between Drug Monograph and Patient 
         * Monograph.</p><p>ZPC1.2</p><p>ZPD2.2</p> <p>Allows 
         * distinction between Drug Monograph and Patient 
         * Monograph.</p><p>ZPC1.2</p><p>ZPD2.2</p> <p>Allows 
         * medication document types to be distinguished for display, 
         * printing, etc. Code is mandatory because an application 
         * can't know what to do with a medication document without 
         * knowing its type.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActMedicationDocumentCode Code {
            get { return (ActMedicationDocumentCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: C:Medication Document 
         * Effective/Expiry Date</summary>
         * 
         * <remarks>Relationship: 
         * PORR_MT050016CA.Document.effectiveTime 
         * Conformance/Cardinality: POPULATED (1) <p>The date on which 
         * the information in the medication document became effective, 
         * and/or the date on which the information in the medication 
         * document was superseded.</p> 
         * <p>Monograph.EffectiveDate</p><p>Monograph.EndDate</p> 
         * <p>Monograph.EffectiveDate</p><p>Monograph.EndDate</p> 
         * <p>Indicates currency of information or when monograph no 
         * longer applies. Different systems may update their 
         * monographs at different times, and it is important to know 
         * what version contains the most current 
         * information</p><p>Monograph effective and/or expiry date 
         * should be available in most situations and is clinically 
         * relevant; thus attribute is marked as 'populated'.</p> 
         * <p>Indicates currency of information or when monograph no 
         * longer applies. Different systems may update their 
         * monographs at different times, and it is important to know 
         * what version contains the most current 
         * information</p><p>Monograph effective and/or expiry date 
         * should be available in most situations and is clinically 
         * relevant; thus attribute is marked as 'populated'.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Relationship: PORR_MT050016CA.Author.assignedEntity</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged.AssignedEntity AuthorAssignedEntity {
            get { return this.authorAssignedEntity; }
            set { this.authorAssignedEntity = value; }
        }

        /**
         * <summary>Business Name: F:Medication Document Content + 
         * Language</summary>
         * 
         * <remarks>Relationship: 
         * PORR_MT050016CA.DocumentBodyEvent.text 
         * Conformance/Cardinality: MANDATORY (1) <p>Includes either 
         * the full-blown content of the medication document (as a PDF, 
         * HTML or HL7 CDA document), or provides a reference to where 
         * the medication document can be accessed on the network via 
         * HTTP or FTP.</p><p>This attribute will also include a coded 
         * value denoting the language in which the medication document 
         * is written.</p> <p>Includes either the full-blown content of 
         * the medication document (as a PDF, HTML or HL7 CDA 
         * document), or provides a reference to where the medication 
         * document can be accessed on the network via HTTP or 
         * FTP.</p><p>This attribute will also include a coded value 
         * denoting the language in which the medication document is 
         * written.</p> <p>Allows delivery of the medication document 
         * information to the provider either embedded or by 
         * reference.</p><p>The inclusion of document language allows 
         * providers to determine what language the medication document 
         * is written in.</p><p>The attribute is mandatory because 
         * there is no point in having a medication document with no 
         * content.</p> <p>Allows delivery of the medication document 
         * information to the provider either embedded or by 
         * reference.</p><p>The inclusion of document language allows 
         * providers to determine what language the medication document 
         * is written in.</p><p>The attribute is mandatory because 
         * there is no point in having a medication document with no 
         * content.</p> <p>Allows delivery of the medication document 
         * information to the provider either embedded or by 
         * reference.</p><p>The inclusion of document language allows 
         * providers to determine what language the medication document 
         * is written in.</p><p>The attribute is mandatory because 
         * there is no point in having a medication document with no 
         * content.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component/documentBodyEvent/text"})]
        public EncapsulatedData ComponentDocumentBodyEventText {
            get { return this.componentDocumentBodyEventText.Value; }
            set { this.componentDocumentBodyEventText.Value = value; }
        }

    }

}