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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */

/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt240007ab {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: Sub-Locations</summary>
     * 
     * <p>Allows a more thorough understanding of the capabilities 
     * of the service delivery location, as well as drill-down to 
     * component parts.</p> <p>Identifies service delivery 
     * locations contained within the described &quot;parent&quot; 
     * service delivery location.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT240007AB.SubLocation"})]
    public class SubLocations : MessagePartBean {

        private CV code;
        private ST name;
        private CV locationCode;
        private ST locationName;

        public SubLocations() {
            this.code = new CVImpl();
            this.name = new STImpl();
            this.locationCode = new CVImpl();
            this.locationName = new STImpl();
        }
        /**
         * <summary>Business Name: Sub-Location Type</summary>
         * 
         * <remarks>Relationship: COCT_MT240007AB.SubLocation.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Provides context 
         * about what the capabilities of the component service 
         * delivery location are. Allows for unique identification of a 
         * sub-location and is therefore mandatory.</p> <p>Describes 
         * the 'type' of component service delivery location. For 
         * example, a hospital might contain a laboratory or a 
         * community clinic.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ServiceDeliveryLocationPlaceType Code {
            get { return (ServiceDeliveryLocationPlaceType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Sub-Location Name</summary>
         * 
         * <remarks>Relationship: COCT_MT240007AB.SubLocation.name 
         * Conformance/Cardinality: MANDATORY (1) <p>Provides a 
         * human-readable label for the location and is therefore 
         * mandatory. In general, names of sub-locations will be unique 
         * within their containing location.</p> <p>A descriptive name 
         * for the sub-location.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"name"})]
        public String Name {
            get { return this.name.Value; }
            set { this.name.Value = value; }
        }

        /**
         * <summary>Business Name: Sub-Location Place Type</summary>
         * 
         * <remarks>Relationship: COCT_MT240007AB.SubPlace.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Provides context 
         * about the type of sub-location.</p><p>Used for searching, as 
         * well as for understanding what is meant by a particular 
         * sub-location and is therefore mandatory.</p> <p>Identifies 
         * the physical type of the component location. For example, a 
         * campus may contain a building, a building may contain a 
         * ward, etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location/code"})]
        public ServiceDeliveryLocationPlaceType LocationCode {
            get { return (ServiceDeliveryLocationPlaceType) this.locationCode.Value; }
            set { this.locationCode.Value = value; }
        }

        /**
         * <summary>Business Name: Sub-Location Place Name</summary>
         * 
         * <remarks>Relationship: COCT_MT240007AB.SubPlace.name 
         * Conformance/Cardinality: MANDATORY (1) <p>Provides a 
         * human-readable label for the location and is therefore 
         * mandatory. In general, names of sub-locations will be unique 
         * within their containing location.</p> <p>A descriptive name 
         * for the Sub-Location Place</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location/name"})]
        public String LocationName {
            get { return this.locationName.Value; }
            set { this.locationName.Value = value; }
        }

    }

}