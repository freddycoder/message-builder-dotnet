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
    using System;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"BaseModel.Reference"})]
    public class Reference : MessagePartBean {

        private CS typeCode;
        private LIST<CS, Code> realmCode;
        private II typeId;
        private LIST<II, Identifier> templateId;
        private BL seperatableInd;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.IReferenceChoice referenceChoice;

        public Reference() {
            this.typeCode = new CSImpl();
            this.realmCode = new LISTImpl<CS, Code>(typeof(CSImpl));
            this.typeId = new IIImpl();
            this.templateId = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.seperatableInd = new BLImpl();
        }
        /**
         * <summary>Relationship: BaseModel.Reference.typeCode</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"typeCode"})]
        public x_ActRelationshipExternalReference TypeCode {
            get { return (x_ActRelationshipExternalReference) this.typeCode.Value; }
            set { this.typeCode.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.Reference.realmCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"realmCode"})]
        public IList<Code> RealmCode {
            get { return this.realmCode.RawList<Code>(); }
        }

        /**
         * <summary>Relationship: BaseModel.Reference.typeId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"typeId"})]
        public Identifier TypeId {
            get { return this.typeId.Value; }
            set { this.typeId.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.Reference.templateId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"templateId"})]
        public IList<Identifier> TemplateId {
            get { return this.templateId.RawList(); }
        }

        /**
         * <summary>Relationship: BaseModel.Reference.seperatableInd</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"seperatableInd"})]
        public bool? SeperatableInd {
            get { return this.seperatableInd.Value; }
            set { this.seperatableInd.Value = value; }
        }

        /**
         * <summary>Relationship: BaseModel.Reference.referenceChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"referenceChoice"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.IReferenceChoice ReferenceChoice {
            get { return this.referenceChoice; }
            set { this.referenceChoice = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.ExternalAct ReferenceChoiceAsExternalAct {
            get { return this.referenceChoice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.ExternalAct ? (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.ExternalAct) this.referenceChoice : (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.ExternalAct) null; }
        }
        public bool HasReferenceChoiceAsExternalAct() {
            return (this.referenceChoice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.ExternalAct);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.ExternalObservation ReferenceChoiceAsExternalObservation {
            get { return this.referenceChoice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.ExternalObservation ? (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.ExternalObservation) this.referenceChoice : (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.ExternalObservation) null; }
        }
        public bool HasReferenceChoiceAsExternalObservation() {
            return (this.referenceChoice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.ExternalObservation);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.ExternalProcedure ReferenceChoiceAsExternalProcedure {
            get { return this.referenceChoice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.ExternalProcedure ? (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.ExternalProcedure) this.referenceChoice : (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.ExternalProcedure) null; }
        }
        public bool HasReferenceChoiceAsExternalProcedure() {
            return (this.referenceChoice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.ExternalProcedure);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.ExternalDocument ReferenceChoiceAsExternalDocument {
            get { return this.referenceChoice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.ExternalDocument ? (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.ExternalDocument) this.referenceChoice : (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.ExternalDocument) null; }
        }
        public bool HasReferenceChoiceAsExternalDocument() {
            return (this.referenceChoice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.ExternalDocument);
        }

    }

}