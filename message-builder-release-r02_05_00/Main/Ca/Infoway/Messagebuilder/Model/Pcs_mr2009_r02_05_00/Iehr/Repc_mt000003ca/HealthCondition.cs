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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Repc_mt000003ca {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt011001ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt050207ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt090508ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt911107ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt090108ca;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Health Condition</summary>
     * 
     * <p>Necessary component of a person's overall profile. Helps 
     * with contraindication checking.</p> <p>A record of a 
     * patient's health condition, as tracked over time. Examples 
     * include diseases, disabilities, pregnancy, lactation and 
     * other clinical conditions of interest.</p><p>Also known as 
     * &quot;Problem&quot; (from a 'problem list').</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT000003CA.ConditionEvent"})]
    public class HealthCondition : MessagePartBean {

        private CV code;
        private BL negationInd;
        private CS statusCode;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private SET<CV, Code> confidentialityCode;
        private CD value;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt911107ca.IActingPerson informantActingPerson;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.OldCondition> predecessorOldCondition;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.Includes subjectOf;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt011001ca.CareCompositions> componentOfPatientCareProvisionEvent;

        public HealthCondition() {
            this.code = new CVImpl();
            this.negationInd = new BLImpl();
            this.statusCode = new CSImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.value = new CDImpl();
            this.predecessorOldCondition = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.OldCondition>();
            this.componentOfPatientCareProvisionEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt011001ca.CareCompositions>();
        }
        /**
         * <summary>Business Name: B: Condition Type</summary>
         * 
         * <remarks>Relationship: REPC_MT000003CA.ConditionEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Denotes assertion 
         * of condition. The condition is conveyed in the value 
         * attribute.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActDiagnosisCode Code {
            get { return (ActDiagnosisCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: E: Refuted Indicator</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000003CA.ConditionEvent.negationInd 
         * Conformance/Cardinality: MANDATORY (1) <p>This is primarily 
         * used to supersede records where an assertion was made that 
         * is subsequently determined to be false. It is important to 
         * be able to make explicit statements that something is known 
         * to not be true.</p><p>This element is mandatory because it 
         * should always be known whether the record is being refuted 
         * or not.</p> <p>When set to true, specifically flags the 
         * Health Condition record as &quot;did not occur&quot;. The 
         * default is false. Additional details about the reasons for 
         * refuting the record may be conveyed in notes.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"negationInd"})]
        public bool? NegationInd {
            get { return this.negationInd.Value; }
            set { this.negationInd.Value = value; }
        }

        /**
         * <summary>Business Name: C:Condition Status</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000003CA.ConditionEvent.statusCode 
         * Conformance/Cardinality: REQUIRED (1) <p>Status is 
         * frequently used to filter query responses as well as to sort 
         * records for presentation. It also affects how the Health 
         * Condition record is interpreted.</p><p>Because the status 
         * won't always be known, the attribute is marked as 
         * 'populated' to allow the use of null flavors.</p> <p>This 
         * identifies the current state of the Health Condition 
         * record.</p><p>Indicates whether the condition is still being 
         * monitored as relevant to the patient's health ('active') or 
         * whether the condition is no longer considered a relevant 
         * 'problem' ('completed'). It may also be 'obsolete' in 
         * circumstances where the record has been replaced.</p><p>Note 
         * that a problem may be considered 'active' even if the 
         * underlying condition is no longer affecting the patient. For 
         * example, for a patient who was recently pregnant, the 
         * pregnancy has ended, but the pregnancy would still be an 
         * 'active' condition record because of it's ongoing impact on 
         * the patient's healthcare situation.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: G: Condition Time Period</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000003CA.ConditionEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Identifies the 
         * time-period of relevance to the record that is useful in 
         * filtering and organizing &quot;time-view&quot; presentations 
         * of data. Because the timing information won't always be 
         * known, this attribute is marked as 'populated'.</p> <p>The 
         * date on which the condition first began and when it 
         * ended.</p><p>For ongoing conditions such as chronic 
         * diseases, the upper boundary may be unknown.</p><p>For 
         * transient conditions such as pregnancy, lactation, etc; the 
         * upper boundary of the period would usually be specified to 
         * signify the end of the condition.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: F: Condition Masking Indicators</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000003CA.ConditionEvent.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-2) <p>The value 
         * specified for a particular record may be overridden by a 
         * higher level masking applied to an indication, a care 
         * composition, a type of record or even all patient 
         * records.</p> <p>Communicates the desire of the patient to 
         * restrict access to this Health Condition record. Provides 
         * support for additional confidentiality constraint, giving 
         * patients a level of control over their information. Methods 
         * for accessing masked event records will be governed by each 
         * jurisdiction (e.g. court orders, shared secret/consent, 
         * etc.).</p><p>Can also be used to communicate that the 
         * information is deemed to be sensitive and should not be 
         * communicated or exposed to the patient (at least without the 
         * guidance of the authoring or other responsible healthcare 
         * provider).</p><p>Valid values are: 'normal' (denotes 'Not 
         * Masked'); 'restricted' (denotes 'Masked') and 'taboo' 
         * (denotes 'patient restricted'). The default is 'normal' 
         * signifying 'Not Masked'. Either or both of the other codes 
         * can be asserted to indicate masking by the patient from 
         * providers or masking by a provider from the patient, 
         * respectively. 'normal' should never be asserted with one of 
         * the other codes.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_BasicConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_BasicConfidentialityKind>(); }
        }

        /**
         * <summary>Business Name: K:Condition</summary>
         * 
         * <remarks>Relationship: REPC_MT000003CA.ConditionEvent.value 
         * Conformance/Cardinality: MANDATORY (1) <p>This is the 
         * central piece of information in recording a condition, 
         * therefore the attribute is mandatory.</p> <p>A code 
         * indicating the specific condition. E.g. Hypertension, 
         * Pregnancy.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public DiagnosisValue Value {
            get { return (DiagnosisValue) this.value.Value; }
            set { this.value.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT000003CA.Informant.actingPerson</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"informant/actingPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt911107ca.IActingPerson InformantActingPerson {
            get { return this.informantActingPerson; }
            set { this.informantActingPerson = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt090108ca.HealthcareWorker InformantActingPersonAsAssignedEntity1 {
            get { return this.informantActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt090108ca.HealthcareWorker ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt090108ca.HealthcareWorker) this.informantActingPerson : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt090108ca.HealthcareWorker) null; }
        }
        public bool HasInformantActingPersonAsAssignedEntity1() {
            return (this.informantActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt090108ca.HealthcareWorker);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt090508ca.HealthcareOrganization InformantActingPersonAsAssignedEntity2 {
            get { return this.informantActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt090508ca.HealthcareOrganization ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt090508ca.HealthcareOrganization) this.informantActingPerson : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt090508ca.HealthcareOrganization) null; }
        }
        public bool HasInformantActingPersonAsAssignedEntity2() {
            return (this.informantActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt090508ca.HealthcareOrganization);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt050207ca.Patient InformantActingPersonAsPatient {
            get { return this.informantActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt050207ca.Patient ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt050207ca.Patient) this.informantActingPerson : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt050207ca.Patient) null; }
        }
        public bool HasInformantActingPersonAsPatient() {
            return (this.informantActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt050207ca.Patient);
        }

        /**
         * <summary>Relationship: 
         * REPC_MT000003CA.Predecessor.oldCondition</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"predecessor/oldCondition"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.OldCondition> PredecessorOldCondition {
            get { return this.predecessorOldCondition; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT000003CA.ConditionEvent.subjectOf</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.Includes SubjectOf {
            get { return this.subjectOf; }
            set { this.subjectOf = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT000003CA.Component.patientCareProvisionEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"componentOf/patientCareProvisionEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt011001ca.CareCompositions> ComponentOfPatientCareProvisionEvent {
            get { return this.componentOfPatientCareProvisionEvent; }
        }

    }

}