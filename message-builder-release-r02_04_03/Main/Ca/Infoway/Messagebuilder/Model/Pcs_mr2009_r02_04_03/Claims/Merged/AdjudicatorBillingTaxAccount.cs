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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Domainvalue;


    /**
     * <summary>FICR_MT610201CA.AdjudicatorBillingTaxAccount: (no 
     * business name)</summary>
     * 
     * <p>Can be used to specify the appropriate GST number and 
     * other tax numbers.</p> 
     * FICR_MT510201CA.AdjudicatorBillingTaxAccount: (no business 
     * name) <p>Can be used to specify the appropriate GST number 
     * and other tax numbers.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT510201CA.AdjudicatorBillingTaxAccount","FICR_MT610201CA.AdjudicatorBillingTaxAccount"})]
    public class AdjudicatorBillingTaxAccount : MessagePartBean {

        private II id;
        private CV code;

        public AdjudicatorBillingTaxAccount() {
            this.id = new IIImpl();
            this.code = new CVImpl();
        }
        /**
         * <summary>Un-merged Business Name: TaxAcctNo</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT610201CA.AdjudicatorBillingTaxAccount.id 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: TaxAccountNumber Relationship: 
         * FICR_MT510201CA.AdjudicatorBillingTaxAccount.id 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: DetailTaxCode</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT610201CA.AdjudicatorBillingTaxAccount.code 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: AdjudicatorBillingTaxAccount Relationship: 
         * FICR_MT510201CA.AdjudicatorBillingTaxAccount.code 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActInvoiceDetailTaxType Code {
            get { return (ActInvoiceDetailTaxType) this.code.Value; }
            set { this.code.Value = value; }
        }

    }

}