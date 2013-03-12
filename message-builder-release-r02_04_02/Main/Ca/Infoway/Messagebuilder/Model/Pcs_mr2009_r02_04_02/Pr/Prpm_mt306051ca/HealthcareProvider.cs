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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pr.Prpm_mt306051ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pr.Merged;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Healthcare Provider</summary>
     * 
     * <p>Roleclass required to support the identification of 
     * person responsible for providing healthcare services</p> 
     * <p>This roles the specific Healthcare provider role such as 
     * a Physician, Nurse or other type of caregivers.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPM_MT306051CA.HealthCareProvider"})]
    public class HealthcareProvider : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.IRoleChoice {

        private SET<II, Identifier> id;
        private CV code;
        private LIST<PN, PersonName> name;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pr.Merged.PrinicpalPerson_2 healthCarePrincipalPerson;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pr.Prpm_mt306051ca.Organization issuingOrganization;

        public HealthcareProvider() {
            this.id = new SETImpl<II, Identifier>(typeof(IIImpl));
            this.code = new CVImpl();
            this.name = new LISTImpl<PN, PersonName>(typeof(PNImpl));
        }
        /**
         * <summary>Business Name: Healthcare Provider Role 
         * Identification</summary>
         * 
         * <remarks>Relationship: PRPM_MT306051CA.HealthCareProvider.id 
         * Conformance/Cardinality: MANDATORY (1-50) <p>Mandatory 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>A unique identifier for a provider in a 
         * specific healthcare role.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public ICollection<Identifier> Id {
            get { return this.id.RawSet(); }
        }

        /**
         * <summary>Business Name: Healthcare Provider Role Type</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT306051CA.HealthCareProvider.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>The code identifying the specific healthcare 
         * provider role.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public HealthcareProviderRoleType Code {
            get { return (HealthcareProviderRoleType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Healthcare Provider Role Name</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT306051CA.HealthCareProvider.name 
         * Conformance/Cardinality: REQUIRED (0-5) <p>Required 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>The providers name pertaining to the 
         * specific healthcare provider role.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"name"})]
        public IList<PersonName> Name {
            get { return this.name.RawList(); }
        }

        /**
         * <summary>Relationship: 
         * PRPM_MT306051CA.HealthCareProvider.healthCarePrincipalPerson</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"healthCarePrincipalPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pr.Merged.PrinicpalPerson_2 HealthCarePrincipalPerson {
            get { return this.healthCarePrincipalPerson; }
            set { this.healthCarePrincipalPerson = value; }
        }

        /**
         * <summary>Relationship: 
         * PRPM_MT306051CA.HealthCareProvider.issuingOrganization</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"issuingOrganization"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pr.Prpm_mt306051ca.Organization IssuingOrganization {
            get { return this.issuingOrganization; }
            set { this.issuingOrganization = value; }
        }

    }

}