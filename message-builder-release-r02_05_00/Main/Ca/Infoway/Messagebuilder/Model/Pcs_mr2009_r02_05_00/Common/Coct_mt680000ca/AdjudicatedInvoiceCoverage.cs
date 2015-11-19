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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt680000ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <p>Association is required, 1..1 and not mandatory, as EOB 
     * may have been generated from a non-HL7 EOB and the Provider 
     * s/w will not know the Policy Type to put in the target 
     * act.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT680000CA.AdjudicatedInvoiceCoverage"})]
    public class AdjudicatedInvoiceCoverage : MessagePartBean {

        private INT sequenceNumber;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt680000ca.FinancialContractPolicyAccount policyOrAccount;

        public AdjudicatedInvoiceCoverage() {
            this.sequenceNumber = new INTImpl();
        }
        /**
         * <summary>Business Name: COB Priority</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT680000CA.AdjudicatedInvoiceCoverage.sequenceNumber 
         * Conformance/Cardinality: MANDATORY (1) <p>COB priority as 
         * adjudicated primary, secondary, etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"sequenceNumber"})]
        public int? SequenceNumber {
            get { return this.sequenceNumber.Value; }
            set { this.sequenceNumber.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT680000CA.AdjudicatedInvoiceCoverage.policyOrAccount</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"policyOrAccount"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt680000ca.FinancialContractPolicyAccount PolicyOrAccount {
            get { return this.policyOrAccount; }
            set { this.policyOrAccount = value; }
        }

    }

}