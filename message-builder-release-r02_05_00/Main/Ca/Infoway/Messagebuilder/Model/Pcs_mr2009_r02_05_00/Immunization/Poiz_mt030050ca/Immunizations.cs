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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Poiz_mt030050ca {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt050207ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Immunizations</summary>
     * 
     * <p>Necessary component of a person's overall vaccine 
     * profile. Helps deal with outbreaks and also vaccine 
     * contraindication checking.</p> <p>A record of products 
     * administered to a patient specific to immunization.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POIZ_MT030050CA.Immunization"})]
    public class Immunizations : MessagePartBean {

        private II id;
        private BL negationInd;
        private CS statusCode;
        private TS effectiveTime;
        private SET<CV, Code> confidentialityCode;
        private CV uncertaintyCode;
        private CV routeCode;
        private CV approachSiteCode;
        private PQ doseQuantity;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt050207ca.Patient subjectPatient;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Merged.Vaccine consumableAdministerableMedicineAdministerableVaccine;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.HealthcareWorker responsiblePartyAssignedEntity;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.AdministeredBy performer;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.HealthcareWorker authorAssignedEntity;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Merged.Informant informant;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.HealthcareWorker authenticatorAssignedEntity;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.OccurredAt location;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Merged.InFulfillmentOf inFulfillmentOf;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Merged.Reason reason;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Merged.Consent authorizationConsent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Merged.PatientImmunizationObservations> pertinentInformationPatientImmunizationObservations;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.Includes> subjectOf;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Merged.InvestigationEvent cause1InvestigationEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Merged.IntoleranceCondition> cause2IntoleranceCondition;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Merged.HealthDocument referencedByHealthDocument;

        public Immunizations() {
            this.id = new IIImpl();
            this.negationInd = new BLImpl();
            this.statusCode = new CSImpl();
            this.effectiveTime = new TSImpl();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.uncertaintyCode = new CVImpl();
            this.routeCode = new CVImpl();
            this.approachSiteCode = new CVImpl();
            this.doseQuantity = new PQImpl();
            this.pertinentInformationPatientImmunizationObservations = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Merged.PatientImmunizationObservations>();
            this.subjectOf = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.Includes>();
            this.cause2IntoleranceCondition = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Merged.IntoleranceCondition>();
        }
        /**
         * <summary>Business Name: A:Immunization Event ID</summary>
         * 
         * <remarks>Relationship: POIZ_MT030050CA.Immunization.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for the 
         * unique referencing of a specific immunization record. Thus 
         * the mandatory requirement.</p> <p>This is an identifier 
         * assigned to a unique instance of an immunization record.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: Not Immunized?</summary>
         * 
         * <remarks>Relationship: 
         * POIZ_MT030050CA.Immunization.negationInd 
         * Conformance/Cardinality: MANDATORY (1) <p>Tracking failures 
         * to be immunized is also important in immunization reporting. 
         * Marked as mandatory because it is not meaningful for this 
         * flag to be 'unknown'.</p> <p>An explicit indication that a 
         * person has not been immunized with the specified vaccine at 
         * the time indicated.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"negationInd"})]
        public bool? NegationInd {
            get { return this.negationInd.Value; }
            set { this.negationInd.Value = value; }
        }

        /**
         * <summary>Business Name: Immunization Event Status</summary>
         * 
         * <remarks>Relationship: 
         * POIZ_MT030050CA.Immunization.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Needed to 
         * differentiate between valid, obsolete and invalid 
         * immunization events (e.g. immunization event has been 
         * retracted or nullified) and is therefore mandatory.</p> 
         * <p>Nullified=Retracted</p> <p>Status of the immunization 
         * event</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: Immunization Date</summary>
         * 
         * <remarks>Relationship: 
         * POIZ_MT030050CA.Immunization.effectiveTime 
         * Conformance/Cardinality: MANDATORY (1) <p>Important 
         * information for establishing the validity of the 
         * immunization records, and therefore mandatory. Also used in 
         * the scheduling of subsequent immunizations.</p> <p>The date 
         * the vaccine was administered to the patient.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public PlatformDate EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: Immunization Masking Indicators</summary>
         * 
         * <remarks>Relationship: 
         * POIZ_MT030050CA.Immunization.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-2) <p>Provides support 
         * for additional confidentiality constraint to reflect the 
         * wishes of the patient.</p><p>The attribute is optional 
         * because not all systems will support masking.</p> <p>Denotes 
         * access restriction place on the immunization record.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_BasicConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_BasicConfidentialityKind>(); }
        }

        /**
         * <summary>Business Name: Uncertainty Code</summary>
         * 
         * <remarks>Relationship: 
         * POIZ_MT030050CA.Immunization.uncertaintyCode 
         * Conformance/Cardinality: REQUIRED (1) <p>Allows for users of 
         * information to determine the degree of uncertainty regarding 
         * the details of an immunization event and is therefore 
         * populated.</p> <p>Only populated when it is needed to 
         * communicate a degree of uncertainty - i.e. historical 
         * information.</p> <p>An indication of uncertainty regarding 
         * an immunization event</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"uncertaintyCode"})]
        public ActUncertainty UncertaintyCode {
            get { return (ActUncertainty) this.uncertaintyCode.Value; }
            set { this.uncertaintyCode.Value = value; }
        }

        /**
         * <summary>Business Name: Route of Administration</summary>
         * 
         * <remarks>Relationship: 
         * POIZ_MT030050CA.Immunization.routeCode 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>RouteCode is 
         * Required if not using SNOMED.</p> <p>Ensures consistency in 
         * description of routes.</p><p>Attribute is marked 'optional' 
         * to allow for use of pre-coordinated SNOMED Codes.</p> <p>The 
         * route by which the drug was administered to the patient, for 
         * example, sub-cutaneous, intra-muscular</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"routeCode"})]
        public RouteOfAdministration RouteCode {
            get { return (RouteOfAdministration) this.routeCode.Value; }
            set { this.routeCode.Value = value; }
        }

        /**
         * <summary>Business Name: Anatomical Site</summary>
         * 
         * <remarks>Relationship: 
         * POIZ_MT030050CA.Immunization.approachSiteCode 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>approachSiteCode 
         * is Required if not using SNOMED</p> <p>Site of 
         * administration is needed for follow up in case of an adverse 
         * event and in some jurisdictions is part of the minimum 
         * dataset per national standard and legal client 
         * record.</p><p>Attribute is marked &quot;optional&quot; to 
         * allow for use of pre-coordinated SNOMED Codes.</p> <p>A 
         * coded value denoting the body area where the immunization 
         * was administered.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"approachSiteCode"})]
        public HumanSubstanceAdministrationSite ApproachSiteCode {
            get { return (HumanSubstanceAdministrationSite) this.approachSiteCode.Value; }
            set { this.approachSiteCode.Value = value; }
        }

        /**
         * <summary>Business Name: Quantity Administered</summary>
         * 
         * <remarks>Relationship: 
         * POIZ_MT030050CA.Immunization.doseQuantity 
         * Conformance/Cardinality: REQUIRED (1) <p>Useful for 
         * evaluating reaction, evaluating vaccine failure and for 
         * checking contraindication.</p><p>Attribute is populated to 
         * allow for situations where quantity may not be known and 
         * thus null flavor must be specified.</p> <p>The amount of the 
         * drug product administered to/by the patient.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"doseQuantity"})]
        public PhysicalQuantity DoseQuantity {
            get { return this.doseQuantity.Value; }
            set { this.doseQuantity.Value = value; }
        }

        /**
         * <summary>Relationship: POIZ_MT030050CA.Subject10.patient</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject/patient"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt050207ca.Patient SubjectPatient {
            get { return this.subjectPatient; }
            set { this.subjectPatient = value; }
        }

        /**
         * <summary>Relationship: 
         * POIZ_MT030050CA.AdministerableMedicine.administerableVaccine</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"consumable/administerableMedicine/administerableVaccine"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Merged.Vaccine ConsumableAdministerableMedicineAdministerableVaccine {
            get { return this.consumableAdministerableMedicineAdministerableVaccine; }
            set { this.consumableAdministerableMedicineAdministerableVaccine = value; }
        }

        /**
         * <summary>Relationship: 
         * POIZ_MT030050CA.ResponsibleParty.assignedEntity</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.HealthcareWorker ResponsiblePartyAssignedEntity {
            get { return this.responsiblePartyAssignedEntity; }
            set { this.responsiblePartyAssignedEntity = value; }
        }

        /**
         * <summary>Relationship: 
         * POIZ_MT030050CA.Immunization.performer</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"performer"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.AdministeredBy Performer {
            get { return this.performer; }
            set { this.performer = value; }
        }

        /**
         * <summary>Relationship: POIZ_MT030050CA.Author.assignedEntity</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.HealthcareWorker AuthorAssignedEntity {
            get { return this.authorAssignedEntity; }
            set { this.authorAssignedEntity = value; }
        }

        /**
         * <summary>Relationship: 
         * POIZ_MT030050CA.Immunization.informant</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"informant"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Merged.Informant Informant {
            get { return this.informant; }
            set { this.informant = value; }
        }

        /**
         * <summary>Relationship: 
         * POIZ_MT030050CA.Authenticator.assignedEntity</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"authenticator/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.HealthcareWorker AuthenticatorAssignedEntity {
            get { return this.authenticatorAssignedEntity; }
            set { this.authenticatorAssignedEntity = value; }
        }

        /**
         * <summary>Relationship: POIZ_MT030050CA.Immunization.location</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.OccurredAt Location {
            get { return this.location; }
            set { this.location = value; }
        }

        /**
         * <summary>Relationship: 
         * POIZ_MT030050CA.Immunization.inFulfillmentOf</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"inFulfillmentOf"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Merged.InFulfillmentOf InFulfillmentOf {
            get { return this.inFulfillmentOf; }
            set { this.inFulfillmentOf = value; }
        }

        /**
         * <summary>Relationship: POIZ_MT030050CA.Immunization.reason</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reason"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Merged.Reason Reason {
            get { return this.reason; }
            set { this.reason = value; }
        }

        /**
         * <summary>Relationship: POIZ_MT030050CA.Authorization.consent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"authorization/consent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Merged.Consent AuthorizationConsent {
            get { return this.authorizationConsent; }
            set { this.authorizationConsent = value; }
        }

        /**
         * <summary>Relationship: 
         * POIZ_MT030050CA.PertinentInformation.patientImmunizationObservations</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"pertinentInformation/patientImmunizationObservations"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Merged.PatientImmunizationObservations> PertinentInformationPatientImmunizationObservations {
            get { return this.pertinentInformationPatientImmunizationObservations; }
        }

        /**
         * <summary>Relationship: 
         * POIZ_MT030050CA.Immunization.subjectOf</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-99)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.Includes> SubjectOf {
            get { return this.subjectOf; }
        }

        /**
         * <summary>Relationship: 
         * POIZ_MT030050CA.CauseOf.investigationEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"cause1/investigationEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Merged.InvestigationEvent Cause1InvestigationEvent {
            get { return this.cause1InvestigationEvent; }
            set { this.cause1InvestigationEvent = value; }
        }

        /**
         * <summary>Relationship: 
         * POIZ_MT030050CA.CauseOf2.intoleranceCondition</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"cause2/intoleranceCondition"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Merged.IntoleranceCondition> Cause2IntoleranceCondition {
            get { return this.cause2IntoleranceCondition; }
        }

        /**
         * <summary>Relationship: 
         * POIZ_MT030050CA.Reference.healthDocument</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"referencedBy/healthDocument"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Immunization.Merged.HealthDocument ReferencedByHealthDocument {
            get { return this.referencedByHealthDocument; }
            set { this.referencedByHealthDocument = value; }
        }

    }

}