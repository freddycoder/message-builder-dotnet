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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt090107ca;
    using System;


    /**
     * <summary>COCT_MT470000CA.Author2: c:consent overridden by</summary>
     * 
     * <p>Authorization.signatory(PROV)</p> <p>Clinical 
     * circumstances may demand that a patient's information be 
     * accessed without consent to ensure patient safety.</p> 
     * <p>Indicates that information access was approved by a 
     * provider rather than a patient. I.e. This is an override 
     * rather than an actual consent, and is used for the purposes 
     * of 'breaking the glass' only.</p> PORX_MT030040CA.Author2: 
     * *b:prescribed by <p>Prescription.Prescriber</p> 
     * <p>A_BillablePharmacyDispense</p> <p>To be a legal order, 
     * the person responsible for its creation must be identified. 
     * Thus the association is mandatory.</p> <p>This is the 
     * provider who authorized the medication to be dispensed to 
     * the patient.</p> PORX_MT020050CA.Author2: prescribed by 
     * <p>Used to create an 'inferred' prescription if an 
     * electronic prescription does not already exist in the 
     * EHR.</p><p>The attribute is marked as &quot;populated&quot; 
     * as the prescriber must be known or null flavour 
     * specified.</p> <p>The person who ordered the office 
     * supply.</p> RCMR_MT010001CA.Author2: c:overridden by 
     * <p>Authorization.signatory(PROV)</p> <p>Clinical 
     * circumstances may demand that a patient's information be 
     * accessed without consent to ensure patient safety.</p> 
     * <p>Indicates that information access was approved by a 
     * provider rather than a patient. I.e. This is an override 
     * rather than an actual consent.</p> PORX_MT060020CA.Author2: 
     * *b:prescribed by <p>Prescription.Prescriber</p> 
     * <p>A_BillablePharmacyDispense</p> <p>To be a legal order, 
     * the person responsible for its creation must be identified. 
     * Thus the association is mandatory.</p> <p>This is the 
     * provider who authorized the device to be dispensed to the 
     * patient.</p> PORX_MT060100CA.Author2: *b:prescribed by 
     * <p>Prescription.Prescriber</p> 
     * <p>A_BillablePharmacyDispense</p> <p>To be a legal order, 
     * the person responsible for its creation must be identified. 
     * Thus the association is mandatory.</p> <p>This is the 
     * provider who authorized the medication to be dispensed to 
     * the patient.</p> PORX_MT060190CA.Author2: *c:prescribed by 
     * <p>Prescription.Prescriber</p> 
     * <p>A_BillablePharmacyDispense</p> <p>To be a legal order, 
     * the person responsible for its creation must be identified. 
     * Thus the association is mandatory.</p> <p>This is the 
     * provider who authorized the medication to be dispensed to 
     * the patient.</p> PORX_MT060060CA.Author2: *b:prescribed by 
     * <p>Prescription.Prescriber</p> 
     * <p>A_BillablePharmacyDispense</p> <p>To be a legal order, 
     * the person responsible for its creation must be identified. 
     * Thus the association is mandatory.</p> <p>This is the 
     * provider who authorized the device to be dispensed to the 
     * patient.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT470000CA.Author2","PORX_MT020050CA.Author2","PORX_MT030040CA.Author2","PORX_MT060020CA.Author2","PORX_MT060060CA.Author2","PORX_MT060100CA.Author2","PORX_MT060190CA.Author2","RCMR_MT010001CA.Author2"})]
    public class PrescribedBy : MessagePartBean {

        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt090107ca.Provider assignedPerson;
        private TS time;

        public PrescribedBy() {
            this.time = new TSImpl();
        }
        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT470000CA.Author2.assignedPerson 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT030040CA.Author2.assignedPerson 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT020050CA.Author2.assignedPerson 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060020CA.Author2.assignedPerson 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * RCMR_MT010001CA.Author2.assignedPerson 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060100CA.Author2.assignedPerson 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060190CA.Author2.assignedPerson 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060060CA.Author2.assignedPerson 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"assignedPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt090107ca.Provider AssignedPerson {
            get { return this.assignedPerson; }
            set { this.assignedPerson = value; }
        }

        /**
         * <summary>Un-merged Business Name: PrescribedDate</summary>
         * 
         * <remarks>Relationship: PORX_MT030040CA.Author2.time 
         * Conformance/Cardinality: POPULATED (1) 
         * <p>Prescription.prescribedDate</p> <p>Date prescription 
         * written</p> <p>ZDP.8</p> <p>DRU.040-02 (low, qualifier=85, 
         * format=102)</p> <p>DRU.040-02 (low, qualifier=LO, 
         * format=102, where filter type = most recent)</p> 
         * <p>Claim:414-DE</p> <p>Indicates when the action was 
         * performed, and may influence expiry dates for the 
         * order.</p><p>The attribute is populated because the creation 
         * datetime of the prescription will not always be known (as in 
         * the case of 'inferred prescription').</p> <p>The date at 
         * which the drug was prescribed. This may differ from the date 
         * on which the prescription becomes effective. E.g. A 
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
         * PrescriptionOrderDate Relationship: 
         * PORX_MT060100CA.Author2.time Conformance/Cardinality: 
         * POPULATED (1) <p>Prescription.prescribedDate</p> <p>Date 
         * prescription written</p> <p>ZDP.8</p> <p>DRU.040-02 (low, 
         * qualifier=85, format=102)</p> <p>DRU.040-02 (low, 
         * qualifier=LO, format=102, where filter type = most 
         * recent)</p> <p>Claim:414-DE</p> <p>Indicates when the action 
         * was performed, and may influence expiry dates for the 
         * order.</p><p>The attribute is populated as it will not be 
         * there for inferred prescriptions.</p> <p>The date at which 
         * the drug was prescribed. This may differ from the date on 
         * which the prescription becomes effective. E.g. A 
         * prescription created today may not be valid to be dispensed 
         * or administered for two weeks.</p> Un-merged Business Name: 
         * PrescribedDate Relationship: PORX_MT060190CA.Author2.time 
         * Conformance/Cardinality: POPULATED (1) <p>Essential 
         * information for a prescription to be legal.</p><p>This 
         * information may not always be known for an inferred 
         * prescription, and is therefore marked as 
         * &quot;populated&quot;.</p> <p>The date that the prescription 
         * was written by the prescriber.</p> Un-merged Business Name: 
         * PrescribedDate Relationship: PORX_MT060060CA.Author2.time 
         * Conformance/Cardinality: MANDATORY (1) 
         * <p>Prescription.prescribedDate</p> <p>Date prescription 
         * written</p> <p>ZDP.8</p> <p>DRU.040-02 (low, qualifier=85, 
         * format=102)</p> <p>DRU.040-02 (low, qualifier=LO, 
         * format=102, where filter type = most recent)</p> 
         * <p>Claim:414-DE</p> <p>Indicates when the action was 
         * performed, and may influence expiry dates for the 
         * order.</p><p>The attribute is mandatory because the creation 
         * date of the prescription will always be known.</p> <p>The 
         * date at which the device was prescribed. This may differ 
         * from the date on which the prescription becomes effective. 
         * E.g. A prescription created today may not be valid to be 
         * dispensed or used for two weeks.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"time"})]
        public PlatformDate Time {
            get { return this.time.Value; }
            set { this.time.Value = value; }
        }

    }

}