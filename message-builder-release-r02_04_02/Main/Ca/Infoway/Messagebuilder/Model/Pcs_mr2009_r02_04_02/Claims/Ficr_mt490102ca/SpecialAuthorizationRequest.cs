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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt490102ca {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged;
    using System;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT490102CA.SpecialAuthorizationRequest"})]
    public class SpecialAuthorizationRequest : MessagePartBean {

        private II id;
        private CV code;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private CV priorityCode;
        private SET<CV, Code> confidentialityCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.HealthcareWorker authorAssignedEntity;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.SpecialAuthorizationRequestCrossReference predecessorSpecialAuthorizationRequestCrossReference;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt490102ca.SpecialAuthorizationCriteria> supportSpecialAuthorizationCriteria;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.Subject3 subject1;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.Subject5> subject2;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt490102ca.PolicyOrAccount coveragePolicyOrAccount;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.HealthDocumentAttachment_1> pertinentInformationHealthDocumentAttachment;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt490102ca.SpecialAuthorization fulfillmentSpecialAuthorization;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.Includes> subjectOf;

        public SpecialAuthorizationRequest() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.priorityCode = new CVImpl();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.supportSpecialAuthorizationCriteria = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt490102ca.SpecialAuthorizationCriteria>();
            this.subject2 = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.Subject5>();
            this.pertinentInformationHealthDocumentAttachment = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.HealthDocumentAttachment_1>();
            this.subjectOf = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.Includes>();
        }
        /**
         * <summary>Business Name: Special Authority Request ID</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT490102CA.SpecialAuthorizationRequest.id 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: Special Authorization Request Type</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT490102CA.SpecialAuthorizationRequest.code 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActSpecialAuthorizationCode Code {
            get { return (ActSpecialAuthorizationCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Special Authorization Request 
         * Effective Date</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT490102CA.SpecialAuthorizationRequest.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: Special Authorization Priority Code</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT490102CA.SpecialAuthorizationRequest.priorityCode 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"priorityCode"})]
        public ActPriority PriorityCode {
            get { return (ActPriority) this.priorityCode.Value; }
            set { this.priorityCode.Value = value; }
        }

        /**
         * <summary>Business Name: Confidentiality Restriction(s</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT490102CA.SpecialAuthorizationRequest.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-2)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_VeryBasicConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_VeryBasicConfidentialityKind>(); }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT490102CA.Author2.assignedEntity</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.HealthcareWorker AuthorAssignedEntity {
            get { return this.authorAssignedEntity; }
            set { this.authorAssignedEntity = value; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT490102CA.Predecessor.specialAuthorizationRequestCrossReference</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"predecessor/specialAuthorizationRequestCrossReference"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.SpecialAuthorizationRequestCrossReference PredecessorSpecialAuthorizationRequestCrossReference {
            get { return this.predecessorSpecialAuthorizationRequestCrossReference; }
            set { this.predecessorSpecialAuthorizationRequestCrossReference = value; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT490102CA.Support2.specialAuthorizationCriteria</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"support/specialAuthorizationCriteria"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt490102ca.SpecialAuthorizationCriteria> SupportSpecialAuthorizationCriteria {
            get { return this.supportSpecialAuthorizationCriteria; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT490102CA.SpecialAuthorizationRequest.subject1</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject1"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.Subject3 Subject1 {
            get { return this.subject1; }
            set { this.subject1 = value; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT490102CA.SpecialAuthorizationRequest.subject2</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-20)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject2"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.Subject5> Subject2 {
            get { return this.subject2; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT490102CA.Coverage.policyOrAccount</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"coverage/policyOrAccount"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt490102ca.PolicyOrAccount CoveragePolicyOrAccount {
            get { return this.coveragePolicyOrAccount; }
            set { this.coveragePolicyOrAccount = value; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT490102CA.PertinentInformation.healthDocumentAttachment</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"pertinentInformation/healthDocumentAttachment"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.HealthDocumentAttachment_1> PertinentInformationHealthDocumentAttachment {
            get { return this.pertinentInformationHealthDocumentAttachment; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT490102CA.InFulfillmentOf.specialAuthorization</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"fulfillment/specialAuthorization"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt490102ca.SpecialAuthorization FulfillmentSpecialAuthorization {
            get { return this.fulfillmentSpecialAuthorization; }
            set { this.fulfillmentSpecialAuthorization = value; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT490102CA.SpecialAuthorizationRequest.subjectOf</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-100)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.Includes> SubjectOf {
            get { return this.subjectOf; }
        }

    }

}