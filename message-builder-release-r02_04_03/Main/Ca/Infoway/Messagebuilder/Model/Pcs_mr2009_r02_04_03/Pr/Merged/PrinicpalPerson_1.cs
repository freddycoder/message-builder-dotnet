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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Pr.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: PrinicpalPerson</summary>
     * 
     * <remarks>PRPM_MT303010CA.PrincipalPerson: Prinicpal Person 
     * <p>Provides additional information about the person playing 
     * the role of Healthcare Provider</p> <p>Identification of 
     * playing entity is required (0..1) to support the case in 
     * which information directly related to the playing party is 
     * not needed.</p> PRPM_MT301010CA.PrincipalPerson: Prinicpal 
     * Person <p>Provides additional information about the person 
     * playing the role of Healthcare Provider</p> 
     * <p>Identification of playing entity is required (0..1) to 
     * support the case in which information directly related to 
     * the playing party is not needed.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPM_MT301010CA.PrincipalPerson","PRPM_MT303010CA.PrincipalPerson"})]
    public class PrinicpalPerson_1 : MessagePartBean {

        private II id;
        private LIST<PN, PersonName> name;
        private CV administrativeGenderCode;
        private TS birthTime;
        private BL deceasedInd;
        private TS deceasedTime;
        private AD birthplaceAddr;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.LanguageCommunication> languageCommunication;

        public PrinicpalPerson_1() {
            this.id = new IIImpl();
            this.name = new LISTImpl<PN, PersonName>(typeof(PNImpl));
            this.administrativeGenderCode = new CVImpl();
            this.birthTime = new TSImpl();
            this.deceasedInd = new BLImpl();
            this.deceasedTime = new TSImpl();
            this.birthplaceAddr = new ADImpl();
            this.languageCommunication = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.LanguageCommunication>();
        }
        /**
         * <summary>Business Name: PrincipalPersonAggregateIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * PrincipalPersonAggregateIdentifier Relationship: 
         * PRPM_MT303010CA.PrincipalPerson.id Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Required attribute supports the 
         * identification of the healthcare provider</p> <p>A unique 
         * identifier for the person who may play various healthcare 
         * provider roles. This identifier is specific to the person 
         * not their roles.</p> Un-merged Business Name: 
         * PrincipalPersonAggregateIdentifier Relationship: 
         * PRPM_MT301010CA.PrincipalPerson.id Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Required attribute supports the 
         * identification of the healthcare provider</p> <p>A unique 
         * identifier for the person who may play various healthcare 
         * provider roles. This identifier is specific to the person 
         * not their roles.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: PrincipalPersonName</summary>
         * 
         * <remarks>Un-merged Business Name: PrincipalPersonName 
         * Relationship: PRPM_MT303010CA.PrincipalPerson.name 
         * Conformance/Cardinality: REQUIRED (0-5) <p>Required 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>If Principal Person is included in the 
         * message, then Person Name Must Exist.</p> <p>The persons 
         * name independent of any role they may play.</p> Un-merged 
         * Business Name: PrincipalPersonName Relationship: 
         * PRPM_MT301010CA.PrincipalPerson.name 
         * Conformance/Cardinality: REQUIRED (0-5) <p>13, STF:3; 
         * ROL:4:2-7,10,16,21</p> <p>Required attribute supports the 
         * identification of the healthcare provider</p> <p>If 
         * Principal Person is included in the message, then Prinicpal 
         * Person Name Must Exist.</p> <p>The persons name independent 
         * of any role they may play.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"name"})]
        public IList<PersonName> Name {
            get { return this.name.RawList(); }
        }

        /**
         * <summary>Business Name: PrincipalPersonGender</summary>
         * 
         * <remarks>Un-merged Business Name: PrincipalPersonGender 
         * Relationship: 
         * PRPM_MT303010CA.PrincipalPerson.administrativeGenderCode 
         * Conformance/Cardinality: POPULATED (1) <p>Mandatory 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>If Principal Person is included in the 
         * message, then Person Gender is Expected to Exist.</p> <p>The 
         * principal persons gender.</p> Un-merged Business Name: 
         * PrincipalPersonGender Relationship: 
         * PRPM_MT301010CA.PrincipalPerson.administrativeGenderCode 
         * Conformance/Cardinality: MANDATORY (1) <p>STF.5</p> 
         * <p>Mandatory attribute supports the identification of the 
         * healthcare provider</p> <p>If Principal Person is included 
         * in the message, then Person Gender is Expected to Exist.</p> 
         * <p>The principal persons gender.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"administrativeGenderCode"})]
        public AdministrativeGender AdministrativeGenderCode {
            get { return (AdministrativeGender) this.administrativeGenderCode.Value; }
            set { this.administrativeGenderCode.Value = value; }
        }

        /**
         * <summary>Business Name: PrincipalPersonDateOfBirth</summary>
         * 
         * <remarks>Un-merged Business Name: PrincipalPersonDateOfBirth 
         * Relationship: PRPM_MT303010CA.PrincipalPerson.birthTime 
         * Conformance/Cardinality: POPULATED (1) <p>Populated 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>If Principal Person is included in the 
         * message, then Prinicpal Person Date of Birth is Expected to 
         * Exist.</p> <p>The principal persons date of birth.</p> 
         * Un-merged Business Name: PrincipalPersonDateOfBirth 
         * Relationship: PRPM_MT301010CA.PrincipalPerson.birthTime 
         * Conformance/Cardinality: POPULATED (1) <p>Populated 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>If Principal Person is included in the 
         * message, then Prinicpal Person Date of Birth is Expected to 
         * Exist.</p> <p>The principal persons date of birth.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"birthTime"})]
        public PlatformDate BirthTime {
            get { return this.birthTime.Value; }
            set { this.birthTime.Value = value; }
        }

        /**
         * <summary>Business Name: PrincipalPersonDeceasedIndicator</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * PrincipalPersonDeceasedIndicator Relationship: 
         * PRPM_MT303010CA.PrincipalPerson.deceasedInd 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>An indication that the principal person is 
         * deceased.</p> Un-merged Business Name: 
         * PrincipalPersonDeceasedIndicator Relationship: 
         * PRPM_MT301010CA.PrincipalPerson.deceasedInd 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>An indication that the principal person is 
         * deceased.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"deceasedInd"})]
        public bool? DeceasedInd {
            get { return this.deceasedInd.Value; }
            set { this.deceasedInd.Value = value; }
        }

        /**
         * <summary>Business Name: PrincipalPersonDeceasedDate</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * PrincipalPersonDeceasedDate Relationship: 
         * PRPM_MT303010CA.PrincipalPerson.deceasedTime 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Attribute 
         * supports verification of death from official source such as 
         * Vital Statistics.</p><p>Optional attribute in order to meet 
         * jurisdictional legislation which does not allow the sharing 
         * of this information.</p> <p>The date and time that a 
         * healthcare provider's death occurred.</p> Un-merged Business 
         * Name: PrincipalPersonDeceasedDate Relationship: 
         * PRPM_MT301010CA.PrincipalPerson.deceasedTime 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Attribute 
         * supports verification of death from official source such as 
         * Vital Statistics.</p><p>Optional attribute in order to meet 
         * jurisdictional legislation which does not allow the sharing 
         * of this information.</p> <p>The date and time that a 
         * healthcare provider's death occurred.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"deceasedTime"})]
        public PlatformDate DeceasedTime {
            get { return this.deceasedTime.Value; }
            set { this.deceasedTime.Value = value; }
        }

        /**
         * <summary>Business Name: BirthplaceAddress</summary>
         * 
         * <remarks>Un-merged Business Name: BirthplaceAddress 
         * Relationship: PRPM_MT303010CA.Birthplace.addr 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>If Birthplace is included in the message, 
         * then Address is Expected to Exist.</p> <p>Principal person's 
         * address at time of birth</p> Un-merged Business Name: 
         * BirthplaceAddress Relationship: 
         * PRPM_MT301010CA.Birthplace.addr Conformance/Cardinality: 
         * MANDATORY (1) <p>Mandatory attribute supports the 
         * identification of the healthcare provider</p> <p>If 
         * Birthplace is included in the message, then Address is 
         * Expected to Exist.</p> <p>Principal person's address at time 
         * of birth</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"birthplace/addr"})]
        public PostalAddress BirthplaceAddr {
            get { return this.birthplaceAddr.Value; }
            set { this.birthplaceAddr.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT303010CA.PrincipalPerson.languageCommunication 
         * Conformance/Cardinality: REQUIRED (0-10) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PRPM_MT301010CA.PrincipalPerson.languageCommunication 
         * Conformance/Cardinality: REQUIRED (0-10)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"languageCommunication"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.LanguageCommunication> LanguageCommunication {
            get { return this.languageCommunication; }
        }

    }

}