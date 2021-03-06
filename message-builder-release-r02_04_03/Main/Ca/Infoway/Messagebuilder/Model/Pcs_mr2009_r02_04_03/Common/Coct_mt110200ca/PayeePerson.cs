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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt110200ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: Payee Person</summary>
     * 
     * <p>Person receiving payment from Payor</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT110200CA.PayeePerson"})]
    public class PayeePerson : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt110200ca.IPayeeChoice {

        private PN name;
        private AD addr;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt110200ca.PayeeRelationshipRole asRole;
        private CV payeeLanguageLanguageCode;
        private CV payeeLanguageModeCode;
        private BL payeeLanguagePreferenceInd;

        public PayeePerson() {
            this.name = new PNImpl();
            this.addr = new ADImpl();
            this.payeeLanguageLanguageCode = new CVImpl();
            this.payeeLanguageModeCode = new CVImpl();
            this.payeeLanguagePreferenceInd = new BLImpl();
        }
        /**
         * <summary>Business Name: payee name</summary>
         * 
         * <remarks>Relationship: COCT_MT110200CA.PayeePerson.name 
         * Conformance/Cardinality: MANDATORY (1) <p>name of person who 
         * is the payee</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"name"})]
        public PersonName Name {
            get { return this.name.Value; }
            set { this.name.Value = value; }
        }

        /**
         * <summary>Business Name: payee address</summary>
         * 
         * <remarks>Relationship: COCT_MT110200CA.PayeePerson.addr 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"addr"})]
        public PostalAddress Addr {
            get { return this.addr.Value; }
            set { this.addr.Value = value; }
        }

        /**
         * <summary>Relationship: COCT_MT110200CA.PayeeChoice.asRole</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"asRole"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt110200ca.PayeeRelationshipRole AsRole {
            get { return this.asRole; }
            set { this.asRole = value; }
        }

        /**
         * <summary>Business Name: Payee Person Language</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT110200CA.PayeeLanguage.languageCode 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"payeeLanguage/languageCode"})]
        public HumanLanguage PayeeLanguageLanguageCode {
            get { return (HumanLanguage) this.payeeLanguageLanguageCode.Value; }
            set { this.payeeLanguageLanguageCode.Value = value; }
        }

        /**
         * <summary>Business Name: Language of Communication</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT110200CA.PayeeLanguage.modeCode 
         * Conformance/Cardinality: MANDATORY (1) <p>A value presenting 
         * the method of expression of the language.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"payeeLanguage/modeCode"})]
        public LanguageAbilityMode PayeeLanguageModeCode {
            get { return (LanguageAbilityMode) this.payeeLanguageModeCode.Value; }
            set { this.payeeLanguageModeCode.Value = value; }
        }

        /**
         * <summary>Business Name: Preferred Language Indicator</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT110200CA.PayeeLanguage.preferenceInd 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"payeeLanguage/preferenceInd"})]
        public bool? PayeeLanguagePreferenceInd {
            get { return this.payeeLanguagePreferenceInd.Value; }
            set { this.payeeLanguagePreferenceInd.Value = value; }
        }

    }

}