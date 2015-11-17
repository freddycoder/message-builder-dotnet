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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Repc_mt000013ca {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Allergy/Intolerance</summary>
     * 
     * <p>Necessary component of a person's overall medication and 
     * clinical profile. Helps with drug contraindication 
     * checking.</p> <p>A record of a patient's allergy or 
     * intolerance.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT000013CA.IntoleranceCondition"})]
    public class AllergyIntolerance : MessagePartBean {

        private SET<II, Identifier> id;
        private CD code;
        private BL negationInd;
        private CS statusCode;
        private TS effectiveTime;
        private SET<CV, Code> confidentialityCode;
        private CV uncertaintyCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.ReportedBy informant;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.IRecords> supportRecords;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.AllergyIntoleranceSeverityLevel subjectOfSeverityObservation;

        public AllergyIntolerance() {
            this.id = new SETImpl<II, Identifier>(typeof(IIImpl));
            this.code = new CDImpl();
            this.negationInd = new BLImpl();
            this.statusCode = new CSImpl();
            this.effectiveTime = new TSImpl();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.uncertaintyCode = new CVImpl();
            this.supportRecords = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.IRecords>();
        }
        /**
         * <summary>Business Name: D:Allergy/Intolerance Record Id</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000013CA.IntoleranceCondition.id 
         * Conformance/Cardinality: MANDATORY (1-2) <p>Indicates the 
         * allergy or intolerance record to be updated and is therefore 
         * mandatory.</p> <p>Unique identifier for an 
         * allergy/intolerance record.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public ICollection<Identifier> Id {
            get { return this.id.RawSet(); }
        }

        /**
         * <summary>Business Name: A:Allergy/Intolerance Type</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000013CA.IntoleranceCondition.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for the 
         * separation of allergy and intolerance records. The type of 
         * condition is critical to understanding the record and is 
         * therefore mandatory.</p> <p>A coded value denoting whether 
         * the record pertains to an intolerance or a true allergy. 
         * (Allergies result from immunologic reactions. Intolerances 
         * do not.)</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ObservationIntoleranceType Code {
            get { return (ObservationIntoleranceType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: G:Allergy/Intolerance Refuted</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000013CA.IntoleranceCondition.negationInd 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows providers 
         * to refute a previously confirmed or suspected allergy. 
         * Because it is essential to know whether the allergy or 
         * intolerance is being refuted or affirmed, this attribute is 
         * mandatory.</p> <p>An indication that the allergy/intolerance 
         * has been refuted. I.e. A clinician has positively determined 
         * that the patient does not suffer from a particular allergy 
         * or intolerance.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"negationInd"})]
        public bool? NegationInd {
            get { return this.negationInd.Value; }
            set { this.negationInd.Value = value; }
        }

        /**
         * <summary>Business Name: E:Allergy/Intolerance Status</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000013CA.IntoleranceCondition.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows providers 
         * to evaluate the relevance of a recorded allergy/intolerance. 
         * The status has a default value of 'ACTIVE' and is therefore 
         * mandatory.</p> <p>System must default the status to 
         * 'ACTIVE'.</p> <p>A coded value that indicates whether an 
         * allergy/intolerance is 'ACTIVE' or 'COMPLETE' (indicating no 
         * longer active).</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: I:Allergy/Intolerance Date</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000013CA.IntoleranceCondition.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows providers 
         * to evaluate the period of relevance for the 
         * allergy/intolerance record.</p> <p>The date on which the 
         * recorded allergy is considered active.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public PlatformDate EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: H:Allergy/Intolerance Masking 
         * Indicators</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000013CA.IntoleranceCondition.confidentialityCode 
         * Conformance/Cardinality: REQUIRED (0-2) <p>Provides support 
         * for additional confidentiality constraint to reflect the 
         * wishes of the patient.</p><p>Taboo allows the provider to 
         * request restricted access to patient or their care 
         * giver.</p><p>Constraint: Can't have both normal and one of 
         * the other codes simultaneously.</p><p>The attribute is 
         * optional because not all systems will support masking.</p> 
         * <p>Communicates the desire of the patient to restrict access 
         * to this Health Condition record. Provides support for 
         * additional confidentiality constraint, giving patients a 
         * level of control over their information. Methods for 
         * accessing masked event records will be governed by each 
         * jurisdiction (e.g. court orders, shared secret/consent, 
         * etc.). Can also be used to communicate that the information 
         * is deemed to be sensitive and should not be communicated or 
         * exposed to the patient (at least without the guidance of the 
         * authoring or other responsible healthcare provider). Valid 
         * values are: 'normal' (denotes 'Not Masked'); 'restricted' 
         * (denotes 'Masked'); 'very restricted' (denotes 'Masked by 
         * Regulation'); and 'taboo' (denotes 'patient restricted'). 
         * The default is 'normal' signifying 'Not Masked'. Either or 
         * both of the other codes can be asserted to indicate masking 
         * by the patient from providers or masking by a provider from 
         * the patient, respectively. 'normal' should never be asserted 
         * with one of the other codes.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_BasicConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_BasicConfidentialityKind>(); }
        }

        /**
         * <summary>Business Name: F:Confirmed Indicator</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000013CA.IntoleranceCondition.uncertaintyCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Helps other 
         * providers to make appropriate decisions in their management 
         * of allergy or intolerance contraindications.</p><p>Attribute 
         * is mandatory because an allergy or intolerance record must 
         * be tagged as either U or N</p> <p>An indication of the level 
         * of confidence/surety placed in the recorded 
         * information.</p><p>The two valid codes are:</p><p>- U 
         * (stated with uncertainty) -Specifies that the author of the 
         * act affirms the uncertainty of the act statement. In other 
         * words, they know that parts of the act statement are not 
         * certain or are inferred. An example of this is an inferred 
         * prescription where some order data is inferred from a supply 
         * event (i.e. dispense).</p><p>- N (stated with no assertion 
         * of uncertainty) - Specifies that the act statement is made 
         * without any explicit expression of certainty/uncertainty. 
         * This is the normal statement, meaning that it may not be 
         * free of errors and uncertainty may still exist. In 
         * healthcare, N is believed to express certainty to the 
         * strength possible.</p><p>An allergy or intolerance record is 
         * always used in drug contraindication checking whether the 
         * record is U or N.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"uncertaintyCode"})]
        public ActUncertainty UncertaintyCode {
            get { return (ActUncertainty) this.uncertaintyCode.Value; }
            set { this.uncertaintyCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT000013CA.IntoleranceCondition.informant</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"informant"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.ReportedBy Informant {
            get { return this.informant; }
            set { this.informant = value; }
        }

        /**
         * <summary>Relationship: REPC_MT000013CA.Support.records</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"support/records"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.IRecords> SupportRecords {
            get { return this.supportRecords; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT000013CA.Subject1.severityObservation</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf/severityObservation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.AllergyIntoleranceSeverityLevel SubjectOfSeverityObservation {
            get { return this.subjectOfSeverityObservation; }
            set { this.subjectOfSeverityObservation = value; }
        }

    }

}