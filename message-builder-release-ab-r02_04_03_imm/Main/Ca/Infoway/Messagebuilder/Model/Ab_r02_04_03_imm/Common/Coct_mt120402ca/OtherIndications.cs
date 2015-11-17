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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt120402ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: Other indications</summary>
     * 
     * <p>Must have at least one of code or text</p> <p>Allows 
     * separation of conditions from symptoms from other forms of 
     * indication.</p> <p>Describes indications that are not 
     * diagnosis or symptom-related (e.g. contrast agents)</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT120402CA.OtherIndication"})]
    public class OtherIndications : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt120402ca.IIndications {

        private CV code;
        private ST text;

        public OtherIndications() {
            this.code = new CVImpl();
            this.text = new STImpl();
        }
        /**
         * <summary>Business Name: Other Indication</summary>
         * 
         * <remarks>Relationship: COCT_MT120402CA.OtherIndication.code 
         * Conformance/Cardinality: REQUIRED (0-1) <p>EPHS: vocab 
         * proposal needed for simple concepts of i) sign or symptom 
         * related to investigation disease ii) sign or symptom not 
         * related to investigation disease. EPHS: act.code value 
         * needed for encounter reason; reason for treatment; 
         * immunization interpretation reason</p> <p>Allows for coded 
         * representation of a non-condition based indication such as 
         * administration of a contrast agent for a lab test.</p> <p>A 
         * code indicating some other action which is the reason for a 
         * therapy.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActNonConditionIndicationCode Code {
            get { return (ActNonConditionIndicationCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Other indication ad-hoc description</summary>
         * 
         * <remarks>Relationship: COCT_MT120402CA.OtherIndication.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Provides ability 
         * to describe indication without labeling it a diagnosis or 
         * symptom. Attribute as free form text is the only information 
         * allowed.</p> <p>A textual description of an indication not 
         * meant to be either diagnosis or symptom.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public String Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

    }

}