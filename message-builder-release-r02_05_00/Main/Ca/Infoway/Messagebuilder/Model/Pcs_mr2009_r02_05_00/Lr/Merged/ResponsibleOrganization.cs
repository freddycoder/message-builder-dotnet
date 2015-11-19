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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lr.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: ResponsibleOrganization</summary>
     * 
     * <remarks>PRPA_MT202302CA.Organization: B:Responsible 
     * Organization <p>To provide additional information regarding 
     * the management and administration of the service delivery 
     * location.</p> <p>The organization responsible for the 
     * operations of the service delivery location.</p> 
     * PRPA_MT202301CA.Organization: B:Responsible Organization 
     * <p>To provide additional information regarding the 
     * management and administration of the service delivery 
     * location.</p> <p>The organization responsible for the 
     * operations of the service delivery location.</p> 
     * PRPA_MT202303CA.Organization: B:Responsible Organization 
     * <p>To provide additional information regarding the 
     * management and administration of the service delivery 
     * location.</p> <p>The organization responsible for the 
     * operations of the service delivery location.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPA_MT202301CA.Organization","PRPA_MT202302CA.Organization","PRPA_MT202303CA.Organization"})]
    public class ResponsibleOrganization : MessagePartBean {

        private II id;
        private ST name;

        public ResponsibleOrganization() {
            this.id = new IIImpl();
            this.name = new STImpl();
        }
        /**
         * <summary>Business Name: ResponsibleOrganizationIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * ResponsibleOrganizationIdentifier Relationship: 
         * PRPA_MT202302CA.Organization.id Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Allows drilling down for additional 
         * information about the organization. May also be used as a 
         * query parameter.</p> <p>The expectation is that these 
         * identifiers can be retrieved from jurisdictional provider 
         * registries. Where organization identifiers are not 
         * maintained in the registry, they may be omitted or 
         * alternative identifier sources may be used (e.g. identifiers 
         * issued by health regions).</p> <p>Unique identifier for the 
         * responsible organization.</p> Un-merged Business Name: 
         * ResponsibleOrganizationIdentifier Relationship: 
         * PRPA_MT202301CA.Organization.id Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Allows drilling down for additional 
         * information about the organization. May also be used as a 
         * query parameter.</p> <p>The expectation is that these 
         * identifiers can be retrieved from jurisdictional provider 
         * registries. Where organization identifiers are not 
         * maintained in the registry, they may be omitted or 
         * alternative identifier sources may be used (e.g. identifiers 
         * issued by health regions).</p> <p>Unique identifier for the 
         * responsible organization.</p> Un-merged Business Name: 
         * ResponsibleOrganizationIdentifier Relationship: 
         * PRPA_MT202303CA.Organization.id Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Allows drilling down for additional 
         * information about the organization. May also be used as a 
         * query parameter.</p> <p>The expectation is that these 
         * identifiers can be retrieved from jurisdictional provider 
         * registries. Where organization identifiers are not 
         * maintained in the registry, they may be omitted or 
         * alternative identifier sources may be used (e.g. identifiers 
         * issued by health regions).</p> <p>Unique identifier for the 
         * responsible organization.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: ResponsibleOrganizationName</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * ResponsibleOrganizationName Relationship: 
         * PRPA_MT202302CA.Organization.name Conformance/Cardinality: 
         * MANDATORY (1) <p>Provides a user-accessible label for the 
         * organization and is therefore mandatory.</p> <p>The label by 
         * which the responsible organization is known and communicated 
         * with e.g. Capital Health District.</p> Un-merged Business 
         * Name: ResponsibleOrganizationName Relationship: 
         * PRPA_MT202301CA.Organization.name Conformance/Cardinality: 
         * MANDATORY (1) <p>Provides a user-accessible label for the 
         * organization and is therefore mandatory.</p> <p>The label by 
         * which the responsible organization is known and communicated 
         * with e.g. Capital Health District.</p> Un-merged Business 
         * Name: ResponsibleOrganizationName Relationship: 
         * PRPA_MT202303CA.Organization.name Conformance/Cardinality: 
         * MANDATORY (1) <p>Provides a user-accessible label for the 
         * organization and is therefore mandatory.</p> <p>The label by 
         * which the responsible organization is known and communicated 
         * with e.g. Capital Health District.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"name"})]
        public String Name {
            get { return this.name.Value; }
            set { this.name.Value = value; }
        }

    }

}