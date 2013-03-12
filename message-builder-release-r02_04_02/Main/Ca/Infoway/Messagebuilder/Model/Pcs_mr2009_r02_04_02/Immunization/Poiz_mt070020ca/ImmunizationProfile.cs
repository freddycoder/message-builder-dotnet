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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Immunization.Poiz_mt070020ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Immunization.Merged;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"POIZ_MT070020CA.ImmunizationProfile"})]
    public class ImmunizationProfile : MessagePartBean {

        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Immunization.Merged.AdministeredTo subject1;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Immunization.Poiz_mt070020ca.ImmunizationForecast> subject2ImmunizationForecast;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Immunization.Poiz_mt070020ca.Attachment pertinentInformationAttachment;

        public ImmunizationProfile() {
            this.subject2ImmunizationForecast = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Immunization.Poiz_mt070020ca.ImmunizationForecast>();
        }
        /**
         * <summary>Relationship: 
         * POIZ_MT070020CA.ImmunizationProfile.subject1</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject1"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Immunization.Merged.AdministeredTo Subject1 {
            get { return this.subject1; }
            set { this.subject1 = value; }
        }

        /**
         * <summary>Relationship: 
         * POIZ_MT070020CA.Subject3.immunizationForecast</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject2/immunizationForecast"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Immunization.Poiz_mt070020ca.ImmunizationForecast> Subject2ImmunizationForecast {
            get { return this.subject2ImmunizationForecast; }
        }

        /**
         * <summary>Relationship: 
         * POIZ_MT070020CA.PertinentInformation.attachment</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"pertinentInformation/attachment"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Immunization.Poiz_mt070020ca.Attachment PertinentInformationAttachment {
            get { return this.pertinentInformationAttachment; }
            set { this.pertinentInformationAttachment = value; }
        }

    }

}