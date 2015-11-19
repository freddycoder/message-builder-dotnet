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
namespace Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Servicedeliverylocation {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel;
    using Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"ServiceDeliveryLocation.ParticipantRole"})]
    public class ParticipantRole : MessagePartBean {

        private LIST<CS, Code> realmCode;
        private II typeId;
        private LIST<II, Identifier> templateId;
        private LIST<II, Identifier> id;
        private CE code;
        private LIST<AD, PostalAddress> addr;
        private LIST<TEL, TelecommunicationAddress> telecom;
        private Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.IParticipantRoleChoice participantRoleChoice;
        private Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.Entity scopingEntity;

        public ParticipantRole() {
            this.realmCode = new LISTImpl<CS, Code>(typeof(CSImpl));
            this.typeId = new IIImpl();
            this.templateId = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.id = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.code = new CEImpl();
            this.addr = new LISTImpl<AD, PostalAddress>(typeof(ADImpl));
            this.telecom = new LISTImpl<TEL, TelecommunicationAddress>(typeof(TELImpl));
        }
        /**
         * <summary>Relationship: 
         * ServiceDeliveryLocation.ParticipantRole.realmCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"realmCode"})]
        public IList<Code> RealmCode {
            get { return this.realmCode.RawList<Code>(); }
        }

        /**
         * <summary>Relationship: 
         * ServiceDeliveryLocation.ParticipantRole.typeId</summary>
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
         * ServiceDeliveryLocation.ParticipantRole.templateId</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"templateId"})]
        public IList<Identifier> TemplateId {
            get { return this.templateId.RawList(); }
        }

        /**
         * <summary>Relationship: 
         * ServiceDeliveryLocation.ParticipantRole.id</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public IList<Identifier> Id {
            get { return this.id.RawList(); }
        }

        /**
         * <summary>Relationship: 
         * ServiceDeliveryLocation.ParticipantRole.code</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public HealthcareServiceLocation Code {
            get { return (HealthcareServiceLocation) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * ServiceDeliveryLocation.ParticipantRole.addr</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"addr"})]
        public IList<PostalAddress> Addr {
            get { return this.addr.RawList(); }
        }

        /**
         * <summary>Relationship: 
         * ServiceDeliveryLocation.ParticipantRole.telecom</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"telecom"})]
        public IList<TelecommunicationAddress> Telecom {
            get { return this.telecom.RawList(); }
        }

        /**
         * <summary>Relationship: 
         * ServiceDeliveryLocation.ParticipantRole.participantRoleChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"participantRoleChoice"})]
        public Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.IParticipantRoleChoice ParticipantRoleChoice {
            get { return this.participantRoleChoice; }
            set { this.participantRoleChoice = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.Device ParticipantRoleChoiceAsPlayingDevice {
            get { return this.participantRoleChoice is Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.Device ? (Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.Device) this.participantRoleChoice : (Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.Device) null; }
        }
        public bool HasParticipantRoleChoiceAsPlayingDevice() {
            return (this.participantRoleChoice is Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.Device);
        }

        public Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.PlayingEntity_2 ParticipantRoleChoiceAsPlayingEntity {
            get { return this.participantRoleChoice is Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.PlayingEntity_2 ? (Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.PlayingEntity_2) this.participantRoleChoice : (Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.PlayingEntity_2) null; }
        }
        public bool HasParticipantRoleChoiceAsPlayingEntity() {
            return (this.participantRoleChoice is Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.PlayingEntity_2);
        }

        /**
         * <summary>Relationship: 
         * ServiceDeliveryLocation.ParticipantRole.scopingEntity</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"scopingEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.Entity ScopingEntity {
            get { return this.scopingEntity; }
            set { this.scopingEntity = value; }
        }

    }

}