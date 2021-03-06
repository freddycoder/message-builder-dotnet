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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Coct_mt680000ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Domainvalue;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT680000CA.AdjudicatedInvoiceElementGroup"})]
    public class AdjudicatedInvoiceElementGroup : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Coct_mt680000ca.IAdjudicatedInvoiceElementChoice {

        private CV code;
        private CS statusCode;
        private MO netAmt;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Coct_mt680000ca.AdjudicatedInvoiceAuthor author;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Coct_mt680000ca.AdjudicatedInvoiceCoverage> coverage;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Coct_mt680000ca.IAdjudicatedInvoiceElementChoice> componentAdjudicatedInvoiceElementChoice;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Coct_mt680000ca.AdjudicatedResultOutcome outcomeOf;

        public AdjudicatedInvoiceElementGroup() {
            this.code = new CVImpl();
            this.statusCode = new CSImpl();
            this.netAmt = new MOImpl();
            this.coverage = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Coct_mt680000ca.AdjudicatedInvoiceCoverage>();
            this.componentAdjudicatedInvoiceElementChoice = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Coct_mt680000ca.IAdjudicatedInvoiceElementChoice>();
        }
        /**
         * <summary>Business Name: Invoice element group Code</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT680000CA.AdjudicatedInvoiceElementGroup.code 
         * Conformance/Cardinality: MANDATORY (1) <p>(Invoice Type e.g. 
         * Healthcare Services, Rx Dispense, Rx Compound, Healthcare 
         * Goods, Preferred Accomodation</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActInvoiceGroupCode Code {
            get { return (ActInvoiceGroupCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Invoice Status Code</summary>
         * 
         * <remarks>Relationship: 
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
         * <summary>Business Name: Invoice Element amount billed</summary>
         * 
         * <remarks>Relationship: 
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
         * <summary>Relationship: 
         * COCT_MT680000CA.AdjudicatedInvoiceElementGroup.author</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Coct_mt680000ca.AdjudicatedInvoiceAuthor Author {
            get { return this.author; }
            set { this.author = value; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT680000CA.AdjudicatedInvoiceElementGroup.coverage</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1-10)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"coverage"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Coct_mt680000ca.AdjudicatedInvoiceCoverage> Coverage {
            get { return this.coverage; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT680000CA.AdjudicatedInvoiceElementComponent.adjudicatedInvoiceElementChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component/adjudicatedInvoiceElementChoice"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Coct_mt680000ca.IAdjudicatedInvoiceElementChoice> ComponentAdjudicatedInvoiceElementChoice {
            get { return this.componentAdjudicatedInvoiceElementChoice; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT680000CA.AdjudicatedInvoiceElementChoice.outcomeOf</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"outcomeOf"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Coct_mt680000ca.AdjudicatedResultOutcome OutcomeOf {
            get { return this.outcomeOf; }
            set { this.outcomeOf = value; }
        }

    }

}