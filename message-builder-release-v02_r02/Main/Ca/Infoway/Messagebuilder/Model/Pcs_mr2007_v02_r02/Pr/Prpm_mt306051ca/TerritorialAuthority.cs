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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pr.Prpm_mt306051ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>Business Name: Territorial Authority</summary>
     * 
     * <p>Supports business requirement to provide additional 
     * information regarding the jurisdication within the scoping 
     * organization exists.</p> <p>RoleClass necessary to support 
     * the Jurisdiction within which the scoping organization 
     * exists</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPM_MT306051CA.TerritorialAuthority"})]
    public class TerritorialAuthority : MessagePartBean {

        private CV code;
        private CV territoryCode;
        private CS partTypeCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pr.Prpm_mt306051ca.TerritorialAuthority partTerritorialAuthority;

        public TerritorialAuthority() {
            this.code = new CVImpl();
            this.territoryCode = new CVImpl();
            this.partTypeCode = new CSImpl();
        }
        /**
         * <summary>Business Name: Territorial Authority Type</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT306051CA.TerritorialAuthority.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports the validation and identification of the 
         * healthcare provider</p> <p>The code identifying the specific 
         * Territorial Authority</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public RoleCode Code {
            get { return (RoleCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Jurisdiction Type</summary>
         * 
         * <remarks>Relationship: PRPM_MT306051CA.Jurisdiction.code 
         * Conformance/Cardinality: POPULATED (1) <p>Populated 
         * attribute supports the validation and identification of the 
         * healthcare provider</p> <p>If Jurisdiction is included in 
         * the message, then Territorial Authority Type is Expected to 
         * Exist.</p> <p>A character value that represents the Canadian 
         * provincial or territorial geographical area within which the 
         * Provider is operating.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"territory/code"})]
        public PlaceEntityType TerritoryCode {
            get { return (PlaceEntityType) this.territoryCode.Value; }
            set { this.territoryCode.Value = value; }
        }

        /**
         * <summary>Relationship: PRPM_MT306051CA.Part.typeCode</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"part/typeCode"})]
        public RoleLinkType PartTypeCode {
            get { return (RoleLinkType) this.partTypeCode.Value; }
            set { this.partTypeCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PRPM_MT306051CA.Part.territorialAuthority</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"part/territorialAuthority"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pr.Prpm_mt306051ca.TerritorialAuthority PartTerritorialAuthority {
            get { return this.partTerritorialAuthority; }
            set { this.partTerritorialAuthority = value; }
        }

    }

}