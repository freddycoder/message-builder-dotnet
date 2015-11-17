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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt306050ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Domainvalue;
    using System;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"PRPM_MT306050CA.ParameterList"})]
    public class ParameterList : MessagePartBean {

        private IList<AD> addressValue;
        private CV administrativeGenderValue;
        private IList<CV> assignedRoleTypeValue;
        private REAL confidenceValue;
        private TS dOBValue;
        private IList<CV> jurisdictionValue;
        private PN nameValue;
        private II providerIDValue;
        private IList<CV> roleClassValue;
        private IList<CV> roleTypeValue;

        public ParameterList() {
            this.addressValue = new List<AD>();
            this.administrativeGenderValue = new CVImpl();
            this.assignedRoleTypeValue = new List<CV>();
            this.confidenceValue = new REALImpl();
            this.dOBValue = new TSImpl();
            this.jurisdictionValue = new List<CV>();
            this.nameValue = new PNImpl();
            this.providerIDValue = new IIImpl();
            this.roleClassValue = new List<CV>();
            this.roleTypeValue = new List<CV>();
        }
        /**
         * <summary>Business Name: Healthcare Provider Role Address</summary>
         * 
         * <remarks>Relationship: PRPM_MT306050CA.Address.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>The address for the provider when playing 
         * the role of healthcare provider.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"address/value"})]
        public IList<PostalAddress> AddressValue {
            get { return new RawListWrapper<AD, PostalAddress>(addressValue, typeof(ADImpl)); }
        }

        /**
         * <summary>Business Name: Principal Person Gender</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT306050CA.AdministrativeGender.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>The principal person's gender.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"administrativeGender/value"})]
        public AdministrativeGender AdministrativeGenderValue {
            get { return (AdministrativeGender) this.administrativeGenderValue.Value; }
            set { this.administrativeGenderValue.Value = value; }
        }

        /**
         * <summary>Business Name: Assigned Role Type Value</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT306050CA.AssignedRoleType.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>The code identifying the specific functional 
         * role.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"assignedRoleType/value"})]
        public IList<AssignedRoleType> AssignedRoleTypeValue {
            get { return new RawListWrapper<CV, AssignedRoleType>(assignedRoleTypeValue, typeof(CVImpl)); }
        }

        /**
         * <summary>Business Name: Confidence Value</summary>
         * 
         * <remarks>Relationship: PRPM_MT306050CA.Confidence.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute to provide information about success of query</p> 
         * <p>A real number value indicating the confidence of the 
         * query with regard to finding the intended target provider 
         * i.e. the value would be the computed confidence value.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidence/value"})]
        public BigDecimal ConfidenceValue {
            get { return this.confidenceValue.Value; }
            set { this.confidenceValue.Value = value; }
        }

        /**
         * <summary>Business Name: Principal Person Date of Birth</summary>
         * 
         * <remarks>Relationship: PRPM_MT306050CA.DOB.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>The principal person's date of birth.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"dOB/value"})]
        public PlatformDate DOBValue {
            get { return this.dOBValue.Value; }
            set { this.dOBValue.Value = value; }
        }

        /**
         * <summary>Business Name: Jurisdiction Type</summary>
         * 
         * <remarks>Relationship: PRPM_MT306050CA.Jurisdiction.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports the validation and identification of the 
         * healthcare provider</p> <p>A character value that represents 
         * the Canadian provincial or territorial geographical area 
         * within which the Provider is operating.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"jurisdiction/value"})]
        public IList<JurisdictionTypeCode> JurisdictionValue {
            get { return new RawListWrapper<CV, JurisdictionTypeCode>(jurisdictionValue, typeof(CVImpl)); }
        }

        /**
         * <summary>Business Name: Healthcare Provider Role Name</summary>
         * 
         * <remarks>Relationship: PRPM_MT306050CA.Name.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>The provider's name pertaining to the 
         * specific healthcare provider role.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"name/value"})]
        public PersonName NameValue {
            get { return this.nameValue.Value; }
            set { this.nameValue.Value = value; }
        }

        /**
         * <summary>Business Name: Healthcare Provider Role 
         * Identification</summary>
         * 
         * <remarks>Relationship: PRPM_MT306050CA.ProviderID.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>A unique identifier for a provider in a 
         * specific healthcare role.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"providerID/value"})]
        public Identifier ProviderIDValue {
            get { return this.providerIDValue.Value; }
            set { this.providerIDValue.Value = value; }
        }

        /**
         * <summary>Business Name: Role Class Value</summary>
         * 
         * <remarks>Relationship: PRPM_MT306050CA.RoleClass.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute where queried upon</p> <p>Indicates Role Class 
         * being queried upon</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"roleClass/value"})]
        public IList<x_RoleClassAssignedQualifiedProvider> RoleClassValue {
            get { return new RawListWrapper<CV, x_RoleClassAssignedQualifiedProvider>(roleClassValue, typeof(CVImpl)); }
        }

        /**
         * <summary>Business Name: Healthcare Provider Role Type</summary>
         * 
         * <remarks>Relationship: PRPM_MT306050CA.RoleType.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>The code identifying the specific healthcare 
         * provider role.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"roleType/value"})]
        public IList<HealthcareProviderRoleType> RoleTypeValue {
            get { return new RawListWrapper<CV, HealthcareProviderRoleType>(roleTypeValue, typeof(CVImpl)); }
        }

    }

}