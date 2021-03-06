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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pr.Prpm_mt306011ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;


    [Hl7PartTypeMappingAttribute(new string[] {"PRPM_MT306011CA.Part"})]
    public class Part : MessagePartBean {

        private CS typeCode;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pr.Prpm_mt306011ca.TerritorialAuthority territorialAuthority;

        public Part() {
            this.typeCode = new CSImpl();
        }
        /**
         * <summary>Relationship: PRPM_MT306011CA.Part.typeCode</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"typeCode"})]
        public RoleLinkType TypeCode {
            get { return (RoleLinkType) this.typeCode.Value; }
            set { this.typeCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PRPM_MT306011CA.Part.territorialAuthority</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"territorialAuthority"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pr.Prpm_mt306011ca.TerritorialAuthority TerritorialAuthority {
            get { return this.territorialAuthority; }
            set { this.territorialAuthority = value; }
        }

    }

}