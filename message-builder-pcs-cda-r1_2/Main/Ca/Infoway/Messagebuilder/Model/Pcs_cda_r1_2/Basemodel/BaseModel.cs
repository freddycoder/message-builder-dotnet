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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */


/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Merged;
    using System;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"BaseModel.ClinicalDocument"})]
    public class BaseModel : MessagePartBean {

        private II typeId;
        private LIST<II, Identifier> templateId;
        private II id;
        private CE code;
        private ST title;
        private TSCDAR1 effectiveTime;
        private CE confidentialityCode;
        private CS languageCode;
        private II setId;
        private INT versionNumber;
        private TSCDAR1 copyTime;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.RecordTarget> recordTarget;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Author> author;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.DataEnterer dataEnterer;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Merged.Informant12> informant;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Merged.Custodian custodian;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.InformationRecipient> informationRecipient;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.LegalAuthenticator legalAuthenticator;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Authenticator> authenticator;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Merged.Participant2> participant;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.InFulfillmentOf> inFulfillmentOf;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.DocumentationOf> documentationOf;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Merged.RelatedDocument> relatedDocument;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Authorization> authorization;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Component1 componentOf;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Component2 component;

        public BaseModel() {
            this.typeId = new IIImpl();
            this.templateId = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.id = new IIImpl();
            this.code = new CEImpl();
            this.title = new STImpl();
            this.effectiveTime = new TSCDAR1Impl();
            this.confidentialityCode = new CEImpl();
            this.languageCode = new CSImpl();
            this.setId = new IIImpl();
            this.versionNumber = new INTImpl();
            this.copyTime = new TSCDAR1Impl();
            this.recordTarget = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.RecordTarget>();
            this.author = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Author>();
            this.informant = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Merged.Informant12>();
            this.informationRecipient = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.InformationRecipient>();
            this.authenticator = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Authenticator>();
            this.participant = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Merged.Participant2>();
            this.inFulfillmentOf = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.InFulfillmentOf>();
            this.documentationOf = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.DocumentationOf>();
            this.relatedDocument = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Merged.RelatedDocument>();
            this.authorization = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Authorization>();
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
        public Code Code {
            get { return (Code) this.code.Value; }
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
        public Code ConfidentialityCode {
            get { return (Code) this.confidentialityCode.Value; }
            set { this.confidentialityCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ClinicalDocument.languageCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"languageCode"})]
        public Code LanguageCode {
            get { return (Code) this.languageCode.Value; }
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
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.RecordTarget> RecordTarget {
            get { return this.recordTarget; }
        }

        /**
         * <summary>Relationship: BaseModel.ClinicalDocument.author</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Author> Author {
            get { return this.author; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ClinicalDocument.dataEnterer</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"dataEnterer"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.DataEnterer DataEnterer {
            get { return this.dataEnterer; }
            set { this.dataEnterer = value; }
        }

        /**
         * <summary>Relationship: BaseModel.ClinicalDocument.informant</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"informant"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Merged.Informant12> Informant {
            get { return this.informant; }
        }

        /**
         * <summary>Relationship: BaseModel.ClinicalDocument.custodian</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"custodian"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Merged.Custodian Custodian {
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
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.InformationRecipient> InformationRecipient {
            get { return this.informationRecipient; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ClinicalDocument.legalAuthenticator</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"legalAuthenticator"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.LegalAuthenticator LegalAuthenticator {
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
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Authenticator> Authenticator {
            get { return this.authenticator; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ClinicalDocument.participant</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"participant"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Merged.Participant2> Participant {
            get { return this.participant; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ClinicalDocument.inFulfillmentOf</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"inFulfillmentOf"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.InFulfillmentOf> InFulfillmentOf {
            get { return this.inFulfillmentOf; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ClinicalDocument.documentationOf</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"documentationOf"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.DocumentationOf> DocumentationOf {
            get { return this.documentationOf; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ClinicalDocument.relatedDocument</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"relatedDocument"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Merged.RelatedDocument> RelatedDocument {
            get { return this.relatedDocument; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ClinicalDocument.authorization</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"authorization"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Authorization> Authorization {
            get { return this.authorization; }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ClinicalDocument.componentOf</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"componentOf"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Component1 ComponentOf {
            get { return this.componentOf; }
            set { this.componentOf = value; }
        }

        /**
         * <summary>Relationship: BaseModel.ClinicalDocument.component</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Component2 Component {
            get { return this.component; }
            set { this.component = value; }
        }

    }

}