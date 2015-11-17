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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt490001ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Domainvalue;
    using System;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT490001CA.ParameterList"})]
    public class ParameterList : MessagePartBean {

        private CV approvedDeviceCodeValue;
        private CV approvedDrugCodeValue;
        private II authorIDId;
        private PN authorNameValue;
        private TS coveredPartyDOBValue;
        private CV coveredPartyGenderValue;
        private PN coveredPartyNameValue;
        private IVL<TS, Interval<PlatformDate>> expiryDateRangeValue;
        private II policyIdentifierValue;
        private CV requestedDeviceCodeValue;
        private CV requestedDrugCodeValue;
        private CV specialAuthorizationRequestTypeValue;
        private IList<CV> specialAuthorizationStatusValue;

        public ParameterList() {
            this.approvedDeviceCodeValue = new CVImpl();
            this.approvedDrugCodeValue = new CVImpl();
            this.authorIDId = new IIImpl();
            this.authorNameValue = new PNImpl();
            this.coveredPartyDOBValue = new TSImpl();
            this.coveredPartyGenderValue = new CVImpl();
            this.coveredPartyNameValue = new PNImpl();
            this.expiryDateRangeValue = new IVLImpl<TS, Interval<PlatformDate>>();
            this.policyIdentifierValue = new IIImpl();
            this.requestedDeviceCodeValue = new CVImpl();
            this.requestedDrugCodeValue = new CVImpl();
            this.specialAuthorizationRequestTypeValue = new CVImpl();
            this.specialAuthorizationStatusValue = new List<CV>();
        }
        /**
         * <summary>Business Name: Approved Device Code</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT490001CA.ApprovedDeviceCode.value 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"approvedDeviceCode/value"})]
        public ClinicalDeviceEntity ApprovedDeviceCodeValue {
            get { return (ClinicalDeviceEntity) this.approvedDeviceCodeValue.Value; }
            set { this.approvedDeviceCodeValue.Value = value; }
        }

        /**
         * <summary>Business Name: Approved Drug Code</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT490001CA.ApprovedDrugCode.value 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"approvedDrugCode/value"})]
        public ClinicalDrug ApprovedDrugCodeValue {
            get { return (ClinicalDrug) this.approvedDrugCodeValue.Value; }
            set { this.approvedDrugCodeValue.Value = value; }
        }

        /**
         * <summary>Business Name: Author ID</summary>
         * 
         * <remarks>Relationship: FICR_MT490001CA.AuthorID.id 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"authorID/id"})]
        public Identifier AuthorIDId {
            get { return this.authorIDId.Value; }
            set { this.authorIDId.Value = value; }
        }

        /**
         * <summary>Business Name: Author Name</summary>
         * 
         * <remarks>Relationship: FICR_MT490001CA.AuthorName.value 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"authorName/value"})]
        public PersonName AuthorNameValue {
            get { return this.authorNameValue.Value; }
            set { this.authorNameValue.Value = value; }
        }

        /**
         * <summary>Business Name: Covered Party Birthdate</summary>
         * 
         * <remarks>Relationship: FICR_MT490001CA.CoveredPartyDOB.value 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"coveredPartyDOB/value"})]
        public PlatformDate CoveredPartyDOBValue {
            get { return this.coveredPartyDOBValue.Value; }
            set { this.coveredPartyDOBValue.Value = value; }
        }

        /**
         * <summary>Business Name: Covered Party Gender</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT490001CA.CoveredPartyGender.value 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"coveredPartyGender/value"})]
        public AdministrativeGender CoveredPartyGenderValue {
            get { return (AdministrativeGender) this.coveredPartyGenderValue.Value; }
            set { this.coveredPartyGenderValue.Value = value; }
        }

        /**
         * <summary>Business Name: Covered Party (Patient) Name</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT490001CA.CoveredPartyName.value 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"coveredPartyName/value"})]
        public PersonName CoveredPartyNameValue {
            get { return this.coveredPartyNameValue.Value; }
            set { this.coveredPartyNameValue.Value = value; }
        }

        /**
         * <summary>Business Name: Special Authorization Expiry Date 
         * Range</summary>
         * 
         * <remarks>Relationship: FICR_MT490001CA.ExpiryDateRange.value 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"expiryDateRange/value"})]
        public Interval<PlatformDate> ExpiryDateRangeValue {
            get { return this.expiryDateRangeValue.Value; }
            set { this.expiryDateRangeValue.Value = value; }
        }

        /**
         * <summary>Business Name: Policy Identifier</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT490001CA.PolicyIdentifier.value 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"policyIdentifier/value"})]
        public Identifier PolicyIdentifierValue {
            get { return this.policyIdentifierValue.Value; }
            set { this.policyIdentifierValue.Value = value; }
        }

        /**
         * <summary>Business Name: Requested Device Code</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT490001CA.RequestedDeviceCode.value 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"requestedDeviceCode/value"})]
        public ClinicalDeviceEntity RequestedDeviceCodeValue {
            get { return (ClinicalDeviceEntity) this.requestedDeviceCodeValue.Value; }
            set { this.requestedDeviceCodeValue.Value = value; }
        }

        /**
         * <summary>Business Name: Requested Drug Code</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT490001CA.RequestedDrugCode.value 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"requestedDrugCode/value"})]
        public ClinicalDrug RequestedDrugCodeValue {
            get { return (ClinicalDrug) this.requestedDrugCodeValue.Value; }
            set { this.requestedDrugCodeValue.Value = value; }
        }

        /**
         * <summary>Business Name: Special Authorization Request Type</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT490001CA.SpecialAuthorizationRequestType.value 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"specialAuthorizationRequestType/value"})]
        public ActSpecialAuthorizationCode SpecialAuthorizationRequestTypeValue {
            get { return (ActSpecialAuthorizationCode) this.specialAuthorizationRequestTypeValue.Value; }
            set { this.specialAuthorizationRequestTypeValue.Value = value; }
        }

        /**
         * <summary>Business Name: Special Authorization Status</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT490001CA.SpecialAuthorizationStatus.value 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"specialAuthorizationStatus/value"})]
        public IList<ActStatus> SpecialAuthorizationStatusValue {
            get { return new RawListWrapper<CV, ActStatus>(specialAuthorizationStatusValue, typeof(CVImpl)); }
        }

    }

}