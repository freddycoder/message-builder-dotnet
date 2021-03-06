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
 * Last modified: $LastChangedDate: 2015-09-15 11:09:53 -0400 (Tue, 15 Sep 2015) $
 * Revision:      $LastChangedRevision: 9796 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt500201ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged;
    using System;


    /**
     * <p>At most 5 levels of recursion, with n children at each 
     * level. Root level counts as level 1.</p>
     * 
     * <p>This allows for an Invoice Grouping to be composed of one 
     * or more invoice element groups and/or details. There must be 
     * one leaf detail.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT500201CA.InvoiceElementComponent"})]
    public class InvoiceElementComponent : MessagePartBean {

        private INT sequenceNumber;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt500201ca.IInvoiceElementChoice invoiceElementChoice;

        public InvoiceElementComponent() {
            this.sequenceNumber = new INTImpl();
        }
        /**
         * <summary>Business Name: Invoice Element Sequence Number</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT500201CA.InvoiceElementComponent.sequenceNumber 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"sequenceNumber"})]
        public int? SequenceNumber {
            get { return this.sequenceNumber.Value; }
            set { this.sequenceNumber.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT500201CA.InvoiceElementComponent.invoiceElementChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"invoiceElementChoice"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt500201ca.IInvoiceElementChoice InvoiceElementChoice {
            get { return this.invoiceElementChoice; }
            set { this.invoiceElementChoice = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.InvoiceElementGroup InvoiceElementChoiceAsInvoiceElementGroup {
            get { return this.invoiceElementChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.InvoiceElementGroup ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.InvoiceElementGroup) this.invoiceElementChoice : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.InvoiceElementGroup) null; }
        }
        public bool HasInvoiceElementChoiceAsInvoiceElementGroup() {
            return (this.invoiceElementChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.InvoiceElementGroup);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.InvoiceElementDetail InvoiceElementChoiceAsInvoiceElementDetail {
            get { return this.invoiceElementChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.InvoiceElementDetail ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.InvoiceElementDetail) this.invoiceElementChoice : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.InvoiceElementDetail) null; }
        }
        public bool HasInvoiceElementChoiceAsInvoiceElementDetail() {
            return (this.invoiceElementChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.InvoiceElementDetail);
        }

    }

}