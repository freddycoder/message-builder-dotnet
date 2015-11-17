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
namespace Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Advancedirectiveobservation {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Domainvalue;
    using System;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"AdvanceDirectiveObservation.Reference"})]
    public class Reference : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Advancedirectiveobservation.IReferenceChoice {

        private LIST<CS_R2<Code>, CodedTypeR2<Code>> realmCode;
        private II typeId;
        private LIST<II, Identifier> templateId;
        private BL seperatableInd;
        private CS_R2<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Domainvalue.ActClassDocument> externalDocumentClassCode;
        private LIST<CS_R2<Code>, CodedTypeR2<Code>> externalDocumentRealmCode;
        private II externalDocumentTypeId;
        private LIST<II, Identifier> externalDocumentTemplateId;
        private LIST<II, Identifier> externalDocumentId;
        private CD_R2<Code> externalDocumentCode;
        private ED<EncapsulatedData> externalDocumentText;
        private II externalDocumentSetId;
        private INT externalDocumentVersionNumber;

        public Reference() {
            this.realmCode = new LISTImpl<CS_R2<Code>, CodedTypeR2<Code>>(typeof(CS_R2Impl<Code>));
            this.typeId = new IIImpl();
            this.templateId = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.seperatableInd = new BLImpl();
            this.externalDocumentClassCode = new CS_R2Impl<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Domainvalue.ActClassDocument>();
            this.externalDocumentRealmCode = new LISTImpl<CS_R2<Code>, CodedTypeR2<Code>>(typeof(CS_R2Impl<Code>));
            this.externalDocumentTypeId = new IIImpl();
            this.externalDocumentTemplateId = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.externalDocumentId = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.externalDocumentCode = new CD_R2Impl<Code>();
            this.externalDocumentText = new EDImpl<EncapsulatedData>();
            this.externalDocumentSetId = new IIImpl();
            this.externalDocumentVersionNumber = new INTImpl();
        }
        /**
         * <summary>Relationship: 
         * AdvanceDirectiveObservation.Reference.realmCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"realmCode"})]
        public IList<CodedTypeR2<Code>> RealmCode {
            get { return this.realmCode.RawList<CodedTypeR2<Code>>(); }
        }

        /**
         * <summary>Relationship: 
         * AdvanceDirectiveObservation.Reference.typeId</summary>
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
         * AdvanceDirectiveObservation.Reference.templateId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"templateId"})]
        public IList<Identifier> TemplateId {
            get { return this.templateId.RawList(); }
        }

        /**
         * <summary>Relationship: 
         * AdvanceDirectiveObservation.Reference.seperatableInd</summary>
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
         * AdvanceDirectiveObservation.ExternalDocument.classCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"externalDocument/classCode"})]
        public CodedTypeR2<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Domainvalue.ActClassDocument> ExternalDocumentClassCode {
            get { return (CodedTypeR2<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Domainvalue.ActClassDocument>) this.externalDocumentClassCode.Value; }
            set { this.externalDocumentClassCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * AdvanceDirectiveObservation.ExternalDocument.realmCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"externalDocument/realmCode"})]
        public IList<CodedTypeR2<Code>> ExternalDocumentRealmCode {
            get { return this.externalDocumentRealmCode.RawList<CodedTypeR2<Code>>(); }
        }

        /**
         * <summary>Relationship: 
         * AdvanceDirectiveObservation.ExternalDocument.typeId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"externalDocument/typeId"})]
        public Identifier ExternalDocumentTypeId {
            get { return this.externalDocumentTypeId.Value; }
            set { this.externalDocumentTypeId.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * AdvanceDirectiveObservation.ExternalDocument.templateId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"externalDocument/templateId"})]
        public IList<Identifier> ExternalDocumentTemplateId {
            get { return this.externalDocumentTemplateId.RawList(); }
        }

        /**
         * <summary>Relationship: 
         * AdvanceDirectiveObservation.ExternalDocument.id</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"externalDocument/id"})]
        public IList<Identifier> ExternalDocumentId {
            get { return this.externalDocumentId.RawList(); }
        }

        /**
         * <summary>Relationship: 
         * AdvanceDirectiveObservation.ExternalDocument.code</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"externalDocument/code"})]
        public CodedTypeR2<Code> ExternalDocumentCode {
            get { return (CodedTypeR2<Code>) this.externalDocumentCode.Value; }
            set { this.externalDocumentCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * AdvanceDirectiveObservation.ExternalDocument.text</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"externalDocument/text"})]
        public EncapsulatedData ExternalDocumentText {
            get { return this.externalDocumentText.Value; }
            set { this.externalDocumentText.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * AdvanceDirectiveObservation.ExternalDocument.setId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"externalDocument/setId"})]
        public Identifier ExternalDocumentSetId {
            get { return this.externalDocumentSetId.Value; }
            set { this.externalDocumentSetId.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * AdvanceDirectiveObservation.ExternalDocument.versionNumber</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"externalDocument/versionNumber"})]
        public int? ExternalDocumentVersionNumber {
            get { return this.externalDocumentVersionNumber.Value; }
            set { this.externalDocumentVersionNumber.Value = value; }
        }

    }

}