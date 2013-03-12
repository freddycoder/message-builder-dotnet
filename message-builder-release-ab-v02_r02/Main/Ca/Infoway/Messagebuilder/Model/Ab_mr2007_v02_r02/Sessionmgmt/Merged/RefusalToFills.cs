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
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt090107ca;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>PORX_MT060340CA.RefusalToFill: Refusal to Fills</summary>
     * 
     * <p>One of 'Refusal to Fill Reason' or an 'Issue' must be 
     * specified but not both</p> <p>Indicates that the identified 
     * issue resulted in a dispenser refusing to fill the subject 
     * prescription.</p> <p>Exposes in the model that this issue is 
     * associated with a refusal to dispense.</p><p>An indication 
     * of 'refusal to fill' must be indicated, thus attribute is 
     * mandatory.</p> <p>Exposes in the model that this issue is 
     * associated with a refusal to dispense.</p><p>An indication 
     * of 'refusal to fill' must be indicated, thus attribute is 
     * mandatory.</p> PORX_MT060160CA.RefusalToFill: Fill Refusals 
     * <p>One of 'Refusal to Fill Reason' or an Issue must be 
     * specified but no both</p> <p>Indicates that the identified 
     * issue resulted in a dispenser refusing to fill the subject 
     * prescription.</p> <p>Exposes in the model that this issue is 
     * associated with a refusal to dispense.</p><p>An indication 
     * of 'refusal to fill' must be indicated, thus attribute is 
     * mandatory.</p> <p>Exposes in the model that this issue is 
     * associated with a refusal to dispense.</p><p>An indication 
     * of 'refusal to fill' must be indicated, thus attribute is 
     * mandatory.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060160CA.RefusalToFill","PORX_MT060340CA.RefusalToFill"})]
    public class RefusalToFills : MessagePartBean {

        private TS effectiveTime;
        private CV reasonCode;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt090107ca.Provider authorAssignedPerson;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.CreatedAt location;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.Issues> reasonDetectedIssueEvent;

        public RefusalToFills() {
            this.effectiveTime = new TSImpl();
            this.reasonCode = new CVImpl();
            this.reasonDetectedIssueEvent = new List<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.Issues>();
        }
        /**
         * <summary>Business Name: RefusalToFillDate</summary>
         * 
         * <remarks>Un-merged Business Name: RefusalToFillDate 
         * Relationship: PORX_MT060340CA.RefusalToFill.effectiveTime 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: RefusalToFillDate Relationship: 
         * PORX_MT060160CA.RefusalToFill.effectiveTime 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public PlatformDate EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: RefusalToFillReason</summary>
         * 
         * <remarks>Un-merged Business Name: RefusalToFillReason 
         * Relationship: PORX_MT060340CA.RefusalToFill.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Indicates a 
         * non-clinical-issue based reason for refusing to fill.</p> 
         * <p>Supports capture of reasons such as 'moral objection' 
         * which are not tied to specific issues. Set to CWE to allow 
         * non-coded reasons.</p> Un-merged Business Name: 
         * RefusalToFillReason Relationship: 
         * PORX_MT060160CA.RefusalToFill.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Indicates a 
         * non-clinical-issue based reason for refusing to fill.</p> 
         * <p>Supports capture of reasons such as 'moral objection' 
         * which are not tied to specific issues. Set as CWE to allow 
         * for non-coded reasons.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reasonCode"})]
        public ActSupplyFulfillmentRefusalReason ReasonCode {
            get { return (ActSupplyFulfillmentRefusalReason) this.reasonCode.Value; }
            set { this.reasonCode.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: PORX_MT060340CA.Author.assignedPerson 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060160CA.Author5.assignedPerson 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author/assignedPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt090107ca.Provider AuthorAssignedPerson {
            get { return this.authorAssignedPerson; }
            set { this.authorAssignedPerson = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060340CA.RefusalToFill.location 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060160CA.RefusalToFill.location 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.CreatedAt Location {
            get { return this.location; }
            set { this.location = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060340CA.Reason.detectedIssueEvent 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060160CA.Reason.detectedIssueEvent 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reason/detectedIssueEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.Issues> ReasonDetectedIssueEvent {
            get { return this.reasonDetectedIssueEvent; }
        }

    }

}