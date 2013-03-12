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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged;
    using System;


    /**
     * <summary>Business Name: IssueManagements</summary>
     * 
     * <remarks>COCT_MT260030CA.DetectedIssueManagement: Issue 
     * Managements <p>A_DetectedMedicationIssue</p> <p>It allows 
     * overriding of the detected issue</p> <p>The processes and 
     * procedures employed by providers to resolve clinical and 
     * business issues between the action being performed and 
     * additional information already in the patient's record or 
     * system business rules.</p> 
     * COCT_MT260012CA.DetectedIssueManagement: Issue Managements 
     * <p>A_DetectedMedicationIssue</p> <p>It allows overriding of 
     * the detected issue</p> <p>The processes and procedures 
     * employed by providers to resolve clinical and business 
     * issues between the action being performed and additional 
     * information already in the patient's record or system 
     * business rules.</p> COCT_MT260022CA.DetectedIssueManagement: 
     * Issue Managements <p>A_DetectedMedicationIssue</p> 
     * <p>Presents alternatives for how the issue could be managed 
     * or has been managed in the past.</p> <p>The processes and 
     * procedures employed by providers to resolve clinical 
     * conflicts between the action being performed and additional 
     * information already in the patient's record.</p> 
     * COCT_MT260010CA.DetectedIssueManagement: Issue Managements 
     * <p>A_DetectedMedicationIssue</p> <p>It allows overriding of 
     * the detected issue</p> <p>The processes and procedures 
     * employed by providers to resolve clinical and business 
     * issues between the action being performed and additional 
     * information already in the patient's record or system 
     * business rules.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT260010CA.DetectedIssueManagement","COCT_MT260012CA.DetectedIssueManagement","COCT_MT260020CA.DetectedIssueManagement","COCT_MT260022CA.DetectedIssueManagement","COCT_MT260030CA.DetectedIssueManagement"})]
    public class IssueManagements : MessagePartBean {

        private CV code;
        private ST text;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.PrescribedBy author;

        public IssueManagements() {
            this.code = new CVImpl();
            this.text = new STImpl();
        }
        /**
         * <summary>Business Name: ManagementType</summary>
         * 
         * <remarks>Un-merged Business Name: ManagementType 
         * Relationship: COCT_MT260020CA.DetectedIssueManagement.code 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: ManagementType Relationship: 
         * COCT_MT260012CA.DetectedIssueManagement.code 
         * Conformance/Cardinality: MANDATORY (1) 
         * <p>ManagedContraindication.State</p> 
         * <p>OverrideReason.reason</p> <p>D65(when dealing with 
         * clinical indication overrides, otherwise use overrides in 
         * ControlAct wrapper.</p> <p>ZPB3.10</p> <p>Intervention 
         * Codes</p> <p>ZPS.8</p> <p>ZPS.15</p> <p>ZDP.21.1</p> 
         * <p>DRU.100-02</p> <p>DRU.100-03</p> <p>DUR/PPS.440-E6</p> 
         * <p>DUR/PPS.441-E6</p> <p>Claim.420-DK</p> 
         * <p>A_DetectedMedicationIssue</p> <p>Ensures consistency in 
         * description of management actions.</p><p>This is mandatory 
         * so as to ensure distinction between different kinds of 
         * management.</p> <p>Indicates the kinds of management actions 
         * that have been taken, depending on the issue type.</p> 
         * Un-merged Business Name: ManagementType Relationship: 
         * COCT_MT260030CA.DetectedIssueManagement.code 
         * Conformance/Cardinality: MANDATORY (1) 
         * <p>ManagedContraindication.State</p> 
         * <p>OverrideReason.reason</p> <p>D65(when dealing with 
         * clinical indication overrides, otherwise use overrides in 
         * ControlAct wrapper.</p> <p>ZPB3.10</p> <p>Intervention 
         * Codes</p> <p>ZPS.8</p> <p>ZPS.15</p> <p>ZDP.21.1</p> 
         * <p>DRU.100-02</p> <p>DRU.100-03</p> <p>DUR/PPS.440-E6</p> 
         * <p>DUR/PPS.441-E6</p> <p>Claim.420-DK</p> 
         * <p>A_DetectedMedicationIssue</p> <p>Ensures consistency in 
         * description of management actions.</p><p>This is mandatory 
         * so as to ensure distinction between different kinds of 
         * management.</p> <p>Indicates the kinds of management actions 
         * that have been taken, depending on the issue type.</p> 
         * Un-merged Business Name: ManagementType Relationship: 
         * COCT_MT260022CA.DetectedIssueManagement.code 
         * Conformance/Cardinality: MANDATORY (1) 
         * <p>ManagedContraindication.State</p> 
         * <p>OverrideReason.reason</p> <p>D65(when dealing with 
         * clinical indication overrides, otherwise use overrides in 
         * ControlAct wrapper.</p> <p>ZPB3.10</p> <p>Intervention 
         * Codes</p> <p>ZPS.8</p> <p>ZPS.15</p> <p>ZDP.21.1</p> 
         * <p>DRU.100-02</p> <p>DRU.100-03</p> <p>DUR/PPS.440-E6</p> 
         * <p>DUR/PPS.441-E6</p> <p>Claim.420-DK</p> 
         * <p>A_DetectedMedicationIssue</p> <p>Ensures consistency in 
         * description of management actions.</p><p>This is mandatory 
         * so as to ensure distinction between different kinds of 
         * management.</p> <p>Indicates the kinds of management actions 
         * that can be taken, based on the issue type.</p> Un-merged 
         * Business Name: ManagementType Relationship: 
         * COCT_MT260010CA.DetectedIssueManagement.code 
         * Conformance/Cardinality: MANDATORY (1) 
         * <p>ManagedContraindication.State</p> 
         * <p>OverrideReason.reason</p> <p>D65(when dealing with 
         * clinical indication overrides, otherwise use overrides in 
         * ControlAct wrapper.</p> <p>ZPB3.10</p> <p>Intervention 
         * Codes</p> <p>ZPS.8</p> <p>ZPS.15</p> <p>ZDP.21.1</p> 
         * <p>DRU.100-02</p> <p>DRU.100-03</p> <p>DUR/PPS.440-E6</p> 
         * <p>DUR/PPS.441-E6</p> <p>Claim.420-DK</p> 
         * <p>A_DetectedMedicationIssue</p> <p>Ensures consistency in 
         * description of management actions.</p><p>This is mandatory 
         * so as to ensure distinction between different kinds of 
         * management.</p> <p>Indicates the kinds of management actions 
         * that have been taken, depending on the issue type.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActDetectedIssueManagementCode Code {
            get { return (ActDetectedIssueManagementCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: ManagementDescription</summary>
         * 
         * <remarks>Un-merged Business Name: ManagementDescription 
         * Relationship: COCT_MT260020CA.DetectedIssueManagement.text 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: ManagementDescription Relationship: 
         * COCT_MT260012CA.DetectedIssueManagement.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows additional 
         * clinical detail to be conveyed that are important clinically 
         * and not conveyed by the code.</p> <p>Additional free-text 
         * details describing the management of the issue.</p> 
         * Un-merged Business Name: ManagementDescription Relationship: 
         * COCT_MT260030CA.DetectedIssueManagement.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows additional 
         * clinical detail to be conveyed that are important clinically 
         * and not conveyed by the code.</p> <p>Additional free-text 
         * details describing the management of the issue.</p> 
         * Un-merged Business Name: ManagementDescription Relationship: 
         * COCT_MT260022CA.DetectedIssueManagement.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows additional 
         * clinical detail to be conveyed that are important clinically 
         * and not conveyed by the code.</p> <p>Additional free-text 
         * details describing the management of the issue.</p> 
         * Un-merged Business Name: ManagementDescription Relationship: 
         * COCT_MT260010CA.DetectedIssueManagement.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows additional 
         * clinical detail to be conveyed that are important clinically 
         * and not conveyed by the code.</p> <p>Additional free-text 
         * details describing the management of the issue.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public String Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT260020CA.DetectedIssueManagement.author 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * COCT_MT260012CA.DetectedIssueManagement.author 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * COCT_MT260030CA.DetectedIssueManagement.author 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * COCT_MT260022CA.DetectedIssueManagement.author 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * COCT_MT260010CA.DetectedIssueManagement.author 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.PrescribedBy Author {
            get { return this.author; }
            set { this.author = value; }
        }

    }

}