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
 * Author:        $LastChangedBy: jmis $
 * Last modified: $LastChangedDate: 2015-09-15 10:24:28 -0400 (Tue, 15 Sep 2015) $
 * Revision:      $LastChangedRevision: 9776 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: DrugContains</summary>
     * 
     * <remarks>POME_MT010040CA.Ingredient: drug contains <p>Useful 
     * to providers in deciding appropriate use instruction (dosage 
     * specification) for patients. Also important in checking for 
     * potential adverse reactions to non-active ingredients. For 
     * compounds, allows contraindication checking against 
     * ingredients of custom compounds.</p> <p>Identification of 
     * which ingredients are contained (or are not contained) in a 
     * drug, along with their respective quantities.</p> 
     * POME_MT010100CA.Ingredient: drug contains <p>Useful to 
     * providers in deciding appropriate use instruction (dosage 
     * specification) for patients. Also important in checking for 
     * potential adverse reactions to non-active ingredients. For 
     * compounds, allows contraindication checking against 
     * ingredients of custom compounds.</p> <p>Identification of 
     * which ingredients are contained (or are not contained) in a 
     * drug, along with their respective quantities.</p> 
     * COCT_MT220100CA.Ingredient: drug contains <p>Useful to 
     * providers in deciding appropriate use instruction (dosage 
     * specification) for patients. Also important in checking for 
     * potential adverse reactions to non-active ingredients. For 
     * compounds, allows contraindication checking against 
     * ingredients of custom compounds.</p> <p>Identification of 
     * which ingredients are contained (or are not contained) in a 
     * drug, along with their respective quantities.</p> 
     * COCT_MT220200CA.Ingredient: drug contains <p>Useful to 
     * providers in deciding appropriate use instruction (dosage 
     * specification) for patients. Also important in checking for 
     * potential adverse reactions to non-active ingredients. For 
     * compounds, allows contraindication checking against 
     * ingredients of custom compounds.</p> <p>Identification of 
     * which ingredients are contained (or are not contained) in a 
     * drug, along with their respective quantities.</p> 
     * COCT_MT220210CA.Ingredient: drug contains <p>Useful to 
     * providers in deciding appropriate use instruction (dosage 
     * specification) for patients. Also important in checking for 
     * potential adverse reactions to non-active ingredients. For 
     * compounds, allows contraindication checking against 
     * ingredients of custom compounds.</p> <p>Identification of 
     * which ingredients are contained (or are not contained) in a 
     * drug, along with their respective quantities.</p> 
     * COCT_MT220110CA.Ingredient: drug contains <p>Useful to 
     * providers in deciding appropriate use instruction (dosage 
     * specification) for patients. Also important in checking for 
     * potential adverse reactions to non-active ingredients. For 
     * compounds, allows contraindication checking against 
     * ingredients of custom compounds.</p> <p>Identification of 
     * which ingredients are contained (or are not contained) in a 
     * drug, along with their respective quantities.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT220100CA.Ingredient","COCT_MT220110CA.Ingredient","COCT_MT220200CA.Ingredient","COCT_MT220210CA.Ingredient","POME_MT010040CA.Ingredient","POME_MT010100CA.Ingredient"})]
    public class DrugContains : MessagePartBean {

        private BL negationInd;
        private PQ quantity;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged.DrugIngredients ingredient;

        public DrugContains() {
            this.negationInd = new BLImpl();
            this.quantity = new PQImpl();
        }
        /**
         * <summary>Un-merged Business Name: DoesNotContainIndicator</summary>
         * 
         * <remarks>Relationship: 
         * POME_MT010040CA.Ingredient.negationInd 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Useful for 
         * filtering searches. Allows providers to search for drugs not 
         * containing a specific active ingredients or excipients. E.g. 
         * lactose-free, gluten-free, etc.</p><p>Because product 
         * descriptions (particularly herbals) occasionally use the 
         * phrase &quot;may contain&quot;, this attribute allows null 
         * values.</p> <p>An indication that a drug does not contain 
         * the specified ingredient (active or inactive).</p> Un-merged 
         * Business Name: DoesNotContainIndicator Relationship: 
         * POME_MT010100CA.Ingredient.negationInd 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Useful for 
         * filtering searches. Allows providers to search for drugs not 
         * containing a specific active ingredients or excipients. E.g. 
         * lactose-free, gluten-free, etc.</p><p>Because product 
         * descriptions (particularly herbals) occasionally use the 
         * phrase &quot;may contain&quot;, this attribute allows null 
         * values.</p> <p>An indication that a drug does not contain 
         * the specified ingredient (active or inactive).</p> Un-merged 
         * Business Name: DrugDoesNotContainIndicator Relationship: 
         * COCT_MT220100CA.Ingredient.negationInd 
         * Conformance/Cardinality: MANDATORY (1) <p>Useful for 
         * filtering searches. Allows providers to search for drugs not 
         * containing a specific active ingredients or excipients. E.g. 
         * lactose-free, gluten-free, etc.</p><p>The attribute is 
         * 'mandatory' because the distinction between &quot;does/must 
         * contain&quot; and &quot;does/must not contain&quot; is 
         * essential.</p> <p>An indication that a drug does not contain 
         * the specified ingredient (active or inactive).</p> Un-merged 
         * Business Name: DrugDoesNotContainIndicator Relationship: 
         * COCT_MT220200CA.Ingredient.negationInd 
         * Conformance/Cardinality: MANDATORY (1) <p>Useful for 
         * filtering searches. Allows providers to search for drugs not 
         * containing a specific active ingredients or excipients. E.g. 
         * lactose-free, gluten-free, etc.</p><p>The attribute is 
         * 'mandatory' because the distinction between &quot;does/must 
         * contain&quot; and &quot;does/must not contain&quot; is 
         * essential.</p> <p>An indication that a drug does not contain 
         * the specified ingredient (active or inactive).</p> Un-merged 
         * Business Name: DrugDoesNotContainIndicator Relationship: 
         * COCT_MT220210CA.Ingredient.negationInd 
         * Conformance/Cardinality: REQUIRED (1) <p>Useful for 
         * filtering searches. Allows providers to search for drugs not 
         * containing a specific active ingredients or excipients. E.g. 
         * lactose-free, gluten-free, etc.</p><p>The attribute is 
         * 'populated' because the distinction between &quot;does/must 
         * contain&quot; and &quot;does/must not contain&quot; is 
         * essential, however in some circumstances it is necessary to 
         * say &quot;may contain&quot;.</p> <p>An indication that a 
         * drug does not contain the specified ingredient (active or 
         * inactive).</p> Un-merged Business Name: 
         * DrugDoesNotContainIndicator Relationship: 
         * COCT_MT220110CA.Ingredient.negationInd 
         * Conformance/Cardinality: REQUIRED (1) <p>Useful for 
         * filtering searches. Allows providers to search for drugs not 
         * containing a specific active ingredients or excipients. E.g. 
         * lactose-free, gluten-free, etc.</p><p>The attribute is 
         * 'populated' because the distinction between &quot;does/must 
         * contain&quot; and &quot;does/must not contain&quot; is 
         * essential, however in some circumstances it is necessary to 
         * say &quot;may contain&quot;.</p> <p>An indication that a 
         * drug does not contain the specified ingredient (active or 
         * inactive).</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"negationInd"})]
        public bool? NegationInd {
            get { return this.negationInd.Value; }
            set { this.negationInd.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: IngredientQuantity</summary>
         * 
         * <remarks>Relationship: POME_MT010040CA.Ingredient.quantity 
         * Conformance/Cardinality: REQUIRED (0-1) 
         * <p>CompoundIngredient.amount(numerator)</p> 
         * <p>CompoundIngredient.proportionOfFinal(e.g. 10% = 
         * .1mg/1mg)</p> <p>ZPC.4(quantity)</p> <p>ZPC.5(unit)</p> 
         * <p>ZPJ1.4(quantity)</p> <p>ZPJ1.5(unit)</p> <p>ZPJ1.6(e.g. 
         * 10% = .1mg/1mg)</p> <p>ZCP.3</p> <p>ZDU.4.3</p> 
         * <p>ZDU.6.1.2</p> <p>Compound.448-ED (quantity)</p> 
         * <p>Compound.451-EG (unit)</p> <p>Essential for evaluating 
         * appropriate dosage based on strength, as well as for 
         * creating custom compounds with proper composition.</p> 
         * <p>The quantity of the ingredient in a drug. This is 
         * represented/measured in various forms/units including: mg, 
         * mg/vol, %, etc.</p> Un-merged Business Name: 
         * IngredientQuantity Relationship: 
         * POME_MT010100CA.Ingredient.quantity Conformance/Cardinality: 
         * REQUIRED (0-1) <p>CompoundIngredient.amount(numerator)</p> 
         * <p>CompoundIngredient.proportionOfFinal(e.g. 10% = 
         * .1mg/1mg)</p> <p>ZPC.4(quantity)</p> <p>ZPC.5(unit)</p> 
         * <p>ZPJ1.4(quantity)</p> <p>ZPJ1.5(unit)</p> <p>ZPJ1.6(e.g. 
         * 10% = .1mg/1mg)</p> <p>ZCP.3</p> <p>ZDU.4.3</p> 
         * <p>ZDU.6.1.2</p> <p>Compound.448-ED (quantity)</p> 
         * <p>Compound.451-EG (unit)</p> <p>Essential for evaluating 
         * appropriate dosage based on strength, as well as for 
         * creating custom compounds with proper composition.</p> 
         * <p>The quantity of the ingredient in a drug. This is 
         * represented/measured in various forms/units including: mg, 
         * mg/vol, %, etc.</p> Un-merged Business Name: 
         * DrugIngredientQuantity Relationship: 
         * COCT_MT220100CA.Ingredient.quantity Conformance/Cardinality: 
         * REQUIRED (0-1) <p>CompoundIngredient.amount(numerator)</p> 
         * <p>CompoundIngredient.proportionOfFinal(e.g. 10% = 
         * .1mg/1mg)</p> <p>ZPC.4(quantity)</p> <p>ZPC.5(unit)</p> 
         * <p>ZPJ1.4(quantity)</p> <p>ZPJ1.5(unit)</p> <p>ZPJ1.6(e.g. 
         * 10% = .1mg/1mg)</p> <p>ZCP.3</p> <p>ZDU.4.3</p> 
         * <p>ZDU.6.1.2</p> <p>Compound.448-ED (quantity)</p> 
         * <p>Compound.451-EG (unit)</p> <p>Essential for evaluating 
         * appropriate dosage based on strength, as well as for 
         * creating custom compounds with proper composition.</p> 
         * <p>The quantity of the ingredient in a drug. This is 
         * represented/measured in various forms/units including: mg, 
         * mg/vol, %, etc.</p> Un-merged Business Name: 
         * DrugIngredientQuantity Relationship: 
         * COCT_MT220200CA.Ingredient.quantity Conformance/Cardinality: 
         * REQUIRED (0-1) <p>CompoundIngredient.amount(numerator)</p> 
         * <p>CompoundIngredient.proportionOfFinal(e.g. 10% = 
         * .1mg/1mg)</p> <p>ZPC.4(quantity)</p> <p>ZPC.5(unit)</p> 
         * <p>ZPJ1.4(quantity)</p> <p>ZPJ1.5(unit)</p> <p>ZPJ1.6(e.g. 
         * 10% = .1mg/1mg)</p> <p>ZCP.3</p> <p>ZDU.4.3</p> 
         * <p>ZDU.6.1.2</p> <p>Compound.448-ED (quantity)</p> 
         * <p>Compound.451-EG (unit)</p> <p>Essential for evaluating 
         * appropriate dosage based on strength, as well as for 
         * creating custom compounds with proper composition.</p> 
         * <p>The quantity of the ingredient in a drug. This is 
         * represented/measured in various forms/units including: mg, 
         * mg/vol, %, etc.</p> Un-merged Business Name: 
         * DrugIngredientQuantity Relationship: 
         * COCT_MT220210CA.Ingredient.quantity Conformance/Cardinality: 
         * REQUIRED (0-1) <p>CompoundIngredient.amount(numerator)</p> 
         * <p>CompoundIngredient.proportionOfFinal(e.g. 10% = 
         * .1mg/1mg)</p> <p>ZPC.4(quantity)</p> <p>ZPC.5(unit)</p> 
         * <p>ZPJ1.4(quantity)</p> <p>ZPJ1.5(unit)</p> <p>ZPJ1.6(e.g. 
         * 10% = .1mg/1mg)</p> <p>ZCP.3</p> <p>ZDU.4.3</p> 
         * <p>ZDU.6.1.2</p> <p>Compound.448-ED (quantity)</p> 
         * <p>Compound.451-EG (unit)</p> <p>Essential for evaluating 
         * appropriate dosage based on strength, as well as for 
         * creating custom compounds with proper composition.</p> 
         * <p>The quantity of the ingredient in a drug. This is 
         * represented/measured in various forms/units including: mg, 
         * mg/vol, %, etc.</p> Un-merged Business Name: 
         * DrugIngredientQuantity Relationship: 
         * COCT_MT220110CA.Ingredient.quantity Conformance/Cardinality: 
         * REQUIRED (0-1) <p>CompoundIngredient.amount(numerator)</p> 
         * <p>CompoundIngredient.proportionOfFinal(e.g. 10% = 
         * .1mg/1mg)</p> <p>ZPC.4(quantity)</p> <p>ZPC.5(unit)</p> 
         * <p>ZPJ1.4(quantity)</p> <p>ZPJ1.5(unit)</p> <p>ZPJ1.6(e.g. 
         * 10% = .1mg/1mg)</p> <p>ZCP.3</p> <p>ZDU.4.3</p> 
         * <p>ZDU.6.1.2</p> <p>Compound.448-ED (quantity)</p> 
         * <p>Compound.451-EG (unit)</p> <p>Essential for evaluating 
         * appropriate dosage based on strength, as well as for 
         * creating custom compounds with proper composition.</p> 
         * <p>The quantity of the ingredient in a drug. This is 
         * represented/measured in various forms/units including: mg, 
         * mg/vol, %, etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"quantity"})]
        public PhysicalQuantity Quantity {
            get { return this.quantity.Value; }
            set { this.quantity.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: POME_MT010040CA.Ingredient.ingredient 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * POME_MT010100CA.Ingredient.ingredient 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * COCT_MT220100CA.Ingredient.ingredient 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * COCT_MT220200CA.Ingredient.ingredient 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * COCT_MT220210CA.Ingredient.ingredient 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * COCT_MT220110CA.Ingredient.ingredient 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"ingredient"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged.DrugIngredients Ingredient {
            get { return this.ingredient; }
            set { this.ingredient = value; }
        }

    }

}