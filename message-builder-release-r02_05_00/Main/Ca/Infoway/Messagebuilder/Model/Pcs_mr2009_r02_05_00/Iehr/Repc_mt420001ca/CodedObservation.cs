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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Repc_mt420001ca {
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
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt240007ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt911107ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt911108ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt090108ca;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Coded Observation</summary>
     * 
     * <p>Observations are a key mechanism for capturing the state 
     * of a patient. Observations provide context for interventions 
     * subsequently taken. Observations can also be tracked over 
     * time to look for changes that may help in assessing a 
     * patient's health.</p> <p>This record expresses a single 
     * point-in-time observation made about a patient.</p><p>E.g. 
     * blood type, APGAR, diagnosis, mole shape, etc.</p><p>Note: 
     * Diagnosis captured using Coded Observations represent 
     * 'point-in-time' assessments. To assert a condition as a 
     * problem and track it over time, use the Health Condition 
     * transactions.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT420001CA.CommonObservationEvent"})]
    public class CodedObservation : MessagePartBean {

        private CD code;
        private BL negationInd;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private SET<CV, Code> confidentialityCode;
        private CD value;
        private CE interpretationCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt240007ca.ServiceLocation indirectTargetServiceDeliveryLocation;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt911108ca.IActingPerson> performerActingPerson;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt911107ca.IActingPerson informantActingPerson;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.OccurredAt location;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.Request_2 inFulfillmentOfActRequest;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.ActDefinition> definitionActDefinition;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.OldCommonObservationEvent> predecessorOldCommonObservationEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.BecauseOf> reason;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.ComponentObservations_2> componentSubObservationEvent;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.Includes subjectOf;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt011001ca.CareCompositions> componentOfPatientCareProvisionEvent;

        public CodedObservation() {
            this.code = new CDImpl();
            this.negationInd = new BLImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.value = new CDImpl();
            this.interpretationCode = new CEImpl();
            this.performerActingPerson = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt911108ca.IActingPerson>();
            this.definitionActDefinition = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.ActDefinition>();
            this.predecessorOldCommonObservationEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.OldCommonObservationEvent>();
            this.reason = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.BecauseOf>();
            this.componentSubObservationEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.ComponentObservations_2>();
            this.componentOfPatientCareProvisionEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt011001ca.CareCompositions>();
        }
        /**
         * <summary>Business Name: B:Observation Type</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT420001CA.CommonObservationEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Only 'nullFlavor' 
         * value of OTH is available.</p> <p>EPHS: new vocab concepts 
         * needed. See implementation notes</p><p>EPHS: vocab code 
         * needed for immunization interpretation</p><p>EPHS: vocab 
         * domain needed for medical history</p><p>EPHS: vocab domain 
         * needed for Assessment</p><p>EPHS: vocab domain needed for 
         * encounter complication</p><p>EPHS: concept code needed for 
         * Outbreak Complication</p> <p> <i>Observation Type is used 
         * for searching and for organizing Coded Observation records 
         * as well as sorting them for presentation.</i> </p><p> 
         * <i>This is a key attribute for understanding the type of 
         * record and is therefore mandatory.</i> </p><p> <i>This 
         * element makes use of the CD datatype to allow for use of the 
         * SNOMED code system that in some circumstances requires the 
         * use of post-coordination. Post-coordination is only 
         * supported by the CD datatype.</i> </p><p> <i>The element 
         * uses CWE to allow for the capture of Observation Type 
         * concepts not presently supported by the approved code 
         * system(s). In this case, the human-to-human benefit of 
         * capturing additional non-coded values outweighs the 
         * penalties of capturing some information that will not be 
         * amenable to searching or categorizing.</i> </p> 
         * <p>EPHS:Observation.code fixed to &quot;OUTCOME&quot; at 
         * runtime</p><p>EPHS: observation.code fixed to &quot;DIRECTLY 
         * OBSERVED DOSES TAKEN&quot; at runtime</p> <p> <i>Identifies 
         * the type of Coded Observation represented by this 
         * record.</i> </p><p>Observation types include: Assertion, 
         * blood type, APGAR, etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public CommonCodedClinicalObservationType Code {
            get { return (CommonCodedClinicalObservationType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: D:Refuted Indicator</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT420001CA.CommonObservationEvent.negationInd 
         * Conformance/Cardinality: MANDATORY (1) <p> <i>This is 
         * primarily used to supersede records where an assertion was 
         * made that is subsequently determined to be false. It is 
         * important to be able to make explicit statements that 
         * something is known to not be true.</i> </p><p> <i>This 
         * element is mandatory because it should always be known 
         * whether the record is being refuted or not. NOTE: This 
         * element should not be used to communicate negative findings, 
         * but rather circumstances where the observation itself was 
         * not actually made. E.g. &quot;I did not make a diagnosis of 
         * meningitis&quot; would be appropriate. &quot;I diagnosed 
         * that they did not have meningitis&quot; would not. (The 
         * latter would be handled as part of the code describing the 
         * diagnosis.)</i> </p> <p> <i>When set to true, specifically 
         * flags the Coded Observation record as &quot;did not 
         * occur&quot;. The default is false. Additional details about 
         * the reasons for refuting the record may be conveyed in 
         * notes.</i> </p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"negationInd"})]
        public bool? NegationInd {
            get { return this.negationInd.Value; }
            set { this.negationInd.Value = value; }
        }

        /**
         * <summary>Business Name: E:Observation Period</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT420001CA.CommonObservationEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (1) <p> <i>Identifies the 
         * time-period of relevance to the record that is useful in 
         * filtering and organizing &quot;time-view&quot; presentations 
         * of data. Because the timing information won't always be 
         * known, this attribute is marked as 'populated'.</i> </p> 
         * <p>EPHS: signs and symptoms onset date maps to beginning of 
         * time interval, recovery date to end of interval</p> 
         * <p>Identifies the time at which the observation applies. 
         * Usually, this will be conveyed as a single point in time 
         * (center with a width of 0). However, some observations may 
         * cover a time-period with in which case start and end or 
         * start and duration may be specified.</p><p>Note that the 
         * date the observation applies is not always the same as the 
         * time the observation is actually made. A lab example: if 
         * blood was drawn two days ago and White Blood Count (WBC) was 
         * done today, then WBC observation date should reflect the 
         * date of two days ago because that is the time the 
         * observation actually applies to.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: D:Observation Masking Indicators</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT420001CA.CommonObservationEvent.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-2) <p>The value 
         * specified for a particular record may be overridden by a 
         * higher level masking applied to an indication, a care 
         * composition, a type of record or even all patient 
         * records.</p> <p>Communicates the desire of the patient to 
         * restrict access to this Coded Observation record. Provides 
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
         * <summary>Business Name: L:Observation Value</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT420001CA.CommonObservationEvent.value 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Observation Value 
         * must be specified and may only be specified when no 
         * sub-observations are present.</p> <p>Depending on 
         * CommonCodedClinicalObservationType, One of 
         * CommonClinicalObservationResultValue or 
         * CommonClinicalObservationAssertionValue must be implemented 
         * in place of CommonClinicalbservationValue</p> <p>Conveys the 
         * clinical information resulting from the observation in a 
         * standardized representation.</p> <p>Indicates what was 
         * actually observed when the observation was made.</p><p>E.g. 
         * code for pregnancy, code for blood type, color of eyes 
         * etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public CommonClinicalObservationValue Value {
            get { return (CommonClinicalObservationValue) this.value.Value; }
            set { this.value.Value = value; }
        }

        /**
         * <summary>Business Name: M:Observation Normality 
         * Interpretation</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT420001CA.CommonObservationEvent.interpretationCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Provides an 
         * ability to quickly flag observations that are outside the 
         * norm. These are generally the records which are of most 
         * interest from a clinical perspective.</p> <p>Identifies the 
         * level of variation of the observed state from what would be 
         * considered normal for a patient of similar age and gender. 
         * E.g. &quot;Normal&quot;, &quot;High&quot;, &quot;Critically 
         * High&quot;, etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"interpretationCode"})]
        public ObservationInterpretationNormality InterpretationCode {
            get { return (ObservationInterpretationNormality) this.interpretationCode.Value; }
            set { this.interpretationCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT420001CA.IndirectTarget.serviceDeliveryLocation</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"indirectTarget/serviceDeliveryLocation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt240007ca.ServiceLocation IndirectTargetServiceDeliveryLocation {
            get { return this.indirectTargetServiceDeliveryLocation; }
            set { this.indirectTargetServiceDeliveryLocation = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT420001CA.Performer.actingPerson</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"performer/actingPerson"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt911108ca.IActingPerson> PerformerActingPerson {
            get { return this.performerActingPerson; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT420001CA.Informant.actingPerson</summary>
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
         * REPC_MT420001CA.CommonObservationEvent.location</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.OccurredAt Location {
            get { return this.location; }
            set { this.location = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT420001CA.InFulfillmentOf.actRequest</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"inFulfillmentOf/actRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.Request_2 InFulfillmentOfActRequest {
            get { return this.inFulfillmentOfActRequest; }
            set { this.inFulfillmentOfActRequest = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT420001CA.Definition.actDefinition</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"definition/actDefinition"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.ActDefinition> DefinitionActDefinition {
            get { return this.definitionActDefinition; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT420001CA.Predecessor.oldCommonObservationEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"predecessor/oldCommonObservationEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.OldCommonObservationEvent> PredecessorOldCommonObservationEvent {
            get { return this.predecessorOldCommonObservationEvent; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT420001CA.CommonObservationEvent.reason</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-5)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reason"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.BecauseOf> Reason {
            get { return this.reason; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT420001CA.Component.subObservationEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component/subObservationEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.ComponentObservations_2> ComponentSubObservationEvent {
            get { return this.componentSubObservationEvent; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT420001CA.CommonObservationEvent.subjectOf</summary>
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
         * REPC_MT420001CA.Component3.patientCareProvisionEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"componentOf/patientCareProvisionEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt011001ca.CareCompositions> ComponentOfPatientCareProvisionEvent {
            get { return this.componentOfPatientCareProvisionEvent; }
        }

    }

}