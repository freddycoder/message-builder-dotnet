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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt080100ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Domainvalue;
    using System;


    /**
     * <summary>Business Name: Other Specimen Identifications</summary>
     * 
     * <p>For referral and redirected orders, this information 
     * helps keep track of the different id's assigned during each 
     * phase of processing.</p> <p>Associated specimen 
     * identifiers.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT080100CA.IdentifiedEntity"})]
    public class OtherSpecimenIdentifications : MessagePartBean {

        private II id;
        private CV code;
        private II assigningOrganizationId;
        private ST assigningOrganizationName;

        public OtherSpecimenIdentifications() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.assigningOrganizationId = new IIImpl();
            this.assigningOrganizationName = new STImpl();
        }
        /**
         * <summary>Business Name: Other Specimen Identifiers</summary>
         * 
         * <remarks>Relationship: COCT_MT080100CA.IdentifiedEntity.id 
         * Conformance/Cardinality: MANDATORY (1) <p>For referral and 
         * redirected orders, this information helps keep track of the 
         * different id's assigned during each phase of processing.</p> 
         * <p>Associated specimen identifiers.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: Other Specimen Identifier Type</summary>
         * 
         * <remarks>Relationship: COCT_MT080100CA.IdentifiedEntity.code 
         * Conformance/Cardinality: REQUIRED (1) <p>Categorized the 
         * type of role identifier.</p> <p>Describes the type of other 
         * specimen identifier (referral, primary, etc.)</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public SpecimenIdentifierRoleType Code {
            get { return (SpecimenIdentifierRoleType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Organization Identifier</summary>
         * 
         * <remarks>Relationship: COCT_MT080100CA.Organization.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows the 
         * organization to be referenced when determining privileges 
         * and for drill-downs to retrieve additional information. 
         * Because of its importance, the attribute is mandatory.</p> 
         * <p>A unique identifier for the organization</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"assigningOrganization/id"})]
        public Identifier AssigningOrganizationId {
            get { return this.assigningOrganizationId.Value; }
            set { this.assigningOrganizationId.Value = value; }
        }

        /**
         * <summary>Business Name: Organization Name</summary>
         * 
         * <remarks>Relationship: COCT_MT080100CA.Organization.name 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for human 
         * recognition of the organization as well as confirmation of 
         * the identifier. As a result, the attribute is mandatory.</p> 
         * <p>Identifies the name of the organization</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"assigningOrganization/name"})]
        public String AssigningOrganizationName {
            get { return this.assigningOrganizationName.Value; }
            set { this.assigningOrganizationName.Value = value; }
        }

    }

}