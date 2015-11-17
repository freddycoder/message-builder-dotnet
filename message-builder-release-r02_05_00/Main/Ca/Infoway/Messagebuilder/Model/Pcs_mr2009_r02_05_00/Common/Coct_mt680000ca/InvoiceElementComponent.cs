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
    using Ca.Infoway.Messagebuilder.Model;


    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT680000CA.InvoiceElementComponent"})]
    public class InvoiceElementComponent : MessagePartBean {

        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt680000ca.IInvoiceElementChoice invoiceElementChoice;

        public InvoiceElementComponent() {
        }
        /**
         * <summary>Relationship: 
         * COCT_MT680000CA.InvoiceElementComponent.invoiceElementChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"invoiceElementChoice"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt680000ca.IInvoiceElementChoice InvoiceElementChoice {
            get { return this.invoiceElementChoice; }
            set { this.invoiceElementChoice = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt680000ca.InventElementChoice InvoiceElementChoiceAsInvoiceElementIntent1 {
            get { return this.invoiceElementChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt680000ca.InventElementChoice ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt680000ca.InventElementChoice) this.invoiceElementChoice : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt680000ca.InventElementChoice) null; }
        }
        public bool HasInvoiceElementChoiceAsInvoiceElementIntent1() {
            return (this.invoiceElementChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt680000ca.InventElementChoice);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt680000ca.InvoiceElementIntent2 InvoiceElementChoiceAsInvoiceElementIntent2 {
            get { return this.invoiceElementChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt680000ca.InvoiceElementIntent2 ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt680000ca.InvoiceElementIntent2) this.invoiceElementChoice : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt680000ca.InvoiceElementIntent2) null; }
        }
        public bool HasInvoiceElementChoiceAsInvoiceElementIntent2() {
            return (this.invoiceElementChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt680000ca.InvoiceElementIntent2);
        }

    }

}