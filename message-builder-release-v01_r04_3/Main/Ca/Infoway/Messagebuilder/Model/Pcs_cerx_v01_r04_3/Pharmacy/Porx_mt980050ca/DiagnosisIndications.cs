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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Porx_mt980050ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: Diagnosis Indications</summary>
     * 
     * <p>Code must be fixed to DX if not using SNOMED</p> <p>Value 
     * is mandatory if not using SNOMED</p> <p>Allows separation of 
     * conditions from symptoms from other forms of indication.</p> 
     * <p>Describes diagnosis-related indications</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT980050CA.ObservationDiagnosis"})]
    public class DiagnosisIndications : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Porx_mt980050ca.IIndications {

        private CD code;
        private ST text;
        private CV value;

        public DiagnosisIndications() {
            this.code = new CDImpl();
            this.text = new STImpl();
            this.value = new CVImpl();
        }
        /**
         * <summary>Business Name: Diagnosis Type</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT980050CA.ObservationDiagnosis.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Identifies this 
         * measurement as a type of diagnosis and is therefore 
         * mandatory. It is set to CD because SNOMED codes may require 
         * post-coordination</p> <p>For SNOMED, the complete diagnosis 
         * appears here. For non-SNOMED this should be a fixed value of 
         * &quot;DX&quot;.</p> <p>Identifies the type of diagnosis</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActCode Code {
            get { return (ActCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Free Form Diagnosis Indication</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT980050CA.ObservationDiagnosis.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Provides greater 
         * flexibility in specifying indication.</p> <p>A free form 
         * description augmenting the specified diagnosis code.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public String Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Business Name: A:Diagnosis Code</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT980050CA.ObservationDiagnosis.value 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Allows 
         * cross-checking the use of a therapy against its indication. 
         * Also allows analysis of best practices, etc. This attribute 
         * is optional because it is not used by SNOMED.</p> <p>A coded 
         * form of the diagnosis that is the reason for the current 
         * action.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public DiagnosisValue Value {
            get { return (DiagnosisValue) this.value.Value; }
            set { this.value.Value = value; }
        }

    }

}