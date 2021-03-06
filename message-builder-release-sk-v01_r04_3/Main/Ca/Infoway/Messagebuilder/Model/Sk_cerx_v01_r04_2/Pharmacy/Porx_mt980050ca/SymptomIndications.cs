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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Porx_mt980050ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: Symptom Indications</summary>
     * 
     * <p>Code must be fixed to SYMPT if not using 
     * SNOMED</p><p>Value is mandatory if not using SNOMED</p> 
     * <p>Code must be fixed to SYMPT if not using 
     * SNOMED</p><p>Value is mandatory if not using SNOMED</p> 
     * <p>Describes symptom-related indications</p> <p>Allows 
     * separation of conditions from symptoms from other forms of 
     * indication.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT980050CA.ObservationSymptom"})]
    public class SymptomIndications : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Porx_mt980050ca.IIndications {

        private CD code;
        private ST text;
        private CV value;

        public SymptomIndications() {
            this.code = new CDImpl();
            this.text = new STImpl();
            this.value = new CVImpl();
        }
        /**
         * <summary>Business Name: Symptom Type</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT980050CA.ObservationSymptom.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Identifies the 
         * category of symptom being communicated.</p> <p>Indicates 
         * that this observation is expressing a symptom, and is 
         * therefore mandatory. It is set to CD because SNOMED codes 
         * may require post-coordination</p> <p>For SNOMED, this will 
         * communicate the full symptom. For non-SNOMED this will be a 
         * fixed value of SYMPT</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActCode Code {
            get { return (ActCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Free Form Symptom Indication</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT980050CA.ObservationSymptom.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>A free form 
         * description to augment the specified symptom.</p> 
         * <p>Provides greater flexibility in specifying 
         * indication.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public String Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Business Name: A:Symptom Code</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT980050CA.ObservationSymptom.value 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>A coded 
         * representation of the symptom that is the reason for the 
         * current therapy.</p> <p>Allows cross-checking the use of a 
         * therapy against its indication. Also allows analysis of best 
         * practices, etc. The attribute is optional because it is not 
         * used for SNOMED.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public SymptomValue Value {
            get { return (SymptomValue) this.value.Value; }
            set { this.value.Value = value; }
        }

    }

}