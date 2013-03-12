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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pr.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: ServiceDeliveryLocation</summary>
     * 
     * <remarks>PRPM_MT306011CA.ServiceDeliveryLocation: Service 
     * Delivery Location <p>Roleclass required to support the 
     * identification of the physical location where healthcare 
     * services are provided</p> <p>A role played by a place at 
     * which services may be provided. The RIM defines two 
     * specializations of service delivery location: 1. incidental 
     * service delivery location - A role played by a place at 
     * which health care services may be provided without prior 
     * designation or authorization and 2. dedicated service 
     * delivery location - A role played by a place that is 
     * intended to house the provision of services. Scoper is the 
     * Entity (typically Organization) that provides these 
     * services. This is not synonymous with &quot;ownership&quot;. 
     * This can be further characterized by a role code of: 
     * A)DedicatedClinicalLocationRoleType - A role of a place that 
     * further classifies the clinical setting (e.g., cardiology 
     * clinic, primary care clinic, rehabilitation hospital, 
     * skilled nursing facility) in which care is delivered during 
     * an encounter or B)DedicatedNonClinicalLocationRoleType - A 
     * role of a place that further classifies the setting in which 
     * non-clinical services are delivered. A given physical place 
     * can play multiple service delivery location roles each with 
     * its own attributes. For example, a Podiatric clinic and 
     * Research clinic may meet on alternate days in the same 
     * physical location; each clinic uses its own mailing address 
     * and telephone number.</p> 
     * PRPM_MT309000CA.ServiceDeliveryLocation: Service Delivery 
     * Location <p>Roleclass required to support the identification 
     * of the physical location where healthcare services are 
     * provided</p> <p>A role played by a place at which services 
     * may be provided. The RIM defines two specializations of 
     * service delivery location: 1. incidental service delivery 
     * location - A role played by a place at which health care 
     * services may be provided without prior designation or 
     * authorization and 2. dedicated service delivery location - A 
     * role played by a place that is intended to house the 
     * provision of services. Scoper is the Entity (typically 
     * Organization) that provides these services. This is not 
     * synonymous with &quot;ownership&quot;. This can be further 
     * characterized by a role code of: 
     * A)DedicatedClinicalLocationRoleType - A role of a place that 
     * further classifies the clinical setting (e.g., cardiology 
     * clinic, primary care clinic, rehabilitation hospital, 
     * skilled nursing facility) in which care is delivered during 
     * an encounter or B)DedicatedNonClinicalLocationRoleType - A 
     * role of a place that further classifies the setting in which 
     * non-clinical services are delivered. A given physical place 
     * can play multiple service delivery location roles each with 
     * its own attributes. For example, a Podiatric clinic and 
     * Research clinic may meet on alternate days in the same 
     * physical location; each clinic uses its own mailing address 
     * and telephone number.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPM_MT306011CA.ServiceDeliveryLocation","PRPM_MT309000CA.ServiceDeliveryLocation"})]
    public class ServiceDeliveryLocation : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.IChoice {

        private SET<II, Identifier> id;
        private CV code;
        private LIST<AD, PostalAddress> addr;
        private LIST<TEL, TelecommunicationAddress> telecom;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private ST locationName;

        public ServiceDeliveryLocation() {
            this.id = new SETImpl<II, Identifier>(typeof(IIImpl));
            this.code = new CVImpl();
            this.addr = new LISTImpl<AD, PostalAddress>(typeof(ADImpl));
            this.telecom = new LISTImpl<TEL, TelecommunicationAddress>(typeof(TELImpl));
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.locationName = new STImpl();
        }
        /**
         * <summary>Business Name: ServiceDeliveryLocationIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * ServiceDeliveryLocationIdentifier Relationship: 
         * PRPM_MT306011CA.ServiceDeliveryLocation.id 
         * Conformance/Cardinality: REQUIRED (0-10) <p>Required 
         * attribute supports the validation and identification of the 
         * service delivery location</p> <p>A unique identifier for the 
         * service delivery location.</p> Un-merged Business Name: 
         * ServiceDeliveryLocationIdentifier Relationship: 
         * PRPM_MT309000CA.ServiceDeliveryLocation.id 
         * Conformance/Cardinality: MANDATORY (1-10) <p>Mandatory 
         * attribute supports the validation and identification of the 
         * service delivery location</p> <p>A unique identifier for the 
         * service delivery location.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public ICollection<Identifier> Id {
            get { return this.id.RawSet(); }
        }

        /**
         * <summary>Business Name: ServiceDeliveryLocationType</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * ServiceDeliveryLocationType Relationship: 
         * PRPM_MT306011CA.ServiceDeliveryLocation.code 
         * Conformance/Cardinality: POPULATED (1) <p>Populated 
         * attribute supports the validation and identification of the 
         * service delivery location</p> <p>The code identifying the 
         * specific service delivery location</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ServiceDeliveryLocationRoleType Code {
            get { return (ServiceDeliveryLocationRoleType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: ServiceDeliveryLocationAddress</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * ServiceDeliveryLocationAddress Relationship: 
         * PRPM_MT306011CA.ServiceDeliveryLocation.addr 
         * Conformance/Cardinality: REQUIRED (0-5) <p>Required 
         * attribute supports the validation and identification of the 
         * service delivery location</p> <p>Address of the specific 
         * service delivery location</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"addr"})]
        public IList<PostalAddress> Addr {
            get { return this.addr.RawList(); }
        }

        /**
         * <summary>Business Name: ServiceDeliveryLocationTelecom</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * ServiceDeliveryLocationTelecom Relationship: 
         * PRPM_MT306011CA.ServiceDeliveryLocation.telecom 
         * Conformance/Cardinality: REQUIRED (0-5) <p>Required 
         * attribute supports the validation and identification of the 
         * service delivery location</p> <p>The telecom for the 
         * specific service delivery location</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"telecom"})]
        public IList<TelecommunicationAddress> Telecom {
            get { return this.telecom.RawList(); }
        }

        /**
         * <summary>Business Name: ServiceDeliveryLocationEffectiveDate</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * ServiceDeliveryLocationEffectiveDate Relationship: 
         * PRPM_MT306011CA.ServiceDeliveryLocation.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute supports the validation and identification of the 
         * service delivery location</p> <p>Effective date of the 
         * specific service delivery location</p></remarks>
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
         * PRPM_MT306011CA.Place.name Conformance/Cardinality: 
         * MANDATORY (1) <p>Mandatory attribute supports the validation 
         * and identification of the service delivery location</p> 
         * <p>The name of the service delivery location</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location/name"})]
        public String LocationName {
            get { return this.locationName.Value; }
            set { this.locationName.Value = value; }
        }

    }

}