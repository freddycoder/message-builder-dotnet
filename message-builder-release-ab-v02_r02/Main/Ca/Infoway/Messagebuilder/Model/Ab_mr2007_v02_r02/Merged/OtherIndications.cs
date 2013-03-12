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
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: OtherIndications</summary>
     * 
     * <remarks>COCT_MT120402CA.OtherIndication: Other indications 
     * <p>Must have at least one of code or text</p> <p>Describes 
     * indications that are not diagnosis or symptom-related (e.g. 
     * contrast agents)</p> <p>Allows separation of conditions from 
     * symptoms from other forms of indication.</p> 
     * PORX_MT980050CA.OtherIndication: Other indications <p>Must 
     * have at least one of code or text</p> <p>Describes 
     * indications that are not diagnosis or symptom-related (e.g. 
     * contrast agents)</p> <p>Allows separation of conditions from 
     * symptoms from other forms of indication.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT120402CA.OtherIndication","PORX_MT980050CA.OtherIndication"})]
    public class OtherIndications : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.IIndications {

        private CV code;
        private ST text;

        public OtherIndications() {
            this.code = new CVImpl();
            this.text = new STImpl();
        }
        /**
         * <summary>Business Name: OtherIndication</summary>
         * 
         * <remarks>Un-merged Business Name: OtherIndication 
         * Relationship: COCT_MT120402CA.OtherIndication.code 
         * Conformance/Cardinality: REQUIRED (0-1) <p>A code indicating 
         * some other action which is the reason for a therapy.</p> 
         * <p>EPHS: vocab proposal needed for simple concepts of i) 
         * sign or symptom related to investigation disease ii) sign or 
         * symptom not related to investigation disease. EPHS: act.code 
         * value needed for encounter reason; reason for treatment; 
         * immunization interpretation reason</p> <p>Allows for coded 
         * representation of a non-condition based indication such as 
         * administration of a contrast agent for a lab test.</p> 
         * Un-merged Business Name: OtherIndication Relationship: 
         * PORX_MT980050CA.OtherIndication.code 
         * Conformance/Cardinality: REQUIRED (0-1) <p>A code indicating 
         * some other action which is the reason for a therapy.</p> 
         * <p>Allows for coded representation of a non-condition based 
         * indication such as administration of a contrast agent for a 
         * lab test.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActNonConditionIndicationCode Code {
            get { return (ActNonConditionIndicationCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: OtherIndicationAdHocDescription</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * OtherIndicationAdHocDescription Relationship: 
         * COCT_MT120402CA.OtherIndication.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>A textual 
         * description of an indication not meant to be either 
         * diagnosis or symptom.</p> <p>Provides ability to describe 
         * indication without labeling it a diagnosis or symptom. 
         * Attribute as free form text is the only information 
         * allowed.</p> Un-merged Business Name: 
         * OtherIndicationAdHocDescription Relationship: 
         * PORX_MT980050CA.OtherIndication.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>A textual 
         * description of an indication not meant to be either 
         * diagnosis or symptom.</p> <p>Provides ability to describe 
         * indication without labeling it a diagnosis or symptom. 
         * Attribute as free form text is the only information 
         * allowed.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public String Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

    }

}