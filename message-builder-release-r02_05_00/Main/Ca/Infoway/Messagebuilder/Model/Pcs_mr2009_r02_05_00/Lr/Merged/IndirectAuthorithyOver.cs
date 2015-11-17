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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lr.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;


    [Hl7PartTypeMappingAttribute(new string[] {"PRPA_MT202301CA.IndirectAuthorithyOver","PRPA_MT202302CA.IndirectAuthorithyOver","PRPA_MT202303CA.IndirectAuthorithyOver","PRPA_MT202317CA.IndirectAuthorithyOver"})]
    public class IndirectAuthorithyOver : MessagePartBean {

        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lr.Merged.TerritorialAuthority territorialAuthority;

        public IndirectAuthorithyOver() {
        }
        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PRPA_MT202302CA.IndirectAuthorithyOver.territorialAuthority 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PRPA_MT202301CA.IndirectAuthorithyOver.territorialAuthority 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PRPA_MT202303CA.IndirectAuthorithyOver.territorialAuthority 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PRPA_MT202317CA.IndirectAuthorithyOver.territorialAuthority 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"territorialAuthority"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lr.Merged.TerritorialAuthority TerritorialAuthority {
            get { return this.territorialAuthority; }
            set { this.territorialAuthority = value; }
        }

    }

}