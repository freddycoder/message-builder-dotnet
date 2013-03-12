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
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Domainvalue;
    using System;


    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT400001CA.SpecialAuthorizationCriteria","FICR_MT490103CA.SpecialAuthorizationCriteria"})]
    public class SpecialAuthorizationCriteria : MessagePartBean {

        private CV code;
        private ST text;
        private ST value;

        public SpecialAuthorizationCriteria() {
            this.code = new CVImpl();
            this.text = new STImpl();
            this.value = new STImpl();
        }
        /**
         * <summary>Business Name: GeneralSupportingInformationType</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * GeneralSupportingInformationType Relationship: 
         * FICR_MT490103CA.SpecialAuthorizationCriteria.code 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: GeneralSupportingInformationType Relationship: 
         * FICR_MT400001CA.SpecialAuthorizationCriteria.code 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActSupportingInformationCode Code {
            get { return (ActSupportingInformationCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: 
         * GeneralSupportingInformationText</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT490103CA.SpecialAuthorizationCriteria.text 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: SpecialAuthorizationCriteriaText Relationship: 
         * FICR_MT400001CA.SpecialAuthorizationCriteria.text 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public String Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Business Name: GeneralSupportingInformationValue</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * GeneralSupportingInformationValue Relationship: 
         * FICR_MT490103CA.SpecialAuthorizationCriteria.value 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: GeneralSupportingInformationValue Relationship: 
         * FICR_MT400001CA.SpecialAuthorizationCriteria.value 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public String Value {
            get { return this.value.Value; }
            set { this.value.Value = value; }
        }

    }

}