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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */

/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Quqi_mt020000ab {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt011001ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt050201ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt050202ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt050207ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt090102ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt090502ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt240002ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt260012ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt470002ab;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt910102ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt911102ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Trigger Event</summary>
     * 
     * <p>Key to understanding what action a message 
     * represents.</p> <p>There may be constraints on the usage of 
     * the effectiveTime and reasonCode attributes in the 
     * definition of the interaction or the trigger events which 
     * are conveyed with this wrapper.</p> <p>Identifies the action 
     * that resulted in this message being sent.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"QUQI_MT020000AB.ControlActEvent"})]
    public class TriggerEvent<PL> : MessagePartBean {

        private II id;
        private CV code;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private CV reasonCode;
        private CE languageCode;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Merged.IPatient recordTargetPatient1;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt090102ca.HealthcareWorker responsiblePartyAssignedEntity;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Merged.CreatedBy author;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt911102ca.IActingPerson dataEntererActingPerson;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt240002ca.ServiceLocation dataEntryLocationServiceDeliveryLocation;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt240002ca.ServiceLocation locationServiceDeliveryLocation;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Merged.AuthenticationToken pertinentInformationAuthorizationToken;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt260012ca.Issues> subjectOf1DetectedIssueEvent;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt470002ab.Consent subjectOf2ConsentEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt011001ca.CareCompositions> componentOfPatientCareProvisionEvent;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Merged.QueryByParameter<PL> queryByParameter;

        public TriggerEvent() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.reasonCode = new CVImpl();
            this.languageCode = new CEImpl();
            this.subjectOf1DetectedIssueEvent = new List<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt260012ca.Issues>();
            this.componentOfPatientCareProvisionEvent = new List<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt011001ca.CareCompositions>();
        }
        /**
         * <summary>Business Name: B:Event Identifier</summary>
         * 
         * <remarks>Relationship: QUQI_MT020000AB.ControlActEvent.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows the event 
         * to be referenced (for undos) and also indicates whether 
         * multiple interactions were caused by the same triggering 
         * event. Also used for audit purposes.</p> <p>Identifier needs 
         * to be persisted by receiving applications, except for 
         * queries (queries cannot be retracted or undone).</p> <p>A 
         * unique identifier for this particular event assigned by the 
         * system in which the event occurred. The identifier must be 
         * unique and different from the event identifier that is 
         * present on the request - it must be generated by the 
         * responding application.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: A:Event Type</summary>
         * 
         * <remarks>Relationship: QUQI_MT020000AB.ControlActEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>This is mandatory 
         * because it is essential to understanding the meaning of the 
         * event.</p> <p>Identifies the trigger event that 
         * occurred.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public HL7TriggerEventCode Code {
            get { return (HL7TriggerEventCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: C:Event Effective Period</summary>
         * 
         * <remarks>Relationship: 
         * QUQI_MT020000AB.ControlActEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The time an event 
         * becomes effective may differ from the time the event is 
         * recorded (i.e. it may be in the future or the past). For 
         * events such as 'suspend', an intended end date may also be 
         * indicated.</p> <p>Indicates the time the event (e.g. query, 
         * change, activation) should begin and occasionally when it 
         * should end.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: E:Event Reason</summary>
         * 
         * <remarks>Relationship: 
         * QUQI_MT020000AB.ControlActEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows 
         * identifying a reason for a specific action, such as 'reason 
         * for hold' or 'reason for accessing information'.</p> <p>The 
         * domain associated with this attribute will vary for each 
         * interaction and will be noted as part of the interaction 
         * description.</p> <p>Identifies why this specific message 
         * interaction (e.g. query, activation request, modification 
         * request) occurred.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reasonCode"})]
        public ControlActReason ReasonCode {
            get { return (ControlActReason) this.reasonCode.Value; }
            set { this.reasonCode.Value = value; }
        }

        /**
         * <summary>Business Name: Message Language</summary>
         * 
         * <remarks>Relationship: 
         * QUQI_MT020000AB.ControlActEvent.languageCode 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"languageCode"})]
        public HumanLanguage LanguageCode {
            get { return (HumanLanguage) this.languageCode.Value; }
            set { this.languageCode.Value = value; }
        }

        /**
         * <summary>Relationship: QUQI_MT020000AB.RecordTarget.patient1</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"recordTarget/patient1"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Merged.IPatient RecordTargetPatient1 {
            get { return this.recordTargetPatient1; }
            set { this.recordTargetPatient1 = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt050202ca.Patient RecordTargetPatient1AsPatient1 {
            get { return this.recordTargetPatient1 is Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt050202ca.Patient ? (Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt050202ca.Patient) this.recordTargetPatient1 : (Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt050202ca.Patient) null; }
        }
        public bool HasRecordTargetPatient1AsPatient1() {
            return (this.recordTargetPatient1 is Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt050202ca.Patient);
        }

        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt050207ca.Patient RecordTargetPatient1AsPatient2 {
            get { return this.recordTargetPatient1 is Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt050207ca.Patient ? (Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt050207ca.Patient) this.recordTargetPatient1 : (Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt050207ca.Patient) null; }
        }
        public bool HasRecordTargetPatient1AsPatient2() {
            return (this.recordTargetPatient1 is Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt050207ca.Patient);
        }

        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt050201ca.Patient RecordTargetPatient1AsPatient3 {
            get { return this.recordTargetPatient1 is Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt050201ca.Patient ? (Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt050201ca.Patient) this.recordTargetPatient1 : (Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt050201ca.Patient) null; }
        }
        public bool HasRecordTargetPatient1AsPatient3() {
            return (this.recordTargetPatient1 is Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt050201ca.Patient);
        }

        /**
         * <summary>Relationship: 
         * QUQI_MT020000AB.ResponsibleParty.assignedEntity</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt090102ca.HealthcareWorker ResponsiblePartyAssignedEntity {
            get { return this.responsiblePartyAssignedEntity; }
            set { this.responsiblePartyAssignedEntity = value; }
        }

        /**
         * <summary>Relationship: 
         * QUQI_MT020000AB.ControlActEvent.author</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Merged.CreatedBy Author {
            get { return this.author; }
            set { this.author = value; }
        }

        /**
         * <summary>Relationship: 
         * QUQI_MT020000AB.DataEnterer.actingPerson</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"dataEnterer/actingPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt911102ca.IActingPerson DataEntererActingPerson {
            get { return this.dataEntererActingPerson; }
            set { this.dataEntererActingPerson = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt090102ca.HealthcareWorker DataEntererActingPersonAsAssignedEntity1 {
            get { return this.dataEntererActingPerson is Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt090102ca.HealthcareWorker ? (Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt090102ca.HealthcareWorker) this.dataEntererActingPerson : (Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt090102ca.HealthcareWorker) null; }
        }
        public bool HasDataEntererActingPersonAsAssignedEntity1() {
            return (this.dataEntererActingPerson is Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt090102ca.HealthcareWorker);
        }

        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt090502ca.HealthcareOrganization DataEntererActingPersonAsAssignedEntity2 {
            get { return this.dataEntererActingPerson is Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt090502ca.HealthcareOrganization ? (Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt090502ca.HealthcareOrganization) this.dataEntererActingPerson : (Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt090502ca.HealthcareOrganization) null; }
        }
        public bool HasDataEntererActingPersonAsAssignedEntity2() {
            return (this.dataEntererActingPerson is Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt090502ca.HealthcareOrganization);
        }

        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt910102ca.RelatedPerson DataEntererActingPersonAsPersonalRelationship {
            get { return this.dataEntererActingPerson is Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt910102ca.RelatedPerson ? (Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt910102ca.RelatedPerson) this.dataEntererActingPerson : (Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt910102ca.RelatedPerson) null; }
        }
        public bool HasDataEntererActingPersonAsPersonalRelationship() {
            return (this.dataEntererActingPerson is Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt910102ca.RelatedPerson);
        }

        /**
         * <summary>Relationship: 
         * QUQI_MT020000AB.DataEntryLocation.serviceDeliveryLocation</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"dataEntryLocation/serviceDeliveryLocation"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt240002ca.ServiceLocation DataEntryLocationServiceDeliveryLocation {
            get { return this.dataEntryLocationServiceDeliveryLocation; }
            set { this.dataEntryLocationServiceDeliveryLocation = value; }
        }

        /**
         * <summary>Relationship: 
         * QUQI_MT020000AB.Location.serviceDeliveryLocation</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location/serviceDeliveryLocation"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt240002ca.ServiceLocation LocationServiceDeliveryLocation {
            get { return this.locationServiceDeliveryLocation; }
            set { this.locationServiceDeliveryLocation = value; }
        }

        /**
         * <summary>Relationship: 
         * QUQI_MT020000AB.PertinentInformation.authorizationToken</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"pertinentInformation/authorizationToken"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Merged.AuthenticationToken PertinentInformationAuthorizationToken {
            get { return this.pertinentInformationAuthorizationToken; }
            set { this.pertinentInformationAuthorizationToken = value; }
        }

        /**
         * <summary>Relationship: 
         * QUQI_MT020000AB.Subject.detectedIssueEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf1/detectedIssueEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt260012ca.Issues> SubjectOf1DetectedIssueEvent {
            get { return this.subjectOf1DetectedIssueEvent; }
        }

        /**
         * <summary>Relationship: QUQI_MT020000AB.Subject3.consentEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2/consentEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt470002ab.Consent SubjectOf2ConsentEvent {
            get { return this.subjectOf2ConsentEvent; }
            set { this.subjectOf2ConsentEvent = value; }
        }

        /**
         * <summary>Relationship: 
         * QUQI_MT020000AB.Component.patientCareProvisionEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"componentOf/patientCareProvisionEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt011001ca.CareCompositions> ComponentOfPatientCareProvisionEvent {
            get { return this.componentOfPatientCareProvisionEvent; }
        }

        /**
         * <summary>Relationship: 
         * QUQI_MT020000AB.ControlActEvent.queryByParameter</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"queryByParameter"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Merged.QueryByParameter<PL> QueryByParameter {
            get { return this.queryByParameter; }
            set { this.queryByParameter = value; }
        }

    }

}