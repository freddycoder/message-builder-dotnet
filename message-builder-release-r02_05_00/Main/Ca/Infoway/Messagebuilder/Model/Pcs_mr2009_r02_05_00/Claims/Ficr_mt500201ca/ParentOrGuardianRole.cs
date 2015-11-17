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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Claims.Ficr_mt500201ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <p></p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT500201CA.ParentOrGuardianRole"})]
    public class ParentOrGuardianRole : MessagePartBean {

        private II id;
        private CV code;
        private PN relationshipHolderName;

        public ParentOrGuardianRole() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.relationshipHolderName = new PNImpl();
        }
        /**
         * <summary>Business Name: Id of parent</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT500201CA.ParentOrGuardianRole.id 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: Parent or Guardian Relationship to 
         * patient</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT500201CA.ParentOrGuardianRole.code 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public PersonalRelationshipRoleType Code {
            get { return (PersonalRelationshipRoleType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Name of Parent or Guardian</summary>
         * 
         * <remarks>Relationship: FICR_MT500201CA.ParentOrGuardian.name 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"relationshipHolder/name"})]
        public PersonName RelationshipHolderName {
            get { return this.relationshipHolderName.Value; }
            set { this.relationshipHolderName.Value = value; }
        }

    }

}