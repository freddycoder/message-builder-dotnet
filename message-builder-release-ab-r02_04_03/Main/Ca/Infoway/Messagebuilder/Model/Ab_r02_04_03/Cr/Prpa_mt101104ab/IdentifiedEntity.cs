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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Cr.Prpa_mt101104ab {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Cr.Merged;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Merged;
    using System;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"PRPA_MT101104AB.IdentifiedEntity"})]
    public class IdentifiedEntity : MessagePartBean {

        private SET<II, Identifier> id;
        private CS statusCode;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private CV confidentialityCode;
        private LIST<PN, PersonName> identifiedPersonName;
        private LIST<TEL, TelecommunicationAddress> identifiedPersonTelecom;
        private CV identifiedPersonAdministrativeGenderCode;
        private TS identifiedPersonBirthTime;
        private BL identifiedPersonDeceasedInd;
        private TS identifiedPersonDeceasedTime;
        private BL identifiedPersonMultipleBirthInd;
        private INT identifiedPersonMultipleBirthOrderNumber;
        private LIST<AD, PostalAddress> identifiedPersonAddr;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Cr.Merged.OtherIDsNonHealthcareIdentifiers> identifiedPersonAsOtherIDs;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Cr.Merged.PersonalRelationship> identifiedPersonPersonalRelationship;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Merged.LanguageCommunication> identifiedPersonLanguageCommunication;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Merged.ConfidenceValue subjectOfObservationEvent;

        public IdentifiedEntity() {
            this.id = new SETImpl<II, Identifier>(typeof(IIImpl));
            this.statusCode = new CSImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.confidentialityCode = new CVImpl();
            this.identifiedPersonName = new LISTImpl<PN, PersonName>(typeof(PNImpl));
            this.identifiedPersonTelecom = new LISTImpl<TEL, TelecommunicationAddress>(typeof(TELImpl));
            this.identifiedPersonAdministrativeGenderCode = new CVImpl();
            this.identifiedPersonBirthTime = new TSImpl();
            this.identifiedPersonDeceasedInd = new BLImpl();
            this.identifiedPersonDeceasedTime = new TSImpl();
            this.identifiedPersonMultipleBirthInd = new BLImpl();
            this.identifiedPersonMultipleBirthOrderNumber = new INTImpl();
            this.identifiedPersonAddr = new LISTImpl<AD, PostalAddress>(typeof(ADImpl));
            this.identifiedPersonAsOtherIDs = new List<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Cr.Merged.OtherIDsNonHealthcareIdentifiers>();
            this.identifiedPersonPersonalRelationship = new List<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Cr.Merged.PersonalRelationship>();
            this.identifiedPersonLanguageCommunication = new List<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Merged.LanguageCommunication>();
        }
        /**
         * <summary>Business Name: Client Healthcare Identification 
         * Number</summary>
         * 
         * <remarks>Relationship: PRPA_MT101104AB.IdentifiedEntity.id 
         * Conformance/Cardinality: MANDATORY (1-40)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public ICollection<Identifier> Id {
            get { return this.id.RawSet(); }
        }

        /**
         * <summary>Business Name: Client Status Code</summary>
         * 
         * <remarks>Relationship: 
         * PRPA_MT101104AB.IdentifiedEntity.statusCode 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public RoleStatus StatusCode {
            get { return (RoleStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: Client Effective Time</summary>
         * 
         * <remarks>Relationship: 
         * PRPA_MT101104AB.IdentifiedEntity.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: Client Masked Information</summary>
         * 
         * <remarks>Relationship: 
         * PRPA_MT101104AB.IdentifiedEntity.confidentialityCode 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public x_VeryBasicConfidentialityKind ConfidentialityCode {
            get { return (x_VeryBasicConfidentialityKind) this.confidentialityCode.Value; }
            set { this.confidentialityCode.Value = value; }
        }

        /**
         * <summary>Business Name: Client Name</summary>
         * 
         * <remarks>Relationship: PRPA_MT101104AB.Person.name 
         * Conformance/Cardinality: REQUIRED (1-20)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"identifiedPerson/name"})]
        public IList<PersonName> IdentifiedPersonName {
            get { return this.identifiedPersonName.RawList(); }
        }

        /**
         * <summary>Business Name: Client Telecom</summary>
         * 
         * <remarks>Relationship: PRPA_MT101104AB.Person.telecom 
         * Conformance/Cardinality: REQUIRED (1-10)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"identifiedPerson/telecom"})]
        public IList<TelecommunicationAddress> IdentifiedPersonTelecom {
            get { return this.identifiedPersonTelecom.RawList(); }
        }

        /**
         * <summary>Business Name: Client Gender</summary>
         * 
         * <remarks>Relationship: 
         * PRPA_MT101104AB.Person.administrativeGenderCode 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"identifiedPerson/administrativeGenderCode"})]
        public AdministrativeGender IdentifiedPersonAdministrativeGenderCode {
            get { return (AdministrativeGender) this.identifiedPersonAdministrativeGenderCode.Value; }
            set { this.identifiedPersonAdministrativeGenderCode.Value = value; }
        }

        /**
         * <summary>Business Name: Client Date of Birth</summary>
         * 
         * <remarks>Relationship: PRPA_MT101104AB.Person.birthTime 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"identifiedPerson/birthTime"})]
        public PlatformDate IdentifiedPersonBirthTime {
            get { return this.identifiedPersonBirthTime.Value; }
            set { this.identifiedPersonBirthTime.Value = value; }
        }

        /**
         * <summary>Business Name: Client Deceased Indicator</summary>
         * 
         * <remarks>Relationship: PRPA_MT101104AB.Person.deceasedInd 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"identifiedPerson/deceasedInd"})]
        public bool? IdentifiedPersonDeceasedInd {
            get { return this.identifiedPersonDeceasedInd.Value; }
            set { this.identifiedPersonDeceasedInd.Value = value; }
        }

        /**
         * <summary>Business Name: Client Deceased Date</summary>
         * 
         * <remarks>Relationship: PRPA_MT101104AB.Person.deceasedTime 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"identifiedPerson/deceasedTime"})]
        public PlatformDate IdentifiedPersonDeceasedTime {
            get { return this.identifiedPersonDeceasedTime.Value; }
            set { this.identifiedPersonDeceasedTime.Value = value; }
        }

        /**
         * <summary>Business Name: Client Multiple Birth Indicator</summary>
         * 
         * <remarks>Relationship: 
         * PRPA_MT101104AB.Person.multipleBirthInd 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"identifiedPerson/multipleBirthInd"})]
        public bool? IdentifiedPersonMultipleBirthInd {
            get { return this.identifiedPersonMultipleBirthInd.Value; }
            set { this.identifiedPersonMultipleBirthInd.Value = value; }
        }

        /**
         * <summary>Business Name: Client Multiple Birth Order Number</summary>
         * 
         * <remarks>Relationship: 
         * PRPA_MT101104AB.Person.multipleBirthOrderNumber 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"identifiedPerson/multipleBirthOrderNumber"})]
        public int? IdentifiedPersonMultipleBirthOrderNumber {
            get { return this.identifiedPersonMultipleBirthOrderNumber.Value; }
            set { this.identifiedPersonMultipleBirthOrderNumber.Value = value; }
        }

        /**
         * <summary>Business Name: Client Address</summary>
         * 
         * <remarks>Relationship: PRPA_MT101104AB.Person.addr 
         * Conformance/Cardinality: REQUIRED (1-10)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"identifiedPerson/addr"})]
        public IList<PostalAddress> IdentifiedPersonAddr {
            get { return this.identifiedPersonAddr.RawList(); }
        }

        /**
         * <summary>Relationship: PRPA_MT101104AB.Person.asOtherIDs</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-100)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"identifiedPerson/asOtherIDs"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Cr.Merged.OtherIDsNonHealthcareIdentifiers> IdentifiedPersonAsOtherIDs {
            get { return this.identifiedPersonAsOtherIDs; }
        }

        /**
         * <summary>Relationship: 
         * PRPA_MT101104AB.Person.personalRelationship</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-10)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"identifiedPerson/personalRelationship"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Cr.Merged.PersonalRelationship> IdentifiedPersonPersonalRelationship {
            get { return this.identifiedPersonPersonalRelationship; }
        }

        /**
         * <summary>Relationship: 
         * PRPA_MT101104AB.Person.languageCommunication</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1-10)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"identifiedPerson/languageCommunication"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Merged.LanguageCommunication> IdentifiedPersonLanguageCommunication {
            get { return this.identifiedPersonLanguageCommunication; }
        }

        /**
         * <summary>Relationship: 
         * PRPA_MT101104AB.Subject.observationEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf/observationEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Merged.ConfidenceValue SubjectOfObservationEvent {
            get { return this.subjectOfObservationEvent; }
            set { this.subjectOfObservationEvent = value; }
        }

    }

}