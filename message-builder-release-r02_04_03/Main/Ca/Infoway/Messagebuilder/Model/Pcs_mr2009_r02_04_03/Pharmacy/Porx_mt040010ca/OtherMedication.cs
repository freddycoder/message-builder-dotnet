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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Pharmacy.Porx_mt040010ca {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt220100ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt270010ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Other Medication</summary>
     * 
     * <p>Necessary component of a person's overall medication 
     * profile. Allows DUR checking against a more complete drug 
     * profile.</p> <p>A record of a medication the patient is 
     * believed to be taking, but for which an electronic order 
     * does not exist. 'Other medications' include any drug product 
     * deemed relevant to the patient's drug profile, but which was 
     * not specifically ordered by a prescriber in a DIS-enabled 
     * jurisdiction. Examples include over-the counter medications 
     * that were not specifically ordered, herbal remedies, and 
     * recreational drugs. Prescription drugs that the patient may 
     * be taking but were not prescribed on the EHR (e.g. 
     * institutionally administered or out-of-jurisdiction 
     * prescriptions) will also be recorded here.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT040010CA.OtherMedication"})]
    public class OtherMedication : MessagePartBean {

        private CD code;
        private CS statusCode;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private SET<CV, Code> confidentialityCode;
        private CV routeCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt220100ca.DrugProduct consumableMedication;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt270010ca.AdministrationInstructions> componentDosageInstruction;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.Includes subjectOf;

        public OtherMedication() {
            this.code = new CDImpl();
            this.statusCode = new CSImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.routeCode = new CVImpl();
            this.componentDosageInstruction = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt270010ca.AdministrationInstructions>();
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
        public SubstanceAdministrationType Code {
            get { return (SubstanceAdministrationType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: C:Other Medication Status</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT040010CA.OtherMedication.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Status can only be 
         * 'ACTIVE' or 'COMPLETED'</p> <p>Indicates what actions are 
         * allowed to be performed against an other medication record. 
         * This is a mandatory field because every recorded 'other 
         * medication' needs to be in some state.</p><p>Note ------ The 
         * provider might know that the patient is not taking the 
         * medication but not necessarily when the patient stopped it. 
         * Thus the status of the medication could be set to 
         * 'COMPLETED' by the provider without necessarily setting an 
         * End Date on the medication record.</p> <p>This denotes a 
         * state in the lifecycle of the other medication. Valid 
         * statuses are: 'ACTIVE' and 'COMPLETED' only.</p></remarks>
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
         * Conformance/Cardinality: REQUIRED (1) <p>Used to help 
         * determine whether the medication is currently active. 
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
         * <summary>Business Name: E:Other Medication Masking 
         * Indicators</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT040010CA.OtherMedication.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-2) <p>Provides support 
         * for additional confidentiality constraint to reflect the 
         * wishes of the patient.</p><p>Taboo allows the provider to 
         * request restricted access to patient or their care 
         * giver.</p><p>Constraint: Can't have both normal and one of 
         * the other codes simultaneously.</p><p>The attribute is 
         * optional because not all systems will support masking.</p> 
         * <p>Communicates the intent of the patient to restrict access 
         * to their prescriptions.</p><p>Provides support for 
         * additional confidentiality constraint, giving patients a 
         * level of control over their information.</p><p>Valid values 
         * are: 'N' (normal - denotes 'Not Masked'); 'R' (restricted - 
         * denotes 'Masked'); 'V' (very restricted - denotes very 
         * restricted access as declared by the Privacy Officer of the 
         * record holder) and 'T' (taboo - denotes 'Patient Access 
         * Restricted').</p><p>The default is 'normal' signifying 'Not 
         * Masked'.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_BasicConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_BasicConfidentialityKind>(); }
        }

        /**
         * <summary>Business Name: F:Route of Administration</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT040010CA.OtherMedication.routeCode 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>routeCode must 
         * not be used when code is SNOMED and is mandatory 
         * otherwise</p> <p>Ensures consistency in description of 
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
         * <summary>Relationship: 
         * PORX_MT040010CA.Consumable2.medication</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"consumable/medication"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt220100ca.DrugProduct ConsumableMedication {
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
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt270010ca.AdministrationInstructions> ComponentDosageInstruction {
            get { return this.componentDosageInstruction; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT040010CA.OtherMedication.subjectOf</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.Includes SubjectOf {
            get { return this.subjectOf; }
            set { this.subjectOf = value; }
        }

    }

}