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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT010110CA.ProcedureRequest","PORX_MT020060CA.ProcedureRequest","PORX_MT060010CA.ProcedureRequest","PORX_MT060040CA.ProcedureRequest","PORX_MT060060CA.ProcedureRequest"})]
    public class ProcedureRequest : MessagePartBean {

        private ST text;

        public ProcedureRequest() {
            this.text = new STImpl();
        }
        /**
         * <summary>Business Name: UsageInstructions</summary>
         * 
         * <remarks>Un-merged Business Name: UsageInstructions 
         * Relationship: PORX_MT060010CA.ProcedureRequest.text 
         * Conformance/Cardinality: MANDATORY (1) <p>Shows other 
         * providers the usage instructions provided to the 
         * patient.</p> <p>Indicates how the device is intended to be 
         * used.</p> Un-merged Business Name: UsageInstructions 
         * Relationship: PORX_MT020060CA.ProcedureRequest.text 
         * Conformance/Cardinality: MANDATORY (1) <p>Communicates to 
         * other providers how the patient is expected to use the 
         * dispensed device</p> <p>Indicates how the patient is 
         * expected to use the device.</p> Un-merged Business Name: 
         * UsageInstructions Relationship: 
         * PORX_MT060040CA.ProcedureRequest.text 
         * Conformance/Cardinality: MANDATORY (1) <p>Instructions for 
         * use are a key part of any prescription</p> <p>Indicates how 
         * the prescribed device is intended to be used.</p> Un-merged 
         * Business Name: UsageInstructions Relationship: 
         * PORX_MT010110CA.ProcedureRequest.text 
         * Conformance/Cardinality: MANDATORY (1) <p>Instructions are a 
         * key part of the prescription.</p> <p>Indicates how the 
         * device should be used by the patient.</p> Un-merged Business 
         * Name: UsageInstructions Relationship: 
         * PORX_MT060060CA.ProcedureRequest.text 
         * Conformance/Cardinality: MANDATORY (1) <p>Usage instructions 
         * are a critical part of a prescription.</p> <p>Indicates how 
         * the prescribed device is intended to be used.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public String Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

    }

}