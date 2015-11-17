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
namespace Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"AllergyIntoleranceObservation.ParticipantRole","BaseModel.ParticipantRole","CaregiverCharacteristics.ParticipantRole","SubstanceOrDeviceAllergyIntoleranceObservation.ParticipantRole"})]
    public class ParticipantRole : MessagePartBean {

        private LIST<CS_R2<Code>, CodedTypeR2<Code>> realmCode;
        private II typeId;
        private LIST<II, Identifier> templateId;
        private LIST<II, Identifier> id;
        private CE_R2<Code> code;
        private LIST<AD, PostalAddress> addr;
        private LIST<TEL, TelecommunicationAddress> telecom;
        private Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Entity scopingEntity;
        private Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.PlayingEntity_2 playingEntity;
        private Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.IParticipantRoleChoice participantRoleChoice;
        private CS_R2<RoleClassRoot> classCode;

        public ParticipantRole() {
            this.realmCode = new LISTImpl<CS_R2<Code>, CodedTypeR2<Code>>(typeof(CS_R2Impl<Code>));
            this.typeId = new IIImpl();
            this.templateId = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.id = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.code = new CE_R2Impl<Code>();
            this.addr = new LISTImpl<AD, PostalAddress>(typeof(ADImpl));
            this.telecom = new LISTImpl<TEL, TelecommunicationAddress>(typeof(TELImpl));
            this.classCode = new CS_R2Impl<RoleClassRoot>();
        }
        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * AllergyIntoleranceObservation.ParticipantRole.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * CaregiverCharacteristics.ParticipantRole.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * SubstanceOrDeviceAllergyIntoleranceObservation.ParticipantRole.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * BaseModel.ParticipantRole.realmCode Conformance/Cardinality: 
         * OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"realmCode"})]
        public IList<CodedTypeR2<Code>> RealmCode {
            get { return this.realmCode.RawList<CodedTypeR2<Code>>(); }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * AllergyIntoleranceObservation.ParticipantRole.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * CaregiverCharacteristics.ParticipantRole.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * SubstanceOrDeviceAllergyIntoleranceObservation.ParticipantRole.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * BaseModel.ParticipantRole.typeId Conformance/Cardinality: 
         * OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"typeId"})]
        public Identifier TypeId {
            get { return this.typeId.Value; }
            set { this.typeId.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * AllergyIntoleranceObservation.ParticipantRole.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * CaregiverCharacteristics.ParticipantRole.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * SubstanceOrDeviceAllergyIntoleranceObservation.ParticipantRole.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * BaseModel.ParticipantRole.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"templateId"})]
        public IList<Identifier> TemplateId {
            get { return this.templateId.RawList(); }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * AllergyIntoleranceObservation.ParticipantRole.id 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * CaregiverCharacteristics.ParticipantRole.id 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * SubstanceOrDeviceAllergyIntoleranceObservation.ParticipantRole.id 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * BaseModel.ParticipantRole.id Conformance/Cardinality: 
         * OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public IList<Identifier> Id {
            get { return this.id.RawList(); }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * AllergyIntoleranceObservation.ParticipantRole.code 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * CaregiverCharacteristics.ParticipantRole.code 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * SubstanceOrDeviceAllergyIntoleranceObservation.ParticipantRole.code 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * BaseModel.ParticipantRole.code Conformance/Cardinality: 
         * OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public CodedTypeR2<Code> Code {
            get { return (CodedTypeR2<Code>) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * AllergyIntoleranceObservation.ParticipantRole.addr 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * CaregiverCharacteristics.ParticipantRole.addr 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * SubstanceOrDeviceAllergyIntoleranceObservation.ParticipantRole.addr 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * BaseModel.ParticipantRole.addr Conformance/Cardinality: 
         * OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"addr"})]
        public IList<PostalAddress> Addr {
            get { return this.addr.RawList(); }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * AllergyIntoleranceObservation.ParticipantRole.telecom 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * CaregiverCharacteristics.ParticipantRole.telecom 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * SubstanceOrDeviceAllergyIntoleranceObservation.ParticipantRole.telecom 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * BaseModel.ParticipantRole.telecom Conformance/Cardinality: 
         * OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"telecom"})]
        public IList<TelecommunicationAddress> Telecom {
            get { return this.telecom.RawList(); }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * AllergyIntoleranceObservation.ParticipantRole.scopingEntity 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * CaregiverCharacteristics.ParticipantRole.scopingEntity 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * SubstanceOrDeviceAllergyIntoleranceObservation.ParticipantRole.scopingEntity 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * BaseModel.ParticipantRole.scopingEntity 
         * Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"scopingEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Entity ScopingEntity {
            get { return this.scopingEntity; }
            set { this.scopingEntity = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * AllergyIntoleranceObservation.ParticipantRole.playingEntity 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * SubstanceOrDeviceAllergyIntoleranceObservation.ParticipantRole.playingEntity 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"playingEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.PlayingEntity_2 PlayingEntity {
            get { return this.playingEntity; }
            set { this.playingEntity = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * CaregiverCharacteristics.ParticipantRole.participantRoleChoice 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * BaseModel.ParticipantRole.participantRoleChoice 
         * Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"participantRoleChoice"})]
        public Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.IParticipantRoleChoice ParticipantRoleChoice {
            get { return this.participantRoleChoice; }
            set { this.participantRoleChoice = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: BaseModel.ParticipantRole.classCode 
         * Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"classCode"})]
        public CodedTypeR2<RoleClassRoot> ClassCode {
            get { return (CodedTypeR2<RoleClassRoot>) this.classCode.Value; }
            set { this.classCode.Value = value; }
        }

    }

}