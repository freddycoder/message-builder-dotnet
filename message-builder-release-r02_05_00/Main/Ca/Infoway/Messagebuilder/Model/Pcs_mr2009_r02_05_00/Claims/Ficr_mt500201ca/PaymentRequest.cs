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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Claims.Ficr_mt500201ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Claims.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt110101ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt110200ca;
    using System.Collections.Generic;


    /**
     * <p>Mood Code: PRP - auth, pre-det, cov.etc. RQO - 
     * invoice</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT500201CA.PaymentRequest"})]
    public class PaymentRequest : MessagePartBean {

        private SET<II, Identifier> id;
        private MO amt;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Claims.Merged.ContactParty primaryPerformerContactParty;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt110200ca.PayeeAccount creditAccount;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt110101ca.Account debitAccount;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Claims.Merged.ProviderBillingTaxAccount> pertinentInformationProviderBillingTaxAccount;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Claims.Ficr_mt500201ca.IInvoiceElementChoice> reasonOfInvoiceElementChoice;

        public PaymentRequest() {
            this.id = new SETImpl<II, Identifier>(typeof(IIImpl));
            this.amt = new MOImpl();
            this.pertinentInformationProviderBillingTaxAccount = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Claims.Merged.ProviderBillingTaxAccount>();
            this.reasonOfInvoiceElementChoice = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Claims.Ficr_mt500201ca.IInvoiceElementChoice>();
        }
        /**
         * <summary>Business Name: Invoice Identifier</summary>
         * 
         * <remarks>Relationship: FICR_MT500201CA.PaymentRequest.id 
         * Conformance/Cardinality: MANDATORY (1-9)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public ICollection<Identifier> Id {
            get { return this.id.RawSet(); }
        }

        /**
         * <summary>Business Name: Total Billed Amount</summary>
         * 
         * <remarks>Relationship: FICR_MT500201CA.PaymentRequest.amt 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"amt"})]
        public Money Amt {
            get { return this.amt.Value; }
            set { this.amt.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT500201CA.PaymentRequestAttention.contactParty</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"primaryPerformer/contactParty"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Claims.Merged.ContactParty PrimaryPerformerContactParty {
            get { return this.primaryPerformerContactParty; }
            set { this.primaryPerformerContactParty = value; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT500201CA.PaymentRequestPayee.account</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"credit/account"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt110200ca.PayeeAccount CreditAccount {
            get { return this.creditAccount; }
            set { this.creditAccount = value; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT500201CA.PaymentRequestPayor.account</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"debit/account"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt110101ca.Account DebitAccount {
            get { return this.debitAccount; }
            set { this.debitAccount = value; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT500201CA.PertinentInformation.providerBillingTaxAccount</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"pertinentInformation/providerBillingTaxAccount"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Claims.Merged.ProviderBillingTaxAccount> PertinentInformationProviderBillingTaxAccount {
            get { return this.pertinentInformationProviderBillingTaxAccount; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT500201CA.PaymentRequestReason.invoiceElementChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reasonOf/invoiceElementChoice"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Claims.Ficr_mt500201ca.IInvoiceElementChoice> ReasonOfInvoiceElementChoice {
            get { return this.reasonOfInvoiceElementChoice; }
        }

    }

}