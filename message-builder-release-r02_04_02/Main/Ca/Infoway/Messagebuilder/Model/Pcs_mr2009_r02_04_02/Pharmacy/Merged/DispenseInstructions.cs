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
 * Last modified: $LastChangedDate: 2013-03-08 11:06:36 -0500 (Fri, 08 Mar 2013) $
 * Revision:      $LastChangedRevision: 6699 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Porx_mt010140ca;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: DispenseInstructions</summary>
     * 
     * <remarks>PORX_MT060040CA.SupplyRequest: Dispense 
     * Instructions <p>At least one of Days Supply and Fill 
     * Quantity must be identified.</p> <p>Sets the parameters 
     * within which the dispenser must operate in dispensing the 
     * device to the patient.</p> <p>Specification of how the 
     * prescribed device is to be dispensed to the patient. 
     * Dispensed instruction information includes the quantity to 
     * be dispensed, how often the quantity is to be dispensed, 
     * etc.</p> PORX_MT060060CA.SupplyRequest: Dispense 
     * Instructions <p>Sets the parameters within which the 
     * dispenser must operate in dispensing the device to the 
     * patient.</p> <p>Specification of how the prescribed device 
     * is to be dispensed to the patient. Dispensed instruction 
     * information includes the quantity to be dispensed, how often 
     * the quantity is to be dispensed, etc.</p> 
     * PORX_MT010140CA.SupplyRequest: Dispense Instructions <p>Sets 
     * the parameters within which the dispenser must operate.</p> 
     * <p>This is the information that describes the authorization 
     * for a dispenser to dispense the prescription.</p> 
     * PORX_MT010110CA.SupplyRequest: Dispense Instructions <p>One 
     * of quantity and expectedUseTime must be specified</p> 
     * <p>Sets the parameters within which the dispenser must 
     * operate in dispensing the device to the patient.</p> 
     * <p>Specification of how the prescribed device is to be 
     * dispensed to the patient. Dispensed instruction information 
     * includes the quantity to be dispensed, how often the 
     * quantity is to be dispensed, etc.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT010110CA.SupplyRequest","PORX_MT010140CA.SupplyRequest","PORX_MT060040CA.SupplyRequest","PORX_MT060060CA.SupplyRequest"})]
    public class DispenseInstructions : MessagePartBean {

        private INT quantity;
        private IVL<TS, Interval<PlatformDate>> expectedUseTime;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Merged.DispenseShipToLocation destinationServiceDeliveryLocation;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.OccurredAt location;
        private CS componentContextControlCode;
        private BL componentContextConductionInd;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Merged.SupplementalFillInformation componentSupplementalFillInformation;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Porx_mt010140ca.RemainingDispenses> fulfillmentSupplyEvent;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.ActRequest componentOfActRequest;

        public DispenseInstructions() {
            this.quantity = new INTImpl();
            this.expectedUseTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.componentContextControlCode = new CSImpl();
            this.componentContextConductionInd = new BLImpl();
            this.fulfillmentSupplyEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Porx_mt010140ca.RemainingDispenses>();
        }
        /**
         * <summary>Business Name: TotalPrescribedQuantity</summary>
         * 
         * <remarks>Un-merged Business Name: TotalPrescribedQuantity 
         * Relationship: PORX_MT060040CA.SupplyRequest.quantity 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Sets upper limit 
         * for devices to be dispensed. Can be used to verify the 
         * intention of the prescriber with respect to the overall 
         * prescription. Used for comparison when determining whether 
         * additional quantity may be dispensed in the context of a 
         * part-fill prescription.</p> <p>The overall number of devices 
         * to be dispensed under this prescription. Includes any first 
         * fills (trials, aligning quantities), the initial standard 
         * fill plus all refills.</p> Un-merged Business Name: 
         * TotalPrescribedQuantity Relationship: 
         * PORX_MT060060CA.SupplyRequest.quantity 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Sets upper limit 
         * for devices to be dispensed. Can be used to verify the 
         * intention of the prescriber with respect to the overall 
         * prescription. Used for comparison when determining whether 
         * additional quantity may be dispensed in the context of a 
         * part-fill prescription.</p> <p>The overall number of devices 
         * to be dispensed under this prescription. Includes any first 
         * fills (trials, aligning quantities), the initial standard 
         * fill plus all refills.</p> Un-merged Business Name: 
         * TotalPrescribedQuantity Relationship: 
         * PORX_MT010110CA.SupplyRequest.quantity 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Sets upper limit 
         * for device to be dispensed. Can be used to verify the 
         * intention of the prescriber with respect to the overall 
         * prescription. Used for comparison when determining whether 
         * additional quantity may be dispensed in the context of a 
         * part-fill prescription.</p> <p>The overall number of devices 
         * to be dispensed under this prescription. Includes any first 
         * fills (trials, aligning quantities), the initial standard 
         * fill plus all refills.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"quantity"})]
        public int? Quantity {
            get { return this.quantity.Value; }
            set { this.quantity.Value = value; }
        }

        /**
         * <summary>Business Name: TotalDaysSupply</summary>
         * 
         * <remarks>Un-merged Business Name: TotalDaysSupply 
         * Relationship: PORX_MT060040CA.SupplyRequest.expectedUseTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Used to specify a 
         * total authorization as a duration rather than a quantity 
         * with refills. E.g. dispense 30 at a time, refill for 1 year. 
         * May also be sent as an estimate of the expected overall 
         * duration of the prescription based on the quantity 
         * prescribed.</p> <p>The number of days that the overall 
         * prescribed item is expected to last, if the patient is 
         * compliant with the dispensing and use of the 
         * prescription.</p> Un-merged Business Name: TotalDaysSupply 
         * Relationship: PORX_MT010110CA.SupplyRequest.expectedUseTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Used to specify a 
         * total authorization as a duration rather than a quantity 
         * with refills. E.g. dispense 30 at a time, refill for 1 year. 
         * May also be sent as an estimate of the expected overall 
         * duration of the prescription based on the quantity 
         * prescribed.</p> <p>The number of days that the overall 
         * prescribed item is expected to last, if the patient is 
         * compliant with the dispensing and use of the 
         * prescription.</p></remarks>
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
         * PORX_MT060040CA.Destination1.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT010110CA.Destination1.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"destination/serviceDeliveryLocation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Merged.DispenseShipToLocation DestinationServiceDeliveryLocation {
            get { return this.destinationServiceDeliveryLocation; }
            set { this.destinationServiceDeliveryLocation = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060040CA.SupplyRequest.location 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060060CA.SupplyRequest.location 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT010140CA.SupplyRequest.location 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT010110CA.SupplyRequest.location 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.OccurredAt Location {
            get { return this.location; }
            set { this.location = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060040CA.Component3.contextControlCode 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component/contextControlCode"})]
        public ContextControl ComponentContextControlCode {
            get { return (ContextControl) this.componentContextControlCode.Value; }
            set { this.componentContextControlCode.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060040CA.Component3.contextConductionInd 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component/contextConductionInd"})]
        public bool? ComponentContextConductionInd {
            get { return this.componentContextConductionInd.Value; }
            set { this.componentContextConductionInd.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060040CA.Component3.supplementalFillInformation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT010110CA.Component.supplementalFillInformation 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component/supplementalFillInformation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Merged.SupplementalFillInformation ComponentSupplementalFillInformation {
            get { return this.componentSupplementalFillInformation; }
            set { this.componentSupplementalFillInformation = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT010140CA.InFulfillmentOf.supplyEvent 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"fulfillment/supplyEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Porx_mt010140ca.RemainingDispenses> FulfillmentSupplyEvent {
            get { return this.fulfillmentSupplyEvent; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: PORX_MT010140CA.Component6.actRequest 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"componentOf/actRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.ActRequest ComponentOfActRequest {
            get { return this.componentOfActRequest; }
            set { this.componentOfActRequest = value; }
        }

    }

}