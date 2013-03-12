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
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>PRPM_MT303010CA.ServiceDeliveryLocation: Service 
     * Delivery Location</summary>
     * 
     * <p>A role played by a place at which services may be 
     * provided. The RIM defines two specializations of service 
     * delivery location: 1. incidental service delivery location - 
     * A role played by a place at which health care services may 
     * be provided without prior designation or authorization and 
     * 2. dedicated service delivery location - A role played by a 
     * place that is intended to house the provision of services. 
     * Scoper is the Entity (typically Organization) that provides 
     * these services. This is not synonymous with 
     * &quot;ownership&quot;. This can be further characterized by 
     * a role code of: A)DedicatedClinicalLocationRoleType - A role 
     * of a place that further classifies the clinical setting 
     * (e.g., cardiology clinic, primary care clinic, 
     * rehabilitation hospital, skilled nursing facility) in which 
     * care is delivered during an encounter or 
     * B)DedicatedNonClinicalLocationRoleType - A role of a place 
     * that further classifies the setting in which non-clinical 
     * services are delivered. A given physical place can play 
     * multiple service delivery location roles each with its own 
     * attributes. For example, a Podiatric clinic and Research 
     * clinic may meet on alternate days in the same physical 
     * location; each clinic uses its own mailing address and 
     * telephone number.</p> <p>Roleclass required to support the 
     * identification of the physical location where healthcare 
     * services are provided</p> 
     * PORX_MT060340CA.ServiceDeliveryLocation: Dispense Ship-To 
     * Location <p>The location where the dispensed product is 
     * expected to be delivered.</p> <p>Important as part of a 
     * claim for justifying shipping charges.</p> 
     * PORX_MT020070CA.ServiceDeliveryLocation: Dispense Ship-To 
     * Location <p>The location where the dispensed product is 
     * expected to be delivered.</p> <p>Important as part of a 
     * claim for justifying shipping charges.</p> 
     * PORX_MT020060CA.ServiceDeliveryLocation: Dispense Ship-To 
     * Location <p>The location where the dispensed product is 
     * expected to be delivered.</p> <p>Important as part of a 
     * claim for justifying shipping charges.</p> 
     * PORX_MT060010CA.ServiceDeliveryLocation: Dispense Ship-To 
     * Location <p>The location where the dispensed product is 
     * expected to be delivered.</p> <p>Important as part of a 
     * claim for justifying shipping charges.</p> 
     * PORX_MT060160CA.ServiceDeliveryLocation: Dispense Ship-To 
     * Location <p>The location where the dispensed product is 
     * expected to be delivered.</p> <p>Important as part of a 
     * claim for justifying shipping charges.</p> 
     * PORX_MT060040CA.ServiceDeliveryLocation: Dispense Ship-To 
     * Location <p>The location where the dispensed product is 
     * expected to be delivered.</p> <p>Important as part of a 
     * claim for justifying shipping charges.</p> 
     * PRPM_MT301010CA.ServiceDeliveryLocation: Service Delivery 
     * Location <p>A role played by a place at which services may 
     * be provided. The RIM defines two specializations of service 
     * delivery location: 1. incidental service delivery location - 
     * A role played by a place at which health care services may 
     * be provided without prior designation or authorization and 
     * 2. dedicated service delivery location - A role played by a 
     * place that is intended to house the provision of services. 
     * Scoper is the Entity (typically Organization) that provides 
     * these services. This is not synonymous with 
     * &quot;ownership&quot;. This can be further characterized by 
     * a role code of: A)DedicatedClinicalLocationRoleType - A role 
     * of a place that further classifies the clinical setting 
     * (e.g., cardiology clinic, primary care clinic, 
     * rehabilitation hospital, skilled nursing facility) in which 
     * care is delivered during an encounter or 
     * B)DedicatedNonClinicalLocationRoleType - A role of a place 
     * that further classifies the setting in which non-clinical 
     * services are delivered. A given physical place can play 
     * multiple service delivery location roles each with its own 
     * attributes. For example, a Podiatric clinic and Research 
     * clinic may meet on alternate days in the same physical 
     * location; each clinic uses its own mailing address and 
     * telephone number.</p> <p>Roleclass required to support the 
     * identification of the physical location where healthcare 
     * services are provided</p> 
     * PORX_MT060090CA.ServiceDeliveryLocation: Dispense Ship-To 
     * Location <p>The location where the dispensed product is 
     * expected to be delivered.</p> <p>Important as part of a 
     * claim for justifying shipping charges.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT010110CA.ServiceDeliveryLocation","PORX_MT010120CA.ServiceDeliveryLocation","PORX_MT020060CA.ServiceDeliveryLocation","PORX_MT020070CA.ServiceDeliveryLocation","PORX_MT060010CA.ServiceDeliveryLocation","PORX_MT060040CA.ServiceDeliveryLocation","PORX_MT060040CA.ServiceDeliveryLocation2","PORX_MT060090CA.ServiceDeliveryLocation","PORX_MT060160CA.ServiceDeliveryLocation","PORX_MT060160CA.ServiceDeliveryLocation2","PORX_MT060340CA.ServiceDeliveryLocation","PORX_MT060340CA.ServiceDeliveryLocation2","PRPM_MT301010CA.ServiceDeliveryLocation","PRPM_MT303010CA.ServiceDeliveryLocation"})]
    public class DispenseShipToLocation : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.IChoice {

        private II id;
        private CV code;
        private AD addr;
        private TEL telecom;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private ST locationName;

        public DispenseShipToLocation() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.addr = new ADImpl();
            this.telecom = new TELImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.locationName = new STImpl();
        }
        /**
         * <summary>Business Name: ServiceDeliveryLocationIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * ServiceDeliveryLocationIdentifier Relationship: 
         * PRPM_MT303010CA.ServiceDeliveryLocation.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>A unique 
         * identifier for the service delivery location.</p> 
         * <p>Required attribute supports the validation and 
         * identification of the service delivery location</p> 
         * Un-merged Business Name: ServiceDeliveryLocationIdentifier 
         * Relationship: PRPM_MT301010CA.ServiceDeliveryLocation.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>A unique 
         * identifier for the service delivery location.</p> 
         * <p>Required attribute supports the validation and 
         * identification of the service delivery location</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: ServiceDeliveryLocationType</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * ServiceDeliveryLocationType Relationship: 
         * PRPM_MT303010CA.ServiceDeliveryLocation.code 
         * Conformance/Cardinality: MANDATORY (1) <p>The code 
         * identifying the specific service delivery location</p> 
         * <p>Mandatory attribute supports the validation and 
         * identification of the service delivery location</p> 
         * Un-merged Business Name: ServiceDeliveryLocationType 
         * Relationship: PRPM_MT301010CA.ServiceDeliveryLocation.code 
         * Conformance/Cardinality: MANDATORY (1) <p>The code 
         * identifying the specific service delivery location</p> 
         * <p>Mandatory attribute supports the validation and 
         * identification of the service delivery location</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ServiceDeliveryLocationRoleType Code {
            get { return (ServiceDeliveryLocationRoleType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: 
         * ServiceDeliveryLocationAddress</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT303010CA.ServiceDeliveryLocation.addr 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Address of the 
         * specific service delivery location</p> <p>Required attribute 
         * supports the validation and identification of the service 
         * delivery location</p> Un-merged Business Name: 
         * PrescriptionShipToAddress Relationship: 
         * PORX_MT060040CA.ServiceDeliveryLocation2.addr 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates the 
         * location the dispensed device should be shipped to, at the 
         * request of the patient or provider.</p> <p>In some cases 
         * devices need to be delivered to the patient instead of being 
         * picked up. In other cases, devices need to be shipped to the 
         * physician's office to replace stock used for the 
         * patient.</p> Un-merged Business Name: ShipToAddress 
         * Relationship: PORX_MT060340CA.ServiceDeliveryLocation.addr 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates where 
         * the dispensed product was sent.</p> <p>Important as part of 
         * a claim for justifying shipping charges.</p> Un-merged 
         * Business Name: ShipToAddress Relationship: 
         * PORX_MT020070CA.ServiceDeliveryLocation.addr 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates where 
         * the dispensed product was sent.</p> <p>Important as part of 
         * a claim for justifying shipping charges.</p> Un-merged 
         * Business Name: ShipToAddress Relationship: 
         * PORX_MT020060CA.ServiceDeliveryLocation.addr 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates where 
         * the dispensed product was sent.</p> <p>Important as part of 
         * a claim for justifying shipping charges.</p> Un-merged 
         * Business Name: PrescriptionShipToAddress Relationship: 
         * PORX_MT060160CA.ServiceDeliveryLocation2.addr 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates the 
         * location the dispensed medication should be shipped to, at 
         * the request of the patient or provider.</p> <p>In some cases 
         * drugs need to be delivered to the patient instead of being 
         * picked up. In other cases, drugs need to be shipped to the 
         * physician's office to replace stock used for the 
         * patient.</p> Un-merged Business Name: ShipToAddress 
         * Relationship: PORX_MT060010CA.ServiceDeliveryLocation.addr 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates where 
         * the dispensed product was sent.</p> <p>Important as part of 
         * a claim for justifying shipping charges.</p> Un-merged 
         * Business Name: ShipToAddress Relationship: 
         * PORX_MT060160CA.ServiceDeliveryLocation.addr 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates where 
         * the dispensed product was sent.</p> <p>Important as part of 
         * a claim for justifying shipping charges.</p> Un-merged 
         * Business Name: ShipToAddress Relationship: 
         * PORX_MT060040CA.ServiceDeliveryLocation.addr 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates where 
         * the dispensed product was sent.</p> <p>Important as part of 
         * a claim for justifying shipping charges.</p> Un-merged 
         * Business Name: PrescriptionShipToAddress Relationship: 
         * PORX_MT010120CA.ServiceDeliveryLocation.addr 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates the 
         * location the dispensed medication should be shipped to, at 
         * the request of the patient or provider.</p> <p>In some cases 
         * drugs need to be delivered to the patient instead of being 
         * picked up. In other cases, drugs need to be shipped to the 
         * physician's office to replace stock used for the 
         * patient.</p> Un-merged Business Name: 
         * PrescriptionShipToAddress Relationship: 
         * PORX_MT060340CA.ServiceDeliveryLocation2.addr 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates the 
         * location the dispensed medication should be shipped to, at 
         * the request of the patient or provider.</p> <p>In some cases 
         * drugs need to be delivered to the patient instead of being 
         * picked up. In other cases, drugs need to be shipped to the 
         * physician's office to replace stock used for the 
         * patient.</p> Un-merged Business Name: 
         * ServiceDeliveryLocationAddress Relationship: 
         * PRPM_MT301010CA.ServiceDeliveryLocation.addr 
         * Conformance/Cardinality: POPULATED (1) <p>Address of the 
         * specific service delivery location</p> <p>Populated 
         * attribute supports the validation and identification of the 
         * service delivery location</p> Un-merged Business Name: 
         * ShipToAddress Relationship: 
         * PORX_MT060090CA.ServiceDeliveryLocation.addr 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates where 
         * the dispensed product was sent.</p> <p>Important as part of 
         * a claim for justifying shipping charges.</p> Un-merged 
         * Business Name: PrescriptionShipToAddress Relationship: 
         * PORX_MT010110CA.ServiceDeliveryLocation.addr 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates the 
         * location the dispensed device should be shipped to, at the 
         * request of the patient or provider.</p> <p>In some cases 
         * devices need to be delivered to the patient instead of being 
         * picked up. In other cases, devices need to be shipped to the 
         * physician's office to replace stock used for the 
         * patient.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"addr"})]
        public PostalAddress Addr {
            get { return this.addr.Value; }
            set { this.addr.Value = value; }
        }

        /**
         * <summary>Business Name: ServiceDeliveryLocationTelecom</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * ServiceDeliveryLocationTelecom Relationship: 
         * PRPM_MT303010CA.ServiceDeliveryLocation.telecom 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The telecom for 
         * the specific service delivery location</p> <p>Required 
         * attribute supports the validation and identification of the 
         * service delivery location</p> Un-merged Business Name: 
         * ServiceDeliveryLocationTelecom Relationship: 
         * PRPM_MT301010CA.ServiceDeliveryLocation.telecom 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The telecom for 
         * the specific service delivery location</p> <p>Required 
         * attribute supports the validation and identification of the 
         * service delivery location</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"telecom"})]
        public TelecommunicationAddress Telecom {
            get { return this.telecom.Value; }
            set { this.telecom.Value = value; }
        }

        /**
         * <summary>Business Name: ServiceDeliveryLocationEffectiveDate</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * ServiceDeliveryLocationEffectiveDate Relationship: 
         * PRPM_MT303010CA.ServiceDeliveryLocation.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Effective date of 
         * the specific service delivery location</p> <p>Required 
         * attribute supports the validation and identification of the 
         * service delivery location</p> Un-merged Business Name: 
         * ServiceDeliveryLocationEffectiveDate Relationship: 
         * PRPM_MT301010CA.ServiceDeliveryLocation.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Effective date of 
         * the specific service delivery location</p> <p>Required 
         * attribute supports the validation and identification of the 
         * service delivery location</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: ServiceDeliveryLocationName</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * ServiceDeliveryLocationName Relationship: 
         * PRPM_MT303010CA.Place.name Conformance/Cardinality: 
         * MANDATORY (1) <p>The name of the service delivery 
         * location</p> <p>Mandatory attribute supports the validation 
         * and identification of the service delivery location</p> 
         * Un-merged Business Name: ServiceDeliveryLocationName 
         * Relationship: PRPM_MT301010CA.Place.name 
         * Conformance/Cardinality: MANDATORY (1) <p>The name of the 
         * service delivery location</p> <p>Mandatory attribute 
         * supports the validation and identification of the service 
         * delivery location</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location/name"})]
        public String LocationName {
            get { return this.locationName.Value; }
            set { this.locationName.Value = value; }
        }

    }

}