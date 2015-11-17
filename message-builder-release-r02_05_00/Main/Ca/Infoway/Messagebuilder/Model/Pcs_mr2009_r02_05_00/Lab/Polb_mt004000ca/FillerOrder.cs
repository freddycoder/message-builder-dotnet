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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Polb_mt004000ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>Business Name: Filler Order</summary>
     * 
     * <p>The filler order communiates the intended testing (as 
     * opposed to the requested tests).</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POLB_MT004000CA.ActPromise"})]
    public class FillerOrder : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.IFulfillmentChoice {

        private II id;

        public FillerOrder() {
            this.id = new IIImpl();
        }
        /**
         * <summary>Business Name: Filler Order Identifier</summary>
         * 
         * <remarks>Relationship: POLB_MT004000CA.ActPromise.id 
         * Conformance/Cardinality: MANDATORY (1) <p>The promise id is 
         * mandatory as it is necessary to create the association (act 
         * relationship).</p> <p>The unique identfier for the filler 
         * order or promise.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

    }

}