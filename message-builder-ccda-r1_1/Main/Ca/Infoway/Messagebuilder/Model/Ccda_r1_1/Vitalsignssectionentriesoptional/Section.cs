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
namespace Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Vitalsignssectionentriesoptional {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel;
    using Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged;
    using System;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"VitalSignsSectionentriesOptional.Section"})]
    public class Section : MessagePartBean {

        private ST iD;
        private LIST<CS_R2<Code>, CodedTypeR2<Code>> realmCode;
        private II typeId;
        private LIST<II, Identifier> templateId;
        private II id;
        private ST title;
        private ED<EncapsulatedData> text;
        private CE_R2<Code> confidentialityCode;
        private CS_R2<Code> languageCode;
        private Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Subject subject;
        private IList<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Author_1> author;
        private IList<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Informant12> informant;
        private IList<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.IEntryChoice_10> entry;
        private IList<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Component5> component;

        public Section() {
            this.iD = new STImpl();
            this.realmCode = new LISTImpl<CS_R2<Code>, CodedTypeR2<Code>>(typeof(CS_R2Impl<Code>));
            this.typeId = new IIImpl();
            this.templateId = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.id = new IIImpl();
            this.title = new STImpl();
            this.text = new EDImpl<EncapsulatedData>();
            this.confidentialityCode = new CE_R2Impl<Code>();
            this.languageCode = new CS_R2Impl<Code>();
            this.author = new List<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Author_1>();
            this.informant = new List<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Informant12>();
            this.entry = new List<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.IEntryChoice_10>();
            this.component = new List<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Component5>();
        }
        /**
         * <summary>Relationship: 
         * VitalSignsSectionentriesOptional.Section.ID</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"ID"})]
        public String ID {
            get { return this.iD.Value; }
            set { this.iD.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * VitalSignsSectionentriesOptional.Section.realmCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"realmCode"})]
        public IList<CodedTypeR2<Code>> RealmCode {
            get { return this.realmCode.RawList<CodedTypeR2<Code>>(); }
        }

        /**
         * <summary>Relationship: 
         * VitalSignsSectionentriesOptional.Section.typeId</summary>
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
         * VitalSignsSectionentriesOptional.Section.templateId</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"templateId"})]
        public IList<Identifier> TemplateId {
            get { return this.templateId.RawList(); }
        }

        /**
         * <summary>Relationship: 
         * VitalSignsSectionentriesOptional.Section.id</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * VitalSignsSectionentriesOptional.Section.title</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"title"})]
        public String Title {
            get { return this.title.Value; }
            set { this.title.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * VitalSignsSectionentriesOptional.Section.text</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public EncapsulatedData Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * VitalSignsSectionentriesOptional.Section.confidentialityCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public CodedTypeR2<Code> ConfidentialityCode {
            get { return (CodedTypeR2<Code>) this.confidentialityCode.Value; }
            set { this.confidentialityCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * VitalSignsSectionentriesOptional.Section.languageCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"languageCode"})]
        public CodedTypeR2<Code> LanguageCode {
            get { return (CodedTypeR2<Code>) this.languageCode.Value; }
            set { this.languageCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * VitalSignsSectionentriesOptional.Section.subject</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject"})]
        public Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Subject Subject {
            get { return this.subject; }
            set { this.subject = value; }
        }

        /**
         * <summary>Relationship: 
         * VitalSignsSectionentriesOptional.Section.author</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Author_1> Author {
            get { return this.author; }
        }

        /**
         * <summary>Relationship: 
         * VitalSignsSectionentriesOptional.Section.informant</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"informant"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Informant12> Informant {
            get { return this.informant; }
        }

        /**
         * <summary>Relationship: 
         * VitalSignsSectionentriesOptional.Section.entry</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"entry"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.IEntryChoice_10> Entry {
            get { return this.entry; }
        }

        /**
         * <summary>Relationship: 
         * VitalSignsSectionentriesOptional.Section.component</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Component5> Component {
            get { return this.component; }
        }

    }

}