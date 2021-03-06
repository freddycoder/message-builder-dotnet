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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Immunization.Poiz_mt061150ab {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Vaccine</summary>
     * 
     * <p>Allows vaccines to be clearly described and referenced. 
     * Also allows searching for and examining information about 
     * vaccines that have been administered to a patient.</p> <p>A 
     * pharmaceutical product to be supplied and/or administered to 
     * a patient. Encompasses manufactured vaccines and generic 
     * classifications.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POIZ_MT061150AB.Vaccine"})]
    public class Vaccine : MessagePartBean {

        private CV code;
        private ST lotNumberText;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Merged.Manufacturer asManufacturedProductManufacturer;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Immunization.Poiz_mt061150ab.Antigen> ingredientsIngredientAntigen;

        public Vaccine() {
            this.code = new CVImpl();
            this.lotNumberText = new STImpl();
            this.ingredientsIngredientAntigen = new List<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Immunization.Poiz_mt061150ab.Antigen>();
        }
        /**
         * <summary>Business Name: Vaccine Code</summary>
         * 
         * <remarks>Relationship: POIZ_MT061150AB.Vaccine.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Used to ensure 
         * clear communication by uniquely identifying a particular 
         * drug product when prescribing or dispensing. This attribute 
         * is mandatory because it is expected that vaccine codes will 
         * always be specified.</p> <p>An identifier for a type of 
         * drug. Depending on where the drug is being referenced, the 
         * drug may be identified at different levels of abstraction. 
         * E.g. Manufactured drug (including vaccine).</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ClinicalDrug Code {
            get { return (ClinicalDrug) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Vaccine Lot Number</summary>
         * 
         * <remarks>Relationship: POIZ_MT061150AB.Vaccine.lotNumberText 
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
         * <summary>Relationship: 
         * POIZ_MT061150AB.ManufacturedProduct.manufacturer</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"asManufacturedProduct/manufacturer"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Merged.Manufacturer AsManufacturedProductManufacturer {
            get { return this.asManufacturedProductManufacturer; }
            set { this.asManufacturedProductManufacturer = value; }
        }

        /**
         * <summary>Relationship: 
         * POIZ_MT061150AB.Ingredients.ingredientAntigen</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"ingredients/ingredientAntigen"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Immunization.Poiz_mt061150ab.Antigen> IngredientsIngredientAntigen {
            get { return this.ingredientsIngredientAntigen; }
        }

    }

}