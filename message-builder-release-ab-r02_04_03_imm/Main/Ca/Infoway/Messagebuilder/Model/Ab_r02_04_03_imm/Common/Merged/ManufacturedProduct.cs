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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt490000ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Domainvalue;
    using System;


    /**
     * <summary>Business Name: ManufacturedProduct</summary>
     * 
     * <remarks>COCT_MT490000CA.ManufacturedProduct: Manufactured 
     * Product <p>Must have Organization if you don't have UPC/GTIN 
     * or pseudo UPC</p> <p>Scoped by Manufacturer</p> <p>Playing 
     * Role of Manufactured Product</p> 
     * COCT_MT290000CA.ManufacturedProduct: Manufactured Product 
     * <p>Must have Role.cd or ManufacturedMaterial.cd</p> 
     * <p>Scoped by Manufacturer</p> <p>Pertinent info about 
     * manufactured Product</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT290000CA.ManufacturedProduct","COCT_MT490000CA.ManufacturedProduct"})]
    public class ManufacturedProduct : MessagePartBean {

        private II id;
        private CV code;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt490000ca.ManufacturedMaterialKind manufacturedMaterialKind;
        private ST manufacturerManufacturedProductOrganizationName;
        private TEL manufacturerManufacturedProductOrganizationTelecom;
        private CD manufacturedMaterialCode;

        public ManufacturedProduct() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.manufacturerManufacturedProductOrganizationName = new STImpl();
            this.manufacturerManufacturedProductOrganizationTelecom = new TELImpl();
            this.manufacturedMaterialCode = new CDImpl();
        }
        /**
         * <summary>Un-merged Business Name: ProductID</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT490000CA.ManufacturedProduct.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>serial number</p> 
         * Un-merged Business Name: ProductNumber Relationship: 
         * COCT_MT290000CA.ManufacturedProduct.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>serial number</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: ProductCode</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT490000CA.ManufacturedProduct.code 
         * Conformance/Cardinality: MANDATORY (1) <p>code denoting 
         * product type</p> Un-merged Business Name: 
         * ManufacturedProductCode Relationship: 
         * COCT_MT290000CA.ManufacturedProduct.code 
         * Conformance/Cardinality: REQUIRED (0-1) <p>(UPC/GTIN/pseudo 
         * UPC number manufacturer's item/catalogue number</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ProductRoleType Code {
            get { return (ProductRoleType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT490000CA.ManufacturedProduct.manufacturedMaterialKind 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"manufacturedMaterialKind"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt490000ca.ManufacturedMaterialKind ManufacturedMaterialKind {
            get { return this.manufacturedMaterialKind; }
            set { this.manufacturedMaterialKind = value; }
        }

        /**
         * <summary>Un-merged Business Name: OrganisationName</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT490000CA.ManufacturedProductOrganization.name 
         * Conformance/Cardinality: MANDATORY (1) <p>Manufacturer 
         * Name</p> Un-merged Business Name: ManufacturerName 
         * Relationship: 
         * COCT_MT290000CA.ManufacturedProductOrganization.name 
         * Conformance/Cardinality: MANDATORY (1) <p>Name of 
         * manufacturer.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"manufacturerManufacturedProductOrganization/name"})]
        public String ManufacturerManufacturedProductOrganizationName {
            get { return this.manufacturerManufacturedProductOrganizationName.Value; }
            set { this.manufacturerManufacturedProductOrganizationName.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: OrganisationTelephoneEmail</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT490000CA.ManufacturedProductOrganization.telecom 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Organisation 
         * telephone/email</p> Un-merged Business Name: 
         * ManufacturerTelecom Relationship: 
         * COCT_MT290000CA.ManufacturedProductOrganization.telecom 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Telephone no. for 
         * manufacturer</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"manufacturerManufacturedProductOrganization/telecom"})]
        public TelecommunicationAddress ManufacturerManufacturedProductOrganizationTelecom {
            get { return this.manufacturerManufacturedProductOrganizationTelecom.Value; }
            set { this.manufacturerManufacturedProductOrganizationTelecom.Value = value; }
        }

        /**
         * <summary>Business Name: ProductNumber</summary>
         * 
         * <remarks>Un-merged Business Name: ProductNumber 
         * Relationship: COCT_MT290000CA.ManufacturedMaterial.code 
         * Conformance/Cardinality: REQUIRED (1) <p>Code for 
         * manufactured material eg. DIN/PIN</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"manufacturedMaterial/code"})]
        public EntityCode ManufacturedMaterialCode {
            get { return (EntityCode) this.manufacturedMaterialCode.Value; }
            set { this.manufacturedMaterialCode.Value = value; }
        }

    }

}