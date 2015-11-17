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
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Domainvalue;


    /**
     * <summary>Business Name: Diagnosis Indications</summary>
     * 
     * <p>Allows separation of conditions from symptoms from other 
     * forms of indication.</p> <p>Describes diagnosis-related 
     * indications</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT120402CA.ObservationProblem"})]
    public class DiagnosisIndications : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt120402ca.IIndications {

        private CV code;
        private CD value;

        public DiagnosisIndications() {
            this.code = new CVImpl();
            this.value = new CDImpl();
        }
        /**
         * <summary>Business Name: Problem Type</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT120402CA.ObservationProblem.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Identifies this 
         * measurement as a type of diagnosis and is therefore 
         * mandatory.</p> <p>Identifies the type of problem 
         * described.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ProblemType Code {
            get { return (ProblemType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: A:Problem Code</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT120402CA.ObservationProblem.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows 
         * cross-checking the use of a therapy against its indication. 
         * Also allows analysis of best practices, etc. This is the 
         * attribute that actually identifies the indication and is 
         * therefore mandatory.</p><p>[UseCommon CD]</p> <p>A coded 
         * form of the problem that is the reason for the current 
         * action.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public ProblemValue Value {
            get { return (ProblemValue) this.value.Value; }
            set { this.value.Value = value; }
        }

    }

}