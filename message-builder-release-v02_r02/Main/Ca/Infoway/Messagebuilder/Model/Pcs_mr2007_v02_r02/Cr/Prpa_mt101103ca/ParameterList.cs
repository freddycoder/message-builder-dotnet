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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Cr.Prpa_mt101103ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"PRPA_MT101103CA.ParameterList"})]
    public class ParameterList : MessagePartBean {

        private CV administrativeGenderValue;
        private IList<II> clientIdValue;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Cr.Prpa_mt101103ca.DeceasedIndicator deceasedIndicator;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Cr.Prpa_mt101103ca.DeceasedTime deceasedTime;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Cr.Prpa_mt101103ca.LanguageCode languageCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Cr.Prpa_mt101103ca.MultipleBirthIndicator multipleBirthIndicator;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Cr.Prpa_mt101103ca.MultipleBirthOrderNumber multipleBirthOrderNumber;
        private IList<AD> personAddressValue;
        private TS personBirthtimeValue;
        private IList<PN> personNameValue;
        private IList<TEL> personTelecomValue;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Cr.Prpa_mt101103ca.PersonalRelationshipCode personalRelationshipCode;

        public ParameterList() {
            this.administrativeGenderValue = new CVImpl();
            this.clientIdValue = new List<II>();
            this.personAddressValue = new List<AD>();
            this.personBirthtimeValue = new TSImpl();
            this.personNameValue = new List<PN>();
            this.personTelecomValue = new List<TEL>();
        }
        /**
         * <summary>Business Name: Client Gender</summary>
         * 
         * <remarks>Relationship: 
         * PRPA_MT101103CA.AdministrativeGender.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports the identification of the client</p> 
         * <p>Gender of the Client, this is not to be confused with 
         * Clinical Gender of a client. Administrative Gender is 
         * typically restricted to Male (M), Female (F) or Unknown 
         * (U)</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"administrativeGender/value"})]
        public AdministrativeGender AdministrativeGenderValue {
            get { return (AdministrativeGender) this.administrativeGenderValue.Value; }
            set { this.administrativeGenderValue.Value = value; }
        }

        /**
         * <summary>Business Name: (Client Healthcare Identification 
         * Number And Or NonHealthcare Identification</summary>
         * 
         * <remarks>Relationship: PRPA_MT101103CA.ClientId.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports the identification of the client</p> 
         * <p>Healthcare identiers may be assigned jurisdictionally or 
         * by care facility and/or non-healthcare identifiers for the 
         * Client (e.g. Passport, SIN, DND, DIAND, Drivers License)</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"clientId/value"})]
        public IList<Identifier> ClientIdValue {
            get { return new RawListWrapper<II, Identifier>(clientIdValue, typeof(IIImpl)); }
        }

        /**
         * <summary>Relationship: 
         * PRPA_MT101103CA.ParameterList.deceasedIndicator</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"deceasedIndicator"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Cr.Prpa_mt101103ca.DeceasedIndicator DeceasedIndicator {
            get { return this.deceasedIndicator; }
            set { this.deceasedIndicator = value; }
        }

        /**
         * <summary>Relationship: 
         * PRPA_MT101103CA.ParameterList.deceasedTime</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"deceasedTime"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Cr.Prpa_mt101103ca.DeceasedTime DeceasedTime {
            get { return this.deceasedTime; }
            set { this.deceasedTime = value; }
        }

        /**
         * <summary>Relationship: 
         * PRPA_MT101103CA.ParameterList.languageCode</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"languageCode"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Cr.Prpa_mt101103ca.LanguageCode LanguageCode {
            get { return this.languageCode; }
            set { this.languageCode = value; }
        }

        /**
         * <summary>Relationship: 
         * PRPA_MT101103CA.ParameterList.multipleBirthIndicator</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"multipleBirthIndicator"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Cr.Prpa_mt101103ca.MultipleBirthIndicator MultipleBirthIndicator {
            get { return this.multipleBirthIndicator; }
            set { this.multipleBirthIndicator = value; }
        }

        /**
         * <summary>Relationship: 
         * PRPA_MT101103CA.ParameterList.multipleBirthOrderNumber</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"multipleBirthOrderNumber"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Cr.Prpa_mt101103ca.MultipleBirthOrderNumber MultipleBirthOrderNumber {
            get { return this.multipleBirthOrderNumber; }
            set { this.multipleBirthOrderNumber = value; }
        }

        /**
         * <summary>Business Name: Client Address</summary>
         * 
         * <remarks>Relationship: PRPA_MT101103CA.PersonAddress.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports the identification of the client</p> 
         * <p>Address(es) of the Client</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"personAddress/value"})]
        public IList<PostalAddress> PersonAddressValue {
            get { return new RawListWrapper<AD, PostalAddress>(personAddressValue, typeof(ADImpl)); }
        }

        /**
         * <summary>Business Name: Client Date of Birth</summary>
         * 
         * <remarks>Relationship: PRPA_MT101103CA.PersonBirthtime.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports the identification of the client</p> 
         * <p>Date of birth of the Client</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"personBirthtime/value"})]
        public PlatformDate PersonBirthtimeValue {
            get { return this.personBirthtimeValue.Value; }
            set { this.personBirthtimeValue.Value = value; }
        }

        /**
         * <summary>Business Name: Client Name</summary>
         * 
         * <remarks>Relationship: PRPA_MT101103CA.PersonName.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports the identification of the client</p> 
         * <p>Name(s) for the Client</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"personName/value"})]
        public IList<PersonName> PersonNameValue {
            get { return new RawListWrapper<PN, PersonName>(personNameValue, typeof(PNImpl)); }
        }

        /**
         * <summary>Business Name: Client Telecom</summary>
         * 
         * <remarks>Relationship: PRPA_MT101103CA.PersonTelecom.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports the identification of the client</p> 
         * <p>Provides information about telecom</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"personTelecom/value"})]
        public IList<TelecommunicationAddress> PersonTelecomValue {
            get { return new RawListWrapper<TEL, TelecommunicationAddress>(personTelecomValue, typeof(TELImpl)); }
        }

        /**
         * <summary>Relationship: 
         * PRPA_MT101103CA.ParameterList.personalRelationshipCode</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"personalRelationshipCode"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Cr.Prpa_mt101103ca.PersonalRelationshipCode PersonalRelationshipCode {
            get { return this.personalRelationshipCode; }
            set { this.personalRelationshipCode = value; }
        }

    }

}