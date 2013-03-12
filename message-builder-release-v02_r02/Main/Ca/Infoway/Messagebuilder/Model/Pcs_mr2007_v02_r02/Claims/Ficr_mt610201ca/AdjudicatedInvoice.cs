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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Ficr_mt610201ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Domainvalue;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Adjudicated Invoice</summary>
     * 
     * <p>For the root AdjududicatedInvoiceElementGroup, the 
     * Coverage, Author and OutcomeOf relationships are 
     * Mandatory.</p> <p>All Relationships to the 
     * AdjudicatedInvoiceElementGroup can only be associated with 
     * the root level instance</p> <p>Grouping of invoice elements 
     * or line items.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT610201CA.AdjudicatedInvoiceElementGroup"})]
    public class AdjudicatedInvoice : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Ficr_mt610201ca.IAdjudicatedInvoiceElementChoice {

        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Ficr_mt610201ca.AllowableAmount reference1Allowable;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Merged.AdjudicatedResultOutcome outcomeOf;
        private II id;
        private CV code;
        private CS statusCode;
        private MO netAmt;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Ficr_mt610201ca.Adjudicator author;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Ficr_mt610201ca.AdjudicatedInvoice predecessorAdjudicatedInvoiceElementGroup;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Merged.AdjudicatedInvoiceElementGroup> referenceAdjudicatedInvoiceElementGroup;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Ficr_mt610201ca.AdjudicatedInvoiceCoverage> coverage;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Ficr_mt610201ca.ComponentInvoiceElement> component;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Merged.AdjudicatedResultsGroup referencedByAdjudResultsGroup;

        public AdjudicatedInvoice() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.statusCode = new CSImpl();
            this.netAmt = new MOImpl();
            this.referenceAdjudicatedInvoiceElementGroup = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Merged.AdjudicatedInvoiceElementGroup>();
            this.coverage = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Ficr_mt610201ca.AdjudicatedInvoiceCoverage>();
            this.component = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Ficr_mt610201ca.ComponentInvoiceElement>();
        }
        /**
         * <summary>Relationship: FICR_MT610201CA.Reference4.allowable</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reference1/allowable"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Ficr_mt610201ca.AllowableAmount Reference1Allowable {
            get { return this.reference1Allowable; }
            set { this.reference1Allowable = value; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT610201CA.AdjudicatedInvoiceElementChoice.outcomeOf</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"outcomeOf"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Merged.AdjudicatedResultOutcome OutcomeOf {
            get { return this.outcomeOf; }
            set { this.outcomeOf = value; }
        }

        /**
         * <summary>Business Name: Adjudicated Results Identifier</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT610201CA.AdjudicatedInvoiceElementGroup.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Technique to 
         * identify that the EOB was not electronic (manual) is through 
         * the participation mode code for the adjudicator.</p> 
         * <p>Technique to identify that the EOB was not electronic 
         * (manual) is through the participation mode code for the 
         * adjudicator.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: Invoice Type</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT610201CA.AdjudicatedInvoiceElementGroup.code 
         * Conformance/Cardinality: MANDATORY (1) <p>RXDINV, RXCINV, 
         * CSINV, CPINV only.</p> <p>For Invoice (COB) : Invoice type 
         * (for root) cannot be different from submitted invoice. This 
         * would be a cause for rejecting the invoice.</p><p>For 
         * Adjudication Results: code must match to the corresponding 
         * invoice element that was submitted.</p><p>For Invoice 
         * Nullify Results: this is the identifier of the EOB that was 
         * previously messaged to the Provider.</p><p>Modifiers for the 
         * codes are taken from the same domain (i.e 
         * ActInvoiceGroupCode).</p> <p>For Invoice (COB) : Invoice 
         * type (for root) cannot be different from submitted invoice. 
         * This would be a cause for rejecting the invoice.</p><p>For 
         * Adjudication Results: code must match to the corresponding 
         * invoice element that was submitted.</p><p>For Invoice 
         * Nullify Results: this is the identifier of the EOB that was 
         * previously messaged to the Provider.</p><p>Modifiers for the 
         * codes are taken from the same domain (i.e 
         * ActInvoiceGroupCode).</p> <p>Invoice Type e.g. Healthcare 
         * Services, Rx Dispense, Rx Compound, Healthcare Goods, 
         * Preferred Accomodation</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActInvoiceGroupCode Code {
            get { return (ActInvoiceGroupCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Status of the Adjudicated Invoice</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT610201CA.AdjudicatedInvoiceElementGroup.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Active EOBs are 
         * used to convey interim or preliminary adjudication results. 
         * They can also be used, with information codes, to indicate 
         * that the invoice grouping is held for manual review by the 
         * adjudicator, waiting for other third party information (e.g. 
         * from another provider, employer, etc.).</p><p>Suspended EOBs 
         * are used to convey adjudication results that are awaiting 
         * additional information from the submitting 
         * Provider.</p><p>Complete EOBs are used to convey final 
         * adjudication results, with an associated intent to pay.</p> 
         * <p>For Pharmacy dispense Invoices &amp; Pre-Determinations 
         * (RXDINV, RXCINV), only completed EOBs are permitted to 
         * facilitate real-time processing.</p><p>For Pharmacy clinical 
         * product (CPINV) and clinical service (CSINV) Invoices &amp; 
         * Pre-Determinations, status may be active, suspended or 
         * complete.</p><p>For all Coverage Extension Requests, status 
         * may be active, suspended or complete. For Invoice (COB): 
         * Status code must be complete in order for EOB to be sent to 
         * downstream Adjudicators. If a Provider receives a 
         * non-complete EOB, this cannot be forwarded to a downstream 
         * Adjudicator.</p><p>Field cannot be made mandatory, as it is 
         * not included in Payment Advice Detail messages (only 
         * completed EOBs can be included in a Payment Advice).</p> 
         * <p>Status of the Adjudicated Invoice</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: Paid Amount</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT610201CA.AdjudicatedInvoiceElementGroup.netAmt 
         * Conformance/Cardinality: MANDATORY (1) <p>For Coverage 
         * Extension Results, this is typically not specified, as 
         * dollar limits are noted as information codes.</p> <p>Paid 
         * Amount</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"netAmt"})]
        public Money NetAmt {
            get { return this.netAmt.Value; }
            set { this.netAmt.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT610201CA.AdjudicatedInvoiceElementGroup.author</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Ficr_mt610201ca.Adjudicator Author {
            get { return this.author; }
            set { this.author = value; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT610201CA.AdjudicatedInvoicePredecessor.adjudicatedInvoiceElementGroup</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"predecessor/adjudicatedInvoiceElementGroup"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Ficr_mt610201ca.AdjudicatedInvoice PredecessorAdjudicatedInvoiceElementGroup {
            get { return this.predecessorAdjudicatedInvoiceElementGroup; }
            set { this.predecessorAdjudicatedInvoiceElementGroup = value; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT610201CA.Reference2.adjudicatedInvoiceElementGroup</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reference/adjudicatedInvoiceElementGroup"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Merged.AdjudicatedInvoiceElementGroup> ReferenceAdjudicatedInvoiceElementGroup {
            get { return this.referenceAdjudicatedInvoiceElementGroup; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT610201CA.AdjudicatedInvoiceElementGroup.coverage</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-10)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"coverage"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Ficr_mt610201ca.AdjudicatedInvoiceCoverage> Coverage {
            get { return this.coverage; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT610201CA.AdjudicatedInvoiceElementGroup.component</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1-5)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Ficr_mt610201ca.ComponentInvoiceElement> Component {
            get { return this.component; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT610201CA.AdjudResultsRef.adjudResultsGroup</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"referencedBy/adjudResultsGroup"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Merged.AdjudicatedResultsGroup ReferencedByAdjudResultsGroup {
            get { return this.referencedByAdjudResultsGroup; }
            set { this.referencedByAdjudResultsGroup = value; }
        }

    }

}