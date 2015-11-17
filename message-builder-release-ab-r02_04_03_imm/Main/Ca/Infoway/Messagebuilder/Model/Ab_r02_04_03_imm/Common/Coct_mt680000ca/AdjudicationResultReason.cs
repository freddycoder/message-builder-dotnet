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
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT680000CA.AdjudicationResultReason"})]
    public class AdjudicationResultReason : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt680000ca.IAdjudicationCodeChoice {

        private ST value;

        public AdjudicationResultReason() {
            this.value = new STImpl();
        }
        /**
         * <summary>Business Name: ActAdjudication Reason</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT680000CA.AdjudicationResultReason.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Reason for the 
         * adjudication.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public String Value {
            get { return this.value.Value; }
            set { this.value.Value = value; }
        }

    }

}