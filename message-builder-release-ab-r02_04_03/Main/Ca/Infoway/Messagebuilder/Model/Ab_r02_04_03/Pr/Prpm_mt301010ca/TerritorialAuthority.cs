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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Prpm_mt301010ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Domainvalue;


    /**
     * <summary>Business Name: Territorial Authority</summary>
     * 
     * <p>Supports business requirement to provide additional 
     * information regarding the jurisdication within the scoping 
     * organization exists.</p> <p>RoleClass necessary to support 
     * the Jurisdiction within which the scoping organization 
     * exists</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPM_MT301010CA.TerritorialAuthority"})]
    public class TerritorialAuthority : MessagePartBean {

        private CV code;
        private CV territoryCode;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Prpm_mt301010ca.TerritorialAuthority partTerritorialAuthority;

        public TerritorialAuthority() {
            this.code = new CVImpl();
            this.territoryCode = new CVImpl();
        }
        /**
         * <summary>Business Name: Territorial Authority Type</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT301010CA.TerritorialAuthority.code 
         * Conformance/Cardinality: REQUIRED (1) <p>Mandatory attribute 
         * supports the validation and identification of the healthcare 
         * provider</p> <p>The code identifying the specific 
         * Territorial Authority</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public TerritorialAuthorityRoleType Code {
            get { return (TerritorialAuthorityRoleType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Jurisdiction Type</summary>
         * 
         * <remarks>Relationship: PRPM_MT301010CA.Jurisdiction.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports the validation and identification of the 
         * healthcare provider</p> <p>If Jurisdiction is included in 
         * the message, then Territorial Authority Type is Expected to 
         * Exist.</p> <p>A character value that represents the Canadian 
         * provincial or territorial geographical area within which the 
         * Provider is operating.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"territory/code"})]
        public JurisdictionTypeCode TerritoryCode {
            get { return (JurisdictionTypeCode) this.territoryCode.Value; }
            set { this.territoryCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PRPM_MT301010CA.Part.territorialAuthority</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"part/territorialAuthority"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Prpm_mt301010ca.TerritorialAuthority PartTerritorialAuthority {
            get { return this.partTerritorialAuthority; }
            set { this.partTerritorialAuthority = value; }
        }

    }

}