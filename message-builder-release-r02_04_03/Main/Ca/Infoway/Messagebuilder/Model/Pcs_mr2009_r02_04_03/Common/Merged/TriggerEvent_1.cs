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
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: TriggerEvent</summary>
     * 
     * <remarks>MCAI_MT700218CA.ControlActEvent: Trigger Event 
     * <p>Key to understanding what action a message 
     * represents.</p> <p>There may be constraints on the usage of 
     * the effectiveTime and reasonCode attributes in the 
     * definition of the interaction or the trigger events which 
     * are conveyed with this wrapper.</p> <p>Identifies the action 
     * that resulted in this message being sent.</p> 
     * MCAI_MT700217CA.ControlActEvent: Trigger Event <p>Key to 
     * understanding what action a message represents.</p> <p>There 
     * may be constraints on the usage of the effectiveTime and 
     * reasonCode attributes in the definition of the interaction 
     * or the trigger events which are conveyed with this 
     * wrapper.</p> <p>Identifies the action that resulted in this 
     * message being sent.</p> MCAI_MT700216CA.ControlActEvent: 
     * Trigger Event <p>Key to understanding what action a message 
     * represents.</p> <p>There may be constraints on the usage of 
     * the effectiveTime and reasonCode attributes in the 
     * definition of the interaction or the trigger events which 
     * are conveyed with this wrapper.</p> <p>Identifies the action 
     * that resulted in this message being sent.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"MCAI_MT700216CA.ControlActEvent","MCAI_MT700217CA.ControlActEvent","MCAI_MT700218CA.ControlActEvent"})]
    public class TriggerEvent_1<ACT> : MessagePartBean {

        private II id;
        private CV code;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private CV reasonCode;
        private CE languageCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.RefersTo_1<ACT> subject;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.Issues> subjectOfDetectedIssueEvent;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.IPatient recordTargetPatient1;

        public TriggerEvent_1() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.reasonCode = new CVImpl();
            this.languageCode = new CEImpl();
            this.subjectOfDetectedIssueEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.Issues>();
        }
        /**
         * <summary>Business Name: EventIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: EventIdentifier 
         * Relationship: MCAI_MT700218CA.ControlActEvent.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows the event 
         * to be referenced (for undos) and also indicates whether 
         * multiple interactions were caused by the same triggering 
         * event. Also used for audit purposes.</p> <p>Identifier needs 
         * to be persisted by receiving applications, except for 
         * queries (queries cannot be retracted or undone).</p> <p>A 
         * unique identifier for this particular event assigned by the 
         * system in which the event occurred.</p> Un-merged Business 
         * Name: EventIdentifier Relationship: 
         * MCAI_MT700217CA.ControlActEvent.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Allows the event to be referenced (for 
         * undos) and also indicates whether multiple interactions were 
         * caused by the same triggering event. Also used for audit 
         * purposes.</p> <p>Identifier needs to be persisted by 
         * receiving applications, except for queries (queries cannot 
         * be retracted or undone).</p> <p>A unique identifier for this 
         * particular event assigned by the system in which the event 
         * occurred.</p> Un-merged Business Name: EventIdentifier 
         * Relationship: MCAI_MT700216CA.ControlActEvent.id 
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
         * <summary>Business Name: EventType</summary>
         * 
         * <remarks>Un-merged Business Name: EventType Relationship: 
         * MCAI_MT700218CA.ControlActEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>This is mandatory 
         * because it is essential to understanding the meaning of the 
         * event.</p> <p>Identifies the trigger event that 
         * occurred.</p> Un-merged Business Name: EventType 
         * Relationship: MCAI_MT700217CA.ControlActEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>This is mandatory 
         * because it is essential to understanding the meaning of the 
         * event.</p> <p>Identifies the trigger event that 
         * occurred.</p> Un-merged Business Name: EventType 
         * Relationship: MCAI_MT700216CA.ControlActEvent.code 
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
         * Relationship: MCAI_MT700218CA.ControlActEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The time an event 
         * becomes effective may differ from the time the event is 
         * recorded (i.e. it may be in the future or the past). For 
         * events such as 'suspend', an intended end date may also be 
         * indicated.</p> <p>Indicates the time the event (e.g. query, 
         * change, activation) should begin and occasionally when it 
         * should end.</p> Un-merged Business Name: 
         * EventEffectivePeriod Relationship: 
         * MCAI_MT700217CA.ControlActEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The time an event 
         * becomes effective may differ from the time the event is 
         * recorded (i.e. it may be in the future or the past). For 
         * events such as 'suspend', an intended end date may also be 
         * indicated.</p> <p>Indicates the time the event (e.g. query, 
         * change, activation) should begin and occasionally when it 
         * should end.</p> Un-merged Business Name: 
         * EventEffectivePeriod Relationship: 
         * MCAI_MT700216CA.ControlActEvent.effectiveTime 
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
         * MCAI_MT700218CA.ControlActEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows 
         * identifying a reason for a specific action, such as 'reason 
         * for hold' or 'reason for accessing information'.</p> <p>The 
         * domain associated with this attribute will vary for each 
         * interaction and will be noted as part of the interaction 
         * description.</p> <p>Identifies why this specific message 
         * interaction (e.g. query, activation request, modification 
         * request) occurred.</p> Un-merged Business Name: EventReason 
         * Relationship: MCAI_MT700217CA.ControlActEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows 
         * identifying a reason for a specific action, such as 'reason 
         * for hold' or 'reason for accessing information'.</p> <p>The 
         * domain associated with this attribute will vary for each 
         * interaction and will be noted as part of the interaction 
         * description.</p> <p>Identifies why this specific message 
         * interaction (e.g. query, activation request, modification 
         * request) occurred.</p> Un-merged Business Name: EventReason 
         * Relationship: MCAI_MT700216CA.ControlActEvent.reasonCode 
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
         * Relationship: MCAI_MT700218CA.ControlActEvent.languageCode 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: MessageLanguage Relationship: 
         * MCAI_MT700217CA.ControlActEvent.languageCode 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: MessageLanguage Relationship: 
         * MCAI_MT700216CA.ControlActEvent.languageCode 
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
         * MCAI_MT700218CA.ControlActEvent.subject 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700217CA.ControlActEvent.subject 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700216CA.ControlActEvent.subject 
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
         * MCAI_MT700218CA.Subject.detectedIssueEvent 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700217CA.Subject.detectedIssueEvent 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700216CA.Subject.detectedIssueEvent 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf/detectedIssueEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.Issues> SubjectOfDetectedIssueEvent {
            get { return this.subjectOfDetectedIssueEvent; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: MCAI_MT700217CA.RecordTarget.patient1 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700216CA.RecordTarget.patient1 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"recordTarget/patient1"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.IPatient RecordTargetPatient1 {
            get { return this.recordTargetPatient1; }
            set { this.recordTargetPatient1 = value; }
        }

    }

}