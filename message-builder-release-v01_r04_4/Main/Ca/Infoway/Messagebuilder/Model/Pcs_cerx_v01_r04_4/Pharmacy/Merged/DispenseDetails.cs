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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt040205ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt141007ca;
    using System;


    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT020060CA.SupplyEvent","PORX_MT060010CA.SupplyEvent","PORX_MT060020CA.SupplyEvent","PORX_MT060040CA.SupplyEvent"})]
    public class DispenseDetails : MessagePartBean {

        private CV code;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private INT quantity;
        private IVL<TS, Interval<PlatformDate>> expectedUseTime;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt141007ca.DeviceProduct productManufacturedProduct;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.DispenseShipToLocation destinationServiceDeliveryLocation;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt040205ca.ResponsiblePerson receiverResponsibleParty;

        public DispenseDetails() {
            this.code = new CVImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.quantity = new INTImpl();
            this.expectedUseTime = new IVLImpl<TS, Interval<PlatformDate>>();
        }
        /**
         * <summary>Business Name: DispenseType</summary>
         * 
         * <remarks>Un-merged Business Name: DispenseType Relationship: 
         * PORX_MT020060CA.SupplyEvent.code Conformance/Cardinality: 
         * MANDATORY (1) <p>DispensedItem.activityType</p> <p>D52</p> 
         * <p>ZDP.2</p> <p>Claim.403-D3</p> <p>Claim.343-HD</p> 
         * <p>A_BillablePharmacyDispense</p> <p>Indicates reason for 
         * the size of dispense. Because it defines what type of 
         * dispense is occurring, the attribute is mandatory.</p> 
         * <p>Indicates the type of dispensing event that is performed. 
         * Examples include: Trial Fill, Completion of Trial, Partial 
         * Fill, Emergency Fill, Samples, etc.</p> Un-merged Business 
         * Name: DispenseType Relationship: 
         * PORX_MT060010CA.SupplyEvent.code Conformance/Cardinality: 
         * MANDATORY (1) <p>DispensedItem.activityType</p> <p>D52</p> 
         * <p>ZDP.2</p> <p>Claim.403-D3</p> <p>Claim.343-HD</p> 
         * <p>A_BillablePharmacyDispense</p> <p>Indicates reason for 
         * the size of dispense. Because it defines what type of 
         * dispense is occurring, the attribute is mandatory.</p> 
         * <p>Indicates the type of dispensing event that is performed. 
         * Examples include: Trial Fill, Completion of Trial, Partial 
         * Fill, Emergency Fill, Samples, etc.</p> Un-merged Business 
         * Name: DispenseType Relationship: 
         * PORX_MT060040CA.SupplyEvent.code Conformance/Cardinality: 
         * MANDATORY (1) <p>DispensedItem.activityType</p> <p>D52</p> 
         * <p>ZDP.2</p> <p>Claim.403-D3</p> <p>Claim.343-HD</p> 
         * <p>A_BillablePharmacyDispense</p> <p>Indicates reason for 
         * the size of dispense. Because it defines what type of 
         * dispense is occurring, the attribute is mandatory.</p> 
         * <p>Indicates the type of dispensing event that is performed. 
         * Examples include: Trial Fill, Completion of Trial, Partial 
         * Fill, Emergency Fill, Samples, etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActPharmacySupplyType Code {
            get { return (ActPharmacySupplyType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: DispenseProcessingAndPickupDate</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * DispenseProcessingAndPickupDate Relationship: 
         * PORX_MT020060CA.SupplyEvent.effectiveTime 
         * Conformance/Cardinality: MANDATORY (1) <p>ZPB3.9</p> 
         * <p>ZDP.17 (high)</p> <p>DRU.040-02 (low, qualifier=07, 
         * format=102)</p> <p>DRU.040-02 (low, qualifier=36, 
         * format=102)</p> <p>A_BillablePharmacyDispense</p> 
         * <p>Dispense Date</p> <p>Dispense Date</p> 
         * <p>DispensedItem.dispenseDate</p> 
         * <p>A_BillablePharmacyDispense</p> <p>Used by the system in 
         * calculating expected exhaustion time. Valuable in compliance 
         * checking. This attribute is mandatory because an existing 
         * dispense record must at least indicate the date it was 
         * processed.</p> <p>Must be able to post-date a dispense 
         * (enter retroactively) e.g. system failure.</p> <p>Represents 
         * the date the dispense product was prepared and when the 
         * product was picked up by or delivered to the patient. The 
         * dispense processing date and pickup date can be back dated 
         * to reflect when the actual processing and pickup occurred. 
         * The lower-bound of the period signifies the 
         * dispense-processing date whereas the upper-bound signifies 
         * the dispense-pickup date.</p> Un-merged Business Name: 
         * DispenseProcessingAndPickupDate Relationship: 
         * PORX_MT060010CA.SupplyEvent.effectiveTime 
         * Conformance/Cardinality: MANDATORY (1) <p>ZPB3.9</p> 
         * <p>ZDP.17 (high)</p> <p>DRU.040-02 (low, qualifier=07, 
         * format=102)</p> <p>DRU.040-02 (low, qualifier=36, 
         * format=102)</p> <p>A_BillablePharmacyDispense</p> 
         * <p>Dispense Date</p> <p>Dispense Date</p> 
         * <p>DispensedItem.dispenseDate</p> 
         * <p>A_BillablePharmacyDispense</p> <p>Used by the system in 
         * calculating expected exhaustion time. Valuable in compliance 
         * checking. This attribute is mandatory because an existing 
         * dispense record must at least indicate the date it was 
         * processed.</p> <p>Represents the date the dispense product 
         * was prepared and when the product was picked up by or 
         * delivered to the patient. The dispense processing date and 
         * pickup date can be back dated to reflect when the actual 
         * processing and pickup occurred. The lower-bound of the 
         * period signifies the dispense-processing date whereas the 
         * upper-bound signifies the dispense-pickup date.</p> 
         * Un-merged Business Name: DispenseProcessingAndPickupDate 
         * Relationship: PORX_MT060020CA.SupplyEvent.effectiveTime 
         * Conformance/Cardinality: MANDATORY (1) <p>ZPB3.9</p> 
         * <p>ZDP.17 (high)</p> <p>DRU.040-02 (low, qualifier=07, 
         * format=102)</p> <p>DRU.040-02 (low, qualifier=36, 
         * format=102)</p> <p>A_BillablePharmacyDispense</p> 
         * <p>Dispense Date</p> <p>Dispense Date</p> 
         * <p>DispensedItem.dispenseDate</p> 
         * <p>A_BillablePharmacyDispense</p> <p>Used by the system in 
         * calculating expected exhaustion time. Valuable in compliance 
         * checking.</p><p>This attribute is mandatory because an 
         * existing dispense record must at least indicate the date it 
         * was processed.</p> <p>Represents the date the dispense 
         * product was prepared and when the product was picked up by 
         * or delivered to the patient. The dispense processing date 
         * and pickup date can be back dated to reflect when the actual 
         * processing and pickup occurred. The lower-bound of the 
         * period signifies the dispense-processing date whereas the 
         * upper-bound signifies the dispense-pickup date.</p> 
         * Un-merged Business Name: DispenseProcessingAndPickupDate 
         * Relationship: PORX_MT060040CA.SupplyEvent.effectiveTime 
         * Conformance/Cardinality: MANDATORY (1) <p>ZPB3.9</p> 
         * <p>ZDP.17 (high)</p> <p>DRU.040-02 (low, qualifier=07, 
         * format=102)</p> <p>DRU.040-02 (low, qualifier=36, 
         * format=102)</p> <p>A_BillablePharmacyDispense</p> 
         * <p>Dispense Date</p> <p>Dispense Date</p> 
         * <p>DispensedItem.dispenseDate</p> 
         * <p>A_BillablePharmacyDispense</p> <p>Used by the system in 
         * calculating expected exhaustion time. Valuable in compliance 
         * checking. This attribute is mandatory because an existing 
         * dispense record must at least indicate the date it was 
         * processed.</p> <p>Represents the date the dispense product 
         * was prepared and when the product was picked up by or 
         * delivered to the patient. The dispense processing date and 
         * pickup date can be back dated to reflect when the actual 
         * processing and pickup occurred. The lower-bound of the 
         * period signifies the dispense-processing date whereas the 
         * upper-bound signifies the dispense-pickup date.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: DispensedQuantity</summary>
         * 
         * <remarks>Un-merged Business Name: DispensedQuantity 
         * Relationship: PORX_MT020060CA.SupplyEvent.quantity 
         * Conformance/Cardinality: MANDATORY (1) <p>D58</p> 
         * <p>ZPB3.4</p> <p>ZDP.10.1</p> <p>ZDP.10.2.1 (the fact that 
         * it is package is determined by a playing entity)</p> 
         * <p>ZDP.9.1</p> <p>ZDP.9.2.1 (the fact that it is package is 
         * determined by a playing entity)</p> <p>DRU.020-01 (Unit, 
         * qualifier=38 0r 87)</p> <p>DRU.020-02 (Quantity, 
         * qualifier=38 0r 87)</p> <p>DRU.020-03 (qualifier=38 0r 
         * 87)</p> <p>Claim.442-E7</p> <p>Claim.460-ET</p> 
         * <p>Claim.600-28</p> <p>A_BillablePharmacyDispense</p> 
         * <p>Quantity</p> <p>DispensedItem.dispensedAmount</p> 
         * <p>Critical in understanding the patient's profile, both 
         * past and current, This is also mandatory to allow 
         * determination of the amount that remains to be dispensed 
         * against the prescription.</p> <p>The number of devices that 
         * have been dispensed.</p> Un-merged Business Name: 
         * DispensedQuantity Relationship: 
         * PORX_MT060010CA.SupplyEvent.quantity 
         * Conformance/Cardinality: MANDATORY (1) <p>D58</p> 
         * <p>ZPB3.4</p> <p>ZDP.10.1</p> <p>ZDP.10.2.1 (the fact that 
         * it is package is determined by a playing entity)</p> 
         * <p>ZDP.9.1</p> <p>ZDP.9.2.1 (the fact that it is package is 
         * determined by a playing entity)</p> <p>DRU.020-01 (Unit, 
         * qualifier=38 0r 87)</p> <p>DRU.020-02 (Quantity, 
         * qualifier=38 0r 87)</p> <p>DRU.020-03 (qualifier=38 0r 
         * 87)</p> <p>Claim.442-E7</p> <p>Claim.460-ET</p> 
         * <p>Claim.600-28</p> <p>A_BillablePharmacyDispense</p> 
         * <p>Quantity</p> <p>DispensedItem.dispensedAmount</p> 
         * <p>Critical in understanding the patient's profile, both 
         * past and current, This is also mandatory to allow 
         * determination of the amount that remains to be dispensed 
         * against the prescription.</p> <p>The number of devices that 
         * have been dispensed.</p> Un-merged Business Name: 
         * DispensedQuantity Relationship: 
         * PORX_MT060020CA.SupplyEvent.quantity 
         * Conformance/Cardinality: MANDATORY (1) <p>D58</p> 
         * <p>ZPB3.4</p> <p>ZDP.10.1</p> <p>ZDP.10.2.1 (the fact that 
         * it is package is determined by a playing entity)</p> 
         * <p>ZDP.9.1</p> <p>ZDP.9.2.1 (the fact that it is package is 
         * determined by a playing entity)</p> <p>DRU.020-01 (Unit, 
         * qualifier=38 0r 87)</p> <p>DRU.020-02 (Quantity, 
         * qualifier=38 0r 87)</p> <p>DRU.020-03 (qualifier=38 0r 
         * 87)</p> <p>Claim.442-E7</p> <p>Claim.460-ET</p> 
         * <p>Claim.600-28</p> <p>A_BillablePharmacyDispense</p> 
         * <p>Quantity</p> <p>DispensedItem.dispensedAmount</p> 
         * <p>Critical in understanding the patient's profile, both 
         * past and current, This is also mandatory to allow 
         * determination of the amount that remains to be dispensed 
         * against the prescription.</p> <p>The number of devices that 
         * have been dispensed.</p> Un-merged Business Name: 
         * DispensedQuantity Relationship: 
         * PORX_MT060040CA.SupplyEvent.quantity 
         * Conformance/Cardinality: MANDATORY (1) <p>D58</p> 
         * <p>ZPB3.4</p> <p>ZDP.10.1</p> <p>ZDP.10.2.1 (the fact that 
         * it is package is determined by a playing entity)</p> 
         * <p>ZDP.9.1</p> <p>ZDP.9.2.1 (the fact that it is package is 
         * determined by a playing entity)</p> <p>DRU.020-01 (Unit, 
         * qualifier=38 0r 87)</p> <p>DRU.020-02 (Quantity, 
         * qualifier=38 0r 87)</p> <p>DRU.020-03 (qualifier=38 0r 
         * 87)</p> <p>Claim.442-E7</p> <p>Claim.460-ET</p> 
         * <p>Claim.600-28</p> <p>A_BillablePharmacyDispense</p> 
         * <p>Quantity</p> <p>DispensedItem.dispensedAmount</p> 
         * <p>Critical in understanding the patient's profile, both 
         * past and current, This is also mandatory to allow 
         * determination of the amount that remains to be dispensed 
         * against the prescription.</p> <p>The number of devices that 
         * have been dispensed.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"quantity"})]
        public int? Quantity {
            get { return this.quantity.Value; }
            set { this.quantity.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: DispensedDaysSupply</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT020060CA.SupplyEvent.expectedUseTime 
         * Conformance/Cardinality: REQUIRED (1) <p>D59(width)</p> 
         * <p>ZDP.11</p> <p>DRU.040-02 (low, qualifier=ZDS, 
         * format=804)</p> <p>Claim.405-D5</p> 
         * <p>A_BillablePharmacyDispense</p> <p>Days Supply</p> 
         * <p>DispensedItem.daysSupply</p> <p>Useful in monitoring 
         * patient compliance. May also be useful in determining and 
         * managing certain contraindications ('Fill-Too-Soon', 
         * 'Fill-Too-Late', and 'Duration of Therapy'). Because 'Days 
         * Supply' may be necessary to compute total dispensed 
         * quantity, it is made a 'populated' field.</p> <p>The number 
         * of days that the dispensed quantity is expected to last.</p> 
         * Un-merged Business Name: DispensedDaysSupply Relationship: 
         * PORX_MT060010CA.SupplyEvent.expectedUseTime 
         * Conformance/Cardinality: REQUIRED (1) <p>D59(width)</p> 
         * <p>ZDP.11</p> <p>DRU.040-02 (low, qualifier=ZDS, 
         * format=804)</p> <p>Claim.405-D5</p> 
         * <p>A_BillablePharmacyDispense</p> <p>Days Supply</p> 
         * <p>DispensedItem.daysSupply</p> <p>Useful in monitoring 
         * patient compliance. May also be useful in determining and 
         * managing certain contraindications ('Fill-Too-Soon', 
         * 'Fill-Too-Late', and 'Duration of Therapy'). Because 'Days 
         * Supply' may be necessary to compute total dispensed 
         * quantity, it is made a 'populated' field.</p> <p>The number 
         * of days that the dispensed quantity is expected to last. 
         * Cannot be mandatory as there are some situations where 'as 
         * needed' cannot be used to determine days supply.</p> 
         * Un-merged Business Name: DispensedDaysSupply Relationship: 
         * PORX_MT060020CA.SupplyEvent.expectedUseTime 
         * Conformance/Cardinality: REQUIRED (1) <p>D59(width)</p> 
         * <p>ZDP.11</p> <p>DRU.040-02 (low, qualifier=ZDS, 
         * format=804)</p> <p>Claim.405-D5</p> 
         * <p>A_BillablePharmacyDispense</p> <p>Days Supply</p> 
         * <p>DispensedItem.daysSupply</p> <p>Useful in monitoring 
         * patient compliance. May also be useful in determining and 
         * managing certain contraindications ('Fill-Too-Soon', 
         * 'Fill-Too-Late', and 'Duration of Therapy'). Because 'Days 
         * Supply' may be necessary to compute total dispensed 
         * quantity, it is made a 'populated' field.</p> <p>The number 
         * of days that the dispensed quantity is expected to last. 
         * Cannot be mandatory as there are some situations where 'as 
         * needed' cannot be used to determine days supply.</p> 
         * Un-merged Business Name: DispenseDaysSupply Relationship: 
         * PORX_MT060040CA.SupplyEvent.expectedUseTime 
         * Conformance/Cardinality: REQUIRED (1) <p>D59(width)</p> 
         * <p>ZDP.11</p> <p>DRU.040-02 (low, qualifier=ZDS, 
         * format=804)</p> <p>Claim.405-D5</p> 
         * <p>A_BillablePharmacyDispense</p> <p>Days Supply</p> 
         * <p>DispensedItem.daysSupply</p> <p>Useful in monitoring 
         * patient compliance. May also be useful in determining and 
         * managing certain contraindications ('Fill-Too-Soon', 
         * 'Fill-Too-Late', and 'Duration of Therapy'). Because 'Days 
         * Supply' may be necessary to compute total dispensed 
         * quantity, it is made a 'populated' field.</p> <p>The number 
         * of days that the dispensed quantity is expected to 
         * last.</p><p>Cannot be mandatory as there are some situations 
         * where 'as needed' cannot be used to determine days 
         * supply.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"expectedUseTime"})]
        public Interval<PlatformDate> ExpectedUseTime {
            get { return this.expectedUseTime.Value; }
            set { this.expectedUseTime.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT020060CA.Product2.manufacturedProduct 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060010CA.Product2.manufacturedProduct 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060020CA.Product2.manufacturedProduct 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060040CA.Product2.manufacturedProduct 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"product/manufacturedProduct"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt141007ca.DeviceProduct ProductManufacturedProduct {
            get { return this.productManufacturedProduct; }
            set { this.productManufacturedProduct = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT020060CA.Destination2.serviceDeliveryLocation 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060010CA.Destination2.serviceDeliveryLocation 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060040CA.Destination2.serviceDeliveryLocation 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"destination/serviceDeliveryLocation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.DispenseShipToLocation DestinationServiceDeliveryLocation {
            get { return this.destinationServiceDeliveryLocation; }
            set { this.destinationServiceDeliveryLocation = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060010CA.Receiver2.responsibleParty 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060040CA.Receiver2.responsibleParty 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"receiver/responsibleParty"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt040205ca.ResponsiblePerson ReceiverResponsibleParty {
            get { return this.receiverResponsibleParty; }
            set { this.receiverResponsibleParty = value; }
        }

    }

}