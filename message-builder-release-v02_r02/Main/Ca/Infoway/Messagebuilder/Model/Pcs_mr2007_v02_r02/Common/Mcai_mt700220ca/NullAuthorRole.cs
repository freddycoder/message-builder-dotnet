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
 * Author:        $LastChangedBy: jmis $
 * Last modified: $LastChangedDate: 2015-09-15 10:13:40 -0400 (Tue, 15 Sep 2015) $
 * Revision:      $LastChangedRevision: 9768 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Mcai_mt700220ca {
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
    [Hl7PartTypeMappingAttribute(new string[] {"MCAI_MT700220CA.AuthorRole"})]
    public class NullAuthorRole : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Merged.IAuthorPerson_1 {

        private CS classCode;

        public NullAuthorRole() {
            this.classCode = new CSImpl();
        }
        /**
         * <summary>Relationship: MCAI_MT700220CA.AuthorRole.classCode</summary>
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