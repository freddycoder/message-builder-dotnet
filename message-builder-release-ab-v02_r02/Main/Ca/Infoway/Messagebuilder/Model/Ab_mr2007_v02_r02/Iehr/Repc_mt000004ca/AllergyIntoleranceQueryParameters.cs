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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Iehr.Repc_mt000004ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Allergy/Intolerance Query Parameters</summary>
     * 
     * <p>Defines the set of parameters that may be used to filter 
     * the query response</p> <p>Root class for query 
     * definition</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT000004CA.ParameterList"})]
    public class AllergyIntoleranceQueryParameters : MessagePartBean {

        private CV allergyIntoleranceStatusValue;
        private CD allergyIntoleranceTypeValue;
        private IVL<TS, Interval<PlatformDate>> alllergyIntoleranceChangePeriodValue;
        private IList<II> careCompositionIDValue;
        private IList<CV> careCompositionTypeValue;
        private BL includeNotesIndicatorValue;
        private CV reactionTypeValue;

        public AllergyIntoleranceQueryParameters() {
            this.allergyIntoleranceStatusValue = new CVImpl();
            this.allergyIntoleranceTypeValue = new CDImpl();
            this.alllergyIntoleranceChangePeriodValue = new IVLImpl<TS, Interval<PlatformDate>>();
            this.careCompositionIDValue = new List<II>();
            this.careCompositionTypeValue = new List<CV>();
            this.includeNotesIndicatorValue = new BLImpl();
            this.reactionTypeValue = new CVImpl();
        }
        /**
         * <summary>Business Name: G:Allergy/Intolerance Status</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000004CA.AllergyIntoleranceStatus.value 
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
         * <summary>Business Name: H:Allergy/Intolerance Type</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000004CA.AllergyIntoleranceType.value 
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
         * <summary>Business Name: F:Allergy/Intolerance Change Period</summary>
         * 
         * <remarks>Relationship: 
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
         * <summary>Business Name: Care Composition IDs</summary>
         * 
         * <remarks>Relationship: 
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
         * <summary>Business Name: Care Composition Types</summary>
         * 
         * <remarks>Relationship: 
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
         * <summary>Business Name: Include Notes Indicator</summary>
         * 
         * <remarks>Relationship: 
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
         * <summary>Business Name: I:Reaction</summary>
         * 
         * <remarks>Relationship: REPC_MT000004CA.ReactionType.value 
         * Conformance/Cardinality: MANDATORY (1) <p>A coded value 
         * denoting a specific reaction. E.g. Code for 'rash'. The 
         * result set will be filtered to include only those allergy 
         * records or intolerance records pertaining to the specified 
         * reaction.</p> <p>Allows allergy/intolerance records to be 
         * selectively searched and retrieved.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reactionType/value"})]
        public SubjectReaction ReactionTypeValue {
            get { return (SubjectReaction) this.reactionTypeValue.Value; }
            set { this.reactionTypeValue.Value = value; }
        }

    }

}