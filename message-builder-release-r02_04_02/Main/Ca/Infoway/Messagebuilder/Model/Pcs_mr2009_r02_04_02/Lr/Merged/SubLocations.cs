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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lr.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: SubLocations</summary>
     * 
     * <remarks>PRPA_MT202301CA.SubLocation: Sub-Locations 
     * <p>Allows a more thorough understanding of the capabilities 
     * of the service delivery location, as well as drill-down to 
     * component parts.</p> <p>Identifies service delivery 
     * locations contained within the described &quot;parent&quot; 
     * service delivery location.</p> PRPA_MT202302CA.SubLocation: 
     * Sub-Locations <p>Allows a more thorough understanding of the 
     * capabilities of the service delivery location, as well as 
     * drill-down to component parts.</p> <p>Identifies service 
     * delivery locations contained within the described 
     * &quot;parent&quot; service delivery location.</p> 
     * PRPA_MT202303CA.SubLocation: Sub-Locations <p>Allows a more 
     * thorough understanding of the capabilities of the service 
     * delivery location, as well as drill-down to component 
     * parts.</p> <p>Identifies service delivery locations 
     * contained within the described &quot;parent&quot; service 
     * delivery location.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPA_MT202301CA.SubLocation","PRPA_MT202302CA.SubLocation","PRPA_MT202303CA.SubLocation"})]
    public class SubLocations : MessagePartBean {

        private II id;
        private CV code;
        private ST name;
        private CV locationCode;

        public SubLocations() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.name = new STImpl();
            this.locationCode = new CVImpl();
        }
        /**
         * <summary>Business Name: SubLocationIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: SubLocationIdentifier 
         * Relationship: PRPA_MT202301CA.SubLocation.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows subsequent 
         * queries to drill down to detail information about this 
         * specific sub location and is therefore mandatory.</p> 
         * <p>Unique identifier for the contained service delivery 
         * location</p> Un-merged Business Name: SubLocationIdentifier 
         * Relationship: PRPA_MT202302CA.SubLocation.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows subsequent 
         * queries to drill down to detail information about this 
         * specific sub location and is therefore mandatory.</p> 
         * <p>Unique identifier for the contained service delivery 
         * location</p> Un-merged Business Name: SubLocationIdentifier 
         * Relationship: PRPA_MT202303CA.SubLocation.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows subsequent 
         * queries to drill down to detail information about this 
         * specific sub location and is therefore mandatory.</p> 
         * <p>Unique identifier for the contained service delivery 
         * location</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: SubLocationType</summary>
         * 
         * <remarks>Un-merged Business Name: SubLocationType 
         * Relationship: PRPA_MT202301CA.SubLocation.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Provides context 
         * about what the capabilities of the component service 
         * delivery location are. Allows for unique identification of a 
         * sub-location and is therefore mandatory.</p> <p>Describes 
         * the 'type' of component service delivery location. For 
         * example, a hospital might contain a laboratory or a 
         * community clinic.</p> Un-merged Business Name: 
         * SubLocationType Relationship: 
         * PRPA_MT202302CA.SubLocation.code Conformance/Cardinality: 
         * MANDATORY (1) <p>Provides context about what the 
         * capabilities of the component service delivery location are. 
         * Allows for unique identification of a sub-location and is 
         * therefore mandatory.</p> <p>Describes the 'type' of 
         * component service delivery location. For example, a hospital 
         * might contain a laboratory or a community clinic.</p> 
         * Un-merged Business Name: SubLocationType Relationship: 
         * PRPA_MT202303CA.SubLocation.code Conformance/Cardinality: 
         * MANDATORY (1) <p>Provides context about what the 
         * capabilities of the component service delivery location are. 
         * Allows for unique identification of a sub-location and is 
         * therefore mandatory.</p> <p>Describes the 'type' of 
         * component service delivery location. For example, a hospital 
         * might contain a laboratory or a community clinic.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ServiceDeliveryLocationRoleType Code {
            get { return (ServiceDeliveryLocationRoleType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: LocationName</summary>
         * 
         * <remarks>Un-merged Business Name: LocationName Relationship: 
         * PRPA_MT202301CA.SubLocation.name Conformance/Cardinality: 
         * MANDATORY (1) <p>Provides a human-readable label for the 
         * location and is therefore mandatory. In general, names of 
         * sub-locations will be unique within their containing 
         * location.</p> <p>A descriptive name for the 
         * sub-location.</p> Un-merged Business Name: LocationName 
         * Relationship: PRPA_MT202302CA.SubLocation.name 
         * Conformance/Cardinality: MANDATORY (1) <p>Provides a 
         * human-readable label for the location and is therefore 
         * mandatory. In general, names of sub-locations will be unique 
         * within their containing location.</p> <p>A descriptive name 
         * for the sub-location.</p> Un-merged Business Name: 
         * LocationName Relationship: PRPA_MT202303CA.SubLocation.name 
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
         * <summary>Business Name: SubLocationPlaceType</summary>
         * 
         * <remarks>Un-merged Business Name: SubLocationPlaceType 
         * Relationship: PRPA_MT202301CA.SubPlace.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Provides context 
         * about the type of sub-location.</p><p>Used for searching, as 
         * well as for understanding what is meant by a particular 
         * sub-location and is therefore mandatory.</p> <p>Identifies 
         * the physical type of the component location. For example, a 
         * campus may contain a building, a building may contain a 
         * ward, etc.</p> Un-merged Business Name: SubLocationPlaceType 
         * Relationship: PRPA_MT202302CA.SubPlace.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Provides context 
         * about the type of sub-location.</p><p>Used for searching, as 
         * well as for understanding what is meant by a particular 
         * sub-location and is therefore mandatory.</p> <p>Identifies 
         * the physical type of the component location. For example, a 
         * campus may contain a building, a building may contain a 
         * ward, etc.</p> Un-merged Business Name: SubLocationPlaceType 
         * Relationship: PRPA_MT202303CA.SubPlace.code 
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

    }

}