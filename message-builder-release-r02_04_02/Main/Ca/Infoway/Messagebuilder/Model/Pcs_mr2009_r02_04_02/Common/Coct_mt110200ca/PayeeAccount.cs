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
 * Last modified: $LastChangedDate: 2015-09-15 11:03:10 -0400 (Tue, 15 Sep 2015) $
 * Revision:      $LastChangedRevision: 9793 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt110200ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Domainvalue;
    using System;


    /**
     * <summary>Business Name: Payee Account</summary>
     * 
     * <p>Payee Bank account, transit number, credit card, etc. for 
     * payment.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT110200CA.Account"})]
    public class PayeeAccount : MessagePartBean {

        private II id;
        private CV code;
        private ST title;
        private TS effectiveTime;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt110200ca.PayeeRole holderPayeeRole;

        public PayeeAccount() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.title = new STImpl();
            this.effectiveTime = new TSImpl();
        }
        /**
         * <summary>Business Name: Account ID</summary>
         * 
         * <remarks>Relationship: COCT_MT110200CA.Account.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Bank account 
         * information can be used to indicate where the Payer is 
         * instructed to direct deposit for a Payee who is not already 
         * known to the Payer.</p> <p>Bank Account, transit number, 
         * credit card, etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: Type of Account</summary>
         * 
         * <remarks>Relationship: COCT_MT110200CA.Account.code 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActAccountCode Code {
            get { return (ActAccountCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: name on credit card</summary>
         * 
         * <remarks>Relationship: COCT_MT110200CA.Account.title 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"title"})]
        public String Title {
            get { return this.title.Value; }
            set { this.title.Value = value; }
        }

        /**
         * <summary>Business Name: expiry date on credit card</summary>
         * 
         * <remarks>Relationship: COCT_MT110200CA.Account.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public PlatformDate EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Relationship: COCT_MT110200CA.Holder.payeeRole</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"holder/payeeRole"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt110200ca.PayeeRole HolderPayeeRole {
            get { return this.holderPayeeRole; }
            set { this.holderPayeeRole = value; }
        }

    }

}