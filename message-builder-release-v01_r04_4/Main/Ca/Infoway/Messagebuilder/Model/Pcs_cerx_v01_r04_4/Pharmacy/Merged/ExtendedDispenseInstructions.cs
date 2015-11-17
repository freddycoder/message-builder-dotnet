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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt220110ca;
    using System;


    /**
     * <summary>PORX_MT060160CA.SupplyRequestItem: Dispense 
     * Instruction Details</summary>
     * 
     * <p>Sets the parameters within which the dispenser must 
     * operate in dispensing the medication to the 
     * patient.</p><p>Allows dispensing instructions to be given at 
     * specific dispensable drug level for an overall prescribed 
     * drug.</p> <p>Specification of how the prescribed medication 
     * is to be dispensed to the patient. Dispensed instruction 
     * information includes the quantity to be dispensed, how often 
     * the quantity is to be dispensed, etc.</p> 
     * PORX_MT060340CA.SupplyRequestItem: Extended Dispense 
     * Instructions <p>Sets the parameters within which the 
     * dispenser must operate in dispensing the medication to the 
     * patient.</p> <p>Specification of the overall use duration of 
     * the prescrbed medication and/or overall quantity to be 
     * dispensed.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060160CA.SupplyRequestItem","PORX_MT060340CA.SupplyRequestItem"})]
    public class ExtendedDispenseInstructions : MessagePartBean {

        private PQ quantity;
        private IVL<TS, Interval<PlatformDate>> expectedUseTime;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt220110ca.DrugProduct productMedication;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.FirstFill component2InitialSupplyRequest;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.SubsequentSupplyRequest component1SubsequentSupplyRequest;

        public ExtendedDispenseInstructions() {
            this.quantity = new PQImpl();
            this.expectedUseTime = new IVLImpl<TS, Interval<PlatformDate>>();
        }
        /**
         * <summary>Business Name: TotalPrescribedQuantity</summary>
         * 
         * <remarks>Un-merged Business Name: TotalPrescribedQuantity 
         * Relationship: PORX_MT060160CA.SupplyRequestItem.quantity 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Sets upper limit 
         * for medication to be dispensed. Can be used to verify the 
         * intention of the prescriber with respect to the overall 
         * medication. Used for comparison when determining whether 
         * additional quantity may be dispensed in the context of a 
         * part-fill prescription.</p><p>Narcotics must always be 
         * specified as a total quantity.</p> <p>The overall amount of 
         * amount medication to be dispensed under this prescription. 
         * Includes any first fills (trials, aligning quantities), the 
         * initial standard fill plus all refills.</p> Un-merged 
         * Business Name: TotalPrescribedQuantity Relationship: 
         * PORX_MT060340CA.SupplyRequestItem.quantity 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Sets upper limit 
         * for medication to be dispensed. Can be used to verify the 
         * intention of the prescriber with respect to the overall 
         * medication. Used for comparison when determining whether 
         * additional quantity may be dispensed in the context of a 
         * part-fill prescription.</p><p>Narcotics must always be 
         * specified as a total quantity.</p> <p>The overall amount of 
         * amount medication to be dispensed under this prescription. 
         * Includes any first fills (trials, aligning quantities), the 
         * initial standard fill plus all refills.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"quantity"})]
        public PhysicalQuantity Quantity {
            get { return this.quantity.Value; }
            set { this.quantity.Value = value; }
        }

        /**
         * <summary>Business Name: TotalDaysSupply</summary>
         * 
         * <remarks>Un-merged Business Name: TotalDaysSupply 
         * Relationship: 
         * PORX_MT060160CA.SupplyRequestItem.expectedUseTime 
         * Conformance/Cardinality: MANDATORY (1) <p>Used to specify a 
         * total authorization as a duration rather than a quantity 
         * with refills. E.g. dispense 30 at a time, refill for 1 year. 
         * May also be sent as an estimate of the expected overall 
         * duration of the prescription based on the quantity 
         * prescribed. This attribute is mandatory because the 
         * prescriber (in discussion with the patient) has a better 
         * understanding of the days supply needed by the patient.</p> 
         * <p>The number of days that the overall prescribed item is 
         * expected to last, if the patient is compliant with the 
         * dispensing and administration of the prescription.</p> 
         * Un-merged Business Name: TotalDaysSupply Relationship: 
         * PORX_MT060340CA.SupplyRequestItem.expectedUseTime 
         * Conformance/Cardinality: MANDATORY (1) <p>Used to specify a 
         * total authorization as a duration rather than a quantity 
         * with refills. E.g. dispense 30 at a time, refill for 1 year. 
         * May also be sent as an estimate of the expected overall 
         * duration of the prescription based on the quantity 
         * prescribed. This attribute is mandatory because the 
         * prescriber (in discussion with the patient) has a better 
         * understanding of the days supply needed by the patient.</p> 
         * <p>The number of days that the overall prescribed item is 
         * expected to last, if the patient is compliant with the 
         * dispensing and administration of the prescription.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"expectedUseTime"})]
        public Interval<PlatformDate> ExpectedUseTime {
            get { return this.expectedUseTime.Value; }
            set { this.expectedUseTime.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: PORX_MT060160CA.Product1.medication 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060340CA.Product1.medication Conformance/Cardinality: 
         * REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"product/medication"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt220110ca.DrugProduct ProductMedication {
            get { return this.productMedication; }
            set { this.productMedication = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060160CA.Component7.initialSupplyRequest 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060340CA.Component7.initialSupplyRequest 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component1/initialSupplyRequest","component2/initialSupplyRequest"})]
        [Hl7MapByPartType(Name="component1", Type="PORX_MT060160CA.Component7")]
        [Hl7MapByPartType(Name="component1/initialSupplyRequest", Type="PORX_MT060160CA.InitialSupplyRequest")]
        [Hl7MapByPartType(Name="component2", Type="PORX_MT060340CA.Component7")]
        [Hl7MapByPartType(Name="component2/initialSupplyRequest", Type="PORX_MT060340CA.InitialSupplyRequest")]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.FirstFill Component2InitialSupplyRequest {
            get { return this.component2InitialSupplyRequest; }
            set { this.component2InitialSupplyRequest = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060160CA.Component8.subsequentSupplyRequest 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060340CA.Component8.subsequentSupplyRequest 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component1/subsequentSupplyRequest","component2/subsequentSupplyRequest"})]
        [Hl7MapByPartType(Name="component1", Type="PORX_MT060340CA.Component8")]
        [Hl7MapByPartType(Name="component1/subsequentSupplyRequest", Type="PORX_MT060340CA.SubsequentSupplyRequest")]
        [Hl7MapByPartType(Name="component2", Type="PORX_MT060160CA.Component8")]
        [Hl7MapByPartType(Name="component2/subsequentSupplyRequest", Type="PORX_MT060160CA.SubsequentSupplyRequest")]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.SubsequentSupplyRequest Component1SubsequentSupplyRequest {
            get { return this.component1SubsequentSupplyRequest; }
            set { this.component1SubsequentSupplyRequest = value; }
        }

    }

}