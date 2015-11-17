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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt490000ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Domainvalue;
    using System;


    /**
     * <summary>Business Name: Manufactured Material Kind</summary>
     * 
     * <p>Type of Product</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT490000CA.ManufacturedMaterialKind"})]
    public class ManufacturedMaterialKind : MessagePartBean {

        private CV code;
        private ST desc;
        private IVL<TS, Interval<PlatformDate>> asWarrantorEffectiveTime;
        private ST asWarrantorWarrantingWarrantorOrganizationName;
        private TEL asWarrantorWarrantingWarrantorOrganizationTelecom;
        private PQ contentPackagedProductQuantity;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt490000ca.ManufacturedMaterialKind contentPackagedProductContainedManufacturedMaterialKind;

        public ManufacturedMaterialKind() {
            this.code = new CVImpl();
            this.desc = new STImpl();
            this.asWarrantorEffectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.asWarrantorWarrantingWarrantorOrganizationName = new STImpl();
            this.asWarrantorWarrantingWarrantorOrganizationTelecom = new TELImpl();
            this.contentPackagedProductQuantity = new PQImpl();
        }
        /**
         * <summary>Business Name: Manufactured material code</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT490000CA.ManufacturedMaterialKind.code 
         * Conformance/Cardinality: REQUIRED (1) <p>Code for 
         * manufactured material</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public MaterialEntityClassType Code {
            get { return (MaterialEntityClassType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Package description</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT490000CA.ManufacturedMaterialKind.desc 
         * Conformance/Cardinality: REQUIRED (0-1) <p>box, blister 
         * pack, compliance packaging, etc. HC-PCS?</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"desc"})]
        public String Desc {
            get { return this.desc.Value; }
            set { this.desc.Value = value; }
        }

        /**
         * <summary>Business Name: Time of warranty</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT490000CA.Warrantor.effectiveTime 
         * Conformance/Cardinality: MANDATORY (1) <p>time of 
         * warranty</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"asWarrantor/effectiveTime"})]
        public Interval<PlatformDate> AsWarrantorEffectiveTime {
            get { return this.asWarrantorEffectiveTime.Value; }
            set { this.asWarrantorEffectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: Warrantor Organisation Name</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT490000CA.WarrantorOrganization.name 
         * Conformance/Cardinality: MANDATORY (1) <p>name of 
         * Organization that holds warranty</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"asWarrantor/warrantingWarrantorOrganization/name"})]
        public String AsWarrantorWarrantingWarrantorOrganizationName {
            get { return this.asWarrantorWarrantingWarrantorOrganizationName.Value; }
            set { this.asWarrantorWarrantingWarrantorOrganizationName.Value = value; }
        }

        /**
         * <summary>Business Name: Warrantor Organisation telecom</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT490000CA.WarrantorOrganization.telecom 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Warrantor 
         * Organization telephone number</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"asWarrantor/warrantingWarrantorOrganization/telecom"})]
        public TelecommunicationAddress AsWarrantorWarrantingWarrantorOrganizationTelecom {
            get { return this.asWarrantorWarrantingWarrantorOrganizationTelecom.Value; }
            set { this.asWarrantorWarrantingWarrantorOrganizationTelecom.Value = value; }
        }

        /**
         * <summary>Business Name: Package Quantity</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT490000CA.ContentPackagedProduct.quantity 
         * Conformance/Cardinality: REQUIRED (1) <p>number of items in 
         * the package</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"contentPackagedProduct/quantity"})]
        public PhysicalQuantity ContentPackagedProductQuantity {
            get { return this.contentPackagedProductQuantity.Value; }
            set { this.contentPackagedProductQuantity.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT490000CA.ContentPackagedProduct.containedManufacturedMaterialKind</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"contentPackagedProduct/containedManufacturedMaterialKind"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt490000ca.ManufacturedMaterialKind ContentPackagedProductContainedManufacturedMaterialKind {
            get { return this.contentPackagedProductContainedManufacturedMaterialKind; }
            set { this.contentPackagedProductContainedManufacturedMaterialKind = value; }
        }

    }

}