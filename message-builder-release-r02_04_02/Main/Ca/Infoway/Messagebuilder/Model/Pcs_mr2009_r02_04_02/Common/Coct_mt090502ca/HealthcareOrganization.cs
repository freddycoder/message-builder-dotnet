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
 * Author:        $LastChangedBy: jmis $
 * Last modified: $LastChangedDate: 2015-09-15 11:03:10 -0400 (Tue, 15 Sep 2015) $
 * Revision:      $LastChangedRevision: 9793 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt090502ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: Healthcare Organization</summary>
     * 
     * <p>Critical to tracking responsibility and performing 
     * follow-up.</p> <p>The organization under whose authority the 
     * associated action (linked by a participation) was 
     * performed.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT090502CA.AssignedEntity"})]
    public class HealthcareOrganization : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lab.Polb_mt002000ca.IRoleChoice, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt080100ca.IPerformerChoice, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt911102ca.IActingPerson, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.IAuthorPerson_2, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lab.Merged.IRoleChoice, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt011001ca.IAssignees, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.IEntererChoice, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lab.Merged.IRecipientChoice, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lab.Polb_mt004000ca.IRecipientChoice {

        private II representedOrganizationId;
        private ST representedOrganizationName;

        public HealthcareOrganization() {
            this.representedOrganizationId = new IIImpl();
            this.representedOrganizationName = new STImpl();
        }
        /**
         * <summary>Business Name: D: Organization identifier</summary>
         * 
         * <remarks>Relationship: COCT_MT090502CA.Organization.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows the 
         * organization to be referenced when determining privileges 
         * and for drill-downs to retrieve additional information. 
         * Because of its importance, the attribute is mandatory.</p> 
         * <p>A unique identifier for the organization</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"representedOrganization/id"})]
        public Identifier RepresentedOrganizationId {
            get { return this.representedOrganizationId.Value; }
            set { this.representedOrganizationId.Value = value; }
        }

        /**
         * <summary>Business Name: E: Organization Name</summary>
         * 
         * <remarks>Relationship: COCT_MT090502CA.Organization.name 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for human 
         * recognition of the organization as well as confirmation of 
         * the identifier. As a result, the attribute is mandatory.</p> 
         * <p>Identifies the name of the organization</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"representedOrganization/name"})]
        public String RepresentedOrganizationName {
            get { return this.representedOrganizationName.Value; }
            set { this.representedOrganizationName.Value = value; }
        }

    }

}