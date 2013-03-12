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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>COCT_MT680000CA.AdjudicationResultReference: (no 
     * business name)</summary>
     * 
     * <p>Each submitted invoice element must have 1 
     * AdjudicationResults instance unless its parent is 
     * adjudicated as submitted</p> <p>Multiple references to 
     * submitted invoice elements provides support for code 
     * substitution where the number of submitted fee items is 
     * consolidated on the adjudication results (e.g. 3 items to 
     * 1)</p> FICR_MT610201CA.AdjudicationResultReference: (no 
     * business name) <p>Each submitted invoice element must have 1 
     * AdjudicationResults instance unless its parent is 
     * adjudicated as submitted</p> <p>Association mandatory for 
     * Root AdjudicatedInvoiceElementGroup and all associations 
     * that point to submitted invoice elements.</p> <p>Multiple 
     * references to submitted invoice elements provides support 
     * for code substitution where the number of submitted fee 
     * items is consolidated on the adjudication results (e.g. 3 
     * items to 1)</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT680000CA.AdjudicationResultReference","FICR_MT610201CA.AdjudicationResultReference"})]
    public class AdjudicationResultReference : MessagePartBean {

        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.IInvoiceElementChoice invoiceElementChoice;

        public AdjudicationResultReference() {
        }
        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT680000CA.AdjudicationResultReference.invoiceElementChoice 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * FICR_MT610201CA.AdjudicationResultReference.invoiceElementChoice 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"invoiceElementChoice"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.IInvoiceElementChoice InvoiceElementChoice {
            get { return this.invoiceElementChoice; }
            set { this.invoiceElementChoice = value; }
        }

    }

}