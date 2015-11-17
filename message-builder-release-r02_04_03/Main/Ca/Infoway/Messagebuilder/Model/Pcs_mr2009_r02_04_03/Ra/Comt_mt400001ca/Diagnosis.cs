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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Ra.Comt_mt400001ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>Business Name: Diagnosis</summary>
     * 
     * <p>Allows masking of items related to a particular medical 
     * condition.</p> <p>Conveys information about a diagnosis to 
     * be masked</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COMT_MT400001CA.Diagnosis"})]
    public class Diagnosis : MessagePartBean {

        private CV code;
        private CV value;

        public Diagnosis() {
            this.code = new CVImpl();
            this.value = new CVImpl();
        }
        /**
         * <summary>Business Name: A:Diagnosis Type</summary>
         * 
         * <remarks>Relationship: COMT_MT400001CA.Diagnosis.code 
         * Conformance/Cardinality: MANDATORY (1) <p>If code is SNOMED, 
         * value must not be specified. Otherwise value is mandatory 
         * and code must be 'DX'</p> <p>Needed to convey the diagnosis 
         * information to be masked, and attribute is therefore 
         * mandatory.</p> <p>Used to indicate that this observation is 
         * a diagnosis, and for SNOMED, provides details of what the 
         * diagnosis is.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActCode Code {
            get { return (ActCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: B:Diagnosis</summary>
         * 
         * <remarks>Relationship: COMT_MT400001CA.Diagnosis.value 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Allows masking of 
         * all records (prescriptions, dispenses, encounters, lab 
         * tests, etc.) associated with the specified diagnosis. This 
         * element is optional because it is not used for SNOMED.</p> 
         * <p>The diagnosis whose associated records should be 
         * masked.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public DiagnosisValue Value {
            get { return (DiagnosisValue) this.value.Value; }
            set { this.value.Value = value; }
        }

    }

}