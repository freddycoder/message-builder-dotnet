/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged;
    using System;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"BaseModel.ObservationMedia"})]
    public class ObservationMedia : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.IEntryChoice, Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.IComponent4Choice, Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.IEntryRelationshipChoice {

        private ST iD;
        private CS_R2<ActClassObservation> classCode;
        private CS_R2<ActMood> moodCode;
        private LIST<CS_R2<Code>, CodedTypeR2<Code>> realmCode;
        private II typeId;
        private LIST<II, Identifier> templateId;
        private LIST<II, Identifier> id;
        private CS_R2<Code> languageCode;
        private ED<EncapsulatedData> value;
        private Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Subject subject;
        private IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Specimen> specimen;
        private IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.Performer1> performer;
        private IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Author> author;
        private IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.Informant12> informant;
        private IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.Participant1> participant;
        private IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.EntryRelationship> entryRelationship;
        private IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Reference> reference;
        private IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Precondition> precondition;

        public ObservationMedia() {
            this.iD = new STImpl();
            this.classCode = new CS_R2Impl<ActClassObservation>();
            this.moodCode = new CS_R2Impl<ActMood>();
            this.realmCode = new LISTImpl<CS_R2<Code>, CodedTypeR2<Code>>(typeof(CS_R2Impl<Code>));
            this.typeId = new IIImpl();
            this.templateId = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.id = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.languageCode = new CS_R2Impl<Code>();
            this.value = new EDImpl<EncapsulatedData>();
            this.specimen = new List<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Specimen>();
            this.performer = new List<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.Performer1>();
            this.author = new List<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Author>();
            this.informant = new List<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.Informant12>();
            this.participant = new List<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.Participant1>();
            this.entryRelationship = new List<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.EntryRelationship>();
            this.reference = new List<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Reference>();
            this.precondition = new List<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Precondition>();
        }
        /**
         * <summary>Relationship: BaseModel.ObservationMedia.ID</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"ID"})]
        public String ID {
            get { return this.iD.Value; }
            set { this.iD.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.ObservationMedia.classCode</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"classCode"})]
        public CodedTypeR2<ActClassObservation> ClassCode {
            get { return (CodedTypeR2<ActClassObservation>) this.classCode.Value; }
            set { this.classCode.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.ObservationMedia.moodCode</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"moodCode"})]
        public CodedTypeR2<ActMood> MoodCode {
            get { return (CodedTypeR2<ActMood>) this.moodCode.Value; }
            set { this.moodCode.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.ObservationMedia.realmCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"realmCode"})]
        public IList<CodedTypeR2<Code>> RealmCode {
            get { return this.realmCode.RawList<CodedTypeR2<Code>>(); }
        }

        /**
         * <summary>Relationship: BaseModel.ObservationMedia.typeId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"typeId"})]
        public Identifier TypeId {
            get { return this.typeId.Value; }
            set { this.typeId.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.ObservationMedia.templateId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"templateId"})]
        public IList<Identifier> TemplateId {
            get { return this.templateId.RawList(); }
        }

        /**
         * <summary>Relationship: BaseModel.ObservationMedia.id</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public IList<Identifier> Id {
            get { return this.id.RawList(); }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ObservationMedia.languageCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"languageCode"})]
        public CodedTypeR2<Code> LanguageCode {
            get { return (CodedTypeR2<Code>) this.languageCode.Value; }
            set { this.languageCode.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.ObservationMedia.value</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public EncapsulatedData Value {
            get { return this.value.Value; }
            set { this.value.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.ObservationMedia.subject</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject"})]
        public Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Subject Subject {
            get { return this.subject; }
            set { this.subject = value; }
        }

        /**
         * <summary>Relationship: BaseModel.ObservationMedia.specimen</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"specimen"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Specimen> Specimen {
            get { return this.specimen; }
        }

        /**
         * <summary>Relationship: BaseModel.ObservationMedia.performer</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"performer"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.Performer1> Performer {
            get { return this.performer; }
        }

        /**
         * <summary>Relationship: BaseModel.ObservationMedia.author</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Author> Author {
            get { return this.author; }
        }

        /**
         * <summary>Relationship: BaseModel.ObservationMedia.informant</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"informant"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.Informant12> Informant {
            get { return this.informant; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ObservationMedia.participant</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"participant"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.Participant1> Participant {
            get { return this.participant; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ObservationMedia.entryRelationship</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"entryRelationship"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.EntryRelationship> EntryRelationship {
            get { return this.entryRelationship; }
        }

        /**
         * <summary>Relationship: BaseModel.ObservationMedia.reference</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reference"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Reference> Reference {
            get { return this.reference; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ObservationMedia.precondition</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"precondition"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Precondition> Precondition {
            get { return this.precondition; }
        }

    }

}