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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Comt_mt001101ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Referenced Record</summary>
     * 
     * <p>As a request, refers to the event to be acted upon or 
     * which has been acted upon.</p><p>As a response, may be used 
     * to indicate the identifier assigned to a created object.</p> 
     * <p>References an existing event record by identifier.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COMT_MT001101CA.ActRequest"})]
    public class ReferencedRecord : MessagePartBean {

        private SET<II, Identifier> id;

        public ReferencedRecord() {
            this.id = new SETImpl<II, Identifier>(typeof(IIImpl));
        }
        /**
         * <summary>Business Name: Record Ids</summary>
         * 
         * <remarks>Relationship: COMT_MT001101CA.ActRequest.id 
         * Conformance/Cardinality: MANDATORY (1-2) <p>Allows the event 
         * record to be uniquely referenced and is therefore 
         * mandatory.</p> <p>The identifier assigned by the central 
         * system (EHR) to the Event record being referred to.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public ICollection<Identifier> Id {
            get { return this.id.RawSet(); }
        }

    }

}