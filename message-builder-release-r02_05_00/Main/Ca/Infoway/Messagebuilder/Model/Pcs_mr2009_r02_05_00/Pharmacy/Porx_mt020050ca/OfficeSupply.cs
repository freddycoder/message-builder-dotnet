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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pharmacy.Porx_mt020050ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pharmacy.Merged;
    using System;


    /**
     * <summary>Business Name: Office Supply</summary>
     * 
     * <p>Allows for tracking of medications supplied to an 
     * office.</p> <p>This is the detailed information about a 
     * medication being supplied for office use.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT020050CA.SupplyEvent"})]
    public class OfficeSupply : MessagePartBean {

        private II id;
        private TS effectiveTime;
        private PQ quantity;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.Dispensed product;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.ServiceDeliveryLocation destinationServiceDeliveryLocation;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pharmacy.Merged.SupplyOrder fulfillmentSupplyRequest;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.Includes subjectOf;

        public OfficeSupply() {
            this.id = new IIImpl();
            this.effectiveTime = new TSImpl();
            this.quantity = new PQImpl();
        }
        /**
         * <summary>Business Name: A:Local Dispense ID</summary>
         * 
         * <remarks>Relationship: PORX_MT020050CA.SupplyEvent.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows formal 
         * tracking of centrally recorded dispenses to local records 
         * for audit and related purposes.</p> <p>Identifier assigned 
         * by the dispensing facility.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: A:Supply Date</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT020050CA.SupplyEvent.effectiveTime 
         * Conformance/Cardinality: MANDATORY (1) <p>Needed for audit 
         * purposes.</p><p>Because the supply date is always known, the 
         * attribute is mandatory.</p> <p>Must be able to post date a 
         * dispense (enter retroactively) e.g. system failure</p> 
         * <p>Represents the date medication was supplied.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public PlatformDate EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: B:Supplied Quantity</summary>
         * 
         * <remarks>Relationship: PORX_MT020050CA.SupplyEvent.quantity 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for 
         * auditing of medication dispensed to an office. This is 
         * mandatory to allow reconciliation with the amount used from 
         * the office.</p> <p>The amount of medication that has been 
         * dispensed. Includes unit of measure.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"quantity"})]
        public PhysicalQuantity Quantity {
            get { return this.quantity.Value; }
            set { this.quantity.Value = value; }
        }

        /**
         * <summary>Relationship: PORX_MT020050CA.SupplyEvent.product</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"product"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.Dispensed Product {
            get { return this.product; }
            set { this.product = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT020050CA.Destination2.serviceDeliveryLocation</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"destination/serviceDeliveryLocation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.ServiceDeliveryLocation DestinationServiceDeliveryLocation {
            get { return this.destinationServiceDeliveryLocation; }
            set { this.destinationServiceDeliveryLocation = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT020050CA.InFulfillmentOf.supplyRequest</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"fulfillment/supplyRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pharmacy.Merged.SupplyOrder FulfillmentSupplyRequest {
            get { return this.fulfillmentSupplyRequest; }
            set { this.fulfillmentSupplyRequest = value; }
        }

        /**
         * <summary>Relationship: PORX_MT020050CA.SupplyEvent.subjectOf</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.Includes SubjectOf {
            get { return this.subjectOf; }
            set { this.subjectOf = value; }
        }

    }

}