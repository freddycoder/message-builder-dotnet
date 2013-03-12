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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: AllergyIntolerance</summary>
     * 
     * <remarks>REPC_MT000005CA.IntoleranceCondition: 
     * Allergy/Intolerance <p>Necessary component of a person's 
     * overall medication and clinical profile. Helps with drug 
     * contraindication checking.</p> <p>A record of a patient's 
     * allergy or intolerance.</p> 
     * REPC_MT000001CA.IntoleranceCondition: Allergy/Intolerance 
     * <p>Necessary component of a person's overall medication and 
     * clinical profile. Helps with drug contraindication 
     * checking.</p> <p>A record of a patient's allergy or 
     * intolerance.</p> REPC_MT000013CA.IntoleranceCondition: 
     * Allergy/Intolerance <p>Necessary component of a person's 
     * overall medication and clinical profile. Helps with drug 
     * contraindication checking.</p> <p>A record of a patient's 
     * allergy or intolerance.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT000001CA.IntoleranceCondition","REPC_MT000005CA.IntoleranceCondition","REPC_MT000013CA.IntoleranceCondition"})]
    public class AllergyIntolerance : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Comt_mt111111ca.ISHR {

        private II id;
        private CD code;
        private BL negationInd;
        private CS statusCode;
        private TS effectiveTime;
        private SET<CV, Code> confidentialityCode;
        private CV uncertaintyCode;
        private CV value;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.HealthcareWorker responsiblePartyAssignedEntity;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.RefusedBy author;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.ReportedBy informant;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.OccurredAt location;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.IRecords> supportRecords;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.AllergyIntoleranceSeverityLevel subjectOfSeverityObservation;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.Includes subjectOf1;
        private BL subjectOf3AnnotationIndicator;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.CareCompositions> componentOfPatientCareProvisionEvent;

        public AllergyIntolerance() {
            this.id = new IIImpl();
            this.code = new CDImpl();
            this.negationInd = new BLImpl();
            this.statusCode = new CSImpl();
            this.effectiveTime = new TSImpl();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.uncertaintyCode = new CVImpl();
            this.value = new CVImpl();
            this.supportRecords = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.IRecords>();
            this.subjectOf3AnnotationIndicator = new BLImpl(false);
            this.componentOfPatientCareProvisionEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.CareCompositions>();
        }
        /**
         * <summary>Business Name: AllergyIntoleranceRecordId</summary>
         * 
         * <remarks>Un-merged Business Name: AllergyIntoleranceRecordId 
         * Relationship: REPC_MT000005CA.IntoleranceCondition.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for direct 
         * referencing of an allergy/intolerance record when querying 
         * or performing updates and is therefore mandatory.</p> 
         * <p>Unique identifier for an allergy/intolerance record.</p> 
         * Un-merged Business Name: AllergyIntoleranceRecordId 
         * Relationship: REPC_MT000013CA.IntoleranceCondition.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates the 
         * allergy or intolerance record to be updated and is therefore 
         * mandatory.</p> <p>Unique identifier for an 
         * allergy/intolerance record.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: AllergyIntoleranceType</summary>
         * 
         * <remarks>Un-merged Business Name: AllergyIntoleranceType 
         * Relationship: REPC_MT000001CA.IntoleranceCondition.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for the 
         * separation of allergy and intolerance records. The type of 
         * condition is critical to understanding the record and is 
         * therefore mandatory. It is expressed as a CD to allow for 
         * SNOMED post-coordination.</p> <p>A coded value denoting 
         * whether the record pertains to an intolerance or a true 
         * allergy. (Allergies result from immunologic reactions. 
         * Intolerances do not.)</p> Un-merged Business Name: 
         * AllergyIntoleranceType Relationship: 
         * REPC_MT000005CA.IntoleranceCondition.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for the 
         * separation of allergy and intolerance records. The type of 
         * condition is critical to understanding the record and is 
         * therefore mandatory. It is expressed as a CD to allow for 
         * SNOMED post-coordination.</p> <p>A coded value denoting 
         * whether the record pertains to an intolerance or a true 
         * allergy. (Allergies result from immunologic reactions. 
         * Intolerances do not.)</p> Un-merged Business Name: 
         * AllergyIntoleranceType Relationship: 
         * REPC_MT000013CA.IntoleranceCondition.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for the 
         * separation of allergy and intolerance records. The type of 
         * condition is critical to understanding the record and is 
         * therefore mandatory. It is expressed as a CD to allow for 
         * SNOMED post-coordination.</p> <p>A coded value denoting 
         * whether the record pertains to an intolerance or a true 
         * allergy. (Allergies result from immunologic reactions. 
         * Intolerances do not.)</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ObservationIntoleranceType Code {
            get { return (ObservationIntoleranceType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: AllergyIntoleranceRefuted</summary>
         * 
         * <remarks>Un-merged Business Name: AllergyIntoleranceRefuted 
         * Relationship: 
         * REPC_MT000001CA.IntoleranceCondition.negationInd 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows providers 
         * to refute a previously confirmed or suspected allergy. The 
         * attribute is mandatory because it is essential to know 
         * whether a record is refuted or not.</p> <p>An indication 
         * that the allergy/intolerance has been refuted. I.e. A 
         * clinician has positively determined that the patient does 
         * not suffer from a particular allergy or intolerance.</p> 
         * Un-merged Business Name: AllergyIntoleranceRefuted 
         * Relationship: 
         * REPC_MT000005CA.IntoleranceCondition.negationInd 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows providers 
         * to refute a previously confirmed or suspected allergy. The 
         * attribute is mandatory because it is critical to know 
         * whether the record represents the refutation or affirmation 
         * of an allergy or intolerance.</p> <p>An indication that the 
         * allergy/intolerance has been refuted. I.e. A clinician has 
         * positively determined that the patient does not suffer from 
         * a particular allergy or intolerance.</p> Un-merged Business 
         * Name: AllergyIntoleranceRefuted Relationship: 
         * REPC_MT000013CA.IntoleranceCondition.negationInd 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows providers 
         * to refute a previously confirmed or suspected allergy. 
         * Because it is essential to know whether the allergy or 
         * intolerance is being refuted or affirmed, this attribute is 
         * mandatory.</p> <p>An indication that the allergy/intolerance 
         * has been refuted. I.e. A clinician has positively determined 
         * that the patient does not suffer from a particular allergy 
         * or intolerance.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"negationInd"})]
        public bool? NegationInd {
            get { return this.negationInd.Value; }
            set { this.negationInd.Value = value; }
        }

        /**
         * <summary>Business Name: AllergyIntoleranceStatus</summary>
         * 
         * <remarks>Un-merged Business Name: AllergyIntoleranceStatus 
         * Relationship: 
         * REPC_MT000001CA.IntoleranceCondition.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows providers 
         * to evaluate the relevance of a recorded allergy/intolerance. 
         * The status has a default value of 'active' and is therefore 
         * mandatory.</p> <p>System must default the status to 
         * 'active'.</p> <p>A coded value that indicates whether an 
         * allergy/intolerance is 'active' or 'completed' (indicating 
         * no longer active).</p> Un-merged Business Name: 
         * AllergyIntoleranceStatus Relationship: 
         * REPC_MT000005CA.IntoleranceCondition.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows providers 
         * to evaluate the relevance of a recorded allergy/intolerance. 
         * The status has a default value of 'ACTIVE' and is therefore 
         * mandatory.</p> <p>System must default the status to 
         * 'ACTIVE'.</p> <p>A coded value that indicates whether an 
         * allergy/intolerance is 'ACTIVE' or 'COMPLETE' (indicating no 
         * longer active).</p> Un-merged Business Name: 
         * AllergyIntoleranceStatus Relationship: 
         * REPC_MT000013CA.IntoleranceCondition.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows providers 
         * to evaluate the relevance of a recorded allergy/intolerance. 
         * The status has a default value of 'ACTIVE' and is therefore 
         * mandatory.</p> <p>System must default the status to 
         * 'ACTIVE'.</p> <p>A coded value that indicates whether an 
         * allergy/intolerance is 'ACTIVE' or 'COMPLETE' (indicating no 
         * longer active).</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: AllergyIntoleranceDate</summary>
         * 
         * <remarks>Un-merged Business Name: AllergyIntoleranceDate 
         * Relationship: 
         * REPC_MT000001CA.IntoleranceCondition.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows providers 
         * to evaluate the period of relevance for the 
         * allergy/intolerance record.</p> <p>The date on which the 
         * recorded allergy is considered active.</p> Un-merged 
         * Business Name: AllergyIntoleranceDate Relationship: 
         * REPC_MT000005CA.IntoleranceCondition.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows providers 
         * to evaluate the period of relevance for the 
         * allergy/intolerance record.</p> <p>The date on which the 
         * recorded allergy is considered active.</p> Un-merged 
         * Business Name: AllergyIntoleranceDate Relationship: 
         * REPC_MT000013CA.IntoleranceCondition.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows providers 
         * to evaluate the period of relevance for the 
         * allergy/intolerance record.</p> <p>The date on which the 
         * recorded allergy is considered active.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public PlatformDate EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: AllergyIntoleranceMaskingIndicators</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * AllergyIntoleranceMaskingIndicators Relationship: 
         * REPC_MT000001CA.IntoleranceCondition.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-2) <p>Provides support 
         * for additional confidentiality constraint to reflect the 
         * wishes of the patient.</p><p>Taboo allows the provider to 
         * request restricted access to patient or their care 
         * giver.</p><p>Constraint: Cant have both normal and one of 
         * the other codes simultaneously.</p><p>The attribute is 
         * optional because not all systems will support masking.</p> 
         * <p>Communicates the desire of the patient to restrict access 
         * to this Health Condition record. Provides support for 
         * additional confidentiality constraint, giving patients a 
         * level of control over their information. Methods for 
         * accessing masked event records will be governed by each 
         * jurisdiction (e.g. court orders, shared secret/consent, 
         * etc.). Can also be used to communicate that the information 
         * is deemed to be sensitive and should not be communicated or 
         * exposed to the patient (at least without the guidance of the 
         * authoring or other responsible healthcare provider). Valid 
         * values are: 'normal' (denotes 'Not Masked'); 'restricted' 
         * (denotes 'Masked'); very restricted (denotes Masked by 
         * Regulation); and 'taboo' (denotes 'patient restricted'). The 
         * default is 'normal' signifying 'Not Masked'. Either or both 
         * of the other codes can be asserted to indicate masking by 
         * the patient from providers or masking by a provider from the 
         * patient, respectively. 'normal' should never be asserted 
         * with one of the other codes.</p> Un-merged Business Name: 
         * AllergyIntoleranceMaskingIndicators Relationship: 
         * REPC_MT000005CA.IntoleranceCondition.confidentialityCode 
         * Conformance/Cardinality: REQUIRED (0-2) <p>Provides support 
         * for additional confidentiality constraint to reflect the 
         * wishes of the patient.</p><p>Taboo allows the provider to 
         * request restricted access to patient or their care 
         * giver.</p><p>Constraint: Cant have both normal and one of 
         * the other codes simultaneously.</p><p>The attribute is 
         * required because even if a jurisdiction doesn't support 
         * masking on the way in, it will need to need to communicate 
         * masked data returned from other jurisdictions.</p> 
         * <p>Communicates the desire of the patient to restrict access 
         * to this Health Condition record. Provides support for 
         * additional confidentiality constraint, giving patients a 
         * level of control over their information. Methods for 
         * accessing masked event records will be governed by each 
         * jurisdiction (e.g. court orders, shared secret/consent, 
         * etc.). Can also be used to communicate that the information 
         * is deemed to be sensitive and should not be communicated or 
         * exposed to the patient (at least without the guidance of the 
         * authoring or other responsible healthcare provider). Valid 
         * values are: 'normal' (denotes 'Not Masked'); 'restricted' 
         * (denotes 'Masked'); very restricted (denotes Masked by 
         * Regulation); and 'taboo' (denotes 'patient restricted'). The 
         * default is 'normal' signifying 'Not Masked'. Either or both 
         * of the other codes can be asserted to indicate masking by 
         * the patient from providers or masking by a provider from the 
         * patient, respectively. 'normal' should never be asserted 
         * with one of the other codes.</p> Un-merged Business Name: 
         * AllergyIntoleranceMaskingIndicators Relationship: 
         * REPC_MT000013CA.IntoleranceCondition.confidentialityCode 
         * Conformance/Cardinality: REQUIRED (0-2) <p>Provides support 
         * for additional confidentiality constraint to reflect the 
         * wishes of the patient.</p><p>Taboo allows the provider to 
         * request restricted access to patient or their care 
         * giver.</p><p>Constraint: Cant have both normal and one of 
         * the other codes simultaneously.</p><p>The attribute is 
         * optional because not all systems will support masking.</p> 
         * <p>Communicates the desire of the patient to restrict access 
         * to this Health Condition record. Provides support for 
         * additional confidentiality constraint, giving patients a 
         * level of control over their information. Methods for 
         * accessing masked event records will be governed by each 
         * jurisdiction (e.g. court orders, shared secret/consent, 
         * etc.). Can also be used to communicate that the information 
         * is deemed to be sensitive and should not be communicated or 
         * exposed to the patient (at least without the guidance of the 
         * authoring or other responsible healthcare provider). Valid 
         * values are: 'normal' (denotes 'Not Masked'); 'restricted' 
         * (denotes 'Masked'); very restricted (denotes Masked by 
         * Regulation); and 'taboo' (denotes 'patient restricted'). The 
         * default is 'normal' signifying 'Not Masked'. Either or both 
         * of the other codes can be asserted to indicate masking by 
         * the patient from providers or masking by a provider from the 
         * patient, respectively. 'normal' should never be asserted 
         * with one of the other codes.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_BasicConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_BasicConfidentialityKind>(); }
        }

        /**
         * <summary>Business Name: ConfirmedIndicator</summary>
         * 
         * <remarks>Un-merged Business Name: ConfirmedIndicator 
         * Relationship: 
         * REPC_MT000001CA.IntoleranceCondition.uncertaintyCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Helps other 
         * providers to make appropriate decisions in their management 
         * of allergy or intolerance contraindications.</p><p>Attribute 
         * is mandatory because an allergy or intolerance record must 
         * be tagged as either U or N.</p> <p>An indication of the 
         * level of confidence/surety placed in the recorded 
         * information.</p><p>The two valid codes are:</p><p>- U 
         * (stated with uncertainty) -Specifies that the author of the 
         * act affirms the uncertainty of the act statement. In other 
         * words, they know that parts of the act statement are not 
         * certain or are inferred. An example of this is an inferred 
         * prescription where some order data is inferred from a supply 
         * event (i.e. dispense).</p><p>- N (stated with no assertion 
         * of uncertainty) - Specifies that the act statement is made 
         * without any explicit expression of certainty/uncertainty. 
         * This is the normal statement, meaning that it may not be 
         * free of errors and uncertainty may still exist. In 
         * healthcare, N is believed to express certainty to the 
         * strength possible.</p><p>An allergy or intolerance record is 
         * always used in drug contraindication checking whether the 
         * record is U or N.</p> Un-merged Business Name: 
         * ConfirmedIndicator Relationship: 
         * REPC_MT000005CA.IntoleranceCondition.uncertaintyCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Helps other 
         * providers to make appropriate decisions in their management 
         * of allergy or intolerance contraindications.</p><p>Attribute 
         * is mandatory because an allergy or intolerance record must 
         * be tagged as either U or N.</p> <p>An indication of the 
         * level of confidence/surety placed in the recorded 
         * information.</p><p>The two valid codes are:</p><p>- U 
         * (stated with uncertainty) -Specifies that the author of the 
         * act affirms the uncertainty of the act statement. In other 
         * words, they know that parts of the act statement are not 
         * certain or are inferred. An example of this is an inferred 
         * prescription where some order data is inferred from a supply 
         * event (i.e. dispense).</p><p>- N (stated with no assertion 
         * of uncertainty) - Specifies that the act statement is made 
         * without any explicit expression of certainty/uncertainty. 
         * This is the normal statement, meaning that it may not be 
         * free of errors and uncertainty may still exist. In 
         * healthcare, N is believed to express certainty to the 
         * strength possible.</p><p>An allergy or intolerance record is 
         * always used in drug contraindication checking whether the 
         * record is U or N</p> Un-merged Business Name: 
         * ConfirmedIndicator Relationship: 
         * REPC_MT000013CA.IntoleranceCondition.uncertaintyCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Helps other 
         * providers to make appropriate decisions in their management 
         * of allergy or intolerance contraindications.</p><p>Attribute 
         * is mandatory because an allergy or intolerance record must 
         * be tagged as either U or N</p> <p>An indication of the level 
         * of confidence/surety placed in the recorded 
         * information.</p><p>The two valid codes are:</p><p>- U 
         * (stated with uncertainty) -Specifies that the author of the 
         * act affirms the uncertainty of the act statement. In other 
         * words, they know that parts of the act statement are not 
         * certain or are inferred. An example of this is an inferred 
         * prescription where some order data is inferred from a supply 
         * event (i.e. dispense).</p><p>- N (stated with no assertion 
         * of uncertainty) - Specifies that the act statement is made 
         * without any explicit expression of certainty/uncertainty. 
         * This is the normal statement, meaning that it may not be 
         * free of errors and uncertainty may still exist. In 
         * healthcare, N is believed to express certainty to the 
         * strength possible.</p><p>An allergy or intolerance record is 
         * always used in drug contraindication checking whether the 
         * record is U or N.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"uncertaintyCode"})]
        public ActUncertainty UncertaintyCode {
            get { return (ActUncertainty) this.uncertaintyCode.Value; }
            set { this.uncertaintyCode.Value = value; }
        }

        /**
         * <summary>Business Name: Agent</summary>
         * 
         * <remarks>Un-merged Business Name: Agent Relationship: 
         * REPC_MT000001CA.IntoleranceCondition.value 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Value is 
         * mandatory if not using SNOMED</p> <p>Critical for 
         * identifying the allergy or intolerance. However, because the 
         * attribute is not used for SNOMED, it is optional.</p> 
         * <p>Indicates the substance to which the patient is 
         * allergic</p> Un-merged Business Name: Agent Relationship: 
         * REPC_MT000005CA.IntoleranceCondition.value 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Value is 
         * mandatory if not using SNOMED</p> <p>Critical for 
         * identifying the allergy or intolerance. Because it is not 
         * used for SNOMED, this element is optional.</p> <p>Indicates 
         * the substance to which the patient is allergic</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public IntoleranceValue Value {
            get { return (IntoleranceValue) this.value.Value; }
            set { this.value.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000005CA.ResponsibleParty.assignedEntity 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.HealthcareWorker ResponsiblePartyAssignedEntity {
            get { return this.responsiblePartyAssignedEntity; }
            set { this.responsiblePartyAssignedEntity = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000005CA.IntoleranceCondition.author 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.RefusedBy Author {
            get { return this.author; }
            set { this.author = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000001CA.IntoleranceCondition.informant 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000005CA.IntoleranceCondition.informant 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000013CA.IntoleranceCondition.informant 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"informant"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.ReportedBy Informant {
            get { return this.informant; }
            set { this.informant = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000005CA.IntoleranceCondition.location 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.OccurredAt Location {
            get { return this.location; }
            set { this.location = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: REPC_MT000001CA.Support.records 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000005CA.Support.records Conformance/Cardinality: 
         * POPULATED (1) Un-merged Business Name: (no business name 
         * specified) Relationship: REPC_MT000013CA.Support.records 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"support/records"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.IRecords> SupportRecords {
            get { return this.supportRecords; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000001CA.Subject1.severityObservation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000005CA.Subject1.severityObservation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000013CA.Subject1.severityObservation 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf/severityObservation","subjectOf1/severityObservation","subjectOf2/severityObservation"})]
        [Hl7MapByPartType(Name="subjectOf", Type="REPC_MT000013CA.Subject1")]
        [Hl7MapByPartType(Name="subjectOf/severityObservation", Type="REPC_MT000013CA.SeverityObservation")]
        [Hl7MapByPartType(Name="subjectOf1", Type="REPC_MT000005CA.Subject1")]
        [Hl7MapByPartType(Name="subjectOf1/severityObservation", Type="REPC_MT000005CA.SeverityObservation")]
        [Hl7MapByPartType(Name="subjectOf2", Type="REPC_MT000001CA.Subject1")]
        [Hl7MapByPartType(Name="subjectOf2/severityObservation", Type="REPC_MT000001CA.SeverityObservation")]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.AllergyIntoleranceSeverityLevel SubjectOfSeverityObservation {
            get { return this.subjectOfSeverityObservation; }
            set { this.subjectOfSeverityObservation = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000001CA.IntoleranceCondition.subjectOf1 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000005CA.IntoleranceCondition.subjectOf2 
         * Conformance/Cardinality: REQUIRED (0-99)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf1","subjectOf2"})]
        [Hl7MapByPartType(Name="subjectOf1", Type="REPC_MT000001CA.Subject3")]
        [Hl7MapByPartType(Name="subjectOf2", Type="REPC_MT000005CA.Subject4")]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.Includes SubjectOf1 {
            get { return this.subjectOf1; }
            set { this.subjectOf1 = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000005CA.Subject3.annotationIndicator 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf3/annotationIndicator"})]
        public bool? SubjectOf3AnnotationIndicator {
            get { return this.subjectOf3AnnotationIndicator.Value; }
            set { this.subjectOf3AnnotationIndicator.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000005CA.Component.patientCareProvisionEvent 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"componentOf/patientCareProvisionEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.CareCompositions> ComponentOfPatientCareProvisionEvent {
            get { return this.componentOfPatientCareProvisionEvent; }
        }

    }

}