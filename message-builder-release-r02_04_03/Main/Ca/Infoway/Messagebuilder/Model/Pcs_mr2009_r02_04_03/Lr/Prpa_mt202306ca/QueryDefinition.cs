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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lr.Prpa_mt202306ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Query Definition</summary>
     * 
     * <p>Search Radius may only be specified if Near Address is 
     * specified</p> <p>Allows the user and/or the point-of-service 
     * application to constrain what EHR information they wish to 
     * retrieve.</p> <p>Identifies the various parameters that act 
     * as filters on the records to be retrieved.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPA_MT202306CA.ParameterList"})]
    public class QueryDefinition : MessagePartBean {

        private AD addressValue;
        private TS amendedSinceDateTimeValue;
        private II eHRRepositoryIdValue;
        private BL locationMobileIndicatorValue;
        private CV locationPlaceTypeValue;
        private IList<CV> locationServiceTypeValue;
        private ST nameContainsValue;
        private AD nearAddressValue;
        private IList<II> protocolIdValue;
        private IList<CS> recordStatusValue;
        private IList<CD> recordTypeValue;
        private IList<II> regionIdValue;
        private II responsibleOrganizationIdValue;
        private PQ searchRadiusValue;

        public QueryDefinition() {
            this.addressValue = new ADImpl();
            this.amendedSinceDateTimeValue = new TSImpl();
            this.eHRRepositoryIdValue = new IIImpl();
            this.locationMobileIndicatorValue = new BLImpl();
            this.locationPlaceTypeValue = new CVImpl();
            this.locationServiceTypeValue = new List<CV>();
            this.nameContainsValue = new STImpl();
            this.nearAddressValue = new ADImpl();
            this.protocolIdValue = new List<II>();
            this.recordStatusValue = new List<CS>();
            this.recordTypeValue = new List<CD>();
            this.regionIdValue = new List<II>();
            this.responsibleOrganizationIdValue = new IIImpl();
            this.searchRadiusValue = new PQImpl();
        }
        /**
         * <summary>Business Name: ZE: Address</summary>
         * 
         * <remarks>Relationship: PRPA_MT202306CA.Address.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows filtering 
         * the physical location of the facility.</p> <p>If specified, 
         * filters the returned location records to those in the 
         * specified province/territory or municipality.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"address/value"})]
        public PostalAddress AddressValue {
            get { return this.addressValue.Value; }
            set { this.addressValue.Value = value; }
        }

        /**
         * <summary>Business Name: K: Updated Since DateTime</summary>
         * 
         * <remarks>Relationship: 
         * PRPA_MT202306CA.AmendedSinceDateTime.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Useful to retrieve 
         * information &quot;since you last checked&quot;.</p> 
         * <p>Filters the records retrieved to only include those which 
         * have been created or revised since the specified date and 
         * time. If unspecified, no filter is applied.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"amendedSinceDateTime/value"})]
        public PlatformDate AmendedSinceDateTimeValue {
            get { return this.amendedSinceDateTimeValue.Value; }
            set { this.amendedSinceDateTimeValue.Value = value; }
        }

        /**
         * <summary>Business Name: Q: EHR Repository Id</summary>
         * 
         * <remarks>Relationship: PRPA_MT202306CA.EHRRepositoryId.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Primarily intended 
         * to allow filtering an initial search to a local EHR 
         * repository for performance reasons.</p> <p>Filters the 
         * records retrieved to only include those records from a 
         * specific EHR repository. If unspecified, all 
         * &quot;connected&quot; EHR repositories will be searched.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"eHRRepositoryId/value"})]
        public Identifier EHRRepositoryIdValue {
            get { return this.eHRRepositoryIdValue.Value; }
            set { this.eHRRepositoryIdValue.Value = value; }
        }

        /**
         * <summary>Business Name: ZC: Location Mobile Indicator</summary>
         * 
         * <remarks>Relationship: 
         * PRPA_MT202306CA.LocationMobileIndicator.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows restricting 
         * to either mobile or non-mobile locations.</p> <p>If 
         * specified, filters the returned location records to either 
         * those which are mobile or non-mobile. If unspecified, no 
         * filter is applied.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"locationMobileIndicator/value"})]
        public bool? LocationMobileIndicatorValue {
            get { return this.locationMobileIndicatorValue.Value; }
            set { this.locationMobileIndicatorValue.Value = value; }
        }

        /**
         * <summary>Business Name: ZA: Location Place Type</summary>
         * 
         * <remarks>Relationship: 
         * PRPA_MT202306CA.LocationPlaceType.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows 
         * constraining the types of records to retrieve. Multiple 
         * repetitions are provided to allow more than one type to be 
         * included.</p> <p>Filters the returned location records to 
         * only include specific types of places such as facilities, 
         * departments, buildings, wards, etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"locationPlaceType/value"})]
        public ServiceDeliveryLocationPlaceType LocationPlaceTypeValue {
            get { return (ServiceDeliveryLocationPlaceType) this.locationPlaceTypeValue.Value; }
            set { this.locationPlaceTypeValue.Value = value; }
        }

        /**
         * <summary>Business Name: ZB: Location Service Types</summary>
         * 
         * <remarks>Relationship: 
         * PRPA_MT202306CA.LocationServiceType.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows searching 
         * for facilities able to deliver certain services or groups of 
         * services.</p> <p>Filters the returned location records to 
         * only include locations that provide the specified type of 
         * service(s), etc. Multiple repetitions will be treated as 
         * &quot;AND&quot;. I.e. Locations that provide A and B. If 
         * this criterion is used, it will only match on services that 
         * are marked as &quot;available&quot;.</p><p> <i>Query results 
         * should include those with an match of this code, as well 
         * those matching any specializations of the coded 
         * parameter.</i> </p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"locationServiceType/value"})]
        public IList<ActServiceDeliveryLocationService> LocationServiceTypeValue {
            get { return new RawListWrapper<CV, ActServiceDeliveryLocationService>(locationServiceTypeValue, typeof(CVImpl)); }
        }

        /**
         * <summary>Business Name: Z: Name Contains</summary>
         * 
         * <remarks>Relationship: PRPA_MT202306CA.NameContains.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows searching 
         * by name.</p><p>Note: Searches should be case-insensitive and 
         * should ignore punctuation and spacing. Some implementations 
         * may perform &quot;sounds-like&quot; searches.</p> <p>Filters 
         * the returned location records to only include those whose 
         * name includes the specified string. If unspecified, no 
         * filter is applied.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"nameContains/value"})]
        public String NameContainsValue {
            get { return this.nameContainsValue.Value; }
            set { this.nameContainsValue.Value = value; }
        }

        /**
         * <summary>Business Name: ZF: Near Address</summary>
         * 
         * <remarks>Relationship: PRPA_MT202306CA.NearAddress.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows retrieving 
         * facilities near to a particular location.</p> <p>Identifies 
         * an address that returned locations should be near to. 
         * Results will be filtered to those appearing within the 
         * specified radius from the identified address.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"nearAddress/value"})]
        public PostalAddress NearAddressValue {
            get { return this.nearAddressValue.Value; }
            set { this.nearAddressValue.Value = value; }
        }

        /**
         * <summary>Business Name: ZI: Protocol Ids</summary>
         * 
         * <remarks>Relationship: PRPA_MT202306CA.ProtocolId.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows retrieving 
         * records associated with a particular protocol. Useful in 
         * clinical studies and other research.</p><p>The element is 
         * optional because support for protocols is not deemed a 
         * neccesity for many healthcare providers.</p> <p>Filters the 
         * records retrieved to only include those associated with the 
         * specified protocols. If unspecified, no filter is 
         * applied.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"protocolId/value"})]
        public IList<Identifier> ProtocolIdValue {
            get { return new RawListWrapper<II, Identifier>(protocolIdValue, typeof(IIImpl)); }
        }

        /**
         * <summary>Business Name: I: Record Statuses</summary>
         * 
         * <remarks>Relationship: PRPA_MT202306CA.RecordStatus.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows 
         * constraining the status of records to be retrieved. Multiple 
         * repetitions are present to allow selection of multiple 
         * statuses with a single query.</p> <p>Filters the set of 
         * records to be retrieved to only include those with the 
         * identified status(s). If no values are specified, no filter 
         * will be applied.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"recordStatus/value"})]
        public IList<ServiceDeliveryRoleStatus> RecordStatusValue {
            get { return new RawListWrapper<CS, ServiceDeliveryRoleStatus>(recordStatusValue, typeof(CSImpl)); }
        }

        /**
         * <summary>Business Name: H:Record Types</summary>
         * 
         * <remarks>Relationship: PRPA_MT202306CA.RecordType.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows 
         * constraining the type of records to be retrieved. Multiple 
         * repetitions are present to allow selection of multiple types 
         * with a single query.</p><p> <i>This element makes use of the 
         * CD datatype to allow for use of the SNOMED code system that 
         * in some circumstances requires the use of post-coordination. 
         * Post-coordination is only supported by the CD datatype.</i> 
         * </p> <p>Filters the type(s) or category(ies) of the records 
         * to be retrieved. The query will return both those records 
         * whose type exactly matches, as well as those whose types are 
         * subsets of the specified parameter. If no Types are 
         * specified, no restriction will be placed on the types to be 
         * returned.</p><p> <i>Query results should include those with 
         * an match of this code, as well those matching any 
         * specializations of the coded parameter.</i> </p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"recordType/value"})]
        public IList<ServiceDeliveryLocationRoleType> RecordTypeValue {
            get { return new RawListWrapper<CD, ServiceDeliveryLocationRoleType>(recordTypeValue, typeof(CDImpl)); }
        }

        /**
         * <summary>Business Name: ZD: Region Ids</summary>
         * 
         * <remarks>Relationship: PRPA_MT202306CA.RegionId.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows restricting 
         * the retrieved locations to those associated with a 
         * particular health region.</p> <p>If specified, filters the 
         * returned location records to those which are part of the 
         * specified 'region'.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"regionId/value"})]
        public IList<Identifier> RegionIdValue {
            get { return new RawListWrapper<II, Identifier>(regionIdValue, typeof(IIImpl)); }
        }

        /**
         * <summary>Business Name: ZH: Responsible Organization Id</summary>
         * 
         * <remarks>Relationship: 
         * PRPA_MT202306CA.ResponsibleOrganizationId.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows returning 
         * all locations associated with a particular organization.</p> 
         * <p>If specified, filters the returned location records to 
         * those which are under the responsibility of the specified 
         * organization.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleOrganizationId/value"})]
        public Identifier ResponsibleOrganizationIdValue {
            get { return this.responsibleOrganizationIdValue.Value; }
            set { this.responsibleOrganizationIdValue.Value = value; }
        }

        /**
         * <summary>Business Name: ZG: Search Radius</summary>
         * 
         * <remarks>Relationship: PRPA_MT202306CA.SearchRadius.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows retrieving 
         * facilities near to a particular location.</p> <p>Identifies 
         * the distance from the &quot;Near Address&quot; within which 
         * locations should be retrieved.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"searchRadius/value"})]
        public PhysicalQuantity SearchRadiusValue {
            get { return this.searchRadiusValue.Value; }
            set { this.searchRadiusValue.Value = value; }
        }

    }

}