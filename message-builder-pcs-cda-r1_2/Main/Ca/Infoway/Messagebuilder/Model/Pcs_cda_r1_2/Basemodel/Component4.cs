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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using System;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"BaseModel.Component4"})]
    public class Component4 : MessagePartBean {

        private LIST<CS, Code> realmCode;
        private II typeId;
        private LIST<II, Identifier> templateId;
        private INT sequenceNumber;
        private BL seperatableInd;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.IComponent4Choice component4Choice;

        public Component4() {
            this.realmCode = new LISTImpl<CS, Code>(typeof(CSImpl));
            this.typeId = new IIImpl();
            this.templateId = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.sequenceNumber = new INTImpl();
            this.seperatableInd = new BLImpl();
        }
        /**
         * <summary>Relationship: BaseModel.Component4.realmCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"realmCode"})]
        public IList<Code> RealmCode {
            get { return this.realmCode.RawList<Code>(); }
        }

        /**
         * <summary>Relationship: BaseModel.Component4.typeId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"typeId"})]
        public Identifier TypeId {
            get { return this.typeId.Value; }
            set { this.typeId.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.Component4.templateId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"templateId"})]
        public IList<Identifier> TemplateId {
            get { return this.templateId.RawList(); }
        }

        /**
         * <summary>Relationship: BaseModel.Component4.sequenceNumber</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"sequenceNumber"})]
        public int? SequenceNumber {
            get { return this.sequenceNumber.Value; }
            set { this.sequenceNumber.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.Component4.seperatableInd</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"seperatableInd"})]
        public bool? SeperatableInd {
            get { return this.seperatableInd.Value; }
            set { this.seperatableInd.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.Component4.component4Choice</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component4Choice"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.IComponent4Choice Component4Choice {
            get { return this.component4Choice; }
            set { this.component4Choice = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Act Component4ChoiceAsAct {
            get { return this.component4Choice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Act ? (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Act) this.component4Choice : (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Act) null; }
        }
        public bool HasComponent4ChoiceAsAct() {
            return (this.component4Choice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Act);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Encounter Component4ChoiceAsEncounter {
            get { return this.component4Choice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Encounter ? (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Encounter) this.component4Choice : (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Encounter) null; }
        }
        public bool HasComponent4ChoiceAsEncounter() {
            return (this.component4Choice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Encounter);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Observation Component4ChoiceAsObservation {
            get { return this.component4Choice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Observation ? (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Observation) this.component4Choice : (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Observation) null; }
        }
        public bool HasComponent4ChoiceAsObservation() {
            return (this.component4Choice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Observation);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.ObservationMedia Component4ChoiceAsObservationMedia {
            get { return this.component4Choice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.ObservationMedia ? (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.ObservationMedia) this.component4Choice : (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.ObservationMedia) null; }
        }
        public bool HasComponent4ChoiceAsObservationMedia() {
            return (this.component4Choice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.ObservationMedia);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Organizer Component4ChoiceAsOrganizer {
            get { return this.component4Choice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Organizer ? (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Organizer) this.component4Choice : (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Organizer) null; }
        }
        public bool HasComponent4ChoiceAsOrganizer() {
            return (this.component4Choice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Organizer);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Procedure Component4ChoiceAsProcedure {
            get { return this.component4Choice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Procedure ? (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Procedure) this.component4Choice : (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Procedure) null; }
        }
        public bool HasComponent4ChoiceAsProcedure() {
            return (this.component4Choice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Procedure);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.RegionOfInterest Component4ChoiceAsRegionOfInterest {
            get { return this.component4Choice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.RegionOfInterest ? (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.RegionOfInterest) this.component4Choice : (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.RegionOfInterest) null; }
        }
        public bool HasComponent4ChoiceAsRegionOfInterest() {
            return (this.component4Choice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.RegionOfInterest);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.SubstanceAdministration Component4ChoiceAsSubstanceAdministration {
            get { return this.component4Choice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.SubstanceAdministration ? (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.SubstanceAdministration) this.component4Choice : (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.SubstanceAdministration) null; }
        }
        public bool HasComponent4ChoiceAsSubstanceAdministration() {
            return (this.component4Choice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.SubstanceAdministration);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Supply Component4ChoiceAsSupply {
            get { return this.component4Choice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Supply ? (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Supply) this.component4Choice : (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Supply) null; }
        }
        public bool HasComponent4ChoiceAsSupply() {
            return (this.component4Choice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Supply);
        }

    }

}