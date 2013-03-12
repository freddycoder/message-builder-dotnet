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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Coct_mt280001ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Ficr_mt600201ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Domainvalue;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>FICR_MT620000CA.InvoiceElementGroup: Invoice Type</summary>
     * 
     * <p>Cancel reasons are noted in the control wrapper</p> 
     * FICR_MT600201CA.InvoiceElementGroup: Invoice Grouping 
     * Information <p>There are some situations where all items for 
     * a patient need to be included in 1 Invoice Grouping, as the 
     * final determination (adjudication results) will not be made 
     * until all invoice elements are considered for that 
     * patient.</p> <p>The statement and justification of the Total 
     * Billed Amount. For an invoice it is the statement and 
     * justification of the Total Billed amount requesting the 
     * determination of the amount owed by the payor for the 
     * service(s) that either have occurred or are on-going. For an 
     * authorization it represents the statement and justification 
     * of an invoice for a future service requesting the 
     * determination of the amount owed that is guaranteed by the 
     * payor. For a pre-determination, it represents the statement 
     * and possible justification for an invoice for a future 
     * service to determine the possible amount owed by the 
     * payor.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT600201CA.InvoiceElementGroup","FICR_MT620000CA.InvoiceElementGroup","QUCR_MT830201CA.InvoiceElementGroup"})]
    public class InvoiceType : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Ficr_mt600201ca.IInvoiceElementChoice {

        private II id;
        private CV code;
        private MO netAmt;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Coct_mt280001ca.IA_BillableActChoice> reasonOfBillableActChoice;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Merged.BusinessArrangement inFulfillmentOfFinancialContract;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Ficr_mt600201ca.Attachments> pertinentInformation;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Ficr_mt600201ca.CrossReferenceIdentifier> predecessorInvoiceElementCrossReference;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Merged.AdjudicatedInvoiceElementGroup> referenceAdjudicatedInvoiceElementGroup;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Merged.PolicyIdentifier> coveragePolicyOrAccount;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Ficr_mt600201ca.InvoiceComponent> component;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Ficr_mt600201ca.InvoiceOverrideDetails> triggerForInvoiceElementOverride;

        public InvoiceType() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.netAmt = new MOImpl();
            this.reasonOfBillableActChoice = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Coct_mt280001ca.IA_BillableActChoice>();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.pertinentInformation = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Ficr_mt600201ca.Attachments>();
            this.predecessorInvoiceElementCrossReference = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Ficr_mt600201ca.CrossReferenceIdentifier>();
            this.referenceAdjudicatedInvoiceElementGroup = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Merged.AdjudicatedInvoiceElementGroup>();
            this.coveragePolicyOrAccount = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Merged.PolicyIdentifier>();
            this.component = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Ficr_mt600201ca.InvoiceComponent>();
            this.triggerForInvoiceElementOverride = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Ficr_mt600201ca.InvoiceOverrideDetails>();
        }
        /**
         * <summary>Un-merged Business Name: InvoiceGroupingIdentifiers</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT620000CA.InvoiceElementGroup.id 
         * Conformance/Cardinality: MANDATORY (1) <p>There are some 
         * situations where more than 1 identifier for this object can 
         * be included in a message.</p> <p>For example:</p> Un-merged 
         * Business Name: InvoiceGroupID Relationship: 
         * QUCR_MT830201CA.InvoiceElementGroup.id 
         * Conformance/Cardinality: MANDATORY (1) <p>For example:</p> 
         * <p>Set of identifiers that uniquely identify the Invoice 
         * Grouping.</p> Un-merged Business Name: 
         * InvoiceGroupingIdentifierS Relationship: 
         * FICR_MT600201CA.InvoiceElementGroup.id 
         * Conformance/Cardinality: MANDATORY (1) <p>For example:</p> 
         * <p>OID (object identifier) + unique number generated by the 
         * pharmacy software for the specific invoice element 
         * group.</p><p>For child Invoice Element Groups, the 
         * identifier will be the same as its parent Invoice Element 
         * Group, appended with a &quot;.x&quot;, where &quot;x&quot; 
         * is a number siginifying the occurence of this item under its 
         * parent. For example, the parent id is &quot;12942&quot; and 
         * this is the 2nd item under the parent. Therefore, the id for 
         * this item would be &quot;12942.2&quot;.</p><p>Must not be 
         * the same identifier as the PaymentRequest.id or the 
         * InvoiceElementDetail.id.</p> <p>Set of identifiers that 
         * uniquely identify the Invoice Grouping.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: InvoiceType</summary>
         * 
         * <remarks>Un-merged Business Name: (no business name 
         * specified) Relationship: 
         * FICR_MT620000CA.InvoiceElementGroup.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Information on 
         * constraints for the Invoice Type will be found in the NeCST 
         * Message Specifications. Each Benefit Group will indicate 
         * which Invoice Types will be supported by that Benefit 
         * Group.</p><p>Invoice Types will not generate unique and 
         * distinct XML schemas that can tested independent of each 
         * other. They must be tested together within an Message 
         * Type.</p> <p>Invoice Type e.g. Healthcare Services, Rx 
         * Dispense, Rx Compound, Healthcare Goods, Preferred 
         * Accomodation</p> Un-merged Business Name: InvoiceType 
         * Relationship: FICR_MT600201CA.InvoiceElementGroup.code 
         * Conformance/Cardinality: MANDATORY (1) <p>RXDINV, RXCINV, 
         * CSINV, CPINV, CSPINV only for root invoice element group. 
         * RXDINV only for root invoice element group. DRGING for 
         * specify drug group.</p> <p>Invoice Type is the indication to 
         * the payor as to the content rules to apply when processing 
         * and adjudicating the invoice. Basically, the structure of 
         * the invoice grouping. Ie. Clinical Product, Clinical 
         * Service, Preferred Accom, Rx Dispense, Rx Compound</p> 
         * <p>This is used to indicate the type of Invoice 
         * Grouping.</p><p>Information on constraints for the Invoice 
         * Type will be found in the NeCST Message Specifications. Each 
         * Benefit Group will indicate which Invoice Types will be 
         * supported by that Benefit Group.</p><p>Invoice Types will 
         * not generate unique and distinct XML schemas that can tested 
         * independent of each other. They must be tested together 
         * within an Message Type.</p> <p>Invoice Type e.g. Healthcare 
         * Services, Rx Dispense, Rx Compound, Healthcare Goods, 
         * Preferred Accomodation</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActInvoiceGroupCode Code {
            get { return (ActInvoiceGroupCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: InvoiceSubTotal</summary>
         * 
         * <remarks>Un-merged Business Name: InvoiceSubTotal 
         * Relationship: FICR_MT620000CA.InvoiceElementGroup.netAmt 
         * Conformance/Cardinality: MANDATORY (1) <p>For Cancel 
         * Request: This would serve as a cross-check for the 
         * Adjudicator for the Invoice Grouping that is being 
         * cancelled.</p><p>Attribute cannot be mandatory as it may not 
         * be present for a Coverage Extension Request.</p> <p>Invoice 
         * sub-total - This is the sum of the Submitted Invoice Line 
         * amounts; Identifies the total monetary amount billed for the 
         * invoice element.</p> Un-merged Business Name: 
         * InvoiceSubTotal Relationship: 
         * FICR_MT600201CA.InvoiceElementGroup.netAmt 
         * Conformance/Cardinality: MANDATORY (1) <p>For Cancel 
         * Request: This would serve as a cross-check for the 
         * Adjudicator for the Invoice Grouping that is being 
         * cancelled.</p><p>Attribute cannot be mandatory as it may not 
         * be present for a Coverage Extension Request.</p> <p>For 
         * Coverage Extension Results: Some adjudicators will indicate 
         * a dollar amount allowed for the coverage 
         * extension.</p><p>RxS1: Sum of InvoiceElementDetail.netAmt 
         * for all immediate child invoice elements. The root invoice 
         * element group will be the transaction total (invoice 
         * total).</p> <p>Identifies the total monetary amount billed 
         * for the invoice element. This is the sum of the Submitted 
         * Invoice Line amounts.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"netAmt"})]
        public Money NetAmt {
            get { return this.netAmt.Value; }
            set { this.netAmt.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT600201CA.InvoiceElementReason.billableActChoice 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reasonOf/billableActChoice"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Coct_mt280001ca.IA_BillableActChoice> ReasonOfBillableActChoice {
            get { return this.reasonOfBillableActChoice; }
        }

        /**
         * <summary>Business Name: TimePeriodForInvoice</summary>
         * 
         * <remarks>Un-merged Business Name: TimePeriodForInvoice 
         * Relationship: 
         * FICR_MT600201CA.InvoiceElementGroup.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Transmission of 
         * this information suggests a transfer of liability for how 
         * this information/invoice is 
         * used/communicated.</p><p>Legislation and service level 
         * agreements typically cover the requirement to send this code 
         * with every invoice.</p><p>This will be required for Alberta 
         * physician invoices only.</p> <p>This may be useful for 
         * nursing homes. For example, they get paid so much $ per 
         * patient per month and would need to specify the time period 
         * for the invoice.</p> <p>The period of time that the invoice 
         * pertains to. This may be a specific date or a date range (as 
         * in the month of January) for the invoice.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT600201CA.InvoiceElementGroupInFulfillmentOf.financialContract 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"inFulfillmentOf/financialContract"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Merged.BusinessArrangement InFulfillmentOfFinancialContract {
            get { return this.inFulfillmentOfFinancialContract; }
            set { this.inFulfillmentOfFinancialContract = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT600201CA.InvoiceElementGroup.pertinentInformation 
         * Conformance/Cardinality: REQUIRED (0-10)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"pertinentInformation"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Ficr_mt600201ca.Attachments> PertinentInformation {
            get { return this.pertinentInformation; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT600201CA.Predecessor.invoiceElementCrossReference 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"predecessor/invoiceElementCrossReference"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Ficr_mt600201ca.CrossReferenceIdentifier> PredecessorInvoiceElementCrossReference {
            get { return this.predecessorInvoiceElementCrossReference; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT600201CA.Reference.adjudicatedInvoiceElementGroup 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reference/adjudicatedInvoiceElementGroup"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Merged.AdjudicatedInvoiceElementGroup> ReferenceAdjudicatedInvoiceElementGroup {
            get { return this.referenceAdjudicatedInvoiceElementGroup; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT600201CA.InvoiceElementCoverage.policyOrAccount 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"coverage/policyOrAccount"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Merged.PolicyIdentifier> CoveragePolicyOrAccount {
            get { return this.coveragePolicyOrAccount; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT600201CA.InvoiceElementGroup.component 
         * Conformance/Cardinality: MANDATORY (1-10)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Ficr_mt600201ca.InvoiceComponent> Component {
            get { return this.component; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT600201CA.Suggests.invoiceElementOverride 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"triggerFor/invoiceElementOverride"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Ficr_mt600201ca.InvoiceOverrideDetails> TriggerForInvoiceElementOverride {
            get { return this.triggerForInvoiceElementOverride; }
        }

    }

}