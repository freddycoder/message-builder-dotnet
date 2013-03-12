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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pr.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>Business Name: PrivilegeCategorization</summary>
     * 
     * <remarks>PRPM_MT306011CA.PrivilegeCategorization: Privilege 
     * Categorization <p>Supports the business requirement to 
     * provide information about a healthcare provider where 
     * privileges have been restricted.</p> <p>An act that is 
     * intended to result in new information about a subject. In 
     * this instance, regarding restrictions to practice for a 
     * specified healthcare provider.</p> 
     * PRPM_MT309000CA.PrivilegeCategorization: Privilege 
     * Categorization <p>Supports the business requirement to 
     * provide information about a healthcare provider where 
     * privileges have been restricted.</p> <p>An act that is 
     * intended to result in new information about a subject. In 
     * this instance, regarding restrictions to practice for a 
     * specified healthcare provider.</p> 
     * PRPM_MT303010CA.PrivilegeCategorization: Privilege 
     * Categorization <p>Supports the business requirement to 
     * provide information about a healthcare provider where 
     * privileges have been restricted.</p> <p>An act that is 
     * intended to result in new information about a subject. In 
     * this instance, regarding restrictions to practice for a 
     * specified healthcare provider.</p> 
     * PRPM_MT301010CA.PrivilegeCategorization: Privilege 
     * Categorization <p>Supports the business requirement to 
     * provide information about a healthcare provider where 
     * privileges have been restricted.</p> <p>An act that is 
     * intended to result in new information about a subject. In 
     * this instance, regarding restrictions to practice for a 
     * specified healthcare provider.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPM_MT301010CA.PrivilegeCategorization","PRPM_MT303010CA.PrivilegeCategorization","PRPM_MT306011CA.PrivilegeCategorization","PRPM_MT309000CA.PrivilegeCategorization"})]
    public class PrivilegeCategorization : MessagePartBean {

        private CV code;
        private CV value;

        public PrivilegeCategorization() {
            this.code = new CVImpl();
            this.value = new CVImpl();
        }
        /**
         * <summary>Business Name: RestrictionsCategorizationType</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * RestrictionsCategorizationType Relationship: 
         * PRPM_MT306011CA.PrivilegeCategorization.code 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute supports the validation and identification of the 
         * healthcare provider and his/her given privileges</p> <p>The 
         * code identifying the specific privilege and/or restrictions 
         * on those privileges</p> Un-merged Business Name: 
         * RestrictionsCategorizationType Relationship: 
         * PRPM_MT309000CA.PrivilegeCategorization.code 
         * Conformance/Cardinality: POPULATED (1) <p>Populated 
         * attribute supports the validation and identification of the 
         * healthcare provider and his/her given privileges</p> <p>The 
         * code identifying the specific privilege and/or restrictions 
         * on those privileges</p> Un-merged Business Name: 
         * RestrictionsCategorizationType Relationship: 
         * PRPM_MT301010CA.PrivilegeCategorization.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports the validation and identification of the 
         * healthcare provider and his/her given privileges</p> <p>The 
         * code identifying the specific privilege and/or restrictions 
         * on those privileges</p> Un-merged Business Name: 
         * RestrictionsCategorizationType Relationship: 
         * PRPM_MT303010CA.PrivilegeCategorization.code 
         * Conformance/Cardinality: POPULATED (1) <p>Mandatory 
         * attribute supports the validation and identification of the 
         * healthcare provider and his/her given privileges</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActPrivilegeCategorization Code {
            get { return (ActPrivilegeCategorization) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: RestrictionsCategorizationValue</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * RestrictionsCategorizationValue Relationship: 
         * PRPM_MT306011CA.PrivilegeCategorization.value 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute supports the validation and identification of the 
         * healthcare provider and his/her given privileges</p> <p>The 
         * value identifying the specific privilege and/or restrictions 
         * on those privileges</p> Un-merged Business Name: 
         * RestrictionsCategorizationValue Relationship: 
         * PRPM_MT309000CA.PrivilegeCategorization.value 
         * Conformance/Cardinality: POPULATED (1) <p>Populated 
         * attribute supports the validation and identification of the 
         * healthcare provider and his/her given privileges</p> <p>The 
         * value identifying the specific privilege and/or restrictions 
         * on those privileges</p> Un-merged Business Name: 
         * RestrictionsCategorizationValue Relationship: 
         * PRPM_MT301010CA.PrivilegeCategorization.value 
         * Conformance/Cardinality: POPULATED (1) <p>Populated 
         * attribute supports the validation and identification of the 
         * healthcare provider and his/her given privileges</p> <p>The 
         * value identifying the specific privilege and/or restrictions 
         * on those privileges</p> Un-merged Business Name: 
         * RestrictionsCategorizationValue Relationship: 
         * PRPM_MT303010CA.PrivilegeCategorization.value 
         * Conformance/Cardinality: POPULATED (1) <p>Populated 
         * attribute supports the validation and identification of the 
         * healthcare provider and his/her given privileges</p> <p>The 
         * value identifying the specific privilege and/or restrictions 
         * on those privileges</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public ObservationValue Value {
            get { return (ObservationValue) this.value.Value; }
            set { this.value.Value = value; }
        }

    }

}