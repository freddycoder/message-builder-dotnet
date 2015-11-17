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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Common.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Domainvalue;
    using System;


    /**
     * <summary>Business Name: Diagnosis</summary>
     * 
     * <remarks>COCT_MT290000CA.Diagnosis: Diagnosis <p>More than 1 
     * diagnosis may be specified to justify the performing of a 
     * particular service.</p><p>A specific diagnosis code must 
     * always be specified, and may be supplemented by descriptive 
     * text.</p><p>For some services (e.g. provider's review of a 
     * file), the diagnosis may not be known.</p> <p>Diagnosis</p> 
     * COCT_MT490000CA.Diagnosis: Diagnosis <p>Patient 
     * Diagnosis</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT290000CA.Diagnosis","COCT_MT490000CA.Diagnosis"})]
    public class Diagnosis : MessagePartBean {

        private CV code;
        private ST text;
        private CV value;

        public Diagnosis() {
            this.code = new CVImpl();
            this.text = new STImpl();
            this.value = new CVImpl();
        }
        /**
         * <summary>Un-merged Business Name: DiagnosisType</summary>
         * 
         * <remarks>Relationship: COCT_MT290000CA.Diagnosis.code 
         * Conformance/Cardinality: MANDATORY (1) <p>admit, 
         * intermediate, discharge diagnosis</p> Un-merged Business 
         * Name: DiagnosisCode Relationship: 
         * COCT_MT490000CA.Diagnosis.code Conformance/Cardinality: 
         * MANDATORY (1) <p>ObservationDiagnosis Type</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActDiagnosisCode Code {
            get { return (ActDiagnosisCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: DiagnosisDescription</summary>
         * 
         * <remarks>Un-merged Business Name: DiagnosisDescription 
         * Relationship: COCT_MT290000CA.Diagnosis.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Can be used to 
         * supplement a diagnostic code</p> <p>Can be used to 
         * supplement a diagnostic code</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public String Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Business Name: DiagnosisValue</summary>
         * 
         * <remarks>Un-merged Business Name: DiagnosisValue 
         * Relationship: COCT_MT290000CA.Diagnosis.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Diagnosis Code eg. 
         * ICD-10-CA code.</p> Un-merged Business Name: DiagnosisValue 
         * Relationship: COCT_MT490000CA.Diagnosis.value 
         * Conformance/Cardinality: MANDATORY (1) <p>coded Value 
         * denoting diagnosis</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public DiagnosisValue Value {
            get { return (DiagnosisValue) this.value.Value; }
            set { this.value.Value = value; }
        }

    }

}