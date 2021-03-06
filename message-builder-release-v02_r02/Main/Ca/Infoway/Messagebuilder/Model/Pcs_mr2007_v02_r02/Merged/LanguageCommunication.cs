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
 * Author:        $LastChangedBy: jmis $
 * Last modified: $LastChangedDate: 2015-09-15 10:16:43 -0400 (Tue, 15 Sep 2015) $
 * Revision:      $LastChangedRevision: 9773 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>PRPM_MT306011CA.LanguageCommunication: Language of 
     * Communication</summary>
     * 
     * <p>Supports the business requirement to identify languages 
     * used by client for the purposes of communication</p> 
     * <p>Information about what language(s) should be used to 
     * communicate with the focal person can be sent in the 
     * LanguageCommunication class.</p> 
     * PRPA_MT101102CA.LanguageCommunication: Language 
     * Communication <p>Supports the business requirement to 
     * identify languages used by client for the purposes of 
     * communication</p> <p>Information about what language(s) 
     * should be used to communicate with the focal person can be 
     * sent in the LanguageCommunication class.</p> 
     * PRPA_MT101001CA.LanguageCommunication: LanguageCommunication 
     * <p>Supports the business requirement to identify languages 
     * used by client for the purposes of communication</p> 
     * <p>Information about what language(s) should be used to 
     * communicate with the focal person can be sent in the 
     * LanguageCommunication class.</p> 
     * PRPA_MT101002CA.LanguageCommunication: LanguageCommunication 
     * <p>Supports the business requirement to identify languages 
     * used by client for the purposes of communication</p> 
     * <p>Information about what language(s) should be used to 
     * communicate with the focal person can be sent in the 
     * LanguageCommunication class.</p> 
     * PRPA_MT101104CA.LanguageCommunication: LanguageCommunication 
     * <p>Supports the business requirement to identify languages 
     * used by client for the purposes of communication</p> 
     * <p>Information about what language(s) should be used to 
     * communicate with the focal person can be sent in the 
     * LanguageCommunication class.</p> 
     * PRPM_MT303010CA.LanguageCommunication: Language of 
     * Communication <p>Supports the business requirement to 
     * identify languages used by client for the purposes of 
     * communication</p> <p>Information about what language(s) 
     * should be used to communicate with the focal person can be 
     * sent in the LanguageCommunication class.</p> 
     * PRPM_MT301010CA.LanguageCommunication: Language of 
     * Communication <p>Supports the business requirement to 
     * identify languages used by the provider for the purposes of 
     * communication</p> <p>Information about what language(s) 
     * should be used to communicate with the focal person can be 
     * sent in the LanguageCommunication class.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPA_MT101001CA.LanguageCommunication","PRPA_MT101002CA.LanguageCommunication","PRPA_MT101102CA.LanguageCommunication","PRPA_MT101104CA.LanguageCommunication","PRPM_MT301010CA.LanguageCommunication","PRPM_MT303010CA.LanguageCommunication","PRPM_MT306011CA.LanguageCommunication"})]
    public class LanguageCommunication : MessagePartBean {

        private CV languageCode;
        private CV modeCode;
        private CV proficiencyLevelCode;
        private BL preferenceInd;

        public LanguageCommunication() {
            this.languageCode = new CVImpl();
            this.modeCode = new CVImpl();
            this.proficiencyLevelCode = new CVImpl();
            this.preferenceInd = new BLImpl();
        }
        /**
         * <summary>Business Name: LanguageOfCommunicationCode</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * LanguageOfCommunicationCode Relationship: 
         * PRPA_MT101102CA.LanguageCommunication.languageCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute conveying the expected language message elements 
         * are to be transmitted in</p> <p>A code indicating the 
         * language of communication</p> Un-merged Business Name: 
         * LanguageOfCommunicationCode Relationship: 
         * PRPM_MT306011CA.LanguageCommunication.languageCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute conveying the expected language message elements 
         * are to be transmitted in</p> <p>A code indicating the 
         * language of communication</p> Un-merged Business Name: 
         * LanguageOfCommunicationCode Relationship: 
         * PRPA_MT101001CA.LanguageCommunication.languageCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute conveying the expected language message elements 
         * are to be transmitted in.</p> <p>A code indicating the 
         * language of communication</p> Un-merged Business Name: 
         * LanguageOfCommunicationCode Relationship: 
         * PRPA_MT101002CA.LanguageCommunication.languageCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute conveying the expected language message elements 
         * are to be transmitted in</p> <p>A code indicating the 
         * language of communication</p> Un-merged Business Name: 
         * LanguageOfCommunicationCode Relationship: 
         * PRPA_MT101104CA.LanguageCommunication.languageCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute conveying the expected language message elements 
         * are to be transmitted in</p> <p>A code indicating the 
         * language of communication</p> Un-merged Business Name: 
         * LanguageOfCommunicationCode Relationship: 
         * PRPM_MT301010CA.LanguageCommunication.languageCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute conveying the expected language message elements 
         * are to be transmitted in</p> <p>A code indicating the 
         * language of communication</p> Un-merged Business Name: 
         * LanguageOfCommunicationCode Relationship: 
         * PRPM_MT303010CA.LanguageCommunication.languageCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute conveying the expected language message elements 
         * are to be transmitted in</p> <p>A code indicating the 
         * language of communication</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"languageCode"})]
        public HumanLanguage LanguageCode {
            get { return (HumanLanguage) this.languageCode.Value; }
            set { this.languageCode.Value = value; }
        }

        /**
         * <summary>Business Name: LanguageOfCommunicationSkillsCode</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * LanguageOfCommunicationSkillsCode Relationship: 
         * PRPM_MT306011CA.LanguageCommunication.modeCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute provides additional information about the 
         * healthcare provider's communication skills in a given 
         * language</p> <p>Indicates the healthcare provider's ability 
         * to communicate in the indicated language i.e. written, 
         * spoken, read</p> Un-merged Business Name: 
         * LanguageOfCommunicationSkillsCode Relationship: 
         * PRPM_MT301010CA.LanguageCommunication.modeCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute provides additional information about the 
         * healthcare provider's communication skills in a given 
         * language</p> <p>Indicates the healthcare provider's ability 
         * to communicate in the indicated language i.e. written, 
         * spoken, read</p> Un-merged Business Name: 
         * LanguageOfCommunicationSkillsCode Relationship: 
         * PRPM_MT303010CA.LanguageCommunication.modeCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute provides additional information about the 
         * healthcare provider's communication skills in a given 
         * language</p> <p>Indicates the healthcare provider's ability 
         * to communicate in the indicated language i.e. written, 
         * spoken, read</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"modeCode"})]
        public LanguageAbilityMode ModeCode {
            get { return (LanguageAbilityMode) this.modeCode.Value; }
            set { this.modeCode.Value = value; }
        }

        /**
         * <summary>Business Name: 
         * LanguageOfCommunicationProficiencyLevelCode</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * LanguageOfCommunicationProficiencyLevelCode Relationship: 
         * PRPM_MT306011CA.LanguageCommunication.proficiencyLevelCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute provides additional information about the 
         * healthcare provider's communication skills in a given 
         * language</p> <p>Indicates the proficiency level at which 
         * healthcare provider is able to communicate in the indicated 
         * language of communication</p> Un-merged Business Name: 
         * LanguageOfCommunicationProficiencyLevelCode Relationship: 
         * PRPM_MT301010CA.LanguageCommunication.proficiencyLevelCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute provides additional information about the 
         * healthcare provider's communication skills in a given 
         * language</p> <p>Indicates the proficiency level at which 
         * healthcare provider is able to communicate in the indicated 
         * language of communication</p> Un-merged Business Name: 
         * LanguageOfCommunicationProficiencyLevelCode Relationship: 
         * PRPM_MT303010CA.LanguageCommunication.proficiencyLevelCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute provides additional information about the 
         * healthcare provider's communication skills in a given 
         * language</p> <p>Indicates the proficiency level at which 
         * healthcare provider is able to communicate in the indicated 
         * language of communication</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"proficiencyLevelCode"})]
        public LanguageAbilityProficiency ProficiencyLevelCode {
            get { return (LanguageAbilityProficiency) this.proficiencyLevelCode.Value; }
            set { this.proficiencyLevelCode.Value = value; }
        }

        /**
         * <summary>Business Name: 
         * LanguageOfCommunicationPreferenceIndicator</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * LanguageOfCommunicationPreferenceIndicator Relationship: 
         * PRPA_MT101102CA.LanguageCommunication.preferenceInd 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute that supports the business requirement to indicate 
         * the preferred language for all communications.</p> 
         * <p>Indicates the preferred language for all 
         * communications.</p> Un-merged Business Name: 
         * LanguageOfCommunicationPreferenceIndicator Relationship: 
         * PRPM_MT306011CA.LanguageCommunication.preferenceInd 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute that supports the business requirement to indicate 
         * the preferred language for all communications.</p> 
         * <p>Indicates the preferred language for all 
         * communications.</p> Un-merged Business Name: 
         * LanguageOfCommunicationPreferenceIndicator Relationship: 
         * PRPA_MT101001CA.LanguageCommunication.preferenceInd 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute that supports the business requirement to indicate 
         * the preferred language for all communications.</p> 
         * <p>Indicates the preferred language for all 
         * communications.</p> Un-merged Business Name: 
         * LanguageOfCommunicationPreferenceIndicator Relationship: 
         * PRPA_MT101002CA.LanguageCommunication.preferenceInd 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute that supports the business requirement to indicate 
         * the preferred language for all communications.</p> 
         * <p>Indicates the preferred language for all 
         * communications.</p> Un-merged Business Name: 
         * LanguageOfCommunicationPreferenceIndicator Relationship: 
         * PRPA_MT101104CA.LanguageCommunication.preferenceInd 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute that supports the business requirement to indicate 
         * the preferred language for all communications.</p> 
         * <p>Indicates the preferred language for all 
         * communications.</p> Un-merged Business Name: 
         * LanguageOfCommunicationPreferenceIndicator Relationship: 
         * PRPM_MT301010CA.LanguageCommunication.preferenceInd 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute that supports the business requirement to indicate 
         * the preferred language for all communications.</p> 
         * <p>Indicates the preferred language for all 
         * communications.</p> Un-merged Business Name: 
         * LanguageOfCommunicationPreferenceIndicator Relationship: 
         * PRPM_MT303010CA.LanguageCommunication.preferenceInd 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute that supports the business requirement to indicate 
         * the preferred language for all communications.</p> 
         * <p>Indicates the preferred language for all 
         * communications.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"preferenceInd"})]
        public bool? PreferenceInd {
            get { return this.preferenceInd.Value; }
            set { this.preferenceInd.Value = value; }
        }

    }

}