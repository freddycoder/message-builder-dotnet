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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Domainvalue;
    using System;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT400001CA.CoveredParty","FICR_MT400003CA.CoveredParty","FICR_MT400004CA.CoveredParty","FICR_MT490101CA.CoveredParty","FICR_MT490102CA.CoveredParty"})]
    public class CoveredParty : MessagePartBean {

        private II id;
        private CV code;
        private SET<PN, PersonName> coveredPartyAsPatientPersonName;
        private CV coveredPartyAsPatientPersonAdministrativeGenderCode;
        private TS coveredPartyAsPatientPersonBirthTime;
        private AD coveredPartyAsPatientPersonAddr;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Merged.PersonalRelationship> indirectAuthorityPersonalRelationship;

        public CoveredParty() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.coveredPartyAsPatientPersonName = new SETImpl<PN, PersonName>(typeof(PNImpl));
            this.coveredPartyAsPatientPersonAdministrativeGenderCode = new CVImpl();
            this.coveredPartyAsPatientPersonBirthTime = new TSImpl();
            this.coveredPartyAsPatientPersonAddr = new ADImpl();
            this.indirectAuthorityPersonalRelationship = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Merged.PersonalRelationship>();
        }
        /**
         * <summary>Business Name: CoveredPartyIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: CoveredPartyIdentifier 
         * Relationship: FICR_MT490101CA.CoveredParty.id 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: CoveredPartyIdentifier Relationship: 
         * FICR_MT400001CA.CoveredParty.id Conformance/Cardinality: 
         * MANDATORY (1) Un-merged Business Name: 
         * CoveredPartyIdentifier Relationship: 
         * FICR_MT400003CA.CoveredParty.id Conformance/Cardinality: 
         * MANDATORY (1) Un-merged Business Name: 
         * CoveredPartyIdentifier Relationship: 
         * FICR_MT400004CA.CoveredParty.id Conformance/Cardinality: 
         * MANDATORY (1) Un-merged Business Name: 
         * CoveredPartyIdentifier Relationship: 
         * FICR_MT490102CA.CoveredParty.id Conformance/Cardinality: 
         * MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: RelationshipToPolicyHolder</summary>
         * 
         * <remarks>Un-merged Business Name: RelationshipToPolicyHolder 
         * Relationship: FICR_MT490101CA.CoveredParty.code 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: RelationshipToPolicyHolder Relationship: 
         * FICR_MT400001CA.CoveredParty.code Conformance/Cardinality: 
         * MANDATORY (1) Un-merged Business Name: 
         * RelationshipToPolicyHolder Relationship: 
         * FICR_MT400003CA.CoveredParty.code Conformance/Cardinality: 
         * MANDATORY (1) Un-merged Business Name: 
         * RelationshipToPolicyHolder Relationship: 
         * FICR_MT400004CA.CoveredParty.code Conformance/Cardinality: 
         * MANDATORY (1) Un-merged Business Name: 
         * RelationshipToPolicyHolder Relationship: 
         * FICR_MT490102CA.CoveredParty.code Conformance/Cardinality: 
         * MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public CoveredPartyRoleType Code {
            get { return (CoveredPartyRoleType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: CoveredPartyPatientNameS</summary>
         * 
         * <remarks>Un-merged Business Name: CoveredPartyPatientNameS 
         * Relationship: 
         * FICR_MT490101CA.CoveredPartyAsPatientPerson.name 
         * Conformance/Cardinality: MANDATORY (1-5) Un-merged Business 
         * Name: CoveredPartyPatientNameS Relationship: 
         * FICR_MT400001CA.CoveredPartyAsPatientPerson.name 
         * Conformance/Cardinality: MANDATORY (1-5) Un-merged Business 
         * Name: CoveredPartyPatientNameS Relationship: 
         * FICR_MT400003CA.CoveredPartyAsPatientPerson.name 
         * Conformance/Cardinality: MANDATORY (1-5) Un-merged Business 
         * Name: CoveredPartyPatientNameS Relationship: 
         * FICR_MT400004CA.CoveredPartyAsPatientPerson.name 
         * Conformance/Cardinality: MANDATORY (1-5) Un-merged Business 
         * Name: CoveredPartyPatientNameS Relationship: 
         * FICR_MT490102CA.CoveredPartyAsPatientPerson.name 
         * Conformance/Cardinality: MANDATORY (1-5)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"coveredPartyAsPatientPerson/name"})]
        public ICollection<PersonName> CoveredPartyAsPatientPersonName {
            get { return this.coveredPartyAsPatientPersonName.RawSet(); }
        }

        /**
         * <summary>Business Name: CoveredPartyPatientGender</summary>
         * 
         * <remarks>Un-merged Business Name: CoveredPartyPatientGender 
         * Relationship: 
         * FICR_MT490101CA.CoveredPartyAsPatientPerson.administrativeGenderCode 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: CoveredPartyPatientGender Relationship: 
         * FICR_MT400001CA.CoveredPartyAsPatientPerson.administrativeGenderCode 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: CoveredPartyPatientGender Relationship: 
         * FICR_MT400003CA.CoveredPartyAsPatientPerson.administrativeGenderCode 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: CoveredPartyPatientGender Relationship: 
         * FICR_MT400004CA.CoveredPartyAsPatientPerson.administrativeGenderCode 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: CoveredPartyPatientGender Relationship: 
         * FICR_MT490102CA.CoveredPartyAsPatientPerson.administrativeGenderCode 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"coveredPartyAsPatientPerson/administrativeGenderCode"})]
        public AdministrativeGender CoveredPartyAsPatientPersonAdministrativeGenderCode {
            get { return (AdministrativeGender) this.coveredPartyAsPatientPersonAdministrativeGenderCode.Value; }
            set { this.coveredPartyAsPatientPersonAdministrativeGenderCode.Value = value; }
        }

        /**
         * <summary>Business Name: CoveredPartyPatientDateOfBirth</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * CoveredPartyPatientDateOfBirth Relationship: 
         * FICR_MT490101CA.CoveredPartyAsPatientPerson.birthTime 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: CoveredPartyPatientDateOfBirth Relationship: 
         * FICR_MT400001CA.CoveredPartyAsPatientPerson.birthTime 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: CoveredPartyPatientDateOfBirth Relationship: 
         * FICR_MT400003CA.CoveredPartyAsPatientPerson.birthTime 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: CoveredPartyPatientDateOfBirth Relationship: 
         * FICR_MT400004CA.CoveredPartyAsPatientPerson.birthTime 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: CoveredPartyPatientDateOfBirth Relationship: 
         * FICR_MT490102CA.CoveredPartyAsPatientPerson.birthTime 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"coveredPartyAsPatientPerson/birthTime"})]
        public PlatformDate CoveredPartyAsPatientPersonBirthTime {
            get { return this.coveredPartyAsPatientPersonBirthTime.Value; }
            set { this.coveredPartyAsPatientPersonBirthTime.Value = value; }
        }

        /**
         * <summary>Business Name: CoveredPartyPatientAddress</summary>
         * 
         * <remarks>Un-merged Business Name: CoveredPartyPatientAddress 
         * Relationship: 
         * FICR_MT490101CA.CoveredPartyAsPatientPerson.addr 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: CoveredPartyPatientAddress Relationship: 
         * FICR_MT400001CA.CoveredPartyAsPatientPerson.addr 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: CoveredPartyPatientAddress Relationship: 
         * FICR_MT400003CA.CoveredPartyAsPatientPerson.addr 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: CoveredPartyPatientAddress Relationship: 
         * FICR_MT400004CA.CoveredPartyAsPatientPerson.addr 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: CoveredPartyPatientAddress Relationship: 
         * FICR_MT490102CA.CoveredPartyAsPatientPerson.addr 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"coveredPartyAsPatientPerson/addr"})]
        public PostalAddress CoveredPartyAsPatientPersonAddr {
            get { return this.coveredPartyAsPatientPersonAddr.Value; }
            set { this.coveredPartyAsPatientPersonAddr.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT490101CA.IndirectAuthorithyOver.personalRelationship 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * FICR_MT400001CA.IndirectAuthorithyOver.personalRelationship 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * FICR_MT400003CA.IndirectAuthorithyOver.personalRelationship 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * FICR_MT400004CA.IndirectAuthorithyOver.personalRelationship 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * FICR_MT490102CA.IndirectAuthorithyOver.personalRelationship 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"indirectAuthority/personalRelationship"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Merged.PersonalRelationship> IndirectAuthorityPersonalRelationship {
            get { return this.indirectAuthorityPersonalRelationship; }
        }

    }

}