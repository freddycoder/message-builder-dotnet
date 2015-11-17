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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt260020ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged;
    using System;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT260020CA.DetectedIssueEvent"})]
    public class DetectedIssueEvent : MessagePartBean {

        private CV code;
        private ST text;
        private CV priorityCode;
        private SET<ST, String> targetSiteCode;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt260020ca.ICausalActs> subjectCausalActs;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.IssueDescription instantiationDetectedIssueDefinition;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.IssueManagements_2> mitigatedByDetectedIssueManagement;
        private BL triggerForActRequest;
        private BL subjectOf1StorageIntent;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.AllergyIntoleranceSeverityLevel subjectOf2SeverityObservation;

        public DetectedIssueEvent() {
            this.code = new CVImpl();
            this.text = new STImpl();
            this.priorityCode = new CVImpl();
            this.targetSiteCode = new SETImpl<ST, String>(typeof(STImpl));
            this.subjectCausalActs = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt260020ca.ICausalActs>();
            this.mitigatedByDetectedIssueManagement = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.IssueManagements_2>();
            this.triggerForActRequest = new BLImpl(false);
            this.subjectOf1StorageIntent = new BLImpl(false);
        }
        /**
         * <summary>Business Name: A:Issue Type</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT260020CA.DetectedIssueEvent.code 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
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
         * COCT_MT260020CA.DetectedIssueEvent.text 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
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
         * COCT_MT260020CA.DetectedIssueEvent.priorityCode 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"priorityCode"})]
        public ActIssuePriority PriorityCode {
            get { return (ActIssuePriority) this.priorityCode.Value; }
            set { this.priorityCode.Value = value; }
        }

        /**
         * <summary>Business Name: Message Issue Location</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT260020CA.DetectedIssueEvent.targetSiteCode 
         * Conformance/Cardinality: REQUIRED (0-5) <p>Used to identify 
         * XPath references that indicate which attributes from the 
         * message instance were involved in the issue.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"targetSiteCode"})]
        public ICollection<String> TargetSiteCode {
            get { return this.targetSiteCode.RawSet(); }
        }

        /**
         * <summary>Relationship: COCT_MT260020CA.Subject2.causalActs</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject/causalActs"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt260020ca.ICausalActs> SubjectCausalActs {
            get { return this.subjectCausalActs; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT260020CA.Definition.detectedIssueDefinition</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"instantiation/detectedIssueDefinition"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.IssueDescription InstantiationDetectedIssueDefinition {
            get { return this.instantiationDetectedIssueDefinition; }
            set { this.instantiationDetectedIssueDefinition = value; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT260020CA.Mitigates.detectedIssueManagement</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"mitigatedBy/detectedIssueManagement"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.IssueManagements_2> MitigatedByDetectedIssueManagement {
            get { return this.mitigatedByDetectedIssueManagement; }
        }

        /**
         * <summary>Relationship: COCT_MT260020CA.Trigger2.actRequest</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"triggerFor/actRequest"})]
        public bool? TriggerForActRequest {
            get { return this.triggerForActRequest.Value; }
            set { this.triggerForActRequest.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT260020CA.Subject3.storageIntent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf1/storageIntent"})]
        public bool? SubjectOf1StorageIntent {
            get { return this.subjectOf1StorageIntent.Value; }
            set { this.subjectOf1StorageIntent.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT260020CA.Subject.severityObservation</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2/severityObservation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.AllergyIntoleranceSeverityLevel SubjectOf2SeverityObservation {
            get { return this.subjectOf2SeverityObservation; }
            set { this.subjectOf2SeverityObservation = value; }
        }

    }

}