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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt680000ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Domainvalue;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: AdjudicatedInvoiceElementGroup</summary>
     * 
     * <remarks>FICR_MT630000CA.AdjudicatedInvoiceElementGroup: 
     * Adjudicated Invoice Element Group <p>Group of Invoice 
     * Elements being referenced; ie. group of billable items.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT680000CA.AdjudicatedInvoiceElementGroup","FICR_MT630000CA.AdjudicatedInvoiceElementGroup"})]
    public class AdjudicatedInvoiceElementGroup : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt680000ca.IAdjudicatedInvoiceElementChoice {

        private II id;
        private CV code;
        private CS statusCode;
        private MO netAmt;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Merged.PaymentIntent reasonPaymentIntent;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.AdjudicatedInvoiceElementGroup referenceAdjudicatedInvoiceElementGroup;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Merged.AdjudicatedResultsGroup referencedByAdjudResultsGroup;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.AdjudicatedResultOutcome outcomeOf;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt680000ca.AdjudicatedInvoiceAuthor author;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt680000ca.AdjudicatedInvoiceCoverage> coverage;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt680000ca.IAdjudicatedInvoiceElementChoice> componentAdjudicatedInvoiceElementChoice;

        public AdjudicatedInvoiceElementGroup() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.statusCode = new CSImpl();
            this.netAmt = new MOImpl();
            this.coverage = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt680000ca.AdjudicatedInvoiceCoverage>();
            this.componentAdjudicatedInvoiceElementChoice = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt680000ca.IAdjudicatedInvoiceElementChoice>();
        }
        /**
         * <summary>Business Name: AdjudicationResultId</summary>
         * 
         * <remarks>Un-merged Business Name: AdjudicationResultId 
         * Relationship: 
         * FICR_MT630000CA.AdjudicatedInvoiceElementGroup.id 
         * Conformance/Cardinality: MANDATORY (1) <p>May include data 
         * centre and sequence numbers</p> <p>Adjudication Result Id - 
         * Technique to identify that the EOB was not electronic 
         * (manual) is through the participation mode code for the 
         * adjudicator.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: InvoiceType</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT630000CA.AdjudicatedInvoiceElementGroup.code 
         * Conformance/Cardinality: MANDATORY (1) <p>For Invoice (COB) 
         * : Invoice type (for root) cannot be different from submitted 
         * invoice. This would be a cause for rejecting the 
         * invoice.</p><p>For Adjudication Results: code must match to 
         * the corresponding invoice element that was 
         * submitted.</p><p>For Invoice Nullify Results: this is the 
         * identifier of the EOB that was previously messaged to the 
         * Provider.</p><p>Modifiers for the codes are taken from the 
         * same domain (i.e ActInvoiceGroupCode).</p> <p>Invoice Type 
         * e.g. Healthcare Services, Rx Dispense, Rx Compound</p> 
         * Un-merged Business Name: InvoiceElementGroupCode 
         * Relationship: 
         * COCT_MT680000CA.AdjudicatedInvoiceElementGroup.code 
         * Conformance/Cardinality: MANDATORY (1) <p>(Invoice Type e.g. 
         * Healthcare Services, Rx Dispense, Rx Compound, Healthcare 
         * Goods, Preferred Accomodation</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActInvoiceGroupType Code {
            get { return (ActInvoiceGroupType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: InvoiceStatus</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT630000CA.AdjudicatedInvoiceElementGroup.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Active EOBs are 
         * used to convey interim or preliminary adjudication results. 
         * They can also be used, with information codes, to indicate 
         * that the invoice grouping is held for manual review by the 
         * adjudicator, waiting for other third party information (e.g. 
         * from another provider, employer, etc.).</p><p>Suspended EOBs 
         * are used to convey adjudication results that are awaiting 
         * additional information from the submitting 
         * Provider.</p><p>Complete EOBs are used to convey final 
         * adjudication results, with an associated intent to 
         * pay.</p><p>For Invoice (COB): Status code must be complete 
         * in order for EOB to be sent to downstream Adjudicators. If a 
         * Provider receives a non-complete EOB, this cannot be 
         * forwarded to a downstream Adjudicator.</p><p>Field cannot be 
         * made mandatory, as it is not included in Payment Advice 
         * Detail messages (only completed EOBs can be included in a 
         * Payment Advice).</p> <p>Codes representing the defined 
         * states of an Act as defined by the Act class state 
         * machine.</p> Un-merged Business Name: InvoiceStatusCode 
         * Relationship: 
         * COCT_MT680000CA.AdjudicatedInvoiceElementGroup.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>(Completed when 
         * done, Suspended if waiting for external )(information, 
         * Active if delayed by Adjudicator or the EOB is an 
         * estimate</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: PaidAmount</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT630000CA.AdjudicatedInvoiceElementGroup.netAmt 
         * Conformance/Cardinality: MANDATORY (1) <p>For Coverage 
         * Extension Results, this is typically not specified, as 
         * dollar limits are noted as information codes</p> <p>Paid 
         * Amount</p> Un-merged Business Name: 
         * InvoiceElementAmountBilled Relationship: 
         * COCT_MT680000CA.AdjudicatedInvoiceElementGroup.netAmt 
         * Conformance/Cardinality: MANDATORY (1) <p>Identifies the 
         * total monetary amount billed for the invoice element. = 
         * unit_qty * unit_price_amt * factor_nbr * points_nbr. E.g. 
         * $150 CAD</p></remarks>
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
         * FICR_MT630000CA.PaymentIntentReason.paymentIntent 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reason/paymentIntent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Merged.PaymentIntent ReasonPaymentIntent {
            get { return this.reasonPaymentIntent; }
            set { this.reasonPaymentIntent = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT630000CA.Reference.adjudicatedInvoiceElementGroup 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reference/adjudicatedInvoiceElementGroup"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.AdjudicatedInvoiceElementGroup ReferenceAdjudicatedInvoiceElementGroup {
            get { return this.referenceAdjudicatedInvoiceElementGroup; }
            set { this.referenceAdjudicatedInvoiceElementGroup = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT630000CA.AdjudResultsRef.adjudResultsGroup 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"referencedBy/adjudResultsGroup"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Merged.AdjudicatedResultsGroup ReferencedByAdjudResultsGroup {
            get { return this.referencedByAdjudResultsGroup; }
            set { this.referencedByAdjudResultsGroup = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT680000CA.AdjudicatedInvoiceElementChoice.outcomeOf 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"outcomeOf"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.AdjudicatedResultOutcome OutcomeOf {
            get { return this.outcomeOf; }
            set { this.outcomeOf = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT680000CA.AdjudicatedInvoiceElementGroup.author 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt680000ca.AdjudicatedInvoiceAuthor Author {
            get { return this.author; }
            set { this.author = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT680000CA.AdjudicatedInvoiceElementGroup.coverage 
         * Conformance/Cardinality: POPULATED (1-10)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"coverage"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt680000ca.AdjudicatedInvoiceCoverage> Coverage {
            get { return this.coverage; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT680000CA.AdjudicatedInvoiceElementComponent.adjudicatedInvoiceElementChoice 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component/adjudicatedInvoiceElementChoice"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt680000ca.IAdjudicatedInvoiceElementChoice> ComponentAdjudicatedInvoiceElementChoice {
            get { return this.componentAdjudicatedInvoiceElementChoice; }
        }

    }

}