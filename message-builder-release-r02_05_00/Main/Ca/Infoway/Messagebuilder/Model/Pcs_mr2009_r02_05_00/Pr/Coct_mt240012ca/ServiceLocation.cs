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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt240012ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: Service Location</summary>
     * 
     * <p>Used for tracking service delivery responsibility, to 
     * provide contact information for follow-up and for 
     * statistical analysis. Also important for indicating where 
     * paper records can be located.</p> <p>An identification of a 
     * service location (or facility) that can be found in the 
     * service delivery location. E.g. Pharmacy, Medical Clinic, 
     * Hospital</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT240012CA.ServiceDeliveryLocation"})]
    public class ServiceLocation : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt470012ca.IRecipient {

        private II id;
        private ST locationName;

        public ServiceLocation() {
            this.id = new IIImpl();
            this.locationName = new STImpl();
        }
        /**
         * <summary>Business Name: C:Service Location Identifier</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT240012CA.ServiceDeliveryLocation.id 
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
         * <summary>Business Name: B:Service Location Name</summary>
         * 
         * <remarks>Relationship: COCT_MT240012CA.Place.name 
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