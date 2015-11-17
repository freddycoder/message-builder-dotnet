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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Ficr_mt490002ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT490002CA.ParameterList"})]
    public class ParameterList : MessagePartBean {

        private TS coveredPartyDOBValue;
        private CV coveredPartyGenderValue;
        private PN coveredPartyNameValue;
        private II policyIdentifierValue;
        private II specialAuthorizationRequestIDValue;

        public ParameterList() {
            this.coveredPartyDOBValue = new TSImpl();
            this.coveredPartyGenderValue = new CVImpl();
            this.coveredPartyNameValue = new PNImpl();
            this.policyIdentifierValue = new IIImpl();
            this.specialAuthorizationRequestIDValue = new IIImpl();
        }
        /**
         * <summary>Business Name: Covered Party Birthdate</summary>
         * 
         * <remarks>Relationship: FICR_MT490002CA.CoveredPartyDOB.value 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"coveredPartyDOB/value"})]
        public PlatformDate CoveredPartyDOBValue {
            get { return this.coveredPartyDOBValue.Value; }
            set { this.coveredPartyDOBValue.Value = value; }
        }

        /**
         * <summary>Business Name: Gender of covered party</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT490002CA.CoveredPartyGender.value 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"coveredPartyGender/value"})]
        public AdministrativeGender CoveredPartyGenderValue {
            get { return (AdministrativeGender) this.coveredPartyGenderValue.Value; }
            set { this.coveredPartyGenderValue.Value = value; }
        }

        /**
         * <summary>Business Name: Covered Party Name</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT490002CA.CoveredPartyName.value 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"coveredPartyName/value"})]
        public PersonName CoveredPartyNameValue {
            get { return this.coveredPartyNameValue.Value; }
            set { this.coveredPartyNameValue.Value = value; }
        }

        /**
         * <summary>Business Name: Policy Identifier</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT490002CA.PolicyIdentifier.value 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"policyIdentifier/value"})]
        public Identifier PolicyIdentifierValue {
            get { return this.policyIdentifierValue.Value; }
            set { this.policyIdentifierValue.Value = value; }
        }

        /**
         * <summary>Business Name: Special Authorization Request ID</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT490002CA.SpecialAuthorizationRequestID.value 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"specialAuthorizationRequestID/value"})]
        public Identifier SpecialAuthorizationRequestIDValue {
            get { return this.specialAuthorizationRequestIDValue.Value; }
            set { this.specialAuthorizationRequestIDValue.Value = value; }
        }

    }

}