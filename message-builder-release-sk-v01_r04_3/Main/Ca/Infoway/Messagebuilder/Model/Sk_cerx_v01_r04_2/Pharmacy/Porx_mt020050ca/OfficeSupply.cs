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
namespace Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Porx_mt020050ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt120600ca;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt220200ca;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged;
    using System;


    /**
     * <summary>Business Name: Office Supply</summary>
     * 
     * <p>This is the detailed information about a medication being 
     * supplied for office use.</p> <p>Allows for tracking of 
     * medications supplied to an office.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT020050CA.SupplyEvent"})]
    public class OfficeSupply : MessagePartBean {

        private II id;
        private CV code;
        private TS effectiveTime;
        private PQ quantity;
        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt220200ca.DrugProduct productMedication;
        private II destinationServiceDeliveryLocationId;
        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged.SupplyOrder fulfillmentSupplyRequest;
        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt120600ca.Notes subjectOfAnnotation;

        public OfficeSupply() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.effectiveTime = new TSImpl();
            this.quantity = new PQImpl();
            this.destinationServiceDeliveryLocationId = new IIImpl();
        }
        /**
         * <summary>Business Name: A:Local Dispense ID</summary>
         * 
         * <remarks>Relationship: PORX_MT020050CA.SupplyEvent.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Identifier 
         * assigned by the dispensing facility.</p> <p>Allows formal 
         * tracking of centrally recorded dispenses to local records 
         * for audit and related purposes.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: Dispense Type</summary>
         * 
         * <remarks>Relationship: PORX_MT020050CA.SupplyEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates the type 
         * of dispensing event that is being performed.</p><p>This is a 
         * fixed dispense type of 'Office Supply' unless using 
         * SNOMED.</p> <p>Indicates the type of dispensing event that 
         * is being performed.</p><p>This is a fixed dispense type of 
         * 'Office Supply' unless using SNOMED.</p> 
         * <p>DispensedItem.activityType</p><p>D52</p><p>ZDP.2</p><p>Claim.403-D3</p><p>Claim.343-HD</p><p>A_BillablePharmacyDispense</p> 
         * <p>DispensedItem.activityType</p><p>D52</p><p>ZDP.2</p><p>Claim.403-D3</p><p>Claim.343-HD</p><p>A_BillablePharmacyDispense</p> 
         * <p>DispensedItem.activityType</p><p>D52</p><p>ZDP.2</p><p>Claim.403-D3</p><p>Claim.343-HD</p><p>A_BillablePharmacyDispense</p> 
         * <p>DispensedItem.activityType</p><p>D52</p><p>ZDP.2</p><p>Claim.403-D3</p><p>Claim.343-HD</p><p>A_BillablePharmacyDispense</p> 
         * <p>DispensedItem.activityType</p><p>D52</p><p>ZDP.2</p><p>Claim.403-D3</p><p>Claim.343-HD</p><p>A_BillablePharmacyDispense</p> 
         * <p>DispensedItem.activityType</p><p>D52</p><p>ZDP.2</p><p>Claim.403-D3</p><p>Claim.343-HD</p><p>A_BillablePharmacyDispense</p> 
         * <p>Indicates reason for the size of dispense. Because it 
         * defines what type of dispense is occurring, the attribute is 
         * mandatory.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActCode Code {
            get { return (ActCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: A:Supply Date</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT020050CA.SupplyEvent.effectiveTime 
         * Conformance/Cardinality: MANDATORY (1) <p>Represents the 
         * date medication was supplied.</p> <p>ZPB3.9</p><p>ZDP.17 
         * (high)</p><p>DRU.040-02 (low, qualifier=07, 
         * format=102)</p><p>DRU.040-02 (low, qualifier=36, 
         * format=102)</p><p>A_BillablePharmacyDispense</p><p>Dispense 
         * Date</p><p>Dispense 
         * Date</p><p>DispensedItem.dispenseDate</p><p>A_BillablePharmacyDispense</p> 
         * <p>ZPB3.9</p><p>ZDP.17 (high)</p><p>DRU.040-02 (low, 
         * qualifier=07, format=102)</p><p>DRU.040-02 (low, 
         * qualifier=36, 
         * format=102)</p><p>A_BillablePharmacyDispense</p><p>Dispense 
         * Date</p><p>Dispense 
         * Date</p><p>DispensedItem.dispenseDate</p><p>A_BillablePharmacyDispense</p> 
         * <p>ZPB3.9</p><p>ZDP.17 (high)</p><p>DRU.040-02 (low, 
         * qualifier=07, format=102)</p><p>DRU.040-02 (low, 
         * qualifier=36, 
         * format=102)</p><p>A_BillablePharmacyDispense</p><p>Dispense 
         * Date</p><p>Dispense 
         * Date</p><p>DispensedItem.dispenseDate</p><p>A_BillablePharmacyDispense</p> 
         * <p>ZPB3.9</p><p>ZDP.17 (high)</p><p>DRU.040-02 (low, 
         * qualifier=07, format=102)</p><p>DRU.040-02 (low, 
         * qualifier=36, 
         * format=102)</p><p>A_BillablePharmacyDispense</p><p>Dispense 
         * Date</p><p>Dispense 
         * Date</p><p>DispensedItem.dispenseDate</p><p>A_BillablePharmacyDispense</p> 
         * <p>ZPB3.9</p><p>ZDP.17 (high)</p><p>DRU.040-02 (low, 
         * qualifier=07, format=102)</p><p>DRU.040-02 (low, 
         * qualifier=36, 
         * format=102)</p><p>A_BillablePharmacyDispense</p><p>Dispense 
         * Date</p><p>Dispense 
         * Date</p><p>DispensedItem.dispenseDate</p><p>A_BillablePharmacyDispense</p> 
         * <p>ZPB3.9</p><p>ZDP.17 (high)</p><p>DRU.040-02 (low, 
         * qualifier=07, format=102)</p><p>DRU.040-02 (low, 
         * qualifier=36, 
         * format=102)</p><p>A_BillablePharmacyDispense</p><p>Dispense 
         * Date</p><p>Dispense 
         * Date</p><p>DispensedItem.dispenseDate</p><p>A_BillablePharmacyDispense</p> 
         * <p>ZPB3.9</p><p>ZDP.17 (high)</p><p>DRU.040-02 (low, 
         * qualifier=07, format=102)</p><p>DRU.040-02 (low, 
         * qualifier=36, 
         * format=102)</p><p>A_BillablePharmacyDispense</p><p>Dispense 
         * Date</p><p>Dispense 
         * Date</p><p>DispensedItem.dispenseDate</p><p>A_BillablePharmacyDispense</p> 
         * <p>ZPB3.9</p><p>ZDP.17 (high)</p><p>DRU.040-02 (low, 
         * qualifier=07, format=102)</p><p>DRU.040-02 (low, 
         * qualifier=36, 
         * format=102)</p><p>A_BillablePharmacyDispense</p><p>Dispense 
         * Date</p><p>Dispense 
         * Date</p><p>DispensedItem.dispenseDate</p><p>A_BillablePharmacyDispense</p> 
         * <p>ZPB3.9</p><p>ZDP.17 (high)</p><p>DRU.040-02 (low, 
         * qualifier=07, format=102)</p><p>DRU.040-02 (low, 
         * qualifier=36, 
         * format=102)</p><p>A_BillablePharmacyDispense</p><p>Dispense 
         * Date</p><p>Dispense 
         * Date</p><p>DispensedItem.dispenseDate</p><p>A_BillablePharmacyDispense</p> 
         * <p>Needed for audit purposes.</p><p>Because the supply date 
         * is always known, the attribute is mandatory.</p> <p>Needed 
         * for audit purposes.</p><p>Because the supply date is always 
         * known, the attribute is mandatory.</p> <p>Must be able to 
         * post date a dispense (enter retroactively) e.g. system 
         * failure</p></remarks>
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
         * Conformance/Cardinality: MANDATORY (1) <p>The amount of 
         * medication that has been dispensed. Includes unit of 
         * measure.</p> 
         * <p>D58</p><p>ZPB3.4</p><p>ZDP.10.1</p><p>ZDP.10.2.1 (the 
         * fact that it is package is determined by a playing 
         * entity)</p><p>ZDP.9.1</p><p>ZDP.9.2.1 (the fact that it is 
         * package is determined by a playing entity)</p><p>DRU.020-01 
         * (Unit, qualifier=38 0r 87)</p><p>DRU.020-02 (Quantity, 
         * qualifier=38 0r 87)</p><p>DRU.020-03 (qualifier=38 0r 
         * 87)</p><p>Claim.442-E7</p><p>Claim.460-ET</p><p>Claim.600-28</p><p>A_BillablePharmacyDispense</p><p>Quantity</p><p>DispensedItem.dispensedAmount</p> 
         * <p>D58</p><p>ZPB3.4</p><p>ZDP.10.1</p><p>ZDP.10.2.1 (the 
         * fact that it is package is determined by a playing 
         * entity)</p><p>ZDP.9.1</p><p>ZDP.9.2.1 (the fact that it is 
         * package is determined by a playing entity)</p><p>DRU.020-01 
         * (Unit, qualifier=38 0r 87)</p><p>DRU.020-02 (Quantity, 
         * qualifier=38 0r 87)</p><p>DRU.020-03 (qualifier=38 0r 
         * 87)</p><p>Claim.442-E7</p><p>Claim.460-ET</p><p>Claim.600-28</p><p>A_BillablePharmacyDispense</p><p>Quantity</p><p>DispensedItem.dispensedAmount</p> 
         * <p>D58</p><p>ZPB3.4</p><p>ZDP.10.1</p><p>ZDP.10.2.1 (the 
         * fact that it is package is determined by a playing 
         * entity)</p><p>ZDP.9.1</p><p>ZDP.9.2.1 (the fact that it is 
         * package is determined by a playing entity)</p><p>DRU.020-01 
         * (Unit, qualifier=38 0r 87)</p><p>DRU.020-02 (Quantity, 
         * qualifier=38 0r 87)</p><p>DRU.020-03 (qualifier=38 0r 
         * 87)</p><p>Claim.442-E7</p><p>Claim.460-ET</p><p>Claim.600-28</p><p>A_BillablePharmacyDispense</p><p>Quantity</p><p>DispensedItem.dispensedAmount</p> 
         * <p>D58</p><p>ZPB3.4</p><p>ZDP.10.1</p><p>ZDP.10.2.1 (the 
         * fact that it is package is determined by a playing 
         * entity)</p><p>ZDP.9.1</p><p>ZDP.9.2.1 (the fact that it is 
         * package is determined by a playing entity)</p><p>DRU.020-01 
         * (Unit, qualifier=38 0r 87)</p><p>DRU.020-02 (Quantity, 
         * qualifier=38 0r 87)</p><p>DRU.020-03 (qualifier=38 0r 
         * 87)</p><p>Claim.442-E7</p><p>Claim.460-ET</p><p>Claim.600-28</p><p>A_BillablePharmacyDispense</p><p>Quantity</p><p>DispensedItem.dispensedAmount</p> 
         * <p>D58</p><p>ZPB3.4</p><p>ZDP.10.1</p><p>ZDP.10.2.1 (the 
         * fact that it is package is determined by a playing 
         * entity)</p><p>ZDP.9.1</p><p>ZDP.9.2.1 (the fact that it is 
         * package is determined by a playing entity)</p><p>DRU.020-01 
         * (Unit, qualifier=38 0r 87)</p><p>DRU.020-02 (Quantity, 
         * qualifier=38 0r 87)</p><p>DRU.020-03 (qualifier=38 0r 
         * 87)</p><p>Claim.442-E7</p><p>Claim.460-ET</p><p>Claim.600-28</p><p>A_BillablePharmacyDispense</p><p>Quantity</p><p>DispensedItem.dispensedAmount</p> 
         * <p>D58</p><p>ZPB3.4</p><p>ZDP.10.1</p><p>ZDP.10.2.1 (the 
         * fact that it is package is determined by a playing 
         * entity)</p><p>ZDP.9.1</p><p>ZDP.9.2.1 (the fact that it is 
         * package is determined by a playing entity)</p><p>DRU.020-01 
         * (Unit, qualifier=38 0r 87)</p><p>DRU.020-02 (Quantity, 
         * qualifier=38 0r 87)</p><p>DRU.020-03 (qualifier=38 0r 
         * 87)</p><p>Claim.442-E7</p><p>Claim.460-ET</p><p>Claim.600-28</p><p>A_BillablePharmacyDispense</p><p>Quantity</p><p>DispensedItem.dispensedAmount</p> 
         * <p>D58</p><p>ZPB3.4</p><p>ZDP.10.1</p><p>ZDP.10.2.1 (the 
         * fact that it is package is determined by a playing 
         * entity)</p><p>ZDP.9.1</p><p>ZDP.9.2.1 (the fact that it is 
         * package is determined by a playing entity)</p><p>DRU.020-01 
         * (Unit, qualifier=38 0r 87)</p><p>DRU.020-02 (Quantity, 
         * qualifier=38 0r 87)</p><p>DRU.020-03 (qualifier=38 0r 
         * 87)</p><p>Claim.442-E7</p><p>Claim.460-ET</p><p>Claim.600-28</p><p>A_BillablePharmacyDispense</p><p>Quantity</p><p>DispensedItem.dispensedAmount</p> 
         * <p>D58</p><p>ZPB3.4</p><p>ZDP.10.1</p><p>ZDP.10.2.1 (the 
         * fact that it is package is determined by a playing 
         * entity)</p><p>ZDP.9.1</p><p>ZDP.9.2.1 (the fact that it is 
         * package is determined by a playing entity)</p><p>DRU.020-01 
         * (Unit, qualifier=38 0r 87)</p><p>DRU.020-02 (Quantity, 
         * qualifier=38 0r 87)</p><p>DRU.020-03 (qualifier=38 0r 
         * 87)</p><p>Claim.442-E7</p><p>Claim.460-ET</p><p>Claim.600-28</p><p>A_BillablePharmacyDispense</p><p>Quantity</p><p>DispensedItem.dispensedAmount</p> 
         * <p>D58</p><p>ZPB3.4</p><p>ZDP.10.1</p><p>ZDP.10.2.1 (the 
         * fact that it is package is determined by a playing 
         * entity)</p><p>ZDP.9.1</p><p>ZDP.9.2.1 (the fact that it is 
         * package is determined by a playing entity)</p><p>DRU.020-01 
         * (Unit, qualifier=38 0r 87)</p><p>DRU.020-02 (Quantity, 
         * qualifier=38 0r 87)</p><p>DRU.020-03 (qualifier=38 0r 
         * 87)</p><p>Claim.442-E7</p><p>Claim.460-ET</p><p>Claim.600-28</p><p>A_BillablePharmacyDispense</p><p>Quantity</p><p>DispensedItem.dispensedAmount</p> 
         * <p>D58</p><p>ZPB3.4</p><p>ZDP.10.1</p><p>ZDP.10.2.1 (the 
         * fact that it is package is determined by a playing 
         * entity)</p><p>ZDP.9.1</p><p>ZDP.9.2.1 (the fact that it is 
         * package is determined by a playing entity)</p><p>DRU.020-01 
         * (Unit, qualifier=38 0r 87)</p><p>DRU.020-02 (Quantity, 
         * qualifier=38 0r 87)</p><p>DRU.020-03 (qualifier=38 0r 
         * 87)</p><p>Claim.442-E7</p><p>Claim.460-ET</p><p>Claim.600-28</p><p>A_BillablePharmacyDispense</p><p>Quantity</p><p>DispensedItem.dispensedAmount</p> 
         * <p>D58</p><p>ZPB3.4</p><p>ZDP.10.1</p><p>ZDP.10.2.1 (the 
         * fact that it is package is determined by a playing 
         * entity)</p><p>ZDP.9.1</p><p>ZDP.9.2.1 (the fact that it is 
         * package is determined by a playing entity)</p><p>DRU.020-01 
         * (Unit, qualifier=38 0r 87)</p><p>DRU.020-02 (Quantity, 
         * qualifier=38 0r 87)</p><p>DRU.020-03 (qualifier=38 0r 
         * 87)</p><p>Claim.442-E7</p><p>Claim.460-ET</p><p>Claim.600-28</p><p>A_BillablePharmacyDispense</p><p>Quantity</p><p>DispensedItem.dispensedAmount</p> 
         * <p>D58</p><p>ZPB3.4</p><p>ZDP.10.1</p><p>ZDP.10.2.1 (the 
         * fact that it is package is determined by a playing 
         * entity)</p><p>ZDP.9.1</p><p>ZDP.9.2.1 (the fact that it is 
         * package is determined by a playing entity)</p><p>DRU.020-01 
         * (Unit, qualifier=38 0r 87)</p><p>DRU.020-02 (Quantity, 
         * qualifier=38 0r 87)</p><p>DRU.020-03 (qualifier=38 0r 
         * 87)</p><p>Claim.442-E7</p><p>Claim.460-ET</p><p>Claim.600-28</p><p>A_BillablePharmacyDispense</p><p>Quantity</p><p>DispensedItem.dispensedAmount</p> 
         * <p>D58</p><p>ZPB3.4</p><p>ZDP.10.1</p><p>ZDP.10.2.1 (the 
         * fact that it is package is determined by a playing 
         * entity)</p><p>ZDP.9.1</p><p>ZDP.9.2.1 (the fact that it is 
         * package is determined by a playing entity)</p><p>DRU.020-01 
         * (Unit, qualifier=38 0r 87)</p><p>DRU.020-02 (Quantity, 
         * qualifier=38 0r 87)</p><p>DRU.020-03 (qualifier=38 0r 
         * 87)</p><p>Claim.442-E7</p><p>Claim.460-ET</p><p>Claim.600-28</p><p>A_BillablePharmacyDispense</p><p>Quantity</p><p>DispensedItem.dispensedAmount</p> 
         * <p>D58</p><p>ZPB3.4</p><p>ZDP.10.1</p><p>ZDP.10.2.1 (the 
         * fact that it is package is determined by a playing 
         * entity)</p><p>ZDP.9.1</p><p>ZDP.9.2.1 (the fact that it is 
         * package is determined by a playing entity)</p><p>DRU.020-01 
         * (Unit, qualifier=38 0r 87)</p><p>DRU.020-02 (Quantity, 
         * qualifier=38 0r 87)</p><p>DRU.020-03 (qualifier=38 0r 
         * 87)</p><p>Claim.442-E7</p><p>Claim.460-ET</p><p>Claim.600-28</p><p>A_BillablePharmacyDispense</p><p>Quantity</p><p>DispensedItem.dispensedAmount</p> 
         * <p>D58</p><p>ZPB3.4</p><p>ZDP.10.1</p><p>ZDP.10.2.1 (the 
         * fact that it is package is determined by a playing 
         * entity)</p><p>ZDP.9.1</p><p>ZDP.9.2.1 (the fact that it is 
         * package is determined by a playing entity)</p><p>DRU.020-01 
         * (Unit, qualifier=38 0r 87)</p><p>DRU.020-02 (Quantity, 
         * qualifier=38 0r 87)</p><p>DRU.020-03 (qualifier=38 0r 
         * 87)</p><p>Claim.442-E7</p><p>Claim.460-ET</p><p>Claim.600-28</p><p>A_BillablePharmacyDispense</p><p>Quantity</p><p>DispensedItem.dispensedAmount</p> 
         * <p>Allows for auditing of medication dispensed to an office. 
         * This is mandatory to allow reconciliation with the amount 
         * used from the office.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"quantity"})]
        public PhysicalQuantity Quantity {
            get { return this.quantity.Value; }
            set { this.quantity.Value = value; }
        }

        /**
         * <summary>Relationship: PORX_MT020050CA.Product2.medication</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"product/medication"})]
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt220200ca.DrugProduct ProductMedication {
            get { return this.productMedication; }
            set { this.productMedication = value; }
        }

        /**
         * <summary>Business Name: C:Ship-to Facility Id</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT020050CA.ServiceDeliveryLocation.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Identifier of the 
         * facility where the dispensed medication was shipped.</p> 
         * <p>Allows tracking what drugs are dispensed to a facility. 
         * The attribute is mandatory because identification of the 
         * facility must be known.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"destination/serviceDeliveryLocation/id"})]
        public Identifier DestinationServiceDeliveryLocationId {
            get { return this.destinationServiceDeliveryLocationId.Value; }
            set { this.destinationServiceDeliveryLocationId.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT020050CA.InFulfillmentOf.supplyRequest</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"fulfillment/supplyRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged.SupplyOrder FulfillmentSupplyRequest {
            get { return this.fulfillmentSupplyRequest; }
            set { this.fulfillmentSupplyRequest = value; }
        }

        /**
         * <summary>Relationship: PORX_MT020050CA.Subject7.annotation</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf/annotation"})]
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt120600ca.Notes SubjectOfAnnotation {
            get { return this.subjectOfAnnotation; }
            set { this.subjectOfAnnotation = value; }
        }

    }

}