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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;


    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT400001CA.PolicyHolder","FICR_MT400003CA.PolicyHolder","FICR_MT400004CA.PolicyHolder","FICR_MT490102CA.PolicyHolder"})]
    public class PolicyHolder : MessagePartBean {

        private II id;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Merged.IPolicyHolderChoice policyHolderChoice;

        public PolicyHolder() {
            this.id = new IIImpl();
        }
        /**
         * <summary>Business Name: PolicyHolderIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: PolicyHolderIdentifier 
         * Relationship: FICR_MT490102CA.PolicyHolder.id 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: PolicyHolderIdentifier Relationship: 
         * FICR_MT400003CA.PolicyHolder.id Conformance/Cardinality: 
         * MANDATORY (1) Un-merged Business Name: 
         * PolicyHolderIdentifier Relationship: 
         * FICR_MT400004CA.PolicyHolder.id Conformance/Cardinality: 
         * MANDATORY (1) Un-merged Business Name: 
         * PolicyHolderIdentifier Relationship: 
         * FICR_MT400001CA.PolicyHolder.id Conformance/Cardinality: 
         * MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT490102CA.PolicyHolder.policyHolderChoice 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * FICR_MT400003CA.PolicyHolder.policyHolderChoice 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * FICR_MT400004CA.PolicyHolder.policyHolderChoice 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * FICR_MT400001CA.PolicyHolder.policyHolderChoice 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"policyHolderChoice"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Merged.IPolicyHolderChoice PolicyHolderChoice {
            get { return this.policyHolderChoice; }
            set { this.policyHolderChoice = value; }
        }

    }

}