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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lr.Prpa_mt202301ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt960002ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lr.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Location</summary>
     * 
     * <p>At least one of address or coordinate must be specified 
     * unless the place is mobile.</p> <p>Provides location 
     * information which uniquely identifies where health services 
     * are provided. This includes details and other supporting 
     * information on locations e.g. name, address, organization 
     * and contact parties. Needed when looking up facilities to 
     * link to patient records. Also useful when trying to find 
     * facilities to meet particular patient needs, as well as 
     * looking up how to contact the location.</p> <p>Any location 
     * where health-related services may be provided. Note that a 
     * single physical place can play multiple service delivery 
     * location roles e.g. a Podiatry clinic and Research clinic 
     * may meet on alternate days in the same physical location; 
     * each clinic uses its own mailing address and telephone 
     * number.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPA_MT202301CA.ServiceDeliveryLocation"})]
    public class Location : MessagePartBean {

        private CV code;
        private SET<ST, String> name;
        private AD addr;
        private CS statusCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lr.Merged.Place locationValue;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lr.Merged.ResponsibleOrganization serviceProviderOrganization;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt960002ca.GeographicCoordinates> subjectOfPosition;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lr.Merged.AvailableServices> locationOfServiceDefinition;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.ContactPoints> directAuthorityOverContactParty;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lr.Merged.SubLocations> partSubLocation;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lr.Merged.IndirectAuthorithyOver indirectAuthority;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lr.Prpa_mt202301ca.Location partOfServiceDeliveryLocation;

        public Location() {
            this.code = new CVImpl();
            this.name = new SETImpl<ST, String>(typeof(STImpl));
            this.addr = new ADImpl();
            this.statusCode = new CSImpl();
            this.subjectOfPosition = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt960002ca.GeographicCoordinates>();
            this.locationOfServiceDefinition = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lr.Merged.AvailableServices>();
            this.directAuthorityOverContactParty = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.ContactPoints>();
            this.partSubLocation = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lr.Merged.SubLocations>();
        }
        /**
         * <summary>Business Name: B: Location Type</summary>
         * 
         * <remarks>Relationship: 
         * PRPA_MT202301CA.ServiceDeliveryLocation.code 
         * Conformance/Cardinality: MANDATORY (1) <p> <i>Location Type 
         * is used for searching and for organizing Location records as 
         * well as sorting them for presentation.</i> </p><p> <i>This 
         * is a key attribute for understanding the type of record and 
         * is therefore mandatory.</i> </p> <p> <i>Identifies the type 
         * of Location represented by this record.</i> </p><p>For 
         * example, a service delivery location may be either an 
         * incidental service delivery location (a place at which 
         * health-related services may be provided without prior 
         * designation or authorization such as a church or school) or 
         * a dedicated service delivery location (a place that is 
         * intended to house the provision of health-related services 
         * such as a clinic or hospital). Dedicated service delivery 
         * locations can be further characterized as either clinical or 
         * non-clinical.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ServiceDeliveryLocationRoleType Code {
            get { return (ServiceDeliveryLocationRoleType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: D:Location Names</summary>
         * 
         * <remarks>Relationship: 
         * PRPA_MT202301CA.ServiceDeliveryLocation.name 
         * Conformance/Cardinality: REQUIRED (0-5) <p>Provides a 
         * human-readable label for the location. The location name is 
         * not intended to be parsed or analyzed by when processing the 
         * record. (E.g. To determine if a location is a hospital, look 
         * at the location type, don't check the name for the word 
         * &quot;hospital&quot;.)</p><p>Multiple repetitions are 
         * allowed to capture historical names</p> <p>A textual name 
         * for the place where the service is provided e.g. Ottawa 
         * General Hospital.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"name"})]
        public ICollection<String> Name {
            get { return this.name.RawSet(); }
        }

        /**
         * <summary>Business Name: G:Location Address</summary>
         * 
         * <remarks>Relationship: 
         * PRPA_MT202301CA.ServiceDeliveryLocation.addr 
         * Conformance/Cardinality: POPULATED (1) <p>Restricted to 
         * physical address only</p> <p>Allows location to be visited. 
         * May also be used for geographic profiling (e.g. a dispatcher 
         * may be looking for the closest hospital or ambulance that 
         * can help a patient in need of emergency care).</p><p>Because 
         * a physical address may not exist for mobile locations, and 
         * may not be expressible for non-dedicated locations such as 
         * water resevoirs, this element is only 'populated'. When no 
         * address exists, the null flavor should be set to NA.</p> 
         * <p>For mobile service delivery location, this can either be 
         * set to the address of the &quot;home&quot; site for the 
         * mobile unit or can be set to a null flavor of N/A.</p> 
         * <p>Identifies the physical address for this service delivery 
         * location, I.e. What is the geographic location of the 
         * building.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"addr"})]
        public PostalAddress Addr {
            get { return this.addr.Value; }
            set { this.addr.Value = value; }
        }

        /**
         * <summary>Business Name: C: Location Status</summary>
         * 
         * <remarks>Relationship: 
         * PRPA_MT202301CA.ServiceDeliveryLocation.statusCode 
         * Conformance/Cardinality: POPULATED (1) <p> <i>Status is 
         * frequently used to filter query responses as well as to sort 
         * records for presentation. It also affects how the Location 
         * record is interpreted.</i> </p><p> <i>Because the status 
         * won't always be known, the attribute is marked as 
         * 'populated' to allow the use of null flavors.</i> </p> <p> 
         * <i>This identifies the current state of the Location 
         * record.</i> </p><p>Allowed status values are 'active' (the 
         * location is actively used to deliver healthcare-related 
         * services), 'suspended' (the location has temporarily ceased 
         * delivering healthcare-related services) and 'terminated' 
         * (the location has permanently ceased delivering 
         * healthcare-related services and may no longer physically 
         * exist.)</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ServiceDeliveryRoleStatus StatusCode {
            get { return (ServiceDeliveryRoleStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PRPA_MT202301CA.ServiceDeliveryLocation.location</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lr.Merged.Place LocationValue {
            get { return this.locationValue; }
            set { this.locationValue = value; }
        }

        /**
         * <summary>Relationship: 
         * PRPA_MT202301CA.ServiceDeliveryLocation.serviceProviderOrganization</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"serviceProviderOrganization"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lr.Merged.ResponsibleOrganization ServiceProviderOrganization {
            get { return this.serviceProviderOrganization; }
            set { this.serviceProviderOrganization = value; }
        }

        /**
         * <summary>Relationship: PRPA_MT202301CA.Subject.position</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf/position"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt960002ca.GeographicCoordinates> SubjectOfPosition {
            get { return this.subjectOfPosition; }
        }

        /**
         * <summary>Relationship: 
         * PRPA_MT202301CA.Location.serviceDefinition</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"locationOf/serviceDefinition"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lr.Merged.AvailableServices> LocationOfServiceDefinition {
            get { return this.locationOfServiceDefinition; }
        }

        /**
         * <summary>Relationship: 
         * PRPA_MT202301CA.DirectAuthorityOver.contactParty</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"directAuthorityOver/contactParty"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.ContactPoints> DirectAuthorityOverContactParty {
            get { return this.directAuthorityOverContactParty; }
        }

        /**
         * <summary>Relationship: PRPA_MT202301CA.Part.subLocation</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"part/subLocation"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lr.Merged.SubLocations> PartSubLocation {
            get { return this.partSubLocation; }
        }

        /**
         * <summary>Relationship: 
         * PRPA_MT202301CA.ServiceDeliveryLocation.indirectAuthority</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"indirectAuthority"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lr.Merged.IndirectAuthorithyOver IndirectAuthority {
            get { return this.indirectAuthority; }
            set { this.indirectAuthority = value; }
        }

        /**
         * <summary>Relationship: 
         * PRPA_MT202301CA.Part2.serviceDeliveryLocation</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"partOf/serviceDeliveryLocation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lr.Prpa_mt202301ca.Location PartOfServiceDeliveryLocation {
            get { return this.partOfServiceDeliveryLocation; }
            set { this.partOfServiceDeliveryLocation = value; }
        }

    }

}