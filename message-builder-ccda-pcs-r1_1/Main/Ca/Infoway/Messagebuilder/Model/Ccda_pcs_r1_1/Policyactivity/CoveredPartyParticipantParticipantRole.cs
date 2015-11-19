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
namespace Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Policyactivity {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Domainvalue;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"PolicyActivity.CoveredPartyParticipantParticipantRole"})]
    public class CoveredPartyParticipantParticipantRole : MessagePartBean {

        private LIST<II, Identifier> id;
        private CE code;
        private AD addr;
        private CS playingEntityClassCode;
        private LIST<CS, Code> playingEntityRealmCode;
        private II playingEntityTypeId;
        private LIST<II, Identifier> playingEntityTemplateId;
        private CE playingEntityCode;
        private LIST<PQ, PhysicalQuantity> playingEntityQuantity;
        private PN playingEntityName;
        private TSCDAR1 playingEntityBirthTime;
        private ED<EncapsulatedData> playingEntityDesc;

        public CoveredPartyParticipantParticipantRole() {
            this.id = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.code = new CEImpl();
            this.addr = new ADImpl();
            this.playingEntityClassCode = new CSImpl();
            this.playingEntityRealmCode = new LISTImpl<CS, Code>(typeof(CSImpl));
            this.playingEntityTypeId = new IIImpl();
            this.playingEntityTemplateId = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.playingEntityCode = new CEImpl();
            this.playingEntityQuantity = new LISTImpl<PQ, PhysicalQuantity>(typeof(PQImpl));
            this.playingEntityName = new PNImpl();
            this.playingEntityBirthTime = new TSCDAR1Impl();
            this.playingEntityDesc = new EDImpl<EncapsulatedData>();
        }
        /**
         * <summary>Relationship: 
         * PolicyActivity.CoveredPartyParticipantParticipantRole.id</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public IList<Identifier> Id {
            get { return this.id.RawList(); }
        }

        /**
         * <summary>Relationship: 
         * PolicyActivity.CoveredPartyParticipantParticipantRole.code</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public CoverageRoleType Code {
            get { return (CoverageRoleType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PolicyActivity.CoveredPartyParticipantParticipantRole.addr</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"addr"})]
        public PostalAddress Addr {
            get { return this.addr.Value; }
            set { this.addr.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PolicyActivity.PlayingEntity.classCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"playingEntity/classCode"})]
        public EntityClassRoot PlayingEntityClassCode {
            get { return (EntityClassRoot) this.playingEntityClassCode.Value; }
            set { this.playingEntityClassCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PolicyActivity.PlayingEntity.realmCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"playingEntity/realmCode"})]
        public IList<Code> PlayingEntityRealmCode {
            get { return this.playingEntityRealmCode.RawList<Code>(); }
        }

        /**
         * <summary>Relationship: PolicyActivity.PlayingEntity.typeId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"playingEntity/typeId"})]
        public Identifier PlayingEntityTypeId {
            get { return this.playingEntityTypeId.Value; }
            set { this.playingEntityTypeId.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PolicyActivity.PlayingEntity.templateId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"playingEntity/templateId"})]
        public IList<Identifier> PlayingEntityTemplateId {
            get { return this.playingEntityTemplateId.RawList(); }
        }

        /**
         * <summary>Relationship: PolicyActivity.PlayingEntity.code</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"playingEntity/code"})]
        public Code PlayingEntityCode {
            get { return (Code) this.playingEntityCode.Value; }
            set { this.playingEntityCode.Value = value; }
        }

        /**
         * <summary>Relationship: PolicyActivity.PlayingEntity.quantity</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"playingEntity/quantity"})]
        public IList<PhysicalQuantity> PlayingEntityQuantity {
            get { return this.playingEntityQuantity.RawList(); }
        }

        /**
         * <summary>Relationship: PolicyActivity.PlayingEntity.name</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"playingEntity/name"})]
        public PersonName PlayingEntityName {
            get { return this.playingEntityName.Value; }
            set { this.playingEntityName.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PolicyActivity.PlayingEntity.birthTime</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"playingEntity/birthTime"})]
        public MbDate PlayingEntityBirthTime {
            get { return this.playingEntityBirthTime.Value; }
            set { this.playingEntityBirthTime.Value = value; }
        }

        /**
         * <summary>Relationship: PolicyActivity.PlayingEntity.desc</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"playingEntity/desc"})]
        public EncapsulatedData PlayingEntityDesc {
            get { return this.playingEntityDesc.Value; }
            set { this.playingEntityDesc.Value = value; }
        }

    }

}