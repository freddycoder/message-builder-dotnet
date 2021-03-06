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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT400003CA.Subject","FICR_MT400004CA.Subject","FICR_MT490102CA.Subject4"})]
    public class Subject4 : MessagePartBean {

        private BL negationInd;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Merged.ISpecialAuthorizationChoice_2 specialAuthorizationChoice;

        public Subject4() {
            this.negationInd = new BLImpl();
        }
        /**
         * <summary>Business Name: IncludesExcludesProduct</summary>
         * 
         * <remarks>Un-merged Business Name: IncludesExcludesProduct 
         * Relationship: FICR_MT400003CA.Subject.negationInd 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: IncludesExcludesProduct Relationship: 
         * FICR_MT400004CA.Subject.negationInd Conformance/Cardinality: 
         * MANDATORY (1) Un-merged Business Name: 
         * IncludesExcludesProduct Relationship: 
         * FICR_MT490102CA.Subject4.negationInd 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"negationInd"})]
        public bool? NegationInd {
            get { return this.negationInd.Value; }
            set { this.negationInd.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT400003CA.Subject.specialAuthorizationChoice 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * FICR_MT400004CA.Subject.specialAuthorizationChoice 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * FICR_MT490102CA.Subject4.specialAuthorizationChoice 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"specialAuthorizationChoice"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Merged.ISpecialAuthorizationChoice_2 SpecialAuthorizationChoice {
            get { return this.specialAuthorizationChoice; }
            set { this.specialAuthorizationChoice = value; }
        }

    }

}