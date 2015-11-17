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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt220100ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Drug Product</summary>
     * 
     * <p>A_BillablePharmacyDispense</p> <p>Allows drugs to be 
     * clearly described and referenced. Also allows searching for 
     * and examining information about medications that can be or 
     * are being used by a patient.</p> <p>A pharmaceutical product 
     * intended to be supplied and/or administered to a patient. 
     * Encompasses manufactured drug products, generic 
     * classifications, prescription medications, over-the-counter 
     * medications and recreational drugs.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT220100CA.Medication"})]
    public class DrugProduct : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt270010ca.IMedication {

        private CD administerableMedicineCode;
        private ST administerableMedicineName;
        private ST administerableMedicineDesc;
        private CV administerableMedicineFormCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.DispensedIn administerableMedicineAsContent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.DrugContains> administerableMedicineIngredient;

        public DrugProduct() {
            this.administerableMedicineCode = new CDImpl();
            this.administerableMedicineName = new STImpl();
            this.administerableMedicineDesc = new STImpl();
            this.administerableMedicineFormCode = new CVImpl();
            this.administerableMedicineIngredient = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.DrugContains>();
        }
        /**
         * <summary>Business Name: A:Drug Code</summary>
         * 
         * <remarks>Relationship: COCT_MT220100CA.Medicine.code 
         * Conformance/Cardinality: REQUIRED (1) 
         * <p>DrugProduct.activeIngredientId</p> 
         * <p>DrugProduct.ActiveIngredientGroupNumber</p> 
         * <p>DrugProduct.DIN</p> <p>DrugProduct.StandardProductId 
         * (Mnemonic)</p> <p>DrugProduct.StandardIDType(Code 
         * System)</p> <p>D56(use code system to distinguish different 
         * types)</p> <p>ZPB2.1</p> <p>ZPB3.1</p> <p>ZPC.1</p> 
         * <p>ZPC1.3</p> <p>ZPD.1</p> <p>ZPD1.1</p> <p>ZPD.6(scoping a 
         * specialized kind of therapeutic equivalent)</p> 
         * <p>MB.05.03B</p> <p>ZPS.11</p> <p>ZDP.3a(code system)</p> 
         * <p>ZDU.4.1</p> <p>ZDP.7</p> <p>DRU.010-03(mnemonic)</p> 
         * <p>DRU.010-04(code system)</p> <p>DRU.010-08(mnemonic)</p> 
         * <p>DRU.010-09(code system)</p> <p>DRU.100-04 (mnemonic)</p> 
         * <p>DRU.100-05 (code system)</p> <p>Compound.488-RE (code 
         * system)</p> <p>Compound.489-TE (mnemonic)</p> 
         * <p>DUR/PPS.475-J9 (code system)</p> <p>DUR/PPS.476-H6 
         * (mnemonic)</p> <p>Claim.436-E1 (code system)</p> 
         * <p>Claim.407-D7 (mnemonic)</p> <p>Claim.453-EJ (code 
         * system)</p> <p>Claim.445-EA (mnemonic)</p> <p>Claim.406-D6 
         * (determined from code system)</p> <p>RXA.5</p> 
         * <p>A_BillablePharmacyDispense</p> <p>Used to ensure clear 
         * communication by uniquely identifying a particular drug 
         * product when prescribing or dispensing. This attribute is 
         * only marked as 'populated' because some custom compounds 
         * will not have unique identifiers Datatype has been retained 
         * as CE (Translatable Code) to support translation between 
         * multiple code sets for drugs (e.g. DIN, GTIN, UPC).</p> 
         * <p>An identifier for a type of drug. Depending on where the 
         * drug is being referenced, the drug may be identified at 
         * different levels of abstraction. E.g. Manufactured drug 
         * (including vaccines), generic formulation, generic, 
         * therapeutic class, etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"administerableMedicine/code"})]
        public ClinicalDrug AdministerableMedicineCode {
            get { return (ClinicalDrug) this.administerableMedicineCode.Value; }
            set { this.administerableMedicineCode.Value = value; }
        }

        /**
         * <summary>Business Name: B:Drug Name</summary>
         * 
         * <remarks>Relationship: COCT_MT220100CA.Medicine.name 
         * Conformance/Cardinality: MANDATORY (1) <p>DrugProduct.Name 
         * (Search)</p> <p>CoumpoundDrugProduct.name</p> 
         * <p>Contraindication.interactingDrugName</p> 
         * <p>DrugProduct.labelName(useCode=L)</p> <p>ZPB2.2</p> 
         * <p>ZPB3.2</p> <p>ZPC.2</p> <p>ZPD.2</p> <p>ZPD1.2</p> 
         * <p>ZPD.5</p> <p>MB.01.03</p> <p>Drug Name</p> <p>ZDU.4.2</p> 
         * <p>ZDU.6.1.1</p> <p>DRU.010-02</p> <p>RXA.TradeName</p> 
         * <p>DRU.010-10-&gt;12</p> <p>Brand Name</p> <p>C.1a</p> 
         * <p>Trade Name</p> <p>Other Name</p> <p>Names are used for 
         * human reference communication, to allow selection from 
         * dropdowns and for local searching. If a code is available, 
         * the name acts as a cross-check. If the code is not available 
         * the name acts as the primary identifier. The attribute is 
         * therefore mandatory.</p> <p>First occurrence is preferred 
         * for display.</p> <p>The name assigned to a drug.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"administerableMedicine/name"})]
        public String AdministerableMedicineName {
            get { return this.administerableMedicineName.Value; }
            set { this.administerableMedicineName.Value = value; }
        }

        /**
         * <summary>Business Name: C:Drug Description</summary>
         * 
         * <remarks>Relationship: COCT_MT220100CA.Medicine.desc 
         * Conformance/Cardinality: REQUIRED (0-1) 
         * <p>DrugProduct.description</p> 
         * <p>CompoundedDrugProduct.adhocSpecification</p> 
         * <p>DRU.010-06</p> <p>DIN Description</p> <p>Allows 
         * description of compound ingredients and/or recipe in free 
         * text form.</p> <p>A free form textual description of a drug. 
         * This usually is only populated for custom compounds, 
         * providing instructions on the composition and creation of 
         * the compound.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"administerableMedicine/desc"})]
        public String AdministerableMedicineDesc {
            get { return this.administerableMedicineDesc.Value; }
            set { this.administerableMedicineDesc.Value = value; }
        }

        /**
         * <summary>Business Name: D:Drug Form</summary>
         * 
         * <remarks>Relationship: COCT_MT220100CA.Medicine.formCode 
         * Conformance/Cardinality: REQUIRED (0-1) 
         * <p>Prescription.dosageForm</p> <p>DrugProduct.dosageForm</p> 
         * <p>CompoundedDrugProduct.dosageForm</p> 
         * <p>DispensedItem.dosageForm</p> <p>D63</p> <p>ZPC.3</p> 
         * <p>ZPD.3</p> <p>Drug form</p> <p>ZDP.14.1</p> <p>ZDP.3b</p> 
         * <p>DRU.010-05</p> <p>Compound.450-EF</p> 
         * <p>A_BillablePharmacyDispense</p> <p>Dosage Form</p> 
         * <p>Dosage Form</p> <p>Provides a constrained vocabulary for 
         * describing dose forms. The form of the drug influences how 
         * it can be used by the patient.</p> <p>Should be recorded if 
         * the Drug Id does not specify the Drug Form AND where the 
         * provider has a preference for the drug form that the patient 
         * will consume.</p> <p>Indicates the form in which the drug 
         * product must be, or has been manufactured or custom 
         * prepared.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"administerableMedicine/formCode"})]
        public OrderableDrugForm AdministerableMedicineFormCode {
            get { return (OrderableDrugForm) this.administerableMedicineFormCode.Value; }
            set { this.administerableMedicineFormCode.Value = value; }
        }

        /**
         * <summary>Relationship: COCT_MT220100CA.Medicine.asContent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"administerableMedicine/asContent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.DispensedIn AdministerableMedicineAsContent {
            get { return this.administerableMedicineAsContent; }
            set { this.administerableMedicineAsContent = value; }
        }

        /**
         * <summary>Relationship: COCT_MT220100CA.Medicine.ingredient</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-50)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"administerableMedicine/ingredient"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.DrugContains> AdministerableMedicineIngredient {
            get { return this.administerableMedicineIngredient; }
        }

    }

}