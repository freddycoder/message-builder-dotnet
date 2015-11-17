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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Porx_mt040010ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt050203ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt120600ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt220100ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Porx_mt980040ca;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Other Medication</summary>
     * 
     * <p>Status can only be 'ACTIVE' or 'COMPLETED'</p> 
     * <p>routeCode must not be used when code is SNOMED and is 
     * mandatory otherwise</p> <p>Necessary component of a person's 
     * overall medication profile. Allows DUR checking against a 
     * more complete drug profile.</p> <p>A record of a medication 
     * the patient is believed to be taking, but for which an 
     * electronic order does not exist. 'Other medications' include 
     * any drug product deemed relevant to the patient's drug 
     * profile, but which was not specifically ordered by a 
     * prescriber in a DIS-enabled jurisdiction. Examples include 
     * over-the counter medications that were not specifically 
     * ordered, herbal remedies, and recreational drugs. 
     * Prescription drugs that the patient may be taking but were 
     * not prescribed on the EHR (e.g. institutionally administered 
     * or out-of-jurisdiction prescriptions) will also be recorded 
     * here.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT040010CA.OtherMedication"})]
    public class OtherMedication : MessagePartBean {

        private CD code;
        private CS statusCode;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private CV confidentialityCode;
        private CV routeCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt050203ca.Patient subjectPatient;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt220100ca.DrugProduct consumableMedication;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Porx_mt980040ca.AdministrationInstructions> componentDosageInstruction;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt120600ca.Notes subjectOfAnnotation;

        public OtherMedication() {
            this.code = new CDImpl();
            this.statusCode = new CSImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.confidentialityCode = new CVImpl();
            this.routeCode = new CVImpl();
            this.componentDosageInstruction = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Porx_mt980040ca.AdministrationInstructions>();
        }
        /**
         * <summary>Business Name: Other Medication Type</summary>
         * 
         * <remarks>Relationship: PORX_MT040010CA.OtherMedication.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Must be 'DRUG' 
         * unless using SNOMED</p> <p>Needed to convey the meaning of 
         * this class and is therefore mandatory.</p><p>The element 
         * allows 'CD' to provide support for SNOMED.</p> <p>Indicates 
         * that the record is a drug administration rather than an 
         * immunization or other type of administration. For SNOMED, 
         * may also include route, drug and other information.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActCode Code {
            get { return (ActCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: C:Other Medication Status</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT040010CA.OtherMedication.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates what 
         * actions are allowed to be performed against an other 
         * medication record. This is a mandatory field because every 
         * recorded 'other medication' needs to be in some 
         * state.</p><p>Note ------ The provider might know that the 
         * patient is not taking the medication but not necessarily 
         * when the patient stopped it. Thus the status of the 
         * medication could be set to 'COMPLETED' by the provider 
         * without necessarily setting an End Date on the medication 
         * record.</p> <p>This denotes a state in the lifecycle of the 
         * other medication. Valid statuses are: 'ACTIVE' and 
         * 'COMPLETED' only.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: d:Drug Active Period</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT040010CA.OtherMedication.effectiveTime 
         * Conformance/Cardinality: REQUIRED (1) <p>ZDP.13.2.2</p> 
         * <p>ZDP.13.3</p> <p>ZDP.13.4</p> <p>ZDP.13.5</p> <p>Used to 
         * help determine whether the medication is currently active. 
         * Because this information won't always be available, the 
         * attribute is marked as 'populated'.</p> <p>Either the start 
         * or end or both can be null if they are not known.</p> 
         * <p>Indicates the time-period in which the patient has been 
         * taking or is expected to be taking the medication.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: E:Other Medication Masking Indicator</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT040010CA.OtherMedication.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Provides support 
         * for additional confidentiality constraint to reflect the 
         * wishes of the patient.</p><p>The attribute is optional 
         * because not all systems will support masking.</p> <p>Denotes 
         * access restriction place on the other medication record. 
         * Methods for accessing masked other medications will be 
         * governed by each jurisdiction (e.g. court orders, shared 
         * secret/consent, etc.).</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public x_VeryBasicConfidentialityKind ConfidentialityCode {
            get { return (x_VeryBasicConfidentialityKind) this.confidentialityCode.Value; }
            set { this.confidentialityCode.Value = value; }
        }

        /**
         * <summary>Business Name: F:Route of Administration</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT040010CA.OtherMedication.routeCode 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Route of 
         * administration</p> <p>Ensures consistency in description of 
         * routes. Provides potential for cross-checking dosage form 
         * and route. Because this information is pre-coordinated into 
         * 'code' for SNOMED, it is marked as optional.</p> <p>This is 
         * the means by which the patient is taking the other 
         * medication.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"routeCode"})]
        public RouteOfAdministration RouteCode {
            get { return (RouteOfAdministration) this.routeCode.Value; }
            set { this.routeCode.Value = value; }
        }

        /**
         * <summary>Relationship: PORX_MT040010CA.Subject10.patient</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject/patient"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt050203ca.Patient SubjectPatient {
            get { return this.subjectPatient; }
            set { this.subjectPatient = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT040010CA.Consumable2.medication</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"consumable/medication"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt220100ca.DrugProduct ConsumableMedication {
            get { return this.consumableMedication; }
            set { this.consumableMedication = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT040010CA.Component.dosageInstruction</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component/dosageInstruction"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Porx_mt980040ca.AdministrationInstructions> ComponentDosageInstruction {
            get { return this.componentDosageInstruction; }
        }

        /**
         * <summary>Relationship: PORX_MT040010CA.Subject9.annotation</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf/annotation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt120600ca.Notes SubjectOfAnnotation {
            get { return this.subjectOfAnnotation; }
            set { this.subjectOfAnnotation = value; }
        }

    }

}