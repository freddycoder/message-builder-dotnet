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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Common.Mcai_mt700230ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>Business Name: Null Author Role</summary>
     * 
     * <p>This is a messaging artifact used by HL7 to allow the 
     * time, signiture and method to be captured when the author is 
     * not sent. This will happen in circumstances where the author 
     * information is sent as part of the authentication token.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"MCAI_MT700230CA.AuthorRole"})]
    public class NullAuthorRole : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Common.Merged.IAuthorPerson {

        private CS classCode;

        public NullAuthorRole() {
            this.classCode = new CSImpl();
        }
        /**
         * <summary>Relationship: MCAI_MT700230CA.AuthorRole.classCode</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"classCode"})]
        public RoleClass ClassCode {
            get { return (RoleClass) this.classCode.Value; }
            set { this.classCode.Value = value; }
        }

    }

}