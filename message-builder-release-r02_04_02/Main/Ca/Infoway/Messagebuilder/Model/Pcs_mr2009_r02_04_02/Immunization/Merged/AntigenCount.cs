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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Immunization.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: AntigenCount</summary>
     * 
     * <remarks>POIZ_MT030050CA.AntigenCount: Antigen Count 
     * <p>Allows for an immunization registry to communicate the 
     * current antigen count value.</p> <p>Represents the asserted 
     * antigen count.</p> POIZ_MT060150CA.AntigenCount: Antigen 
     * Count <p>Allows for an immunization registry to communicate 
     * the current antigen count value.</p> <p>Represents the 
     * asserted antigen count.</p> POIZ_MT030060CA.AntigenCount: 
     * Antigen Count <p>Allows for an immunization registry to 
     * communicate the current antigen count value.</p> 
     * <p>Represents the asserted antigen count.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POIZ_MT030050CA.AntigenCount","POIZ_MT030060CA.AntigenCount","POIZ_MT060150CA.AntigenCount"})]
    public class AntigenCount : MessagePartBean {

        private INT value;

        public AntigenCount() {
            this.value = new INTImpl();
        }
        /**
         * <summary>Business Name: AntigenCountValue</summary>
         * 
         * <remarks>Un-merged Business Name: AntigenCountValue 
         * Relationship: POIZ_MT030050CA.AntigenCount.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for an 
         * immunization registry to communicate the current antigen 
         * count value.</p> <p>Represents the asserted antigen 
         * count.</p> Un-merged Business Name: AntigenCountValue 
         * Relationship: POIZ_MT060150CA.AntigenCount.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for an 
         * immunization registry to communicate the current antigen 
         * count value.</p> <p>Represents the asserted antigen 
         * count.</p> Un-merged Business Name: AntigenCountValue 
         * Relationship: POIZ_MT030060CA.AntigenCount.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for an 
         * immunization registry to communicate the current antigen 
         * count value.</p> <p>Represents the asserted antigen 
         * count.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public int? Value {
            get { return this.value.Value; }
            set { this.value.Value = value; }
        }

    }

}