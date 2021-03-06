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
 * Author:        $LastChangedBy: jmis $
 * Last modified: $LastChangedDate: 2015-09-15 11:09:53 -0400 (Tue, 15 Sep 2015) $
 * Revision:      $LastChangedRevision: 9796 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Repc_mt210004ca {
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
     * <p>Allows the user and/or the point-of-service application 
     * to constrain what EHR information they wish to retrieve.</p> 
     * <p>Identifies the various parameters that act as filters on 
     * the records to be retrieved.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT210004CA.ParameterList"})]
    public class QueryDefinition : MessagePartBean {

        private TS amendedSinceDateTimeValue;
        private BL attestedIndicatorValue;
        private IList<II> careCompositionIdValue;
        private IList<CV> careCompositionTypeValue;
        private II eHRRepositoryIdValue;
        private IVL<TS, Interval<PlatformDate>> effectiveTimeRangeValue;
        private IList<CV> eventCategoryValue;
        private II eventLocationIdValue;
        private CV eventLocationTypeValue;
        private IList<CD> healthConditionValue;
        private CD indicationValue;
        private BL mostRecentByTypeIndicatorValue;
        private IList<II> protocolIdValue;
        private II recipientLocationIdValue;
        private II recipientProviderIdValue;
        private IList<CS> recordStatusValue;
        private IList<CD> recordTypeValue;
        private II requestingProviderIdValue;
        private II responsibleProviderIdValue;
        private CV responsibleProviderTypeValue;

        public QueryDefinition() {
            this.amendedSinceDateTimeValue = new TSImpl();
            this.attestedIndicatorValue = new BLImpl();
            this.careCompositionIdValue = new List<II>();
            this.careCompositionTypeValue = new List<CV>();
            this.eHRRepositoryIdValue = new IIImpl();
            this.effectiveTimeRangeValue = new IVLImpl<TS, Interval<PlatformDate>>();
            this.eventCategoryValue = new List<CV>();
            this.eventLocationIdValue = new IIImpl();
            this.eventLocationTypeValue = new CVImpl();
            this.healthConditionValue = new List<CD>();
            this.indicationValue = new CDImpl();
            this.mostRecentByTypeIndicatorValue = new BLImpl();
            this.protocolIdValue = new List<II>();
            this.recipientLocationIdValue = new IIImpl();
            this.recipientProviderIdValue = new IIImpl();
            this.recordStatusValue = new List<CS>();
            this.recordTypeValue = new List<CD>();
            this.requestingProviderIdValue = new IIImpl();
            this.responsibleProviderIdValue = new IIImpl();
            this.responsibleProviderTypeValue = new CVImpl();
        }
        /**
         * <summary>Business Name: K: Updated Since DateTime</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT210004CA.AmendedSinceDateTime.value 
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
         * <summary>Business Name: ZM: Attested Indicator</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT210004CA.AttestedIndicator.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows filtering 
         * to only see those documents which are &quot;known&quot; to 
         * be accurate. May also be used to retrieve documents 
         * associated with a provider which are unauthenticated.</p> 
         * <p>If specified, filters the returned documents to only 
         * include those which have been attested as correct by the 
         * document author or which have not been authenticated. If not 
         * specified, both attested and non-attested documents will be 
         * returned. Relevant for transcribed reports (e.g. the data 
         * enterer is different than the 'author'). Records where 
         * &quot;attestation&quot; is marked as &quot;Not 
         * applicable&quot; will be treated as attested.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"attestedIndicator/value"})]
        public bool? AttestedIndicatorValue {
            get { return this.attestedIndicatorValue.Value; }
            set { this.attestedIndicatorValue.Value = value; }
        }

        /**
         * <summary>Business Name: R: Care Composition Ids</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT210004CA.CareCompositionId.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows retrieving 
         * all records associated with an encounter, episode or care 
         * event.</p> <p>Filters the records retrieved to only include 
         * those associated with the specified encounter, episode or 
         * care event. If unspecified, no filter is 
         * applied.</p><p>Note: When matching on care composition id, 
         * systems should also retrieve records with a fulfillment id 
         * to requisitions associated with the care composition. E.g. 
         * When retrieving records associated with an encounter which 
         * includes a referral, the retrieved records should also 
         * include the care summary created in fulfillment of the 
         * referral.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"careCompositionId/value"})]
        public IList<Identifier> CareCompositionIdValue {
            get { return new RawListWrapper<II, Identifier>(careCompositionIdValue, typeof(IIImpl)); }
        }

        /**
         * <summary>Business Name: S: Care Composition Types</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT210004CA.CareCompositionType.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows retrieving 
         * all records associated with a particular type of encounter, 
         * episode or care event. E.g. Orthopedic Clinic Encounter, ER 
         * encounter, Walk-in encounter, etc.</p> <p>Filters the 
         * records retrieved to only include those associated with the 
         * specified 'kind' of encounter, episode or care event. If 
         * unspecified, no filter is applied.</p><p> <i>Query results 
         * should include those with an match of this code, as well 
         * those matching any specializations of the coded 
         * parameter.</i> </p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"careCompositionType/value"})]
        public IList<ActCareEventType> CareCompositionTypeValue {
            get { return new RawListWrapper<CV, ActCareEventType>(careCompositionTypeValue, typeof(CVImpl)); }
        }

        /**
         * <summary>Business Name: Q: EHR Repository Id</summary>
         * 
         * <remarks>Relationship: REPC_MT210004CA.EHRRepositoryId.value 
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
         * <summary>Business Name: J: Effective Date Range</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT210004CA.EffectiveTimeRange.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows 
         * constraining the retrieved records to those applicable at a 
         * particular time. Useful in retrieving those records 
         * &quot;currently in effect&quot; as well as retrieving views 
         * of what information was in effect at some date in the 
         * past.</p> <p>Filters the set of records to be retrieved to 
         * those which occurred or were effective for the patient 
         * within the date boundaries specified. Either the lower bound 
         * or upper bound or both would be specified. If no value is 
         * specified, no filter will be applied. If there is any 
         * overlap between the specified date-range and the effective 
         * date of the record, the record will be returned.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTimeRange/value"})]
        public Interval<PlatformDate> EffectiveTimeRangeValue {
            get { return this.effectiveTimeRangeValue.Value; }
            set { this.effectiveTimeRangeValue.Value = value; }
        }

        /**
         * <summary>Business Name: ZJ: Event Categories</summary>
         * 
         * <remarks>Relationship: REPC_MT210004CA.EventCategory.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows filtering 
         * responses based on higher level categorization. Multiple 
         * repetitions are supported to allow for multiple categories 
         * to be returned.</p> <p>If specified, filters the returned 
         * records to those having the specified category. E.g. 
         * &quot;Allergy/Intolerance&quot;, &quot;Measured 
         * Observation&quot;, &quot;Cognitive Procedure&quot;. 
         * (Contrast this with &quot;Type&quot; which would allow 
         * searching for &quot;Drug Allergies&quot;, &quot;Patient 
         * Weight&quot; and &quot;Smoking Cessation 
         * Counseling&quot;.)</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"eventCategory/value"})]
        public IList<ReferralDocumentType> EventCategoryValue {
            get { return new RawListWrapper<CV, ReferralDocumentType>(eventCategoryValue, typeof(CVImpl)); }
        }

        /**
         * <summary>Business Name: O: Event Location Id</summary>
         * 
         * <remarks>Relationship: REPC_MT210004CA.EventLocationId.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows retrieving 
         * those records associated with a particular facility.</p> 
         * <p>Filters the records retrieved to only include those 
         * records which are officially associated with and/or were 
         * performed by a particular facility. I.e. It will return 
         * records where either the &quot;Service Location&quot; or the 
         * &quot;Record Location&quot; has the specified location id. 
         * Records associated with &quot;sub-locations&quot; (e.g. 
         * departments, wards) will be returned when searching by the 
         * larger location (e.g. hospital).</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"eventLocationId/value"})]
        public Identifier EventLocationIdValue {
            get { return this.eventLocationIdValue.Value; }
            set { this.eventLocationIdValue.Value = value; }
        }

        /**
         * <summary>Business Name: P: Event Location Type</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT210004CA.EventLocationType.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows retrieving 
         * those records associated with a particular kind of facility. 
         * E.g. Hospital, clinic, pharmacy, patient residence, etc.</p> 
         * <p>Filters the records retrieved to only include those 
         * records which are officially associated with and/or were 
         * performed by facilities with the specified type. I.e. It 
         * will return records where either the &quot;Service 
         * Location&quot; or the &quot;Record Location&quot; has the 
         * specified location type.</p><p> <i>Query results should 
         * include those with an match of this code, as well those 
         * matching any specializations of the coded parameter.</i> 
         * </p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"eventLocationType/value"})]
        public ServiceDeliveryLocationRoleType EventLocationTypeValue {
            get { return (ServiceDeliveryLocationRoleType) this.eventLocationTypeValue.Value; }
            set { this.eventLocationTypeValue.Value = value; }
        }

        /**
         * <summary>Business Name: T: Health Conditions</summary>
         * 
         * <remarks>Relationship: REPC_MT210004CA.HealthCondition.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows retrieving 
         * all records associated with a particular health condition or 
         * problem.</p><p> <i>This element makes use of the CD datatype 
         * to allow for use of the SNOMED code system that in some 
         * circumstances requires the use of post-coordination. 
         * Post-coordination is only supported by the CD datatype.</i> 
         * </p> <p>Filters the records retrieved to only include those 
         * associated with the specified health condition (e.g. has 
         * indication, discharge diagnosis, condition type, etc. 
         * Specifically, any record having an &quot;indication&quot; 
         * which matches the specified code, any Care composition or 
         * Discharge-Care Summary with a discharge disposition which 
         * matches the specified code, or any Coded Observation which 
         * matches the specified code and any Health Condition which 
         * matches the specified code). If there are episodes 
         * associated with the condition, the query will also return 
         * records associated with that episode. (I.e. Any record tied 
         * to an episode with an associated health condition has an 
         * implicit relationship to that health condition.) If 
         * unspecified, no filter is applied.</p><p> <i>Query results 
         * should include those with an match of this code, as well 
         * those matching any specializations of the coded 
         * parameter.</i> </p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"healthCondition/value"})]
        public IList<ActHealthConditionType> HealthConditionValue {
            get { return new RawListWrapper<CD, ActHealthConditionType>(healthConditionValue, typeof(CDImpl)); }
        }

        /**
         * <summary>Business Name: U: Indication</summary>
         * 
         * <remarks>Relationship: REPC_MT210004CA.Indication.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows retrieving 
         * all records associated with a particular indication.</p><p> 
         * <i>This element makes use of the CD datatype to allow for 
         * use of the SNOMED code system that in some circumstances 
         * requires the use of post-coordination. Post-coordination is 
         * only supported by the CD datatype.</i> </p> <p>Filters the 
         * records retrieved to only include those where the 
         * &quot;indication&quot; (reason) for the record was the 
         * specified code.</p><p>This is distinct from the Health 
         * Condition query parameter in that it will only return 
         * records with an explicit indication match (it will not match 
         * on discharge diagnosis, part of related episode, etc.) It 
         * also allows searching on indications such as prophylaxis, 
         * surgery prep, etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"indication/value"})]
        public ActIndicationType IndicationValue {
            get { return (ActIndicationType) this.indicationValue.Value; }
            set { this.indicationValue.Value = value; }
        }

        /**
         * <summary>Business Name: V: Most Recent By Type Indicator</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT210004CA.MostRecentByTypeIndicator.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Provides a 
         * mechanism of getting a quick overview of the types of events 
         * that have occurred without needing to look at all 
         * occurrences. The attribute is mandatory because it must be 
         * known whether to return the most recent or all records.</p> 
         * <p>If true, indicates that only the most recent records of a 
         * given type or category should be retrieved. I.e. If there 
         * are 10 records of the same kind, only the most recent one 
         * would be returned. If false, all occurrences will be 
         * returned.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"mostRecentByTypeIndicator/value"})]
        public bool? MostRecentByTypeIndicatorValue {
            get { return this.mostRecentByTypeIndicatorValue.Value; }
            set { this.mostRecentByTypeIndicatorValue.Value = value; }
        }

        /**
         * <summary>Business Name: ZI: Protocol Ids</summary>
         * 
         * <remarks>Relationship: REPC_MT210004CA.ProtocolId.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows retrieving 
         * records associated with a particular protocol. Useful in 
         * clinical studies and other research.</p><p>The element is 
         * optional because support for protocols is not deemed a 
         * necessity for many healthcare providers.</p> <p>Filters the 
         * records retrieved to only include those associated with the 
         * specified protocols. If unspecified, no filter is 
         * applied.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"protocolId/value"})]
        public IList<Identifier> ProtocolIdValue {
            get { return new RawListWrapper<II, Identifier>(protocolIdValue, typeof(IIImpl)); }
        }

        /**
         * <summary>Business Name: ZO: Recipient Location Id</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT210004CA.RecipientLocationId.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows retrieval 
         * of all documents sent to a particular location. E.g. 
         * &quot;Find all documents targeted to my location&quot;</p> 
         * <p>If specified, filters the returned documents to only 
         * include those which were targeted to the specified location. 
         * If not specified, no filter is applied</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"recipientLocationId/value"})]
        public Identifier RecipientLocationIdValue {
            get { return this.recipientLocationIdValue.Value; }
            set { this.recipientLocationIdValue.Value = value; }
        }

        /**
         * <summary>Business Name: ZN: Recipient Provider Id</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT210004CA.RecipientProviderId.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows retrieval 
         * of all documents sent to a particular provider. E.g. 
         * &quot;Find all documents targeted to me&quot;</p> <p>If 
         * specified, filters the returned documents to only include 
         * those which were targeted to the specified provider. If not 
         * specified, no filter is applied</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"recipientProviderId/value"})]
        public Identifier RecipientProviderIdValue {
            get { return this.recipientProviderIdValue.Value; }
            set { this.recipientProviderIdValue.Value = value; }
        }

        /**
         * <summary>Business Name: I: Record Statuses</summary>
         * 
         * <remarks>Relationship: REPC_MT210004CA.RecordStatus.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows 
         * constraining the status of records to be retrieved. Multiple 
         * repetitions are present to allow selection of multiple 
         * statuses with a single query.</p> <p>Filters the set of 
         * records to be retrieved to only include those with the 
         * identified status(s). If no values are specified, no filter 
         * will be applied.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"recordStatus/value"})]
        public IList<ActStatus> RecordStatusValue {
            get { return new RawListWrapper<CS, ActStatus>(recordStatusValue, typeof(CSImpl)); }
        }

        /**
         * <summary>Business Name: H:Record Types</summary>
         * 
         * <remarks>Relationship: REPC_MT210004CA.RecordType.value 
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
        public IList<ActCareProvisionRequestType> RecordTypeValue {
            get { return new RawListWrapper<CD, ActCareProvisionRequestType>(recordTypeValue, typeof(CDImpl)); }
        }

        /**
         * <summary>Business Name: N: Requesting Provider Id</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT210004CA.RequestingProviderId.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows a provider 
         * to see the results of any requests they may have made.</p> 
         * <p>Filters the records retrieved to only include those whose 
         * creation/performance were requested by the identified 
         * provider. If unspecified, no filter is applied.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"requestingProviderId/value"})]
        public Identifier RequestingProviderIdValue {
            get { return this.requestingProviderIdValue.Value; }
            set { this.requestingProviderIdValue.Value = value; }
        }

        /**
         * <summary>Business Name: L: Responsible Provider Id</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT210004CA.ResponsibleProviderId.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows retrieving 
         * those records in which a particular provider has a vested 
         * interest.</p> <p>Filters the records retrieved to only 
         * include those where the identified provider was the author, 
         * supervisor or performer. If unspecified, no filter is 
         * applied.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleProviderId/value"})]
        public Identifier ResponsibleProviderIdValue {
            get { return this.responsibleProviderIdValue.Value; }
            set { this.responsibleProviderIdValue.Value = value; }
        }

        /**
         * <summary>Business Name: M: Responsible Provider Type</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT210004CA.ResponsibleProviderType.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows retrieving 
         * those records in which a particular kind of provider has a 
         * vested interest.</p> <p>Filters the records retrieved to 
         * only include those where the author, supervisor or performer 
         * was of the specified provider type. If unspecified, no 
         * filter is applied.</p><p> <i>Query results should include 
         * those with an match of this code, as well those matching any 
         * specializations of the coded parameter.</i> </p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleProviderType/value"})]
        public HealthcareProviderRoleType ResponsibleProviderTypeValue {
            get { return (HealthcareProviderRoleType) this.responsibleProviderTypeValue.Value; }
            set { this.responsibleProviderTypeValue.Value = value; }
        }

    }

}