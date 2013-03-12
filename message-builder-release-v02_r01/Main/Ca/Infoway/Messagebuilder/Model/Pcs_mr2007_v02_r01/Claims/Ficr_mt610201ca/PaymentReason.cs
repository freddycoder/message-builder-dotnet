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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Ficr_mt610201ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Merged;


    /**
     * <summary>Business Name: Payment Reason</summary>
     * 
     * <p>For spontaneous EOBs, there may be more than 1 EOB for 
     * the same Payment Intent.</p> <p>For deferred adjudication, 
     * this may be of value. Spontaneous EOBs for policies that 
     * were not asked for on an invoice will likely require 
     * separate Payment Intents and/or EOBs.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT610201CA.PaymentIntentReason"})]
    public class PaymentReason : MessagePartBean {

        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Ficr_mt610201ca.IAdjudicatedInvoiceElementChoice adjudicatedInvoiceElementChoice;

        public PaymentReason() {
        }
        /**
         * <summary>Relationship: 
         * FICR_MT610201CA.PaymentIntentReason.adjudicatedInvoiceElementChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"adjudicatedInvoiceElementChoice"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Ficr_mt610201ca.IAdjudicatedInvoiceElementChoice AdjudicatedInvoiceElementChoice {
            get { return this.adjudicatedInvoiceElementChoice; }
            set { this.adjudicatedInvoiceElementChoice = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Merged.AdjudicationResultIdentifier AdjudicatedInvoiceElementChoiceAsAdjudicatedInvoiceElementGroup {
            get { return this.adjudicatedInvoiceElementChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Merged.AdjudicationResultIdentifier ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Merged.AdjudicationResultIdentifier) this.adjudicatedInvoiceElementChoice : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Merged.AdjudicationResultIdentifier) null; }
        }
        public bool HasAdjudicatedInvoiceElementChoiceAsAdjudicatedInvoiceElementGroup() {
            return (this.adjudicatedInvoiceElementChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Merged.AdjudicationResultIdentifier);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Merged.AdjudicatedInvoiceElementLineItem AdjudicatedInvoiceElementChoiceAsAdjudicatedInvoiceElementDetail {
            get { return this.adjudicatedInvoiceElementChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Merged.AdjudicatedInvoiceElementLineItem ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Merged.AdjudicatedInvoiceElementLineItem) this.adjudicatedInvoiceElementChoice : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Merged.AdjudicatedInvoiceElementLineItem) null; }
        }
        public bool HasAdjudicatedInvoiceElementChoiceAsAdjudicatedInvoiceElementDetail() {
            return (this.adjudicatedInvoiceElementChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Merged.AdjudicatedInvoiceElementLineItem);
        }

    }

}