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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Porx_mt060210ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt090107ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt220110ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Porx_mt980040ca;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Other Medication</summary>
     * 
     * <p>routeCode must not be used when code is SNOMED and is 
     * mandatory otherwise</p> <p>Status can only be ACTIVE or 
     * COMPLETE</p> <p>Annotation is only permitted if Annotation 
     * Indicator is not present and vice versa</p> <p>Reported 
     * Issue is only permitted if Issue Indicator is not present 
     * and vice versa</p> <p>Necessary component of a person's 
     * overall medication profile. Allows DUR checking against a 
     * more complete drug profile.</p> <p>A record of a medication 
     * the patient is believed to be taking, but for which an 
     * electronic order does not exist. &quot;Other active 
     * medications&quot; include any drug product deemed relevant 
     * to the patient's drug profile, but which was not 
     * specifically ordered by a prescriber in a DIS-enabled 
     * jurisdiction. Examples include over-the counter medications 
     * that were not specifically ordered, herbal remedies, and 
     * recreational drugs. Prescription drugs that the patient may 
     * be taking but was not prescribed on the EHR (e.g. 
     * institutionally administered or out-of-jurisdiction 
     * prescriptions) will also be recorded here.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060210CA.OtherMedication"})]
    public class OtherMedication : MessagePartBean {

        private II id;
        private CD code;
        private CS statusCode;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private CV confidentialityCode;
        private CV routeCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Merged.Patient subjectPatient;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt220110ca.DrugProduct consumableMedication;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt090107ca.Provider responsiblePartyAssignedPerson;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged.RefusedBy author;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged.RecordedAt location;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Porx_mt980040ca.AdministrationInstructions> componentDosageInstruction;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.StatusChanges> subjectOf1ControlActEvent;
        private BL subjectOf2DetectedIssueIndicator;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged.Comment> subjectOf3Annotation;
        private BL subjectOf4AnnotationIndicator;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.Issues> subjectOf5DetectedIssueEvent;

        public OtherMedication() {
            this.id = new IIImpl();
            this.code = new CDImpl();
            this.statusCode = new CSImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.confidentialityCode = new CVImpl();
            this.routeCode = new CVImpl();
            this.componentDosageInstruction = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Porx_mt980040ca.AdministrationInstructions>();
            this.subjectOf1ControlActEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.StatusChanges>();
            this.subjectOf2DetectedIssueIndicator = new BLImpl(false);
            this.subjectOf3Annotation = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged.Comment>();
            this.subjectOf4AnnotationIndicator = new BLImpl(false);
            this.subjectOf5DetectedIssueEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.Issues>();
        }
        /**
         * <summary>Business Name: A:Administration Record Id</summary>
         * 
         * <remarks>Relationship: PORX_MT060210CA.OtherMedication.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for the 
         * unique referencing of a specific active medication record. 
         * Thus the mandatory requirement. .</p> <p>This is an 
         * identifier assigned to a unique instance of an active 
         * medication record.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: Other Medication Type</summary>
         * 
         * <remarks>Relationship: PORX_MT060210CA.OtherMedication.code 
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
         * <summary>Business Name: B:Other Medication Status</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060210CA.OtherMedication.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Used to determine 
         * whether the medication should be considered in performing 
         * DUR checking.</p><p>Attribute is mandatory to ensure that a 
         * medication recorded in EHR/DIS is in some state.</p><p>Note 
         * ------ The provider might know that the patient is not 
         * taking the medication but not necessarily when the patient 
         * stopped it. Thus the status of the medication could be set 
         * to 'completed' by the provider without necessarily setting 
         * an End Date on the medication record.</p> <p>Indicates the 
         * status of the other medication record created on the 
         * EHR/DIS. Valid statuses for other medication records are: 
         * 'active' and 'completed' only.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: C:Drug Active Period</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060210CA.OtherMedication.effectiveTime 
         * Conformance/Cardinality: POPULATED (1) <p>ZDP.13.2.2</p> 
         * <p>ZDP.13.3</p> <p>ZDP.13.4</p> <p>ZDP.13.5</p> <p>Used to 
         * help determine whether the medication is currently active. 
         * Because this information won't always be available, the 
         * attribute is marked as 'populated'.</p> <p>Indicates the 
         * time-period in which the patient has been taking or is 
         * expected to be taking the medication.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: D:Other Medication Masking Indicator</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060210CA.OtherMedication.confidentialityCode 
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
         * <summary>Business Name: E:Route of Administration</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060210CA.OtherMedication.routeCode 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>RXR.1</p> 
         * <p>Route of administration</p> <p>Ensures consistency in 
         * description of routes. Provides potential for cross-checking 
         * dosage form and route. Because this information is 
         * pre-coordinated into 'code' for SNOMED, it is marked as 
         * optional.</p> <p>This is the means by which the patient is 
         * taking the medication.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"routeCode"})]
        public RouteOfAdministration RouteCode {
            get { return (RouteOfAdministration) this.routeCode.Value; }
            set { this.routeCode.Value = value; }
        }

        /**
         * <summary>Relationship: PORX_MT060210CA.Subject10.patient</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject/patient"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Merged.Patient SubjectPatient {
            get { return this.subjectPatient; }
            set { this.subjectPatient = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060210CA.Consumable2.medication</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"consumable/medication"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt220110ca.DrugProduct ConsumableMedication {
            get { return this.consumableMedication; }
            set { this.consumableMedication = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060210CA.ResponsibleParty.assignedPerson</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/assignedPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt090107ca.Provider ResponsiblePartyAssignedPerson {
            get { return this.responsiblePartyAssignedPerson; }
            set { this.responsiblePartyAssignedPerson = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060210CA.OtherMedication.author</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged.RefusedBy Author {
            get { return this.author; }
            set { this.author = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060210CA.OtherMedication.location</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged.RecordedAt Location {
            get { return this.location; }
            set { this.location = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060210CA.Component.dosageInstruction</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component/dosageInstruction"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Porx_mt980040ca.AdministrationInstructions> ComponentDosageInstruction {
            get { return this.componentDosageInstruction; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060210CA.Subject11.controlActEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf1/controlActEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.StatusChanges> SubjectOf1ControlActEvent {
            get { return this.subjectOf1ControlActEvent; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060210CA.Subject9.detectedIssueIndicator</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2/detectedIssueIndicator"})]
        public bool? SubjectOf2DetectedIssueIndicator {
            get { return this.subjectOf2DetectedIssueIndicator.Value; }
            set { this.subjectOf2DetectedIssueIndicator.Value = value; }
        }

        /**
         * <summary>Relationship: PORX_MT060210CA.Subject14.annotation</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf3/annotation"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged.Comment> SubjectOf3Annotation {
            get { return this.subjectOf3Annotation; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060210CA.Subject15.annotationIndicator</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf4/annotationIndicator"})]
        public bool? SubjectOf4AnnotationIndicator {
            get { return this.subjectOf4AnnotationIndicator.Value; }
            set { this.subjectOf4AnnotationIndicator.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060210CA.Subject.detectedIssueEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf5/detectedIssueEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.Issues> SubjectOf5DetectedIssueEvent {
            get { return this.subjectOf5DetectedIssueEvent; }
        }

    }

}