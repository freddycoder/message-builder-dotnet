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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Quqi_mt120000ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Trigger Event</summary>
     * 
     * <p>Key to understanding what action a message 
     * represents.</p> <p>There may be constraints on the usage of 
     * the reasonCode attribute in the definition of the 
     * interaction or the trigger events which are conveyed with 
     * this wrapper.</p> <p>Identifies the action that resulted in 
     * this message being sent.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"QUQI_MT120000CA.ControlActEvent"})]
    public class TriggerEvent<ACT,PL> : MessagePartBean {

        private II id;
        private CV code;
        private TS effectiveTime;
        private CV reasonCode;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Merged.RefersTo<ACT>> subject;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.Issues> subjectOfDetectedIssueEvent;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Quqi_mt120000ca.QueryResponseInformation queryAck;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Merged.QueryDefinition<PL> queryByParameter;

        public TriggerEvent() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.effectiveTime = new TSImpl();
            this.reasonCode = new CVImpl();
            this.subject = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Merged.RefersTo<ACT>>();
            this.subjectOfDetectedIssueEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.Issues>();
        }
        /**
         * <summary>Business Name: B:Event Identifier</summary>
         * 
         * <remarks>Relationship: QUQI_MT120000CA.ControlActEvent.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Used for audit 
         * purposes and therefore mandatory.</p> <p>A unique identifier 
         * for this particular event assigned by the system in which 
         * the event occurred.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: A:Event Type</summary>
         * 
         * <remarks>Relationship: QUQI_MT120000CA.ControlActEvent.code 
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
         * QUQI_MT120000CA.ControlActEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Sometimes 
         * messages may be constructed and sent at a significantly 
         * different time than the query was actually processed.</p> 
         * <p>Indicates when the query was performed. If not specified, 
         * the assumption is that the query was performed at the same 
         * time the message was constructed.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public PlatformDate EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: E:Event Reason</summary>
         * 
         * <remarks>Relationship: 
         * QUQI_MT120000CA.ControlActEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Usually used to 
         * indicate a reason why a query was unsuccessful or was not 
         * processed.</p> <p>Indicates the reason for the response 
         * given</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reasonCode"})]
        public ControlActReason ReasonCode {
            get { return (ControlActReason) this.reasonCode.Value; }
            set { this.reasonCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * QUQI_MT120000CA.ControlActEvent.subject</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-999)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Merged.RefersTo<ACT>> Subject {
            get { return this.subject; }
        }

        /**
         * <summary>Relationship: 
         * QUQI_MT120000CA.Subject.detectedIssueEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf/detectedIssueEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.Issues> SubjectOfDetectedIssueEvent {
            get { return this.subjectOfDetectedIssueEvent; }
        }

        /**
         * <summary>Relationship: 
         * QUQI_MT120000CA.ControlActEvent.queryAck</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"queryAck"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Quqi_mt120000ca.QueryResponseInformation QueryAck {
            get { return this.queryAck; }
            set { this.queryAck = value; }
        }

        /**
         * <summary>Relationship: 
         * QUQI_MT120000CA.ControlActEvent.queryByParameter</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"queryByParameter"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Merged.QueryDefinition<PL> QueryByParameter {
            get { return this.queryByParameter; }
            set { this.queryByParameter = value; }
        }

    }

}