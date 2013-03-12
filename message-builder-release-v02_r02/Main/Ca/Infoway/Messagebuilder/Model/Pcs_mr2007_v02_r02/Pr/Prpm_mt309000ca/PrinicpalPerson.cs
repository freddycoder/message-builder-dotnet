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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pr.Prpm_mt309000ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Prinicpal Person</summary>
     * 
     * <p>Provides additional information about the person playing 
     * the role of Healthcare Provider</p> <p>Identification of 
     * playing entity is required (0..1) to support the case in 
     * which information directly related to the playing party is 
     * not needed.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPM_MT309000CA.PrincipalPerson"})]
    public class PrinicpalPerson : MessagePartBean {

        private SET<II, Identifier> id;
        private LIST<PN, PersonName> name;
        private CV administrativeGenderCode;
        private TS birthTime;
        private BL deceasedInd;
        private TS deceasedTime;
        private AD birthplaceAddr;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pr.Prpm_mt309000ca.LanguageOfCommunication> languageCommunication;

        public PrinicpalPerson() {
            this.id = new SETImpl<II, Identifier>(typeof(IIImpl));
            this.name = new LISTImpl<PN, PersonName>(typeof(PNImpl));
            this.administrativeGenderCode = new CVImpl();
            this.birthTime = new TSImpl();
            this.deceasedInd = new BLImpl();
            this.deceasedTime = new TSImpl();
            this.birthplaceAddr = new ADImpl();
            this.languageCommunication = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pr.Prpm_mt309000ca.LanguageOfCommunication>();
        }
        /**
         * <summary>Business Name: Principal Person Aggregate 
         * Identifier</summary>
         * 
         * <remarks>Relationship: PRPM_MT309000CA.PrincipalPerson.id 
         * Conformance/Cardinality: REQUIRED (0-5) <p>Required 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>A unique identifier for the person who may 
         * play various healthcare provider roles. This identifier is 
         * specific to the person not their roles.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public ICollection<Identifier> Id {
            get { return this.id.RawSet(); }
        }

        /**
         * <summary>Business Name: Principal Person Name</summary>
         * 
         * <remarks>Relationship: PRPM_MT309000CA.PrincipalPerson.name 
         * Conformance/Cardinality: REQUIRED (0-5) <p>Required 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>If Principal Person is included in the 
         * message, then Person Name Must Exist.</p> <p>The persons 
         * name independent of any role they may play.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"name"})]
        public IList<PersonName> Name {
            get { return this.name.RawList(); }
        }

        /**
         * <summary>Business Name: Principal Person Gender</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT309000CA.PrincipalPerson.administrativeGenderCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>If Principal Person is included in the 
         * message, then Person Gender is Expected to Exist.</p> <p>The 
         * principal persons gender.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"administrativeGenderCode"})]
        public AdministrativeGender AdministrativeGenderCode {
            get { return (AdministrativeGender) this.administrativeGenderCode.Value; }
            set { this.administrativeGenderCode.Value = value; }
        }

        /**
         * <summary>Business Name: Principal Person Date of Birth</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT309000CA.PrincipalPerson.birthTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
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
         * <summary>Business Name: Principal Person Deceased Indicator</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT309000CA.PrincipalPerson.deceasedInd 
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
         * <summary>Business Name: Principal Person Deceased Date</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT309000CA.PrincipalPerson.deceasedTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute supports verification of death from official 
         * source such as Vital Statistics.</p> <p>The date and time 
         * that a healthcare provider's death occurred.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"deceasedTime"})]
        public PlatformDate DeceasedTime {
            get { return this.deceasedTime.Value; }
            set { this.deceasedTime.Value = value; }
        }

        /**
         * <summary>Business Name: Birthplace Address</summary>
         * 
         * <remarks>Relationship: PRPM_MT309000CA.Birthplace.addr 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>If Birthplace is included in the message, 
         * then Address is Expected to Exist.</p> <p>Principal person's 
         * address at time of birth</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"birthplace/addr"})]
        public PostalAddress BirthplaceAddr {
            get { return this.birthplaceAddr.Value; }
            set { this.birthplaceAddr.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PRPM_MT309000CA.PrincipalPerson.languageCommunication</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-10)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"languageCommunication"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pr.Prpm_mt309000ca.LanguageOfCommunication> LanguageCommunication {
            get { return this.languageCommunication; }
        }

    }

}