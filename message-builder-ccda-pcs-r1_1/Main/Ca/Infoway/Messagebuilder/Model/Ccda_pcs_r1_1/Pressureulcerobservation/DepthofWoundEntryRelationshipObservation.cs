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
namespace Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Pressureulcerobservation {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel;
    using Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged;
    using System;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"PressureUlcerObservation.DepthofWoundEntryRelationshipObservation"})]
    public class DepthofWoundEntryRelationshipObservation : MessagePartBean {

        private BL negationInd;
        private LIST<CS, Code> realmCode;
        private II typeId;
        private LIST<II, Identifier> templateId;
        private LIST<II, Identifier> id;
        private ST derivationExpr;
        private ED<EncapsulatedData> text;
        private CS statusCode;
        private IVLTSCDAR1 effectiveTime;
        private CE priorityCode;
        private IVL<INT, Interval<int?>> repeatNumber;
        private CS languageCode;
        private PQ value;
        private LIST<CE, Code> interpretationCode;
        private LIST<CE, Code> methodCode;
        private LIST<CD, Code> targetSiteCode;
        private Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Subject subject;
        private IList<Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.Specimen> specimen;
        private IList<Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.Performer2_1> performer;
        private IList<Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.Author_1> author;
        private IList<Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.Informant12> informant;
        private IList<Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.Participant2_2> participant;
        private IList<Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.EntryRelationship_2> entryRelationship;
        private IList<Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Reference> reference;
        private IList<Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Precondition> precondition;
        private IList<Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.ReferenceRange> referenceRange;

        public DepthofWoundEntryRelationshipObservation() {
            this.negationInd = new BLImpl();
            this.realmCode = new LISTImpl<CS, Code>(typeof(CSImpl));
            this.typeId = new IIImpl();
            this.templateId = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.id = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.derivationExpr = new STImpl();
            this.text = new EDImpl<EncapsulatedData>();
            this.statusCode = new CSImpl();
            this.effectiveTime = new IVLTSCDAR1Impl();
            this.priorityCode = new CEImpl();
            this.repeatNumber = new IVLImpl<INT, Interval<int?>>();
            this.languageCode = new CSImpl();
            this.value = new PQImpl();
            this.interpretationCode = new LISTImpl<CE, Code>(typeof(CEImpl));
            this.methodCode = new LISTImpl<CE, Code>(typeof(CEImpl));
            this.targetSiteCode = new LISTImpl<CD, Code>(typeof(CDImpl));
            this.specimen = new List<Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.Specimen>();
            this.performer = new List<Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.Performer2_1>();
            this.author = new List<Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.Author_1>();
            this.informant = new List<Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.Informant12>();
            this.participant = new List<Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.Participant2_2>();
            this.entryRelationship = new List<Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.EntryRelationship_2>();
            this.reference = new List<Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Reference>();
            this.precondition = new List<Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Precondition>();
            this.referenceRange = new List<Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.ReferenceRange>();
        }
        /**
         * <summary>Relationship: 
         * PressureUlcerObservation.DepthofWoundEntryRelationshipObservation.negationInd</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"negationInd"})]
        public bool? NegationInd {
            get { return this.negationInd.Value; }
            set { this.negationInd.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PressureUlcerObservation.DepthofWoundEntryRelationshipObservation.realmCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"realmCode"})]
        public IList<Code> RealmCode {
            get { return this.realmCode.RawList<Code>(); }
        }

        /**
         * <summary>Relationship: 
         * PressureUlcerObservation.DepthofWoundEntryRelationshipObservation.typeId</summary>
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
         * PressureUlcerObservation.DepthofWoundEntryRelationshipObservation.templateId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"templateId"})]
        public IList<Identifier> TemplateId {
            get { return this.templateId.RawList(); }
        }

        /**
         * <summary>Relationship: 
         * PressureUlcerObservation.DepthofWoundEntryRelationshipObservation.id</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public IList<Identifier> Id {
            get { return this.id.RawList(); }
        }

        /**
         * <summary>Relationship: 
         * PressureUlcerObservation.DepthofWoundEntryRelationshipObservation.derivationExpr</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"derivationExpr"})]
        public String DerivationExpr {
            get { return this.derivationExpr.Value; }
            set { this.derivationExpr.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PressureUlcerObservation.DepthofWoundEntryRelationshipObservation.text</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public EncapsulatedData Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PressureUlcerObservation.DepthofWoundEntryRelationshipObservation.statusCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public Code StatusCode {
            get { return (Code) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PressureUlcerObservation.DepthofWoundEntryRelationshipObservation.effectiveTime</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public DateInterval EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PressureUlcerObservation.DepthofWoundEntryRelationshipObservation.priorityCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"priorityCode"})]
        public Code PriorityCode {
            get { return (Code) this.priorityCode.Value; }
            set { this.priorityCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PressureUlcerObservation.DepthofWoundEntryRelationshipObservation.repeatNumber</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"repeatNumber"})]
        public Interval<int?> RepeatNumber {
            get { return this.repeatNumber.Value; }
            set { this.repeatNumber.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PressureUlcerObservation.DepthofWoundEntryRelationshipObservation.languageCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"languageCode"})]
        public Code LanguageCode {
            get { return (Code) this.languageCode.Value; }
            set { this.languageCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PressureUlcerObservation.DepthofWoundEntryRelationshipObservation.value</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public PhysicalQuantity Value {
            get { return this.value.Value; }
            set { this.value.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PressureUlcerObservation.DepthofWoundEntryRelationshipObservation.interpretationCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"interpretationCode"})]
        public IList<Code> InterpretationCode {
            get { return this.interpretationCode.RawList<Code>(); }
        }

        /**
         * <summary>Relationship: 
         * PressureUlcerObservation.DepthofWoundEntryRelationshipObservation.methodCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"methodCode"})]
        public IList<Code> MethodCode {
            get { return this.methodCode.RawList<Code>(); }
        }

        /**
         * <summary>Relationship: 
         * PressureUlcerObservation.DepthofWoundEntryRelationshipObservation.targetSiteCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"targetSiteCode"})]
        public IList<Code> TargetSiteCode {
            get { return this.targetSiteCode.RawList<Code>(); }
        }

        /**
         * <summary>Relationship: 
         * PressureUlcerObservation.DepthofWoundEntryRelationshipObservation.subject</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject"})]
        public Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Subject Subject {
            get { return this.subject; }
            set { this.subject = value; }
        }

        /**
         * <summary>Relationship: 
         * PressureUlcerObservation.DepthofWoundEntryRelationshipObservation.specimen</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"specimen"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.Specimen> Specimen {
            get { return this.specimen; }
        }

        /**
         * <summary>Relationship: 
         * PressureUlcerObservation.DepthofWoundEntryRelationshipObservation.performer</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"performer"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.Performer2_1> Performer {
            get { return this.performer; }
        }

        /**
         * <summary>Relationship: 
         * PressureUlcerObservation.DepthofWoundEntryRelationshipObservation.author</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.Author_1> Author {
            get { return this.author; }
        }

        /**
         * <summary>Relationship: 
         * PressureUlcerObservation.DepthofWoundEntryRelationshipObservation.informant</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"informant"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.Informant12> Informant {
            get { return this.informant; }
        }

        /**
         * <summary>Relationship: 
         * PressureUlcerObservation.DepthofWoundEntryRelationshipObservation.participant</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"participant"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.Participant2_2> Participant {
            get { return this.participant; }
        }

        /**
         * <summary>Relationship: 
         * PressureUlcerObservation.DepthofWoundEntryRelationshipObservation.entryRelationship</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"entryRelationship"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.EntryRelationship_2> EntryRelationship {
            get { return this.entryRelationship; }
        }

        /**
         * <summary>Relationship: 
         * PressureUlcerObservation.DepthofWoundEntryRelationshipObservation.reference</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reference"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Reference> Reference {
            get { return this.reference; }
        }

        /**
         * <summary>Relationship: 
         * PressureUlcerObservation.DepthofWoundEntryRelationshipObservation.precondition</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"precondition"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Basemodel.Precondition> Precondition {
            get { return this.precondition; }
        }

        /**
         * <summary>Relationship: 
         * PressureUlcerObservation.DepthofWoundEntryRelationshipObservation.referenceRange</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"referenceRange"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.ReferenceRange> ReferenceRange {
            get { return this.referenceRange; }
        }

    }

}