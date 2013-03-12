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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt240003ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Service Location</summary>
     * 
     * <p>Used for tracking service delivery responsibility, to 
     * provide contact information for follow-up and for 
     * statistical analysis. Also important for indicating where 
     * paper records can be located.</p> <p>An identification of a 
     * service location (or facility) where health service has been 
     * or can be delivered. E.g. Pharmacy, Medical Clinic, 
     * Hospital</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT240003CA.ServiceDeliveryLocation"})]
    public class ServiceLocation : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged.IRecipient {

        private II id;
        private AD addr;
        private SET<TEL, TelecommunicationAddress> telecom;
        private ST locationName;

        public ServiceLocation() {
            this.id = new IIImpl();
            this.addr = new ADImpl();
            this.telecom = new SETImpl<TEL, TelecommunicationAddress>(typeof(TELImpl));
            this.locationName = new STImpl();
        }
        /**
         * <summary>Business Name: C:Service Location Id</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT240003CA.ServiceDeliveryLocation.id 
         * Conformance/Cardinality: MANDATORY (1) <p>PVD.020-01 
         * (extension)</p> <p>PVD.020-02 (root)</p> <p>Dispensing 
         * Pharmacy number</p> <p>Pharmacy Identifier</p> 
         * <p>Facility.facilityKey</p> <p>DispensedItem.facilityKey</p> 
         * <p>Allows for lookup and retrieval of detailed information 
         * about a specific service location. Also ensures unique 
         * identification of service location and is therefore 
         * mandatory.</p><p>The identifier is mandatory because it is 
         * the principal mechanism for uniquely identifying the 
         * facility.</p> <p>Unique identifier for a healthcare service 
         * location.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: D:Service Location Address</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT240003CA.ServiceDeliveryLocation.addr 
         * Conformance/Cardinality: POPULATED (1) <p>Identifies the 
         * physical location of a service location and also allows for 
         * the location to be contacted.</p><p>The address is marked as 
         * 'populated' because it is considered a critical piece of 
         * information about the facility, but may not always be 
         * available or meaningful.</p> <p>The information by which a 
         * service location may be contacted either physically or by 
         * mail.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"addr"})]
        public PostalAddress Addr {
            get { return this.addr.Value; }
            set { this.addr.Value = value; }
        }

        /**
         * <summary>Business Name: E:Service Location Phones and 
         * E-mails</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT240003CA.ServiceDeliveryLocation.telecom 
         * Conformance/Cardinality: POPULATED (1-5) <p>Allows a service 
         * location to be communicated with and is therefore important. 
         * Because a contact number won't always exist, the field is 
         * marked 'populated'.</p> <p>The phone numbers and/or 
         * electronic mail addresses by which a service location may be 
         * contacted.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"telecom"})]
        public ICollection<TelecommunicationAddress> Telecom {
            get { return this.telecom.RawSet(); }
        }

        /**
         * <summary>Business Name: B:Service Location Name</summary>
         * 
         * <remarks>Relationship: COCT_MT240003CA.Place.name 
         * Conformance/Cardinality: MANDATORY (1) <p>PVD.070</p> 
         * <p>Dispensing Pharmacy Name</p> <p>Facility.name</p> <p>Used 
         * for human communication, and for cross-checking of location 
         * Id and is therefore mandatory</p> <p>The name assigned to 
         * the service location.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location/name"})]
        public String LocationName {
            get { return this.locationName.Value; }
            set { this.locationName.Value = value; }
        }

    }

}