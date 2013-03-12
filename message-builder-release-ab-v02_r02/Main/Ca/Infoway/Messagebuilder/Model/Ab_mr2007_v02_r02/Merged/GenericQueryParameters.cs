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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>REPC_MT000016CA.ParameterList: Adverse Reactions 
     * Query Parameters</summary>
     * 
     * <p>Defines the set of parameters that may be used to filter 
     * the query response.</p> <p>Root class for query 
     * definition</p> PORX_MT060280CA.ParameterList: Drug 
     * Prescription Detail Query Parameters <p>Defines the set of 
     * parameters that may be used to filter the query 
     * response.</p> <p>Root class for query definition.</p> 
     * REPC_MT000004CA.ParameterList: Allergy/Intolerance Query 
     * Parameters <p>Defines the set of parameters that may be used 
     * to filter the query response</p> <p>Root class for query 
     * definition</p> PORX_MT060360CA.ParameterList: Generic Query 
     * Parameters <p>Defines the set of parameters that may be used 
     * to filter the query response.</p> <p>Root class for query 
     * definition</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060280CA.ParameterList","PORX_MT060360CA.ParameterList","REPC_MT000004CA.ParameterList","REPC_MT000016CA.ParameterList"})]
    public class GenericQueryParameters : MessagePartBean {

        private IList<II> careCompositionIDValue;
        private IList<CV> careCompositionTypeValue;
        private BL includeNotesIndicatorValue;
        private IVL<TS, Interval<PlatformDate>> reactionPeriodValue;
        private CV reactionTypeValue;
        private IVL<TS, Interval<PlatformDate>> amendedInTimeRangeValue;
        private BL includeEventHistoryIndicatorValue;
        private BL includeIssuesIndicatorValue;
        private BL includePendingChangesIndicatorValue;
        private II prescriptionOrderNumberValue;
        private CV allergyIntoleranceStatusValue;
        private CD allergyIntoleranceTypeValue;
        private IVL<TS, Interval<PlatformDate>> alllergyIntoleranceChangePeriodValue;
        private II prescriptionDispenseNumberValue;

        public GenericQueryParameters() {
            this.careCompositionIDValue = new List<II>();
            this.careCompositionTypeValue = new List<CV>();
            this.includeNotesIndicatorValue = new BLImpl();
            this.reactionPeriodValue = new IVLImpl<TS, Interval<PlatformDate>>();
            this.reactionTypeValue = new CVImpl();
            this.amendedInTimeRangeValue = new IVLImpl<TS, Interval<PlatformDate>>();
            this.includeEventHistoryIndicatorValue = new BLImpl();
            this.includeIssuesIndicatorValue = new BLImpl();
            this.includePendingChangesIndicatorValue = new BLImpl();
            this.prescriptionOrderNumberValue = new IIImpl();
            this.allergyIntoleranceStatusValue = new CVImpl();
            this.allergyIntoleranceTypeValue = new CDImpl();
            this.alllergyIntoleranceChangePeriodValue = new IVLImpl<TS, Interval<PlatformDate>>();
            this.prescriptionDispenseNumberValue = new IIImpl();
        }
        /**
         * <summary>Business Name: CareCompositionIDs</summary>
         * 
         * <remarks>Un-merged Business Name: CareCompositionIDs 
         * Relationship: PORX_MT060280CA.CareCompositionID.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Desc: Filters the 
         * records retrieved to only include those associated with the 
         * specified encounter, episode or care event. If unspecified, 
         * no filter is applied.</p><p>Note: When matching on care 
         * composition id, systems should also retrieve records with a 
         * fulfillment id to requisitions associated with the care 
         * composition. E.g. When retrieving records associated with an 
         * encounter which includes a referral, the retrieved records 
         * should also include the care summary created in fulfillment 
         * of the referral.</p> <p>Desc: Filters the records retrieved 
         * to only include those associated with the specified 
         * encounter, episode or care event. If unspecified, no filter 
         * is applied.</p><p>Note: When matching on care composition 
         * id, systems should also retrieve records with a fulfillment 
         * id to requisitions associated with the care composition. 
         * E.g. When retrieving records associated with an encounter 
         * which includes a referral, the retrieved records should also 
         * include the care summary created in fulfillment of the 
         * referral.</p> <p>Allows retrieving all records associated 
         * with an encounter, episode or care event.</p> Un-merged 
         * Business Name: CareCompositionIDs Relationship: 
         * REPC_MT000016CA.CareCompositionID.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Filters the 
         * records retrieved to only include those associated with the 
         * specified encounter, episode or care event. If unspecified, 
         * no filter is applied.</p><p>Note: When matching on care 
         * composition id, systems should also retrieve records with a 
         * fulfillment id to requisitions associated with the care 
         * composition. E.g. When retrieving records associated with an 
         * encounter which includes a referral, the retrieved records 
         * should also include the care summary created in fulfillment 
         * of the referral.</p> <p>Filters the records retrieved to 
         * only include those associated with the specified encounter, 
         * episode or care event. If unspecified, no filter is 
         * applied.</p><p>Note: When matching on care composition id, 
         * systems should also retrieve records with a fulfillment id 
         * to requisitions associated with the care composition. E.g. 
         * When retrieving records associated with an encounter which 
         * includes a referral, the retrieved records should also 
         * include the care summary created in fulfillment of the 
         * referral.</p> <p>Allows retrieving all records associated 
         * with an encounter, episode or care event.</p> Un-merged 
         * Business Name: CareCompositionIDs Relationship: 
         * REPC_MT000004CA.CareCompositionID.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Filters the 
         * records retrieved to only include those associated with the 
         * specified encounter, episode or care event. If unspecified, 
         * no filter is applied.</p><p>Note: When matching on care 
         * composition id, systems should also retrieve records with a 
         * fulfillment id to requisitions associated with the care 
         * composition. E.g. When retrieving records associated with an 
         * encounter which includes a referral, the retrieved records 
         * should also include the care summary created in fulfillment 
         * of the referral.</p> <p>Filters the records retrieved to 
         * only include those associated with the specified encounter, 
         * episode or care event. If unspecified, no filter is 
         * applied.</p><p>Note: When matching on care composition id, 
         * systems should also retrieve records with a fulfillment id 
         * to requisitions associated with the care composition. E.g. 
         * When retrieving records associated with an encounter which 
         * includes a referral, the retrieved records should also 
         * include the care summary created in fulfillment of the 
         * referral.</p> <p>Allows retrieving all records associated 
         * with an encounter, episode or care event.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"careCompositionID/value"})]
        public IList<Identifier> CareCompositionIDValue {
            get { return new RawListWrapper<II, Identifier>(careCompositionIDValue, typeof(IIImpl)); }
        }

        /**
         * <summary>Business Name: CareCompositionTypes</summary>
         * 
         * <remarks>Un-merged Business Name: CareCompositionTypes 
         * Relationship: PORX_MT060280CA.CareCompositionType.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Filters the 
         * records retrieved to only include those associated with the 
         * specified 'kind' of encounter, episode or care event. If 
         * unspecified, no filter is applied.</p> <p>Allows retrieving 
         * all records associated with a particular type of encounter, 
         * episode or care event. E.g.Orthopedic Clinic Encounter, ER 
         * encounter, Walk-in encounter, etc.</p> Un-merged Business 
         * Name: CareCompositionTypes Relationship: 
         * REPC_MT000016CA.CareCompositionType.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Filters the 
         * records retrieved to only include those associated with the 
         * specified 'kind' of encounter, episode or care event. If 
         * unspecified, no filter is applied.</p> <p>Allows retrieving 
         * all records associated with a particular type of encounter, 
         * episode or care event. E.g.Orthopedic Clinic Encounter, ER 
         * encounter, Walk-in encounter, etc.</p> Un-merged Business 
         * Name: CareCompositionTypes Relationship: 
         * REPC_MT000004CA.CareCompositionType.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Filters the 
         * records retrieved to only include those associated with the 
         * specified 'kind' of encounter, episode or care event. If 
         * unspecified, no filter is applied.</p> <p>Allows retrieving 
         * all records associated with a particular type of encounter, 
         * episode or care event. E.g.Orthopedic Clinic Encounter, ER 
         * encounter, Walk-in encounter, etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"careCompositionType/value"})]
        public IList<ActCareEventType> CareCompositionTypeValue {
            get { return new RawListWrapper<CV, ActCareEventType>(careCompositionTypeValue, typeof(CVImpl)); }
        }

        /**
         * <summary>Business Name: IncludeNotesIndicator</summary>
         * 
         * <remarks>Un-merged Business Name: IncludeNotesIndicator 
         * Relationship: PORX_MT060280CA.IncludeNotesIndicator.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates whether 
         * or not notes attached to the selected medication records are 
         * to be returned along with the detailed information.</p> 
         * <p>Allows for the flexibility of omitting/including notes in 
         * the retrieval of information for medication 
         * data.</p><p>Because the attribute is boolean, it must 
         * explicitly indicate a 'TRUE' or 'FALSE', and thus it is 
         * mandatory.</p> <p>Allows for the flexibility of 
         * omitting/including notes in the retrieval of information for 
         * medication data.</p><p>Because the attribute is boolean, it 
         * must explicitly indicate a 'TRUE' or 'FALSE', and thus it is 
         * mandatory.</p> Un-merged Business Name: 
         * IncludeNotesIndicator Relationship: 
         * REPC_MT000016CA.IncludeNotesIndicator.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates whether 
         * or not notes attached to the adverse reactions records are 
         * to be returned along with the detailed information.</p> 
         * <p>Allows for the flexibility of omitting/including notes in 
         * the retrieval of information for adverse reactions 
         * data.</p><p>Because the attribute is boolean, it must 
         * explicitly indicate a 'TRUE' or 'FALSE', and thus it is 
         * mandatory.</p> <p>Allows for the flexibility of 
         * omitting/including notes in the retrieval of information for 
         * adverse reactions data.</p><p>Because the attribute is 
         * boolean, it must explicitly indicate a 'TRUE' or 'FALSE', 
         * and thus it is mandatory.</p> Un-merged Business Name: 
         * IncludeNotesIndicator Relationship: 
         * PORX_MT060360CA.IncludeNotesIndicator.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates whether 
         * or not notes attached to the prescription dispense record 
         * are to be returned along with the detailed information.</p> 
         * <p>Allows for the flexibility of omitting/including notes in 
         * the retrieval of information for medication detail 
         * data.</p><p>Because the attribute is boolean, it must 
         * explicitly indicate a 'TRUE' or 'FALSE', and thus it is 
         * mandatory.</p> <p>Allows for the flexibility of 
         * omitting/including notes in the retrieval of information for 
         * medication detail data.</p><p>Because the attribute is 
         * boolean, it must explicitly indicate a 'TRUE' or 'FALSE', 
         * and thus it is mandatory.</p> Un-merged Business Name: 
         * IncludeNotesIndicator Relationship: 
         * REPC_MT000004CA.IncludeNotesIndicator.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates whether 
         * or not notes attached to the allergy/intolerance records are 
         * to be returned along with the detailed information.</p> 
         * <p>Allows for the flexibility of omitting/including notes in 
         * the retrieval of information for allergy/intolerance 
         * data.</p><p>Because the attribute is boolean, it must 
         * explicitly indicate a 'TRUE' or 'FALSE', and thus it is 
         * mandatory.</p> <p>Allows for the flexibility of 
         * omitting/including notes in the retrieval of information for 
         * allergy/intolerance data.</p><p>Because the attribute is 
         * boolean, it must explicitly indicate a 'TRUE' or 'FALSE', 
         * and thus it is mandatory.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"includeNotesIndicator/value"})]
        public bool? IncludeNotesIndicatorValue {
            get { return this.includeNotesIndicatorValue.Value; }
            set { this.includeNotesIndicatorValue.Value = value; }
        }

        /**
         * <summary>Business Name: ReactionPeriod</summary>
         * 
         * <remarks>Un-merged Business Name: ReactionPeriod 
         * Relationship: REPC_MT000016CA.ReactionPeriod.value 
         * Conformance/Cardinality: MANDATORY (1) <p>The period in 
         * which the recorded adverse reaction occurred or was updated. 
         * I.e. Filters the result-set to those reactions whose onset 
         * occurred within the time-range specified by this 
         * parameter.</p> <p>Allows the requester to specify the 
         * adverse reaction period of interest for retrieval of adverse 
         * reaction records. Useful to avoid run-away queries.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reactionPeriod/value"})]
        public Interval<PlatformDate> ReactionPeriodValue {
            get { return this.reactionPeriodValue.Value; }
            set { this.reactionPeriodValue.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: ReactionType</summary>
         * 
         * <remarks>Relationship: REPC_MT000016CA.ReactionType.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates that the 
         * result set be filtered to include only those 
         * allergy/intolerance records for which specific type of 
         * reaction was recorded.</p><p>Reaction types include: STEVEN 
         * JOHNSON, ANAPHYLAXIS, NAUSEA, etc</p> <p>Indicates that the 
         * result set be filtered to include only those 
         * allergy/intolerance records for which specific type of 
         * reaction was recorded.</p><p>Reaction types include: STEVEN 
         * JOHNSON, ANAPHYLAXIS, NAUSEA, etc</p> <p>Allows the 
         * requester to retrieve only those allergy/intolerance records 
         * for which there was a specific type of reaction.</p> 
         * Un-merged Business Name: Reaction Relationship: 
         * REPC_MT000004CA.ReactionType.value Conformance/Cardinality: 
         * MANDATORY (1) <p>A coded value denoting a specific reaction. 
         * E.g. Code for 'rash'. The result set will be filtered to 
         * include only those allergy records or intolerance records 
         * pertaining to the specified reaction.</p> <p>Allows 
         * allergy/intolerance records to be selectively searched and 
         * retrieved.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reactionType/value"})]
        public SubjectReaction ReactionTypeValue {
            get { return (SubjectReaction) this.reactionTypeValue.Value; }
            set { this.reactionTypeValue.Value = value; }
        }

        /**
         * <summary>Business Name: AmendedInTimeRange</summary>
         * 
         * <remarks>Un-merged Business Name: AmendedInTimeRange 
         * Relationship: PORX_MT060280CA.AmendedInTimeRange.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates that the 
         * returned records should be filtered to only include those 
         * which have been amended in some way (had status changed, 
         * been annotated, prescription was dispensed, etc.) within the 
         * indicated time-period. This will commonly be used to 
         * 'retrieve everything that has been amended since xxx'.</p> 
         * <p>Allows the requester to specify the event period of 
         * interest for the retrieval of medication 
         * records.</p><p>Useful for constraining run-away queries.</p> 
         * <p>Allows the requester to specify the event period of 
         * interest for the retrieval of medication 
         * records.</p><p>Useful for constraining run-away queries.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"amendedInTimeRange/value"})]
        public Interval<PlatformDate> AmendedInTimeRangeValue {
            get { return this.amendedInTimeRangeValue.Value; }
            set { this.amendedInTimeRangeValue.Value = value; }
        }

        /**
         * <summary>Business Name: IncludeEventHistoryIndicator</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * IncludeEventHistoryIndicator Relationship: 
         * PORX_MT060280CA.IncludeEventHistoryIndicator.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates whether 
         * or not history of selected medication records are to be 
         * returned along with the detailed 
         * information.</p><p>&quot;Pending&quot; changes will be 
         * returned regardless of the setting of this flag.</p> 
         * <p>Indicates whether or not history of selected medication 
         * records are to be returned along with the detailed 
         * information.</p><p>&quot;Pending&quot; changes will be 
         * returned regardless of the setting of this flag.</p> 
         * <p>Allows for the flexibility of omitting/including history 
         * in the retrieval of the requested information.</p><p>Because 
         * the attribute is always either 'TRUE' or 'FALSE' it is 
         * mandatory.</p> <p>Allows for the flexibility of 
         * omitting/including history in the retrieval of the requested 
         * information.</p><p>Because the attribute is always either 
         * 'TRUE' or 'FALSE' it is mandatory.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"includeEventHistoryIndicator/value"})]
        public bool? IncludeEventHistoryIndicatorValue {
            get { return this.includeEventHistoryIndicatorValue.Value; }
            set { this.includeEventHistoryIndicatorValue.Value = value; }
        }

        /**
         * <summary>Business Name: IncludeIssuesIndicator</summary>
         * 
         * <remarks>Un-merged Business Name: IncludeIssuesIndicator 
         * Relationship: PORX_MT060280CA.IncludeIssuesIndicator.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates whether 
         * or not issues (detected and/or managed) attached to the 
         * prescriptions, dispenses and other active medication records 
         * are to be returned along with the detailed information.</p> 
         * <p>Allows for the flexibility of omitting/including issues 
         * in the retrieval of medication detail profile 
         * data.</p><p>Because the attribute is boolean, it must 
         * explicitly indicate a 'TRUE' or 'FALSE', and thus it is 
         * mandatory.</p> <p>Allows for the flexibility of 
         * omitting/including issues in the retrieval of medication 
         * detail profile data.</p><p>Because the attribute is boolean, 
         * it must explicitly indicate a 'TRUE' or 'FALSE', and thus it 
         * is mandatory.</p> Un-merged Business Name: 
         * IncludeIssuesIndicator Relationship: 
         * PORX_MT060360CA.IncludeIssuesIndicator.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates whether 
         * or not Issues (detected and/or managed) attached to the 
         * prescription dispense record to be returned along with the 
         * detailed information.</p> <p>Allows for the flexibility of 
         * omitting/including issues in the retrieval of patient 
         * medication data.</p><p>Because the attribute is boolean, it 
         * must explicitly indicate a 'TRUE' or 'FALSE', and thus it is 
         * mandatory.</p> <p>Allows for the flexibility of 
         * omitting/including issues in the retrieval of patient 
         * medication data.</p><p>Because the attribute is boolean, it 
         * must explicitly indicate a 'TRUE' or 'FALSE', and thus it is 
         * mandatory.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"includeIssuesIndicator/value"})]
        public bool? IncludeIssuesIndicatorValue {
            get { return this.includeIssuesIndicatorValue.Value; }
            set { this.includeIssuesIndicatorValue.Value = value; }
        }

        /**
         * <summary>Business Name: IncludePendingChangesIndicator</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * IncludePendingChangesIndicator Relationship: 
         * PORX_MT060280CA.IncludePendingChangesIndicator.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates whether 
         * to include future changes (e.g. status changes that aren't 
         * effective yet) associated with a prescription order and/or 
         * prescription dispense are to be returned along with the 
         * detailed information.</p> <p>Allows for the flexibility of 
         * omitting/including future events in the retrieval of the 
         * requested information.</p><p>Because the attribute is 
         * boolean, it must explicitly indicate a 'TRUE' or 'FALSE', 
         * and thus it is mandatory.</p> <p>Allows for the flexibility 
         * of omitting/including future events in the retrieval of the 
         * requested information.</p><p>Because the attribute is 
         * boolean, it must explicitly indicate a 'TRUE' or 'FALSE', 
         * and thus it is mandatory.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"includePendingChangesIndicator/value"})]
        public bool? IncludePendingChangesIndicatorValue {
            get { return this.includePendingChangesIndicatorValue.Value; }
            set { this.includePendingChangesIndicatorValue.Value = value; }
        }

        /**
         * <summary>Business Name: PrescriptionOrderNumber</summary>
         * 
         * <remarks>Un-merged Business Name: PrescriptionOrderNumber 
         * Relationship: PORX_MT060280CA.PrescriptionOrderNumber.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Identifier of the 
         * prescription for which detailed information is 
         * required.</p><p>The result set will be filtered to only the 
         * specific prescription.</p> <p>Identifier of the prescription 
         * for which detailed information is required.</p><p>The result 
         * set will be filtered to only the specific prescription.</p> 
         * <p>Identifies the prescription that is to be retrieved, and 
         * is therefore mandatory.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"prescriptionOrderNumber/value"})]
        public Identifier PrescriptionOrderNumberValue {
            get { return this.prescriptionOrderNumberValue.Value; }
            set { this.prescriptionOrderNumberValue.Value = value; }
        }

        /**
         * <summary>Business Name: AllergyIntoleranceStatus</summary>
         * 
         * <remarks>Un-merged Business Name: AllergyIntoleranceStatus 
         * Relationship: REPC_MT000004CA.AllergyIntoleranceStatus.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates that the 
         * result set should be filtered to include only those 
         * allergy/intolerance records for the specified status. Valid 
         * statuses include: ACTIVE or COMPLETE.</p> <p>Allows for the 
         * selective retrieval of allergy/intolerance records based on 
         * the status of the record.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"allergyIntoleranceStatus/value"})]
        public ActStatus AllergyIntoleranceStatusValue {
            get { return (ActStatus) this.allergyIntoleranceStatusValue.Value; }
            set { this.allergyIntoleranceStatusValue.Value = value; }
        }

        /**
         * <summary>Business Name: AllergyIntoleranceType</summary>
         * 
         * <remarks>Un-merged Business Name: AllergyIntoleranceType 
         * Relationship: REPC_MT000004CA.AllergyIntoleranceType.value 
         * Conformance/Cardinality: MANDATORY (1) <p>A coded value 
         * indicating whether to return an allergy record or an 
         * intolerance record. The result set will be filtered to 
         * include only allergy records or intolerance records 
         * accordingly.</p> <p>Allows allergy/intolerance records to be 
         * selectively searched and retrieved.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"allergyIntoleranceType/value"})]
        public ObservationIntoleranceType AllergyIntoleranceTypeValue {
            get { return (ObservationIntoleranceType) this.allergyIntoleranceTypeValue.Value; }
            set { this.allergyIntoleranceTypeValue.Value = value; }
        }

        /**
         * <summary>Business Name: AllergyIntoleranceChangePeriod</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * AllergyIntoleranceChangePeriod Relationship: 
         * REPC_MT000004CA.AlllergyIntoleranceChangePeriod.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Filters the query 
         * response to only include allergy/intolerance records which 
         * have been created or modified within the date-range 
         * specified.</p> <p>Useful in retrieving incremental changes 
         * to the patient's record.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"alllergyIntoleranceChangePeriod/value"})]
        public Interval<PlatformDate> AlllergyIntoleranceChangePeriodValue {
            get { return this.alllergyIntoleranceChangePeriodValue.Value; }
            set { this.alllergyIntoleranceChangePeriodValue.Value = value; }
        }

        /**
         * <summary>Business Name: PrescriptionDispenseNumber</summary>
         * 
         * <remarks>Un-merged Business Name: PrescriptionDispenseNumber 
         * Relationship: 
         * PORX_MT060360CA.PrescriptionDispenseNumber.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Identifies which 
         * prescription dispense record should be retrieved.</p> 
         * <p>Allows for the retrieval of medication records relating 
         * to a specific dispense record. A dispense cannot be 
         * retrieved without the identifier of the record, and the 
         * attribute is therefore mandatory.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"prescriptionDispenseNumber/value"})]
        public Identifier PrescriptionDispenseNumberValue {
            get { return this.prescriptionDispenseNumberValue.Value; }
            set { this.prescriptionDispenseNumberValue.Value = value; }
        }

    }

}