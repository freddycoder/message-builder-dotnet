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
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: AccessType</summary>
     * 
     * <remarks>COCT_MT470000CA.InformDefinition: Access Type 
     * <p>Defines the types of information permission is being 
     * granted to access.</p> <p>Allows discrete control over 
     * different types of information.</p> 
     * COCT_MT470012CA.InformDefinition: Access Type <p>Defines the 
     * types of information permission is being granted to 
     * access.</p> <p>Allows discrete control over different types 
     * of information.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT470000CA.InformDefinition","COCT_MT470012CA.InformDefinition"})]
    public class AccessType : MessagePartBean {

        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.ConsentGivenTo receiver;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.Subject3> subject;

        public AccessType() {
            this.subject = new List<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.Subject3>();
        }
        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT470000CA.InformDefinition.receiver 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * COCT_MT470012CA.InformDefinition.receiver 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"receiver"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.ConsentGivenTo Receiver {
            get { return this.receiver; }
            set { this.receiver = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT470000CA.InformDefinition.subject 
         * Conformance/Cardinality: MANDATORY (1-10) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * COCT_MT470012CA.InformDefinition.subject 
         * Conformance/Cardinality: MANDATORY (1-10)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.Subject3> Subject {
            get { return this.subject; }
        }

    }

}