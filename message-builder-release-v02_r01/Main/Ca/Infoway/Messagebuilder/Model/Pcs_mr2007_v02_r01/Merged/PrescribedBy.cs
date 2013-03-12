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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>PORX_MT060040CA.Author4: *b:prescribed by</summary>
     * 
     * <p>To be a legal order, the person responsible for its 
     * creation must be identified. Thus the association is 
     * mandatory.</p> <p>This is the provider who authorized the 
     * device to be dispensed to the patient.</p> 
     * PORX_MT060340CA.Author4: *b:prescribed by <p>To be a legal 
     * order, the person responsible for its creation must be 
     * identified. Thus the association is mandatory.</p> <p>This 
     * is the provider who authorized the medication to be 
     * dispensed to the patient.</p> RCMR_MT010001CA.Author2: 
     * c:overridden by <p>Clinical circumstances may demand that a 
     * patient's information be accessed without consent to ensure 
     * patient safety.</p> <p>Indicates that information access was 
     * approved by a provider rather than a patient. I.e. This is 
     * an override rather than an actual consent.</p> 
     * PORX_MT060160CA.Author4: *b:prescribed by <p>To be a legal 
     * order, the person responsible for its creation must be 
     * identified. Thus the association is mandatory.</p> <p>This 
     * is the provider who authorized the medication to be 
     * dispensed to the patient.</p> PORX_MT060190CA.Author2: 
     * *c:prescribed by <p>To be a legal order, the person 
     * responsible for its creation must be identified. Thus the 
     * association is mandatory.</p> <p>This is the provider who 
     * authorized the medication to be dispensed to the 
     * patient.</p> PORX_MT060060CA.Author2: *b:prescribed by <p>To 
     * be a legal order, the person responsible for its creation 
     * must be identified. Thus the association is mandatory.</p> 
     * <p>This is the provider who authorized the device to be 
     * dispensed to the patient.</p> COCT_MT260010CA.Author2: is 
     * created by <p>ZPE.1</p> <p>ZDU.5.1</p> 
     * <p>Contraindication.dataSource</p> <p>Provides a means of 
     * evaluating accuracy of content.</p> <p>Identity of the 
     * organization who is responsible for the contents of the 
     * monograph.</p> COCT_MT470002CA.Author2: c:consent overridden 
     * by <p>Authorization.signatory(PROV)</p> <p>Clinical 
     * circumstances may demand that a patient's information be 
     * accessed without consent to ensure patient safety.</p> 
     * <p>Indicates that information access was approved by a 
     * provider rather than a patient. I.e. This is an override 
     * rather than an actual consent, and is used for the purposes 
     * of 'breaking the glass' only.</p> PORX_MT030040CA.Author2: 
     * *b:prescribed by <p>To be a legal order, the person 
     * responsible for its creation must be identified. Thus the 
     * association is mandatory.</p> <p>This is the provider who 
     * authorized the medication to be dispensed to the 
     * patient.</p> PORX_MT020050CA.Author2: prescribed by <p>Used 
     * to create an 'inferred' prescription if an electronic 
     * prescription does not already exist in the EHR.</p><p>The 
     * attribute is marked as &quot;populated&quot; as the 
     * prescriber must be known or null flavour specified.</p> 
     * <p>The person who ordered the office supply.</p> 
     * COCT_MT260030CA.Author2: is created by <p>ZPE.1</p> 
     * <p>ZDU.5.1</p> <p>Contraindication.dataSource</p> 
     * <p>Provides a means of evaluating accuracy of content.</p> 
     * <p>Identity of the organization who is responsible for the 
     * contents of the monograph.</p> PORX_MT060020CA.Author2: 
     * *b:prescribed by <p>Prescription.Prescriber</p> 
     * <p>A_BillablePharmacyDispense</p> <p>To be a legal order, 
     * the person responsible for its creation must be identified. 
     * Thus the association is mandatory.</p> <p>This is the 
     * provider who authorized the device to be dispensed to the 
     * patient.</p> COCT_MT260020CA.Author2: is created by 
     * <p>ZPE.1</p> <p>ZDU.5.1</p> 
     * <p>Contraindication.dataSource</p> <p>Provides a means of 
     * evaluating accuracy of content.</p> <p>Identity of the 
     * organization who is responsible for the contents of the 
     * monograph.</p> PORX_MT060100CA.Author2: *b:prescribed by 
     * <p>To be a legal order, the person responsible for its 
     * creation must be identified. Thus the association is 
     * mandatory.</p> <p>This is the provider who authorized the 
     * medication to be dispensed to the patient.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT260010CA.Author2","COCT_MT260020CA.Author2","COCT_MT260030CA.Author2","COCT_MT470002CA.Author2","PORX_MT020050CA.Author2","PORX_MT030040CA.Author2","PORX_MT060020CA.Author2","PORX_MT060040CA.Author4","PORX_MT060060CA.Author2","PORX_MT060100CA.Author2","PORX_MT060160CA.Author4","PORX_MT060190CA.Author2","PORX_MT060340CA.Author4","RCMR_MT010001CA.Author2"})]
    public class PrescribedBy : MessagePartBean {

        private TS time;
        private CV modeCode;
        private ED<String> signatureText;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Merged.HealthcareWorker assignedEntity;

        public PrescribedBy() {
            this.time = new TSImpl();
            this.modeCode = new CVImpl();
            this.signatureText = new EDImpl<String>();
        }
        /**
         * <summary>Un-merged Business Name: 
         * IssueMonographEffectiveDate</summary>
         * 
         * <remarks>Relationship: COCT_MT260010CA.Author2.time 
         * Conformance/Cardinality: REQUIRED (0-1) 
         * <p>DDIMonograph.EffectiveDate</p> 
         * <p>A_DetectedMedicationIssue</p> <p>Allows detailed matching 
         * of local knowledgebase record with that of the central. (The 
         * monograph id may remain the same, but the effective date 
         * will always change).</p> <p>The date and time on which the 
         * monograph becomes valid and applicable.</p> Un-merged 
         * Business Name: PrescribedDate Relationship: 
         * PORX_MT060040CA.Author4.time Conformance/Cardinality: 
         * POPULATED (1) <p>Indicates when the action was performed, 
         * and may influence expiry dates for the order.</p><p>The 
         * attribute is populated because the creation date of the 
         * prescription will always be known, except for inferred 
         * prescriptions.</p> <p>The date at which the device was 
         * prescribed/dispensed. This may differ from the date on which 
         * the prescription becomes effective. E.g. A prescription 
         * created today may not be valid to be dispensed or used for 
         * two weeks.</p> Un-merged Business Name: PrescribedDate 
         * Relationship: PORX_MT030040CA.Author2.time 
         * Conformance/Cardinality: POPULATED (1) <p>Indicates when the 
         * action was performed, and may influence expiry dates for the 
         * order.</p><p>The attribute is populated because the creation 
         * date of the prescription will not always be known (as in the 
         * case of 'inferred prescription').</p> <p>The date at which 
         * the drug was prescribed/dispensed. This may differ from the 
         * date on which the prescription becomes effective. E.g. A 
         * prescription created today may not be valid to be dispensed 
         * or administered for two weeks.</p> Un-merged Business Name: 
         * PrescribedDate Relationship: PORX_MT060340CA.Author4.time 
         * Conformance/Cardinality: POPULATED (1) <p>Indicates when the 
         * action was performed, and may influence expiry dates for the 
         * order.</p><p>The attribute is populated because the creation 
         * date of the prescription will not always be known (as in the 
         * case of 'inferred prescription').</p> <p>The date at which 
         * the drug was prescribed/dispensed. This may differ from the 
         * date on which the prescription becomes effective. E.g. A 
         * prescription created today may not be valid to be dispensed 
         * or administered for two weeks.</p> Un-merged Business Name: 
         * PrescriptionOrderDate Relationship: 
         * PORX_MT060020CA.Author2.time Conformance/Cardinality: 
         * POPULATED (1) <p>Prescription.prescribedDate</p> <p>Date 
         * prescription written</p> <p>ZDP.8</p> <p>DRU.040-02 (low, 
         * qualifier=85, format=102)</p> <p>DRU.040-02 (low, 
         * qualifier=LO, format=102, where filter type = most 
         * recent)</p> <p>Claim:414-DE</p> <p>Indicates when the action 
         * was performed, and may influence expiry dates for the 
         * order.</p><p>The attribute is populated as it will not be 
         * there for inferred prescriptions.</p> <p>The date at which 
         * the device was prescribed. This may differ from the date on 
         * which the prescription becomes effective. E.g. A 
         * prescription created today may not be valid to be dispensed 
         * or used for two weeks.</p> Un-merged Business Name: 
         * IssueMonographEffectiveDate Relationship: 
         * COCT_MT260030CA.Author2.time Conformance/Cardinality: 
         * REQUIRED (0-1) <p>DDIMonograph.EffectiveDate</p> 
         * <p>A_DetectedMedicationIssue</p> <p>Allows detailed matching 
         * of local knowledgebase record with that of the central. (The 
         * monograph id may remain the same, but the effective date 
         * will always change).</p> <p>The date and time on which the 
         * monograph becomes valid and applicable.</p> Un-merged 
         * Business Name: PrescribedDate Relationship: 
         * PORX_MT060160CA.Author4.time Conformance/Cardinality: 
         * POPULATED (1) <p>Indicates when the action was performed, 
         * and may influence expiry dates for the order.</p><p>The 
         * attribute is populated because the creation date of the 
         * prescription may not be known, as in the case of 'inferred 
         * prescription'.</p> <p>The date at which the drug was 
         * prescribed/dispensed. This may differ from the date on which 
         * the prescription becomes effective. E.g. A prescription 
         * created today may not be valid to be dispensed or 
         * administered for two weeks.</p> Un-merged Business Name: 
         * IssueMonographEffectiveDate Relationship: 
         * COCT_MT260020CA.Author2.time Conformance/Cardinality: 
         * REQUIRED (0-1) <p>DDIMonograph.EffectiveDate</p> 
         * <p>A_DetectedMedicationIssue</p> <p>Allows detailed matching 
         * of local knowledgebase record with that of the central. (The 
         * monograph id may remain the same, but the effective date 
         * will always change).</p> <p>The date and time on which the 
         * monograph becomes valid and applicable.</p> Un-merged 
         * Business Name: PrescriptionOrderDate Relationship: 
         * PORX_MT060100CA.Author2.time Conformance/Cardinality: 
         * POPULATED (1) <p>Indicates when the action was performed, 
         * and may influence expiry dates for the order.</p><p>The 
         * attribute is populated as it will not be there for inferred 
         * prescriptions.</p> <p>The date at which the drug was 
         * prescribed. This may differ from the date on which the 
         * prescription becomes effective. E.g. A prescription created 
         * today may not be valid to be dispensed or administered for 
         * two weeks.</p> Un-merged Business Name: PrescribedDate 
         * Relationship: PORX_MT060190CA.Author2.time 
         * Conformance/Cardinality: POPULATED (1) <p>Essential 
         * information for a prescription to be legal.</p><p>This 
         * information may not always be known for an inferred 
         * prescription, and is therefore marked as 
         * &quot;populated&quot;.</p> <p>The date that the prescription 
         * was written by the prescriber.</p> Un-merged Business Name: 
         * PrescribedDate Relationship: PORX_MT060060CA.Author2.time 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates when the 
         * action was performed, and may influence expiry dates for the 
         * order.</p><p>The attribute is mandatory because the creation 
         * date of the prescription will always be known.</p> <p>The 
         * date at which the device was prescribed/dispensed. This may 
         * differ from the date on which the prescription becomes 
         * effective. E.g. A prescription created today may not be 
         * valid to be dispensed or used for two weeks.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"time"})]
        public PlatformDate Time {
            get { return this.time.Value; }
            set { this.time.Value = value; }
        }

        /**
         * <summary>Business Name: PrescriptionTransmissionMethod</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * PrescriptionTransmissionMethod Relationship: 
         * PORX_MT060040CA.Author4.modeCode Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Some jurisdictions have a requirement to 
         * track how an order was received. May also be important when 
         * orders are entered into a central repository from the 
         * pharmacy.</p> <p>Indicates the medium in which a 
         * prescription was transmitted to or received by the person 
         * who entered it into the electronic record.</p> Un-merged 
         * Business Name: PrescriptionTransmissionMethod Relationship: 
         * PORX_MT060340CA.Author4.modeCode Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Some jurisdictions have a requirement to 
         * track how an order was received. May also be important when 
         * orders are entered into a central repository from the 
         * pharmacy.</p> <p>Indicates the medium in which a 
         * prescription was transmitted to or received by the person 
         * who entered it into the electronic record.</p> Un-merged 
         * Business Name: PrescriptionTransmissionMethod Relationship: 
         * PORX_MT060160CA.Author4.modeCode Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Some jurisdictions have a requirement to 
         * track how an order was received. May also be important when 
         * orders are entered into a central repository from the 
         * pharmacy.</p> <p>Indicates the medium in which a 
         * prescription was transmitted to or received by the person 
         * who entered it into the electronic record.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"modeCode"})]
        public ParticipationMode ModeCode {
            get { return (ParticipationMode) this.modeCode.Value; }
            set { this.modeCode.Value = value; }
        }

        /**
         * <summary>Business Name: Signature</summary>
         * 
         * <remarks>Un-merged Business Name: Signature Relationship: 
         * PORX_MT060040CA.Author4.signatureText 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Allows for pure 
         * electronic prescriptions without a trusted intermediary. The 
         * attribute is optional because all jurisdictions may not 
         * support digital signatures.</p> <p>An electronic signature 
         * of the prescription by the prescriber.</p> Un-merged 
         * Business Name: Signature Relationship: 
         * PORX_MT060340CA.Author4.signatureText 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Allows for pure 
         * electronic prescriptions without a trusted intermediary. The 
         * attribute is optional because all jurisdictions may not 
         * support digital signatures.</p> <p>An electronic signature 
         * of the prescription by the prescriber.</p> Un-merged 
         * Business Name: Signature Relationship: 
         * PORX_MT060160CA.Author4.signatureText 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Allows for pure 
         * electronic prescriptions without a trusted intermediary. The 
         * attribute is optional because all jurisdictions may not 
         * support digital signatures.</p> <p>An electronic signature 
         * of the prescription by the prescriber.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"signatureText"})]
        public String SignatureText {
            get { return this.signatureText.Value; }
            set { this.signatureText.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060040CA.Author4.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060340CA.Author4.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * RCMR_MT010001CA.Author2.assignedEntity 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060160CA.Author4.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060190CA.Author2.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060060CA.Author2.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * COCT_MT260010CA.Author2.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * COCT_MT470002CA.Author2.assignedEntity 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT030040CA.Author2.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT020050CA.Author2.assignedEntity 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * COCT_MT260030CA.Author2.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060020CA.Author2.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * COCT_MT260020CA.Author2.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060100CA.Author2.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Merged.HealthcareWorker AssignedEntity {
            get { return this.assignedEntity; }
            set { this.assignedEntity = value; }
        }

    }

}