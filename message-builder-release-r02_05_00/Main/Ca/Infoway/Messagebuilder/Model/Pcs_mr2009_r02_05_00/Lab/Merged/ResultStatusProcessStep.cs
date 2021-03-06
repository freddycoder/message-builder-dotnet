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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Domainvalue;


    /**
     * <summary>POLB_MT004200CA.ResultStatusProcessStep: Result 
     * Status</summary>
     * 
     * <p>Used to designate &quot;preliminary&quot; and 
     * &quot;final&quot; result statuses.</p> 
     * POLB_MT004100CA.ResultStatusProcessStep: Result Status 
     * Process Step <p>Used to communicate report 
     * &quot;preliminary&quot; and &quot;final&quot; result 
     * statuses.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POLB_MT002000CA.ResultStatusProcessStep","POLB_MT004000CA.ResultStatusProcessStep","POLB_MT004100CA.ResultStatusProcessStep","POLB_MT004200CA.ResultStatusProcessStep"})]
    public class ResultStatusProcessStep : MessagePartBean {

        private CD code;

        public ResultStatusProcessStep() {
            this.code = new CDImpl();
        }
        /**
         * <summary>Business Name: ResultStatusProcessStepCode</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * ResultStatusProcessStepCode Relationship: 
         * POLB_MT004000CA.ResultStatusProcessStep.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Used to designate 
         * &quot;preliminary&quot; and &quot;final&quot; result 
         * statuses.</p> Un-merged Business Name: 
         * ResultStatusProcessStepCode Relationship: 
         * POLB_MT002000CA.ResultStatusProcessStep.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Preliminary or 
         * Final.</p> Un-merged Business Name: 
         * ResultStatusProcessStepCode Relationship: 
         * POLB_MT004200CA.ResultStatusProcessStep.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Used to designate 
         * &quot;preliminary&quot; and &quot;final&quot; result 
         * statuses.</p> Un-merged Business Name: 
         * ResultStatusProcessStepCode Relationship: 
         * POLB_MT004100CA.ResultStatusProcessStep.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Used to designate 
         * &quot;preliminary&quot; and &quot;final&quot; result 
         * statuses.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public LabResultReportingProcessStepCode Code {
            get { return (LabResultReportingProcessStepCode) this.code.Value; }
            set { this.code.Value = value; }
        }

    }

}