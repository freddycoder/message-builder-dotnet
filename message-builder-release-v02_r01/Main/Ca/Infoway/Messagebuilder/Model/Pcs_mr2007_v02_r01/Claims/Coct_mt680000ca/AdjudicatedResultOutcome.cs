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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Coct_mt680000ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;


    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT680000CA.AdjudicatedResultOutcome"})]
    public class AdjudicatedResultOutcome : MessagePartBean {

        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Coct_mt680000ca.AdjudicationResult adjudicationResult;

        public AdjudicatedResultOutcome() {
        }
        /**
         * <summary>Relationship: 
         * COCT_MT680000CA.AdjudicatedResultOutcome.adjudicationResult</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"adjudicationResult"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Coct_mt680000ca.AdjudicationResult AdjudicationResult {
            get { return this.adjudicationResult; }
            set { this.adjudicationResult = value; }
        }

    }

}