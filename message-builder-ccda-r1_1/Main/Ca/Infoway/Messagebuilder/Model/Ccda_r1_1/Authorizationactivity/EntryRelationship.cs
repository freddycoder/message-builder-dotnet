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
namespace Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Authorizationactivity {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel;
    using System;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"AuthorizationActivity.EntryRelationship"})]
    public class EntryRelationship : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Authorizationactivity.IEntryRelationshipChoice {

        private BL inversionInd;
        private BL contextConductionInd;
        private BL negationInd;
        private LIST<CS_R2<Code>, CodedTypeR2<Code>> realmCode;
        private II typeId;
        private LIST<II, Identifier> templateId;
        private INT sequenceNumber;
        private BL seperatableInd;
        private Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.IEntryRelationshipChoice entryRelationshipChoice;

        public EntryRelationship() {
            this.inversionInd = new BLImpl();
            this.contextConductionInd = new BLImpl();
            this.negationInd = new BLImpl();
            this.realmCode = new LISTImpl<CS_R2<Code>, CodedTypeR2<Code>>(typeof(CS_R2Impl<Code>));
            this.typeId = new IIImpl();
            this.templateId = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.sequenceNumber = new INTImpl();
            this.seperatableInd = new BLImpl();
        }
        /**
         * <summary>Relationship: 
         * AuthorizationActivity.EntryRelationship.inversionInd</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"inversionInd"})]
        public bool? InversionInd {
            get { return this.inversionInd.Value; }
            set { this.inversionInd.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * AuthorizationActivity.EntryRelationship.contextConductionInd</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"contextConductionInd"})]
        public bool? ContextConductionInd {
            get { return this.contextConductionInd.Value; }
            set { this.contextConductionInd.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * AuthorizationActivity.EntryRelationship.negationInd</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"negationInd"})]
        public bool? NegationInd {
            get { return this.negationInd.Value; }
            set { this.negationInd.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * AuthorizationActivity.EntryRelationship.realmCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"realmCode"})]
        public IList<CodedTypeR2<Code>> RealmCode {
            get { return this.realmCode.RawList<CodedTypeR2<Code>>(); }
        }

        /**
         * <summary>Relationship: 
         * AuthorizationActivity.EntryRelationship.typeId</summary>
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
         * AuthorizationActivity.EntryRelationship.templateId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"templateId"})]
        public IList<Identifier> TemplateId {
            get { return this.templateId.RawList(); }
        }

        /**
         * <summary>Relationship: 
         * AuthorizationActivity.EntryRelationship.sequenceNumber</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"sequenceNumber"})]
        public int? SequenceNumber {
            get { return this.sequenceNumber.Value; }
            set { this.sequenceNumber.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * AuthorizationActivity.EntryRelationship.seperatableInd</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"seperatableInd"})]
        public bool? SeperatableInd {
            get { return this.seperatableInd.Value; }
            set { this.seperatableInd.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * AuthorizationActivity.EntryRelationship.entryRelationshipChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"entryRelationshipChoice"})]
        public Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.IEntryRelationshipChoice EntryRelationshipChoice {
            get { return this.entryRelationshipChoice; }
            set { this.entryRelationshipChoice = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Act EntryRelationshipChoiceAsAct {
            get { return this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Act ? (Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Act) this.entryRelationshipChoice : (Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Act) null; }
        }
        public bool HasEntryRelationshipChoiceAsAct() {
            return (this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Act);
        }

        public Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Encounter EntryRelationshipChoiceAsEncounter {
            get { return this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Encounter ? (Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Encounter) this.entryRelationshipChoice : (Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Encounter) null; }
        }
        public bool HasEntryRelationshipChoiceAsEncounter() {
            return (this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Encounter);
        }

        public Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Observation EntryRelationshipChoiceAsObservation {
            get { return this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Observation ? (Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Observation) this.entryRelationshipChoice : (Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Observation) null; }
        }
        public bool HasEntryRelationshipChoiceAsObservation() {
            return (this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Observation);
        }

        public Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.ObservationMedia EntryRelationshipChoiceAsObservationMedia {
            get { return this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.ObservationMedia ? (Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.ObservationMedia) this.entryRelationshipChoice : (Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.ObservationMedia) null; }
        }
        public bool HasEntryRelationshipChoiceAsObservationMedia() {
            return (this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.ObservationMedia);
        }

        public Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Organizer EntryRelationshipChoiceAsOrganizer {
            get { return this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Organizer ? (Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Organizer) this.entryRelationshipChoice : (Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Organizer) null; }
        }
        public bool HasEntryRelationshipChoiceAsOrganizer() {
            return (this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Organizer);
        }

        public Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Procedure EntryRelationshipChoiceAsProcedure {
            get { return this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Procedure ? (Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Procedure) this.entryRelationshipChoice : (Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Procedure) null; }
        }
        public bool HasEntryRelationshipChoiceAsProcedure() {
            return (this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Procedure);
        }

        public Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.RegionOfInterest EntryRelationshipChoiceAsRegionOfInterest {
            get { return this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.RegionOfInterest ? (Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.RegionOfInterest) this.entryRelationshipChoice : (Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.RegionOfInterest) null; }
        }
        public bool HasEntryRelationshipChoiceAsRegionOfInterest() {
            return (this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.RegionOfInterest);
        }

        public Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.SubstanceAdministration EntryRelationshipChoiceAsSubstanceAdministration {
            get { return this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.SubstanceAdministration ? (Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.SubstanceAdministration) this.entryRelationshipChoice : (Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.SubstanceAdministration) null; }
        }
        public bool HasEntryRelationshipChoiceAsSubstanceAdministration() {
            return (this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.SubstanceAdministration);
        }

        public Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Supply EntryRelationshipChoiceAsSupply {
            get { return this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Supply ? (Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Supply) this.entryRelationshipChoice : (Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Supply) null; }
        }
        public bool HasEntryRelationshipChoiceAsSupply() {
            return (this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Supply);
        }

    }

}