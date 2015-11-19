/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"BaseModel.Patient"})]
    public class Patient : MessagePartBean {

        private LIST<CS_R2<Code>, CodedTypeR2<Code>> realmCode;
        private II typeId;
        private LIST<II, Identifier> templateId;
        private II id;
        private LIST<PN, PersonName> name;
        private CE_R2<Code> administrativeGenderCode;
        private TS_R2 birthTime;
        private CE_R2<Code> maritalStatusCode;
        private CE_R2<Code> religiousAffiliationCode;
        private CE_R2<Code> raceCode;
        private CE_R2<Code> ethnicGroupCode;
        private IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Guardian> guardian;
        private Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Birthplace birthplace;
        private IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.LanguageCommunication> languageCommunication;

        public Patient() {
            this.realmCode = new LISTImpl<CS_R2<Code>, CodedTypeR2<Code>>(typeof(CS_R2Impl<Code>));
            this.typeId = new IIImpl();
            this.templateId = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.id = new IIImpl();
            this.name = new LISTImpl<PN, PersonName>(typeof(PNImpl));
            this.administrativeGenderCode = new CE_R2Impl<Code>();
            this.birthTime = new TS_R2Impl();
            this.maritalStatusCode = new CE_R2Impl<Code>();
            this.religiousAffiliationCode = new CE_R2Impl<Code>();
            this.raceCode = new CE_R2Impl<Code>();
            this.ethnicGroupCode = new CE_R2Impl<Code>();
            this.guardian = new List<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Guardian>();
            this.languageCommunication = new List<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.LanguageCommunication>();
        }
        /**
         * <summary>Relationship: BaseModel.Patient.realmCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"realmCode"})]
        public IList<CodedTypeR2<Code>> RealmCode {
            get { return this.realmCode.RawList<CodedTypeR2<Code>>(); }
        }

        /**
         * <summary>Relationship: BaseModel.Patient.typeId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"typeId"})]
        public Identifier TypeId {
            get { return this.typeId.Value; }
            set { this.typeId.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.Patient.templateId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"templateId"})]
        public IList<Identifier> TemplateId {
            get { return this.templateId.RawList(); }
        }

        /**
         * <summary>Relationship: BaseModel.Patient.id</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.Patient.name</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"name"})]
        public IList<PersonName> Name {
            get { return this.name.RawList(); }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.Patient.administrativeGenderCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"administrativeGenderCode"})]
        public CodedTypeR2<Code> AdministrativeGenderCode {
            get { return (CodedTypeR2<Code>) this.administrativeGenderCode.Value; }
            set { this.administrativeGenderCode.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.Patient.birthTime</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"birthTime"})]
        public MbDate BirthTime {
            get { return this.birthTime.Value; }
            set { this.birthTime.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.Patient.maritalStatusCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"maritalStatusCode"})]
        public CodedTypeR2<Code> MaritalStatusCode {
            get { return (CodedTypeR2<Code>) this.maritalStatusCode.Value; }
            set { this.maritalStatusCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.Patient.religiousAffiliationCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"religiousAffiliationCode"})]
        public CodedTypeR2<Code> ReligiousAffiliationCode {
            get { return (CodedTypeR2<Code>) this.religiousAffiliationCode.Value; }
            set { this.religiousAffiliationCode.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.Patient.raceCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"raceCode"})]
        public CodedTypeR2<Code> RaceCode {
            get { return (CodedTypeR2<Code>) this.raceCode.Value; }
            set { this.raceCode.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.Patient.ethnicGroupCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"ethnicGroupCode"})]
        public CodedTypeR2<Code> EthnicGroupCode {
            get { return (CodedTypeR2<Code>) this.ethnicGroupCode.Value; }
            set { this.ethnicGroupCode.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.Patient.guardian</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"guardian"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Guardian> Guardian {
            get { return this.guardian; }
        }

        /**
         * <summary>Relationship: BaseModel.Patient.birthplace</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"birthplace"})]
        public Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Birthplace Birthplace {
            get { return this.birthplace; }
            set { this.birthplace = value; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.Patient.languageCommunication</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"languageCommunication"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.LanguageCommunication> LanguageCommunication {
            get { return this.languageCommunication; }
        }

    }

}