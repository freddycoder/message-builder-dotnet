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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Merged {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt220100ca;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: ActiveMedication</summary>
     * 
     * <remarks>COCT_MT260010CA.SubstanceAdministration: Active 
     * Medication <p>Allows providers to identify the offending 
     * drugs when determining their management approach.</p> 
     * <p>Indicates an active medication (prescription or 
     * non-prescription medication) that is recorded in the 
     * patient's record and which contributed to triggering the 
     * issue.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT260010CA.SubstanceAdministration","COCT_MT260020CA.SubstanceAdministration"})]
    public class ActiveMedication : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt260020ca.ICausalActs, Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt260010ca.ICausalActs {

        private CS moodCode;
        private II id;
        private CD code;
        private CS statusCode;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private SET<CV, Code> confidentialityCode;
        private PQ doseQuantity;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt220100ca.DrugProduct consumableMedication;

        public ActiveMedication() {
            this.moodCode = new CSImpl();
            this.id = new IIImpl();
            this.code = new CDImpl();
            this.statusCode = new CSImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.doseQuantity = new PQImpl();
        }
        /**
         * <summary>Business Name: OtherMedicationIndicator</summary>
         * 
         * <remarks>Un-merged Business Name: OtherMedicationIndicator 
         * Relationship: 
         * COCT_MT260010CA.SubstanceAdministration.moodCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Knowing whether a 
         * drug is prescribed or not can influence actions taken to 
         * mitigate an issue. This attribute is therefore 
         * mandatory.</p> <p>If the attribute is 'RQO', represents a 
         * prescription or dispense record. Otherwise if 'EVN', it 
         * represents an 'Other Medication' record.</p> Un-merged 
         * Business Name: OtherMedicationIndicator Relationship: 
         * COCT_MT260020CA.SubstanceAdministration.moodCode 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"moodCode"})]
        public x_ActMoodRequestEvent MoodCode {
            get { return (x_ActMoodRequestEvent) this.moodCode.Value; }
            set { this.moodCode.Value = value; }
        }

        /**
         * <summary>Business Name: ActiveMedicationRecordNumber</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * ActiveMedicationRecordNumber Relationship: 
         * COCT_MT260010CA.SubstanceAdministration.id 
         * Conformance/Cardinality: REQUIRED (1) 
         * <p>DDI/DuplicateTherapy.InteractingPrescriptionNumber</p> 
         * <p>InteractingPrescription.PrescriptionExternalKey</p> 
         * <p>InteractingPrescription.PrescriptionNumber</p> 
         * <p>DDI/Dosage/Duplicate Therapy.SourceNumber (All senders 
         * must uniquely identify prescriptions on request)</p> 
         * <p>Allows provider to drill-down and retrieve additional 
         * information about the implicated drug therapy to either 
         * modify the therapy or to learn more information in 
         * determining their management approach for the issue.</p> 
         * <p>Unique identifier of the prescription or other medication 
         * drug record that triggered the issue.</p> Un-merged Business 
         * Name: ActiveMedicationRecordNumber Relationship: 
         * COCT_MT260020CA.SubstanceAdministration.id 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: AdministrationType</summary>
         * 
         * <remarks>Un-merged Business Name: AdministrationType 
         * Relationship: COCT_MT260010CA.SubstanceAdministration.code 
         * Conformance/Cardinality: REQUIRED (1) <p>Needed to determine 
         * what to do about the issue. Because the medication can be 
         * masked, this element is only marked as 
         * 'populated'.</p><p>The element allows a full 'CD' type to 
         * support SNOMED implementations.</p> <p>Identifies whether 
         * the interaction is with a drug or a vaccine. For SNOMED, may 
         * also indicate the specific drug or vaccine at issue.</p> 
         * Un-merged Business Name: AdministrationType Relationship: 
         * COCT_MT260020CA.SubstanceAdministration.code 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActSubstanceAdministrationCode Code {
            get { return (ActSubstanceAdministrationCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: ActiveMedicationStatus</summary>
         * 
         * <remarks>Un-merged Business Name: ActiveMedicationStatus 
         * Relationship: 
         * COCT_MT260010CA.SubstanceAdministration.statusCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>ZPB3.8 (aborted = 
         * discontinued; nullified = reversed/system reversed; 
         * active=filled/not-filled)</p> <p>Used to determine the 
         * relevance of the issue and the need to manage it. For 
         * example, if the medication is on hold, it may be less of an 
         * issue than if it is being actively taken.</p> <p>Indicates 
         * the status of the medication record at the time of the 
         * issue.</p> Un-merged Business Name: ActiveMedicationStatus 
         * Relationship: 
         * COCT_MT260020CA.SubstanceAdministration.statusCode 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: ActiveMedicationTimeRange</summary>
         * 
         * <remarks>Un-merged Business Name: ActiveMedicationTimeRange 
         * Relationship: 
         * COCT_MT260010CA.SubstanceAdministration.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Requested 
         * Duration</p> <p>Allows the provider to evaluate 'duplicate 
         * therapy' and similar timing-based issues.</p> <p>The date 
         * and time during which the patient is expected to be taking 
         * the drug which triggered the issue.</p> Un-merged Business 
         * Name: ActiveMedicationTimeRange Relationship: 
         * COCT_MT260020CA.SubstanceAdministration.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: ActiveMedicationMaskingIndicator</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * ActiveMedicationMaskingIndicator Relationship: 
         * COCT_MT260010CA.SubstanceAdministration.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-2) <p>Conveys the 
         * patient's wishes relating to the sensitivity of the drug 
         * information.</p><p>The attribute is optional because not all 
         * systems will support masking.</p> <p>An indication of 
         * sensitivity surrounding the related drug, and thus defines 
         * the required sensitivity for the detected issue.</p> 
         * Un-merged Business Name: ActiveMedicationMaskingIndicator 
         * Relationship: 
         * COCT_MT260020CA.SubstanceAdministration.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-2)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_BasicConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_BasicConfidentialityKind>(); }
        }

        /**
         * <summary>Business Name: ActiveMedicationDoseQuantity</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * ActiveMedicationDoseQuantity Relationship: 
         * COCT_MT260010CA.SubstanceAdministration.doseQuantity 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Requested Dosage 
         * Level</p> <p>ZPS.12</p> <p>ZDU.4.4</p> 
         * <p>Contraindication.dosageAmount</p> <p>Used in Low 
         * Dose/High Dose issues.</p> <p>The amount of medication 
         * administered to the patient</p> Un-merged Business Name: 
         * ActiveMedicationDoseQuantity Relationship: 
         * COCT_MT260020CA.SubstanceAdministration.doseQuantity 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"doseQuantity"})]
        public PhysicalQuantity DoseQuantity {
            get { return this.doseQuantity.Value; }
            set { this.doseQuantity.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: COCT_MT260010CA.Consumable.medication 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * COCT_MT260020CA.Consumable.medication 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"consumable/medication"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt220100ca.DrugProduct ConsumableMedication {
            get { return this.consumableMedication; }
            set { this.consumableMedication = value; }
        }

    }

}