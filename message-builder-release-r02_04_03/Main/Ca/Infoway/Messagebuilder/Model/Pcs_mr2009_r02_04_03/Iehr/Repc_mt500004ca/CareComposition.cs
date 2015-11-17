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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Repc_mt500004ca {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt011001ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt050202ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt050207ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090108ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090310ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090508ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt130001ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt240003ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt910108ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt911107ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt911108ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Care Composition</summary>
     * 
     * <p>Annotation is only permitted if Annotation Indicator is 
     * not present and vice versa</p> <p>Care compositions allow 
     * grouping together numerous related records which aids 
     * searching and navigation. Also, the mere knowledge that a 
     * type of care has occurred or is occurring (e.g. an 
     * in-patient hospital encounter) can be useful information 
     * when delivering subsequent care.</p> <p>A care composition 
     * is a record with two purposes. It indicates that care of a 
     * given type has occurred or is occurring. It also acts as a 
     * collector for the events that happened during care, 
     * including who is responsible for the care 
     * provided.</p><p>Care composition messages may be sent during 
     * the course of care to describe the progress of care or may 
     * be sent at the termination of care to describe all the 
     * activities that occurred during the provision of care. Note 
     * that this record merely captures the existence of care and 
     * the locations and people involved. The actual discrete 
     * events and any care summary documentation that results are 
     * captured using other messages.</p><p>Examples include: 
     * encounters, condition-related care (episodes) and 
     * longer-term care collections such as &quot;gynecological 
     * care&quot;.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT500004CA.PatientCareProvisionEvent"})]
    public class CareComposition : MessagePartBean {

        private SET<II, Identifier> id;
        private CV code;
        private BL negationInd;
        private CS statusCode;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private SET<CV, Code> confidentialityCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.Specimen subject1Specimen;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt050202ca.Patient> subject2Patient;
        private INT subject3PatientPatientEntityQuantifiedKindQuantity;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt911108ca.IActingPerson responsiblePartyActingPerson;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt911108ca.IActingPerson> performerActingPerson;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.ChangedBy author;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt911107ca.IActingPerson informantActingPerson;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt911108ca.IActingPerson dischargerActingPerson;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090310ca.EHRRepository custodian1AssignedDevice;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt240003ca.ServiceLocation custodian2ServiceDeliveryLocation;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.OccurredAt> location;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.DischargeDiagnosis> outcomeDiagnosisEvent;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.Request_1 inFulfillmentOfActRequest;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.OldPatientCareProvisionEvent> predecessorOldPatientCareProvisionEvent;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Repc_mt500004ca.CareComposition replacementOfPatientCareProvisionEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.BecauseOf> reason;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.ActEvent> component1ActEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.ParticipantGroupings> component2PatientCareProvisionEventPortion;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.NewPatientCareProvisionEvent successorNewPatientCareProvisionEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.Includes> subjectOf1;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt130001ca.VersionInformation subjectOf2ControlActEvent;
        private BL subjectOf3AnnotationIndicator;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.ControlActEvent subjectOf4ControlActEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt011001ca.CareCompositions> componentOfPatientCareProvisionEvent;

        public CareComposition() {
            this.id = new SETImpl<II, Identifier>(typeof(IIImpl));
            this.code = new CVImpl();
            this.negationInd = new BLImpl();
            this.statusCode = new CSImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.subject2Patient = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt050202ca.Patient>();
            this.subject3PatientPatientEntityQuantifiedKindQuantity = new INTImpl();
            this.performerActingPerson = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt911108ca.IActingPerson>();
            this.location = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.OccurredAt>();
            this.outcomeDiagnosisEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.DischargeDiagnosis>();
            this.predecessorOldPatientCareProvisionEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.OldPatientCareProvisionEvent>();
            this.reason = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.BecauseOf>();
            this.component1ActEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.ActEvent>();
            this.component2PatientCareProvisionEventPortion = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.ParticipantGroupings>();
            this.subjectOf1 = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.Includes>();
            this.subjectOf3AnnotationIndicator = new BLImpl(false);
            this.componentOfPatientCareProvisionEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt011001ca.CareCompositions>();
        }
        /**
         * <summary>Business Name: A: Care Composition Ids</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT500004CA.PatientCareProvisionEvent.id 
         * Conformance/Cardinality: MANDATORY (2) <p> <i>Allows for 
         * unique identification of the Care Composition and is 
         * therefore mandatory. Supports drill-down queries, linking of 
         * this record to other records, matching of EHR records to 
         * locally-stored PoS records and is necessary when identifying 
         * records for amending (revising)/directional linking 
         * (superseding).</i> </p> <p> <i>A globally unique identifier 
         * assigned by the EHR to the Care Composition record.</i> </p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public ICollection<Identifier> Id {
            get { return this.id.RawSet(); }
        }

        /**
         * <summary>Business Name: B: Care Composition Type</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT500004CA.PatientCareProvisionEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p> <i>Care 
         * Composition Type is used for searching and for organizing 
         * Care Composition records as well as sorting them for 
         * presentation.</i> </p><p> <i>This is a key attribute for 
         * understanding the type of record and is therefore 
         * mandatory.</i> </p> <p> <i>Identifies the type of Care 
         * Composition represented by this record.</i> </p><p>Care 
         * Composition is the generic name given to event 'containers' 
         * such as Encounters, Health-Condition-based Collections 
         * (Episodes) and Care-based Collections. The &quot;type&quot; 
         * of care composition places constraints on what elements are 
         * supported.</p><p>Encounter-based collection: a series of 
         * health care events that occur during an interaction between 
         * one or more health care providers and one or more patients 
         * where the providers and the patient remain in the same 
         * location over a contiguous period of time; the providers and 
         * patient may be at different locations (telehealth). e.g. 
         * Inpatient encounter, Community 
         * encounter.</p><p>Condition-based collection (Episode): a 
         * series of interactions between a patient and one or more 
         * health care providers over time in one or more locations and 
         * tied together by a common diagnosis or 
         * problem.</p><p>Care-based collection: a high level grouping 
         * of health events, encounters, and/or episodes related to a 
         * particular area of healthcare. e.g. Gynecology care, 
         * Cardiology Care, etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActCareEventType Code {
            get { return (ActCareEventType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: D:Refuted Indicator</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT500004CA.PatientCareProvisionEvent.negationInd 
         * Conformance/Cardinality: MANDATORY (1) <p>Refuted Indicator 
         * cannot be specified unless Care Composition Type is 
         * Encounter or a specialization there-of.</p> <p> <i>This is 
         * primarily used to supersede records where an assertion was 
         * made that is subsequently determined to be false. It is 
         * important to be able to make explicit statements that 
         * something is known to not be true.</i> </p><p> <i>This 
         * element is mandatory because it should always be known 
         * whether the record is being refuted or not.</i> </p> <p> 
         * <i>When set to true, specifically flags the Care Composition 
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
         * <summary>Business Name: C: Care Composition Status</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT500004CA.PatientCareProvisionEvent.statusCode 
         * Conformance/Cardinality: REQUIRED (1) <p> <i>Status is 
         * frequently used to filter query responses as well as to sort 
         * records for presentation. It also affects how the Care 
         * Composition record is interpreted.</i> </p><p> <i>Because 
         * the status won't always be known, the attribute is marked as 
         * 'populated' to allow the use of null flavors.</i> </p> <p> 
         * <i>This identifies the current state of the Care Composition 
         * record. Allowed status values are 'active' (the encounter, 
         * episode or general delivery of care ongoing) and 'completed' 
         * (the encounter, episode or general care has ended).</i> </p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: F: Care Composition Period</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT500004CA.PatientCareProvisionEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (1) <p> <i>Identifies the 
         * time-period of relevance to the record that is useful in 
         * filtering and organizing &quot;time-view&quot; presentations 
         * of data. Because the timing information won't always be 
         * known, this attribute is marked as 'populated'.</i> </p> 
         * <p>Represents the start and end of the date/time interval 
         * during which the care described by the composition was/is 
         * being provided.</p><p>E.g. The admission and discharge 
         * date/time; the date on which the episode began and ended; 
         * etc.</p><p>Please note that it is possible for many episodes 
         * and care events to not have an end date; in these 
         * situations, only the start date will be specified. Even 
         * encounters will not have an end date until the encounter is 
         * completed/patient is discharged.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: E: Care Composition Masking 
         * Indicators</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT500004CA.PatientCareProvisionEvent.confidentialityCode 
         * Conformance/Cardinality: REQUIRED (0-2) <p></p> <p> <i>The 
         * value specified for a particular record may be overridden by 
         * a higher level masking applied to an indication, a care 
         * composition, a type of record or even all patient 
         * records.</i> </p> <p> <i>Communicates the desire of the 
         * patient to restrict access to this Care Composition record. 
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
         * </p><p>Masking a care composition record masks it for all 
         * associated patients (i.e. all patients involved in the care 
         * composition as a group).</p><p>Also, masking a care 
         * composition implicitly masks all records associated with 
         * that care composition.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_BasicConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_BasicConfidentialityKind>(); }
        }

        /**
         * <summary>Relationship: REPC_MT500004CA.Subject6.specimen</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject1/specimen"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.Specimen Subject1Specimen {
            get { return this.subject1Specimen; }
            set { this.subject1Specimen = value; }
        }

        /**
         * <summary>Relationship: REPC_MT500004CA.Subject7.patient</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject2/patient"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt050202ca.Patient> Subject2Patient {
            get { return this.subject2Patient; }
        }

        /**
         * <summary>Business Name: J:Number of Patients</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT500004CA.EntityQuantifiedKind.quantity 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows a provider 
         * to ascertain the size of a group encounter without 
         * necessarily revealing the identity of the patients 
         * involved.</p><p>The patients associated with an encounter 
         * must be specified at the time the record is created, thus 
         * the number of patients will always be known, making this 
         * element mandatory.</p> <p>Indicates the number of patients 
         * involved in a group encounter. For non-group encounters, 
         * this attribute will always be &quot;1&quot;.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject3/patient/patientEntityQuantifiedKind/quantity"})]
        public int? Subject3PatientPatientEntityQuantifiedKindQuantity {
            get { return this.subject3PatientPatientEntityQuantifiedKindQuantity.Value; }
            set { this.subject3PatientPatientEntityQuantifiedKindQuantity.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT500004CA.ResponsibleParty.actingPerson</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/actingPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt911108ca.IActingPerson ResponsiblePartyActingPerson {
            get { return this.responsiblePartyActingPerson; }
            set { this.responsiblePartyActingPerson = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090108ca.HealthcareWorker ResponsiblePartyActingPersonAsAssignedEntity1 {
            get { return this.responsiblePartyActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090108ca.HealthcareWorker ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090108ca.HealthcareWorker) this.responsiblePartyActingPerson : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090108ca.HealthcareWorker) null; }
        }
        public bool HasResponsiblePartyActingPersonAsAssignedEntity1() {
            return (this.responsiblePartyActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090108ca.HealthcareWorker);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090508ca.HealthcareOrganization ResponsiblePartyActingPersonAsAssignedEntity2 {
            get { return this.responsiblePartyActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090508ca.HealthcareOrganization ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090508ca.HealthcareOrganization) this.responsiblePartyActingPerson : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090508ca.HealthcareOrganization) null; }
        }
        public bool HasResponsiblePartyActingPersonAsAssignedEntity2() {
            return (this.responsiblePartyActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090508ca.HealthcareOrganization);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt910108ca.RelatedPerson ResponsiblePartyActingPersonAsPersonalRelationship {
            get { return this.responsiblePartyActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt910108ca.RelatedPerson ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt910108ca.RelatedPerson) this.responsiblePartyActingPerson : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt910108ca.RelatedPerson) null; }
        }
        public bool HasResponsiblePartyActingPersonAsPersonalRelationship() {
            return (this.responsiblePartyActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt910108ca.RelatedPerson);
        }

        /**
         * <summary>Relationship: 
         * REPC_MT500004CA.Performer3.actingPerson</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"performer/actingPerson"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt911108ca.IActingPerson> PerformerActingPerson {
            get { return this.performerActingPerson; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT500004CA.PatientCareProvisionEvent.author</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.ChangedBy Author {
            get { return this.author; }
            set { this.author = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT500004CA.Informant.actingPerson</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"informant/actingPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt911107ca.IActingPerson InformantActingPerson {
            get { return this.informantActingPerson; }
            set { this.informantActingPerson = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090108ca.HealthcareWorker InformantActingPersonAsAssignedEntity1 {
            get { return this.informantActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090108ca.HealthcareWorker ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090108ca.HealthcareWorker) this.informantActingPerson : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090108ca.HealthcareWorker) null; }
        }
        public bool HasInformantActingPersonAsAssignedEntity1() {
            return (this.informantActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090108ca.HealthcareWorker);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090508ca.HealthcareOrganization InformantActingPersonAsAssignedEntity2 {
            get { return this.informantActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090508ca.HealthcareOrganization ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090508ca.HealthcareOrganization) this.informantActingPerson : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090508ca.HealthcareOrganization) null; }
        }
        public bool HasInformantActingPersonAsAssignedEntity2() {
            return (this.informantActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090508ca.HealthcareOrganization);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt050207ca.Patient InformantActingPersonAsPatient {
            get { return this.informantActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt050207ca.Patient ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt050207ca.Patient) this.informantActingPerson : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt050207ca.Patient) null; }
        }
        public bool HasInformantActingPersonAsPatient() {
            return (this.informantActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt050207ca.Patient);
        }

        /**
         * <summary>Relationship: 
         * REPC_MT500004CA.Discharger.actingPerson</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"discharger/actingPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt911108ca.IActingPerson DischargerActingPerson {
            get { return this.dischargerActingPerson; }
            set { this.dischargerActingPerson = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090108ca.HealthcareWorker DischargerActingPersonAsAssignedEntity1 {
            get { return this.dischargerActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090108ca.HealthcareWorker ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090108ca.HealthcareWorker) this.dischargerActingPerson : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090108ca.HealthcareWorker) null; }
        }
        public bool HasDischargerActingPersonAsAssignedEntity1() {
            return (this.dischargerActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090108ca.HealthcareWorker);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090508ca.HealthcareOrganization DischargerActingPersonAsAssignedEntity2 {
            get { return this.dischargerActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090508ca.HealthcareOrganization ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090508ca.HealthcareOrganization) this.dischargerActingPerson : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090508ca.HealthcareOrganization) null; }
        }
        public bool HasDischargerActingPersonAsAssignedEntity2() {
            return (this.dischargerActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090508ca.HealthcareOrganization);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt910108ca.RelatedPerson DischargerActingPersonAsPersonalRelationship {
            get { return this.dischargerActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt910108ca.RelatedPerson ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt910108ca.RelatedPerson) this.dischargerActingPerson : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt910108ca.RelatedPerson) null; }
        }
        public bool HasDischargerActingPersonAsPersonalRelationship() {
            return (this.dischargerActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt910108ca.RelatedPerson);
        }

        /**
         * <summary>Relationship: 
         * REPC_MT500004CA.Custodian.assignedDevice</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"custodian1/assignedDevice"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090310ca.EHRRepository Custodian1AssignedDevice {
            get { return this.custodian1AssignedDevice; }
            set { this.custodian1AssignedDevice = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT500004CA.Custodian2.serviceDeliveryLocation</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"custodian2/serviceDeliveryLocation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt240003ca.ServiceLocation Custodian2ServiceDeliveryLocation {
            get { return this.custodian2ServiceDeliveryLocation; }
            set { this.custodian2ServiceDeliveryLocation = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT500004CA.PatientCareProvisionEvent.location</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-100)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.OccurredAt> Location {
            get { return this.location; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT500004CA.Outcome.diagnosisEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"outcome/diagnosisEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.DischargeDiagnosis> OutcomeDiagnosisEvent {
            get { return this.outcomeDiagnosisEvent; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT500004CA.InFulfillmentOf.actRequest</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"inFulfillmentOf/actRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.Request_1 InFulfillmentOfActRequest {
            get { return this.inFulfillmentOfActRequest; }
            set { this.inFulfillmentOfActRequest = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT500004CA.Predecessor.oldPatientCareProvisionEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"predecessor/oldPatientCareProvisionEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.OldPatientCareProvisionEvent> PredecessorOldPatientCareProvisionEvent {
            get { return this.predecessorOldPatientCareProvisionEvent; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT500004CA.ReplacementOf.patientCareProvisionEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"replacementOf/patientCareProvisionEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Repc_mt500004ca.CareComposition ReplacementOfPatientCareProvisionEvent {
            get { return this.replacementOfPatientCareProvisionEvent; }
            set { this.replacementOfPatientCareProvisionEvent = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT500004CA.PatientCareProvisionEvent.reason</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-10)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reason"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.BecauseOf> Reason {
            get { return this.reason; }
        }

        /**
         * <summary>Relationship: REPC_MT500004CA.Component3.actEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component1/actEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.ActEvent> Component1ActEvent {
            get { return this.component1ActEvent; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT500004CA.Component2.patientCareProvisionEventPortion</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component2/patientCareProvisionEventPortion"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.ParticipantGroupings> Component2PatientCareProvisionEventPortion {
            get { return this.component2PatientCareProvisionEventPortion; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT500004CA.Predecessor2.newPatientCareProvisionEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"successor/newPatientCareProvisionEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.NewPatientCareProvisionEvent SuccessorNewPatientCareProvisionEvent {
            get { return this.successorNewPatientCareProvisionEvent; }
            set { this.successorNewPatientCareProvisionEvent = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT500004CA.PatientCareProvisionEvent.subjectOf1</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-100)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf1"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.Includes> SubjectOf1 {
            get { return this.subjectOf1; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT500004CA.Subject3.controlActEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2/controlActEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt130001ca.VersionInformation SubjectOf2ControlActEvent {
            get { return this.subjectOf2ControlActEvent; }
            set { this.subjectOf2ControlActEvent = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT500004CA.Subject.annotationIndicator</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf3/annotationIndicator"})]
        public bool? SubjectOf3AnnotationIndicator {
            get { return this.subjectOf3AnnotationIndicator.Value; }
            set { this.subjectOf3AnnotationIndicator.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT500004CA.Subject4.controlActEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf4/controlActEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged.ControlActEvent SubjectOf4ControlActEvent {
            get { return this.subjectOf4ControlActEvent; }
            set { this.subjectOf4ControlActEvent = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT500004CA.Component.patientCareProvisionEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"componentOf/patientCareProvisionEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt011001ca.CareCompositions> ComponentOfPatientCareProvisionEvent {
            get { return this.componentOfPatientCareProvisionEvent; }
        }

    }

}