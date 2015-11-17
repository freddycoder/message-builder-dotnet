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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt300000ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;


    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT300000CA.Substitution"})]
    public class DispenseSubstitution : MessagePartBean {

        private CV code;
        private CV reasonCode;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt300000ca.SubstitutionRole performerSubstitutionRole;

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
         * Conformance/Cardinality: REQUIRED (1) <p>Reason for 
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
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"performer/substitutionRole"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt300000ca.SubstitutionRole PerformerSubstitutionRole {
            get { return this.performerSubstitutionRole; }
            set { this.performerSubstitutionRole = value; }
        }

    }

}