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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: TriggerEvent</summary>
     * 
     * <remarks>MCAI_MT700230CA.ControlActEvent: Trigger Event 
     * <p>Key to understanding what action a message 
     * represents.</p> <p>There may be constraints on the usage of 
     * the effectiveTime and reasonCode attributes in the 
     * definition of the interaction or the trigger events which 
     * are conveyed with this wrapper.</p> <p>Identifies the action 
     * that resulted in this message being sent.</p> 
     * MCAI_MT700237CA.ControlActEvent: Trigger Event <p>Key to 
     * understanding what action a message represents.</p> <p>There 
     * may be constraints on the usage of the effectiveTime and 
     * reasonCode attributes in the definition of the interaction 
     * or the trigger events which are conveyed with this 
     * wrapper.</p> <p>Identifies the action that resulted in this 
     * message being sent.</p> MCAI_MT700232CA.ControlActEvent: 
     * Trigger Event <p>Key to understanding what action a message 
     * represents.</p> <p>There may be constraints on the usage of 
     * the effectiveTime and reasonCode attributes in the 
     * definition of the interaction or the trigger events which 
     * are conveyed with this wrapper.</p> <p>Identifies the action 
     * that resulted in this message being sent.</p> 
     * MCAI_MT700231CA.ControlActEvent: Trigger Event <p>Key to 
     * understanding what action a message represents.</p> <p>There 
     * may be constraints on the usage of the effectiveTime and 
     * reasonCode attributes in the definition of the interaction 
     * or the trigger events which are conveyed with this 
     * wrapper.</p> <p>Identifies the action that resulted in this 
     * message being sent.</p> MCAI_MT700236CA.ControlActEvent: 
     * Trigger Event <p>Key to understanding what action a message 
     * represents.</p> <p>There may be constraints on the usage of 
     * the effectiveTime and reasonCode attributes in the 
     * definition of the interaction or the trigger events which 
     * are conveyed with this wrapper.</p> <p>Identifies the action 
     * that resulted in this message being sent.</p> 
     * QUQI_MT000001CA.ControlActEvent: Trigger Event <p>Key to 
     * understanding what action a message represents.</p> <p>There 
     * may be constraints on the usage of the effectiveTime and 
     * reasonCode attributes in the definition of the interaction 
     * or the trigger events which are conveyed with this 
     * wrapper.</p> <p>Identifies the action that resulted in this 
     * message being sent.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"MCAI_MT700230CA.ControlActEvent","MCAI_MT700231CA.ControlActEvent","MCAI_MT700232CA.ControlActEvent","MCAI_MT700236CA.ControlActEvent","MCAI_MT700237CA.ControlActEvent","QUQI_MT000001CA.ControlActEvent"})]
    public class TriggerEvent_2 : MessagePartBean {

        private II id;
        private CV code;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private CV reasonCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Merged.IPatient_2 recordTargetPatient1;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Merged.HealthcareWorker responsiblePartyAssignedEntity;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Merged.CreatedBy_1 author;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Merged.IActingPerson dataEntererActingPerson;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Merged.ServiceLocation dataEntryLocationServiceDeliveryLocation;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Merged.CreatedAt location;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Merged.AuthenticationToken pertinentInformationAuthorizationToken;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Merged.Issues> subjectOfDetectedIssueEvent;
        private CS recordTargetTypeCode;
        private II queryContinuationQueryId;
        private INT queryContinuationStartResultNumber;
        private INT queryContinuationContinuationQuantity;

        public TriggerEvent_2() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.reasonCode = new CVImpl();
            this.subjectOfDetectedIssueEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Merged.Issues>();
            this.recordTargetTypeCode = new CSImpl();
            this.queryContinuationQueryId = new IIImpl();
            this.queryContinuationStartResultNumber = new INTImpl();
            this.queryContinuationContinuationQuantity = new INTImpl();
        }
        /**
         * <summary>Business Name: EventIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: EventIdentifier 
         * Relationship: MCAI_MT700230CA.ControlActEvent.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows the event 
         * to be referenced (for undos) and also indicates whether 
         * multiple interactions were caused by the same triggering 
         * event. Also used for audit purposes.</p> <p>Identifier needs 
         * to be persisted by receiving applications, except for 
         * queries (queries cannot be retracted or undone).</p> <p>A 
         * unique identifier for this particular event assigned by the 
         * system in which the event occurred.</p> Un-merged Business 
         * Name: EventIdentifier Relationship: 
         * MCAI_MT700237CA.ControlActEvent.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Allows the event to be referenced (for 
         * undos) and also indicates whether multiple interactions were 
         * caused by the same triggering event. Also used for audit 
         * purposes.</p> <p>Identifier needs to be persisted by 
         * receiving applications, except for queries (queries cannot 
         * be retracted or undone).</p> <p>A unique identifier for this 
         * particular event assigned by the system in which the event 
         * occurred.</p> Un-merged Business Name: EventIdentifier 
         * Relationship: MCAI_MT700232CA.ControlActEvent.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows the event 
         * to be referenced (for undos) and also indicates whether 
         * multiple interactions were caused by the same triggering 
         * event. Also used for audit purposes.</p> <p>Identifier needs 
         * to be persisted by receiving applications, except for 
         * queries (queries cannot be retracted or undone).</p> <p>A 
         * unique identifier for this particular event assigned by the 
         * system in which the event occurred.</p> Un-merged Business 
         * Name: EventIdentifier Relationship: 
         * MCAI_MT700231CA.ControlActEvent.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Allows the event to be referenced (for 
         * undos) and also indicates whether multiple interactions were 
         * caused by the same triggering event. Also used for audit 
         * purposes.</p> <p>Identifier needs to be persisted by 
         * receiving applications, except for queries (queries cannot 
         * be retracted or undone).</p> <p>A unique identifier for this 
         * particular event assigned by the system in which the event 
         * occurred.</p> Un-merged Business Name: EventIdentifier 
         * Relationship: MCAI_MT700236CA.ControlActEvent.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows the event 
         * to be referenced (for undos) and also indicates whether 
         * multiple interactions were caused by the same triggering 
         * event. Also used for audit purposes.</p> <p>Identifier needs 
         * to be persisted by receiving applications, except for 
         * queries (queries cannot be retracted or undone).</p> <p>A 
         * unique identifier for this particular event assigned by the 
         * system in which the event occurred.</p> Un-merged Business 
         * Name: EventIdentifier Relationship: 
         * QUQI_MT000001CA.ControlActEvent.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Allows the event to be referenced (for 
         * undos) and also indicates whether multiple interactions were 
         * caused by the same triggering event. Also used for audit 
         * purposes.</p> <p>Identifier needs to be persisted by 
         * receiving applications, except for queries (queries cannot 
         * be retracted or undone).</p> <p>A unique identifier for this 
         * particular event assigned by the system in which the event 
         * occurred.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: EventType</summary>
         * 
         * <remarks>Un-merged Business Name: EventType Relationship: 
         * MCAI_MT700230CA.ControlActEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>This is mandatory 
         * because it is essential to understanding the meaning of the 
         * event.</p> <p>Identifies the trigger event that 
         * occurred.</p> Un-merged Business Name: EventType 
         * Relationship: MCAI_MT700237CA.ControlActEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>This is mandatory 
         * because it is essential to understanding the meaning of the 
         * event.</p> <p>Identifies the trigger event that 
         * occurred.</p> Un-merged Business Name: EventType 
         * Relationship: MCAI_MT700232CA.ControlActEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>This is mandatory 
         * because it is essential to understanding the meaning of the 
         * event.</p> <p>Identifies the trigger event that 
         * occurred.</p> Un-merged Business Name: EventType 
         * Relationship: MCAI_MT700231CA.ControlActEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>This is mandatory 
         * because it is essential to understanding the meaning of the 
         * event.</p> <p>Identifies the trigger event that 
         * occurred.</p> Un-merged Business Name: EventType 
         * Relationship: MCAI_MT700236CA.ControlActEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>This is mandatory 
         * because it is essential to understanding the meaning of the 
         * event.</p> <p>Identifies the trigger event that 
         * occurred.</p> Un-merged Business Name: EventType 
         * Relationship: QUQI_MT000001CA.ControlActEvent.code 
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
         * <summary>Business Name: EventEffectivePeriod</summary>
         * 
         * <remarks>Un-merged Business Name: EventEffectivePeriod 
         * Relationship: MCAI_MT700230CA.ControlActEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The time an event 
         * becomes effective may differ from the time the event is 
         * recorded (i.e. it may be in the future or the past). For 
         * events such as 'suspend', an intended end date may also be 
         * indicated.</p> <p>Indicates the time the event (e.g. query, 
         * change, activation) should begin and occasionally when it 
         * should end.</p> Un-merged Business Name: 
         * EventEffectivePeriod Relationship: 
         * MCAI_MT700237CA.ControlActEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The time an event 
         * becomes effective may differ from the time the event is 
         * recorded (i.e. it may be in the future or the past). For 
         * events such as 'suspend', an intended end date may also be 
         * indicated.</p> <p>Indicates the time the event (e.g. query, 
         * change, activation) should begin and occasionally when it 
         * should end.</p> Un-merged Business Name: 
         * EventEffectivePeriod Relationship: 
         * MCAI_MT700232CA.ControlActEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The time an event 
         * becomes effective may differ from the time the event is 
         * recorded (i.e. it may be in the future or the past). For 
         * events such as 'suspend', an intended end date may also be 
         * indicated.</p> <p>Indicates the time the event (e.g. query, 
         * change, activation) should begin and occasionally when it 
         * should end.</p> Un-merged Business Name: 
         * EventEffectivePeriod Relationship: 
         * MCAI_MT700231CA.ControlActEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The time an event 
         * becomes effective may differ from the time the event is 
         * recorded (i.e. it may be in the future or the past). For 
         * events such as 'suspend', an intended end date may also be 
         * indicated.</p> <p>Indicates the time the event (e.g. query, 
         * change, activation) should begin and occasionally when it 
         * should end.</p> Un-merged Business Name: 
         * EventEffectivePeriod Relationship: 
         * MCAI_MT700236CA.ControlActEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The time an event 
         * becomes effective may differ from the time the event is 
         * recorded (i.e. it may be in the future or the past). For 
         * events such as 'suspend', an intended end date may also be 
         * indicated.</p> <p>Indicates the time the event (e.g. query, 
         * change, activation) should begin and occasionally when it 
         * should end.</p> Un-merged Business Name: 
         * EventEffectivePeriod Relationship: 
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
         * <summary>Business Name: EventReason</summary>
         * 
         * <remarks>Un-merged Business Name: EventReason Relationship: 
         * MCAI_MT700230CA.ControlActEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows 
         * identifying a reason for a specific action, such as 'reason 
         * for hold' or 'reason for accessing information'.</p> <p>The 
         * domain associated with this attribute will vary for each 
         * interaction and will be noted as part of the interaction 
         * description.</p> <p>Identifies why this specific message 
         * interaction (e.g. query, activation request, modification 
         * request) occurred.</p> Un-merged Business Name: EventReason 
         * Relationship: MCAI_MT700237CA.ControlActEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows 
         * identifying a reason for a specific action, such as 'reason 
         * for hold' or 'reason for accessing information'.</p> <p>The 
         * domain associated with this attribute will vary for each 
         * interaction and will be noted as part of the interaction 
         * description.</p> <p>Identifies why this specific message 
         * interaction (e.g. query, activation request, modification 
         * request) occurred.</p> Un-merged Business Name: EventReason 
         * Relationship: MCAI_MT700232CA.ControlActEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows 
         * identifying a reason for a specific action, such as 'reason 
         * for hold' or 'reason for accessing information'.</p> <p>The 
         * domain associated with this attribute will vary for each 
         * interaction and will be noted as part of the interaction 
         * description.</p> <p>Identifies why this specific message 
         * interaction (e.g. query, activation request, modification 
         * request) occurred.</p> Un-merged Business Name: EventReason 
         * Relationship: MCAI_MT700231CA.ControlActEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows 
         * identifying a reason for a specific action, such as 'reason 
         * for hold' or 'reason for accessing information'.</p> <p>The 
         * domain associated with this attribute will vary for each 
         * interaction and will be noted as part of the interaction 
         * description.</p> <p>Identifies why this specific message 
         * interaction (e.g. query, activation request, modification 
         * request) occurred.</p> Un-merged Business Name: EventReason 
         * Relationship: MCAI_MT700236CA.ControlActEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows 
         * identifying a reason for a specific action, such as 'reason 
         * for hold' or 'reason for accessing information'.</p> <p>The 
         * domain associated with this attribute will vary for each 
         * interaction and will be noted as part of the interaction 
         * description.</p> <p>Identifies why this specific message 
         * interaction (e.g. query, activation request, modification 
         * request) occurred.</p> Un-merged Business Name: EventReason 
         * Relationship: QUQI_MT000001CA.ControlActEvent.reasonCode 
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
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: MCAI_MT700230CA.RecordTarget.patient1 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700237CA.RecordTarget.patient1 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700231CA.RecordTarget.patient1 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700236CA.RecordTarget.patient1 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"recordTarget/patient1"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Merged.IPatient_2 RecordTargetPatient1 {
            get { return this.recordTargetPatient1; }
            set { this.recordTargetPatient1 = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * MCAI_MT700230CA.ResponsibleParty.assignedEntity 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700232CA.ResponsibleParty.assignedEntity 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700231CA.ResponsibleParty.assignedEntity 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Merged.HealthcareWorker ResponsiblePartyAssignedEntity {
            get { return this.responsiblePartyAssignedEntity; }
            set { this.responsiblePartyAssignedEntity = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * MCAI_MT700230CA.ControlActEvent.author 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700232CA.ControlActEvent.author 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700231CA.ControlActEvent.author 
         * Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Merged.CreatedBy_1 Author {
            get { return this.author; }
            set { this.author = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * MCAI_MT700230CA.DataEnterer.actingPerson 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700232CA.DataEnterer.actingPerson 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700231CA.DataEnterer.actingPerson 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"dataEnterer/actingPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Merged.IActingPerson DataEntererActingPerson {
            get { return this.dataEntererActingPerson; }
            set { this.dataEntererActingPerson = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * MCAI_MT700230CA.DataEntryLocation.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700232CA.DataEntryLocation.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700231CA.DataEntryLocation.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"dataEntryLocation/serviceDeliveryLocation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Merged.ServiceLocation DataEntryLocationServiceDeliveryLocation {
            get { return this.dataEntryLocationServiceDeliveryLocation; }
            set { this.dataEntryLocationServiceDeliveryLocation = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * MCAI_MT700230CA.ControlActEvent.location 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700232CA.ControlActEvent.location 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700231CA.ControlActEvent.location 
         * Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Merged.CreatedAt Location {
            get { return this.location; }
            set { this.location = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * MCAI_MT700230CA.PertinentInformation.authorizationToken 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700232CA.PertinentInformation.authorizationToken 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700231CA.PertinentInformation.authorizationToken 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"pertinentInformation/authorizationToken"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Merged.AuthenticationToken PertinentInformationAuthorizationToken {
            get { return this.pertinentInformationAuthorizationToken; }
            set { this.pertinentInformationAuthorizationToken = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * MCAI_MT700230CA.Subject.detectedIssueEvent 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700237CA.Subject.detectedIssueEvent 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700232CA.Subject.detectedIssueEvent 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700231CA.Subject.detectedIssueEvent 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700236CA.Subject.detectedIssueEvent 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf/detectedIssueEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Merged.Issues> SubjectOfDetectedIssueEvent {
            get { return this.subjectOfDetectedIssueEvent; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: MCAI_MT700237CA.RecordTarget.typeCode 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700236CA.RecordTarget.typeCode 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"recordTarget/typeCode"})]
        public ParticipationType RecordTargetTypeCode {
            get { return (ParticipationType) this.recordTargetTypeCode.Value; }
            set { this.recordTargetTypeCode.Value = value; }
        }

        /**
         * <summary>Business Name: QueryIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: QueryIdentifier 
         * Relationship: QUQI_MT000001CA.QueryContinuation.queryId 
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
         * <summary>Business Name: StartPosition</summary>
         * 
         * <remarks>Un-merged Business Name: StartPosition 
         * Relationship: 
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
         * <summary>Business Name: QueryLimit</summary>
         * 
         * <remarks>Un-merged Business Name: QueryLimit Relationship: 
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