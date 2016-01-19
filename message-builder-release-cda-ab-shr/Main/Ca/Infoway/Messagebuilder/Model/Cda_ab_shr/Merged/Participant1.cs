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
namespace Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Merged {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"BaseModel.Participant1","BaseModel.Participant2","CAABTranscribedReports.Participant1"})]
    public class Participant1 : MessagePartBean {

        private CS_R2<ParticipationType> typeCode;
        private II typeId;
        private LIST<II, Identifier> templateId;
        private IVL_TS time;
        private CE_R2<Code> awarenessCode;
        private Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.ParticipantRole participantRole;
        private CE_R2<Code> functionCode;
        private Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.AssociatedEntity associatedEntity;

        public Participant1() {
            this.typeCode = new CS_R2Impl<ParticipationType>();
            this.typeId = new IIImpl();
            this.templateId = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.time = new IVL_TSImpl();
            this.awarenessCode = new CE_R2Impl<Code>();
            this.functionCode = new CE_R2Impl<Code>();
        }
        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: BaseModel.Participant2.typeCode 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * BaseModel.Participant1.typeCode Conformance/Cardinality: 
         * MANDATORY (1) Un-merged Business Name: (no business name 
         * specified) Relationship: 
         * CAABTranscribedReports.Participant1.typeCode 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"typeCode"})]
        public CodedTypeR2<ParticipationType> TypeCode {
            get { return (CodedTypeR2<ParticipationType>) this.typeCode.Value; }
            set { this.typeCode.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: BaseModel.Participant2.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * BaseModel.Participant1.typeId Conformance/Cardinality: 
         * OPTIONAL (0-1) Un-merged Business Name: (no business name 
         * specified) Relationship: 
         * CAABTranscribedReports.Participant1.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"typeId"})]
        public Identifier TypeId {
            get { return this.typeId.Value; }
            set { this.typeId.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: BaseModel.Participant2.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * BaseModel.Participant1.templateId Conformance/Cardinality: 
         * OPTIONAL (0-*) Un-merged Business Name: (no business name 
         * specified) Relationship: 
         * CAABTranscribedReports.Participant1.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"templateId"})]
        public IList<Identifier> TemplateId {
            get { return this.templateId.RawList(); }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: BaseModel.Participant2.time 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * BaseModel.Participant1.time Conformance/Cardinality: 
         * OPTIONAL (0-1) Un-merged Business Name: (no business name 
         * specified) Relationship: 
         * CAABTranscribedReports.Participant1.time 
         * Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"time"})]
        public DateInterval Time {
            get { return this.time.Value; }
            set { this.time.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: BaseModel.Participant2.awarenessCode 
         * Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"awarenessCode"})]
        public CodedTypeR2<Code> AwarenessCode {
            get { return (CodedTypeR2<Code>) this.awarenessCode.Value; }
            set { this.awarenessCode.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * BaseModel.Participant2.participantRole 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"participantRole"})]
        public Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.ParticipantRole ParticipantRole {
            get { return this.participantRole; }
            set { this.participantRole = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: BaseModel.Participant1.functionCode 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * CAABTranscribedReports.Participant1.functionCode 
         * Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"functionCode"})]
        public CodedTypeR2<Code> FunctionCode {
            get { return (CodedTypeR2<Code>) this.functionCode.Value; }
            set { this.functionCode.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * BaseModel.Participant1.associatedEntity 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * CAABTranscribedReports.Participant1.associatedEntity 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"associatedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Basemodel.AssociatedEntity AssociatedEntity {
            get { return this.associatedEntity; }
            set { this.associatedEntity = value; }
        }

    }

}