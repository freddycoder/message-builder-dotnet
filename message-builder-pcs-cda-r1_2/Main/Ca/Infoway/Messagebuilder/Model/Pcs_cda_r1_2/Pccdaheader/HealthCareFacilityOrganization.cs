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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Pccdaheader {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"PcCDAHeader.HealthCareFacilityOrganization"})]
    public class HealthCareFacilityOrganization : MessagePartBean {

        private LIST<CS, Code> realmCode;
        private II typeId;
        private LIST<II, Identifier> templateId;
        private LIST<II, Identifier> id;
        private LIST<ON, OrganizationName> name;
        private LIST<TEL, TelecommunicationAddress> telecom;
        private LIST<AD, PostalAddress> addr;
        private CE standardIndustryClassCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.OrganizationPartOf asOrganizationPartOf;

        public HealthCareFacilityOrganization() {
            this.realmCode = new LISTImpl<CS, Code>(typeof(CSImpl));
            this.typeId = new IIImpl();
            this.templateId = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.id = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.name = new LISTImpl<ON, OrganizationName>(typeof(ONImpl));
            this.telecom = new LISTImpl<TEL, TelecommunicationAddress>(typeof(TELImpl));
            this.addr = new LISTImpl<AD, PostalAddress>(typeof(ADImpl));
            this.standardIndustryClassCode = new CEImpl();
        }
        /**
         * <summary>Relationship: 
         * PcCDAHeader.HealthCareFacilityOrganization.realmCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"realmCode"})]
        public IList<Code> RealmCode {
            get { return this.realmCode.RawList<Code>(); }
        }

        /**
         * <summary>Relationship: 
         * PcCDAHeader.HealthCareFacilityOrganization.typeId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"typeId"})]
        public Identifier TypeId {
            get { return this.typeId.Value; }
            set { this.typeId.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PcCDAHeader.HealthCareFacilityOrganization.templateId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"templateId"})]
        public IList<Identifier> TemplateId {
            get { return this.templateId.RawList(); }
        }

        /**
         * <summary>Relationship: 
         * PcCDAHeader.HealthCareFacilityOrganization.id</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public IList<Identifier> Id {
            get { return this.id.RawList(); }
        }

        /**
         * <summary>Relationship: 
         * PcCDAHeader.HealthCareFacilityOrganization.name</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"name"})]
        public IList<OrganizationName> Name {
            get { return this.name.RawList(); }
        }

        /**
         * <summary>Relationship: 
         * PcCDAHeader.HealthCareFacilityOrganization.telecom</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"telecom"})]
        public IList<TelecommunicationAddress> Telecom {
            get { return this.telecom.RawList(); }
        }

        /**
         * <summary>Relationship: 
         * PcCDAHeader.HealthCareFacilityOrganization.addr</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"addr"})]
        public IList<PostalAddress> Addr {
            get { return this.addr.RawList(); }
        }

        /**
         * <summary>Relationship: 
         * PcCDAHeader.HealthCareFacilityOrganization.standardIndustryClassCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"standardIndustryClassCode"})]
        public Code StandardIndustryClassCode {
            get { return (Code) this.standardIndustryClassCode.Value; }
            set { this.standardIndustryClassCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PcCDAHeader.HealthCareFacilityOrganization.asOrganizationPartOf</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"asOrganizationPartOf"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.OrganizationPartOf AsOrganizationPartOf {
            get { return this.asOrganizationPartOf; }
            set { this.asOrganizationPartOf = value; }
        }

    }

}