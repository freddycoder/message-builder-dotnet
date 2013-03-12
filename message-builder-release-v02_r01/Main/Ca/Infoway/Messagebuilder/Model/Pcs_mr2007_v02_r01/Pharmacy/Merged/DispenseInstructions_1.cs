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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Porx_mt010120ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Porx_mt010140ca;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: DispenseInstructions</summary>
     * 
     * <remarks>PORX_MT010120CA.SupplyRequest: Dispense 
     * Instructions <p>Sets the parameters within which the 
     * dispenser must operate in dispensing the medication to the 
     * patient.</p> <p>Specification of how the prescribed 
     * medication is to be dispensed to the patient. Dispensed 
     * instruction information includes the quantity to be 
     * dispensed, how often the quantity is to be dispensed, 
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
     * of 'quantity' and 'expectedUseTime' must be specified</p> 
     * <p>Sets the parameters within which the dispenser must 
     * operate in dispensing the device to the patient.</p> 
     * <p>Specification of how the prescribed device is to be 
     * dispensed to the patient. Dispensed instruction information 
     * includes the quantity to be dispensed, how often the 
     * quantity is to be dispensed, etc.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT010110CA.SupplyRequest","PORX_MT010120CA.SupplyRequest","PORX_MT010140CA.SupplyRequest","PORX_MT060060CA.SupplyRequest"})]
    public class DispenseInstructions_1 : MessagePartBean {

        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Merged.RelatedPerson> receiverPersonalRelationship;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Merged.CreatedAt location;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Merged.DispenseShipToLocation destinationServiceDeliveryLocation;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Porx_mt010120ca.DrugDispenseInstructions> componentSupplyRequestItem;
        private INT quantity;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Porx_mt010140ca.RemainingDispenses> fulfillmentSupplyEvent;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Merged.SubstanceAdministrationRequest componentOfActRequest;
        private IVL<TS, Interval<PlatformDate>> expectedUseTime;
        private CS sourceOfTypeCode;
        private CS sourceOfContextControlCode;
        private BL sourceOfContextConductionInd;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Merged.SupplementalFillInformation sourceOfSupplementalFillInformation;

        public DispenseInstructions_1() {
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.receiverPersonalRelationship = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Merged.RelatedPerson>();
            this.componentSupplyRequestItem = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Porx_mt010120ca.DrugDispenseInstructions>();
            this.quantity = new INTImpl();
            this.fulfillmentSupplyEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Porx_mt010140ca.RemainingDispenses>();
            this.expectedUseTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.sourceOfTypeCode = new CSImpl();
            this.sourceOfContextControlCode = new CSImpl();
            this.sourceOfContextConductionInd = new BLImpl();
        }
        /**
         * <summary>Business Name: DispensingAllowedPeriod</summary>
         * 
         * <remarks>Un-merged Business Name: DispensingAllowedPeriod 
         * Relationship: PORX_MT010120CA.SupplyRequest.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Indicates when 
         * the Prescription becomes valid, and when it ceases to be a 
         * dispensable Prescription.</p><p>Some jurisdictions place a 
         * 'stale date' on prescriptions that cause them to become 
         * invalid a certain amount of time after they are written. 
         * This time may vary by medication.</p> <p>This indicates the 
         * validity period of a prescription (stale dating the 
         * Prescription).</p><p>It reflects the prescriber perspective 
         * for the validity of the prescription. Dispenses must not be 
         * made against the prescription outside of this period. The 
         * lower-bound of the Prescription Effective Period signifies 
         * the earliest date that the prescription can be filled for 
         * the first time. If an upper-bound is not specified then the 
         * Prescription is open-ended or will default to a stale-date 
         * based on regulations.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT010120CA.Receiver.personalRelationship 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"receiver/personalRelationship"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Merged.RelatedPerson> ReceiverPersonalRelationship {
            get { return this.receiverPersonalRelationship; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT010120CA.SupplyRequest.location 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
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
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Merged.CreatedAt Location {
            get { return this.location; }
            set { this.location = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT010120CA.Destination1.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT010110CA.Destination1.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"destination/serviceDeliveryLocation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Merged.DispenseShipToLocation DestinationServiceDeliveryLocation {
            get { return this.destinationServiceDeliveryLocation; }
            set { this.destinationServiceDeliveryLocation = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT010120CA.Component.supplyRequestItem 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component/supplyRequestItem"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Porx_mt010120ca.DrugDispenseInstructions> ComponentSupplyRequestItem {
            get { return this.componentSupplyRequestItem; }
        }

        /**
         * <summary>Business Name: TotalPrescribedQuantity</summary>
         * 
         * <remarks>Un-merged Business Name: TotalPrescribedQuantity 
         * Relationship: PORX_MT060060CA.SupplyRequest.quantity 
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
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT010140CA.InFulfillmentOf.supplyEvent 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"fulfillment/supplyEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Porx_mt010140ca.RemainingDispenses> FulfillmentSupplyEvent {
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
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Merged.SubstanceAdministrationRequest ComponentOfActRequest {
            get { return this.componentOfActRequest; }
            set { this.componentOfActRequest = value; }
        }

        /**
         * <summary>Business Name: TotalDaysSupply</summary>
         * 
         * <remarks>Un-merged Business Name: TotalDaysSupply 
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
         * <remarks>Relationship: PORX_MT010110CA.Component.typeCode 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"sourceOf/typeCode"})]
        public ActRelationshipType SourceOfTypeCode {
            get { return (ActRelationshipType) this.sourceOfTypeCode.Value; }
            set { this.sourceOfTypeCode.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT010110CA.Component.contextControlCode 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"sourceOf/contextControlCode"})]
        public ContextControl SourceOfContextControlCode {
            get { return (ContextControl) this.sourceOfContextControlCode.Value; }
            set { this.sourceOfContextControlCode.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT010110CA.Component.contextConductionInd 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"sourceOf/contextConductionInd"})]
        public bool? SourceOfContextConductionInd {
            get { return this.sourceOfContextConductionInd.Value; }
            set { this.sourceOfContextConductionInd.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT010110CA.Component.supplementalFillInformation 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"sourceOf/supplementalFillInformation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Merged.SupplementalFillInformation SourceOfSupplementalFillInformation {
            get { return this.sourceOfSupplementalFillInformation; }
            set { this.sourceOfSupplementalFillInformation = value; }
        }

    }

}