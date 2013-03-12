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
namespace Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Issues</summary>
     * 
     * <remarks>PORX_MT030040CA.DetectedIssueEvent: Issues 
     * <p>Describes an issue associated with a prescription that 
     * resulted in a dispenser refusing to fill it.</p> <p>Allows a 
     * dispenser to assert an issue against a prescription to be 
     * displayed to subsequent dispensers as well as others 
     * reviewing the patient's medication profile.</p> 
     * PORX_MT060160CA.DetectedIssueEvent: Issues <p>Describes an 
     * issue associated with a prescription that resulted in a 
     * dispenser refusing to fill it.</p> <p>Allows a dispenser to 
     * assert an issue against a prescription to be displayed to 
     * subsequent dispensers as well as others reviewing the 
     * patient's medication profile.</p> 
     * PORX_MT060340CA.DetectedIssueEvent: Issues <p>Describes an 
     * issue associated with a prescription that resulted in a 
     * dispenser refusing to fill it.</p> <p>Allows a dispenser to 
     * assert an issue against a prescription to be displayed to 
     * subsequent dispensers as well as others reviewing the 
     * patient's medication profile.</p> 
     * PORX_MT060190CA.DetectedIssueEvent: Issues <p>Describes an 
     * issue associated with a prescription that resulted in a 
     * dispenser refusing to fill it.</p> <p>Allows a dispenser to 
     * assert an issue against a prescription to be displayed to 
     * subsequent dispensers as well as others reviewing the 
     * patient's medication profile.</p> 
     * PORX_MT980030CA.DetectedIssueEvent: Issues <p>This is the 
     * list of clinical and business issues that have been detected 
     * and recorded involving the current action.</p> <p>Provides a 
     * list of issues that have been detected and/or managed.</p> 
     * PORX_MT980020CA.DetectedIssueEvent: Issues <p>This is the 
     * list of clinical and business-rule issues that have been 
     * detected and recorded involving the current action.</p> 
     * <p>Provides a list of issues that have been detected.</p> 
     * PORX_MT060040CA.DetectedIssueEvent: Issues <p>Describes an 
     * issue associated with a prescription that resulted in a 
     * dispenser refusing to fill it.</p> <p>Allows a dispenser to 
     * assert an issue against a prescription to be displayed to 
     * subsequent dispensers as well as others reviewing the 
     * patient's medication profile.</p> 
     * PORX_MT980010CA.DetectedIssueEvent: Issues <p>This is the 
     * list of clinical and business issues that have been detected 
     * and recorded involving the current action.</p> <p>Provides a 
     * list of issues that have been detected and/or managed.</p> 
     * PORX_MT060060CA.DetectedIssueEvent: Issues <p>Describes an 
     * issue associated with a prescription that resulted in a 
     * dispenser refusing to fill it.</p> <p>Allows a dispenser to 
     * assert an issue against a prescription to be displayed to 
     * subsequent dispensers as well as others reviewing the 
     * patient's profile.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT030040CA.DetectedIssueEvent","PORX_MT060040CA.DetectedIssueEvent","PORX_MT060060CA.DetectedIssueEvent","PORX_MT060160CA.DetectedIssueEvent","PORX_MT060190CA.DetectedIssueEvent","PORX_MT060340CA.DetectedIssueEvent","PORX_MT980010CA.DetectedIssueEvent","PORX_MT980020CA.DetectedIssueEvent","PORX_MT980030CA.DetectedIssueEvent"})]
    public class Issues : MessagePartBean {

        private CV code;
        private ST text;
        private CV priorityCode;
        private IList<Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged.ICausalActs> subjectCausalActs;
        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged.IssueDescription instantiationDetectedIssueDefinition;
        private IList<Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged.IssueManagements> mitigatedByDetectedIssueManagement;
        private CV subjectOfSeverityObservationValue;
        private BL triggerForActRequest;
        private BL subjectOf1StorageIntent;

        public Issues() {
            this.code = new CVImpl();
            this.text = new STImpl();
            this.priorityCode = new CVImpl();
            this.subjectCausalActs = new List<Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged.ICausalActs>();
            this.mitigatedByDetectedIssueManagement = new List<Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged.IssueManagements>();
            this.subjectOfSeverityObservationValue = new CVImpl();
            this.triggerForActRequest = new BLImpl(false);
            this.subjectOf1StorageIntent = new BLImpl(false);
        }
        /**
         * <summary>Business Name: IssueType</summary>
         * 
         * <remarks>Un-merged Business Name: IssueType Relationship: 
         * PORX_MT030040CA.DetectedIssueEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>A coded value that 
         * is used to distinguish between different kinds of issues. 
         * Types of issue include: unrecognized identifiers, permission 
         * issues, drug-drug contraindications, drug-allergy alerts, 
         * duplicate therapies, suspect fraud etc.</p><p>.</p> <p>A 
         * coded value that is used to distinguish between different 
         * kinds of issues. Types of issue include: unrecognized 
         * identifiers, permission issues, drug-drug contraindications, 
         * drug-allergy alerts, duplicate therapies, suspect fraud 
         * etc.</p><p>.</p> <p>Identifies what kind of issue was 
         * detected or is being managed.</p><p>This is mandatory so as 
         * to ensure that one issue type can be distinguished from 
         * another.</p> <p>Identifies what kind of issue was detected 
         * or is being managed.</p><p>This is mandatory so as to ensure 
         * that one issue type can be distinguished from another.</p> 
         * Un-merged Business Name: IssueType Relationship: 
         * PORX_MT060160CA.DetectedIssueEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>A coded value that 
         * is used to distinguish between different kinds of issues. 
         * Types of issue include: unrecognized identifiers, permission 
         * issues, drug-drug contraindications, drug-allergy alerts, 
         * duplicate therapies, suspect fraud etc.</p> <p>Identifies 
         * what kind of issue was detected or is being 
         * managed.</p><p>This is mandatory so as to ensure that one 
         * issue type can be distinguished from another.</p> 
         * <p>Identifies what kind of issue was detected or is being 
         * managed.</p><p>This is mandatory so as to ensure that one 
         * issue type can be distinguished from another.</p> Un-merged 
         * Business Name: IssueType Relationship: 
         * PORX_MT060340CA.DetectedIssueEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>A coded value that 
         * is used to distinguish between different kinds of issues. 
         * Types of issue include: unrecognized identifiers, permission 
         * issues, drug-drug contraindications, drug-allergy alerts, 
         * duplicate therapies, suspect fraud etc.</p> <p>Identifies 
         * what kind of issue was detected or is being 
         * managed.</p><p>This is mandatory so as to ensure that one 
         * issue type can be distinguished from another.</p> 
         * <p>Identifies what kind of issue was detected or is being 
         * managed.</p><p>This is mandatory so as to ensure that one 
         * issue type can be distinguished from another.</p> Un-merged 
         * Business Name: IssueType Relationship: 
         * PORX_MT060190CA.DetectedIssueEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>A coded value that 
         * is used to distinguish between different kinds of issues. 
         * Types of issue include: unrecognized identifiers, permission 
         * issues, drug-drug contraindications, drug-allergy alerts, 
         * duplicate therapies, suspect fraud etc.</p> <p>Identifies 
         * what kind of issue was detected or is being 
         * managed.</p><p>This is mandatory so as to ensure that one 
         * issue type can be distinguished from another.</p> 
         * <p>Identifies what kind of issue was detected or is being 
         * managed.</p><p>This is mandatory so as to ensure that one 
         * issue type can be distinguished from another.</p> Un-merged 
         * Business Name: IssueType Relationship: 
         * PORX_MT980020CA.DetectedIssueEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>A coded value that 
         * is used to distinguish between different kinds of issues. 
         * Types of issue include: unrecognized identifiers, permission 
         * issues, drug-drug contraindications, drug-allergy alerts, 
         * duplicate therapies, etc.</p> 
         * <p>Contraindication.crossSensitive (if code is related 
         * reaction dected issue then crossSensitive is 
         * 'True')</p><p>Distinguishes between DAI, DDI, DosageCheck, 
         * DPD, and Duplicate Therapy 
         * Contraindications</p><p>Contraindication.DosageContraType</p><p>OverrideReason.reasonDomain</p><p>ZP3.3</p><p>E06(for 
         * contraindications errors are handled at transmission or 
         * controlAct wrapper level)</p><p>05.03D</p><p>DUR Response 
         * Codes</p><p>Interaction 
         * Type</p><p>ZPS.7.1</p><p>ZDU.9.1(PLYPHRM)</p><p>ZDU.10.1 
         * (PLYDOC)</p><p>ZDU.6.2</p><p>ZDU.6.4</p><p>ZDU.7.3</p><p>DRU.100-01</p><p>DUR/PPS.439-E4</p><p>A_DetectedMedicationIssue</p> 
         * <p>Contraindication.crossSensitive (if code is related 
         * reaction dected issue then crossSensitive is 
         * 'True')</p><p>Distinguishes between DAI, DDI, DosageCheck, 
         * DPD, and Duplicate Therapy 
         * Contraindications</p><p>Contraindication.DosageContraType</p><p>OverrideReason.reasonDomain</p><p>ZP3.3</p><p>E06(for 
         * contraindications errors are handled at transmission or 
         * controlAct wrapper level)</p><p>05.03D</p><p>DUR Response 
         * Codes</p><p>Interaction 
         * Type</p><p>ZPS.7.1</p><p>ZDU.9.1(PLYPHRM)</p><p>ZDU.10.1 
         * (PLYDOC)</p><p>ZDU.6.2</p><p>ZDU.6.4</p><p>ZDU.7.3</p><p>DRU.100-01</p><p>DUR/PPS.439-E4</p><p>A_DetectedMedicationIssue</p> 
         * <p>Contraindication.crossSensitive (if code is related 
         * reaction dected issue then crossSensitive is 
         * 'True')</p><p>Distinguishes between DAI, DDI, DosageCheck, 
         * DPD, and Duplicate Therapy 
         * Contraindications</p><p>Contraindication.DosageContraType</p><p>OverrideReason.reasonDomain</p><p>ZP3.3</p><p>E06(for 
         * contraindications errors are handled at transmission or 
         * controlAct wrapper level)</p><p>05.03D</p><p>DUR Response 
         * Codes</p><p>Interaction 
         * Type</p><p>ZPS.7.1</p><p>ZDU.9.1(PLYPHRM)</p><p>ZDU.10.1 
         * (PLYDOC)</p><p>ZDU.6.2</p><p>ZDU.6.4</p><p>ZDU.7.3</p><p>DRU.100-01</p><p>DUR/PPS.439-E4</p><p>A_DetectedMedicationIssue</p> 
         * <p>Contraindication.crossSensitive (if code is related 
         * reaction dected issue then crossSensitive is 
         * 'True')</p><p>Distinguishes between DAI, DDI, DosageCheck, 
         * DPD, and Duplicate Therapy 
         * Contraindications</p><p>Contraindication.DosageContraType</p><p>OverrideReason.reasonDomain</p><p>ZP3.3</p><p>E06(for 
         * contraindications errors are handled at transmission or 
         * controlAct wrapper level)</p><p>05.03D</p><p>DUR Response 
         * Codes</p><p>Interaction 
         * Type</p><p>ZPS.7.1</p><p>ZDU.9.1(PLYPHRM)</p><p>ZDU.10.1 
         * (PLYDOC)</p><p>ZDU.6.2</p><p>ZDU.6.4</p><p>ZDU.7.3</p><p>DRU.100-01</p><p>DUR/PPS.439-E4</p><p>A_DetectedMedicationIssue</p> 
         * <p>Contraindication.crossSensitive (if code is related 
         * reaction dected issue then crossSensitive is 
         * 'True')</p><p>Distinguishes between DAI, DDI, DosageCheck, 
         * DPD, and Duplicate Therapy 
         * Contraindications</p><p>Contraindication.DosageContraType</p><p>OverrideReason.reasonDomain</p><p>ZP3.3</p><p>E06(for 
         * contraindications errors are handled at transmission or 
         * controlAct wrapper level)</p><p>05.03D</p><p>DUR Response 
         * Codes</p><p>Interaction 
         * Type</p><p>ZPS.7.1</p><p>ZDU.9.1(PLYPHRM)</p><p>ZDU.10.1 
         * (PLYDOC)</p><p>ZDU.6.2</p><p>ZDU.6.4</p><p>ZDU.7.3</p><p>DRU.100-01</p><p>DUR/PPS.439-E4</p><p>A_DetectedMedicationIssue</p> 
         * <p>Contraindication.crossSensitive (if code is related 
         * reaction dected issue then crossSensitive is 
         * 'True')</p><p>Distinguishes between DAI, DDI, DosageCheck, 
         * DPD, and Duplicate Therapy 
         * Contraindications</p><p>Contraindication.DosageContraType</p><p>OverrideReason.reasonDomain</p><p>ZP3.3</p><p>E06(for 
         * contraindications errors are handled at transmission or 
         * controlAct wrapper level)</p><p>05.03D</p><p>DUR Response 
         * Codes</p><p>Interaction 
         * Type</p><p>ZPS.7.1</p><p>ZDU.9.1(PLYPHRM)</p><p>ZDU.10.1 
         * (PLYDOC)</p><p>ZDU.6.2</p><p>ZDU.6.4</p><p>ZDU.7.3</p><p>DRU.100-01</p><p>DUR/PPS.439-E4</p><p>A_DetectedMedicationIssue</p> 
         * <p>Contraindication.crossSensitive (if code is related 
         * reaction dected issue then crossSensitive is 
         * 'True')</p><p>Distinguishes between DAI, DDI, DosageCheck, 
         * DPD, and Duplicate Therapy 
         * Contraindications</p><p>Contraindication.DosageContraType</p><p>OverrideReason.reasonDomain</p><p>ZP3.3</p><p>E06(for 
         * contraindications errors are handled at transmission or 
         * controlAct wrapper level)</p><p>05.03D</p><p>DUR Response 
         * Codes</p><p>Interaction 
         * Type</p><p>ZPS.7.1</p><p>ZDU.9.1(PLYPHRM)</p><p>ZDU.10.1 
         * (PLYDOC)</p><p>ZDU.6.2</p><p>ZDU.6.4</p><p>ZDU.7.3</p><p>DRU.100-01</p><p>DUR/PPS.439-E4</p><p>A_DetectedMedicationIssue</p> 
         * <p>Contraindication.crossSensitive (if code is related 
         * reaction dected issue then crossSensitive is 
         * 'True')</p><p>Distinguishes between DAI, DDI, DosageCheck, 
         * DPD, and Duplicate Therapy 
         * Contraindications</p><p>Contraindication.DosageContraType</p><p>OverrideReason.reasonDomain</p><p>ZP3.3</p><p>E06(for 
         * cont
         * ... [rest of documentation truncated due to excessive length]
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActDetectedIssueCode Code {
            get { return (ActDetectedIssueCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: IssueComment</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT030040CA.DetectedIssueEvent.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>A free form 
         * textual description regarding the issue of fraudulence. This 
         * may be specified in place of, or in addition to the coded 
         * issue.</p> <p>Enables extra or more detailed description of 
         * the alert</p> Un-merged Business Name: IssueComment 
         * Relationship: PORX_MT060160CA.DetectedIssueEvent.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>A free form 
         * textual description regarding the issue of fraudulence. This 
         * may be specified in place of, or in addition to the coded 
         * issue.</p> <p>Enables extra or more detailed description of 
         * the alert</p> Un-merged Business Name: IssueComment 
         * Relationship: PORX_MT060340CA.DetectedIssueEvent.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>A free form 
         * textual description regarding the issue of fraudulence. This 
         * may be specified in place of, or in addition to the coded 
         * issue.</p> <p>Enables extra or more detailed description of 
         * the alert</p> Un-merged Business Name: IssueComment 
         * Relationship: PORX_MT060190CA.DetectedIssueEvent.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>A free form 
         * textual description regarding the issue of fraudulence. This 
         * may be specified in place of, or in addition to the coded 
         * issue.</p> <p>Enables extra or more detailed description of 
         * the alert</p> Un-merged Business Name: IssueDetails 
         * Relationship: PORX_MT980020CA.DetectedIssueEvent.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>A free form 
         * textual description of a detected issue. This textual 
         * information is provided to either augment the coded 
         * information or in place of the coded information.</p> 
         * <p>Contraindication.DDIDescription</p><p>E20(for 
         * contraindication errors are handled at transmission or 
         * controlact wrapper level)</p><p>ZPE.4</p><p>ZDU.11.1</p> 
         * <p>Contraindication.DDIDescription</p><p>E20(for 
         * contraindication errors are handled at transmission or 
         * controlact wrapper level)</p><p>ZPE.4</p><p>ZDU.11.1</p> 
         * <p>Contraindication.DDIDescription</p><p>E20(for 
         * contraindication errors are handled at transmission or 
         * controlact wrapper level)</p><p>ZPE.4</p><p>ZDU.11.1</p> 
         * <p>Contraindication.DDIDescription</p><p>E20(for 
         * contraindication errors are handled at transmission or 
         * controlact wrapper level)</p><p>ZPE.4</p><p>ZDU.11.1</p> 
         * <p>Lets providers see textual explanation of the issue.</p> 
         * Un-merged Business Name: IssueDetails Relationship: 
         * PORX_MT980030CA.DetectedIssueEvent.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>A free form 
         * textual description of a detected issue. This textual 
         * information is provided to either augment the coded 
         * information or in place of the coded information.</p> 
         * <p>Contraindication.DDIDescription</p><p>E20(for 
         * contraindication errors are handled at transmission or 
         * controlact wrapper level)</p><p>ZPE.4</p><p>ZDU.11.1</p> 
         * <p>Contraindication.DDIDescription</p><p>E20(for 
         * contraindication errors are handled at transmission or 
         * controlact wrapper level)</p><p>ZPE.4</p><p>ZDU.11.1</p> 
         * <p>Contraindication.DDIDescription</p><p>E20(for 
         * contraindication errors are handled at transmission or 
         * controlact wrapper level)</p><p>ZPE.4</p><p>ZDU.11.1</p> 
         * <p>Contraindication.DDIDescription</p><p>E20(for 
         * contraindication errors are handled at transmission or 
         * controlact wrapper level)</p><p>ZPE.4</p><p>ZDU.11.1</p> 
         * <p>Lets providers see textual explanation of the issue.</p> 
         * Un-merged Business Name: IssueComment Relationship: 
         * PORX_MT060040CA.DetectedIssueEvent.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>A free form 
         * textual description regarding the issue of fraudulence. This 
         * may be specified in place of, or in addition to the coded 
         * issue.</p> <p>Enables extra or more detailed description of 
         * the alert</p> Un-merged Business Name: IssueDetails 
         * Relationship: PORX_MT980010CA.DetectedIssueEvent.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>A free form 
         * textual description of a detected issue. This textual 
         * information is provided to either augment the coded 
         * information or in place of the coded information.</p> 
         * <p>Contraindication.DDIDescription</p><p>E20(for 
         * contraindication errors are handled at transmission or 
         * controlact wrapper level)</p><p>ZPE.4</p><p>ZDU.11.1</p> 
         * <p>Contraindication.DDIDescription</p><p>E20(for 
         * contraindication errors are handled at transmission or 
         * controlact wrapper level)</p><p>ZPE.4</p><p>ZDU.11.1</p> 
         * <p>Contraindication.DDIDescription</p><p>E20(for 
         * contraindication errors are handled at transmission or 
         * controlact wrapper level)</p><p>ZPE.4</p><p>ZDU.11.1</p> 
         * <p>Contraindication.DDIDescription</p><p>E20(for 
         * contraindication errors are handled at transmission or 
         * controlact wrapper level)</p><p>ZPE.4</p><p>ZDU.11.1</p> 
         * <p>Lets providers see textual explanation of the issue.</p> 
         * Un-merged Business Name: IssueComment Relationship: 
         * PORX_MT060060CA.DetectedIssueEvent.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>A free form 
         * textual description regarding the issue. This may be 
         * specified in place of, or in addition to the coded 
         * issue.</p> <p>Enables extra or more detailed description of 
         * the alert</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public String Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Business Name: IssuePriority</summary>
         * 
         * <remarks>Un-merged Business Name: IssuePriority 
         * Relationship: 
         * PORX_MT980020CA.DetectedIssueEvent.priorityCode 
         * Conformance/Cardinality: MANDATORY (1) <p>A coded value 
         * denoting the importance of a detectable issue. Valid codes 
         * are: I - for Information, E - for Error, and W - for 
         * Warning.</p> <p>Allows the provider to make informed 
         * decision on the importance and criticality of an issue. May 
         * also be used by the DIS to determine the order of returning 
         * issues. Attribute is mandatory because every issue needs to 
         * be prioritized.</p> Un-merged Business Name: IssuePriority 
         * Relationship: 
         * PORX_MT980030CA.DetectedIssueEvent.priorityCode 
         * Conformance/Cardinality: MANDATORY (1) <p>A coded value 
         * denoting the importance of a detectable issue. Valid codes 
         * are: I - for Information, E - for Error, and W - for 
         * Warning.</p> <p>Allows the provider to make informed 
         * decision on the importance and criticality of an issue. May 
         * also be used by the DIS to determine the order of returning 
         * issues. Attribute is mandatory because every issue needs to 
         * be prioritized.</p> Un-merged Business Name: IssuePriority 
         * Relationship: 
         * PORX_MT980010CA.DetectedIssueEvent.priorityCode 
         * Conformance/Cardinality: MANDATORY (1) <p>A coded value 
         * denoting the importance of a detectable issue. Valid codes 
         * are: I - for Information, E - for Error, and W - for 
         * Warning.</p> <p>Allows the provider to make informed 
         * decision on the importance and criticality of an issue. May 
         * also be used by the DIS to determine the order of returning 
         * issues. Attribute is mandatory because every issue needs to 
         * be prioritized.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"priorityCode"})]
        public ActIssuePriority PriorityCode {
            get { return (ActIssuePriority) this.priorityCode.Value; }
            set { this.priorityCode.Value = value; }
        }

        /**
         * <summary>Business Name: CausalActs</summary>
         * 
         * <remarks>Un-merged Business Name: CausalActs Relationship: 
         * PORX_MT980020CA.Subject2.causalActs Conformance/Cardinality: 
         * POPULATED (1) <div>Although CeRx allows for</div> 
         * <div>ObservationMeasurableEvent components</div> <div>to be 
         * sent, since PIN does not support</div> <div>those at this 
         * time, this component will not</div> <div>be sent by PIN and 
         * can not be sent to PIN.</div> <div>PIN will never generate 
         * issues against</div> <div>SupplyEvents, so those will never 
         * be sent</div> <p>from PIN, although they can be sent to 
         * PIN.&nbsp;</p> Un-merged Business Name: (no business name 
         * specified) Relationship: PORX_MT980030CA.Subject2.causalActs 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: CausalActs Relationship: 
         * PORX_MT980010CA.Subject2.causalActs Conformance/Cardinality: 
         * POPULATED (1) <div>Although CeRx allows for</div> 
         * <div>ObservationMeasurableEvent components</div> <div>to be 
         * sent, since PIN does not support</div> <div>those at this 
         * time, this component will not</div> <div>be sent by PIN and 
         * can not be sent to PIN.</div> <div>PIN will never generate 
         * issues against</div> <div>SupplyEvents, so those will never 
         * be sent</div> <p>from PIN, although they can be sent to 
         * PIN.&nbsp;</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject/causalActs"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged.ICausalActs> SubjectCausalActs {
            get { return this.subjectCausalActs; }
        }

        /**
         * <summary>Business Name: IssueDescription</summary>
         * 
         * <remarks>Un-merged Business Name: IssueDescription 
         * Relationship: 
         * PORX_MT980020CA.Definition.detectedIssueDefinition 
         * Conformance/Cardinality: POPULATED (1) <div>This is the 
         * decision support rule that triggered</div> <p>the 
         * issue.&nbsp;</p> Un-merged Business Name: (no business name 
         * specified) Relationship: 
         * PORX_MT980030CA.Definition.detectedIssueDefinition 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT980010CA.Definition.detectedIssueDefinition 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"instantiation/detectedIssueDefinition"})]
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged.IssueDescription InstantiationDetectedIssueDefinition {
            get { return this.instantiationDetectedIssueDefinition; }
            set { this.instantiationDetectedIssueDefinition = value; }
        }

        /**
         * <summary>Business Name: ManagedBy</summary>
         * 
         * <remarks>Un-merged Business Name: ManagedBy Relationship: 
         * PORX_MT980020CA.Mitigates.detectedIssueManagement 
         * Conformance/Cardinality: POPULATED (1) <p>&nbsp;The 
         * processes and procedures employed by</p> <div>providers to 
         * resolve clinical conflicts between</div> <div>the action 
         * being performed and additional</div> <div>information 
         * already in the patient's record.</div> Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT980030CA.Mitigates.detectedIssueManagement 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: ManagedBy Relationship: 
         * PORX_MT980010CA.Mitigates.detectedIssueManagement 
         * Conformance/Cardinality: POPULATED (1) <div>The processes 
         * and procedures employed by</div> <div>providers to resolve 
         * clinical conflicts between</div> <div>the action being 
         * performed and additional</div> <p>information already in the 
         * patient's record.&nbsp;</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"mitigatedBy/detectedIssueManagement"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged.IssueManagements> MitigatedByDetectedIssueManagement {
            get { return this.mitigatedByDetectedIssueManagement; }
        }

        /**
         * <summary>Business Name: SeverityCode</summary>
         * 
         * <remarks>Un-merged Business Name: SeverityCode Relationship: 
         * PORX_MT980020CA.SeverityObservation.value 
         * Conformance/Cardinality: POPULATED (1) <p>A coded value 
         * denoting the gravity of the detected issue.</p> 
         * <p>Contraindication.severity</p><p>ZPE.3</p><p>MB.05.03A</p><p>Severity</p><p>ZDU.6.3</p><p>ZDU.8.4</p><p>A_DetectedMedicationIssue</p> 
         * <p>Contraindication.severity</p><p>ZPE.3</p><p>MB.05.03A</p><p>Severity</p><p>ZDU.6.3</p><p>ZDU.8.4</p><p>A_DetectedMedicationIssue</p> 
         * <p>Contraindication.severity</p><p>ZPE.3</p><p>MB.05.03A</p><p>Severity</p><p>ZDU.6.3</p><p>ZDU.8.4</p><p>A_DetectedMedicationIssue</p> 
         * <p>Contraindication.severity</p><p>ZPE.3</p><p>MB.05.03A</p><p>Severity</p><p>ZDU.6.3</p><p>ZDU.8.4</p><p>A_DetectedMedicationIssue</p> 
         * <p>Contraindication.severity</p><p>ZPE.3</p><p>MB.05.03A</p><p>Severity</p><p>ZDU.6.3</p><p>ZDU.8.4</p><p>A_DetectedMedicationIssue</p> 
         * <p>Contraindication.severity</p><p>ZPE.3</p><p>MB.05.03A</p><p>Severity</p><p>ZDU.6.3</p><p>ZDU.8.4</p><p>A_DetectedMedicationIssue</p> 
         * <p>Contraindication.severity</p><p>ZPE.3</p><p>MB.05.03A</p><p>Severity</p><p>ZDU.6.3</p><p>ZDU.8.4</p><p>A_DetectedMedicationIssue</p> 
         * <p>May be used to determine which issues must be managed and 
         * how.</p><p>This attribute is marked as &quot;populated&quot; 
         * to allow the use of null flavors.</p> <p>May be used to 
         * determine which issues must be managed and how.</p><p>This 
         * attribute is marked as &quot;populated&quot; to allow the 
         * use of null flavors.</p> Un-merged Business Name: 
         * SeverityCode Relationship: 
         * PORX_MT980030CA.SeverityObservation.value 
         * Conformance/Cardinality: POPULATED (1) <p>A coded value 
         * denoting the gravity of the detected issue.</p> 
         * <p>Contraindication.severity</p><p>ZPE.3</p><p>MB.05.03A</p><p>Severity</p><p>ZDU.6.3</p><p>ZDU.8.4</p><p>A_DetectedMedicationIssue</p> 
         * <p>Contraindication.severity</p><p>ZPE.3</p><p>MB.05.03A</p><p>Severity</p><p>ZDU.6.3</p><p>ZDU.8.4</p><p>A_DetectedMedicationIssue</p> 
         * <p>Contraindication.severity</p><p>ZPE.3</p><p>MB.05.03A</p><p>Severity</p><p>ZDU.6.3</p><p>ZDU.8.4</p><p>A_DetectedMedicationIssue</p> 
         * <p>Contraindication.severity</p><p>ZPE.3</p><p>MB.05.03A</p><p>Severity</p><p>ZDU.6.3</p><p>ZDU.8.4</p><p>A_DetectedMedicationIssue</p> 
         * <p>Contraindication.severity</p><p>ZPE.3</p><p>MB.05.03A</p><p>Severity</p><p>ZDU.6.3</p><p>ZDU.8.4</p><p>A_DetectedMedicationIssue</p> 
         * <p>Contraindication.severity</p><p>ZPE.3</p><p>MB.05.03A</p><p>Severity</p><p>ZDU.6.3</p><p>ZDU.8.4</p><p>A_DetectedMedicationIssue</p> 
         * <p>Contraindication.severity</p><p>ZPE.3</p><p>MB.05.03A</p><p>Severity</p><p>ZDU.6.3</p><p>ZDU.8.4</p><p>A_DetectedMedicationIssue</p> 
         * <p>May be used to determine which contraindications must be 
         * managed and how.</p><p>This attribute is marked as 
         * &quot;populated&quot; to allow for use of null flavors.</p> 
         * <p>May be used to determine which contraindications must be 
         * managed and how.</p><p>This attribute is marked as 
         * &quot;populated&quot; to allow for use of null flavors.</p> 
         * Un-merged Business Name: SeverityCode Relationship: 
         * PORX_MT980010CA.SeverityObservation.value 
         * Conformance/Cardinality: POPULATED (1) <p>A coded value 
         * denoting the gravity of the detected issue.</p> 
         * <p>Contraindication.severity</p><p>ZPE.3</p><p>MB.05.03A</p><p>Severity</p><p>ZDU.6.3</p><p>ZDU.8.4</p><p>A_DetectedMedicationIssue</p> 
         * <p>Contraindication.severity</p><p>ZPE.3</p><p>MB.05.03A</p><p>Severity</p><p>ZDU.6.3</p><p>ZDU.8.4</p><p>A_DetectedMedicationIssue</p> 
         * <p>Contraindication.severity</p><p>ZPE.3</p><p>MB.05.03A</p><p>Severity</p><p>ZDU.6.3</p><p>ZDU.8.4</p><p>A_DetectedMedicationIssue</p> 
         * <p>Contraindication.severity</p><p>ZPE.3</p><p>MB.05.03A</p><p>Severity</p><p>ZDU.6.3</p><p>ZDU.8.4</p><p>A_DetectedMedicationIssue</p> 
         * <p>Contraindication.severity</p><p>ZPE.3</p><p>MB.05.03A</p><p>Severity</p><p>ZDU.6.3</p><p>ZDU.8.4</p><p>A_DetectedMedicationIssue</p> 
         * <p>Contraindication.severity</p><p>ZPE.3</p><p>MB.05.03A</p><p>Severity</p><p>ZDU.6.3</p><p>ZDU.8.4</p><p>A_DetectedMedicationIssue</p> 
         * <p>Contraindication.severity</p><p>ZPE.3</p><p>MB.05.03A</p><p>Severity</p><p>ZDU.6.3</p><p>ZDU.8.4</p><p>A_DetectedMedicationIssue</p> 
         * <p>May be used to determine which contraindications must be 
         * managed and how.</p><p>This attribute is marked as 
         * &quot;populated&quot; to allow the use of null flavors.</p> 
         * <p>May be used to determine which contraindications must be 
         * managed and how.</p><p>This attribute is marked as 
         * &quot;populated&quot; to allow the use of null flavors.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf/severityObservation/value","subjectOf2/severityObservation/value"})]
        [Hl7MapByPartType(Name="subjectOf", Type="PORX_MT980010CA.Subject")]
        [Hl7MapByPartType(Name="subjectOf", Type="PORX_MT980030CA.Subject")]
        [Hl7MapByPartType(Name="subjectOf/severityObservation", Type="PORX_MT980010CA.SeverityObservation")]
        [Hl7MapByPartType(Name="subjectOf/severityObservation", Type="PORX_MT980030CA.SeverityObservation")]
        [Hl7MapByPartType(Name="subjectOf2", Type="PORX_MT980020CA.Subject")]
        [Hl7MapByPartType(Name="subjectOf2/severityObservation", Type="PORX_MT980020CA.SeverityObservation")]
        public SeverityObservation SubjectOfSeverityObservationValue {
            get { return (SeverityObservation) this.subjectOfSeverityObservationValue.Value; }
            set { this.subjectOfSeverityObservationValue.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: PORX_MT980020CA.Trigger2.actRequest 
         * Conformance/Cardinality: POPULATED (1) <p>&nbsp;Information 
         * that indicates whether or not a</p> <div>detected issue 
         * needs to be managed.</div></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"triggerFor/actRequest"})]
        public bool? TriggerForActRequest {
            get { return this.triggerForActRequest.Value; }
            set { this.triggerForActRequest.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT980020CA.Subject3.storageIntent 
         * Conformance/Cardinality: POPULATED (1) <div>Indicates that 
         * this issue will be persisted as</div> <div>part of the 
         * patient's record.</div></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf1/storageIntent"})]
        public bool? SubjectOf1StorageIntent {
            get { return this.subjectOf1StorageIntent.Value; }
            set { this.subjectOf1StorageIntent.Value = value; }
        }

    }

}