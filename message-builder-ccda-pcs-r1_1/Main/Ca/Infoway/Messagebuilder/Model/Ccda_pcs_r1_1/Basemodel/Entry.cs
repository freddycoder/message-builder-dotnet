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
namespace Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Domainvalue;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"BaseModel.Entry"})]
    public class Entry : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Functionalstatussection.IEntryChoice, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Assessmentandplansection.IEntryChoice, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Procedureindicationssection.IEntryChoice, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Plannedproceduresection.IEntryChoice, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Anesthesiasection.IEntryChoice, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Preoperativediagnosissection.IEntryChoice, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Hospitaladmissionmedicationssectionentriesoptional.IEntryChoice, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.IEntryChoice_8, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.IEntryChoice_10, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Payerssection.IEntryChoice, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.IEntryChoice_9, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.IEntryChoice_7, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Postprocedurediagnosissection.IEntryChoice, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Medicalequipmentsection.IEntryChoice, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.IEntryChoice_6, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.IEntryChoice_5, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.IEntryChoice_4, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.IEntryChoice_3, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Familyhistorysection.IEntryChoice, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.IEntryChoice_2, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Physicalexamsection.IEntryChoice, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.IEntryChoice_1, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Planofcaresection.IEntryChoice, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Socialhistorysection.IEntryChoice {

        private CS typeCode;
        private LIST<CS, Code> realmCode;
        private II typeId;
        private LIST<II, Identifier> templateId;
        private Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.IEntryChoice entryChoice;

        public Entry() {
            this.typeCode = new CSImpl();
            this.realmCode = new LISTImpl<CS, Code>(typeof(CSImpl));
            this.typeId = new IIImpl();
            this.templateId = new LISTImpl<II, Identifier>(typeof(IIImpl));
        }
        /**
         * <summary>Relationship: BaseModel.Entry.typeCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"typeCode"})]
        public x_ActRelationshipEntry TypeCode {
            get { return (x_ActRelationshipEntry) this.typeCode.Value; }
            set { this.typeCode.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.Entry.realmCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"realmCode"})]
        public IList<Code> RealmCode {
            get { return this.realmCode.RawList<Code>(); }
        }

        /**
         * <summary>Relationship: BaseModel.Entry.typeId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"typeId"})]
        public Identifier TypeId {
            get { return this.typeId.Value; }
            set { this.typeId.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.Entry.templateId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"templateId"})]
        public IList<Identifier> TemplateId {
            get { return this.templateId.RawList(); }
        }

        /**
         * <summary>Relationship: BaseModel.Entry.entryChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"entryChoice"})]
        public Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.IEntryChoice EntryChoice {
            get { return this.entryChoice; }
            set { this.entryChoice = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Act EntryChoiceAsAct {
            get { return this.entryChoice is Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Act ? (Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Act) this.entryChoice : (Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Act) null; }
        }
        public bool HasEntryChoiceAsAct() {
            return (this.entryChoice is Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Act);
        }

        public Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Encounter EntryChoiceAsEncounter {
            get { return this.entryChoice is Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Encounter ? (Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Encounter) this.entryChoice : (Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Encounter) null; }
        }
        public bool HasEntryChoiceAsEncounter() {
            return (this.entryChoice is Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Encounter);
        }

        public Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Observation EntryChoiceAsObservation {
            get { return this.entryChoice is Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Observation ? (Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Observation) this.entryChoice : (Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Observation) null; }
        }
        public bool HasEntryChoiceAsObservation() {
            return (this.entryChoice is Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Observation);
        }

        public Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.ObservationMedia EntryChoiceAsObservationMedia {
            get { return this.entryChoice is Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.ObservationMedia ? (Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.ObservationMedia) this.entryChoice : (Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.ObservationMedia) null; }
        }
        public bool HasEntryChoiceAsObservationMedia() {
            return (this.entryChoice is Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.ObservationMedia);
        }

        public Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Organizer EntryChoiceAsOrganizer {
            get { return this.entryChoice is Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Organizer ? (Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Organizer) this.entryChoice : (Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Organizer) null; }
        }
        public bool HasEntryChoiceAsOrganizer() {
            return (this.entryChoice is Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Organizer);
        }

        public Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Procedure EntryChoiceAsProcedure {
            get { return this.entryChoice is Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Procedure ? (Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Procedure) this.entryChoice : (Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Procedure) null; }
        }
        public bool HasEntryChoiceAsProcedure() {
            return (this.entryChoice is Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Procedure);
        }

        public Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.RegionOfInterest EntryChoiceAsRegionOfInterest {
            get { return this.entryChoice is Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.RegionOfInterest ? (Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.RegionOfInterest) this.entryChoice : (Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.RegionOfInterest) null; }
        }
        public bool HasEntryChoiceAsRegionOfInterest() {
            return (this.entryChoice is Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.RegionOfInterest);
        }

        public Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.SubstanceAdministration EntryChoiceAsSubstanceAdministration {
            get { return this.entryChoice is Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.SubstanceAdministration ? (Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.SubstanceAdministration) this.entryChoice : (Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.SubstanceAdministration) null; }
        }
        public bool HasEntryChoiceAsSubstanceAdministration() {
            return (this.entryChoice is Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.SubstanceAdministration);
        }

        public Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Supply EntryChoiceAsSupply {
            get { return this.entryChoice is Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Supply ? (Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Supply) this.entryChoice : (Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Supply) null; }
        }
        public bool HasEntryChoiceAsSupply() {
            return (this.entryChoice is Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Supply);
        }

    }

}