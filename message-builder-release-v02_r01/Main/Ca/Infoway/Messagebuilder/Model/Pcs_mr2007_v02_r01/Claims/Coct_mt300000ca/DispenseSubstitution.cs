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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Coct_mt300000ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;


    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT300000CA.Substitution"})]
    public class DispenseSubstitution : MessagePartBean {

        private CV code;
        private CV reasonCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Coct_mt300000ca.SubstitutionRole performerSubstitutionRole;

        public DispenseSubstitution() {
            this.code = new CVImpl();
            this.reasonCode = new CVImpl();
        }
        /**
         * <summary>Business Name: Substitution Type</summary>
         * 
         * <remarks>Relationship: COCT_MT300000CA.Substitution.code 
         * Conformance/Cardinality: MANDATORY (1) <p>type of 
         * substitution</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActSubstanceAdminSubstitutionCode Code {
            get { return (ActSubstanceAdminSubstitutionCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Substitution Reason</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT300000CA.Substitution.reasonCode 
         * Conformance/Cardinality: POPULATED (1) <p>Reason for 
         * substituting or not substituting, e.g. because prescriber 
         * requested</p> <p>Reason why the substitution occurred.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reasonCode"})]
        public SubstanceAdminSubstitutionReason ReasonCode {
            get { return (SubstanceAdminSubstitutionReason) this.reasonCode.Value; }
            set { this.reasonCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT300000CA.Performer.substitutionRole</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"performer/substitutionRole"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Coct_mt300000ca.SubstitutionRole PerformerSubstitutionRole {
            get { return this.performerSubstitutionRole; }
            set { this.performerSubstitutionRole = value; }
        }

    }

}