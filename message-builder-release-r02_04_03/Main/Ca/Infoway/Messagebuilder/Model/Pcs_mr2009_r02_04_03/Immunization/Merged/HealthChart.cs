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


    [Hl7PartTypeMappingAttribute(new string[] {"POIZ_MT030050CA.HealthChart","POIZ_MT030060CA.HealthChart","POIZ_MT060150CA.HealthChart"})]
    public class HealthChart : MessagePartBean {

        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Immunization.Merged.AntigenValidity subjectOf1AntigenValidity;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Immunization.Merged.AntigenCount subjectOf2AntigenCount;

        public HealthChart() {
        }
        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * POIZ_MT060150CA.Subject4.antigenValidity 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * POIZ_MT030060CA.Subject4.antigenValidity 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * POIZ_MT030050CA.Subject4.antigenValidity 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf1/antigenValidity"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Immunization.Merged.AntigenValidity SubjectOf1AntigenValidity {
            get { return this.subjectOf1AntigenValidity; }
            set { this.subjectOf1AntigenValidity = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: POIZ_MT060150CA.Subject3.antigenCount 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * POIZ_MT030060CA.Subject3.antigenCount 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * POIZ_MT030050CA.Subject3.antigenCount 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2/antigenCount"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Immunization.Merged.AntigenCount SubjectOf2AntigenCount {
            get { return this.subjectOf2AntigenCount; }
            set { this.subjectOf2AntigenCount = value; }
        }

    }

}