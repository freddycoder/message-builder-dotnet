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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: HealthcareProvider</summary>
     * 
     * <remarks>COCT_MT290000CA.HealthCareProvider: Healthcare 
     * Provider <p>Healthcare Provider</p> 
     * COCT_MT490000CA.HealthCareProvider: Healthcare Provider 
     * <p>Person providing healthcare service</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT290000CA.HealthCareProvider","COCT_MT490000CA.HealthCareProvider"})]
    public class HealthcareProvider : MessagePartBean {

        private SET<II, Identifier> id;
        private CV code;
        private PN healthCareProviderPersonName;
        private TEL healthCareProviderPersonTelecom;
        private CV healthCareProviderPersonAdministrativeGenderCode;
        private TS healthCareProviderPersonBirthTime;
        private AD healthCareProviderPersonAddr;

        public HealthcareProvider() {
            this.id = new SETImpl<II, Identifier>(typeof(IIImpl));
            this.code = new CVImpl();
            this.healthCareProviderPersonName = new PNImpl();
            this.healthCareProviderPersonTelecom = new TELImpl();
            this.healthCareProviderPersonAdministrativeGenderCode = new CVImpl();
            this.healthCareProviderPersonBirthTime = new TSImpl();
            this.healthCareProviderPersonAddr = new ADImpl();
        }
        /**
         * <summary>Un-merged Business Name: ProviderIdentifiers</summary>
         * 
         * <remarks>Relationship: COCT_MT290000CA.HealthCareProvider.id 
         * Conformance/Cardinality: REQUIRED (0-9) <p>More than 
         * provider identifier could be provided, eg. for dental 
         * claims.</p> <p>Provider ID, eg. Prof. license no.</p> 
         * Un-merged Business Name: ProviderID Relationship: 
         * COCT_MT490000CA.HealthCareProvider.id 
         * Conformance/Cardinality: REQUIRED (0-9) <p>More than 1 
         * Provider identifier can be provided for a particular role, 
         * e.g. some dental claims. An Id may not be available for out 
         * of jurisdiction providers and consulltants.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public ICollection<Identifier> Id {
            get { return this.id.RawSet(); }
        }

        /**
         * <summary>Un-merged Business Name: ProviderType</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT290000CA.HealthCareProvider.code 
         * Conformance/Cardinality: POPULATED (1) <p>Allows for 
         * crosswalks between speciality code sets</p> Un-merged 
         * Business Name: HealthcareProviderCode Relationship: 
         * COCT_MT490000CA.HealthCareProvider.code 
         * Conformance/Cardinality: POPULATED (1) <p>code denoting 
         * healthcare Provider Type</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public HealthcareProviderRoleType Code {
            get { return (HealthcareProviderRoleType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: NameOfProvider</summary>
         * 
         * <remarks>Relationship: COCT_MT290000CA.ProviderPerson.name 
         * Conformance/Cardinality: MANDATORY (1) <p>Name of person 
         * providing service or drug</p> Un-merged Business Name: 
         * ProviderName Relationship: 
         * COCT_MT490000CA.ProviderPerson.name Conformance/Cardinality: 
         * MANDATORY (1) <p>Name of Provider</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"healthCareProviderPerson/name"})]
        public PersonName HealthCareProviderPersonName {
            get { return this.healthCareProviderPersonName.Value; }
            set { this.healthCareProviderPersonName.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: ContactNo</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT290000CA.ProviderPerson.telecom 
         * Conformance/Cardinality: REQUIRED (0-1) <p>contact info. for 
         * Provider</p> Un-merged Business Name: ProviderTelecom 
         * Relationship: COCT_MT490000CA.ProviderPerson.telecom 
         * Conformance/Cardinality: REQUIRED (0-1) <p>only required if 
         * provider is not known to the Payor</p> <p>Telephone no. of 
         * provider</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"healthCareProviderPerson/telecom"})]
        public TelecommunicationAddress HealthCareProviderPersonTelecom {
            get { return this.healthCareProviderPersonTelecom.Value; }
            set { this.healthCareProviderPersonTelecom.Value = value; }
        }

        /**
         * <summary>Business Name: ProviderGender</summary>
         * 
         * <remarks>Un-merged Business Name: ProviderGender 
         * Relationship: 
         * COCT_MT290000CA.ProviderPerson.administrativeGenderCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Telecom, gender, 
         * birth time, addr are only required if provider is not known 
         * to the Payor</p> Un-merged Business Name: ProviderGender 
         * Relationship: 
         * COCT_MT490000CA.ProviderPerson.administrativeGenderCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>only required if 
         * provider is not known to the Payor</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"healthCareProviderPerson/administrativeGenderCode"})]
        public AdministrativeGender HealthCareProviderPersonAdministrativeGenderCode {
            get { return (AdministrativeGender) this.healthCareProviderPersonAdministrativeGenderCode.Value; }
            set { this.healthCareProviderPersonAdministrativeGenderCode.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: ProviderDateOfBirth</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT290000CA.ProviderPerson.birthTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Telecom, gender, 
         * birth time, addr are only required if provider is not known 
         * to the Payor</p> Un-merged Business Name: ProviderBirthDate 
         * Relationship: COCT_MT490000CA.ProviderPerson.birthTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>only required if 
         * provider is not known to the Payor</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"healthCareProviderPerson/birthTime"})]
        public PlatformDate HealthCareProviderPersonBirthTime {
            get { return this.healthCareProviderPersonBirthTime.Value; }
            set { this.healthCareProviderPersonBirthTime.Value = value; }
        }

        /**
         * <summary>Business Name: ProviderAddress</summary>
         * 
         * <remarks>Un-merged Business Name: ProviderAddress 
         * Relationship: COCT_MT290000CA.ProviderPerson.addr 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Can be used to 
         * specify jurisdiction for OOJ providers</p> <p>Telecom, 
         * gender, birth time, addr are only required if provider is 
         * not known to the Payor</p> Un-merged Business Name: 
         * ProviderAddress Relationship: 
         * COCT_MT490000CA.ProviderPerson.addr Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Can be used to specify jurisdiction for 
         * OOJ providers</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"healthCareProviderPerson/addr"})]
        public PostalAddress HealthCareProviderPersonAddr {
            get { return this.healthCareProviderPersonAddr.Value; }
            set { this.healthCareProviderPersonAddr.Value = value; }
        }

    }

}