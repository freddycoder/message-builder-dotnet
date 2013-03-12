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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Immunization.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged;


    /**
     * <summary>Business Name: AdministeredTo</summary>
     * 
     * <remarks>POIZ_MT030060CA.Subject10: (no business name) 
     * <p>Essential for linking the immunization to the patient's 
     * record, and is therefore mandatory.</p> <p>Indicates the 
     * patient who was immunized.</p> POIZ_MT070020CA.Subject: 
     * administered to <p>Essential for linking the immunization to 
     * the patient's record, and is therefore mandatory.</p> 
     * <p>Indicates the patient who is scheduled to be 
     * immunized.</p> POIZ_MT061150CA.Subject10: *administered to 
     * <p>Essential for linking the immunization to the patient's 
     * record, and is therefore mandatory.</p> <p>Indicates the 
     * patient who was immunized.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POIZ_MT030050CA.Subject10","POIZ_MT030060CA.Subject10","POIZ_MT060150CA.Subject10","POIZ_MT061150CA.Subject10","POIZ_MT070020CA.Subject"})]
    public class AdministeredTo : MessagePartBean {

        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.Patient_2 patient;

        public AdministeredTo() {
        }
        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: POIZ_MT030060CA.Subject10.patient 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * POIZ_MT060150CA.Subject10.patient Conformance/Cardinality: 
         * MANDATORY (1) Un-merged Business Name: (no business name 
         * specified) Relationship: POIZ_MT070020CA.Subject.patient 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * POIZ_MT061150CA.Subject10.patient Conformance/Cardinality: 
         * MANDATORY (1) Un-merged Business Name: (no business name 
         * specified) Relationship: POIZ_MT030050CA.Subject10.patient 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"patient"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.Patient_2 Patient {
            get { return this.patient; }
            set { this.patient = value; }
        }

    }

}