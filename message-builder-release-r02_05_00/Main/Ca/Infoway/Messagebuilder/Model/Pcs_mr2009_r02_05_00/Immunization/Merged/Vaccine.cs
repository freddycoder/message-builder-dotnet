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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Vaccine</summary>
     * 
     * <remarks>POIZ_MT030060CA.Vaccine: Vaccine <p>Allows vaccines 
     * to be clearly described and referenced. Also allows 
     * searching for and examining information about vaccines that 
     * have been administered to a patient.</p> <p>A pharmaceutical 
     * product to be supplied and/or administered to a patient. 
     * Encompasses manufactured vaccines and generic 
     * classifications.</p> POIZ_MT060150CA.Vaccine: Vaccine 
     * <p>Allows vaccines to be clearly described and referenced. 
     * Also allows searching for and examining information about 
     * vaccines that have been administered to a patient.</p> <p>A 
     * pharmaceutical product to be supplied and/or administered to 
     * a patient. Encompasses manufactured vaccines and generic 
     * classifications.</p> POIZ_MT030050CA.Vaccine: Vaccine 
     * <p>Allows vaccines to be clearly described and referenced. 
     * Also allows searching for and examining information about 
     * vaccines that have been administered to a patient.</p> <p>A 
     * pharmaceutical product to be supplied and/or administered to 
     * a patient. Encompasses manufactured vaccines and generic 
     * classifications.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POIZ_MT030050CA.Vaccine","POIZ_MT030060CA.Vaccine","POIZ_MT060150CA.Vaccine"})]
    public class Vaccine : MessagePartBean {

        private CV code;
        private ST name;
        private ST desc;
        private CV formCode;
        private ST lotNumberText;
        private IVL<TS, Interval<PlatformDate>> expirationTime;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.Manufacturer asManufacturedProductManufacturer;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Merged.Antigens> ingredientsIngredient;

        public Vaccine() {
            this.code = new CVImpl();
            this.name = new STImpl();
            this.desc = new STImpl();
            this.formCode = new CVImpl();
            this.lotNumberText = new STImpl();
            this.expirationTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.ingredientsIngredient = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Merged.Antigens>();
        }
        /**
         * <summary>Business Name: VaccineCode</summary>
         * 
         * <remarks>Un-merged Business Name: VaccineCode Relationship: 
         * POIZ_MT030060CA.Vaccine.code Conformance/Cardinality: 
         * REQUIRED (1) <p>Used to ensure clear communication by 
         * uniquely identifying a particular drug product when 
         * prescribing or dispensing. This attribute is only marked as 
         * 'populated' because some custom compounds will not have 
         * unique identifiers.</p> <p>An identifier for a type of drug. 
         * Depending on where the drug is being referenced, the drug 
         * may be identified at different levels of abstraction. E.g. 
         * Manufactured drug (including vaccine).</p> Un-merged 
         * Business Name: VaccineCode Relationship: 
         * POIZ_MT060150CA.Vaccine.code Conformance/Cardinality: 
         * REQUIRED (1) <p>Used to ensure clear communication by 
         * uniquely identifying a particular drug product when 
         * prescribing or dispensing. This attribute is only marked as 
         * 'populated' because some custom compounds will not have 
         * unique identifiers.</p> <p>An identifier for a type of drug. 
         * Depending on where the drug is being referenced, the drug 
         * may be identified at different levels of abstraction. E.g. 
         * Manufactured drug (including vaccine).</p> Un-merged 
         * Business Name: VaccineCode Relationship: 
         * POIZ_MT030050CA.Vaccine.code Conformance/Cardinality: 
         * REQUIRED (1) <p>Used to ensure clear communication by 
         * uniquely identifying a particular drug product when 
         * prescribing or dispensing. This attribute is only marked as 
         * 'populated' because some custom compounds will not have 
         * unique identifiers.</p> <p>An identifier for a type of drug. 
         * Depending on where the drug is being referenced, the drug 
         * may be identified at different levels of abstraction. E.g. 
         * Manufactured drug (including vaccine).</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public VaccineType Code {
            get { return (VaccineType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: VaccineName</summary>
         * 
         * <remarks>Un-merged Business Name: VaccineName Relationship: 
         * POIZ_MT030060CA.Vaccine.name Conformance/Cardinality: 
         * MANDATORY (1) <p>Names are used for human reference 
         * communication, to allow selection from dropdowns and for 
         * local searching. If a code is available, the name acts as a 
         * cross-check. If the code is not available the name acts as 
         * the primary identifier. The attribute is therefore 
         * mandatory.</p> <p>The name assigned to a vaccine.</p> 
         * Un-merged Business Name: VaccineName Relationship: 
         * POIZ_MT060150CA.Vaccine.name Conformance/Cardinality: 
         * MANDATORY (1) <p>Names are used for human reference 
         * communication, to allow selection from dropdowns and for 
         * local searching. If a code is available, the name acts as a 
         * cross-check. If the code is not available the name acts as 
         * the primary identifier. The attribute is therefore 
         * mandatory.</p> <p>The name assigned to a vaccine.</p> 
         * Un-merged Business Name: VaccineName Relationship: 
         * POIZ_MT030050CA.Vaccine.name Conformance/Cardinality: 
         * MANDATORY (1) <p>Names are used for human reference 
         * communication, to allow selection from dropdowns and for 
         * local searching. If a code is available, the name acts as a 
         * cross-check. If the code is not available the name acts as 
         * the primary identifier. The attribute is therefore 
         * mandatory.</p> <p>The name assigned to a vaccine.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"name"})]
        public String Name {
            get { return this.name.Value; }
            set { this.name.Value = value; }
        }

        /**
         * <summary>Business Name: VaccineDescription</summary>
         * 
         * <remarks>Un-merged Business Name: VaccineDescription 
         * Relationship: POIZ_MT030060CA.Vaccine.desc 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows 
         * description of compound ingredients and/or recipe in free 
         * text form.</p> <p>A free form textual description of a 
         * vaccine. This usually is only populated for custom 
         * compounds, providing instructions on the composition and 
         * creation of the compound.</p> Un-merged Business Name: 
         * VaccineDescription Relationship: 
         * POIZ_MT060150CA.Vaccine.desc Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Allows description of compound ingredients 
         * and/or recipe in free text form.</p> <p>A free form textual 
         * description of a vaccine. This usually is only populated for 
         * custom compounds, providing instructions on the composition 
         * and creation of the compound.</p> Un-merged Business Name: 
         * VaccineDescription Relationship: 
         * POIZ_MT030050CA.Vaccine.desc Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Allows description of compound ingredients 
         * and/or recipe in free text form.</p> <p>A free form textual 
         * description of a vaccine. This usually is only populated for 
         * custom compounds, providing instructions on the composition 
         * and creation of the compound.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"desc"})]
        public String Desc {
            get { return this.desc.Value; }
            set { this.desc.Value = value; }
        }

        /**
         * <summary>Business Name: DrugForm</summary>
         * 
         * <remarks>Un-merged Business Name: DrugForm Relationship: 
         * POIZ_MT030060CA.Vaccine.formCode Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Provides a constrained vocabulary for 
         * describing dose forms. The form of the drug influences how 
         * it can be used by the patient.</p> <p>Must be populated if 
         * the Vaccine Code does not specify the Drug Form.</p> 
         * <p>Indicates the form in which the drug product must be, or 
         * has been manufactured or custom prepared.</p> Un-merged 
         * Business Name: DrugForm Relationship: 
         * POIZ_MT060150CA.Vaccine.formCode Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Provides a constrained vocabulary for 
         * describing dose forms. The form of the drug influences how 
         * it can be used by the patient.</p> <p>Must be populated if 
         * the Vaccine Code does not specify the Drug Form.</p> 
         * <p>Indicates the form in which the drug product must be, or 
         * has been manufactured or custom prepared.</p> Un-merged 
         * Business Name: DrugForm Relationship: 
         * POIZ_MT030050CA.Vaccine.formCode Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Provides a constrained vocabulary for 
         * describing dose forms. The form of the drug influences how 
         * it can be used by the patient.</p> <p>Must be populated if 
         * the Vaccine Code does not specify the Drug Form.</p> 
         * <p>Indicates the form in which the drug product must be, or 
         * has been manufactured or custom prepared.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"formCode"})]
        public AdministrableDrugForm FormCode {
            get { return (AdministrableDrugForm) this.formCode.Value; }
            set { this.formCode.Value = value; }
        }

        /**
         * <summary>Business Name: VaccineLotNumber</summary>
         * 
         * <remarks>Un-merged Business Name: VaccineLotNumber 
         * Relationship: POIZ_MT030060CA.Vaccine.lotNumberText 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Useful in 
         * tracking for recalls but may not always be known (e.g. 
         * historical immunization records).</p> <p>Identification of a 
         * batch in which a specific manufactured drug belongs.</p> 
         * Un-merged Business Name: VaccineLotNumber Relationship: 
         * POIZ_MT060150CA.Vaccine.lotNumberText 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Useful in 
         * tracking for recalls but may not always be known (e.g. 
         * historical immunization records).</p> <p>Identification of a 
         * batch in which a specific manufactured drug belongs.</p> 
         * Un-merged Business Name: VaccineLotNumber Relationship: 
         * POIZ_MT030050CA.Vaccine.lotNumberText 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Useful in 
         * tracking for recalls but may not always be known (e.g. 
         * historical immunization records).</p> <p>Identification of a 
         * batch in which a specific manufactured drug belongs.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"lotNumberText"})]
        public String LotNumberText {
            get { return this.lotNumberText.Value; }
            set { this.lotNumberText.Value = value; }
        }

        /**
         * <summary>Business Name: VaccineExpiryDate</summary>
         * 
         * <remarks>Un-merged Business Name: VaccineExpiryDate 
         * Relationship: POIZ_MT030060CA.Vaccine.expirationTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The potency, 
         * effectiveness and safety of drug products changes over time. 
         * When determining quantities to be supplied to a patient, one 
         * of the considerations is how long the drug will remain 
         * viable.</p> <p>To indicate the length of time after opening 
         * a product remains viable, specify the 'Width' property. To 
         * indicate a specific end date for an actual dispensed 
         * product, specify the 'High' property</p> <p>Indicates either 
         * the length of time a drug product can remain viable (when 
         * talking about a drug in general terms), or the date on which 
         * the drug product is no longer considered viable (when 
         * talking about a specific medication that has been 
         * dispensed).</p> Un-merged Business Name: VaccineExpiryDate 
         * Relationship: POIZ_MT060150CA.Vaccine.expirationTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The potency, 
         * effectiveness and safety of drug products changes over time. 
         * When determining quantities to be supplied to a patient, one 
         * of the considerations is how long the drug will remain 
         * viable.</p> <p>To indicate the length of time after opening 
         * a product remains viable, specify the 'Width' property. To 
         * indicate a specific end date for an actual dispensed 
         * product, specify the 'High' property</p> <p>Indicates either 
         * the length of time a drug product can remain viable (when 
         * talking about a drug in general terms), or the date on which 
         * the drug product is no longer considered viable (when 
         * talking about a specific medication that has been 
         * dispensed).</p> Un-merged Business Name: VaccineExpiryDate 
         * Relationship: POIZ_MT030050CA.Vaccine.expirationTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The potency, 
         * effectiveness and safety of drug products changes over time. 
         * When determining quantities to be supplied to a patient, one 
         * of the considerations is how long the drug will remain 
         * viable.</p> <p>To indicate the length of time after opening 
         * a product remains viable, specify the 'Width' property. To 
         * indicate a specific end date for an actual dispensed 
         * product, specify the 'High' property</p> <p>Indicates either 
         * the length of time a drug product can remain viable (when 
         * talking about a drug in general terms), or the date on which 
         * the drug product is no longer considered viable (when 
         * talking about a specific medication that has been 
         * dispensed).</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"expirationTime"})]
        public Interval<PlatformDate> ExpirationTime {
            get { return this.expirationTime.Value; }
            set { this.expirationTime.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * POIZ_MT030060CA.ManufacturedProduct.manufacturer 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * POIZ_MT060150CA.ManufacturedProduct.manufacturer 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * POIZ_MT030050CA.ManufacturedProduct.manufacturer 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"asManufacturedProduct/manufacturer"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.Manufacturer AsManufacturedProductManufacturer {
            get { return this.asManufacturedProductManufacturer; }
            set { this.asManufacturedProductManufacturer = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * POIZ_MT030060CA.Ingredients.ingredient 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * POIZ_MT060150CA.Ingredients.ingredient 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * POIZ_MT030050CA.Ingredients.ingredient 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"ingredients/ingredient"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Merged.Antigens> IngredientsIngredient {
            get { return this.ingredientsIngredient; }
        }

    }

}