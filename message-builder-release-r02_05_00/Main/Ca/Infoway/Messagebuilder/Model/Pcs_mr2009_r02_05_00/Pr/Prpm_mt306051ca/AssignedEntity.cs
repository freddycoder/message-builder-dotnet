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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt306051ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Merged;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Assigned Entity</summary>
     * 
     * <p>Roleclass required to provide additional information for 
     * the person responsible for providing healthcare services 
     * within a specific healthcare setting</p> <p>The role class, 
     * assigned entity, captures the critical information of the 
     * provider playing the role of interest. This includes an 
     * identifier for the role, mailing address, phone number, and 
     * the time within which the role is played (may be open 
     * ended). The scooping organization, which may be omitted if 
     * not needed, provides the organizational context for the 
     * entity that actually plays the role. For example, the role 
     * scoper will normally be the party that assigns the 
     * identifier for the role.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPM_MT306051CA.AssignedEntity"})]
    public class AssignedEntity : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt306051ca.IRoleChoice {

        private SET<II, Identifier> id;
        private CV code;
        private LIST<PN, PersonName> name;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Merged.PrinicpalPerson_2 assignedPrincipalPerson;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt306051ca.Organization representedOrganization;

        public AssignedEntity() {
            this.id = new SETImpl<II, Identifier>(typeof(IIImpl));
            this.code = new CVImpl();
            this.name = new LISTImpl<PN, PersonName>(typeof(PNImpl));
        }
        /**
         * <summary>Business Name: Functional Role Identifier</summary>
         * 
         * <remarks>Relationship: PRPM_MT306051CA.AssignedEntity.id 
         * Conformance/Cardinality: MANDATORY (1-50) <p>Mandatory 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>Identifies specific functional role that a 
         * provider may play within an organization.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public ICollection<Identifier> Id {
            get { return this.id.RawSet(); }
        }

        /**
         * <summary>Business Name: Functional Role Type</summary>
         * 
         * <remarks>Relationship: PRPM_MT306051CA.AssignedEntity.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>The code identifying the specific functional 
         * role.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public AssignedRoleType Code {
            get { return (AssignedRoleType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Functional Role Name</summary>
         * 
         * <remarks>Relationship: PRPM_MT306051CA.AssignedEntity.name 
         * Conformance/Cardinality: REQUIRED (0-5) <p>Required 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>The provider's name pertaining to the 
         * specific functional role.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"name"})]
        public IList<PersonName> Name {
            get { return this.name.RawList(); }
        }

        /**
         * <summary>Relationship: 
         * PRPM_MT306051CA.AssignedEntity.assignedPrincipalPerson</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"assignedPrincipalPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Merged.PrinicpalPerson_2 AssignedPrincipalPerson {
            get { return this.assignedPrincipalPerson; }
            set { this.assignedPrincipalPerson = value; }
        }

        /**
         * <summary>Relationship: 
         * PRPM_MT306051CA.AssignedEntity.representedOrganization</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"representedOrganization"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt306051ca.Organization RepresentedOrganization {
            get { return this.representedOrganization; }
            set { this.representedOrganization = value; }
        }

    }

}