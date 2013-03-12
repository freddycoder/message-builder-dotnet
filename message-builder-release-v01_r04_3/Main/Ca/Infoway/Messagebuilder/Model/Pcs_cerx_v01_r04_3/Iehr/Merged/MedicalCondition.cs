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
 * Last modified: $LastChangedDate: 2013-03-08 11:06:36 -0500 (Fri, 08 Mar 2013) $
 * Revision:      $LastChangedRevision: 6699 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Iehr.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged;
    using System;


    /**
     * <summary>Business Name: MedicalCondition</summary>
     * 
     * <remarks>REPC_MT000003CA.MedicalCondition: Medical Condition 
     * <p>Value is mandatory if not using SNOMED</p> <p>Code is 
     * fixed to DX if not using SNOMED</p> <p>Necessary component 
     * of a person's overall medication and clinical profile. Helps 
     * with contraindication checking.</p> <p>A record of a 
     * patient's medical condition. Includes diseases, 
     * disabilities, pregnancy, lactation and other clinical 
     * conditions of interest.</p> 
     * REPC_MT000014CA.MedicalCondition: Medical Condition <p>Value 
     * is mandatory if not using SNOMED</p> <p>Code is fixed to DX 
     * if not using SNOMED</p> <p>Necessary component of a person's 
     * overall medication and clinical profile. Helps with 
     * contraindication checking.</p> <p>A record of a patient's 
     * medical condition. Includes diseases, disabilities, 
     * pregnancy, lactation and other clinical conditions of 
     * interest.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT000003CA.MedicalCondition","REPC_MT000014CA.MedicalCondition"})]
    public class MedicalCondition : MessagePartBean {

        private CD code;
        private CS statusCode;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private CV confidentialityCode;
        private CV value;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Merged.Patient subjectPatient;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Iehr.Merged.ReportedBy informant;
        private BL subjectOfChronicIndicator;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged.Comment subjectOf2Annotation;
        private II id;

        public MedicalCondition() {
            this.code = new CDImpl();
            this.statusCode = new CSImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.confidentialityCode = new CVImpl();
            this.value = new CVImpl();
            this.subjectOfChronicIndicator = new BLImpl(false);
            this.id = new IIImpl();
        }
        /**
         * <summary>Business Name: ConditionType</summary>
         * 
         * <remarks>Un-merged Business Name: ConditionType 
         * Relationship: REPC_MT000003CA.MedicalCondition.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Identifies this 
         * observation as reporting a medical condition and is 
         * therefore mandatory. When using SNOMED, the actual condition 
         * may be post-coordinated into this attribute, thus CD is 
         * used.</p> <p>If SNOMED is used, the diagnosis will appear 
         * here. Otherwise, a fixed value of &quot;DX&quot; should be 
         * sent.</p> <p>Indicates what kind of condition is being 
         * reported.</p> Un-merged Business Name: ConditionType 
         * Relationship: REPC_MT000014CA.MedicalCondition.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Identifies this 
         * observation as reporting a medical condition and is 
         * therefore mandatory. When using SNOMED, the actual condition 
         * may be post-coordinated into this attribute, thus CD is 
         * used.</p> <p>If SNOMED is used, the diagnosis will appear 
         * here. Otherwise, a fixed value of &quot;DX&quot; should be 
         * sent.</p> <p>Indicates what kind of condition is being 
         * reported.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActCode Code {
            get { return (ActCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: ConditionStatus</summary>
         * 
         * <remarks>Un-merged Business Name: ConditionStatus 
         * Relationship: REPC_MT000003CA.MedicalCondition.statusCode 
         * Conformance/Cardinality: POPULATED (1) <p>Essential to 
         * evaluating the relevance of the condition record. In some 
         * cases, it may not be known whether the condition still 
         * exists or not. Therefore the status is treated as 
         * 'populated'.</p> <p>A coded value that indicates whether the 
         * condition is still impacting the patient. 'active' means the 
         * condition is still affecting the patient. 'completed' means 
         * the condition no longer holds</p> Un-merged Business Name: 
         * ConditionStatus Relationship: 
         * REPC_MT000014CA.MedicalCondition.statusCode 
         * Conformance/Cardinality: POPULATED (1) <p>Essential to 
         * evaluating the relevance of the condition record. In some 
         * cases, it may not be known whether the condition still 
         * exists or not. Therefore the status is treated as 
         * 'populated'.</p> <p>A coded value that indicates whether the 
         * condition is still impacting the patient. 'ACTIVE' means the 
         * condition is still affecting the patient. 'COMPLETE' means 
         * the condition no longer holds</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: ConditionTimePeriod</summary>
         * 
         * <remarks>Un-merged Business Name: ConditionTimePeriod 
         * Relationship: REPC_MT000003CA.MedicalCondition.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows providers 
         * to evaluate the period of relevance for the medical 
         * condition.</p> <p>The date on which the condition first 
         * began and when it ended.</p><p>For ongoing conditions such 
         * as chronic diseases, the upper boundary may be 
         * unknown.</p><p>For transient conditions such as pregnancy, 
         * lactation, etc; the upper boundary of the period would 
         * usually be specified to signify the end of the 
         * condition.</p> Un-merged Business Name: ConditionTimePeriod 
         * Relationship: REPC_MT000014CA.MedicalCondition.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows providers 
         * to evaluate the period of relevance for the medical 
         * condition.</p> <p>The date on which the condition first 
         * began and when it ended.</p><p>For ongoing conditions such 
         * as chronic diseases, the upper boundary may be 
         * unknown.</p><p>For transient conditions such as pregnancy, 
         * lactation, etc; the upper boundary of the period would 
         * usually be specified to signify the end of the 
         * condition.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: ConditionMaskingIndicator</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000003CA.MedicalCondition.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Provides support 
         * for additional confidentiality constraint to reflect the 
         * wishes of the patient.</p><p>The attribute is optional 
         * because not all systems will support masking.</p> <p>Denotes 
         * access restriction placed on the medical condition record. 
         * Methods for accessing masked medical condition records will 
         * be governed by each jurisdiction (e.g. court orders, shared 
         * secret/consent, etc.).</p><p>The default confidentiality 
         * level is 'NORMAL'.</p> Un-merged Business Name: 
         * MedicalConditionMaskingIndicator Relationship: 
         * REPC_MT000014CA.MedicalCondition.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Provides support 
         * for additional confidentiality constraint to reflect the 
         * wishes of the patient.</p><p>The attribute is optional 
         * because not all systems will support masking.</p> <p>Denotes 
         * access restriction placed on the medical condition record. 
         * Methods for accessing masked medical condition records will 
         * be governed by each jurisdiction (e.g. court orders, shared 
         * secret/consent, etc.).</p><p>The default confidentiality 
         * level is 'NORMAL'.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public x_VeryBasicConfidentialityKind ConfidentialityCode {
            get { return (x_VeryBasicConfidentialityKind) this.confidentialityCode.Value; }
            set { this.confidentialityCode.Value = value; }
        }

        /**
         * <summary>Business Name: Condition</summary>
         * 
         * <remarks>Un-merged Business Name: Condition Relationship: 
         * REPC_MT000003CA.MedicalCondition.value 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>This is the 
         * central piece of information in recording a condition. 
         * However because when using SNOMED the actual diagnosis will 
         * be sent in the 'code' attribute, this element is 
         * optional.</p> <p>A code indicating the specific condition. 
         * E.g. Hypertension, Pregnancy.</p> Un-merged Business Name: 
         * Condition Relationship: 
         * REPC_MT000014CA.MedicalCondition.value 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>This is the 
         * central piece of information in recording a condition. 
         * However because when using SNOMED the actual diagnosis will 
         * be sent in the 'code' attribute, this element is 
         * optional.</p> <p>A code indicating the specific condition. 
         * E.g. Hypertension, Pregnancy.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public DiagnosisValue Value {
            get { return (DiagnosisValue) this.value.Value; }
            set { this.value.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: REPC_MT000003CA.Subject2.patient 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000014CA.Subject2.patient Conformance/Cardinality: 
         * MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject/patient"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Merged.Patient SubjectPatient {
            get { return this.subjectPatient; }
            set { this.subjectPatient = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000003CA.MedicalCondition.informant 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000014CA.MedicalCondition.informant 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"informant"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Iehr.Merged.ReportedBy Informant {
            get { return this.informant; }
            set { this.informant = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000003CA.Subject.chronicIndicator 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000014CA.Subject.chronicIndicator 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf/chronicIndicator","subjectOf1/chronicIndicator"})]
        [Hl7MapByPartType(Name="subjectOf", Type="REPC_MT000014CA.Subject")]
        [Hl7MapByPartType(Name="subjectOf/chronicIndicator", Type="REPC_MT000014CA.ChronicIndicator")]
        [Hl7MapByPartType(Name="subjectOf1", Type="REPC_MT000003CA.Subject")]
        [Hl7MapByPartType(Name="subjectOf1/chronicIndicator", Type="REPC_MT000003CA.ChronicIndicator")]
        public bool? SubjectOfChronicIndicator {
            get { return this.subjectOfChronicIndicator.Value; }
            set { this.subjectOfChronicIndicator.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: REPC_MT000003CA.Subject3.annotation 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2/annotation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged.Comment SubjectOf2Annotation {
            get { return this.subjectOf2Annotation; }
            set { this.subjectOf2Annotation = value; }
        }

        /**
         * <summary>Business Name: MedicalConditionRecordId</summary>
         * 
         * <remarks>Un-merged Business Name: MedicalConditionRecordId 
         * Relationship: REPC_MT000014CA.MedicalCondition.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for direct 
         * referencing of a medical condition record when querying or 
         * updating and is therefore mandatory.</p> <p>Unique 
         * identifier for medical condition record to be updated.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

    }

}