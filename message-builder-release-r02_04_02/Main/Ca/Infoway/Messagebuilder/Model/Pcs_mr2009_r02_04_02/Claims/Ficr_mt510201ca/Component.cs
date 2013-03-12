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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt510201ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;


    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT510201CA.Component"})]
    public class Component : MessagePartBean {

        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt510201ca.IAdjudicatedInvoiceElementChoice adjudicatedInvoiceElementChoice;

        public Component() {
        }
        /**
         * <summary>Relationship: 
         * FICR_MT510201CA.Component.adjudicatedInvoiceElementChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"adjudicatedInvoiceElementChoice"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt510201ca.IAdjudicatedInvoiceElementChoice AdjudicatedInvoiceElementChoice {
            get { return this.adjudicatedInvoiceElementChoice; }
            set { this.adjudicatedInvoiceElementChoice = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt510201ca.AdjudicatedInvoiceElementGroup AdjudicatedInvoiceElementChoiceAsAdjudicatedInvoiceElementGroup {
            get { return this.adjudicatedInvoiceElementChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt510201ca.AdjudicatedInvoiceElementGroup ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt510201ca.AdjudicatedInvoiceElementGroup) this.adjudicatedInvoiceElementChoice : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt510201ca.AdjudicatedInvoiceElementGroup) null; }
        }
        public bool HasAdjudicatedInvoiceElementChoiceAsAdjudicatedInvoiceElementGroup() {
            return (this.adjudicatedInvoiceElementChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt510201ca.AdjudicatedInvoiceElementGroup);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt510201ca.AdjudicatedInvoiceElementDetail AdjudicatedInvoiceElementChoiceAsAdjudicatedInvoiceElementDetail {
            get { return this.adjudicatedInvoiceElementChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt510201ca.AdjudicatedInvoiceElementDetail ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt510201ca.AdjudicatedInvoiceElementDetail) this.adjudicatedInvoiceElementChoice : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt510201ca.AdjudicatedInvoiceElementDetail) null; }
        }
        public bool HasAdjudicatedInvoiceElementChoiceAsAdjudicatedInvoiceElementDetail() {
            return (this.adjudicatedInvoiceElementChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt510201ca.AdjudicatedInvoiceElementDetail);
        }

    }

}