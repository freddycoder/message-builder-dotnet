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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Comt_mt900002ab {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>Business Name: Logoff</summary>
     * 
     * <p>Represents the ending of a request for access to a 
     * system.</p> <p>For security reasons, access permissions 
     * should be revoked when they are no longer required</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COMT_MT900002AB.ActPermission"})]
    public class Logoff : MessagePartBean {

        private II id;

        public Logoff() {
            this.id = new IIImpl();
        }
        /**
         * <summary>Business Name: Authentication Token</summary>
         * 
         * <remarks>Relationship: COMT_MT900002AB.ActPermission.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates the 
         * authentication token to be revoked/ended</p> <p>Needed to 
         * identify which session is to be logged off.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

    }

}