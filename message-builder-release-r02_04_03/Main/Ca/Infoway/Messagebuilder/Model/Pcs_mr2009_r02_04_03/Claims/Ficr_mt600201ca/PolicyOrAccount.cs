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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Ficr_mt600201ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged;


    /**
     * <p>id: = Coverage Identifier, extension = 
     * Policy.Plan.Group.Contract. Division.Section.Version (or 
     * similar). Carrier noted in author participation, and may not 
     * be same namespace as OID of id</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT600201CA.PolicyOrAccount"})]
    public class PolicyOrAccount : MessagePartBean {

        private II id;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Ficr_mt600201ca.CoveredPartyAsPatient beneficiaryCoveredPartyAsPatient;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.PolicyUnderwriter author;

        public PolicyOrAccount() {
            this.id = new IIImpl();
        }
        /**
         * <summary>Business Name: Policy ID</summary>
         * 
         * <remarks>Relationship: FICR_MT600201CA.PolicyOrAccount.id 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT600201CA.PolicyBeneficiary.coveredPartyAsPatient</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"beneficiary/coveredPartyAsPatient"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Ficr_mt600201ca.CoveredPartyAsPatient BeneficiaryCoveredPartyAsPatient {
            get { return this.beneficiaryCoveredPartyAsPatient; }
            set { this.beneficiaryCoveredPartyAsPatient = value; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT600201CA.PolicyOrAccount.author</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.PolicyUnderwriter Author {
            get { return this.author; }
            set { this.author = value; }
        }

    }

}