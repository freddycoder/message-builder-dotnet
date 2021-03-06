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
 * Author:        $LastChangedBy: jmis $
 * Last modified: $LastChangedDate: 2015-09-15 11:09:53 -0400 (Tue, 15 Sep 2015) $
 * Revision:      $LastChangedRevision: 9796 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>PORX_MT060340CA.RefusalToFill: Refusal to Fills</summary>
     * 
     * <p>One of Refusal to Fill Reason or an Issue must be 
     * specified but not both</p> <p>Exposes in the model that this 
     * issue is associated with a refusal to dispense.</p><p>An 
     * indication of 'refusal to fill' must be indicated, thus 
     * attribute is mandatory.</p> <p>Indicates that the identified 
     * issue resulted in a dispenser refusing to fill the subject 
     * prescription.</p> PORX_MT060060CA.RefusalToFill: Refusal To 
     * Fills <p>One of Refusal To Fill Reason or Issue must be 
     * specified but not both</p> <p>Exposes in the model that this 
     * issue is associated with a refusal to dispense.</p><p>An 
     * indication of 'refusal to fill' must be indicated, thus 
     * attribute is mandatory.</p> <p>Indicates that the identified 
     * issue resulted in a dispenser refusing to fill the subject 
     * prescription.</p> PORX_MT030040CA.RefusalToFill: Refusal to 
     * Fills <p>One of Refusal To Fill Reason or Issue must be 
     * specified, but not both.</p> <p>Exposes in the model that 
     * this issue is associated with a refusal to 
     * dispense.</p><p>An indication of 'refusal to fill' must be 
     * indicated, thus attribute is mandatory.</p> <p>Indicates 
     * that the identified issue resulted in a dispenser refusing 
     * to fill the subject prescription.</p> 
     * PORX_MT060190CA.RefusalToFill: Refusal To Fills <p>One of 
     * Refusal To Fill Reason or Issue must be specified but not 
     * both</p> <p>Exposes in the model that this issue is 
     * associated with a refusal to dispense.</p><p>An indication 
     * of 'refusal to fill' must be indicated, thus attribute is 
     * mandatory.</p> <p>Indicates that the identified issue 
     * resulted in a dispenser refusing to fill the subject 
     * prescription.</p> PORX_MT060040CA.RefusalToFill: Refusals To 
     * Fills <p>One of Refusal To Fill Reason or Issue must be 
     * specified but not both</p> <p>Exposes in the model that this 
     * issue is associated with a refusal to dispense.</p><p>An 
     * indication of 'refusal to fill' must be indicated, thus 
     * attribute is mandatory.</p> <p>Indicates that the identified 
     * issue resulted in a dispenser refusing to fill the subject 
     * prescription. .</p> PORX_MT060160CA.RefusalToFill: Fill 
     * Refusals <p>One of Refusal to Fill Reason or an Issue must 
     * be specified but no both</p> <p>Exposes in the model that 
     * this issue is associated with a refusal to 
     * dispense.</p><p>An indication of 'refusal to fill' must be 
     * indicated, thus attribute is mandatory.</p> <p>Indicates 
     * that the identified issue resulted in a dispenser refusing 
     * to fill the subject prescription.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT030040CA.RefusalToFill","PORX_MT060040CA.RefusalToFill","PORX_MT060060CA.RefusalToFill","PORX_MT060160CA.RefusalToFill","PORX_MT060190CA.RefusalToFill","PORX_MT060340CA.RefusalToFill"})]
    public class RefusalToFills : MessagePartBean {

        private TS effectiveTime;
        private CV reasonCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.RefusedBy author;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.TargetedToPharmacy location;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Merged.Issues> reasonDetectedIssueEvent;

        public RefusalToFills() {
            this.effectiveTime = new TSImpl();
            this.reasonCode = new CVImpl();
            this.reasonDetectedIssueEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Merged.Issues>();
        }
        /**
         * <summary>Business Name: RefusalToFillDate</summary>
         * 
         * <remarks>Un-merged Business Name: RefusalToFillDate 
         * Relationship: PORX_MT060060CA.RefusalToFill.effectiveTime 
         * Conformance/Cardinality: REQUIRED (1) <p>May be important to 
         * down stream providers to know when the refusal 
         * occurred.</p><p>Is marked as populated as it may not always 
         * be known for historical data pre- loaded into the EHR</p> 
         * <p>The date that the dispenser refused to fill the 
         * prescription</p> Un-merged Business Name: RefusalToFillDate 
         * Relationship: PORX_MT060340CA.RefusalToFill.effectiveTime 
         * Conformance/Cardinality: REQUIRED (1) <p>May be important to 
         * down stream providers to know when the refusal 
         * occurred.</p><p>Is marked as populated as it may not always 
         * be known for historical data pre- loaded into the EHR</p> 
         * <p>The date that the dispenser refused to fill the 
         * prescription</p> Un-merged Business Name: RefusalToFillDate 
         * Relationship: PORX_MT030040CA.RefusalToFill.effectiveTime 
         * Conformance/Cardinality: REQUIRED (1) <p>May be important to 
         * down stream providers to know when the refusal 
         * occured.</p><p>Is marked as populated as it may not always 
         * be known for historical data pre- loaded into the EHR</p> 
         * <p>The date that the dispenser refused to fill the 
         * prescitpion</p> Un-merged Business Name: RefusalToFillDate 
         * Relationship: PORX_MT060040CA.RefusalToFill.effectiveTime 
         * Conformance/Cardinality: REQUIRED (1) <p>May be important to 
         * down stream providers to know when the refusal 
         * occurred.</p><p>Is marked as populated as it may not always 
         * be known for historical data pre- loaded into the EHR</p> 
         * <p>The date that the dispenser refused to fill the 
         * prescription</p> Un-merged Business Name: RefusalToFillDate 
         * Relationship: PORX_MT060190CA.RefusalToFill.effectiveTime 
         * Conformance/Cardinality: REQUIRED (1) <p>May be important to 
         * down stream providers to know when the refusal 
         * occurred.</p><p>Is marked as populated as it may not always 
         * be known for historical data pre- loaded into the EHR</p> 
         * <p>The date that the dispenser refused to fill the 
         * prescription</p> Un-merged Business Name: RefusalToFillDate 
         * Relationship: PORX_MT060160CA.RefusalToFill.effectiveTime 
         * Conformance/Cardinality: REQUIRED (1) <p>May be important to 
         * down stream providers to know when the refusal 
         * occurred.</p><p>Is marked as populated as it may not always 
         * be known for historical data pre- loaded into the EHR</p> 
         * <p>The date that the dispenser refused to fill the 
         * prescription</p></remarks>
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
         * Relationship: PORX_MT060060CA.RefusalToFill.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Supports capture 
         * of reasons such as 'moral objection' which are not tied to 
         * specific issues. Set as CWE to allow non-coded reasons.</p> 
         * <p>Indicates a non-clinical-issue based reason for refusing 
         * to fill.</p> Un-merged Business Name: RefusalToFillReason 
         * Relationship: PORX_MT060340CA.RefusalToFill.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Supports capture 
         * of reasons such as 'moral objection' which are not tied to 
         * specific issues. Set to CWE to allow non-coded reasons.</p> 
         * <p>Indicates a non-clinical-issue based reason for refusing 
         * to fill.</p> Un-merged Business Name: RefusalToFillReason 
         * Relationship: PORX_MT030040CA.RefusalToFill.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Indicates a 
         * non-clinical-issue based reason for refusing to fill. Allows 
         * CWE for non-coded reasons.</p> <p>Indicates a 
         * non-clinical-issue based reason for refusing to fill.</p> 
         * Un-merged Business Name: RefusalToFillReason Relationship: 
         * PORX_MT060040CA.RefusalToFill.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Supports capture 
         * of reasons such as 'moral objection' which are not tied to 
         * specific issues. The element is CWE to allow for non-coded 
         * reasons.</p> <p>Indicates a non-clinical-issue based reason 
         * for refusing to fill.</p> Un-merged Business Name: 
         * RefusalToFillReason Relationship: 
         * PORX_MT060190CA.RefusalToFill.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Supports capture 
         * of reasons such as 'moral objection' which are not tied to 
         * specific issues. Set to CWE to allow non-coded reasons.</p> 
         * <p>Indicates a non-clinical-issue based reason for refusing 
         * to fill.</p> Un-merged Business Name: RefusalToFillReason 
         * Relationship: PORX_MT060160CA.RefusalToFill.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Supports capture 
         * of reasons such as 'moral objection' which are not tied to 
         * specific issues. Set as CWE to allow for non-coded 
         * reasons.</p> <p>Indicates a non-clinical-issue based reason 
         * for refusing to fill.</p></remarks>
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
         * <remarks>Relationship: PORX_MT060060CA.RefusalToFill.author 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060340CA.RefusalToFill.author 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT030040CA.RefusalToFill.author 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060040CA.RefusalToFill.author 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060190CA.RefusalToFill.author 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060160CA.RefusalToFill.author 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.RefusedBy Author {
            get { return this.author; }
            set { this.author = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060060CA.RefusalToFill.location 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060340CA.RefusalToFill.location 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT030040CA.RefusalToFill.location 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060040CA.RefusalToFill.location 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060190CA.RefusalToFill.location 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060160CA.RefusalToFill.location 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.TargetedToPharmacy Location {
            get { return this.location; }
            set { this.location = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060060CA.Reason2.detectedIssueEvent 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060340CA.Reason.detectedIssueEvent 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT030040CA.Reason2.detectedIssueEvent 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060040CA.Reason.detectedIssueEvent 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060190CA.Reason2.detectedIssueEvent 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060160CA.Reason.detectedIssueEvent 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reason/detectedIssueEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Merged.Issues> ReasonDetectedIssueEvent {
            get { return this.reasonDetectedIssueEvent; }
        }

    }

}