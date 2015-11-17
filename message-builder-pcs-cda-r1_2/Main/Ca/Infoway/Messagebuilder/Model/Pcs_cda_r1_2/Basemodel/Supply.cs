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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Merged;
    using System;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"BaseModel.Supply"})]
    public class Supply : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.IEntryChoice, Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.IComponent4Choice, Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.IEntryRelationshipChoice {

        private CS moodCode;
        private LIST<CS, Code> realmCode;
        private II typeId;
        private LIST<II, Identifier> templateId;
        private LIST<II, Identifier> id;
        private CD code;
        private ED<EncapsulatedData> text;
        private CS statusCode;
        private LIST<SXCMTSCDAR1, MbDate> effectiveTime;
        private LIST<CE, Code> priorityCode;
        private IVL<INT, Interval<int?>> repeatNumber;
        private BL independentInd;
        private PQ quantity;
        private IVLTSCDAR1 expectedUseTime;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Subject subject;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Specimen> specimen;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Product product;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Merged.Performer2> performer;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Author> author;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Merged.Informant12> informant;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Merged.Participant2> participant;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.EntryRelationship> entryRelationship;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Reference> reference;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Precondition> precondition;

        public Supply() {
            this.moodCode = new CSImpl();
            this.realmCode = new LISTImpl<CS, Code>(typeof(CSImpl));
            this.typeId = new IIImpl();
            this.templateId = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.id = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.code = new CDImpl();
            this.text = new EDImpl<EncapsulatedData>();
            this.statusCode = new CSImpl();
            this.effectiveTime = new LISTImpl<SXCMTSCDAR1, MbDate>(typeof(SXCMTSCDAR1Impl));
            this.priorityCode = new LISTImpl<CE, Code>(typeof(CEImpl));
            this.repeatNumber = new IVLImpl<INT, Interval<int?>>();
            this.independentInd = new BLImpl();
            this.quantity = new PQImpl();
            this.expectedUseTime = new IVLTSCDAR1Impl();
            this.specimen = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Specimen>();
            this.performer = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Merged.Performer2>();
            this.author = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Author>();
            this.informant = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Merged.Informant12>();
            this.participant = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Merged.Participant2>();
            this.entryRelationship = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.EntryRelationship>();
            this.reference = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Reference>();
            this.precondition = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Precondition>();
        }
        /**
         * <summary>Relationship: BaseModel.Supply.moodCode</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"moodCode"})]
        public x_DocumentSubstanceMood MoodCode {
            get { return (x_DocumentSubstanceMood) this.moodCode.Value; }
            set { this.moodCode.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.Supply.realmCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"realmCode"})]
        public IList<Code> RealmCode {
            get { return this.realmCode.RawList<Code>(); }
        }

        /**
         * <summary>Relationship: BaseModel.Supply.typeId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"typeId"})]
        public Identifier TypeId {
            get { return this.typeId.Value; }
            set { this.typeId.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.Supply.templateId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"templateId"})]
        public IList<Identifier> TemplateId {
            get { return this.templateId.RawList(); }
        }

        /**
         * <summary>Relationship: BaseModel.Supply.id</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public IList<Identifier> Id {
            get { return this.id.RawList(); }
        }

        /**
         * <summary>Relationship: BaseModel.Supply.code</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public Code Code {
            get { return (Code) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.Supply.text</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public EncapsulatedData Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.Supply.statusCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public Code StatusCode {
            get { return (Code) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.Supply.effectiveTime</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public IList<MbDate> EffectiveTime {
            get { return this.effectiveTime.RawList(); }
        }

        /**
         * <summary>Relationship: BaseModel.Supply.priorityCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"priorityCode"})]
        public IList<Code> PriorityCode {
            get { return this.priorityCode.RawList<Code>(); }
        }

        /**
         * <summary>Relationship: BaseModel.Supply.repeatNumber</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"repeatNumber"})]
        public Interval<int?> RepeatNumber {
            get { return this.repeatNumber.Value; }
            set { this.repeatNumber.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.Supply.independentInd</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"independentInd"})]
        public bool? IndependentInd {
            get { return this.independentInd.Value; }
            set { this.independentInd.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.Supply.quantity</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"quantity"})]
        public PhysicalQuantity Quantity {
            get { return this.quantity.Value; }
            set { this.quantity.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.Supply.expectedUseTime</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"expectedUseTime"})]
        public DateInterval ExpectedUseTime {
            get { return this.expectedUseTime.Value; }
            set { this.expectedUseTime.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.Supply.subject</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Subject Subject {
            get { return this.subject; }
            set { this.subject = value; }
        }

        /**
         * <summary>Relationship: BaseModel.Supply.specimen</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"specimen"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Specimen> Specimen {
            get { return this.specimen; }
        }

        /**
         * <summary>Relationship: BaseModel.Supply.product</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"product"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Product Product {
            get { return this.product; }
            set { this.product = value; }
        }

        /**
         * <summary>Relationship: BaseModel.Supply.performer</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"performer"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Merged.Performer2> Performer {
            get { return this.performer; }
        }

        /**
         * <summary>Relationship: BaseModel.Supply.author</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Author> Author {
            get { return this.author; }
        }

        /**
         * <summary>Relationship: BaseModel.Supply.informant</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"informant"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Merged.Informant12> Informant {
            get { return this.informant; }
        }

        /**
         * <summary>Relationship: BaseModel.Supply.participant</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"participant"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Merged.Participant2> Participant {
            get { return this.participant; }
        }

        /**
         * <summary>Relationship: BaseModel.Supply.entryRelationship</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"entryRelationship"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.EntryRelationship> EntryRelationship {
            get { return this.entryRelationship; }
        }

        /**
         * <summary>Relationship: BaseModel.Supply.reference</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reference"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Reference> Reference {
            get { return this.reference; }
        }

        /**
         * <summary>Relationship: BaseModel.Supply.precondition</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"precondition"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Precondition> Precondition {
            get { return this.precondition; }
        }

    }

}