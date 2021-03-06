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
namespace Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt090107ca;
    using System;


    /**
     * <summary>PORX_MT980010CA.Author1: *managed by</summary>
     * 
     * <p>Identifies the provider who managed the issue.</p> 
     * <p>OverrideReason.provider</p><p>ManagedContraindication.provider</p><p>A_DetectedMedicationIssue</p> 
     * <p>OverrideReason.provider</p><p>ManagedContraindication.provider</p><p>A_DetectedMedicationIssue</p> 
     * <p>OverrideReason.provider</p><p>ManagedContraindication.provider</p><p>A_DetectedMedicationIssue</p> 
     * <p>Part of the audit record and therefore mandatory.</p> 
     * PORX_MT060340CA.Author1: *changed by <p>Identity of the 
     * health service provider or application responsible for the 
     * change in the prescription status.</p> 
     * <p>PrescriptionStatus.provider</p> <p>In an EHR integrated 
     * health services environment, it is important that other 
     * providers are able to query who (or what application) is 
     * responsible for status changes. Also used by applications 
     * for auditing and sorting.</p><p>The attribute is marked as 
     * &quot;mandatory&quot; because provider or application 
     * maintaining the prescription must be known.</p> <p>In an EHR 
     * integrated health services environment, it is important that 
     * other providers are able to query who (or what application) 
     * is responsible for status changes. Also used by applications 
     * for auditing and sorting.</p><p>The attribute is marked as 
     * &quot;mandatory&quot; because provider or application 
     * maintaining the prescription must be known.</p> 
     * PORX_MT060160CA.Author1: *changed by <p>Identity of the 
     * health service provider or application responsible for the 
     * change in the prescription status.</p> 
     * <p>PrescriptionStatus.provider</p> <p>In an EHR integrated 
     * health services environment, it is important that other 
     * providers are able to query who (or what application) is 
     * responsible for status changes. Also used by applications 
     * for auditing and sorting.</p><p>The attribute is 
     * &quot;mandatory&quot; because provider or application 
     * maintaining the prescription must be known.</p> <p>In an EHR 
     * integrated health services environment, it is important that 
     * other providers are able to query who (or what application) 
     * is responsible for status changes. Also used by applications 
     * for auditing and sorting.</p><p>The attribute is 
     * &quot;mandatory&quot; because provider or application 
     * maintaining the prescription must be known.</p> 
     * PORX_MT980030CA.Author1: *managed by <p>Identifies the 
     * provider who managed the issue.</p> 
     * <p>OverrideReason.provider</p><p>ManagedContraindication.provider</p><p>A_DetectedMedicationIssue</p> 
     * <p>OverrideReason.provider</p><p>ManagedContraindication.provider</p><p>A_DetectedMedicationIssue</p> 
     * <p>OverrideReason.provider</p><p>ManagedContraindication.provider</p><p>A_DetectedMedicationIssue</p> 
     * <p>Part of the audit record and therefore mandatory.</p> 
     * PORX_MT060040CA.Author1: *changed by <p>Identity of the 
     * health service provider or application responsible for the 
     * change in the prescription status.</p> 
     * <p>PrescriptionStatus.provider</p> <p>In an EHR integrated 
     * health services environment, it is important that other 
     * providers are able to query who (or what application) is 
     * responsible for status changes. Also used by applications 
     * for auditing and sorting.</p><p>The attribute is mandatory 
     * because provider or application maintaining the prescription 
     * must be known.</p> <p>In an EHR integrated health services 
     * environment, it is important that other providers are able 
     * to query who (or what application) is responsible for status 
     * changes. Also used by applications for auditing and 
     * sorting.</p><p>The attribute is mandatory because provider 
     * or application maintaining the prescription must be 
     * known.</p> PORX_MT060210CA.Author7: *changed by <p>Identity 
     * of the health service provider or the application 
     * responsible for the change in the other medication 
     * status.</p> <p>In an EHR integrated health services 
     * environment, it is important that other providers are able 
     * to query who is responsible for status changes. Also used by 
     * applications for auditing and sorting. The attribute is 
     * marked as &quot;mandatory&quot; because provider or 
     * application maintaining the other medication must be 
     * known.</p> PORX_MT980020CA.Author1: managed by <p>Identifies 
     * the provider who created the management of the issue.</p> 
     * <p>OverrideReason.provider</p><p>ManagedContraindication.provider</p><p>A_DetectedMedicationIssue</p> 
     * <p>OverrideReason.provider</p><p>ManagedContraindication.provider</p><p>A_DetectedMedicationIssue</p> 
     * <p>OverrideReason.provider</p><p>ManagedContraindication.provider</p><p>A_DetectedMedicationIssue</p> 
     * <p>Part of the audit record, but may not always be known for 
     * historical managements.</p> PORX_MT060090CA.Author6: 
     * *changed by <p>Identity of the health service provider or 
     * the application responsible for the change in the 
     * prescription dispense status.</p> <p>In an EHR integrated 
     * health services environment, it is important that other 
     * providers are able to query who is responsible for status 
     * changes. Also used by applications for auditing and sorting. 
     * The attribute is mandatory because provider or application 
     * maintaining the prescription dispense must be known.</p> 
     * PORX_MT060010CA.Author6: *changed by <p>Identity of the 
     * health service provider or the application responsible for 
     * the change in the prescription dispense status.</p> <p>In an 
     * EHR integrated health services environment, it is important 
     * that other providers are able to query who is responsible 
     * for status changes. Also used by applications for auditing 
     * and sorting. The attribute is populated because provider or 
     * application maintaining the prescription dispense must be 
     * known else an appropriate 'null' flavor must be 
     * specified.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060010CA.Author6","PORX_MT060040CA.Author1","PORX_MT060090CA.Author6","PORX_MT060160CA.Author1","PORX_MT060210CA.Author7","PORX_MT060340CA.Author1","PORX_MT980010CA.Author1","PORX_MT980020CA.Author1","PORX_MT980030CA.Author1"})]
    public class ManagedBy : MessagePartBean {

        private TS time;
        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt090107ca.Provider assignedPerson;
        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged.IChangedBy changedBy;

        public ManagedBy() {
            this.time = new TSImpl();
        }
        /**
         * <summary>Un-merged Business Name: ManagementDate</summary>
         * 
         * <remarks>Relationship: PORX_MT980010CA.Author1.time 
         * Conformance/Cardinality: POPULATED (1) <p>The date and time 
         * on which the provider managed the issue.</p> 
         * <p>ManagedContraindication.CreationDate</p> <p>Part of the 
         * audit record, but not always available and therefore 
         * 'populated'.</p> Un-merged Business Name: ChangeTimestamp 
         * Relationship: PORX_MT060340CA.Author1.time 
         * Conformance/Cardinality: MANDATORY (1) <p>The date on which 
         * the change was made.</p> 
         * <p>PrescriptionStatus.effectiveDate</p> <p>Gives other 
         * providers the frame of reference in evaluating any 
         * post-change issues with the prescription. Also used for 
         * sorting and audit purposes.</p><p>The attribute is marked as 
         * &quot;mandatory&quot; because the time of change must be 
         * known.</p> <p>Gives other providers the frame of reference 
         * in evaluating any post-change issues with the prescription. 
         * Also used for sorting and audit purposes.</p><p>The 
         * attribute is marked as &quot;mandatory&quot; because the 
         * time of change must be known.</p> Un-merged Business Name: 
         * ChangeTimestamp Relationship: PORX_MT060160CA.Author1.time 
         * Conformance/Cardinality: MANDATORY (1) <p>The date and time 
         * at which the change was made.</p> 
         * <p>PrescriptionStatus.effectiveDate</p> <p>Gives other 
         * providers the frame of reference in evaluating any 
         * post-change issues with the prescription. Also used for 
         * sorting and audit purposes.</p><p>The attribute is marked as 
         * &quot;mandatory&quot; because the time of change must be 
         * known.</p> <p>Gives other providers the frame of reference 
         * in evaluating any post-change issues with the prescription. 
         * Also used for sorting and audit purposes.</p><p>The 
         * attribute is marked as &quot;mandatory&quot; because the 
         * time of change must be known.</p> Un-merged Business Name: 
         * ManagementDate Relationship: PORX_MT980030CA.Author1.time 
         * Conformance/Cardinality: POPULATED (1) <p>The date and time 
         * on which the provider managed the issue.</p> 
         * <p>ManagedContraindication.CreationDate</p> <p>Part of the 
         * audit record, but not always available and therefore 
         * 'populated'.</p> Un-merged Business Name: ChangeTimestamp 
         * Relationship: PORX_MT060040CA.Author1.time 
         * Conformance/Cardinality: MANDATORY (1) <p>The date on which 
         * the change was made.</p> 
         * <p>PrescriptionStatus.effectiveDate</p> <p>Gives other 
         * providers the frame of reference in evaluating any 
         * post-change issues with the prescription. Also used for 
         * sorting and audit purposes.</p><p>This attribute is marked 
         * as &quot;mandatory&quot; as the time the comment was posted 
         * will always be known.</p> <p>Gives other providers the frame 
         * of reference in evaluating any post-change issues with the 
         * prescription. Also used for sorting and audit 
         * purposes.</p><p>This attribute is marked as 
         * &quot;mandatory&quot; as the time the comment was posted 
         * will always be known.</p> Un-merged Business Name: 
         * ChangeTimestamp Relationship: PORX_MT060210CA.Author7.time 
         * Conformance/Cardinality: MANDATORY (1) <p>The date and time 
         * at which the change was made.</p> <p>Gives other providers 
         * the frame of reference in evaluating any post-change issues 
         * with the other medication. Also used for sorting and audit 
         * purposes.</p><p>Attribute is marked as &quot;mandatory&quot; 
         * as the time of change must be known.</p> <p>Gives other 
         * providers the frame of reference in evaluating any 
         * post-change issues with the other medication. Also used for 
         * sorting and audit purposes.</p><p>Attribute is marked as 
         * &quot;mandatory&quot; as the time of change must be 
         * known.</p> Un-merged Business Name: ManagementDate 
         * Relationship: PORX_MT980020CA.Author1.time 
         * Conformance/Cardinality: POPULATED (1) <p>The date and time 
         * on which the provider used this management for the issue in 
         * the past.</p> <p>ManagedContraindication.CreationDate</p> 
         * <p>Part of the audit record but not always available and 
         * therefore only marked as 'populated'.</p> Un-merged Business 
         * Name: ChangeTimestamp Relationship: 
         * PORX_MT060010CA.Author6.time Conformance/Cardinality: 
         * REQUIRED (0-1) <p>The date and time at which the change was 
         * made.</p> <p>Gives other providers the frame of reference in 
         * evaluating any post-change issues with the prescription 
         * dispense. Also used for sorting and audit purposes.</p> 
         * Un-merged Business Name: ChangeTimestamp Relationship: 
         * PORX_MT060090CA.Author6.time Conformance/Cardinality: 
         * MANDATORY (1) <p>The date and time at which the change was 
         * made.</p> <p>Gives other providers the frame of reference in 
         * evaluating any post-change issues with the prescription 
         * dispense. Also used for sorting and audit 
         * purposes.</p><p>The attribute is mandatory as the time of 
         * change is known.</p> <p>Gives other providers the frame of 
         * reference in evaluating any post-change issues with the 
         * prescription dispense. Also used for sorting and audit 
         * purposes.</p><p>The attribute is mandatory as the time of 
         * change is known.</p></remarks>
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
         * <remarks>Relationship: 
         * PORX_MT980010CA.Author1.assignedPerson 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT980030CA.Author1.assignedPerson 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT980020CA.Author1.assignedPerson 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"assignedPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt090107ca.Provider AssignedPerson {
            get { return this.assignedPerson; }
            set { this.assignedPerson = value; }
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
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged.IChangedBy ChangedBy {
            get { return this.changedBy; }
            set { this.changedBy = value; }
        }

    }

}