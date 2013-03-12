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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Qucr_mt830201ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Domainvalue;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Type of Summary</summary>
     * 
     * <p>Detailed information required for financial 
     * reconciliation.</p> <p>(Invoice Type e.g. Healthcare 
     * Services, Rx Dispense, Rx Compound, Healthcare Goods, 
     * Preferred Accomodation</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"QUCR_MT830201CA.AdjudResultsGroup"})]
    public class TypeOfSummary : MessagePartBean {

        private CD code;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private MO netAmt;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Qucr_mt830201ca.AdjudicationResultIdentifier> referenceAdjudicatedInvoiceElementGroup;

        public TypeOfSummary() {
            this.code = new CDImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.netAmt = new MOImpl();
            this.referenceAdjudicatedInvoiceElementGroup = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Qucr_mt830201ca.AdjudicationResultIdentifier>();
        }
        /**
         * <summary>Business Name: Type of Summary</summary>
         * 
         * <remarks>Relationship: 
         * QUCR_MT830201CA.AdjudResultsGroup.code 
         * Conformance/Cardinality: MANDATORY (1) <p>For Payment 
         * Advice: Code also specifies the type of adjustment for a 
         * payment advice (e.g. CFWD - carry forward adjustment).</p> 
         * <p>-For Payment Advice: For Vision Care payment advices, 
         * RETRO adjustments will always include references to the EOBs 
         * that made up the retroactive adjustment.</p><p>For Payment 
         * Advice: For Pharmacy payment advices, RETRO adjustments will 
         * not include references to the EOBs that made up the 
         * retroactive adjustment. Providers must submit a Payment 
         * Advice Query message to get the EOBs referenced by the RETRO 
         * amount. The Payment Advice Detail message, however, is not 
         * currently supported in Pharmacy.</p><p>For Payment Advice: 
         * Code also specifies the type of adjustment for a payment 
         * advice (e.g. CFWD - carry forward adjustment).</p> <p>Codes 
         * representing a grouping of invoice elements (totals, 
         * sub-totals), reported through a Payment Advice or a 
         * Statement of Financial Activity (SOFA). The code can 
         * represent summaries by day, location, payee and other cost 
         * elements such as bonus, retroactive adjustment and 
         * transaction fees.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActInvoiceAdjudicationPaymentSummaryType Code {
            get { return (ActInvoiceAdjudicationPaymentSummaryType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Summary period date range</summary>
         * 
         * <remarks>Relationship: 
         * QUCR_MT830201CA.AdjudResultsGroup.effectiveTime 
         * Conformance/Cardinality: POPULATED (1) <p>Time period for 
         * the payment or summary period. Can also indicate time period 
         * over which the clawback and/or retro adjustment applies</p> 
         * <p>For Payment Advice: Can also indicate time period over 
         * which the clawback and/or retro adjustment applies.</p> 
         * <p>Summary period date range - Time period for the payment 
         * or summary period.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: Summary Period Amt</summary>
         * 
         * <remarks>Relationship: 
         * QUCR_MT830201CA.AdjudResultsGroup.netAmt 
         * Conformance/Cardinality: MANDATORY (1) <p>The 
         * AdjudResultsGroup.netAmt must equal the sum of all immediate 
         * children AdjudResultsGroup.netAmt</p> <p>On SOFA Summary, 
         * this could be used to specify the amount that will be 
         * included in the Payment Advice. In this situation, it should 
         * equal the net effect of all AdjudResultsGroupSummaryData 
         * elements that would appear in the Payment Advice.</p> 
         * <p>Summary Period Amt</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"netAmt"})]
        public Money NetAmt {
            get { return this.netAmt.Value; }
            set { this.netAmt.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * QUCR_MT830201CA.AdjudResultsRef.adjudicatedInvoiceElementGroup</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reference/adjudicatedInvoiceElementGroup"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Qucr_mt830201ca.AdjudicationResultIdentifier> ReferenceAdjudicatedInvoiceElementGroup {
            get { return this.referenceAdjudicatedInvoiceElementGroup; }
        }

    }

}