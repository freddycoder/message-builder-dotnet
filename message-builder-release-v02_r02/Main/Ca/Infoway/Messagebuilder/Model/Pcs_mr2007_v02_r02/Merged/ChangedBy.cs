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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Coct_mt911108ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pharmacy.Merged;
    using System;


    /**
     * <summary>PORX_MT060340CA.Author1: *changed by</summary>
     * 
     * <p>In an EHR integrated health services environment, it is 
     * important that other providers are able to query who (or 
     * what application) is responsible for status changes. Also 
     * used by applications for auditing and sorting.</p><p>The 
     * attribute is marked as &quot;mandatory&quot; because 
     * provider or application maintaining the prescription must be 
     * known.</p> <p>Identity of the health service provider or 
     * application responsible for the change in the prescription 
     * status.</p> COCT_MT260022CA.Author1: managed by 
     * <p>OverrideReason.provider</p> 
     * <p>ManagedContraindication.provider</p> 
     * <p>A_DetectedMedicationIssue</p> <p>Part of the audit 
     * record, but may not always be known for historical 
     * managements.</p> <p>Identifies the provider who created the 
     * management of the issue.</p> COCT_MT260012CA.Author1: 
     * *managed by <p>OverrideReason.provider</p> 
     * <p>ManagedContraindication.provider</p> 
     * <p>A_DetectedMedicationIssue</p> <p>Part of the audit record 
     * and therefore mandatory.</p> <p>Identifies the provider who 
     * managed the issue.</p> PORX_MT060090CA.Author6: *changed by 
     * <p>In an EHR integrated health services environment, it is 
     * important that other providers are able to query who is 
     * responsible for status changes. Also used by applications 
     * for auditing and sorting. The attribute is mandatory because 
     * provider or application maintaining the prescription 
     * dispense must be known.</p> <p>Identity of the health 
     * service provider or the application responsible for the 
     * change in the prescription dispense status.</p> 
     * COCT_MT130001CA.Author3: *changed by <p>In an EHR integrated 
     * health services environment, it is important that other 
     * providers are able to query who is responsible for a given 
     * change. Also used by applications for auditing and sorting. 
     * The attribute is mandatory because the responsible provider 
     * should always be known.</p> <p>Identity of the health 
     * service provider responsible for the change.</p> 
     * PORX_MT060160CA.Author1: *changed by <p>In an EHR integrated 
     * health services environment, it is important that other 
     * providers are able to query who (or what application) is 
     * responsible for status changes. Also used by applications 
     * for auditing and sorting.</p><p>The attribute is 
     * &quot;mandatory&quot; because provider or application 
     * maintaining the prescription must be known.</p> <p>Identity 
     * of the health service provider or application responsible 
     * for the change in the prescription status.</p> 
     * COCT_MT260030CA.Author1: *managed by 
     * <p>OverrideReason.provider</p> 
     * <p>ManagedContraindication.provider</p> 
     * <p>A_DetectedMedicationIssue</p> <p>Part of the audit record 
     * and therefore mandatory.</p> <p>Identifies the provider who 
     * managed the issue.</p> REPC_MT000009CA.Author3: *changed by 
     * <p>In an EHR integrated health services environment, it is 
     * important that other providers are able to query who is 
     * responsible for a given change. Also used by applications 
     * for auditing and sorting. The attribute is mandatory because 
     * the responsible provider should always be known.</p> 
     * <p>Identity of the health service provider responsible for 
     * the change in the allergy/intolerance status.</p> 
     * COCT_MT260020CA.Author1: managed by 
     * <p>OverrideReason.provider</p> 
     * <p>ManagedContraindication.provider</p> 
     * <p>A_DetectedMedicationIssue</p> <p>Part of the audit 
     * record, but may not always be known for historical 
     * managements.</p> <p>Identifies the provider who created the 
     * management of the issue.</p> PORX_MT060040CA.Author1: 
     * *changed by <p>In an EHR integrated health services 
     * environment, it is important that other providers are able 
     * to query who (or what application) is responsible for status 
     * changes. Also used by applications for auditing and 
     * sorting.</p><p>The attribute is mandatory because provider 
     * or application maintaining the prescription must be 
     * known.</p> <p>Identity of the health service provider or 
     * application responsible for the change in the prescription 
     * status.</p> PORX_MT060210CA.Author7: *changed by <p>In an 
     * EHR integrated health services environment, it is important 
     * that other providers are able to query who is responsible 
     * for status changes. Also used by applications for auditing 
     * and sorting. The attribute is marked as 
     * &quot;mandatory&quot; because provider or application 
     * maintaining the other medication must be known.</p> 
     * <p>Identity of the health service provider or the 
     * application responsible for the change in the other 
     * medication status.</p> COCT_MT260010CA.Author1: *managed by 
     * <p>OverrideReason.provider</p> 
     * <p>ManagedContraindication.provider</p> 
     * <p>A_DetectedMedicationIssue</p> <p>Part of the audit record 
     * and therefore mandatory.</p> <p>Identifies the provider who 
     * managed the issue.</p> PORX_MT060010CA.Author6: *changed by 
     * <p>In an EHR integrated health services environment, it is 
     * important that other providers are able to query who is 
     * responsible for status changes. Also used by applications 
     * for auditing and sorting.</p><p>The attribute is populated 
     * because provider or application maintaining the prescription 
     * dispense must be known else an appropriate 'null' flavor 
     * must be specified.</p> <p>Identity of the health service 
     * provider or the application responsible for the change in 
     * the prescription dispense status.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT130001CA.Author3","COCT_MT260010CA.Author1","COCT_MT260012CA.Author1","COCT_MT260020CA.Author1","COCT_MT260022CA.Author1","COCT_MT260030CA.Author1","PORX_MT060010CA.Author6","PORX_MT060040CA.Author1","PORX_MT060090CA.Author6","PORX_MT060160CA.Author1","PORX_MT060210CA.Author7","PORX_MT060340CA.Author1","REPC_MT000009CA.Author3"})]
    public class ChangedBy : MessagePartBean {

        private TS time;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pharmacy.Merged.IChangedBy changedByValue;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Merged.HealthcareWorker assignedEntity;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Coct_mt911108ca.IActingPerson actingPerson;

        public ChangedBy() {
            this.time = new TSImpl();
        }
        /**
         * <summary>Un-merged Business Name: ChangeTimestamp</summary>
         * 
         * <remarks>Relationship: PORX_MT060340CA.Author1.time 
         * Conformance/Cardinality: MANDATORY (1) <p>Gives other 
         * providers the frame of reference in evaluating any 
         * post-change issues with the prescription. Also used for 
         * sorting and audit purposes.</p><p>The attribute is marked as 
         * &quot;mandatory&quot; because the time of change must be 
         * known.</p> <p>The date on which the change was made.</p> 
         * Un-merged Business Name: ManagementDate Relationship: 
         * COCT_MT260022CA.Author1.time Conformance/Cardinality: 
         * POPULATED (1) <p>ManagedContraindication.CreationDate</p> 
         * <p>Part of the audit record but not always available and 
         * therefore only marked as 'populated'.</p> <p>The date and 
         * time on which the provider used this management for the 
         * issue in the past.</p> Un-merged Business Name: 
         * ManagementDate Relationship: COCT_MT260012CA.Author1.time 
         * Conformance/Cardinality: POPULATED (1) 
         * <p>ManagedContraindication.CreationDate</p> <p>Part of the 
         * audit record, but not always available and therefore 
         * 'populated'.</p> <p>The date and time on which the provider 
         * managed the issue.</p> Un-merged Business Name: 
         * ChangeTimestamp Relationship: PORX_MT060090CA.Author6.time 
         * Conformance/Cardinality: MANDATORY (1) <p>Gives other 
         * providers the frame of reference in evaluating any 
         * post-change issues with the prescription dispense. Also used 
         * for sorting and audit purposes.</p><p>The attribute is 
         * mandatory as the time of change is known.</p> <p>The date 
         * and time at which the change was made.</p> Un-merged 
         * Business Name: ChangeDatetime Relationship: 
         * COCT_MT130001CA.Author3.time Conformance/Cardinality: 
         * MANDATORY (1) <p>Gives other providers the frame of 
         * reference in evaluating any post-change issues with the 
         * event. Also used for sorting and audit purposes. Time of 
         * change is always known and thus the attribute is 
         * mandatory.</p> <p>The date on which the change was made. 
         * Note that this may be earlier or occassionally later than 
         * when the change is actually effective.</p> Un-merged 
         * Business Name: ChangeTimestamp Relationship: 
         * PORX_MT060160CA.Author1.time Conformance/Cardinality: 
         * MANDATORY (1) <p>Gives other providers the frame of 
         * reference in evaluating any post-change issues with the 
         * prescription. Also used for sorting and audit 
         * purposes.</p><p>The attribute is marked as 
         * &quot;mandatory&quot; because the time of change must be 
         * known.</p> <p>The date and time at which the change was 
         * made.</p> Un-merged Business Name: ManagementDate 
         * Relationship: COCT_MT260030CA.Author1.time 
         * Conformance/Cardinality: POPULATED (1) 
         * <p>ManagedContraindication.CreationDate</p> <p>Part of the 
         * audit record, but not always available and therefore 
         * 'populated'.</p> <p>The date and time on which the provider 
         * managed the issue.</p> Un-merged Business Name: ChangeTime 
         * Relationship: REPC_MT000009CA.Author3.time 
         * Conformance/Cardinality: MANDATORY (1) <p>Gives other 
         * providers the frame of reference in evaluating any 
         * post-change issues with the allergy. Also used for sorting 
         * and audit purposes. Time of change is always known and thus 
         * the attribute is mandatory.</p> <p>The date on which the 
         * change was made.</p> Un-merged Business Name: ManagementDate 
         * Relationship: COCT_MT260020CA.Author1.time 
         * Conformance/Cardinality: POPULATED (1) 
         * <p>ManagedContraindication.CreationDate</p> <p>Part of the 
         * audit record but not always available and therefore only 
         * marked as 'populated'.</p> <p>The date and time on which the 
         * provider used this management for the issue in the past.</p> 
         * Un-merged Business Name: ChangeTimestamp Relationship: 
         * PORX_MT060040CA.Author1.time Conformance/Cardinality: 
         * MANDATORY (1) <p>Gives other providers the frame of 
         * reference in evaluating any post-change issues with the 
         * prescription. Also used for sorting and audit 
         * purposes.</p><p>This attribute is marked as 
         * &quot;mandatory&quot; as the time the comment was posted 
         * will always be known.</p> <p>The date on which the change 
         * was made.</p> Un-merged Business Name: ChangeTimestamp 
         * Relationship: PORX_MT060210CA.Author7.time 
         * Conformance/Cardinality: MANDATORY (1) <p>Gives other 
         * providers the frame of reference in evaluating any 
         * post-change issues with the other medication. Also used for 
         * sorting and audit purposes.</p><p>Attribute is marked as 
         * &quot;mandatory&quot; as the time of change must be 
         * known.</p> <p>The date and time at which the change was 
         * made.</p> Un-merged Business Name: ManagementDate 
         * Relationship: COCT_MT260010CA.Author1.time 
         * Conformance/Cardinality: POPULATED (1) 
         * <p>ManagedContraindication.CreationDate</p> <p>Part of the 
         * audit record, but not always available and therefore 
         * 'populated'.</p> <p>The date and time on which the provider 
         * managed the issue.</p> Un-merged Business Name: 
         * ChangeTimestamp Relationship: PORX_MT060010CA.Author6.time 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Gives other 
         * providers the frame of reference in evaluating any 
         * post-change issues with the prescription dispense. Also used 
         * for sorting and audit purposes.</p> <p>The date and time at 
         * which the change was made.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"time"})]
        public PlatformDate Time {
            get { return this.time.Value; }
            set { this.time.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: PORX_MT060340CA.Author1.changedBy 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060160CA.Author1.changedBy Conformance/Cardinality: 
         * MANDATORY (1) Un-merged Business Name: (no business name 
         * specified) Relationship: PORX_MT060040CA.Author1.changedBy 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060210CA.Author7.changedBy Conformance/Cardinality: 
         * MANDATORY (1) Un-merged Business Name: (no business name 
         * specified) Relationship: PORX_MT060010CA.Author6.changedBy 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060090CA.Author6.changedBy Conformance/Cardinality: 
         * MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"changedBy"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pharmacy.Merged.IChangedBy ChangedByValue {
            get { return this.changedByValue; }
            set { this.changedByValue = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT260022CA.Author1.assignedEntity 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000009CA.Author3.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * COCT_MT260030CA.Author1.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * COCT_MT260020CA.Author1.assignedEntity 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * COCT_MT260010CA.Author1.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * COCT_MT260012CA.Author1.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Merged.HealthcareWorker AssignedEntity {
            get { return this.assignedEntity; }
            set { this.assignedEntity = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: COCT_MT130001CA.Author3.actingPerson 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"actingPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Coct_mt911108ca.IActingPerson ActingPerson {
            get { return this.actingPerson; }
            set { this.actingPerson = value; }
        }

    }

}