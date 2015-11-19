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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Poiz_mt030060ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <p>Supplies contextual information about the source of the 
     * immunization report.</p>
     * 
     * <p>Identifies the source of the immunization information as 
     * someone who has a personal relationship with the 
     * patient.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POIZ_MT030060CA.PersonalRelationshipRole"})]
    public class PersonalRelationshipRole : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Merged.IInformationSourceChoice {

        private CV code;

        public PersonalRelationshipRole() {
            this.code = new CVImpl();
        }
        /**
         * <summary>Business Name: Personal Relationship Type</summary>
         * 
         * <remarks>Relationship: 
         * POIZ_MT030060CA.PersonalRelationshipRole.code 
         * Conformance/Cardinality: REQUIRED (1) <p>Useful for 
         * categorizing sources of immunization information. As a 
         * result, this attribute is populated.</p> <p>Describes the 
         * personal relationship between the information source and the 
         * patient.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public PersonalRelationshipRoleType Code {
            get { return (PersonalRelationshipRoleType) this.code.Value; }
            set { this.code.Value = value; }
        }

    }

}