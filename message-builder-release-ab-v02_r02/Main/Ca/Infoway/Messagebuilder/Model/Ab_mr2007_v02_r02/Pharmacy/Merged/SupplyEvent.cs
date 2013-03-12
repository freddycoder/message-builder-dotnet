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
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Merged;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt220210ca;
    using System;


    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060090CA.SupplyEvent","PORX_MT060100CA.SupplyEvent"})]
    public class SupplyEvent : MessagePartBean {

        private CV code;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private PQ quantity;
        private IVL<TS, Interval<PlatformDate>> expectedUseTime;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt220210ca.DrugProduct productMedication;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Merged.RelatedPerson receiverPersonalRelationship;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.DispenseShipToLocation destinationServiceDeliveryLocation;

        public SupplyEvent() {
            this.code = new CVImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.quantity = new PQImpl();
            this.expectedUseTime = new IVLImpl<TS, Interval<PlatformDate>>();
        }
        /**
         * <summary>Business Name: DispenseType</summary>
         * 
         * <remarks>Un-merged Business Name: DispenseType Relationship: 
         * PORX_MT060090CA.SupplyEvent.code Conformance/Cardinality: 
         * MANDATORY (1) <p>Indicates the type of dispensing event that 
         * is performed. Examples include: Trial Fill, Completion of 
         * Trial, Partial Fill, Emergency Fill, Samples, etc.</p> 
         * <p>Indicates reason for the size of dispense. Because it 
         * defines what type of dispense is occurring, the attribute is 
         * mandatory.</p></remarks>
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
         * PORX_MT060090CA.SupplyEvent.effectiveTime 
         * Conformance/Cardinality: MANDATORY (1) <p>Represents the 
         * date the dispense product was prepared and when the product 
         * was picked up by or delivered to the patient. The dispense 
         * processing date and pickup date can be back dated to reflect 
         * when the actual processing and pickup occurred. The 
         * lower-bound of the period signifies the dispense-processing 
         * date whereas the upper-bound signifies the dispense-pickup 
         * date.</p> <p>Used by the system in calculating expected 
         * exhaustion time. Valuable in compliance checking. This 
         * attribute is mandatory because an existing dispense record 
         * must at least indicate the date it was processed.</p> 
         * Un-merged Business Name: DispenseProcessingAndPickupDate 
         * Relationship: PORX_MT060100CA.SupplyEvent.effectiveTime 
         * Conformance/Cardinality: MANDATORY (1) <p>Represents the 
         * date the dispense product was prepared and when the product 
         * was picked up by or delivered to the patient. The dispense 
         * processing date and pickup date can be back dated to reflect 
         * when the actual processing and pickup occurred. The 
         * lower-bound of the period signifies the dispense-processing 
         * date whereas the upper-bound signifies the dispense-pickup 
         * date.</p> <p>Used by the system in calculating expected 
         * exhaustion time. Valuable in compliance checking.</p><p>This 
         * attribute is mandatory because an existing dispense record 
         * must at least indicate the date it was processed.</p> 
         * <p>Used by the system in calculating expected exhaustion 
         * time. Valuable in compliance checking.</p><p>This attribute 
         * is mandatory because an existing dispense record must at 
         * least indicate the date it was processed.</p></remarks>
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
         * Relationship: PORX_MT060090CA.SupplyEvent.quantity 
         * Conformance/Cardinality: MANDATORY (1) <p>The amount of 
         * medication that has been dispensed. Includes unit of 
         * measure.</p> <p>Critical in understanding the patient's 
         * medication profile, both past and current, This is also 
         * mandatory to allow determination of the amount that remains 
         * to be dispensed against the prescription.</p> Un-merged 
         * Business Name: DispensedQuantity Relationship: 
         * PORX_MT060100CA.SupplyEvent.quantity 
         * Conformance/Cardinality: MANDATORY (1) <p>The amount of 
         * medication that has been dispensed. Includes unit of 
         * measure.</p> <p>Critical in understanding the patient's 
         * medication profile, both past and current, This is also 
         * mandatory to allow determination of the amount that remains 
         * to be dispensed against the prescription.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"quantity"})]
        public PhysicalQuantity Quantity {
            get { return this.quantity.Value; }
            set { this.quantity.Value = value; }
        }

        /**
         * <summary>Business Name: DispensedDaysSupply</summary>
         * 
         * <remarks>Un-merged Business Name: DispensedDaysSupply 
         * Relationship: PORX_MT060090CA.SupplyEvent.expectedUseTime 
         * Conformance/Cardinality: POPULATED (1) <p>The number of days 
         * that the dispensed quantity is expected to last. Cannot be 
         * mandatory as there are some situations where 'as needed' 
         * cannot be used to determine days supply.</p> <p>Useful in 
         * monitoring patient compliance. May also be useful in 
         * determining and managing certain contraindications 
         * ('Fill-Too-Soon', 'Fill-Too-Late', and 'Duration of 
         * Therapy'). Because 'Days Supply' may be necessary to compute 
         * total dispensed quantity, it is made a 'populated' 
         * field.</p> Un-merged Business Name: DispensedDaysSupply 
         * Relationship: PORX_MT060100CA.SupplyEvent.expectedUseTime 
         * Conformance/Cardinality: POPULATED (1) <p>The number of days 
         * that the dispensed quantity is expected to last. Cannot be 
         * mandatory as there are some situations where 'as needed' 
         * cannot be used to determine days supply.</p> <p>Useful in 
         * monitoring patient compliance. May also be useful in 
         * determining and managing certain contraindications 
         * ('Fill-Too-Soon', 'Fill-Too-Late', and 'Duration of 
         * Therapy'). Because 'Days Supply' may be necessary to compute 
         * total dispensed quantity, it is made a 'populated' 
         * field.</p></remarks>
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
         * <remarks>Relationship: PORX_MT060090CA.Product2.medication 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060100CA.Product2.medication Conformance/Cardinality: 
         * MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"product/medication"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt220210ca.DrugProduct ProductMedication {
            get { return this.productMedication; }
            set { this.productMedication = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060090CA.Receiver2.personalRelationship 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"receiver/personalRelationship"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Merged.RelatedPerson ReceiverPersonalRelationship {
            get { return this.receiverPersonalRelationship; }
            set { this.receiverPersonalRelationship = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060090CA.Destination2.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"destination/serviceDeliveryLocation"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.DispenseShipToLocation DestinationServiceDeliveryLocation {
            get { return this.destinationServiceDeliveryLocation; }
            set { this.destinationServiceDeliveryLocation = value; }
        }

    }

}