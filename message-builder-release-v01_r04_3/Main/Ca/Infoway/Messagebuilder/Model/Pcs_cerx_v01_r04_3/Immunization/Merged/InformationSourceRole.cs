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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Immunization.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;


    [Hl7PartTypeMappingAttribute(new string[] {"POIZ_MT030060CA.InformationSourceRole","POIZ_MT060150CA.InformationSourceRole"})]
    public class InformationSourceRole : MessagePartBean {

        private CS classCode;

        public InformationSourceRole() {
            this.classCode = new CSImpl();
        }
        /**
         * <summary>Business Name: InformationSource</summary>
         * 
         * <remarks>Un-merged Business Name: InformationSource 
         * Relationship: 
         * POIZ_MT060150CA.InformationSourceRole.classCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for the 
         * explicit identification of the source of the recorded 
         * information.</p> <p>A coded value denoting a patient, 
         * patient's agent, or a provider as the source of the recorded 
         * immunization information.</p> Un-merged Business Name: 
         * InformationSource Relationship: 
         * POIZ_MT030060CA.InformationSourceRole.classCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for the 
         * explicit identification of the source of the recorded 
         * information.</p> <p>A coded value denoting a patient, 
         * patient's agent, or a provider as the source of the recorded 
         * immunization information.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"classCode"})]
        public x_InformationSource ClassCode {
            get { return (x_InformationSource) this.classCode.Value; }
            set { this.classCode.Value = value; }
        }

    }

}