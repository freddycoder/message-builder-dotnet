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
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"BaseModel.ManufacturedProduct"})]
    public class ManufacturedProduct : MessagePartBean {

        private LIST<CS, Code> realmCode;
        private II typeId;
        private LIST<II, Identifier> templateId;
        private LIST<II, Identifier> id;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.IManufacturedProductChoice manufacturedProductChoice;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Organization manufacturerOrganization;

        public ManufacturedProduct() {
            this.realmCode = new LISTImpl<CS, Code>(typeof(CSImpl));
            this.typeId = new IIImpl();
            this.templateId = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.id = new LISTImpl<II, Identifier>(typeof(IIImpl));
        }
        /**
         * <summary>Relationship: 
         * BaseModel.ManufacturedProduct.realmCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"realmCode"})]
        public IList<Code> RealmCode {
            get { return this.realmCode.RawList<Code>(); }
        }

        /**
         * <summary>Relationship: BaseModel.ManufacturedProduct.typeId</summary>
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
         * BaseModel.ManufacturedProduct.templateId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"templateId"})]
        public IList<Identifier> TemplateId {
            get { return this.templateId.RawList(); }
        }

        /**
         * <summary>Relationship: BaseModel.ManufacturedProduct.id</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public IList<Identifier> Id {
            get { return this.id.RawList(); }
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ManufacturedProduct.manufacturedProductChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"manufacturedProductChoice"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.IManufacturedProductChoice ManufacturedProductChoice {
            get { return this.manufacturedProductChoice; }
            set { this.manufacturedProductChoice = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.LabeledDrug ManufacturedProductChoiceAsManufacturedLabeledDrug {
            get { return this.manufacturedProductChoice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.LabeledDrug ? (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.LabeledDrug) this.manufacturedProductChoice : (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.LabeledDrug) null; }
        }
        public bool HasManufacturedProductChoiceAsManufacturedLabeledDrug() {
            return (this.manufacturedProductChoice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.LabeledDrug);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Material ManufacturedProductChoiceAsManufacturedMaterial {
            get { return this.manufacturedProductChoice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Material ? (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Material) this.manufacturedProductChoice : (Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Material) null; }
        }
        public bool HasManufacturedProductChoiceAsManufacturedMaterial() {
            return (this.manufacturedProductChoice is Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Material);
        }

        /**
         * <summary>Relationship: 
         * BaseModel.ManufacturedProduct.manufacturerOrganization</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"manufacturerOrganization"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cda_r1_2.Basemodel.Organization ManufacturerOrganization {
            get { return this.manufacturerOrganization; }
            set { this.manufacturerOrganization = value; }
        }

    }

}