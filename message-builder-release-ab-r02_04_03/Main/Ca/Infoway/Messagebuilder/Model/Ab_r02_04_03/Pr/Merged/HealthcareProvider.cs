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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Prpm_mt301010ca;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: HealthcareProvider</summary>
     * 
     * <remarks>PRPM_MT301010CA.HealthCareProvider: Healthcare 
     * Provider <p>Roleclass required to support the identification 
     * of person responsible for providing healthcare services.</p> 
     * <p>This roles the specific Healthcare provider role such as 
     * a Physician, Nurse or other type of caregivers.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPM_MT301010CA.HealthCareProvider","PRPM_MT303011AB.HealthCareProvider","PRPM_MT303012AB.HealthCareProvider","PRPM_MT303013AB.HealthCareProvider"})]
    public class HealthcareProvider : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Prpm_mt301010ca.IRoleChoice, Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Prpm_mt301010ca.IChoice {

        private SET<II, Identifier> id;
        private CV code;
        private LIST<PN, PersonName> name;
        private LIST<AD, PostalAddress> addr;
        private LIST<TEL, TelecommunicationAddress> telecom;
        private CS statusCode;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Merged.PrinicpalPerson_1 healthCarePrincipalPerson;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Prpm_mt301010ca.Organization issuingOrganization;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Merged.RegistrationEvent subjectOf1RegistrationEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Merged.StatusChangeDetails> subjectOf2StateTransitionControlActEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Merged.Privilege> responsibleForPrivilege;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Prpm_mt301010ca.RelatedTo> relatedTo;

        public HealthcareProvider() {
            this.id = new SETImpl<II, Identifier>(typeof(IIImpl));
            this.code = new CVImpl();
            this.name = new LISTImpl<PN, PersonName>(typeof(PNImpl));
            this.addr = new LISTImpl<AD, PostalAddress>(typeof(ADImpl));
            this.telecom = new LISTImpl<TEL, TelecommunicationAddress>(typeof(TELImpl));
            this.statusCode = new CSImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.subjectOf2StateTransitionControlActEvent = new List<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Merged.StatusChangeDetails>();
            this.responsibleForPrivilege = new List<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Merged.Privilege>();
            this.relatedTo = new List<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Prpm_mt301010ca.RelatedTo>();
        }
        /**
         * <summary>Un-merged Business Name: 
         * HealthcareProviderRoleIdentification</summary>
         * 
         * <remarks>Relationship: PRPM_MT301010CA.HealthCareProvider.id 
         * Conformance/Cardinality: MANDATORY (1-50) <p>Mandatory 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>A unique identifier for a provider in a 
         * specific healthcare role.</p> Un-merged Business Name: 
         * HealthCareProviderRoleIdentification Relationship: 
         * PRPM_MT303011AB.HealthCareProvider.id 
         * Conformance/Cardinality: MANDATORY (1-10) <p>Allows lookup 
         * on college website, confirmation of identity, etc. 
         * Regulations occasionally require license numbers to be 
         * specified as part of clinical records.</p> <p>If the 
         * identifier used in the root of the CMET is the same as the 
         * license number, the license number should be sent in both 
         * places.</p> <p>The license number issued to the provider and 
         * relevant to the current action.</p> Un-merged Business Name: 
         * HealthCareProviderRoleIdentification Relationship: 
         * PRPM_MT303012AB.HealthCareProvider.id 
         * Conformance/Cardinality: MANDATORY (1-10) Un-merged Business 
         * Name: HealthCareProviderRoleIdentification Relationship: 
         * PRPM_MT303013AB.HealthCareProvider.id 
         * Conformance/Cardinality: MANDATORY (1-10) <p>Allows lookup 
         * on college website, confirmation of identity, etc. 
         * Regulations occasionally require license numbers to be 
         * specified as part of clinical records.</p> <p>If the 
         * identifier used in the root of the CMET is the same as the 
         * license number, the license number should be sent in both 
         * places.</p> <p>The license number issued to the provider and 
         * relevant to the current action.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public ICollection<Identifier> Id {
            get { return this.id.RawSet(); }
        }

        /**
         * <summary>Un-merged Business Name: HealthcareProviderRoleType</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT301010CA.HealthCareProvider.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>The code identifying the specific healthcare 
         * provider role.</p> Un-merged Business Name: 
         * HealthCareProviderRoleType Relationship: 
         * PRPM_MT303011AB.HealthCareProvider.code 
         * Conformance/Cardinality: MANDATORY (1) <p>In some 
         * circumstances, license number isn't unique.</p> 
         * <p>Identifies the type of role being linked</p> Un-merged 
         * Business Name: HealthCareProviderRoleType Relationship: 
         * PRPM_MT303012AB.HealthCareProvider.code 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: HealthCareProviderRoleType Relationship: 
         * PRPM_MT303013AB.HealthCareProvider.code 
         * Conformance/Cardinality: MANDATORY (1) <p>In some 
         * circumstances, license number isn't unique.</p> 
         * <p>Identifies the type of role being nullified</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public HealthcareProviderRoleType Code {
            get { return (HealthcareProviderRoleType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: HealthcareProviderRoleName</summary>
         * 
         * <remarks>Un-merged Business Name: HealthcareProviderRoleName 
         * Relationship: PRPM_MT301010CA.HealthCareProvider.name 
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
         * <summary>Business Name: HealthcareProviderRoleAddress</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * HealthcareProviderRoleAddress Relationship: 
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
         * <summary>Business Name: HealthcareProviderRoleTelecom</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * HealthcareProviderRoleTelecom Relationship: 
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
         * <summary>Business Name: HealthcareProviderRoleStatusCode</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * HealthcareProviderRoleStatusCode Relationship: 
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
         * <summary>Business Name: HealthcareProviderRoleEffectiveDate</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * HealthcareProviderRoleEffectiveDate Relationship: 
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
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT301010CA.HealthCareProvider.healthCarePrincipalPerson 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"healthCarePrincipalPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Merged.PrinicpalPerson_1 HealthCarePrincipalPerson {
            get { return this.healthCarePrincipalPerson; }
            set { this.healthCarePrincipalPerson = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT301010CA.HealthCareProvider.issuingOrganization 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"issuingOrganization"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Prpm_mt301010ca.Organization IssuingOrganization {
            get { return this.issuingOrganization; }
            set { this.issuingOrganization = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT301010CA.Subject2.registrationEvent 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf1/registrationEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Merged.RegistrationEvent SubjectOf1RegistrationEvent {
            get { return this.subjectOf1RegistrationEvent; }
            set { this.subjectOf1RegistrationEvent = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT301010CA.Subject3.stateTransitionControlActEvent 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2/stateTransitionControlActEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Merged.StatusChangeDetails> SubjectOf2StateTransitionControlActEvent {
            get { return this.subjectOf2StateTransitionControlActEvent; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT301010CA.ResponsibleParty.privilege 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleFor/privilege"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Merged.Privilege> ResponsibleForPrivilege {
            get { return this.responsibleForPrivilege; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: PRPM_MT301010CA.RoleChoice.relatedTo 
         * Conformance/Cardinality: REQUIRED (0-100)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"relatedTo"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Prpm_mt301010ca.RelatedTo> RelatedTo {
            get { return this.relatedTo; }
        }

    }

}