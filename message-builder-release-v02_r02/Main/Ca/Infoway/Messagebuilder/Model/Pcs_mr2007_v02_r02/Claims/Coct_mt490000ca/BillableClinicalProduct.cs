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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Coct_mt490000ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Billable Clinical Product</summary>
     * 
     * <p>Patient classes are not referenced in the billable acts, 
     * as they are noted in the parent model (e.g. Invoice message) 
     * as the CoveredPartyAsPatient</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT490000CA.BillableClinicalProduct"})]
    public class BillableClinicalProduct : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Coct_mt280001ca.IA_BillableActChoice {

        private CS moodCode;
        private II id;
        private CV code;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Merged.ManufacturedProduct productManufacturedProduct;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Merged.HealthcareProvider performerHealthCareProvider;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Merged.HealthcareProvider referrerHealthCareProvider;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Merged.HealthcareProvider consultantHealthCareProvider;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Merged.ServiceLocation locationServiceDeliveryLocation;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Merged.ServiceLocation originServiceDeliveryLocation;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Merged.ServiceLocation destinationServiceDeliveryLocation;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Merged.DiagnosisInformation> pertinentInformation;

        public BillableClinicalProduct() {
            this.moodCode = new CSImpl();
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.pertinentInformation = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Merged.DiagnosisInformation>();
        }
        /**
         * <summary>Relationship: 
         * COCT_MT490000CA.BillableClinicalProduct.moodCode</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"moodCode"})]
        public x_ActMoodIntentEvent MoodCode {
            get { return (x_ActMoodIntentEvent) this.moodCode.Value; }
            set { this.moodCode.Value = value; }
        }

        /**
         * <summary>Business Name: Billable Clinical Product ID</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT490000CA.BillableClinicalProduct.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>receipt number 
         * for the sale or rental</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: Billable Clinical Product Code</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT490000CA.BillableClinicalProduct.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Acquistion Code PO 
         * #</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public x_ActFinancialProductAcquisitionCode Code {
            get { return (x_ActFinancialProductAcquisitionCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Time of Sale</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT490000CA.BillableClinicalProduct.effectiveTime 
         * Conformance/Cardinality: MANDATORY (1) <p>Date that the sale 
         * is transacted (change of ownership for a sale) and could be 
         * different than the date that it is invoiced. Similar in 
         * concept to the service date.</p><p>For rentals, this is the 
         * rental period.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT490000CA.Product.manufacturedProduct</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"product/manufacturedProduct"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Merged.ManufacturedProduct ProductManufacturedProduct {
            get { return this.productManufacturedProduct; }
            set { this.productManufacturedProduct = value; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT490000CA.ResponsibleProvider.healthCareProvider</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"performer/healthCareProvider"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Merged.HealthcareProvider PerformerHealthCareProvider {
            get { return this.performerHealthCareProvider; }
            set { this.performerHealthCareProvider = value; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT490000CA.ProductReferrer.healthCareProvider</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"referrer/healthCareProvider"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Merged.HealthcareProvider ReferrerHealthCareProvider {
            get { return this.referrerHealthCareProvider; }
            set { this.referrerHealthCareProvider = value; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT490000CA.Consultant.healthCareProvider</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"consultant/healthCareProvider"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Merged.HealthcareProvider ConsultantHealthCareProvider {
            get { return this.consultantHealthCareProvider; }
            set { this.consultantHealthCareProvider = value; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT490000CA.ServiceLocation.serviceDeliveryLocation</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location/serviceDeliveryLocation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Merged.ServiceLocation LocationServiceDeliveryLocation {
            get { return this.locationServiceDeliveryLocation; }
            set { this.locationServiceDeliveryLocation = value; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT490000CA.ProductLocationOrigin.serviceDeliveryLocation</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"origin/serviceDeliveryLocation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Merged.ServiceLocation OriginServiceDeliveryLocation {
            get { return this.originServiceDeliveryLocation; }
            set { this.originServiceDeliveryLocation = value; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT490000CA.ProductLocationDestination.serviceDeliveryLocation</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"destination/serviceDeliveryLocation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Merged.ServiceLocation DestinationServiceDeliveryLocation {
            get { return this.destinationServiceDeliveryLocation; }
            set { this.destinationServiceDeliveryLocation = value; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT490000CA.BillableClinicalProduct.pertinentInformation</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-10)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"pertinentInformation"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Merged.DiagnosisInformation> PertinentInformation {
            get { return this.pertinentInformation; }
        }

    }

}