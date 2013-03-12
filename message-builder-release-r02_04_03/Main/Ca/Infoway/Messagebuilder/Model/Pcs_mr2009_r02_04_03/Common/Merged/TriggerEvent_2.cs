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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090102ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt240002ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: TriggerEvent</summary>
     * 
     * <remarks>MCAI_MT700228CA.ControlActEvent: Trigger Event 
     * <p>Key to understanding what action a message 
     * represents.</p> <p>There may be constraints on the usage of 
     * the effectiveTime and reasonCode attributes in the 
     * definition of the interaction or the trigger events which 
     * are conveyed with this wrapper.</p> <p>Identifies the action 
     * that resulted in this message being sent.</p> 
     * MCAI_MT700227CA.ControlActEvent: Trigger Event <p>Key to 
     * understanding what action a message represents.</p> <p>There 
     * may be constraints on the usage of the effectiveTime and 
     * reasonCode attributes in the definition of the interaction 
     * or the trigger events which are conveyed with this 
     * wrapper.</p> <p>Identifies the action that resulted in this 
     * message being sent.</p> MCAI_MT700222CA.ControlActEvent: 
     * Trigger Event <p>Key to understanding what action a message 
     * represents.</p> <p>There may be constraints on the usage of 
     * the effectiveTime and reasonCode attributes in the 
     * definition of the interaction or the trigger events which 
     * are conveyed with this wrapper.</p> <p>Identifies the action 
     * that resulted in this message being sent.</p> 
     * MCAI_MT700226CA.ControlActEvent: Trigger Event <p>Key to 
     * understanding what action a message represents.</p> <p>There 
     * may be constraints on the usage of the effectiveTime and 
     * reasonCode attributes in the definition of the interaction 
     * or the trigger events which are conveyed with this 
     * wrapper.</p> <p>Identifies the action that resulted in this 
     * message being sent.</p> MCAI_MT700221CA.ControlActEvent: 
     * Trigger Event <p>Key to understanding what action a message 
     * represents.</p> <p>There may be constraints on the usage of 
     * the effectiveTime and reasonCode attributes in the 
     * definition of the interaction or the trigger events which 
     * are conveyed with this wrapper.</p> <p>Identifies the action 
     * that resulted in this message being sent.</p> 
     * MCAI_MT700220CA.ControlActEvent: Trigger Event <p>Key to 
     * understanding what action a message represents.</p> <p>There 
     * may be constraints on the usage of the effectiveTime and 
     * reasonCode attributes in the definition of the interaction 
     * or the trigger events which are conveyed with this 
     * wrapper.</p> <p>Identifies the action that resulted in this 
     * message being sent.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"MCAI_MT700220CA.ControlActEvent","MCAI_MT700221CA.ControlActEvent","MCAI_MT700222CA.ControlActEvent","MCAI_MT700226CA.ControlActEvent","MCAI_MT700227CA.ControlActEvent","MCAI_MT700228CA.ControlActEvent"})]
    public class TriggerEvent_2<ACT> : MessagePartBean {

        private II id;
        private CV code;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private CV reasonCode;
        private CE languageCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.RefersTo_1<ACT> subject;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.Issues> subjectOfDetectedIssueEvent;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.IPatient recordTargetPatient1;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090102ca.HealthcareWorker responsiblePartyAssignedEntity;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.CreatedBy_1 author;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.IActingPerson dataEntererActingPerson;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt240002ca.ServiceLocation dataEntryLocationServiceDeliveryLocation;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt240002ca.ServiceLocation locationServiceDeliveryLocation;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.AuthenticationToken pertinentInformationAuthorizationToken;

        public TriggerEvent_2() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.reasonCode = new CVImpl();
            this.languageCode = new CEImpl();
            this.subjectOfDetectedIssueEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.Issues>();
        }
        /**
         * <summary>Business Name: EventIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: EventIdentifier 
         * Relationship: MCAI_MT700228CA.ControlActEvent.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows the event 
         * to be referenced (for undos) and also indicates whether 
         * multiple interactions were caused by the same triggering 
         * event. Also used for audit purposes.</p> <p>Identifier needs 
         * to be persisted by receiving applications, except for 
         * queries (queries cannot be retracted or undone). The 
         * identifier must be unique and different from the event 
         * identifier that is present on the request - it must be 
         * generated by the responding application.</p> <p>A unique 
         * identifier for this particular event assigned by the system 
         * in which the event occurred.</p> Un-merged Business Name: 
         * EventIdentifier Relationship: 
         * MCAI_MT700227CA.ControlActEvent.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Allows the event to be referenced (for 
         * undos) and also indicates whether multiple interactions were 
         * caused by the same triggering event. Also used for audit 
         * purposes.</p> <p>Identifier needs to be persisted by 
         * receiving applications, except for queries (queries cannot 
         * be retracted or undone). The identifier must be unique and 
         * different from the event identifier that is present on the 
         * request - it must be generated by the responding 
         * application.</p> <p>A unique identifier for this particular 
         * event assigned by the system in which the event 
         * occurred.</p> Un-merged Business Name: EventIdentifier 
         * Relationship: MCAI_MT700222CA.ControlActEvent.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows the event 
         * to be referenced (for undos) and also indicates whether 
         * multiple interactions were caused by the same triggering 
         * event. Also used for audit purposes.</p> <p>Identifier needs 
         * to be persisted by receiving applications, except for 
         * queries (queries cannot be retracted or undone). The 
         * identifier must be unique and different from the event 
         * identifier that is present on the request - it must be 
         * generated by the responding application.</p> <p>A unique 
         * identifier for this particular event assigned by the system 
         * in which the event occurred.</p> Un-merged Business Name: 
         * EventIdentifier Relationship: 
         * MCAI_MT700221CA.ControlActEvent.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Allows the event to be referenced (for 
         * undos) and also indicates whether multiple interactions were 
         * caused by the same triggering event. Also used for audit 
         * purposes.</p> <p>Identifier needs to be persisted by 
         * receiving applications, except for queries (queries cannot 
         * be retracted or undone). The identifier must be unique and 
         * different from the event identifier that is present on the 
         * request - it must be generated by the responding 
         * application.</p> <p>A unique identifier for this particular 
         * event assigned by the system in which the event 
         * occurred.</p> Un-merged Business Name: EventIdentifier 
         * Relationship: MCAI_MT700226CA.ControlActEvent.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows the event 
         * to be referenced (for undos) and also indicates whether 
         * multiple interactions were caused by the same triggering 
         * event. Also used for audit purposes.</p> <p>Identifier needs 
         * to be persisted by receiving applications, except for 
         * queries (queries cannot be retracted or undone). The 
         * identifier must be unique and different from the event 
         * identifier that is present on the request - it must be 
         * generated by the responding application.</p> <p>A unique 
         * identifier for this particular event assigned by the system 
         * in which the event occurred.</p> Un-merged Business Name: 
         * EventIdentifier Relationship: 
         * MCAI_MT700220CA.ControlActEvent.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Allows the event to be referenced (for 
         * undos) and also indicates whether multiple interactions were 
         * caused by the same triggering event. Also used for audit 
         * purposes.</p> <p>Identifier needs to be persisted by 
         * receiving applications, except for queries (queries cannot 
         * be retracted or undone). The identifier must be unique and 
         * different from the event identifier that is present on the 
         * request - it must be generated by the responding 
         * application.</p> <p>A unique identifier for this particular 
         * event assigned by the system in which the event 
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
         * MCAI_MT700228CA.ControlActEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>This is mandatory 
         * because it is essential to understanding the meaning of the 
         * event.</p> <p>Identifies the trigger event that 
         * occurred.</p> Un-merged Business Name: EventType 
         * Relationship: MCAI_MT700227CA.ControlActEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>This is mandatory 
         * because it is essential to understanding the meaning of the 
         * event.</p> <p>Identifies the trigger event that 
         * occurred.</p> Un-merged Business Name: EventType 
         * Relationship: MCAI_MT700222CA.ControlActEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>This is mandatory 
         * because it is essential to understanding the meaning of the 
         * event.</p> <p>Identifies the trigger event that 
         * occurred.</p> Un-merged Business Name: EventType 
         * Relationship: MCAI_MT700221CA.ControlActEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>This is mandatory 
         * because it is essential to understanding the meaning of the 
         * event.</p> <p>Identifies the trigger event that 
         * occurred.</p> Un-merged Business Name: EventType 
         * Relationship: MCAI_MT700226CA.ControlActEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>This is mandatory 
         * because it is essential to understanding the meaning of the 
         * event.</p> <p>Identifies the trigger event that 
         * occurred.</p> Un-merged Business Name: EventType 
         * Relationship: MCAI_MT700220CA.ControlActEvent.code 
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
         * Relationship: MCAI_MT700228CA.ControlActEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The time an event 
         * becomes effective may differ from the time the event is 
         * recorded (i.e. it may be in the future or the past). For 
         * events such as 'suspend', an intended end date may also be 
         * indicated.</p> <p>Indicates the time the event (e.g. query, 
         * change, activation) should begin and occasionally when it 
         * should end.</p> Un-merged Business Name: 
         * EventEffectivePeriod Relationship: 
         * MCAI_MT700227CA.ControlActEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The time an event 
         * becomes effective may differ from the time the event is 
         * recorded (i.e. it may be in the future or the past). For 
         * events such as 'suspend', an intended end date may also be 
         * indicated.</p> <p>Indicates the time the event (e.g. query, 
         * change, activation) should begin and occasionally when it 
         * should end.</p> Un-merged Business Name: 
         * EventEffectivePeriod Relationship: 
         * MCAI_MT700222CA.ControlActEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The time an event 
         * becomes effective may differ from the time the event is 
         * recorded (i.e. it may be in the future or the past). For 
         * events such as 'suspend', an intended end date may also be 
         * indicated.</p> <p>Indicates the time the event (e.g. query, 
         * change, activation) should begin and occasionally when it 
         * should end.</p> Un-merged Business Name: 
         * EventEffectivePeriod Relationship: 
         * MCAI_MT700221CA.ControlActEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The time an event 
         * becomes effective may differ from the time the event is 
         * recorded (i.e. it may be in the future or the past). For 
         * events such as 'suspend', an intended end date may also be 
         * indicated.</p> <p>Indicates the time the event (e.g. query, 
         * change, activation) should begin and occasionally when it 
         * should end.</p> Un-merged Business Name: 
         * EventEffectivePeriod Relationship: 
         * MCAI_MT700226CA.ControlActEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The time an event 
         * becomes effective may differ from the time the event is 
         * recorded (i.e. it may be in the future or the past). For 
         * events such as 'suspend', an intended end date may also be 
         * indicated.</p> <p>Indicates the time the event (e.g. query, 
         * change, activation) should begin and occasionally when it 
         * should end.</p> Un-merged Business Name: 
         * EventEffectivePeriod Relationship: 
         * MCAI_MT700220CA.ControlActEvent.effectiveTime 
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
         * MCAI_MT700228CA.ControlActEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows 
         * identifying a reason for a specific action, such as 'reason 
         * for hold' or 'reason for accessing information'.</p> <p>The 
         * domain associated with this attribute will vary for each 
         * interaction and will be noted as part of the interaction 
         * description.</p> <p>Identifies why this specific message 
         * interaction (e.g. query, activation request, modification 
         * request) occurred.</p> Un-merged Business Name: EventReason 
         * Relationship: MCAI_MT700227CA.ControlActEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows 
         * identifying a reason for a specific action, such as 'reason 
         * for hold' or 'reason for accessing information'.</p> <p>The 
         * domain associated with this attribute will vary for each 
         * interaction and will be noted as part of the interaction 
         * description.</p> <p>Identifies why this specific message 
         * interaction (e.g. query, activation request, modification 
         * request) occurred.</p> Un-merged Business Name: EventReason 
         * Relationship: MCAI_MT700222CA.ControlActEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows 
         * identifying a reason for a specific action, such as 'reason 
         * for hold' or 'reason for accessing information'.</p> <p>The 
         * domain associated with this attribute will vary for each 
         * interaction and will be noted as part of the interaction 
         * description.</p> <p>Identifies why this specific message 
         * interaction (e.g. query, activation request, modification 
         * request) occurred.</p> Un-merged Business Name: EventReason 
         * Relationship: MCAI_MT700221CA.ControlActEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows 
         * identifying a reason for a specific action, such as 'reason 
         * for hold' or 'reason for accessing information'.</p> <p>The 
         * domain associated with this attribute will vary for each 
         * interaction and will be noted as part of the interaction 
         * description.</p> <p>Identifies why this specific message 
         * interaction (e.g. query, activation request, modification 
         * request) occurred.</p> Un-merged Business Name: EventReason 
         * Relationship: MCAI_MT700226CA.ControlActEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows 
         * identifying a reason for a specific action, such as 'reason 
         * for hold' or 'reason for accessing information'.</p> <p>The 
         * domain associated with this attribute will vary for each 
         * interaction and will be noted as part of the interaction 
         * description.</p> <p>Identifies why this specific message 
         * interaction (e.g. query, activation request, modification 
         * request) occurred.</p> Un-merged Business Name: EventReason 
         * Relationship: MCAI_MT700220CA.ControlActEvent.reasonCode 
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
         * <summary>Business Name: MessageLanguage</summary>
         * 
         * <remarks>Un-merged Business Name: MessageLanguage 
         * Relationship: MCAI_MT700228CA.ControlActEvent.languageCode 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: MessageLanguage Relationship: 
         * MCAI_MT700227CA.ControlActEvent.languageCode 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: MessageLanguage Relationship: 
         * MCAI_MT700222CA.ControlActEvent.languageCode 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: MessageLanguage Relationship: 
         * MCAI_MT700221CA.ControlActEvent.languageCode 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: MessageLanguage Relationship: 
         * MCAI_MT700226CA.ControlActEvent.languageCode 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: MessageLanguage Relationship: 
         * MCAI_MT700220CA.ControlActEvent.languageCode 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"languageCode"})]
        public HumanLanguage LanguageCode {
            get { return (HumanLanguage) this.languageCode.Value; }
            set { this.languageCode.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * MCAI_MT700228CA.ControlActEvent.subject 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700227CA.ControlActEvent.subject 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700222CA.ControlActEvent.subject 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700221CA.ControlActEvent.subject 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700226CA.ControlActEvent.subject 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700220CA.ControlActEvent.subject 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.RefersTo_1<ACT> Subject {
            get { return this.subject; }
            set { this.subject = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * MCAI_MT700228CA.Subject.detectedIssueEvent 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700227CA.Subject.detectedIssueEvent 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700222CA.Subject.detectedIssueEvent 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700221CA.Subject.detectedIssueEvent 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700226CA.Subject.detectedIssueEvent 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700220CA.Subject.detectedIssueEvent 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf/detectedIssueEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.Issues> SubjectOfDetectedIssueEvent {
            get { return this.subjectOfDetectedIssueEvent; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: MCAI_MT700227CA.RecordTarget.patient1 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700221CA.RecordTarget.patient1 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700226CA.RecordTarget.patient1 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700220CA.RecordTarget.patient1 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"recordTarget/patient1"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.IPatient RecordTargetPatient1 {
            get { return this.recordTargetPatient1; }
            set { this.recordTargetPatient1 = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * MCAI_MT700222CA.ResponsibleParty.assignedEntity 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700221CA.ResponsibleParty.assignedEntity 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700220CA.ResponsibleParty.assignedEntity 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090102ca.HealthcareWorker ResponsiblePartyAssignedEntity {
            get { return this.responsiblePartyAssignedEntity; }
            set { this.responsiblePartyAssignedEntity = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * MCAI_MT700222CA.ControlActEvent.author 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700221CA.ControlActEvent.author 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700220CA.ControlActEvent.author 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.CreatedBy_1 Author {
            get { return this.author; }
            set { this.author = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * MCAI_MT700222CA.DataEnterer.actingPerson 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700221CA.DataEnterer.actingPerson 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700220CA.DataEnterer.actingPerson 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"dataEnterer/actingPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.IActingPerson DataEntererActingPerson {
            get { return this.dataEntererActingPerson; }
            set { this.dataEntererActingPerson = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * MCAI_MT700222CA.DataEntryLocation.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700221CA.DataEntryLocation.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700220CA.DataEntryLocation.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"dataEntryLocation/serviceDeliveryLocation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt240002ca.ServiceLocation DataEntryLocationServiceDeliveryLocation {
            get { return this.dataEntryLocationServiceDeliveryLocation; }
            set { this.dataEntryLocationServiceDeliveryLocation = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * MCAI_MT700222CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700221CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700220CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location/serviceDeliveryLocation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt240002ca.ServiceLocation LocationServiceDeliveryLocation {
            get { return this.locationServiceDeliveryLocation; }
            set { this.locationServiceDeliveryLocation = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * MCAI_MT700222CA.PertinentInformation.authorizationToken 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700221CA.PertinentInformation.authorizationToken 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700220CA.PertinentInformation.authorizationToken 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"pertinentInformation/authorizationToken"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.AuthenticationToken PertinentInformationAuthorizationToken {
            get { return this.pertinentInformationAuthorizationToken; }
            set { this.pertinentInformationAuthorizationToken = value; }
        }

    }

}