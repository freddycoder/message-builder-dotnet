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
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Common.Coct_mt120600ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Common.Coct_mt220200ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Merged;
    using System;


    /**
     * <summary>PORX_MT020030CA.SupplyEvent: Prescription Dispense 
     * Response</summary>
     * 
     * <p>Allows communication of the identifiers assigned to the 
     * dispense and the prescription by the DIS.</p> <p>Represents 
     * the information returned when a dispense has been 
     * accepted</p> PORX_MT020020CA.SupplyEvent: Dispense Pickup 
     * <p>The root class for the message. The time of pickup is 
     * specified on the ControlAct wrapper.</p> <p>Captures 
     * information about what prescription was picked up and who 
     * received it.</p> PORX_MT020050CA.SupplyEvent: Office Supply 
     * <p>Allows for tracking of medications supplied to an 
     * office.</p> <p>This is the detailed information about a 
     * medication being supplied for office use.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT020020CA.SupplyEvent","PORX_MT020030CA.SupplyEvent","PORX_MT020050CA.SupplyEvent"})]
    public class PrescriptionDispenseResponse : MessagePartBean {

        private II id;
        private II inFulfillmentOfActRequestId;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Merged.RelatedPerson receiverPersonalRelationship;
        private CV code;
        private TS effectiveTime;
        private PQ quantity;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Common.Coct_mt220200ca.DrugProduct productMedication;
        private II destinationServiceDeliveryLocationId;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Merged.SupplyOrder fulfillmentSupplyRequest;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Common.Coct_mt120600ca.Notes subjectOfAnnotation;

        public PrescriptionDispenseResponse() {
            this.id = new IIImpl();
            this.inFulfillmentOfActRequestId = new IIImpl();
            this.code = new CVImpl();
            this.effectiveTime = new TSImpl();
            this.quantity = new PQImpl();
            this.destinationServiceDeliveryLocationId = new IIImpl();
        }
        /**
         * <summary>Un-merged Business Name: DispenseIdentifier</summary>
         * 
         * <remarks>Relationship: PORX_MT020030CA.SupplyEvent.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Establishes a 
         * record of impending dispense on the prescription. Attribute 
         * is mandatory to ensure that successful request to dispense 
         * has been acknowledged by the DIS.</p> <p>Identifier of a 
         * dispense event to be used by the requesting dispenser.</p> 
         * Un-merged Business Name: DispenseId Relationship: 
         * PORX_MT020020CA.SupplyEvent.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Allows dispenses to be uniquely identified. 
         * This attribute is mandatory because the identity of the 
         * dispense record must be known.</p> <p>Identity of 
         * prescription dispense that has been picked up.</p> Un-merged 
         * Business Name: LocalDispenseID Relationship: 
         * PORX_MT020050CA.SupplyEvent.id Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Allows formal tracking of centrally 
         * recorded dispenses to local records for audit and related 
         * purposes.</p> <p>Identifier assigned by the dispensing 
         * facility.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: PrescriptionOrderNumber</summary>
         * 
         * <remarks>Un-merged Business Name: PrescriptionOrderNumber 
         * Relationship: PORX_MT020030CA.ActRequest.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows 
         * prescriptions to be uniquely referenced. Multiple 
         * identifiers are allowed to support assigning of prescription 
         * ids by the prescriber, EHR, and potentially by 
         * pharmacies.</p><p>The ID is mandatory to allow every 
         * prescription record to be uniquely identified.</p> <p>This 
         * is an identifier assigned to a specific medication order. 
         * The number remains constant across the lifetime of the 
         * order, regardless of the number of providers or pharmacies 
         * involved in fulfilling the order.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"inFulfillmentOf/actRequest/id"})]
        public Identifier InFulfillmentOfActRequestId {
            get { return this.inFulfillmentOfActRequestId.Value; }
            set { this.inFulfillmentOfActRequestId.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT020020CA.Receiver.personalRelationship 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"receiver/personalRelationship"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Merged.RelatedPerson ReceiverPersonalRelationship {
            get { return this.receiverPersonalRelationship; }
            set { this.receiverPersonalRelationship = value; }
        }

        /**
         * <summary>Business Name: DispenseType</summary>
         * 
         * <remarks>Un-merged Business Name: DispenseType Relationship: 
         * PORX_MT020050CA.SupplyEvent.code Conformance/Cardinality: 
         * MANDATORY (1) <p>Indicates reason for the size of dispense. 
         * Because it defines what type of dispense is occurring, the 
         * attribute is mandatory.</p> <p>Indicates the type of 
         * dispensing event that is being performed.</p><p>This is a 
         * fixed dispense type of 'Office Supply' unless using 
         * SNOMED.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActCode Code {
            get { return (ActCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: SupplyDate</summary>
         * 
         * <remarks>Un-merged Business Name: SupplyDate Relationship: 
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
         * <summary>Business Name: SuppliedQuantity</summary>
         * 
         * <remarks>Un-merged Business Name: SuppliedQuantity 
         * Relationship: PORX_MT020050CA.SupplyEvent.quantity 
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
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: PORX_MT020050CA.Product2.medication 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"product/medication"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Common.Coct_mt220200ca.DrugProduct ProductMedication {
            get { return this.productMedication; }
            set { this.productMedication = value; }
        }

        /**
         * <summary>Business Name: ShipToFacilityId</summary>
         * 
         * <remarks>Un-merged Business Name: ShipToFacilityId 
         * Relationship: PORX_MT020050CA.ServiceDeliveryLocation.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows tracking 
         * what drugs are dispensed to a facility. The attribute is 
         * mandatory because identification of the facility must be 
         * known.</p> <p>Identifier of the facility where the dispensed 
         * medication was shipped.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"destination/serviceDeliveryLocation/id"})]
        public Identifier DestinationServiceDeliveryLocationId {
            get { return this.destinationServiceDeliveryLocationId.Value; }
            set { this.destinationServiceDeliveryLocationId.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT020050CA.InFulfillmentOf.supplyRequest 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"fulfillment/supplyRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Merged.SupplyOrder FulfillmentSupplyRequest {
            get { return this.fulfillmentSupplyRequest; }
            set { this.fulfillmentSupplyRequest = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: PORX_MT020050CA.Subject7.annotation 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf/annotation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Common.Coct_mt120600ca.Notes SubjectOfAnnotation {
            get { return this.subjectOfAnnotation; }
            set { this.subjectOfAnnotation = value; }
        }

    }

}