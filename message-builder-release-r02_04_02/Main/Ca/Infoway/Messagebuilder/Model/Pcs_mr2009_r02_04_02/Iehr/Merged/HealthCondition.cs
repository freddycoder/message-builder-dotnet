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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt130001ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt911108ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: HealthCondition</summary>
     * 
     * <remarks>REPC_MT000014CA.ConditionEvent: Health Condition 
     * <p>Necessary component of a person's overall profile. Helps 
     * with contraindication checking.</p> <p>A record of a 
     * patient's health condition, as tracked over time. Examples 
     * include diseases, disabilities, pregnancy, lactation and 
     * other clinical conditions of interest.</p><p>Also known as 
     * &quot;Problem&quot; (from a 'problem list').</p> 
     * REPC_MT000010CA.ConditionEvent: Health Condition 
     * <p>Necessary component of a person's overall profile. Helps 
     * with contraindication checking.</p> <p>A record of a 
     * patient's health condition, as tracked over time. Examples 
     * include diseases, disabilities, pregnancy, lactation and 
     * other clinical conditions of interest.</p><p>Also known as 
     * &quot;Problem&quot; (from a 'problem list').</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT000010CA.ConditionEvent","REPC_MT000014CA.ConditionEvent"})]
    public class HealthCondition : MessagePartBean {

        private SET<II, Identifier> id;
        private CV code;
        private CS statusCode;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private SET<CV, Code> confidentialityCode;
        private CD value;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.IActingPerson informantActingPerson;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.CareCompositions> componentOfPatientCareProvisionEvent;
        private BL negationInd;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt911108ca.IActingPerson responsiblePartyActingPerson;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.ChangedBy author;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.ServiceLocation custodian1ServiceDeliveryLocation;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.EHRRepository custodian2AssignedDevice;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.OldCondition> predecessorOldCondition;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.HealthCondition replacementOfConditionEvent;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.NewCondition successorNewCondition;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.AllergyIntoleranceStatusChanges subjectOf1ControlActEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.Includes> subjectOf2;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt130001ca.VersionInformation subjectOf3ControlActEvent;
        private BL subjectOf4AnnotationIndicator;

        public HealthCondition() {
            this.id = new SETImpl<II, Identifier>(typeof(IIImpl));
            this.code = new CVImpl();
            this.statusCode = new CSImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.value = new CDImpl();
            this.componentOfPatientCareProvisionEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.CareCompositions>();
            this.negationInd = new BLImpl();
            this.predecessorOldCondition = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.OldCondition>();
            this.subjectOf2 = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.Includes>();
            this.subjectOf4AnnotationIndicator = new BLImpl(false);
        }
        /**
         * <summary>Business Name: ConditionIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: ConditionIdentifier 
         * Relationship: REPC_MT000014CA.ConditionEvent.id 
         * Conformance/Cardinality: MANDATORY (2) <p> <i>Allows for 
         * unique identification of the Health Condition and is 
         * therefore mandatory. Supports drill-down queries, linking of 
         * this record to other records, matching of EHR records to 
         * locally-stored PoS records and is necessary when identifying 
         * records for amending (revising)/directional linking 
         * (superseding).</i> </p> <p> <i>A globally unique identifier 
         * assigned by the EHR to the Health Condition record.</i> 
         * </p><p>The identifier applies to this &quot;instance&quot; 
         * of the condition. For example, multiple pregnancies would 
         * each be treated as distinct conditions, each with a unique 
         * id.</p> Un-merged Business Name: ConditionIdentifier 
         * Relationship: REPC_MT000010CA.ConditionEvent.id 
         * Conformance/Cardinality: MANDATORY (2) <p> <i>Allows for 
         * unique identification of the Health Condition and is 
         * therefore mandatory. Supports drill-down queries, linking of 
         * this record to other records, matching of EHR records to 
         * locally-stored PoS records and is necessary when identifying 
         * records for amending (revising)/directional linking 
         * (superseding).</i> </p> <p> <i>A globally unique identifier 
         * assigned by the EHR to the Health Condition record.</i> 
         * </p><p>The identifier applies to this &quot;instance&quot; 
         * of the condition. For example, multiple pregnancies would 
         * each be treated as distinct conditions, each with a unique 
         * id.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public ICollection<Identifier> Id {
            get { return this.id.RawSet(); }
        }

        /**
         * <summary>Business Name: ConditionType</summary>
         * 
         * <remarks>Un-merged Business Name: ConditionType 
         * Relationship: REPC_MT000014CA.ConditionEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Code is fixed DX 
         * if not using SNOMED;</p> <p> <i>Condition Type is used for 
         * searching and for organizing Health Condition records as 
         * well as sorting them for presentation.</i> </p><p> <i>This 
         * is a key attribute for understanding the type of record and 
         * is therefore mandatory.</i> </p><p>Since all diagnosis 
         * concepts can be represented in a single field, this domain 
         * is a fixed value</p> <p>Designates the concept in 
         * DiagnosisValue as a Diagnosis</p> Un-merged Business Name: 
         * ConditionType Relationship: 
         * REPC_MT000010CA.ConditionEvent.code Conformance/Cardinality: 
         * MANDATORY (1) <p>Code is fixed DX if not using SNOMED;</p> 
         * <p> <i>Condition Type is used for searching and for 
         * organizing Health Condition records as well as sorting them 
         * for presentation.</i> </p><p> <i>This is a key attribute for 
         * understanding the type of record and is therefore 
         * mandatory.</i> </p><p>Since all diagnosis concepts can be 
         * represented in a single field, this domain is a fixed 
         * value</p> <p>Designates the concept in DiagnosisValue as a 
         * Diagnosis</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActDiagnosisCode Code {
            get { return (ActDiagnosisCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: ConditionStatus</summary>
         * 
         * <remarks>Un-merged Business Name: ConditionStatus 
         * Relationship: REPC_MT000014CA.ConditionEvent.statusCode 
         * Conformance/Cardinality: POPULATED (1) <p> <i>Status is 
         * frequently used to filter query responses as well as to sort 
         * records for presentation. It also affects how the Health 
         * Condition record is interpreted.</i> </p><p> <i>Because the 
         * status won't always be known, the attribute is marked as 
         * 'populated' to allow the use of null flavors.</i> </p> <p> 
         * <i>This identifies the current state of the Health Condition 
         * record.</i> </p><p>Indicates whether the condition is still 
         * being monitored as relevant to the patient's health 
         * ('active') or whether the condition is no longer considered 
         * a relevant 'problem' ('completed'). It may also be 
         * 'obsolete' in circumstances where the record has been 
         * replaced.</p><p>Note that a problem may be considered 
         * 'active' even if the underlying condition is no longer 
         * affecting the patient. For example, for a patient who was 
         * recently pregnant, the pregnancy has ended, but the 
         * pregnancy would still be an 'active' condition record 
         * because of it's ongoing impact on the patient's healthcare 
         * situation.</p><p>To convey the actual clinical status of the 
         * condition, use SNOMED post-coordination in the Condition 
         * attribute.</p> Un-merged Business Name: ConditionStatus 
         * Relationship: REPC_MT000010CA.ConditionEvent.statusCode 
         * Conformance/Cardinality: POPULATED (1) <p> <i>Status is 
         * frequently used to filter query responses as well as to sort 
         * records for presentation. It also affects how the Health 
         * Condition record is interpreted.</i> </p><p> <i>Because the 
         * status won't always be known, the attribute is marked as 
         * 'populated' to allow the use of null flavors.</i> </p> <p> 
         * <i>This identifies the current state of the Health Condition 
         * record.</i> </p><p>Indicates whether the condition is still 
         * being monitored as relevant to the patient's health 
         * ('active') or whether the condition is no longer considered 
         * a relevant 'problem' ('completed'). It may also be 
         * 'obsolete' in circumstances where the record has been 
         * replaced.</p><p>Note that a problem may be considered 
         * 'active' even if the underlying condition is no longer 
         * affecting the patient. For example, for a patient who was 
         * recently pregnant, the pregnancy has ended, but the 
         * pregnancy would still be an 'active' condition record 
         * because of it's ongoing impact on the patient's healthcare 
         * situation.</p><p>To convey the actual clinical status of the 
         * condition, use SNOMED post-coordination in the Condition 
         * attribute.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: ConditionTimePeriod</summary>
         * 
         * <remarks>Un-merged Business Name: ConditionTimePeriod 
         * Relationship: REPC_MT000014CA.ConditionEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p> <i>Identifies 
         * the time-period of relevance to the record that is useful in 
         * filtering and organizing &quot;time-view&quot; presentations 
         * of data. Because the timing information won't always be 
         * known, this attribute is marked as 'populated'.</i> </p> 
         * <p>The date on which the condition first began and when it 
         * ended.</p><p>For ongoing conditions such as chronic 
         * diseases, the upper boundary may be unknown.</p><p>For 
         * transient conditions such as pregnancy, lactation, etc; the 
         * upper boundary of the period would usually be specified to 
         * signify the end of the condition.</p> Un-merged Business 
         * Name: ConditionTimePeriod Relationship: 
         * REPC_MT000010CA.ConditionEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p> <i>Identifies 
         * the time-period of relevance to the record that is useful in 
         * filtering and organizing &quot;time-view&quot; presentations 
         * of data. Because the timing information won't always be 
         * known, this attribute is marked as 'populated'.</i> </p> 
         * <p>The date on which the condition first began and when it 
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
         * <summary>Business Name: ConditionMaskingIndicators</summary>
         * 
         * <remarks>Un-merged Business Name: ConditionMaskingIndicators 
         * Relationship: 
         * REPC_MT000014CA.ConditionEvent.confidentialityCode 
         * Conformance/Cardinality: REQUIRED (0-2) <p></p> <p> <i>The 
         * value specified for a particular record may be overridden by 
         * a higher level masking applied to an indication, a care 
         * composition, a type of record or even all patient 
         * records.</i> </p> <p> <i>Communicates the desire of the 
         * patient to restrict access to this Health Condition record. 
         * Provides support for additional confidentiality constraint, 
         * giving patients a level of control over their information. 
         * Methods for accessing masked event records will be governed 
         * by each jurisdiction (e.g. court orders, shared 
         * secret/consent, etc.).</i> </p><p> <i>Can also be used to 
         * communicate that the information is deemed to be sensitive 
         * and should not be communicated or exposed to the patient (at 
         * least without the guidance of the authoring or other 
         * responsible healthcare provider).</i> </p><p> <i>Valid 
         * values are: 'normal' (denotes 'Not Masked'); 'restricted' 
         * (denotes 'Masked') and 'taboo' (denotes 'patient 
         * restricted'). The default is 'normal' signifying 'Not 
         * Masked'. Either or both of the other codes can be asserted 
         * to indicate masking by the patient from providers or masking 
         * by a provider from the patient, respectively. 'normal' 
         * should never be asserted with one of the other codes.</i> 
         * </p> Un-merged Business Name: ConditionMaskingIndicators 
         * Relationship: 
         * REPC_MT000010CA.ConditionEvent.confidentialityCode 
         * Conformance/Cardinality: REQUIRED (0-2) <p></p> <p> <i>The 
         * value specified for a particular record may be overridden by 
         * a higher level masking applied to an indication, a care 
         * composition, a type of record or even all patient 
         * records.</i> </p> <p> <i>Communicates the desire of the 
         * patient to restrict access to this Health Condition record. 
         * Provides support for additional confidentiality constraint, 
         * giving patients a level of control over their information. 
         * Methods for accessing masked event records will be governed 
         * by each jurisdiction (e.g. court orders, shared 
         * secret/consent, etc.).</i> </p><p> <i>Can also be used to 
         * communicate that the information is deemed to be sensitive 
         * and should not be communicated or exposed to the patient (at 
         * least without the guidance of the authoring or other 
         * responsible healthcare provider).</i> </p><p> <i>Valid 
         * values are: 'normal' (denotes 'Not Masked'); 'restricted' 
         * (denotes 'Masked') and 'taboo' (denotes 'patient 
         * restricted'). The default is 'normal' signifying 'Not 
         * Masked'. Either or both of the other codes can be asserted 
         * to indicate masking by the patient from providers or masking 
         * by a provider from the patient, respectively. 'normal' 
         * should never be asserted with one of the other codes.</i> 
         * </p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_BasicConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_BasicConfidentialityKind>(); }
        }

        /**
         * <summary>Business Name: Condition</summary>
         * 
         * <remarks>Un-merged Business Name: Condition Relationship: 
         * REPC_MT000014CA.ConditionEvent.value 
         * Conformance/Cardinality: MANDATORY (1) <p>This is the 
         * central piece of information in recording a condition, 
         * therefore the attribute is mandatory.</p><p> <i>This element 
         * makes use of the CD datatype because some terminologies used 
         * for the domain require use of modifiers.</i> </p><p> <i>The 
         * element uses CWE to allow for the capture of Condition 
         * concepts not presently supported by the approved code 
         * system(s). In this case, the human-to-human benefit of 
         * capturing additional non-coded values outweighs the 
         * penalties of capturing some information that will not be 
         * amenable to searching or categorizing.</i> </p> <p>A code 
         * indicating the specific condition. E.g. Hypertension, 
         * Pregnancy.</p> Un-merged Business Name: Condition 
         * Relationship: REPC_MT000010CA.ConditionEvent.value 
         * Conformance/Cardinality: MANDATORY (1) <p>This is the 
         * central piece of information in recording a condition, 
         * therefore the attribute is mandatory.</p><p> <i>This element 
         * makes use of the CD datatype because some terminologies used 
         * for the domain require use of modifiers.</i> </p><p> <i>The 
         * element uses CWE to allow for the capture of Condition 
         * concepts not presently supported by the approved code 
         * system(s). In this case, the human-to-human benefit of 
         * capturing additional non-coded values outweighs the 
         * penalties of capturing some information that will not be 
         * amenable to searching or categorizing.</i> </p> <p>A code 
         * indicating the specific condition. E.g. Hypertension, 
         * Pregnancy.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public DiagnosisValue Value {
            get { return (DiagnosisValue) this.value.Value; }
            set { this.value.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000014CA.Informant.actingPerson 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000010CA.Informant.actingPerson 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"informant/actingPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.IActingPerson InformantActingPerson {
            get { return this.informantActingPerson; }
            set { this.informantActingPerson = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000014CA.Component.patientCareProvisionEvent 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000010CA.Component.patientCareProvisionEvent 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"componentOf/patientCareProvisionEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.CareCompositions> ComponentOfPatientCareProvisionEvent {
            get { return this.componentOfPatientCareProvisionEvent; }
        }

        /**
         * <summary>Business Name: RefutedIndicator</summary>
         * 
         * <remarks>Un-merged Business Name: RefutedIndicator 
         * Relationship: REPC_MT000010CA.ConditionEvent.negationInd 
         * Conformance/Cardinality: MANDATORY (1) <p> <i>This is 
         * primarily used to supersede records where an assertion was 
         * made that is subsequently determined to be false. It is 
         * important to be able to make explicit statements that 
         * something is known to not be true.</i> </p><p> <i>This 
         * element is mandatory because it should always be known 
         * whether the record is being refuted or not.</i> </p> <p> 
         * <i>When set to true, specifically flags the Health Condition 
         * record as &quot;did not occur&quot;. The default is false. 
         * Additional details about the reasons for refuting the record 
         * may be conveyed in notes.</i> </p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"negationInd"})]
        public bool? NegationInd {
            get { return this.negationInd.Value; }
            set { this.negationInd.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000010CA.ResponsibleParty.actingPerson 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/actingPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt911108ca.IActingPerson ResponsiblePartyActingPerson {
            get { return this.responsiblePartyActingPerson; }
            set { this.responsiblePartyActingPerson = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: REPC_MT000010CA.ConditionEvent.author 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.ChangedBy Author {
            get { return this.author; }
            set { this.author = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000010CA.Custodian2.serviceDeliveryLocation 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"custodian1/serviceDeliveryLocation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.ServiceLocation Custodian1ServiceDeliveryLocation {
            get { return this.custodian1ServiceDeliveryLocation; }
            set { this.custodian1ServiceDeliveryLocation = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000010CA.Custodian.assignedDevice 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"custodian2/assignedDevice"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.EHRRepository Custodian2AssignedDevice {
            get { return this.custodian2AssignedDevice; }
            set { this.custodian2AssignedDevice = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000010CA.Predecessor.oldCondition 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"predecessor/oldCondition"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.OldCondition> PredecessorOldCondition {
            get { return this.predecessorOldCondition; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000010CA.ReplacementOf.conditionEvent 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"replacementOf/conditionEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.HealthCondition ReplacementOfConditionEvent {
            get { return this.replacementOfConditionEvent; }
            set { this.replacementOfConditionEvent = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000010CA.Predecessor2.newCondition 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"successor/newCondition"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.NewCondition SuccessorNewCondition {
            get { return this.successorNewCondition; }
            set { this.successorNewCondition = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000010CA.Subject.controlActEvent 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf1/controlActEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.AllergyIntoleranceStatusChanges SubjectOf1ControlActEvent {
            get { return this.subjectOf1ControlActEvent; }
            set { this.subjectOf1ControlActEvent = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000010CA.ConditionEvent.subjectOf2 
         * Conformance/Cardinality: REQUIRED (0-100)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.Includes> SubjectOf2 {
            get { return this.subjectOf2; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000010CA.Subject7.controlActEvent 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf3/controlActEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt130001ca.VersionInformation SubjectOf3ControlActEvent {
            get { return this.subjectOf3ControlActEvent; }
            set { this.subjectOf3ControlActEvent = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000010CA.Subject6.annotationIndicator 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf4/annotationIndicator"})]
        public bool? SubjectOf4AnnotationIndicator {
            get { return this.subjectOf4AnnotationIndicator.Value; }
            set { this.subjectOf4AnnotationIndicator.Value = value; }
        }

    }

}