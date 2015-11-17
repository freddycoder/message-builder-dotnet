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
 * Author:        $LastChangedBy: tmcgrady $
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Porx_mt980010ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Issues</summary>
     * 
     * <p>Provides a list of issues that have been detected and/or 
     * managed.</p> <p>This is the list of clinical and business 
     * issues that have been detected and recorded involving the 
     * current action.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT980010CA.DetectedIssueEvent"})]
    public class Issues : MessagePartBean {

        private CV code;
        private ST text;
        private CV priorityCode;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Porx_mt980010ca.ICausalActs> subjectCausalActs;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.IssueDescription instantiationDetectedIssueDefinition;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.IssueManagements> mitigatedByDetectedIssueManagement;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Merged.AllergyIntoleranceSeverityLevel subjectOfSeverityObservation;

        public Issues() {
            this.code = new CVImpl();
            this.text = new STImpl();
            this.priorityCode = new CVImpl();
            this.subjectCausalActs = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Porx_mt980010ca.ICausalActs>();
            this.mitigatedByDetectedIssueManagement = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.IssueManagements>();
        }
        /**
         * <summary>Business Name: A:Issue Type</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT980010CA.DetectedIssueEvent.code 
         * Conformance/Cardinality: MANDATORY (1) 
         * <p>Contraindication.crossSensitive (if code is related 
         * reaction dected issue then crossSensitive is 'True')</p> 
         * <p>Distinguishes between DAI, DDI, DosageCheck, DPD, and 
         * Duplicate Therapy Contraindications</p> 
         * <p>Contraindication.DosageContraType</p> 
         * <p>OverrideReason.reasonDomain</p> <p>ZP3.3</p> <p>E06(for 
         * contraindications errors are handled at transmission or 
         * controlAct wrapper level)</p> <p>05.03D</p> <p>DUR Response 
         * Codes</p> <p>Interaction Type</p> <p>ZPS.7.1</p> 
         * <p>ZDU.9.1(PLYPHRM)</p> <p>ZDU.10.1 (PLYDOC)</p> 
         * <p>ZDU.6.2</p> <p>ZDU.6.4</p> <p>ZDU.7.3</p> 
         * <p>DRU.100-01</p> <p>DUR/PPS.439-E4</p> 
         * <p>A_DetectedMedicationIssue</p> <p>Identifies what kind of 
         * issue was detected or is being managed.</p><p>This is 
         * mandatory so as to ensure that one issue type can be 
         * distinguished from another.</p> <p>A coded value that is 
         * used to distinguish between different kinds of issues. Types 
         * of issue include: unrecognized identifiers, permission 
         * issues, drug-drug contraindications, drug-allergy alerts, 
         * duplicate therapies, etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActDetectedIssueCode Code {
            get { return (ActDetectedIssueCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: D:Issue Details</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT980010CA.DetectedIssueEvent.text 
         * Conformance/Cardinality: REQUIRED (0-1) 
         * <p>Contraindication.DDIDescription</p> <p>E20(for 
         * contraindication errors are handled at transmission or 
         * controlact wrapper level)</p> <p>ZPE.4</p> <p>ZDU.11.1</p> 
         * <p>Lets providers see textual explanation of the issue.</p> 
         * <p>A free form textual description of a detected issue. This 
         * textual information is provided to either augment the coded 
         * information or in place of the coded information.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public String Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Business Name: C:Issue Priority</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT980010CA.DetectedIssueEvent.priorityCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows the 
         * provider to make informed decision on the importance and 
         * criticality of an issue. May also be used by the DIS to 
         * determine the order of returning issues. Attribute is 
         * mandatory because every issue needs to be prioritized.</p> 
         * <p>A coded value denoting the importance of a detectable 
         * issue. Valid codes are: I - for Information, E - for Error, 
         * and W - for Warning.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"priorityCode"})]
        public ActIssuePriority PriorityCode {
            get { return (ActIssuePriority) this.priorityCode.Value; }
            set { this.priorityCode.Value = value; }
        }

        /**
         * <summary>Relationship: PORX_MT980010CA.Subject2.causalActs</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject/causalActs"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Porx_mt980010ca.ICausalActs> SubjectCausalActs {
            get { return this.subjectCausalActs; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT980010CA.Definition.detectedIssueDefinition</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"instantiation/detectedIssueDefinition"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.IssueDescription InstantiationDetectedIssueDefinition {
            get { return this.instantiationDetectedIssueDefinition; }
            set { this.instantiationDetectedIssueDefinition = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT980010CA.Mitigates.detectedIssueManagement</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"mitigatedBy/detectedIssueManagement"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.IssueManagements> MitigatedByDetectedIssueManagement {
            get { return this.mitigatedByDetectedIssueManagement; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT980010CA.Subject.severityObservation</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf/severityObservation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Merged.AllergyIntoleranceSeverityLevel SubjectOfSeverityObservation {
            get { return this.subjectOfSeverityObservation; }
            set { this.subjectOfSeverityObservation = value; }
        }

    }

}