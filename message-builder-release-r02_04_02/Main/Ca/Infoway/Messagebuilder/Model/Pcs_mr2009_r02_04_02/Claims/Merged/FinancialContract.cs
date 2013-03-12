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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Domainvalue;


    /**
     * <summary>FICR_MT600201CA.FinancialContract: (no business 
     * name)</summary>
     * 
     * <p>Need amount for contract (max allowable amount), not 
     * needed for e-Claims</p> FICR_MT500201CA.FinancialContract: 
     * (no business name) <p>Need amount for contract (max 
     * allowable amount), not needed for e-Claims</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT500201CA.FinancialContract","FICR_MT600201CA.FinancialContract"})]
    public class FinancialContract : MessagePartBean {

        private II id;
        private CV code;

        public FinancialContract() {
            this.id = new IIImpl();
            this.code = new CVImpl();
        }
        /**
         * <summary>Business Name: FinancialContractID</summary>
         * 
         * <remarks>Un-merged Business Name: FinancialContractID 
         * Relationship: FICR_MT600201CA.FinancialContract.id 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: FinancialContractID Relationship: 
         * FICR_MT500201CA.FinancialContract.id 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: BillingArrangementType</summary>
         * 
         * <remarks>Un-merged Business Name: BillingArrangementType 
         * Relationship: FICR_MT600201CA.FinancialContract.code 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: BillingArrangementType Relationship: 
         * FICR_MT500201CA.FinancialContract.code 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActBillingArrangementType Code {
            get { return (ActBillingArrangementType) this.code.Value; }
            set { this.code.Value = value; }
        }

    }

}