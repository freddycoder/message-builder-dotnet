/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged;
    using System;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"BaseModel.ClinicalDocument"})]
    public class BaseModel : MessagePartBean {

        private LIST<CS_R2<Code>, CodedTypeR2<Code>> realmCode;
        private II typeId;
        private LIST<II, Identifier> templateId;
        private II id;
        private CE_R2<Code> code;
        private ST title;
        private TS_R2 effectiveTime;
        private CE_R2<Code> confidentialityCode;
        private CS_R2<Code> languageCode;
        private II setId;
        private INT versionNumber;
        private TS_R2 copyTime;
        private IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.RecordTarget> recordTarget;
        private IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Author> author;
        private Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.DataEnterer dataEnterer;
        private IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.Informant12> informant;
        private Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Custodian custodian;
        private IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.InformationRecipient> informationRecipient;
        private Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.LegalAuthenticator legalAuthenticator;
        private IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Authenticator> authenticator;
        private IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.Participant1> participant;
        private IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.InFulfillmentOf> inFulfillmentOf;
        private IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.DocumentationOf> documentationOf;
        private IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.RelatedDocument> relatedDocument;
        private IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.Authorization> authorization;
        private Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.Component1 componentOf;
        private Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Component2 component;

        public BaseModel() {
            this.realmCode = new LISTImpl<CS_R2<Code>, CodedTypeR2<Code>>(typeof(CS_R2Impl<Code>));
            this.typeId = new IIImpl();
            this.templateId = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.id = new IIImpl();
            this.code = new CE_R2Impl<Code>();
            this.title = new STImpl();
            this.effectiveTime = new TS_R2Impl();
            this.confidentialityCode = new CE_R2Impl<Code>();
            this.languageCode = new CS_R2Impl<Code>();
            this.setId = new IIImpl();
            this.versionNumber = new INTImpl();
            this.copyTime = new TS_R2Impl();
            this.recordTarget = new List<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.RecordTarget>();
            this.author = new List<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Author>();
            this.informant = new List<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.Informant12>();
            this.informationRecipient = new List<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.InformationRecipient>();
            this.authenticator = new List<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Authenticator>();
            this.participant = new List<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.Participant1>();
            this.inFulfillmentOf = new List<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.InFulfillmentOf>();
            this.documentationOf = new List<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.DocumentationOf>();
            this.relatedDocument = new List<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.RelatedDocument>();
            this.authorization = new List<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.Authorization>();
        }
        /**
         * <summary>Relationship: BaseModel.ClinicalDocument.realmCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"realmCode"})]
        public IList<CodedTypeR2<Code>> RealmCode {
            get { return this.realmCode.RawList<CodedTypeR2<Code>>(); }
        }

        /**
         * <summary>Relationship: BaseModel.ClinicalDocument.typeId</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"typeId"})]
        public Identifier TypeId {
            get { return this.typeId.Value; }
            set { this.typeId.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.ClinicalDocument.templateId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"templateId"})]
        public IList<Identifier> TemplateId {
            get { return this.templateId.RawList(); }
        }

        /**
         * <summary>Relationship: BaseModel.ClinicalDocument.id</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.ClinicalDocument.code</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public CodedTypeR2<Code> Code {
            get { return (CodedTypeR2<Code>) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.ClinicalDocument.title</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"title"})]
        public String Title {
            get { return this.title.Value; }
            set { this.title.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ClinicalDocument.effectiveTime</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public MbDate EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ClinicalDocument.confidentialityCode</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public CodedTypeR2<Code> ConfidentialityCode {
            get { return (CodedTypeR2<Code>) this.confidentialityCode.Value; }
            set { this.confidentialityCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ClinicalDocument.languageCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"languageCode"})]
        public CodedTypeR2<Code> LanguageCode {
            get { return (CodedTypeR2<Code>) this.languageCode.Value; }
            set { this.languageCode.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.ClinicalDocument.setId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"setId"})]
        public Identifier SetId {
            get { return this.setId.Value; }
            set { this.setId.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ClinicalDocument.versionNumber</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"versionNumber"})]
        public int? VersionNumber {
            get { return this.versionNumber.Value; }
            set { this.versionNumber.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.ClinicalDocument.copyTime</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"copyTime"})]
        public MbDate CopyTime {
            get { return this.copyTime.Value; }
            set { this.copyTime.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ClinicalDocument.recordTarget</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"recordTarget"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.RecordTarget> RecordTarget {
            get { return this.recordTarget; }
        }

        /**
         * <summary>Relationship: BaseModel.ClinicalDocument.author</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Author> Author {
            get { return this.author; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ClinicalDocument.dataEnterer</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"dataEnterer"})]
        public Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.DataEnterer DataEnterer {
            get { return this.dataEnterer; }
            set { this.dataEnterer = value; }
        }

        /**
         * <summary>Relationship: BaseModel.ClinicalDocument.informant</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"informant"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.Informant12> Informant {
            get { return this.informant; }
        }

        /**
         * <summary>Relationship: BaseModel.ClinicalDocument.custodian</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"custodian"})]
        public Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Custodian Custodian {
            get { return this.custodian; }
            set { this.custodian = value; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ClinicalDocument.informationRecipient</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"informationRecipient"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.InformationRecipient> InformationRecipient {
            get { return this.informationRecipient; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ClinicalDocument.legalAuthenticator</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"legalAuthenticator"})]
        public Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.LegalAuthenticator LegalAuthenticator {
            get { return this.legalAuthenticator; }
            set { this.legalAuthenticator = value; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ClinicalDocument.authenticator</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"authenticator"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Authenticator> Authenticator {
            get { return this.authenticator; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ClinicalDocument.participant</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"participant"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.Participant1> Participant {
            get { return this.participant; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ClinicalDocument.inFulfillmentOf</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"inFulfillmentOf"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.InFulfillmentOf> InFulfillmentOf {
            get { return this.inFulfillmentOf; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ClinicalDocument.documentationOf</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"documentationOf"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.DocumentationOf> DocumentationOf {
            get { return this.documentationOf; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ClinicalDocument.relatedDocument</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"relatedDocument"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.RelatedDocument> RelatedDocument {
            get { return this.relatedDocument; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ClinicalDocument.authorization</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"authorization"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.Authorization> Authorization {
            get { return this.authorization; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ClinicalDocument.componentOf</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"componentOf"})]
        public Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged.Component1 ComponentOf {
            get { return this.componentOf; }
            set { this.componentOf = value; }
        }

        /**
         * <summary>Relationship: BaseModel.ClinicalDocument.component</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component"})]
        public Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.Component2 Component {
            get { return this.component; }
            set { this.component = value; }
        }

    }

}