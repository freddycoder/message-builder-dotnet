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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt080100ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Domainvalue;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: SpecimenMaterial</summary>
     * 
     * <remarks>COCT_MT080100CA.Material: Specimen Material <p>The 
     * specimen material is of primary importance when 
     * communicating a lab result. The specimen Material may be 
     * inherent in the LOINC code describing the lab result.</p> 
     * <p>This entity object is the specimen material itself.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT080100CA.Material","REPC_MT500001CA.Material","REPC_MT500002CA.Material","REPC_MT500003CA.Material","REPC_MT500004CA.Material"})]
    public class SpecimenMaterial : MessagePartBean {

        private ST desc;
        private CD code;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt080100ca.OtherSpecimenIdentifications> asIdentifiedEntity;
        private CV asContentContainerRiskCode;

        public SpecimenMaterial() {
            this.desc = new STImpl();
            this.code = new CDImpl();
            this.asIdentifiedEntity = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt080100ca.OtherSpecimenIdentifications>();
            this.asContentContainerRiskCode = new CVImpl();
        }
        /**
         * <summary>Un-merged Business Name: FocusArea</summary>
         * 
         * <remarks>Relationship: REPC_MT500002CA.Material.desc 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows grouping 
         * observations, procedures and other records directly 
         * associated with a particular mole, tumor or other potion of 
         * a patient not easily referenced as a coded body 
         * site.</p><p>This element is optional because not all systems 
         * will support Localized Health Condition-based 
         * Collections</p> <p>Describes the specific body region or 
         * area associated with a Localized Health Condition-based 
         * Collection.</p><p>E.g. &quot;Left-most mole approximately 
         * one inch below left shoulder-blade&quot;</p> Un-merged 
         * Business Name: SpecimenText Relationship: 
         * COCT_MT080100CA.Material.desc Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Used when information is not able to be 
         * coded or represented using the available other 
         * attributes.</p> <p>Any descriptive specimen information not 
         * sufficiently communicated by the code attribute.</p> 
         * Un-merged Business Name: FocusArea Relationship: 
         * REPC_MT500001CA.Material.desc Conformance/Cardinality: 
         * MANDATORY (1) <p>Allows grouping observations, procedures 
         * and other records directly associated with a particular 
         * mole, tumor or other potion of a patient not easily 
         * referenced as a coded body site.</p><p>This element is 
         * optional because not all systems will support Localized 
         * Health Condition-based Collections</p> <p>Describes the 
         * specific body region or area associated with a Localized 
         * Health Condition-based Collection.</p><p>E.g. 
         * &quot;Left-most mole approximately one inch below left 
         * shoulder-blade&quot;</p> Un-merged Business Name: FocusArea 
         * Relationship: REPC_MT500004CA.Material.desc 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows grouping 
         * observations, procedures and other records directly 
         * associated with a particular mole, tumor or other potion of 
         * a patient not easily referenced as a coded body 
         * site.</p><p>This element is optional because not all systems 
         * will support Localized Health Condition-based 
         * Collections</p> <p>Describes the specific body region or 
         * area associated with a Localized Health Condition-based 
         * Collection.</p><p>E.g. &quot;Left-most mole approximately 
         * one inch below left shoulder-blade&quot;</p> Un-merged 
         * Business Name: FocusArea Relationship: 
         * REPC_MT500003CA.Material.desc Conformance/Cardinality: 
         * MANDATORY (1) <p>Allows grouping observations, procedures 
         * and other records directly associated with a particular 
         * mole, tumor or other potion of a patient not easily 
         * referenced as a coded body site.</p><p>This element is 
         * optional because not all systems will support Localized 
         * Health Condition-based Collections</p> <p>Describes the 
         * specific body region or area associated with a Localized 
         * Health Condition-based Collection.</p><p>E.g. 
         * &quot;Left-most mole approximately one inch below left 
         * shoulder-blade&quot;</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"desc"})]
        public String Desc {
            get { return this.desc.Value; }
            set { this.desc.Value = value; }
        }

        /**
         * <summary>Business Name: SpecimenCode</summary>
         * 
         * <remarks>Un-merged Business Name: SpecimenCode Relationship: 
         * COCT_MT080100CA.Material.code Conformance/Cardinality: 
         * REQUIRED (0-1) <p>The specimen code differentiates testing 
         * types, methods, and resulting processing of specimen 
         * material.</p> <p>The code of the specimen material collected 
         * e.g. skin, blood, etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public HumanLabSpecimenEntityType Code {
            get { return (HumanLabSpecimenEntityType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT080100CA.Material.asIdentifiedEntity 
         * Conformance/Cardinality: REQUIRED (0-10)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"asIdentifiedEntity"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt080100ca.OtherSpecimenIdentifications> AsIdentifiedEntity {
            get { return this.asIdentifiedEntity; }
        }

        /**
         * <summary>Business Name: SpecimenContainerRisk</summary>
         * 
         * <remarks>Un-merged Business Name: SpecimenContainerRisk 
         * Relationship: COCT_MT080100CA.Container.riskCode 
         * Conformance/Cardinality: REQUIRED (1) <p>Used to document 
         * container risks to those who handle the container.</p> 
         * <p>Describes any risk to the handlers of this container 
         * (containing a specimen).</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"asContent/container/riskCode"})]
        public EntityRisk AsContentContainerRiskCode {
            get { return (EntityRisk) this.asContentContainerRiskCode.Value; }
            set { this.asContentContainerRiskCode.Value = value; }
        }

    }

}