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
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Mcai_mt700210ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt090107ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt470000ca;
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
    [Hl7PartTypeMappingAttribute(new string[] {"MCAI_MT700210CA.ControlActEvent"})]
    public class TriggerEvent<ACT> : MessagePartBean {

        private II id;
        private CV code;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private CV reasonCode;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt090107ca.Provider responsiblePartyAssignedPerson;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.CreatedBy author;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt090107ca.Provider dataEntererAssignedPerson;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.ServiceLocation dataEntryLocationServiceDeliveryLocation;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.CreatedAt location;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.RefersTo<ACT> subject;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.Caused> subjectOf1;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt470000ca.Consent subjectOf2ConsentEvent;

        public TriggerEvent() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.reasonCode = new CVImpl();
            this.subjectOf1 = new List<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.Caused>();
        }
        /**
         * <summary>Business Name: B:Event Identifier</summary>
         * 
         * <remarks>Relationship: MCAI_MT700210CA.ControlActEvent.id 
         * Conformance/Cardinality: MANDATORY (1) <p>A unique 
         * identifier for this particular event assigned by the system 
         * in which the event occurred.</p> <p>Allows the event to be 
         * referenced (for undos) and also indicates whether multiple 
         * interactions were caused by the same triggering event. The 
         * attribute is therefore mandatory.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: A:Event Type</summary>
         * 
         * <remarks>Relationship: MCAI_MT700210CA.ControlActEvent.code 
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
         * MCAI_MT700210CA.ControlActEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Indicates the 
         * time the change should begin (and occasionally when it 
         * should end). If not specified, assumption is that the event 
         * occurred at the same time the message was constructed.</p> 
         * <p>The time a change becomes effective may differ from the 
         * time the event is recorded. (I.e. it may be in the future or 
         * the past). For changes such as 'suspend', an intended end 
         * date may also be indicated.</p></remarks>
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
         * MCAI_MT700210CA.ControlActEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Identifies why 
         * this specific query, modification request, or modification 
         * occurred.</p> <p>Allows identifying a reason for a specific 
         * action, such as 'reason for hold'. Also allows identifying 
         * reason for accessing information for a query.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reasonCode"})]
        public ControlActReason ReasonCode {
            get { return (ControlActReason) this.reasonCode.Value; }
            set { this.reasonCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * MCAI_MT700210CA.ResponsibleParty.assignedPerson</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/assignedPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt090107ca.Provider ResponsiblePartyAssignedPerson {
            get { return this.responsiblePartyAssignedPerson; }
            set { this.responsiblePartyAssignedPerson = value; }
        }

        /**
         * <summary>Relationship: 
         * MCAI_MT700210CA.ControlActEvent.author</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.CreatedBy Author {
            get { return this.author; }
            set { this.author = value; }
        }

        /**
         * <summary>Relationship: 
         * MCAI_MT700210CA.DataEnterer.assignedPerson</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"dataEnterer/assignedPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt090107ca.Provider DataEntererAssignedPerson {
            get { return this.dataEntererAssignedPerson; }
            set { this.dataEntererAssignedPerson = value; }
        }

        /**
         * <summary>Relationship: 
         * MCAI_MT700210CA.DataEntryLocation.serviceDeliveryLocation</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"dataEntryLocation/serviceDeliveryLocation"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.ServiceLocation DataEntryLocationServiceDeliveryLocation {
            get { return this.dataEntryLocationServiceDeliveryLocation; }
            set { this.dataEntryLocationServiceDeliveryLocation = value; }
        }

        /**
         * <summary>Relationship: 
         * MCAI_MT700210CA.ControlActEvent.location</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.CreatedAt Location {
            get { return this.location; }
            set { this.location = value; }
        }

        /**
         * <summary>Relationship: 
         * MCAI_MT700210CA.ControlActEvent.subject</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.RefersTo<ACT> Subject {
            get { return this.subject; }
            set { this.subject = value; }
        }

        /**
         * <summary>Relationship: 
         * MCAI_MT700210CA.ControlActEvent.subjectOf1</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-50)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf1"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.Caused> SubjectOf1 {
            get { return this.subjectOf1; }
        }

        /**
         * <summary>Relationship: MCAI_MT700210CA.Subject3.consentEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2/consentEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt470000ca.Consent SubjectOf2ConsentEvent {
            get { return this.subjectOf2ConsentEvent; }
            set { this.subjectOf2ConsentEvent = value; }
        }

    }

}