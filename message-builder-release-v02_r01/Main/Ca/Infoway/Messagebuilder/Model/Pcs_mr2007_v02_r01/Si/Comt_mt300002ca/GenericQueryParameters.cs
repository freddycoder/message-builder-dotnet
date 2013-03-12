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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Si.Comt_mt300002ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>Business Name: Generic Query Parameters</summary>
     * 
     * <p>Root class for query definition</p> <p>Defines the set of 
     * parameters that may be used to filter the query 
     * response.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COMT_MT300002CA.ParameterList"})]
    public class GenericQueryParameters : MessagePartBean {

        private CV patientNoteCategoryCodeValue;

        public GenericQueryParameters() {
            this.patientNoteCategoryCodeValue = new CVImpl();
        }
        /**
         * <summary>Business Name: Patient Note Category Code</summary>
         * 
         * <remarks>Relationship: 
         * COMT_MT300002CA.PatientNoteCategoryCode.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for the 
         * retrieval of all patient notes pertaining to a specific note 
         * category.</p> <p>Indicates that the result set is to be 
         * filtered to include only those patient annotation pertaining 
         * to the specified annotation category.</p><p>Valid patient 
         * note categories include: General, Medication, Lab, DI, 
         * etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"patientNoteCategoryCode/value"})]
        public ActPatientAnnotationCode PatientNoteCategoryCodeValue {
            get { return (ActPatientAnnotationCode) this.patientNoteCategoryCodeValue.Value; }
            set { this.patientNoteCategoryCodeValue.Value = value; }
        }

    }

}