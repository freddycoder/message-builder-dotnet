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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Immunization.Poiz_mt030050ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt050203ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt120600ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt220200ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Immunization.Merged;
    using System;


    /**
     * <summary>Business Name: Immunization</summary>
     * 
     * <p>Allows capturing a patient's immunization profile</p> 
     * <p>Represents a single immunization occurrence for a 
     * particular patient</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POIZ_MT030050CA.Immunization"})]
    public class Immunization : MessagePartBean {

        private CD code;
        private BL negationInd;
        private TS effectiveTime;
        private CV confidentialityCode;
        private CV reasonCode;
        private CV routeCode;
        private CV approachSiteCode;
        private PQ doseQuantity;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt050203ca.Patient subjectPatient;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt220200ca.DrugProduct consumableMedication;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Immunization.Poiz_mt030050ca.InformantionSourceRole informantInformantionSourceRole;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Immunization.Merged.PartOf inFulfillmentOf;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt120600ca.Notes subjectOfAnnotation;
        private BL causeAdverseReactionObservationEvent;

        public Immunization() {
            this.code = new CDImpl();
            this.negationInd = new BLImpl();
            this.effectiveTime = new TSImpl();
            this.confidentialityCode = new CVImpl();
            this.reasonCode = new CVImpl();
            this.routeCode = new CVImpl();
            this.approachSiteCode = new CVImpl();
            this.doseQuantity = new PQImpl();
            this.causeAdverseReactionObservationEvent = new BLImpl(false);
        }
        /**
         * <summary>Business Name: Immunization Type</summary>
         * 
         * <remarks>Relationship: POIZ_MT030050CA.Immunization.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates that the 
         * type of administration is an administration, and for SNOMED, 
         * also indicates the specific type of administration. Thus the 
         * attribute is mandatory. The datatype is CD to allow for 
         * SNOMED post-coordination.</p> <p>Indicates what type of 
         * administration is being performed.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActCode Code {
            get { return (ActCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Not Immunized?</summary>
         * 
         * <remarks>Relationship: 
         * POIZ_MT030050CA.Immunization.negationInd 
         * Conformance/Cardinality: MANDATORY (1) 
         * <p>NotImmunizedFlag</p> <p>CompletionStstus (true = Not 
         * administered)</p> <p>Tracking failures to be immunized is 
         * also important in immunization reporting. This flag must 
         * always be known and is always mandatory.</p> <p>An explicit 
         * indication that a person has not been immunized with the 
         * specified vaccine at the time indicated.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"negationInd"})]
        public bool? NegationInd {
            get { return this.negationInd.Value; }
            set { this.negationInd.Value = value; }
        }

        /**
         * <summary>Business Name: C:Immunization Date</summary>
         * 
         * <remarks>Relationship: 
         * POIZ_MT030050CA.Immunization.effectiveTime 
         * Conformance/Cardinality: MANDATORY (1) 
         * <p>DateOfVaccination</p> <p>Important information for 
         * establishing the validity of the immunization records, and 
         * therefore mandatory. Also used in the scheduling of 
         * subsequent immunizations.</p> <p>The date vaccination(s) was 
         * administered to the patient.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public PlatformDate EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: D:Immunization Masking Indicator</summary>
         * 
         * <remarks>Relationship: 
         * POIZ_MT030050CA.Immunization.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Provides support 
         * for additional confidentiality constraint to reflect the 
         * wishes of the patient.</p><p>The attribute is optional 
         * because not all systems will support masking.</p> <p>Denotes 
         * access restriction placed on the immunization record. 
         * Methods for accessing masked immunization records will be 
         * governed by each jurisdiction (e.g. court orders, shared 
         * secret/consent, etc.).</p><p>The default is 'NORMAL'.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public x_VeryBasicConfidentialityKind ConfidentialityCode {
            get { return (x_VeryBasicConfidentialityKind) this.confidentialityCode.Value; }
            set { this.confidentialityCode.Value = value; }
        }

        /**
         * <summary>Business Name: Immunization Refusal Reason</summary>
         * 
         * <remarks>Relationship: 
         * POIZ_MT030050CA.Immunization.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>If immunization 
         * was not refused, then refusal reason must not be specified 
         * otherwise field should be treated as populated.</p> 
         * <p>CompletionStatus (Refused)</p> <p>Useful information for 
         * planning future immunization encounters for the patient.</p> 
         * <p>A coded value denoting a patient's reason for refusing to 
         * be immunized.</p><p>Typical reasons include: Parental 
         * decision, Religious exemption, Patient decision, etc</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reasonCode"})]
        public ActNoImmunizationReason ReasonCode {
            get { return (ActNoImmunizationReason) this.reasonCode.Value; }
            set { this.reasonCode.Value = value; }
        }

        /**
         * <summary>Business Name: E:Route of Administration</summary>
         * 
         * <remarks>Relationship: 
         * POIZ_MT030050CA.Immunization.routeCode 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>routeCode must be 
         * required if not using SNOMED</p> <p>RXR-1</p> <p>Ensures 
         * consistency in description of routes.</p><p>Attribute is 
         * marked &quot;optional&quot; to allow for use of 
         * pre-coordinated SNOMED Codes.</p> <p>This is the means by 
         * which the drug was administered to the patient.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"routeCode"})]
        public RouteOfAdministration RouteCode {
            get { return (RouteOfAdministration) this.routeCode.Value; }
            set { this.routeCode.Value = value; }
        }

        /**
         * <summary>Business Name: Administration Site</summary>
         * 
         * <remarks>Relationship: 
         * POIZ_MT030050CA.Immunization.approachSiteCode 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>approachSiteCode 
         * must be required if not using SNOMED</p> <p>RXR.2</p> 
         * <p>Some immunizations are intended to adjust from site to 
         * site. (E.g. if first injection is given in right deltoid, 
         * first booster should be given in left 
         * deltoid.)</p><p>Attribute is marked &quot;optional&quot; to 
         * allow for use of pre-coordinated SNOMED Codes.</p> <p>A 
         * coded value denoting the body area where the immunization 
         * was administered.</p><p>This is also referred to as the 
         * anatomical site of vaccination.</p></remarks>
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
         * evaluating reaction and for checking 
         * contraindication.</p><p>Attribute is populated to allow for 
         * situations where quantity may not be known and thus null 
         * flavor must be specified.</p> <p>The amount of the vaccine 
         * administered to/by the patient.</p></remarks>
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
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt050203ca.Patient SubjectPatient {
            get { return this.subjectPatient; }
            set { this.subjectPatient = value; }
        }

        /**
         * <summary>Relationship: 
         * POIZ_MT030050CA.Consumable2.medication</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"consumable/medication"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt220200ca.DrugProduct ConsumableMedication {
            get { return this.consumableMedication; }
            set { this.consumableMedication = value; }
        }

        /**
         * <summary>Relationship: 
         * POIZ_MT030050CA.Informant.informantionSourceRole</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"informant/informantionSourceRole"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Immunization.Poiz_mt030050ca.InformantionSourceRole InformantInformantionSourceRole {
            get { return this.informantInformantionSourceRole; }
            set { this.informantInformantionSourceRole = value; }
        }

        /**
         * <summary>Relationship: 
         * POIZ_MT030050CA.Immunization.inFulfillmentOf</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"inFulfillmentOf"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Immunization.Merged.PartOf InFulfillmentOf {
            get { return this.inFulfillmentOf; }
            set { this.inFulfillmentOf = value; }
        }

        /**
         * <summary>Relationship: POIZ_MT030050CA.Subject9.annotation</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf/annotation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt120600ca.Notes SubjectOfAnnotation {
            get { return this.subjectOfAnnotation; }
            set { this.subjectOfAnnotation = value; }
        }

        /**
         * <summary>Relationship: 
         * POIZ_MT030050CA.CauseOf.adverseReactionObservationEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"cause/adverseReactionObservationEvent"})]
        public bool? CauseAdverseReactionObservationEvent {
            get { return this.causeAdverseReactionObservationEvent.Value; }
            set { this.causeAdverseReactionObservationEvent.Value = value; }
        }

    }

}