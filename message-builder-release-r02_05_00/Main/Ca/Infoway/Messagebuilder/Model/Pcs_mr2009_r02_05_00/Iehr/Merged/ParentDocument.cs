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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT220002CA.ParentDocument","REPC_MT220003CA.ParentDocument","REPC_MT230002CA.ParentDocument","REPC_MT230003CA.ParentDocument"})]
    public class ParentDocument : MessagePartBean {

        private SET<II, Identifier> id;

        public ParentDocument() {
            this.id = new SETImpl<II, Identifier>(typeof(IIImpl));
        }
        /**
         * <summary>Business Name: ParentRecordId</summary>
         * 
         * <remarks>Un-merged Business Name: ParentRecordId 
         * Relationship: REPC_MT230002CA.ParentDocument.id 
         * Conformance/Cardinality: MANDATORY (2) <p>Used in 
         * circumstances where a parent report being appended remains 
         * in place and its content and status are unaltered.</p> 
         * <p>Used to identify a parent report being appended.</p> 
         * Un-merged Business Name: ParentRecordId Relationship: 
         * REPC_MT220002CA.ParentDocument.id Conformance/Cardinality: 
         * MANDATORY (2) <p>Used in circumstances where a parent report 
         * being appended remains in place and its content and status 
         * are unaltered.</p> <p>Used to identify a parent report being 
         * appended.</p> Un-merged Business Name: ParentRecordId 
         * Relationship: REPC_MT220003CA.ParentDocument.id 
         * Conformance/Cardinality: MANDATORY (2) <p>Used in 
         * circumstances where a parent report being appended remains 
         * in place and its content and status are unaltered.</p> 
         * <p>Used to identify a parent report being appended.</p> 
         * Un-merged Business Name: ParentRecordId Relationship: 
         * REPC_MT230003CA.ParentDocument.id Conformance/Cardinality: 
         * MANDATORY (2) <p>Used in circumstances where a parent report 
         * being appended remains in place and its content and status 
         * are unaltered.</p> <p>Used to identify a parent report being 
         * appended.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public ICollection<Identifier> Id {
            get { return this.id.RawSet(); }
        }

    }

}