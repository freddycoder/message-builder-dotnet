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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Porx_mt060340ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt040205ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Dispense Instructions</summary>
     * 
     * <p>A_BillablePharmacyDispense</p> <p>Sets the parameters 
     * within which the dispenser must operate in dispensing the 
     * medication to the patient.</p> <p>Specification of how the 
     * prescribed medication is to be dispensed to the patient. 
     * Dispensed instruction information includes the quantity to 
     * be dispensed, how often the quantity is to be dispensed, 
     * etc.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060340CA.SupplyRequest"})]
    public class DispenseInstructions : MessagePartBean {

        private CS statusCode;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt040205ca.ResponsiblePerson> receiverResponsibleParty;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged.RecordedAt location;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.DispenseShipToLocation destinationServiceDeliveryLocation;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.Component3> component;

        public DispenseInstructions() {
            this.statusCode = new CSImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.receiverResponsibleParty = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt040205ca.ResponsiblePerson>();
            this.component = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.Component3>();
        }
        /**
         * <summary>Business Name: Prescription Dispensable Indicator</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060340CA.SupplyRequest.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows a 
         * prescriber to say &quot;Finish what you have on hand, but 
         * don't get any more.&quot;</p><p>Because the status should 
         * always be known, this element is mandatory.</p> <p>This 
         * generally mirrors the status for the prescription, but in 
         * some circumstances may be changed to 'aborted' while the 
         * prescription is still active. When this occurs, it means the 
         * prescription may no longer be dispensed, though it may still 
         * be administered.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: A:Dispensing Allowed Period</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060340CA.SupplyRequest.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>ZPB3.9</p> 
         * <p>DRU.040-02 (low, qualifier=07, format=102)</p> 
         * <p>DRU.040-02 (low, qualifier=36, format=102)</p> <p>Number 
         * of days (width)</p> <p>When will drug be 
         * administered?(low)</p> <p>ZDP.17 (high)</p> <p>Last date 
         * dispensed(when summary type is 'most recent')</p> 
         * <p>Prescription.dispensingInterval(period)</p> 
         * <p>Prescription.effectiveDate (low)</p> 
         * <p>Prescription.expiryDate (high)</p> <p>Indicates when the 
         * Order becomes valid, and when it ceases to be an actionable 
         * Order. Some jurisdictions place a 'stale date' on 
         * prescriptions that cause them to become invalid a certain 
         * amount of time after they are written. This time may vary by 
         * medication.</p> <p>This indicates the validity period of a 
         * prescription (stale dating the Prescription). It reflects 
         * the prescriber perspective for the validity of the 
         * prescription. Dispenses must not be made against the 
         * prescription outside of this period. The lower-bound of the 
         * Prescription Effective Period signifies the earliest date 
         * that the prescription can be filled for the first time. If 
         * an upper-bound is not specified then the Prescription is 
         * open-ended or will default to a stale-date based on 
         * regulations.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060340CA.Receiver.responsibleParty</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"receiver/responsibleParty"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt040205ca.ResponsiblePerson> ReceiverResponsibleParty {
            get { return this.receiverResponsibleParty; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060340CA.SupplyRequest.location</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged.RecordedAt Location {
            get { return this.location; }
            set { this.location = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060340CA.Destination1.serviceDeliveryLocation</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"destination/serviceDeliveryLocation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.DispenseShipToLocation DestinationServiceDeliveryLocation {
            get { return this.destinationServiceDeliveryLocation; }
            set { this.destinationServiceDeliveryLocation = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060340CA.SupplyRequest.component</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1-5)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.Component3> Component {
            get { return this.component; }
        }

    }

}