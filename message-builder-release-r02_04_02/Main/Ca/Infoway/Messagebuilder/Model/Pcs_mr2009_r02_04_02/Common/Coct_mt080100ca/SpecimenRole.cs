/**
 * Copyright 2015 Canada Health Infoway, Inc.
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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt080100ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Domainvalue;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Specimen Role</summary>
     * 
     * <p>The specimen role represents the information regarding a 
     * material collected from a patient to serve as a specimen for 
     * testing.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT080100CA.Specimen"})]
    public class SpecimenRole : MessagePartBean {

        private II id;
        private CD specimenMaterialCode;
        private ST specimenMaterialDesc;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt080100ca.OtherSpecimenIdentifications> specimenMaterialAsIdentifiedEntity;
        private CV specimenMaterialAsContentContainerRiskCode;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt080100ca.SpecimenProcessSteps> subjectOfTransportationEvent;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt080100ca.SpecimenCollectionProcedure productOfSpecimenCollectionProcedureEvent;

        public SpecimenRole() {
            this.id = new IIImpl();
            this.specimenMaterialCode = new CDImpl();
            this.specimenMaterialDesc = new STImpl();
            this.specimenMaterialAsIdentifiedEntity = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt080100ca.OtherSpecimenIdentifications>();
            this.specimenMaterialAsContentContainerRiskCode = new CVImpl();
            this.subjectOfTransportationEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt080100ca.SpecimenProcessSteps>();
        }
        /**
         * <summary>Business Name: A:Specimen Identifier</summary>
         * 
         * <remarks>Relationship: COCT_MT080100CA.Specimen.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>A unique specimen 
         * identifier is necessary for specimen tracking and 
         * management.</p> <p>A unique identifier for the specimen. 
         * Frequently the accession number which often uniquely 
         * identifies the specimen is used as the unique specimen 
         * identifier in communications. However, accessioning may 
         * group multiple specimens (identified) under one accession 
         * number. Therefore, it is recommended that this be truly the 
         * specimen identifier and not the accession number.</p><p>For 
         * a referral, this attribute should be Required so it is 
         * reflected back in the result. If Lab A has collected and or 
         * done something to the specimen, then the identifier would be 
         * sent.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: V:Specimen Code</summary>
         * 
         * <remarks>Relationship: COCT_MT080100CA.Material.code 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The specimen code 
         * differentiates testing types, methods, and resulting 
         * processing of specimen material.</p> <p>The code of the 
         * specimen material collected e.g. skin, blood, etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"specimenMaterial/code"})]
        public HumanLabSpecimenEntityType SpecimenMaterialCode {
            get { return (HumanLabSpecimenEntityType) this.specimenMaterialCode.Value; }
            set { this.specimenMaterialCode.Value = value; }
        }

        /**
         * <summary>Business Name: W:Specimen Text</summary>
         * 
         * <remarks>Relationship: COCT_MT080100CA.Material.desc 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Used when 
         * information is not able to be coded or represented using the 
         * available other attributes.</p> <p>Any descriptive specimen 
         * information not sufficiently communicated by the code 
         * attribute.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"specimenMaterial/desc"})]
        public String SpecimenMaterialDesc {
            get { return this.specimenMaterialDesc.Value; }
            set { this.specimenMaterialDesc.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT080100CA.Material.asIdentifiedEntity</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-10)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"specimenMaterial/asIdentifiedEntity"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt080100ca.OtherSpecimenIdentifications> SpecimenMaterialAsIdentifiedEntity {
            get { return this.specimenMaterialAsIdentifiedEntity; }
        }

        /**
         * <summary>Business Name: Y:Specimen Container Risk</summary>
         * 
         * <remarks>Relationship: COCT_MT080100CA.Container.riskCode 
         * Conformance/Cardinality: REQUIRED (1) <p>Used to document 
         * container risks to those who handle the container.</p> 
         * <p>Describes any risk to the handlers of this container 
         * (containing a specimen).</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"specimenMaterial/asContent/container/riskCode"})]
        public EntityRisk SpecimenMaterialAsContentContainerRiskCode {
            get { return (EntityRisk) this.specimenMaterialAsContentContainerRiskCode.Value; }
            set { this.specimenMaterialAsContentContainerRiskCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT080100CA.Subject2.transportationEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf/transportationEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt080100ca.SpecimenProcessSteps> SubjectOfTransportationEvent {
            get { return this.subjectOfTransportationEvent; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT080100CA.Product.specimenCollectionProcedureEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"productOf/specimenCollectionProcedureEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt080100ca.SpecimenCollectionProcedure ProductOfSpecimenCollectionProcedureEvent {
            get { return this.productOfSpecimenCollectionProcedureEvent; }
            set { this.productOfSpecimenCollectionProcedureEvent = value; }
        }

    }

}