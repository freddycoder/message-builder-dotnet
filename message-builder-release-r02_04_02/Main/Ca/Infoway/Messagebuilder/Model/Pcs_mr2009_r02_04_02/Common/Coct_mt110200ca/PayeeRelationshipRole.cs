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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt110200ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Domainvalue;


    /**
     * <summary>Business Name: Payee Relationship Role</summary>
     * 
     * <p>Covered Party/Patient is the scoper of this role, but is 
     * not necessary in this CMET</p> <p>Indicates whether payee is 
     * Person or Organisation</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT110200CA.Role"})]
    public class PayeeRelationshipRole : MessagePartBean {

        private CS classCode;

        public PayeeRelationshipRole() {
            this.classCode = new CSImpl();
        }
        /**
         * <summary>Business Name: Account Payee Policy Relationship 
         * Role</summary>
         * 
         * <remarks>Relationship: COCT_MT110200CA.Role.classCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Invoice 
         * Adjudication Results</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"classCode"})]
        public x_RoleClassPayeePolicyRelationship ClassCode {
            get { return (x_RoleClassPayeePolicyRelationship) this.classCode.Value; }
            set { this.classCode.Value = value; }
        }

    }

}