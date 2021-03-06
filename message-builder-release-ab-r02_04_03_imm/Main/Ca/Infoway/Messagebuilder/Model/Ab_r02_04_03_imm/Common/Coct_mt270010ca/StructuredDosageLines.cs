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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt270010ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: Structured Dosage Lines</summary>
     * 
     * <p>Either an Ad-hoc Dosage Line or (Dosage Timing/Frequency 
     * + Dosage Range + possibly Dosage Rate) may be specified t 
     * one time }</p> <p>Enables SIG instructions to be discretely 
     * specified. Also, supports scaling doses and parallel dose 
     * specification.</p> <p>This information, along with the 
     * order/sequence of the dosage lines, constitutes the details 
     * of a structured dosage instruction.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT270010CA.DosageLine"})]
    public class StructuredDosageLines : MessagePartBean {

        private CS moodCode;
        private ST text;
        private GTS effectiveTime;
        private URG<PQ, PhysicalQuantity> doseQuantity;
        private URG<PQ, PhysicalQuantity> rateQuantity;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt270010ca.AdministrationPrecondition triggerActEventCriterion;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt270010ca.AdditionalSIGInstruction componentSupplementalInstruction;

        public StructuredDosageLines() {
            this.moodCode = new CSImpl();
            this.text = new STImpl();
            this.effectiveTime = new GTSImpl();
            this.doseQuantity = new URGImpl<PQ, PhysicalQuantity>();
            this.rateQuantity = new URGImpl<PQ, PhysicalQuantity>();
        }
        /**
         * <summary>Business Name: Dosage Usage Context</summary>
         * 
         * <remarks>Relationship: COCT_MT270010CA.DosageLine.moodCode 
         * Conformance/Cardinality: MANDATORY (1) <p>- moodCode must be 
         * DEFN for drug definitions (such as monographs) - moodCode 
         * must be RQO for orders; - moodCode must be EVN for dispenses 
         * and recording of other medications</p> <p>Puts the class in 
         * context, and is therefore mandatory.</p> <p>Indicates the 
         * context of the administration.</p><p>moodCode = RQO, for 
         * administration instruction on orders</p><p>moodCode = EVN, 
         * for administration instruction on dispenses</p><p>moodCode = 
         * DEF, for administration instruction on medication definition 
         * documents/references (typically, monographs).</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"moodCode"})]
        public x_ActMoodDefEvnRqo MoodCode {
            get { return (x_ActMoodDefEvnRqo) this.moodCode.Value; }
            set { this.moodCode.Value = value; }
        }

        /**
         * <summary>Business Name: C:Ad-hoc Dosage Instruction</summary>
         * 
         * <remarks>Relationship: COCT_MT270010CA.DosageLine.text 
         * Conformance/Cardinality: REQUIRED (0-1) 
         * <p>DispensedItem.instruction</p> 
         * <p>Prescription.instruction</p> <p>D99.02</p> <p>X0201</p> 
         * <p>ZPB3.16</p> <p>DRU.030-02</p> <p>Not all dosage 
         * instructions can easily be expressed in formal 
         * terms</p><p>Allows dosage instructions to be sent across as 
         * one string of information without breaking it up.</p> 
         * <p>This field must not be used for components of the 
         * prescription that are coded elsewhere.(e.g. Coded Dosage 
         * Timing).</p> <p>A free form description of how the dispensed 
         * medication is to be administered to the patient.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public String Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Business Name: C:Dosage Timing/Frequency</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT270010CA.DosageLine.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) 
         * <p>DosageItem.Duration(OuterInterval.Width)</p> 
         * <p>DosageItem.StartDate(OuterInterval.Low)</p> 
         * <p>RepeatPattern.PatternCode(PIVL - codes will need to be 
         * mapped to and from formal GTS expressions)</p> 
         * <p>RepeatPattern.uncodedPattern (PIVL.originalText)</p> 
         * <p>ZDP.13.2.1 (PIVL.period)</p> <p>DP.13.2.2 (single time or 
         * list of times)</p> <p>PID.13.3 (outer 
         * IVL&lt;TS&gt;.width)</p> <p>PID.13.4 (outer 
         * IVL&lt;TS&gt;.low)</p> <p>PID.13.5 (outer 
         * IVL&lt;TS&gt;.high)</p> <p>Frequency</p> <p>Together with 
         * the dose quantity, indicates the overall quantity of 
         * drug.</p> <p>A structure describing the frequency (how often 
         * the drug is to be administered), offset (elapse time between 
         * administrations) represented by one line of dosage 
         * administration instruction. Includes the overall time-period 
         * the dosage instruction applies.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public GeneralTimingSpecification EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: D:Dosage Range</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT270010CA.DosageLine.doseQuantity 
         * Conformance/Cardinality: REQUIRED (0-1) 
         * <p>DosageItem.DosageRange</p> <p>ZDP.13.1</p> <p>Dosage</p> 
         * <p>Enables the checking of administration compliance that 
         * could results in fill-too-soon/fill-too-late 
         * contraindications. Supports circumstances where the dose can 
         * vary. (e.g. 1-2 tablets)</p> <p>Where no range is needed, a 
         * single value should be specified as the center, with a width 
         * of 0.</p> <p>This specifies the minimum and maximum amount 
         * of the medication to be taken during a single 
         * administration.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"doseQuantity"})]
        public UncertainRange<PhysicalQuantity> DoseQuantity {
            get { return this.doseQuantity.Value; }
            set { this.doseQuantity.Value = value; }
        }

        /**
         * <summary>Business Name: E:Dosage Rate</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT270010CA.DosageLine.rateQuantity 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required for 
         * intravenous administration</p> <p>For intravenous and other 
         * such routes, this is the time period over which one dose is 
         * to be administered. The flow rate is determined by dividing 
         * the dose quantity by the Dosage rate.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"rateQuantity"})]
        public UncertainRange<PhysicalQuantity> RateQuantity {
            get { return this.rateQuantity.Value; }
            set { this.rateQuantity.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT270010CA.Trigger.actEventCriterion</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"trigger/actEventCriterion"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt270010ca.AdministrationPrecondition TriggerActEventCriterion {
            get { return this.triggerActEventCriterion; }
            set { this.triggerActEventCriterion = value; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT270010CA.Component18.supplementalInstruction</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component/supplementalInstruction"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt270010ca.AdditionalSIGInstruction ComponentSupplementalInstruction {
            get { return this.componentSupplementalInstruction; }
            set { this.componentSupplementalInstruction = value; }
        }

    }

}