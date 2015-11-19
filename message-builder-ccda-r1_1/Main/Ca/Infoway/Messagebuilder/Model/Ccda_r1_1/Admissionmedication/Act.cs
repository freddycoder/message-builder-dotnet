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
namespace Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Admissionmedication {
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


    [Hl7PartTypeMappingAttribute(new string[] {"AdmissionMedication.Act"})]
    public class Act : MessagePartBean {

        private BL negationInd;
        private LIST<CS_R2<Code>, CodedTypeR2<Code>> realmCode;
        private II typeId;
        private LIST<II, Identifier> templateId;
        private LIST<II, Identifier> id;
        private ED<EncapsulatedData> text;
        private CS_R2<Code> statusCode;
        private IVL_TS effectiveTime;
        private CE_R2<Code> priorityCode;
        private CS_R2<Code> languageCode;
        private Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Subject subject;
        private IList<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Specimen> specimen;
        private IList<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Performer2_1> performer;
        private IList<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Author_1> author;
        private IList<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Informant12> informant;
        private IList<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Participant2_2> participant;
        private IList<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.IEntryRelationshipChoice_1> entryRelationship;
        private IList<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Reference> reference;
        private IList<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Precondition> precondition;

        public Act() {
            this.negationInd = new BLImpl();
            this.realmCode = new LISTImpl<CS_R2<Code>, CodedTypeR2<Code>>(typeof(CS_R2Impl<Code>));
            this.typeId = new IIImpl();
            this.templateId = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.id = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.text = new EDImpl<EncapsulatedData>();
            this.statusCode = new CS_R2Impl<Code>();
            this.effectiveTime = new IVL_TSImpl();
            this.priorityCode = new CE_R2Impl<Code>();
            this.languageCode = new CS_R2Impl<Code>();
            this.specimen = new List<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Specimen>();
            this.performer = new List<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Performer2_1>();
            this.author = new List<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Author_1>();
            this.informant = new List<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Informant12>();
            this.participant = new List<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Participant2_2>();
            this.entryRelationship = new List<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.IEntryRelationshipChoice_1>();
            this.reference = new List<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Reference>();
            this.precondition = new List<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Precondition>();
        }
        /**
         * <summary>Relationship: AdmissionMedication.Act.negationInd</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"negationInd"})]
        public bool? NegationInd {
            get { return this.negationInd.Value; }
            set { this.negationInd.Value = value; }
        }

        /**
         * <summary>Relationship: AdmissionMedication.Act.realmCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"realmCode"})]
        public IList<CodedTypeR2<Code>> RealmCode {
            get { return this.realmCode.RawList<CodedTypeR2<Code>>(); }
        }

        /**
         * <summary>Relationship: AdmissionMedication.Act.typeId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"typeId"})]
        public Identifier TypeId {
            get { return this.typeId.Value; }
            set { this.typeId.Value = value; }
        }

        /**
         * <summary>Relationship: AdmissionMedication.Act.templateId</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"templateId"})]
        public IList<Identifier> TemplateId {
            get { return this.templateId.RawList(); }
        }

        /**
         * <summary>Relationship: AdmissionMedication.Act.id</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public IList<Identifier> Id {
            get { return this.id.RawList(); }
        }

        /**
         * <summary>Relationship: AdmissionMedication.Act.text</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public EncapsulatedData Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Relationship: AdmissionMedication.Act.statusCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public CodedTypeR2<Code> StatusCode {
            get { return (CodedTypeR2<Code>) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Relationship: AdmissionMedication.Act.effectiveTime</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public DateInterval EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Relationship: AdmissionMedication.Act.priorityCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"priorityCode"})]
        public CodedTypeR2<Code> PriorityCode {
            get { return (CodedTypeR2<Code>) this.priorityCode.Value; }
            set { this.priorityCode.Value = value; }
        }

        /**
         * <summary>Relationship: AdmissionMedication.Act.languageCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"languageCode"})]
        public CodedTypeR2<Code> LanguageCode {
            get { return (CodedTypeR2<Code>) this.languageCode.Value; }
            set { this.languageCode.Value = value; }
        }

        /**
         * <summary>Relationship: AdmissionMedication.Act.subject</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject"})]
        public Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Subject Subject {
            get { return this.subject; }
            set { this.subject = value; }
        }

        /**
         * <summary>Relationship: AdmissionMedication.Act.specimen</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"specimen"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Specimen> Specimen {
            get { return this.specimen; }
        }

        /**
         * <summary>Relationship: AdmissionMedication.Act.performer</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"performer"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Performer2_1> Performer {
            get { return this.performer; }
        }

        /**
         * <summary>Relationship: AdmissionMedication.Act.author</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Author_1> Author {
            get { return this.author; }
        }

        /**
         * <summary>Relationship: AdmissionMedication.Act.informant</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"informant"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Informant12> Informant {
            get { return this.informant; }
        }

        /**
         * <summary>Relationship: AdmissionMedication.Act.participant</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"participant"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Participant2_2> Participant {
            get { return this.participant; }
        }

        /**
         * <summary>Relationship: 
         * AdmissionMedication.Act.entryRelationship</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"entryRelationship"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.IEntryRelationshipChoice_1> EntryRelationship {
            get { return this.entryRelationship; }
        }

        /**
         * <summary>Relationship: AdmissionMedication.Act.reference</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reference"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Reference> Reference {
            get { return this.reference; }
        }

        /**
         * <summary>Relationship: AdmissionMedication.Act.precondition</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"precondition"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel.Precondition> Precondition {
            get { return this.precondition; }
        }

    }

}