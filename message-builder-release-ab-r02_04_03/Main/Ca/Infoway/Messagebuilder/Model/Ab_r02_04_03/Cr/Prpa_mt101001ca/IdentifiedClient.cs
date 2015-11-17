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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Cr.Prpa_mt101001ca {
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


    /**
     * <summary>Business Name: Identified Client</summary>
     * 
     * <p>Provides the message entry point required to add a person 
     * to the Client Registry</p> <p>The IdentifiedEntity class is 
     * the entry point to the R-MIM and contains one or more 
     * identifiers (for example an &quot;internal&quot; id used 
     * only by computer systems and an &quot;external&quot; id for 
     * display to users) for the Person in the Client Registry. The 
     * statusCode is set to &quot;active&quot;. The beginning of 
     * the effectiveTime is when the record was added to the 
     * registry.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPA_MT101001CA.IdentifiedEntity"})]
    public class IdentifiedClient : MessagePartBean {

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

        public IdentifiedClient() {
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
         * <remarks>Relationship: PRPA_MT101001CA.IdentifiedEntity.id 
         * Conformance/Cardinality: REQUIRED (1-40) <p>Populated 
         * attribute supports unique identification of the client.</p> 
         * <p>At least 1 client identifier must be present in the 
         * message</p> <p>This identification attribute supports 
         * capture of a healthcare identifier specific to the client. 
         * This identifier may be assigned jurisdictionally or by care 
         * facility.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public ICollection<Identifier> Id {
            get { return this.id.RawSet(); }
        }

        /**
         * <summary>Business Name: Client Status Code</summary>
         * 
         * <remarks>Relationship: 
         * PRPA_MT101001CA.IdentifiedEntity.statusCode 
         * Conformance/Cardinality: REQUIRED (1) <p>Populated attribute 
         * supports the identification of the client</p> <p>Indicates 
         * the status of the Client role (e.g. Active)</p></remarks>
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
         * PRPA_MT101001CA.IdentifiedEntity.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute supports the identification of the client</p> 
         * <p>An interval of time specifying the period during which 
         * this record in a client registry is in effect, if such time 
         * limit is applicable and known.</p></remarks>
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
         * PRPA_MT101001CA.IdentifiedEntity.confidentialityCode 
         * Conformance/Cardinality: REQUIRED (1) <p>Populated attribute 
         * supports the business requirement to provide restricted 
         * access where required</p> <p>Data in the EHR may at some 
         * point (and in some jurisdictions) be accessed directly by 
         * patients. Some health information may be deemed 
         * inappropriate for direct access by patients and requires 
         * interpretation by a clinician (e.g. prescription of 
         * placebos, analysis of certain psychiatric conditions, etc) 
         * Even where direct access by patient is not provided, there 
         * may need to be guidance to other providers viewing the 
         * record where care should be used in disclosing information 
         * to the patient. Non-clinical data (e.g. demographics) may 
         * need to be flagged as not for disclosure to patient and or 
         * next of kin. There may be professional policy and or 
         * legislative guidelines about when/if records may be flagged 
         * as not for direct disclosure.</p> <p>A code that controls 
         * the disclosure of information about this client record.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public x_VeryBasicConfidentialityKind ConfidentialityCode {
            get { return (x_VeryBasicConfidentialityKind) this.confidentialityCode.Value; }
            set { this.confidentialityCode.Value = value; }
        }

        /**
         * <summary>Business Name: Client Name</summary>
         * 
         * <remarks>Relationship: PRPA_MT101001CA.Person.name 
         * Conformance/Cardinality: REQUIRED (1-20) <p>Populated 
         * attribute supports the identification of the client</p> 
         * <p>Name(s) for the Client</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"identifiedPerson/name"})]
        public IList<PersonName> IdentifiedPersonName {
            get { return this.identifiedPersonName.RawList(); }
        }

        /**
         * <summary>Business Name: Client Telecom</summary>
         * 
         * <remarks>Relationship: PRPA_MT101001CA.Person.telecom 
         * Conformance/Cardinality: REQUIRED (1-20) <p>Required 
         * attribute supports the identification of the client</p> 
         * <p>Provides information about telecom</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"identifiedPerson/telecom"})]
        public IList<TelecommunicationAddress> IdentifiedPersonTelecom {
            get { return this.identifiedPersonTelecom.RawList(); }
        }

        /**
         * <summary>Business Name: Client Gender</summary>
         * 
         * <remarks>Relationship: 
         * PRPA_MT101001CA.Person.administrativeGenderCode 
         * Conformance/Cardinality: REQUIRED (1) <p>Populated attribute 
         * supports the identification of the client</p> <p>Gender of 
         * the Client, this is not to be confused with Clinical Gender 
         * of a client. Administrative Gender is typically restricted 
         * to Male (M), Female (F) or Undifferentiated (UN)</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"identifiedPerson/administrativeGenderCode"})]
        public AdministrativeGender IdentifiedPersonAdministrativeGenderCode {
            get { return (AdministrativeGender) this.identifiedPersonAdministrativeGenderCode.Value; }
            set { this.identifiedPersonAdministrativeGenderCode.Value = value; }
        }

        /**
         * <summary>Business Name: Client Date of Birth</summary>
         * 
         * <remarks>Relationship: PRPA_MT101001CA.Person.birthTime 
         * Conformance/Cardinality: REQUIRED (1) <p>Populated attribute 
         * supports the identification of the client</p> <p>Date of 
         * birth of the Client</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"identifiedPerson/birthTime"})]
        public PlatformDate IdentifiedPersonBirthTime {
            get { return this.identifiedPersonBirthTime.Value; }
            set { this.identifiedPersonBirthTime.Value = value; }
        }

        /**
         * <summary>Business Name: Client Deceased Indicator</summary>
         * 
         * <remarks>Relationship: PRPA_MT101001CA.Person.deceasedInd 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute supports the identification of the client</p> 
         * <p>An indication that the client is deceased. Appropriate 
         * business process/function will need to be employed to ensure 
         * that validation or verification of the death event has been 
         * established prior to populating the message.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"identifiedPerson/deceasedInd"})]
        public bool? IdentifiedPersonDeceasedInd {
            get { return this.identifiedPersonDeceasedInd.Value; }
            set { this.identifiedPersonDeceasedInd.Value = value; }
        }

        /**
         * <summary>Business Name: Client Deceased Date</summary>
         * 
         * <remarks>Relationship: PRPA_MT101001CA.Person.deceasedTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Deceased time 
         * only present if deceasedInd is = TRUE</p> <p>Required 
         * attribute supports verification of death from official 
         * source such as Vital Statistics.</p> <p>The date and time 
         * that a client's death occurred</p></remarks>
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
         * PRPA_MT101001CA.Person.multipleBirthInd 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute supports the identification of the client</p> 
         * <p>An indication as to whether the client is part of a 
         * multiple birth.</p></remarks>
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
         * PRPA_MT101001CA.Person.multipleBirthOrderNumber 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute supports the identification of the client</p> 
         * <p>The order in which this client was born if part of a 
         * multiple birth.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"identifiedPerson/multipleBirthOrderNumber"})]
        public int? IdentifiedPersonMultipleBirthOrderNumber {
            get { return this.identifiedPersonMultipleBirthOrderNumber.Value; }
            set { this.identifiedPersonMultipleBirthOrderNumber.Value = value; }
        }

        /**
         * <summary>Business Name: Client Address</summary>
         * 
         * <remarks>Relationship: PRPA_MT101001CA.Person.addr 
         * Conformance/Cardinality: REQUIRED (1-10) <p>Populated 
         * attribute supports the identification of the client</p> 
         * <p>Address(es) of the Client</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"identifiedPerson/addr"})]
        public IList<PostalAddress> IdentifiedPersonAddr {
            get { return this.identifiedPersonAddr.RawList(); }
        }

        /**
         * <summary>Relationship: PRPA_MT101001CA.Person.asOtherIDs</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-100)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"identifiedPerson/asOtherIDs"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Cr.Merged.OtherIDsNonHealthcareIdentifiers> IdentifiedPersonAsOtherIDs {
            get { return this.identifiedPersonAsOtherIDs; }
        }

        /**
         * <summary>Relationship: 
         * PRPA_MT101001CA.Person.personalRelationship</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-10)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"identifiedPerson/personalRelationship"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Cr.Merged.PersonalRelationship> IdentifiedPersonPersonalRelationship {
            get { return this.identifiedPersonPersonalRelationship; }
        }

        /**
         * <summary>Relationship: 
         * PRPA_MT101001CA.Person.languageCommunication</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1-10)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"identifiedPerson/languageCommunication"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Merged.LanguageCommunication> IdentifiedPersonLanguageCommunication {
            get { return this.identifiedPersonLanguageCommunication; }
        }

    }

}