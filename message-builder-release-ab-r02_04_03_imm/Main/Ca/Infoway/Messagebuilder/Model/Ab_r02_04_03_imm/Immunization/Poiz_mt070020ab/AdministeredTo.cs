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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Immunization.Poiz_mt070020ab {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt050208ca;


    /**
     * <summary>Business Name: administered to</summary>
     * 
     * <p>Essential for linking the immunization to the patient's 
     * record, and is therefore mandatory.</p> <p>Indicates the 
     * patient who is scheduled to be immunized.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POIZ_MT070020AB.Subject"})]
    public class AdministeredTo : MessagePartBean {

        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt050208ca.Patient patient;

        public AdministeredTo() {
        }
        /**
         * <summary>Relationship: POIZ_MT070020AB.Subject.patient</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"patient"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt050208ca.Patient Patient {
            get { return this.patient; }
            set { this.patient = value; }
        }

    }

}