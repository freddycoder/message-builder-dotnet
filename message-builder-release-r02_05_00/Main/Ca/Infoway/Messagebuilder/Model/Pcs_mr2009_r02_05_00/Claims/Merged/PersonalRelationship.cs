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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Claims.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Domainvalue;


    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT400001CA.PersonalRelationship","FICR_MT400003CA.PersonalRelationship","FICR_MT400004CA.PersonalRelationship","FICR_MT490101CA.PersonalRelationship","FICR_MT490102CA.PersonalRelationship","FICR_MT500201CA.PersonalRelationship","FICR_MT510201CA.PersonalRelationship","FICR_MT600201CA.PersonalRelationship","FICR_MT610201CA.PersonalRelationship"})]
    public class PersonalRelationship : MessagePartBean {

        private CV code;

        public PersonalRelationship() {
            this.code = new CVImpl();
        }
        /**
         * <summary>Un-merged Business Name: PersonalRelationshipType</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT490102CA.PersonalRelationship.code 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: PersonalRelationshipType Relationship: 
         * FICR_MT400003CA.PersonalRelationship.code 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: ExamplesAreSpouseChild Relationship: 
         * FICR_MT600201CA.PersonalRelationship.code 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: PersonalRelationshipType Relationship: 
         * FICR_MT400004CA.PersonalRelationship.code 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: PersonalRelationshipType Relationship: 
         * FICR_MT490101CA.PersonalRelationship.code 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: PersonalRelationshipCode Relationship: 
         * FICR_MT610201CA.PersonalRelationship.code 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * FICR_MT510201CA.PersonalRelationship.code 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: ExamplesAreSpouseChild Relationship: 
         * FICR_MT500201CA.PersonalRelationship.code 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: PersonalRelationshipType Relationship: 
         * FICR_MT400001CA.PersonalRelationship.code 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public FamilyMemberRelationshipRoleType Code {
            get { return (FamilyMemberRelationshipRoleType) this.code.Value; }
            set { this.code.Value = value; }
        }

    }

}