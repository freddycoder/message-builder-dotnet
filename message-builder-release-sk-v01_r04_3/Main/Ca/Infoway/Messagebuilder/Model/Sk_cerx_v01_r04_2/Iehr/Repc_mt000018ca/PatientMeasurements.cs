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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Iehr.Repc_mt000018ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt050203ca;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt120600ca;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Iehr.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Patient Measurements</summary>
     * 
     * <p>Measurement Type with a nullFlavorvalue must have 
     * SubObservations Measurement Type without a nullFlavor value 
     * must not have SubObservations.</p> <p>This comprises a 
     * single point-in-time measurement made about a patient.</p> 
     * <p>Allows pertinent patient measurements to be recorded for 
     * clinical purposes.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT000018CA.CommonObservationEvent"})]
    public class PatientMeasurements : MessagePartBean {

        private CD code;
        private TS effectiveTime;
        private CV confidentialityCode;
        private PQ value;
        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt050203ca.Patient subjectPatient;
        private IList<Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Iehr.Merged.ComponentMeasurements> componentSubObservationEvent;
        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt120600ca.Notes subjectOfAnnotation;

        public PatientMeasurements() {
            this.code = new CDImpl();
            this.effectiveTime = new TSImpl();
            this.confidentialityCode = new CVImpl();
            this.value = new PQImpl();
            this.componentSubObservationEvent = new List<Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Iehr.Merged.ComponentMeasurements>();
        }
        /**
         * <summary>Business Name: A:MeasurementType</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000018CA.CommonObservationEvent.code 
         * Conformance/Cardinality: POPULATED (1) <p>Identification of 
         * the type of measurement/observation that was made about the 
         * patient. Observation types include: height, weight, blood 
         * pressure, body mass, etc</p> <p>Distinguishes what kind of 
         * information is being specified.</p><p>The attribute is CD to 
         * support SNOMED</p> <p>Distinguishes what kind of information 
         * is being specified.</p><p>The attribute is CD to support 
         * SNOMED</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public CommonClinicalObservationType Code {
            get { return (CommonClinicalObservationType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: C:Observation Timestamp</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000018CA.CommonObservationEvent.effectiveTime 
         * Conformance/Cardinality: POPULATED (1) <p>The dateand time 
         * at which the observation applies. E.g., if blood was drawn 
         * two days ago and White Blood Count (WBC) was done today, 
         * then WBC observation date should reflect the date of two 
         * days ago.</p> <p>OBS.010-04 NCPDP:Clinical.494-ZE 
         * NCPDP:Clinical.495-H1</p> <p>Allows providers to evaluate 
         * currency of the information. Because the date of 
         * observation/measurement determines the relevance of the 
         * information, this attribute is defined as 'populated'. Also 
         * allows tracking of observations over time.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public PlatformDate EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: D:Common Observation Masking 
         * Indicator</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000018CA.CommonObservationEvent.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Communicates the 
         * intent of the patient to restrict access to their common 
         * observations. Provides support for additional 
         * confidentiality constraint, giving patients a level of 
         * control over their information. Valid values are: 'NORMAL' 
         * (denotes 'Not Masked'); and 'RESTRICTED' (denotes 'Masked'). 
         * The default is 'NORMAL' signifying 'Not Masked'.</p> 
         * <p>Allows the patient to have discrete control over access 
         * to their common observation data.</p><p>The attribute is 
         * optional because not all systems will support masking.</p> 
         * <p>Allows the patient to have discrete control over access 
         * to their common observation data.</p><p>The attribute is 
         * optional because not all systems will support masking.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public x_VeryBasicConfidentialityKind ConfidentialityCode {
            get { return (x_VeryBasicConfidentialityKind) this.confidentialityCode.Value; }
            set { this.confidentialityCode.Value = value; }
        }

        /**
         * <summary>Business Name: B:Observation Measurement Value</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000018CA.CommonObservationEvent.value 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The amount 
         * (quantity and unit) that has been recorded for the specific 
         * type of observation. E.g. height in centimeters, weight in 
         * kilograms, etc.</p><p>Valid observation unit types are: kg, 
         * cm, mmHg, mmol/mL, L/min, C, 1/min, etc</p> <p>The amount 
         * (quantity and unit) that has been recorded for the specific 
         * type of observation. E.g. height in centimeters, weight in 
         * kilograms, etc.</p><p>Valid observation unit types are: kg, 
         * cm, mmHg, mmol/mL, L/min, C, 1/min, etc</p> <p>OBS.010-02 
         * (value) eScript:OBS.010-03 (unit) NCPDP:Clinical.595-H4 
         * (value) NCPDP:Clinical.495-H3 (unit)</p> <p>Provides 
         * standard representation of the measurement. May be used in 
         * calculations.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public PhysicalQuantity Value {
            get { return this.value.Value; }
            set { this.value.Value = value; }
        }

        /**
         * <summary>Relationship: REPC_MT000018CA.Subject5.patient</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject/patient"})]
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt050203ca.Patient SubjectPatient {
            get { return this.subjectPatient; }
            set { this.subjectPatient = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT000018CA.Component.subObservationEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1) 
         * <p>&nbsp;Represents one of the two components (systolic</p> 
         * <div>and diastolic) of a blood pressure measurement.</div></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component/subObservationEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Iehr.Merged.ComponentMeasurements> ComponentSubObservationEvent {
            get { return this.componentSubObservationEvent; }
        }

        /**
         * <summary>Relationship: REPC_MT000018CA.Subject.annotation</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1) 
         * <p>&nbsp;Indicates the various comments that providers</p> 
         * <div>have recorded about this common observation.</div></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf/annotation"})]
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt120600ca.Notes SubjectOfAnnotation {
            get { return this.subjectOfAnnotation; }
            set { this.subjectOfAnnotation = value; }
        }

    }

}