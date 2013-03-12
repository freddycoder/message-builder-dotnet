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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt610201ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged;


    /**
     * <p>Want sum of all adjudication details (info &amp; 
     * non-info) to equal what was submitted. For example, the 
     * reasons why you refused to pay part of the invoice</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT610201CA.AdjudicatedInvoiceElementChoice"})]
    public interface IAdjudicatedInvoiceElementChoice {

        [Hl7XmlMappingAttribute(new string[] {"reference1/allowable"})]
        Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.Allowable Reference1Allowable {
            get;
            set;
        }

        [Hl7XmlMappingAttribute(new string[] {"outcomeOf"})]
        Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.AdjudicatedResultOutcome OutcomeOf {
            get;
            set;
        }

    }

}