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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt680000ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Domainvalue;
    using System;


    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT680000CA.AdjudicatedInvoiceElementDetail"})]
    public class InvoiceElementDetail : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt680000ca.IAdjudicatedInvoiceElementChoice {

        private CV code;
        private PQ unitQuantity;
        private RTO<Money, PhysicalQuantity> unitPriceAmt;
        private MO netAmt;
        private INT factorNumber;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt680000ca.AdjudicatedResultOutcome outcomeOf;

        public InvoiceElementDetail() {
            this.code = new CVImpl();
            this.unitQuantity = new PQImpl();
            this.unitPriceAmt = new RTOImpl<Money, PhysicalQuantity>();
            this.netAmt = new MOImpl();
            this.factorNumber = new INTImpl();
        }
        /**
         * <summary>Business Name: Product/service Code</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT680000CA.AdjudicatedInvoiceElementDetail.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Domain for 
         * AdjudicatedInvoiceElementDetail.code is 
         * GenericBillableItemModifier</p> <p>Product/Service Code e.g. 
         * Office Visit ,Taxes, Markup, Dispense, including 
         * Product/Service Code Modifier e.g. northern isolation, off 
         * hours specialty, on call</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActInvoiceDetailCode Code {
            get { return (ActInvoiceDetailCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Quantity per Unit</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT680000CA.AdjudicatedInvoiceElementDetail.unitQuantity 
         * Conformance/Cardinality: REQUIRED (1) <p>e.g. 3 {boxes}</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"unitQuantity"})]
        public PhysicalQuantity UnitQuantity {
            get { return this.unitQuantity.Value; }
            set { this.unitQuantity.Value = value; }
        }

        /**
         * <summary>Business Name: Price Per Unit</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT680000CA.AdjudicatedInvoiceElementDetail.unitPriceAmt 
         * Conformance/Cardinality: REQUIRED (1) <p>e.g. $50 CAD/ 1 
         * {box}</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"unitPriceAmt"})]
        public Ratio<Money, PhysicalQuantity> UnitPriceAmt {
            get { return this.unitPriceAmt.Value; }
            set { this.unitPriceAmt.Value = value; }
        }

        /**
         * <summary>Business Name: Invoice Element Amount billed</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT680000CA.AdjudicatedInvoiceElementDetail.netAmt 
         * Conformance/Cardinality: MANDATORY (1) <p>= unit_qty * 
         * unit_price_amt * factor_nbr * points_nbr. E.g. $150 CAD</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"netAmt"})]
        public Money NetAmt {
            get { return this.netAmt.Value; }
            set { this.netAmt.Value = value; }
        }

        /**
         * <summary>Business Name: Multiplier for Taxes.</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT680000CA.AdjudicatedInvoiceElementDetail.factorNumber 
         * Conformance/Cardinality: REQUIRED (0-1) <p>multiplier, can 
         * be used for tax percentages such as 0.07</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"factorNumber"})]
        public int? FactorNumber {
            get { return this.factorNumber.Value; }
            set { this.factorNumber.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT680000CA.AdjudicatedInvoiceElementChoice.outcomeOf</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"outcomeOf"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt680000ca.AdjudicatedResultOutcome OutcomeOf {
            get { return this.outcomeOf; }
            set { this.outcomeOf = value; }
        }

    }

}