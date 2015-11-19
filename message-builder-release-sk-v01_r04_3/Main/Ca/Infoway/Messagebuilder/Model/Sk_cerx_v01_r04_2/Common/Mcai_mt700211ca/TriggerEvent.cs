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
namespace Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Mcai_mt700211ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Merged;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Porx_mt980020ca;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Trigger Event</summary>
     * 
     * <p>Identifies the action that resulted in this message being 
     * sent.</p> <p>Key to understanding what action a message 
     * represents.</p> <p>There may be constraints on the usage of 
     * the effectiveTime and reasonCode attributes in the 
     * definition of the interaction or the trigger events which 
     * are conveyed with this wrapper.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"MCAI_MT700211CA.ControlActEvent"})]
    public class TriggerEvent<ACT> : MessagePartBean {

        private II id;
        private CV code;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private CV reasonCode;
        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Merged.RefersTo<ACT> subject;
        private IList<Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Porx_mt980020ca.Issues> subjectOfDetectedIssueEvent;

        public TriggerEvent() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.reasonCode = new CVImpl();
            this.subjectOfDetectedIssueEvent = new List<Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Porx_mt980020ca.Issues>();
        }
        /**
         * <summary>Business Name: B:Event Identifier</summary>
         * 
         * <remarks>Relationship: MCAI_MT700211CA.ControlActEvent.id 
         * Conformance/Cardinality: MANDATORY (1) <p>A unique 
         * identifier for this particular event assigned by the system 
         * in which the event occurred.</p> <p>Allows the event to be 
         * referenced (for retractions) and also indicates whether 
         * multiple interactions were caused by the same triggering 
         * event. The attribute is therefore mandatory.</p> <p>These 
         * identifiers should be stored for use in 'retractions'. They 
         * should be stored in such a way that they are associated with 
         * the item that was modified by this event. For example, a 
         * system should be able to show the list of trigger event 
         * identifiers for the actions that have been recorded against 
         * a particular prescription.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: A:Event Type</summary>
         * 
         * <remarks>Relationship: MCAI_MT700211CA.ControlActEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Identifies the 
         * trigger event that occurred.</p> <p>This is mandatory 
         * because it is essential to understanding the meaning of the 
         * event.</p></remarks>
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
         * MCAI_MT700211CA.ControlActEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Indicates the 
         * time the change should begin (and occasionally when it 
         * should end). If not specified, assumption is that the event 
         * occurred at the same time the message was 
         * constructed.</p><p>Example use is to record a dispense 
         * pickup time on the Rx Pickup Notification interaction. This 
         * time may be in the past, but cannot be in the future.</p> 
         * <p>Indicates the time the change should begin (and 
         * occasionally when it should end). If not specified, 
         * assumption is that the event occurred at the same time the 
         * message was constructed.</p><p>Example use is to record a 
         * dispense pickup time on the Rx Pickup Notification 
         * interaction. This time may be in the past, but cannot be in 
         * the future.</p> <p>The time a change becomes effective may 
         * differ from the time the event is recorded. (I.e. it may be 
         * in the future or the past). For changes such as 'suspend', 
         * an intended end date may also be indicated.</p></remarks>
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
         * MCAI_MT700211CA.ControlActEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Identifies why 
         * this specific query, modification request, or modification 
         * occurred.</p> <p>Allows identifying a reason for a specific 
         * action, such as 'reason for hold'. Also allows identifying 
         * reason for accessing information for a query.</p> <p>The 
         * domain associated with this attribute will vary for each 
         * interaction and will be noted as part of the interaction 
         * description.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reasonCode"})]
        public ControlActReason ReasonCode {
            get { return (ControlActReason) this.reasonCode.Value; }
            set { this.reasonCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * MCAI_MT700211CA.ControlActEvent.subject</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject"})]
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Merged.RefersTo<ACT> Subject {
            get { return this.subject; }
            set { this.subject = value; }
        }

        /**
         * <summary>Relationship: 
         * MCAI_MT700211CA.Subject.detectedIssueEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf/detectedIssueEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Porx_mt980020ca.Issues> SubjectOfDetectedIssueEvent {
            get { return this.subjectOfDetectedIssueEvent; }
        }

    }

}