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
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"AllergyIntoleranceObservation.PlayingEntity","BaseModel.PlayingEntity","SubstanceOrDeviceAllergyIntoleranceObservation.PlayingEntity"})]
    public class PlayingEntity_2 : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.IParticipantRoleChoice {

        private LIST<CS_R2<Code>, CodedTypeR2<Code>> realmCode;
        private II typeId;
        private LIST<II, Identifier> templateId;
        private CE_R2<Code> code;
        private LIST<PQ, PhysicalQuantity> quantity;
        private LIST<PN, PersonName> name;
        private TS_R2 birthTime;
        private ED<EncapsulatedData> desc;
        private CS_R2<EntityClassRoot> classCode;

        public PlayingEntity_2() {
            this.realmCode = new LISTImpl<CS_R2<Code>, CodedTypeR2<Code>>(typeof(CS_R2Impl<Code>));
            this.typeId = new IIImpl();
            this.templateId = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.code = new CE_R2Impl<Code>();
            this.quantity = new LISTImpl<PQ, PhysicalQuantity>(typeof(PQImpl));
            this.name = new LISTImpl<PN, PersonName>(typeof(PNImpl));
            this.birthTime = new TS_R2Impl();
            this.desc = new EDImpl<EncapsulatedData>();
            this.classCode = new CS_R2Impl<EntityClassRoot>();
        }
        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * SubstanceOrDeviceAllergyIntoleranceObservation.PlayingEntity.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * AllergyIntoleranceObservation.PlayingEntity.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * BaseModel.PlayingEntity.realmCode Conformance/Cardinality: 
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
         * SubstanceOrDeviceAllergyIntoleranceObservation.PlayingEntity.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * AllergyIntoleranceObservation.PlayingEntity.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * BaseModel.PlayingEntity.typeId Conformance/Cardinality: 
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
         * SubstanceOrDeviceAllergyIntoleranceObservation.PlayingEntity.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * AllergyIntoleranceObservation.PlayingEntity.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * BaseModel.PlayingEntity.templateId Conformance/Cardinality: 
         * OPTIONAL (0-*)</remarks>
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
         * SubstanceOrDeviceAllergyIntoleranceObservation.PlayingEntity.code 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * AllergyIntoleranceObservation.PlayingEntity.code 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * BaseModel.PlayingEntity.code Conformance/Cardinality: 
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
         * SubstanceOrDeviceAllergyIntoleranceObservation.PlayingEntity.quantity 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * AllergyIntoleranceObservation.PlayingEntity.quantity 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * BaseModel.PlayingEntity.quantity Conformance/Cardinality: 
         * OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"quantity"})]
        public IList<PhysicalQuantity> Quantity {
            get { return this.quantity.RawList(); }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * SubstanceOrDeviceAllergyIntoleranceObservation.PlayingEntity.name 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * AllergyIntoleranceObservation.PlayingEntity.name 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * BaseModel.PlayingEntity.name Conformance/Cardinality: 
         * OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"name"})]
        public IList<PersonName> Name {
            get { return this.name.RawList(); }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * SubstanceOrDeviceAllergyIntoleranceObservation.PlayingEntity.birthTime 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * AllergyIntoleranceObservation.PlayingEntity.birthTime 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * BaseModel.PlayingEntity.birthTime Conformance/Cardinality: 
         * OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"birthTime"})]
        public MbDate BirthTime {
            get { return this.birthTime.Value; }
            set { this.birthTime.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * SubstanceOrDeviceAllergyIntoleranceObservation.PlayingEntity.desc 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * AllergyIntoleranceObservation.PlayingEntity.desc 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * BaseModel.PlayingEntity.desc Conformance/Cardinality: 
         * OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"desc"})]
        public EncapsulatedData Desc {
            get { return this.desc.Value; }
            set { this.desc.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: BaseModel.PlayingEntity.classCode 
         * Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"classCode"})]
        public CodedTypeR2<EntityClassRoot> ClassCode {
            get { return (CodedTypeR2<EntityClassRoot>) this.classCode.Value; }
            set { this.classCode.Value = value; }
        }

    }

}