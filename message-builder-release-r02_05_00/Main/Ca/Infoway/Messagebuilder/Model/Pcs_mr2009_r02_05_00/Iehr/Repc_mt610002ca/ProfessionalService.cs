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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Repc_mt610002ca {
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
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt240003ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt910108ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt911107ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt911108ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt090108ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt090310ca;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Professional Service</summary>
     * 
     * <p>Annotation is only permitted if Annotation Indicator is 
     * not present and vice versa</p> 
     * <p>A_BillableClinicalService</p> <p>Information about 
     * surgeries, councilling and other professional services is a 
     * key element of the EHR. It provides context around services 
     * provided and may inform choices about how best to manage the 
     * patient's healthcare.</p> <p>This is the information that is 
     * recorded and maintained on a consultative, surgical or 
     * physical service (procedure) provided to the 
     * patient.</p><p>Counseling, education, surgeries and physical 
     * therapy are examples of the types of services that can be 
     * captured.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT610002CA.ProcedureEvent"})]
    public class ProfessionalService : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Comt_mt111111ca.ISHR {

        private II id;
        private CD code;
        private BL negationInd;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private SET<CV, Code> confidentialityCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt911108ca.IActingPerson responsiblePartyActingPerson;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt911108ca.IActingPerson> performerActingPerson;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.ChangedBy author;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt911107ca.IActingPerson informantActingPerson;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt090310ca.EHRRepository custodian1AssignedDevice;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt240003ca.ServiceLocation custodian2ServiceDeliveryLocation;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.OccurredAt location;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.Request_3 inFulfillmentOfActRequest;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.ActDefinition> definitionActDefinition;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.OldProcedureEvent> predecessorOldProcedureEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.BecauseOf> reason;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Repc_mt610002ca.NewProcedureEvent successorNewProcedureEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.Includes> subjectOf1;
        private BL subjectOf2AnnotationIndicator;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.ClinicalDocumentEvent subjectOf3ClinicalDocumentEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Repc_mt610002ca.Component> componentOf1;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt011001ca.CareCompositions> componentOf2PatientCareProvisionEvent;

        public ProfessionalService() {
            this.id = new IIImpl();
            this.code = new CDImpl();
            this.negationInd = new BLImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.performerActingPerson = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt911108ca.IActingPerson>();
            this.definitionActDefinition = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.ActDefinition>();
            this.predecessorOldProcedureEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.OldProcedureEvent>();
            this.reason = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.BecauseOf>();
            this.subjectOf1 = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.Includes>();
            this.subjectOf2AnnotationIndicator = new BLImpl(false);
            this.componentOf1 = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Repc_mt610002ca.Component>();
            this.componentOf2PatientCareProvisionEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt011001ca.CareCompositions>();
        }
        /**
         * <summary>Business Name: A:Service Record Id</summary>
         * 
         * <remarks>Relationship: REPC_MT610002CA.ProcedureEvent.id 
         * Conformance/Cardinality: MANDATORY (1) 
         * <p>PatientConsultation.patientConsultationkey</p> 
         * <p>PatientConsultation.externalId</p> <p>ZRV.5</p> 
         * <p>ZPS.2</p> <p>ZPS.3</p> <p>Claim.455-EM (root)</p> 
         * <p>Claim.402-D2 (extension)</p> 
         * <p>A_BillableClinicalService</p> <p> <i>Allows for unique 
         * identification of the Professional Service and is therefore 
         * mandatory. Supports drill-down queries, linking of this 
         * record to other records, matching of EHR records to 
         * locally-stored PoS records and is necessary when identifying 
         * records for amending (revising)/directional linking 
         * (superseding).</i> </p> <p> <i>A globally unique identifier 
         * assigned by the EHR to the Professional Service record.</i> 
         * </p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: B:Service Type</summary>
         * 
         * <remarks>Relationship: REPC_MT610002CA.ProcedureEvent.code 
         * Conformance/Cardinality: MANDATORY (1) 
         * <p>PatientConsultation.category</p> <p>D57</p> 
         * <p>ZPS.5.1</p> <p>ZPS.5.2 (experience handled as 
         * qualifier)</p> <p>Claim.436-E1 (code system)</p> 
         * <p>Claim.407-D7 (mnemonic)</p> <p>Claim.459-ER 
         * (modifier)</p> <p>Claim.418-DI (modifier)</p> 
         * <p>DUR/PPS.474-8E (modifier)</p> 
         * <p>A_BillableClinicalService</p> <p> <i>Service Type is used 
         * for searching and for organizing Professional Service 
         * records as well as sorting them for presentation.</i> 
         * </p><p> <i>This is a key attribute for understanding the 
         * type of record and is therefore mandatory.</i> </p><p> 
         * <i>This element makes use of the CD datatype to allow for 
         * use of the SNOMED code system that in some circumstances 
         * requires the use of post-coordination. Post-coordination is 
         * only supported by the CD datatype.</i> </p><p> <i>The 
         * element uses CWE to allow for the capture of Service Type 
         * concepts not presently supported by the approved code 
         * system(s). In this case, the human-to-human benefit of 
         * capturing additional non-coded values outweighs the 
         * penalties of capturing some information that will not be 
         * amenable to searching or categorizing.</i> </p> <p> 
         * <i>Identifies the type of Professional Service represented 
         * by this record.</i> </p><p>e.g. appendectomy, smoking 
         * cessation counseling, physiotherapy</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActProfessionalServiceCode Code {
            get { return (ActProfessionalServiceCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: C:Refuted Indicator</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT610002CA.ProcedureEvent.negationInd 
         * Conformance/Cardinality: MANDATORY (1) <p> <i>This is 
         * primarily used to supersede records where an assertion was 
         * made that is subsequently determined to be false. It is 
         * important to be able to make explicit statements that 
         * something is known to not be true.</i> </p><p> <i>This 
         * element is mandatory because it should always be known 
         * whether the record is being refuted or not.</i> </p> <p> 
         * <i>When set to true, specifically flags the Professional 
         * Service record as &quot;did not occur&quot;. The default is 
         * false. Additional details about the reasons for refuting the 
         * record may be conveyed in notes.</i> </p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"negationInd"})]
        public bool? NegationInd {
            get { return this.negationInd.Value; }
            set { this.negationInd.Value = value; }
        }

        /**
         * <summary>Business Name: E:Service Time and Length</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT610002CA.ProcedureEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (1) <p>Center date cannot 
         * be null but duration can be left unspecified if not 
         * known.</p> <p>PatientConsultation.eventTime(Low)</p> 
         * <p>patientConsultation.eventDuration(Width)</p> <p>ZPS.4 
         * (center)</p> <p>ZPS.5.2(timing portion of code set)</p> 
         * <p>Claim.457-EP</p> <p>A_BillableClinicalService</p> <p> 
         * <i>Identifies the time-period of relevance to the record 
         * that is useful in filtering and organizing 
         * &quot;time-view&quot; presentations of data. Because the 
         * timing information won't always be known, this attribute is 
         * marked as 'populated'.</i> </p> <p>The date and time during 
         * which the professional service was performed, as well as the 
         * duration of the service. May be specified as any one or two 
         * of start time, end time and duration.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: D:Service Masking Indicators</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT610002CA.ProcedureEvent.confidentialityCode 
         * Conformance/Cardinality: REQUIRED (0-2) <p>The value 
         * specified for a particular record may be overridden by a 
         * higher level masking applied to an indication, a care 
         * composition, a type of record or even all patient 
         * records.</p> <p>Communicates the desire of the patient to 
         * restrict access to this Care Composition record. Provides 
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
         * the other codes.</p><p>Masking a care composition record 
         * masks it for all associated patients (i.e. all patients 
         * involved in the care composition as a group).</p><p>Also, 
         * masking a care composition implicitly masks all records 
         * associated with that care composition.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_BasicConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_BasicConfidentialityKind>(); }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT610002CA.ResponsibleParty2.actingPerson</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/actingPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt911108ca.IActingPerson ResponsiblePartyActingPerson {
            get { return this.responsiblePartyActingPerson; }
            set { this.responsiblePartyActingPerson = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt090108ca.HealthcareWorker ResponsiblePartyActingPersonAsAssignedEntity1 {
            get { return this.responsiblePartyActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt090108ca.HealthcareWorker ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt090108ca.HealthcareWorker) this.responsiblePartyActingPerson : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt090108ca.HealthcareWorker) null; }
        }
        public bool HasResponsiblePartyActingPersonAsAssignedEntity1() {
            return (this.responsiblePartyActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt090108ca.HealthcareWorker);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt090508ca.HealthcareOrganization ResponsiblePartyActingPersonAsAssignedEntity2 {
            get { return this.responsiblePartyActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt090508ca.HealthcareOrganization ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt090508ca.HealthcareOrganization) this.responsiblePartyActingPerson : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt090508ca.HealthcareOrganization) null; }
        }
        public bool HasResponsiblePartyActingPersonAsAssignedEntity2() {
            return (this.responsiblePartyActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt090508ca.HealthcareOrganization);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt910108ca.RelatedPerson ResponsiblePartyActingPersonAsPersonalRelationship {
            get { return this.responsiblePartyActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt910108ca.RelatedPerson ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt910108ca.RelatedPerson) this.responsiblePartyActingPerson : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt910108ca.RelatedPerson) null; }
        }
        public bool HasResponsiblePartyActingPersonAsPersonalRelationship() {
            return (this.responsiblePartyActingPerson is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt910108ca.RelatedPerson);
        }

        /**
         * <summary>Relationship: 
         * REPC_MT610002CA.Performer.actingPerson</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"performer/actingPerson"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt911108ca.IActingPerson> PerformerActingPerson {
            get { return this.performerActingPerson; }
        }

        /**
         * <summary>Relationship: REPC_MT610002CA.ProcedureEvent.author</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.ChangedBy Author {
            get { return this.author; }
            set { this.author = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT610002CA.Informant.actingPerson</summary>
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
         * REPC_MT610002CA.Custodian.assignedDevice</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"custodian1/assignedDevice"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt090310ca.EHRRepository Custodian1AssignedDevice {
            get { return this.custodian1AssignedDevice; }
            set { this.custodian1AssignedDevice = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT610002CA.Custodian2.serviceDeliveryLocation</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"custodian2/serviceDeliveryLocation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt240003ca.ServiceLocation Custodian2ServiceDeliveryLocation {
            get { return this.custodian2ServiceDeliveryLocation; }
            set { this.custodian2ServiceDeliveryLocation = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT610002CA.ProcedureEvent.location</summary>
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
         * REPC_MT610002CA.InFulfillmentOf.actRequest</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"inFulfillmentOf/actRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.Request_3 InFulfillmentOfActRequest {
            get { return this.inFulfillmentOfActRequest; }
            set { this.inFulfillmentOfActRequest = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT610002CA.Definition.actDefinition</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"definition/actDefinition"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.ActDefinition> DefinitionActDefinition {
            get { return this.definitionActDefinition; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT610002CA.Predecessor.oldProcedureEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"predecessor/oldProcedureEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.OldProcedureEvent> PredecessorOldProcedureEvent {
            get { return this.predecessorOldProcedureEvent; }
        }

        /**
         * <summary>Relationship: REPC_MT610002CA.ProcedureEvent.reason</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-5)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reason"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.BecauseOf> Reason {
            get { return this.reason; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT610002CA.Predecessor2.newProcedureEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"successor/newProcedureEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Repc_mt610002ca.NewProcedureEvent SuccessorNewProcedureEvent {
            get { return this.successorNewProcedureEvent; }
            set { this.successorNewProcedureEvent = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT610002CA.ProcedureEvent.subjectOf1</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-100)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf1"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.Includes> SubjectOf1 {
            get { return this.subjectOf1; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT610002CA.Subject3.annotationIndicator</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2/annotationIndicator"})]
        public bool? SubjectOf2AnnotationIndicator {
            get { return this.subjectOf2AnnotationIndicator.Value; }
            set { this.subjectOf2AnnotationIndicator.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT610002CA.Subject4.clinicalDocumentEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf3/clinicalDocumentEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.ClinicalDocumentEvent SubjectOf3ClinicalDocumentEvent {
            get { return this.subjectOf3ClinicalDocumentEvent; }
            set { this.subjectOf3ClinicalDocumentEvent = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT610002CA.ProcedureEvent.componentOf1</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1-5)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"componentOf1"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Repc_mt610002ca.Component> ComponentOf1 {
            get { return this.componentOf1; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT610002CA.Component2.patientCareProvisionEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"componentOf2/patientCareProvisionEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt011001ca.CareCompositions> ComponentOf2PatientCareProvisionEvent {
            get { return this.componentOf2PatientCareProvisionEvent; }
        }

    }

}