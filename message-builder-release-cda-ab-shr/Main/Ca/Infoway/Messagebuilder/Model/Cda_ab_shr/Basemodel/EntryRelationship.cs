/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Domainvalue;
    using System;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"BaseModel.EntryRelationship"})]
    public class EntryRelationship : MessagePartBean {

        private CS_R2<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Domainvalue.x_ActRelationshipEntryRelationship> typeCode;
        private BL inversionInd;
        private BL contextConductionInd;
        private BL negationInd;
        private LIST<CS_R2<Code>, CodedTypeR2<Code>> realmCode;
        private II typeId;
        private LIST<II, Identifier> templateId;
        private INT sequenceNumber;
        private BL seperatableInd;
        private Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.IEntryRelationshipChoice entryRelationshipChoice;

        public EntryRelationship() {
            this.typeCode = new CS_R2Impl<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Domainvalue.x_ActRelationshipEntryRelationship>();
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
         * <summary>Relationship: BaseModel.EntryRelationship.typeCode</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"typeCode"})]
        public CodedTypeR2<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Domainvalue.x_ActRelationshipEntryRelationship> TypeCode {
            get { return (CodedTypeR2<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Domainvalue.x_ActRelationshipEntryRelationship>) this.typeCode.Value; }
            set { this.typeCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.EntryRelationship.inversionInd</summary>
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
         * BaseModel.EntryRelationship.contextConductionInd</summary>
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
         * BaseModel.EntryRelationship.negationInd</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"negationInd"})]
        public bool? NegationInd {
            get { return this.negationInd.Value; }
            set { this.negationInd.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.EntryRelationship.realmCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"realmCode"})]
        public IList<CodedTypeR2<Code>> RealmCode {
            get { return this.realmCode.RawList<CodedTypeR2<Code>>(); }
        }

        /**
         * <summary>Relationship: BaseModel.EntryRelationship.typeId</summary>
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
         * BaseModel.EntryRelationship.templateId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"templateId"})]
        public IList<Identifier> TemplateId {
            get { return this.templateId.RawList(); }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.EntryRelationship.sequenceNumber</summary>
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
         * BaseModel.EntryRelationship.seperatableInd</summary>
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
         * BaseModel.EntryRelationship.entryRelationshipChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"entryRelationshipChoice"})]
        public Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.IEntryRelationshipChoice EntryRelationshipChoice {
            get { return this.entryRelationshipChoice; }
            set { this.entryRelationshipChoice = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Act EntryRelationshipChoiceAsAct {
            get { return this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Act ? (Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Act) this.entryRelationshipChoice : (Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Act) null; }
        }
        public bool HasEntryRelationshipChoiceAsAct() {
            return (this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Act);
        }

        public Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Encounter EntryRelationshipChoiceAsEncounter {
            get { return this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Encounter ? (Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Encounter) this.entryRelationshipChoice : (Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Encounter) null; }
        }
        public bool HasEntryRelationshipChoiceAsEncounter() {
            return (this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Encounter);
        }

        public Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Observation EntryRelationshipChoiceAsObservation {
            get { return this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Observation ? (Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Observation) this.entryRelationshipChoice : (Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Observation) null; }
        }
        public bool HasEntryRelationshipChoiceAsObservation() {
            return (this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Observation);
        }

        public Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.ObservationMedia EntryRelationshipChoiceAsObservationMedia {
            get { return this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.ObservationMedia ? (Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.ObservationMedia) this.entryRelationshipChoice : (Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.ObservationMedia) null; }
        }
        public bool HasEntryRelationshipChoiceAsObservationMedia() {
            return (this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.ObservationMedia);
        }

        public Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Organizer EntryRelationshipChoiceAsOrganizer {
            get { return this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Organizer ? (Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Organizer) this.entryRelationshipChoice : (Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Organizer) null; }
        }
        public bool HasEntryRelationshipChoiceAsOrganizer() {
            return (this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Organizer);
        }

        public Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Procedure EntryRelationshipChoiceAsProcedure {
            get { return this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Procedure ? (Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Procedure) this.entryRelationshipChoice : (Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Procedure) null; }
        }
        public bool HasEntryRelationshipChoiceAsProcedure() {
            return (this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Procedure);
        }

        public Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.RegionOfInterest EntryRelationshipChoiceAsRegionOfInterest {
            get { return this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.RegionOfInterest ? (Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.RegionOfInterest) this.entryRelationshipChoice : (Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.RegionOfInterest) null; }
        }
        public bool HasEntryRelationshipChoiceAsRegionOfInterest() {
            return (this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.RegionOfInterest);
        }

        public Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.SubstanceAdministration EntryRelationshipChoiceAsSubstanceAdministration {
            get { return this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.SubstanceAdministration ? (Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.SubstanceAdministration) this.entryRelationshipChoice : (Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.SubstanceAdministration) null; }
        }
        public bool HasEntryRelationshipChoiceAsSubstanceAdministration() {
            return (this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.SubstanceAdministration);
        }

        public Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Supply EntryRelationshipChoiceAsSupply {
            get { return this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Supply ? (Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Supply) this.entryRelationshipChoice : (Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Supply) null; }
        }
        public bool HasEntryRelationshipChoiceAsSupply() {
            return (this.entryRelationshipChoice is Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Supply);
        }

    }

}