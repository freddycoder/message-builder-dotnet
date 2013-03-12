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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Coct_mt120402ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>Business Name: Diagnosis Indications</summary>
     * 
     * <p>Allows separation of conditions from symptoms from other 
     * forms of indication.</p> <p>Describes diagnosis-related 
     * indications</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT120402CA.ObservationCondition"})]
    public class DiagnosisIndications : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Coct_mt120402ca.IIndications {

        private CV code;
        private CD value;

        public DiagnosisIndications() {
            this.code = new CVImpl();
            this.value = new CDImpl();
        }
        /**
         * <summary>Business Name: Diagnosis Type</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT120402CA.ObservationCondition.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Identifies this 
         * measurement as a type of diagnosis and is therefore 
         * mandatory.</p> <p>Identifies the type of condition described 
         * (diagnosis or indication)</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActCode Code {
            get { return (ActCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: A:Diagnosis Code</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT120402CA.ObservationCondition.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows 
         * cross-checking the use of a therapy against its indication. 
         * Also allows analysis of best practices, etc. This is the 
         * attribute that actually identifies the indication and is 
         * therefore mandatory.</p><p> <i>This element makes use of the 
         * CD datatype because some terminologies used for the domain 
         * require use of modifiers.</i> </p> <p>A coded form of the 
         * diagnosis that is the reason for the current action.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public DiagnosisValue Value {
            get { return (DiagnosisValue) this.value.Value; }
            set { this.value.Value = value; }
        }

    }

}