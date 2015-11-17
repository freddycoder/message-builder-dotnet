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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt301010ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Healthcare Provider</summary>
     * 
     * <p>Roleclass required to support the identification of 
     * person responsible for providing healthcare services.</p> 
     * <p>This roles the specific Healthcare provider role such as 
     * a Physician, Nurse or other type of caregivers.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPM_MT301010CA.HealthCareProvider"})]
    public class HealthcareProvider : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt301010ca.IRoleChoice, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt301010ca.IChoice {

        private SET<II, Identifier> id;
        private CV code;
        private LIST<PN, PersonName> name;
        private LIST<AD, PostalAddress> addr;
        private LIST<TEL, TelecommunicationAddress> telecom;
        private CS statusCode;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Merged.PrinicpalPerson_1 healthCarePrincipalPerson;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt301010ca.Organization issuingOrganization;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Merged.Privilege> responsibleForPrivilege;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt301010ca.RelatedTo> relatedTo;

        public HealthcareProvider() {
            this.id = new SETImpl<II, Identifier>(typeof(IIImpl));
            this.code = new CVImpl();
            this.name = new LISTImpl<PN, PersonName>(typeof(PNImpl));
            this.addr = new LISTImpl<AD, PostalAddress>(typeof(ADImpl));
            this.telecom = new LISTImpl<TEL, TelecommunicationAddress>(typeof(TELImpl));
            this.statusCode = new CSImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.responsibleForPrivilege = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Merged.Privilege>();
            this.relatedTo = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt301010ca.RelatedTo>();
        }
        /**
         * <summary>Business Name: Healthcare Provider Role 
         * Identification</summary>
         * 
         * <remarks>Relationship: PRPM_MT301010CA.HealthCareProvider.id 
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
         * PRPM_MT301010CA.HealthCareProvider.code 
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
         * PRPM_MT301010CA.HealthCareProvider.name 
         * Conformance/Cardinality: MANDATORY (1-5) <p>Mandatory 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>The provider's name pertaining to the 
         * specific healthcare provider role.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"name"})]
        public IList<PersonName> Name {
            get { return this.name.RawList(); }
        }

        /**
         * <summary>Business Name: Healthcare Provider Role Address</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT301010CA.HealthCareProvider.addr 
         * Conformance/Cardinality: REQUIRED (0-20) <p>Required 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>The address for the provider when playing 
         * the role of healthcare provider.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"addr"})]
        public IList<PostalAddress> Addr {
            get { return this.addr.RawList(); }
        }

        /**
         * <summary>Business Name: Healthcare Provider Role Telecom</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT301010CA.HealthCareProvider.telecom 
         * Conformance/Cardinality: REQUIRED (0-100) <p>Required 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>The telecom for the provider when playing 
         * the role of healthcare provider.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"telecom"})]
        public IList<TelecommunicationAddress> Telecom {
            get { return this.telecom.RawList(); }
        }

        /**
         * <summary>Business Name: Healthcare Provider Role Status Code</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT301010CA.HealthCareProvider.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>The status of the provider in the healthcare 
         * provider role i.e. Active</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public RoleStatus StatusCode {
            get { return (RoleStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: Healthcare Provider Role Effective 
         * Date</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT301010CA.HealthCareProvider.effectiveTime 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>The effective date of the provider in the 
         * healthcare provider role</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PRPM_MT301010CA.HealthCareProvider.healthCarePrincipalPerson</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"healthCarePrincipalPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Merged.PrinicpalPerson_1 HealthCarePrincipalPerson {
            get { return this.healthCarePrincipalPerson; }
            set { this.healthCarePrincipalPerson = value; }
        }

        /**
         * <summary>Relationship: 
         * PRPM_MT301010CA.HealthCareProvider.issuingOrganization</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"issuingOrganization"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt301010ca.Organization IssuingOrganization {
            get { return this.issuingOrganization; }
            set { this.issuingOrganization = value; }
        }

        /**
         * <summary>Relationship: 
         * PRPM_MT301010CA.ResponsibleParty.privilege</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleFor/privilege"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Merged.Privilege> ResponsibleForPrivilege {
            get { return this.responsibleForPrivilege; }
        }

        /**
         * <summary>Relationship: PRPM_MT301010CA.RoleChoice.relatedTo</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-100)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"relatedTo"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt301010ca.RelatedTo> RelatedTo {
            get { return this.relatedTo; }
        }

    }

}