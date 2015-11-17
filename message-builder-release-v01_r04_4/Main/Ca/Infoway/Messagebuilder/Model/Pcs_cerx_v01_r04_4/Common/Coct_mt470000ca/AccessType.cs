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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt470000ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Merged;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Access Type</summary>
     * 
     * <p>Allows discrete control over different types of 
     * information.</p> <p>Defines the types of information 
     * permission is being granted to access.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT470000CA.InformDefinition"})]
    public class AccessType : MessagePartBean {

        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Merged.ConsentGivenTo receiver;
        private IList<CV> subjectActDefinitionCode;

        public AccessType() {
            this.subjectActDefinitionCode = new List<CV>();
        }
        /**
         * <summary>Relationship: 
         * COCT_MT470000CA.InformDefinition.receiver</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"receiver"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Merged.ConsentGivenTo Receiver {
            get { return this.receiver; }
            set { this.receiver = value; }
        }

        /**
         * <summary>Business Name: B:Consent Information Types</summary>
         * 
         * <remarks>Relationship: COCT_MT470000CA.ActDefinition.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Different consents 
         * (or even keywords) may be needed to access different types 
         * of patient information (e.g. demographics, medications, 
         * allergies, lab results). Understanding the type of 
         * information the consent applies to is critical, and 
         * therefore the attribute is mandatory.</p> <p>The type of 
         * patient information that can be accessed or modified.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject/actDefinition/code"})]
        public IList<ActInformationAccessTypeCode> SubjectActDefinitionCode {
            get { return new RawListWrapper<CV, ActInformationAccessTypeCode>(subjectActDefinitionCode, typeof(CVImpl)); }
        }

    }

}