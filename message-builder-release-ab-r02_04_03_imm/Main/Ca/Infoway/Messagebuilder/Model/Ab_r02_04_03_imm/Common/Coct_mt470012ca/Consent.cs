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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt470012ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt050202ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt090102ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt090502ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt910102ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt911102ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Merged;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Domainvalue;
    using System;


    /**
     * <summary>Business Name: Consent</summary>
     * 
     * <p>One and only one of author2 (Consenter) and author1 
     * (Provider) must be specified.</p> <p>Provides authorization 
     * to record and/or view patient, client, or provider 
     * information.</p><p>Indicates the consent or keyword used to 
     * authorize access or update, including a reason for access; 
     * May also be used to override access restriction to the 
     * information ('break the glass') on a message by message 
     * basis. May be required on a Prescription Request to indicate 
     * a keyword for DUR processing.</p> <p>The keywords will not 
     * be passed from prescriber to dispenser by the DIS.</p> 
     * <p>Information pertaining to a patient's (or client or 
     * provider) agreement/acceptance to have his/her clinical or 
     * demographic information electronically stored and 
     * shared.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT470012CA.ConsentEvent"})]
    public class Consent : MessagePartBean {

        private II id;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private CV reasonCode;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt470012ca.ISubjectChoice subject1SubjectChoice;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Merged.ConsentedToBy author1;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt090102ca.HealthcareWorker author2AssignedEntity;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt470012ca.AccessType subject2InformDefinition;

        public Consent() {
            this.id = new IIImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.reasonCode = new CVImpl();
        }
        /**
         * <summary>Business Name: D:Consent Form Number</summary>
         * 
         * <remarks>Relationship: COCT_MT470012CA.ConsentEvent.id 
         * Conformance/Cardinality: REQUIRED (0-1) 
         * <p>Authorization.formNumber</p> <p>Provides a traceable 
         * audit link between a physical consent form and its 
         * electronic record</p> <p>A unique identifier for a specific 
         * consent for a patient, client or provider.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: C:Consent Effective and End Time</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT470012CA.ConsentEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) 
         * <p>Authorization.endTime (high)</p> <p>Most consents are not 
         * open-ended, to ensure the patient, client, or provider 
         * retains a level of control.</p> <p>Indicates the time that 
         * the consent will expire. 'Low' is effective time and 'High' 
         * is end time.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: E:Consent Override Reason</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT470012CA.ConsentEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>If author1 
         * (provider) is specified, reason code must be specified.</p> 
         * <p>Authorization.reason (mnemonic)</p> 
         * <p>Authorization.comment (original text)</p> <p>Important 
         * for audit purposes</p> <p>Indicates a reason for overriding 
         * a patient's (or client or provider) consent rules.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reasonCode"})]
        public ActConsentInformationAccessOverrideReason ReasonCode {
            get { return (ActConsentInformationAccessOverrideReason) this.reasonCode.Value; }
            set { this.reasonCode.Value = value; }
        }

        /**
         * <summary>Relationship: COCT_MT470012CA.Subject.subjectChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject1/subjectChoice"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt470012ca.ISubjectChoice Subject1SubjectChoice {
            get { return this.subject1SubjectChoice; }
            set { this.subject1SubjectChoice = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt050202ca.Patient Subject1SubjectChoiceAsPatient1 {
            get { return this.subject1SubjectChoice is Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt050202ca.Patient ? (Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt050202ca.Patient) this.subject1SubjectChoice : (Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt050202ca.Patient) null; }
        }
        public bool HasSubject1SubjectChoiceAsPatient1() {
            return (this.subject1SubjectChoice is Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt050202ca.Patient);
        }

        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt090102ca.HealthcareWorker Subject1SubjectChoiceAsAssignedEntity1 {
            get { return this.subject1SubjectChoice is Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt090102ca.HealthcareWorker ? (Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt090102ca.HealthcareWorker) this.subject1SubjectChoice : (Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt090102ca.HealthcareWorker) null; }
        }
        public bool HasSubject1SubjectChoiceAsAssignedEntity1() {
            return (this.subject1SubjectChoice is Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt090102ca.HealthcareWorker);
        }

        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt090502ca.HealthcareOrganization Subject1SubjectChoiceAsAssignedEntity2 {
            get { return this.subject1SubjectChoice is Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt090502ca.HealthcareOrganization ? (Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt090502ca.HealthcareOrganization) this.subject1SubjectChoice : (Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt090502ca.HealthcareOrganization) null; }
        }
        public bool HasSubject1SubjectChoiceAsAssignedEntity2() {
            return (this.subject1SubjectChoice is Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt090502ca.HealthcareOrganization);
        }

        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt910102ca.RelatedPerson Subject1SubjectChoiceAsPersonalRelationship {
            get { return this.subject1SubjectChoice is Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt910102ca.RelatedPerson ? (Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt910102ca.RelatedPerson) this.subject1SubjectChoice : (Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt910102ca.RelatedPerson) null; }
        }
        public bool HasSubject1SubjectChoiceAsPersonalRelationship() {
            return (this.subject1SubjectChoice is Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt910102ca.RelatedPerson);
        }

        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt911102ca.IActingPerson Subject1SubjectChoiceAsActingPerson {
            get { return this.subject1SubjectChoice is Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt911102ca.IActingPerson ? (Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt911102ca.IActingPerson) this.subject1SubjectChoice : (Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt911102ca.IActingPerson) null; }
        }
        public bool HasSubject1SubjectChoiceAsActingPerson() {
            return (this.subject1SubjectChoice is Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt911102ca.IActingPerson);
        }

        /**
         * <summary>Relationship: COCT_MT470012CA.ConsentEvent.author1</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author1"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Merged.ConsentedToBy Author1 {
            get { return this.author1; }
            set { this.author1 = value; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT470012CA.Author2.assignedEntity</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author2/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt090102ca.HealthcareWorker Author2AssignedEntity {
            get { return this.author2AssignedEntity; }
            set { this.author2AssignedEntity = value; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT470012CA.Subject2.informDefinition</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject2/informDefinition"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt470012ca.AccessType Subject2InformDefinition {
            get { return this.subject2InformDefinition; }
            set { this.subject2InformDefinition = value; }
        }

    }

}