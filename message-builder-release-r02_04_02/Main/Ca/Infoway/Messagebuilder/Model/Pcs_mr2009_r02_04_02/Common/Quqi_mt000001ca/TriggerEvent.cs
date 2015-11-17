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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Quqi_mt000001ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: Trigger Event</summary>
     * 
     * <p>Key to understanding what action a message 
     * represents.</p> <p>There may be constraints on the usage of 
     * the effectiveTime and reasonCode attributes in the 
     * definition of the interaction or the trigger events which 
     * are conveyed with this wrapper.</p> <p>Identifies the action 
     * that resulted in this message being sent.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"QUQI_MT000001CA.ControlActEvent"})]
    public class TriggerEvent : MessagePartBean {

        private II id;
        private CV code;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private CV reasonCode;
        private CE languageCode;
        private II queryContinuationQueryId;
        private INT queryContinuationStartResultNumber;
        private INT queryContinuationContinuationQuantity;

        public TriggerEvent() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.reasonCode = new CVImpl();
            this.languageCode = new CEImpl();
            this.queryContinuationQueryId = new IIImpl();
            this.queryContinuationStartResultNumber = new INTImpl();
            this.queryContinuationContinuationQuantity = new INTImpl();
        }
        /**
         * <summary>Business Name: B:Event Identifier</summary>
         * 
         * <remarks>Relationship: QUQI_MT000001CA.ControlActEvent.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows the event 
         * to be referenced (for undos) and also indicates whether 
         * multiple interactions were caused by the same triggering 
         * event. Also used for audit purposes.</p> <p>Identifier needs 
         * to be persisted by receiving applications, except for 
         * queries (queries cannot be retracted or undone).</p> <p>A 
         * unique identifier for this particular event assigned by the 
         * system in which the event occurred.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: A:Event Type</summary>
         * 
         * <remarks>Relationship: QUQI_MT000001CA.ControlActEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>This is mandatory 
         * because it is essential to understanding the meaning of the 
         * event.</p> <p>Identifies the trigger event that 
         * occurred.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public HL7TriggerEventCode Code {
            get { return (HL7TriggerEventCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: C:Event Effective Period</summary>
         * 
         * <remarks>Relationship: 
         * QUQI_MT000001CA.ControlActEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The time an event 
         * becomes effective may differ from the time the event is 
         * recorded (i.e. it may be in the future or the past). For 
         * events such as 'suspend', an intended end date may also be 
         * indicated.</p> <p>Indicates the time the event (e.g. query, 
         * change, activation) should begin and occasionally when it 
         * should end.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: E:Event Reason</summary>
         * 
         * <remarks>Relationship: 
         * QUQI_MT000001CA.ControlActEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows 
         * identifying a reason for a specific action, such as 'reason 
         * for hold' or 'reason for accessing information'.</p> <p>The 
         * domain associated with this attribute will vary for each 
         * interaction and will be noted as part of the interaction 
         * description.</p> <p>Identifies why this specific message 
         * interaction (e.g. query, activation request, modification 
         * request) occurred.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reasonCode"})]
        public ControlActReason ReasonCode {
            get { return (ControlActReason) this.reasonCode.Value; }
            set { this.reasonCode.Value = value; }
        }

        /**
         * <summary>Business Name: Message Language</summary>
         * 
         * <remarks>Relationship: 
         * QUQI_MT000001CA.ControlActEvent.languageCode 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"languageCode"})]
        public HumanLanguage LanguageCode {
            get { return (HumanLanguage) this.languageCode.Value; }
            set { this.languageCode.Value = value; }
        }

        /**
         * <summary>Business Name: H:Query Identifier</summary>
         * 
         * <remarks>Relationship: 
         * QUQI_MT000001CA.QueryContinuation.queryId 
         * Conformance/Cardinality: MANDATORY (1) <p>Links to the query 
         * for which continuation is desired. Needed to ensure that the 
         * query is not re-executed, as the results may have changed. 
         * As a result, the attribute is mandatory.</p> <p>Unique 
         * number for the query to be continued.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"queryContinuation/queryId"})]
        public Identifier QueryContinuationQueryId {
            get { return this.queryContinuationQueryId.Value; }
            set { this.queryContinuationQueryId.Value = value; }
        }

        /**
         * <summary>Business Name: I:Start Position</summary>
         * 
         * <remarks>Relationship: 
         * QUQI_MT000001CA.QueryContinuation.startResultNumber 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates what 
         * point the query should continue from and is therefore 
         * mandatory.</p> <p>Indicates the record number at which to 
         * start the returned result set.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"queryContinuation/startResultNumber"})]
        public int? QueryContinuationStartResultNumber {
            get { return this.queryContinuationStartResultNumber.Value; }
            set { this.queryContinuationStartResultNumber.Value = value; }
        }

        /**
         * <summary>Business Name: J:Query Limit</summary>
         * 
         * <remarks>Relationship: 
         * QUQI_MT000001CA.QueryContinuation.continuationQuantity 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows an 
         * application to control the number of returned records. If 
         * not specified, the EHR may apply a default limit.</p> 
         * <p>Indicates how many records should be returned for this 
         * query.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"queryContinuation/continuationQuantity"})]
        public int? QueryContinuationContinuationQuantity {
            get { return this.queryContinuationContinuationQuantity.Value; }
            set { this.queryContinuationContinuationQuantity.Value = value; }
        }

    }

}