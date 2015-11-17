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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Polb_mt320000ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <p>Allows the user and/or point-of-service application to 
     * constrain what EHR information to be retrieved.</p>
     * 
     * <p>Identifies the various parameters that act as filters on 
     * the records to be retrieved.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POLB_MT320000CA.ParameterList"})]
    public class ParameterList : MessagePartBean {

        private CV assignedPatientLocationValue;
        private BL includeHistoryIndicatorValue;
        private IVL<TS, Interval<PlatformDate>> jLISReceivedDateTimeValue;
        private IVL<TS, Interval<PlatformDate>> observationAvailabilityDateTimeRangeValue;
        private II orderingProviderValue;
        private II resultCopiesToValue;

        public ParameterList() {
            this.assignedPatientLocationValue = new CVImpl();
            this.includeHistoryIndicatorValue = new BLImpl();
            this.jLISReceivedDateTimeValue = new IVLImpl<TS, Interval<PlatformDate>>();
            this.observationAvailabilityDateTimeRangeValue = new IVLImpl<TS, Interval<PlatformDate>>();
            this.orderingProviderValue = new IIImpl();
            this.resultCopiesToValue = new IIImpl();
        }
        /**
         * <summary>Business Name: Assigned Patient Location Type</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT320000CA.AssignedPatientLocation.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows 
         * constraining the retrieved records to those patients seen at 
         * a location type (nursing station, clinic department, 
         * etc).</p> <p>Filters the set of records to be retrieved to 
         * those patients seen at a particular location type e.g. 
         * nursing home, nurse station, clinic department, etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"assignedPatientLocation/value"})]
        public ServiceDeliveryLocationRoleType AssignedPatientLocationValue {
            get { return (ServiceDeliveryLocationRoleType) this.assignedPatientLocationValue.Value; }
            set { this.assignedPatientLocationValue.Value = value; }
        }

        /**
         * <summary>Business Name: Include History Indicator</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT320000CA.IncludeHistoryIndicator.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Historical 
         * (version) records are usable for audit, quality assurance, 
         * etc.</p> <p>Indicates whether or not to include historical 
         * records (each change to a record, revisions, state changes, 
         * each trigger event). True=include records, the default is 
         * false.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"includeHistoryIndicator/value"})]
        public bool? IncludeHistoryIndicatorValue {
            get { return this.includeHistoryIndicatorValue.Value; }
            set { this.includeHistoryIndicatorValue.Value = value; }
        }

        /**
         * <summary>Business Name: JLIS Received Effective Time Range</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT320000CA.JLISReceivedDateTime.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows 
         * constraining the retrieved records to those applicable at a 
         * particular time.</p> <p>Filters the set of records to be 
         * retrieved to those which the JLIS received date/time within 
         * the time boundaries specified. Either the lower bound or 
         * upper bound or both would be specified. If no value is 
         * specified, no filter will be applied. If there is any 
         * overlap between the specified time-range and the JLIS 
         * received date/time, the record will be returned.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"jLISReceivedDateTime/value"})]
        public Interval<PlatformDate> JLISReceivedDateTimeValue {
            get { return this.jLISReceivedDateTimeValue.Value; }
            set { this.jLISReceivedDateTimeValue.Value = value; }
        }

        /**
         * <summary>Business Name: Observation Availability Time Range</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT320000CA.ObservationAvailabilityDateTimeRange.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows 
         * constraining the retrieved records to those applicable at a 
         * particular time.</p> <p>Filters the set of records to be 
         * retrieved to those which the observation availability 
         * date/time for the patient within the time boundaries 
         * specified. Either the lower bound or upper bound or both 
         * would be specified. If no value is specified, no filter will 
         * be applied. If there is any overlap between the specified 
         * time-range and the order entry date/time, the record will be 
         * returned.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"observationAvailabilityDateTimeRange/value"})]
        public Interval<PlatformDate> ObservationAvailabilityDateTimeRangeValue {
            get { return this.observationAvailabilityDateTimeRangeValue.Value; }
            set { this.observationAvailabilityDateTimeRangeValue.Value = value; }
        }

        /**
         * <summary>Business Name: Ordering Provider Identfier</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT320000CA.OrderingProvider.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows 
         * constraining the retrieved records to those applicable for a 
         * particular provider.</p> <p>Filters the set of records to be 
         * retrieved to those ordered by a specific provider.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"orderingProvider/value"})]
        public Identifier OrderingProviderValue {
            get { return this.orderingProviderValue.Value; }
            set { this.orderingProviderValue.Value = value; }
        }

        /**
         * <summary>Business Name: Result Copies To Identfier</summary>
         * 
         * <remarks>Relationship: POLB_MT320000CA.ResultCopiesTo.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows 
         * constraining the retrieved records to those applicable for a 
         * particular party to whom the result was copied.</p> 
         * <p>Filters the set of records to be retrieved to those 
         * copied to an identified party.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"resultCopiesTo/value"})]
        public Identifier ResultCopiesToValue {
            get { return this.resultCopiesToValue.Value; }
            set { this.resultCopiesToValue.Value = value; }
        }

    }

}