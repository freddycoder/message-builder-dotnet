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
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Mcai_mt700236ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt050201ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt050207ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt260020ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Merged;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt050202ca;
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
    [Hl7PartTypeMappingAttribute(new string[] {"MCAI_MT700236CA.ControlActEvent"})]
    public class TriggerEvent : MessagePartBean {

        private II id;
        private CV code;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private CV reasonCode;
        private CS recordTargetTypeCode;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Merged.IPatient recordTargetPatient1;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt260020ca.Issues> subjectOfDetectedIssueEvent;

        public TriggerEvent() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.reasonCode = new CVImpl();
            this.recordTargetTypeCode = new CSImpl();
            this.subjectOfDetectedIssueEvent = new List<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt260020ca.Issues>();
        }
        /**
         * <summary>Business Name: B:Event Identifier</summary>
         * 
         * <remarks>Relationship: MCAI_MT700236CA.ControlActEvent.id 
         * Conformance/Cardinality: MANDATORY (1) <p>A unique 
         * identifier for this particular event assigned by the system 
         * in which the event occurred.</p> <p>Allows the event to be 
         * referenced (for undos) and also indicates whether multiple 
         * interactions were caused by the same triggering event. Also 
         * used for audit purposes.</p> <p>Identifier needs to be 
         * persisted by receiving applications, except for queries 
         * (queries cannot be retracted or undone).</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: A:Event Type</summary>
         * 
         * <remarks>Relationship: MCAI_MT700236CA.ControlActEvent.code 
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
         * MCAI_MT700236CA.ControlActEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Indicates the 
         * time the event (e.g. query, change, activation) should begin 
         * and occasionally when it should end.</p> <p>The time an 
         * event becomes effective may differ from the time the event 
         * is recorded (i.e. it may be in the future or the past). For 
         * events such as 'suspend', an intended end date may also be 
         * indicated.</p></remarks>
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
         * MCAI_MT700236CA.ControlActEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Identifies why 
         * this specific message interaction (e.g. query, activation 
         * request, modification request) occurred.</p> <p>Allows 
         * identifying a reason for a specific action, such as 'reason 
         * for hold' or 'reason for accessing information'.</p> <p>The 
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
         * <summary>Relationship: MCAI_MT700236CA.RecordTarget.typeCode</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"recordTarget/typeCode"})]
        public ParticipationType RecordTargetTypeCode {
            get { return (ParticipationType) this.recordTargetTypeCode.Value; }
            set { this.recordTargetTypeCode.Value = value; }
        }

        /**
         * <summary>Relationship: MCAI_MT700236CA.RecordTarget.patient1</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"recordTarget/patient1"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Merged.IPatient RecordTargetPatient1 {
            get { return this.recordTargetPatient1; }
            set { this.recordTargetPatient1 = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt050202ca.Patient RecordTargetPatient1AsPatient1 {
            get { return this.recordTargetPatient1 is Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt050202ca.Patient ? (Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt050202ca.Patient) this.recordTargetPatient1 : (Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt050202ca.Patient) null; }
        }
        public bool HasRecordTargetPatient1AsPatient1() {
            return (this.recordTargetPatient1 is Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt050202ca.Patient);
        }

        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt050207ca.Patient RecordTargetPatient1AsPatient2 {
            get { return this.recordTargetPatient1 is Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt050207ca.Patient ? (Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt050207ca.Patient) this.recordTargetPatient1 : (Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt050207ca.Patient) null; }
        }
        public bool HasRecordTargetPatient1AsPatient2() {
            return (this.recordTargetPatient1 is Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt050207ca.Patient);
        }

        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt050201ca.Patient RecordTargetPatient1AsPatient3 {
            get { return this.recordTargetPatient1 is Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt050201ca.Patient ? (Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt050201ca.Patient) this.recordTargetPatient1 : (Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt050201ca.Patient) null; }
        }
        public bool HasRecordTargetPatient1AsPatient3() {
            return (this.recordTargetPatient1 is Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt050201ca.Patient);
        }

        /**
         * <summary>Relationship: 
         * MCAI_MT700236CA.Subject.detectedIssueEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf/detectedIssueEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt260020ca.Issues> SubjectOfDetectedIssueEvent {
            get { return this.subjectOfDetectedIssueEvent; }
        }

    }

}