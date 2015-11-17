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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: ResultSortKey</summary>
     * 
     * <remarks>POLB_MT004000CA.ResultSortKey: Result Sort Key 
     * <p>OLIS needs an alphanumeric sort key string to a test 
     * result to allow a laboratory to provide sorting information 
     * for test results.</p> <p>String used for sorting of 
     * results.</p> POLB_MT004200CA.ResultSortKey: Result Sort Key 
     * <p>This must not be linked at ObservationReport level.</p> 
     * <p>OLIS needs an alphanumeric sort key string to a test 
     * result to allow a laboratory to provide sorting information 
     * for test results.</p> <p>String used for sorting of 
     * results.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POLB_MT004000CA.ResultSortKey","POLB_MT004100CA.ResultSortKey","POLB_MT004200CA.ResultSortKey"})]
    public class ResultSortKey : MessagePartBean {

        private ST text;

        public ResultSortKey() {
            this.text = new STImpl();
        }
        /**
         * <summary>Business Name: SortKeyText</summary>
         * 
         * <remarks>Un-merged Business Name: SortKeyText Relationship: 
         * POLB_MT004000CA.ResultSortKey.text Conformance/Cardinality: 
         * MANDATORY (1) <p>Attribute for communicating the actual sort 
         * key value.</p> <p>Value used for sorting results.</p> 
         * Un-merged Business Name: SortKeyText Relationship: 
         * POLB_MT004200CA.ResultSortKey.text Conformance/Cardinality: 
         * MANDATORY (1) <p>Attribute for communicating the actual sort 
         * key value.</p> <p>Value used for sorting results.</p> 
         * Un-merged Business Name: SortKeyText Relationship: 
         * POLB_MT004100CA.ResultSortKey.text Conformance/Cardinality: 
         * MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public String Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

    }

}