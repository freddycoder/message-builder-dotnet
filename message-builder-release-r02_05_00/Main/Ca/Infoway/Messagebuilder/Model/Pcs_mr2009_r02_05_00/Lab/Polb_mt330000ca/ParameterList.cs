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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Polb_mt330000ca {
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
    [Hl7PartTypeMappingAttribute(new string[] {"POLB_MT330000CA.ParameterList"})]
    public class ParameterList : MessagePartBean {

        private CS batteryRequestStatusValue;
        private BL includeHistoryIndicatorValue;
        private BL includeNullifiedIndicatorValue;
        private BL includeResultsIndicatorValue;
        private IVL<TS, Interval<PlatformDate>> observationRequestAvailabilityDateTimeRangeValue;
        private CS observationRequestStatusValue;
        private IVL<TS, Interval<PlatformDate>> orderEnteredDateTimeRangeValue;
        private CD orderTestCodeValue;
        private II orderingProviderValue;
        private TS patientDateofBirthValue;
        private CV patientGenderValue;
        private II patientIDValue;
        private PN patientNameValue;
        private II placerOrderNumberValue;

        public ParameterList() {
            this.batteryRequestStatusValue = new CSImpl();
            this.includeHistoryIndicatorValue = new BLImpl();
            this.includeNullifiedIndicatorValue = new BLImpl();
            this.includeResultsIndicatorValue = new BLImpl();
            this.observationRequestAvailabilityDateTimeRangeValue = new IVLImpl<TS, Interval<PlatformDate>>();
            this.observationRequestStatusValue = new CSImpl();
            this.orderEnteredDateTimeRangeValue = new IVLImpl<TS, Interval<PlatformDate>>();
            this.orderTestCodeValue = new CDImpl();
            this.orderingProviderValue = new IIImpl();
            this.patientDateofBirthValue = new TSImpl();
            this.patientGenderValue = new CVImpl();
            this.patientIDValue = new IIImpl();
            this.patientNameValue = new PNImpl();
            this.placerOrderNumberValue = new IIImpl();
        }
        /**
         * <summary>Business Name: Order Status Value</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT330000CA.BatteryRequestStatus.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for the 
         * selection of only &quot;active&quot; orders or 
         * &quot;completed&quot; orders.</p> <p>Communicates the status 
         * of the order.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"batteryRequestStatus/value"})]
        public ActStatus BatteryRequestStatusValue {
            get { return (ActStatus) this.batteryRequestStatusValue.Value; }
            set { this.batteryRequestStatusValue.Value = value; }
        }

        /**
         * <summary>Business Name: Include History Indicator</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT330000CA.IncludeHistoryIndicator.value 
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
         * <summary>Business Name: Include Nullified Orders Indicator</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT330000CA.IncludeNullifiedIndicator.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates whether 
         * or not to include nullified orders. True=include records, 
         * the default is false</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"includeNullifiedIndicator/value"})]
        public bool? IncludeNullifiedIndicatorValue {
            get { return this.includeNullifiedIndicatorValue.Value; }
            set { this.includeNullifiedIndicatorValue.Value = value; }
        }

        /**
         * <summary>Business Name: Include Results Indicator</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT330000CA.IncludeResultsIndicator.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates whether 
         * or not to include results (current if present) with each 
         * order. True=include records, the default is false.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"includeResultsIndicator/value"})]
        public bool? IncludeResultsIndicatorValue {
            get { return this.includeResultsIndicatorValue.Value; }
            set { this.includeResultsIndicatorValue.Value = value; }
        }

        /**
         * <summary>Business Name: Observation Request Availability 
         * Effective Time Range</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT330000CA.ObservationRequestAvailabilityDateTimeRange.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows 
         * constraining the retrieved records to those applicable at a 
         * particular time.</p> <p>Filters the set of records to be 
         * retrieved to those in which the observation request 
         * availability date/time for the patient is within the time 
         * boundaries specified. Either the lower bound or upper bound 
         * or both would be specified. If no value is specified, no 
         * filter will be applied.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"observationRequestAvailabilityDateTimeRange/value"})]
        public Interval<PlatformDate> ObservationRequestAvailabilityDateTimeRangeValue {
            get { return this.observationRequestAvailabilityDateTimeRangeValue.Value; }
            set { this.observationRequestAvailabilityDateTimeRangeValue.Value = value; }
        }

        /**
         * <summary>Business Name: Order Status Value</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT330000CA.ObservationRequestStatus.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for the 
         * selection of only &quot;active&quot; orders or 
         * &quot;completed&quot; orders.</p> <p>Communicates the status 
         * of the order.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"observationRequestStatus/value"})]
        public ActStatus ObservationRequestStatusValue {
            get { return (ActStatus) this.observationRequestStatusValue.Value; }
            set { this.observationRequestStatusValue.Value = value; }
        }

        /**
         * <summary>Business Name: Order Entry Effective Time Range</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT330000CA.OrderEnteredDateTimeRange.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows 
         * constraining the retrieved records to those applicable at a 
         * particular time.</p> <p>Filters the set of records to be 
         * retrieved to those in which the order entry date/time for 
         * the patient are within the time boundaries specified. Either 
         * the lower bound or upper bound or both would be specified. 
         * If no value is specified, no filter will be applied.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"orderEnteredDateTimeRange/value"})]
        public Interval<PlatformDate> OrderEnteredDateTimeRangeValue {
            get { return this.orderEnteredDateTimeRangeValue.Value; }
            set { this.orderEnteredDateTimeRangeValue.Value = value; }
        }

        /**
         * <summary>Business Name: Order Test Code</summary>
         * 
         * <remarks>Relationship: POLB_MT330000CA.OrderTestCode.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Identifies the 
         * specific test to perform.</p> <p>The code to describe the 
         * type of test requested to be performed.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"orderTestCode/value"})]
        public ObservationOrderableLabType OrderTestCodeValue {
            get { return (ObservationOrderableLabType) this.orderTestCodeValue.Value; }
            set { this.orderTestCodeValue.Value = value; }
        }

        /**
         * <summary>Business Name: Ordering Provider Identifier</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT330000CA.OrderingProvider.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows 
         * constraining the retrieved records to those applicable for a 
         * specific ordering provider.</p> <p>Select only those records 
         * for this ordering provider.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"orderingProvider/value"})]
        public Identifier OrderingProviderValue {
            get { return this.orderingProviderValue.Value; }
            set { this.orderingProviderValue.Value = value; }
        }

        /**
         * <summary>Business Name: Patient DOB</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT330000CA.PatientDateofBirth.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Used to verify 
         * patient identity (a check against the patient id 
         * parameter).</p> <p>Patient's date of birth.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"patientDateofBirth/value"})]
        public PlatformDate PatientDateofBirthValue {
            get { return this.patientDateofBirthValue.Value; }
            set { this.patientDateofBirthValue.Value = value; }
        }

        /**
         * <summary>Business Name: Patient Gender</summary>
         * 
         * <remarks>Relationship: POLB_MT330000CA.PatientGender.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Used to verify 
         * patient identity (a check against the patient id 
         * parameter).</p> <p>Patient's administrative gender (sex) 
         * code.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"patientGender/value"})]
        public AdministrativeGender PatientGenderValue {
            get { return (AdministrativeGender) this.patientGenderValue.Value; }
            set { this.patientGenderValue.Value = value; }
        }

        /**
         * <summary>Business Name: Patient ID</summary>
         * 
         * <remarks>Relationship: POLB_MT330000CA.PatientID.value 
         * Conformance/Cardinality: REQUIRED (1) <p>Identifies the 
         * patient whose information is to be retrieved.</p> <p>A 
         * globally unique identifier for the patient whose information 
         * is to be retrieved.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"patientID/value"})]
        public Identifier PatientIDValue {
            get { return this.patientIDValue.Value; }
            set { this.patientIDValue.Value = value; }
        }

        /**
         * <summary>Business Name: Patient Name</summary>
         * 
         * <remarks>Relationship: POLB_MT330000CA.PatientName.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Used to verify 
         * patient identity (a check against the patient id 
         * parameter).</p> <p>Name for the patient.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"patientName/value"})]
        public PersonName PatientNameValue {
            get { return this.patientNameValue.Value; }
            set { this.patientNameValue.Value = value; }
        }

        /**
         * <summary>Business Name: Placer Order Number</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT330000CA.PlacerOrderNumber.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows 
         * constraining the retrieved records by identifier.</p> 
         * <p>Must contain a value assigned by the order-placing 
         * organization that uniquely identifies the test for query 
         * selection.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"placerOrderNumber/value"})]
        public Identifier PlacerOrderNumberValue {
            get { return this.placerOrderNumberValue.Value; }
            set { this.placerOrderNumberValue.Value = value; }
        }

    }

}