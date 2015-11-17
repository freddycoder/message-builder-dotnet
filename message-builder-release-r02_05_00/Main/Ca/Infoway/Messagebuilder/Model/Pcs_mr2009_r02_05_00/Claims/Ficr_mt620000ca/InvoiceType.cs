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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Claims.Ficr_mt620000ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Domainvalue;


    /**
     * <summary>Business Name: Invoice Type</summary>
     * 
     * <p>Cancel reasons are noted in the control wrapper</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT620000CA.InvoiceElementGroup"})]
    public class InvoiceType : MessagePartBean {

        private II id;
        private CV code;
        private MO netAmt;

        public InvoiceType() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.netAmt = new MOImpl();
        }
        /**
         * <summary>Business Name: Invoice Grouping Identifiers</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT620000CA.InvoiceElementGroup.id 
         * Conformance/Cardinality: MANDATORY (1) <p>There are some 
         * situations where more than 1 identifier for this object can 
         * be included in a message.</p> <p>For example:</p><p>1. 
         * unique invoice group identifier, independent of adjudicator 
         * recipient.</p><p>2. sequential invoice grouping identifier 
         * by adjudicator.</p><p>Obligation on adjudicator is to return 
         * and communicate about this item with all identifiers (i.e. 
         * identifier 1. and 2.).</p> <p></p></remarks>
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
         * FICR_MT620000CA.InvoiceElementGroup.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Each Invoice Type 
         * is used to specify 1. vocabulary, 2. structure of the 
         * Invoice Element Choice and 3. which Billable Act(s) can be 
         * included for the specified Invoice Type.</p><p>Information 
         * on constraints for the Invoice Type will be found in the 
         * NeCST Message Specifications. Each Benefit Group will 
         * indicate which Invoice Types will be supported by that 
         * Benefit Group.</p><p>Invoice Types will not generate unique 
         * and distinct XML schemas that can tested independent of each 
         * other. They must be tested together within an Message 
         * Type.</p> <p>Invoice Type e.g. Healthcare Services, Rx 
         * Dispense, Rx Compound, Healthcare Goods, Preferred 
         * Accomodation</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActInvoiceGroupType Code {
            get { return (ActInvoiceGroupType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Invoice sub-total</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT620000CA.InvoiceElementGroup.netAmt 
         * Conformance/Cardinality: MANDATORY (1) <p>For Cancel 
         * Request: This would serve as a cross-check for the 
         * Adjudicator for the Invoice Grouping that is being 
         * cancelled.</p><p>Attribute cannot be mandatory as it may not 
         * be present for a Coverage Extension Request.</p> <p>Invoice 
         * sub-total - This is the sum of the Submitted Invoice Line 
         * amounts; Identifies the total monetary amount billed for the 
         * invoice element.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"netAmt"})]
        public Money NetAmt {
            get { return this.netAmt.Value; }
            set { this.netAmt.Value = value; }
        }

    }

}