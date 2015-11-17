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
    using System;


    /**
     * <summary>Business Name: FirstFill</summary>
     * 
     * <remarks>PORX_MT060160CA.InitialSupplyRequest: First Fill 
     * <p>Allows a different amount to be dispensed on an initial 
     * fill, either as a trial or to synchronize refill dates 
     * across multiple patient prescriptions</p> <p>Special 
     * instructions regarding the very first supply of medication 
     * to a patient.</p> PORX_MT010120CA.InitialSupplyRequest: 
     * First Fill <p>Allows a different amount to be dispensed on 
     * an initial fill, either as a trial or to synchronize refill 
     * dates across multiple patient prescriptions.</p> <p>Special 
     * instructions regarding the very first supply of medication 
     * to a patient.</p> PORX_MT060340CA.InitialSupplyRequest: 
     * First Fill <p>Allows a different amount to be dispensed on 
     * an initial fill, either as a trial or to synchronize refill 
     * dates across multiple patient prescriptions</p> <p>Special 
     * instructions regarding the very first supply of medication 
     * to a patient.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT010120CA.InitialSupplyRequest","PORX_MT060160CA.InitialSupplyRequest","PORX_MT060340CA.InitialSupplyRequest"})]
    public class FirstFill : MessagePartBean {

        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private PQ quantity;
        private IVL<TS, Interval<PlatformDate>> expectedUseTime;

        public FirstFill() {
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.quantity = new PQImpl();
            this.expectedUseTime = new IVLImpl<TS, Interval<PlatformDate>>();
        }
        /**
         * <summary>Business Name: FirstFillExpiryDate</summary>
         * 
         * <remarks>Un-merged Business Name: FirstFillExpiryDate 
         * Relationship: 
         * PORX_MT060160CA.InitialSupplyRequest.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Some 
         * jurisdictions have distinct stale-date periods for the 
         * initial fill of a prescription from the overall dispensing 
         * of the prescription. E.g. &quot;The first fill must be made 
         * within 1 year, all fills must be complete within 1.5 
         * years&quot;. (This attribute would be used for the &quot;1 
         * year&quot;.)</p> <p>The date before which an initial 
         * dispense can be made against the prescription. If an initial 
         * fill has not been made against the prescription in this 
         * time-period, it may not be dispensed.</p> Un-merged Business 
         * Name: FirstFillExpiryDate Relationship: 
         * PORX_MT010120CA.InitialSupplyRequest.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Some 
         * jurisdictions have distinct stale-date periods for the 
         * initial fill of a prescription from the overall dispensing 
         * of the prescription. E.g. &quot;The first fill must be made 
         * within 1 year, all fills must be complete within 1.5 
         * years&quot;. (This attribute would be used for the &quot;1 
         * year&quot;).</p> <p>The last date before which an initial 
         * dispense can be made against the prescription. If an initial 
         * fill has not been made against the prescription in this 
         * time-period, then the prescription is no longer deemed valid 
         * and it may not be dispensed.</p> Un-merged Business Name: 
         * FirstFillExpiryDate Relationship: 
         * PORX_MT060340CA.InitialSupplyRequest.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Some 
         * jurisdictions have distinct stale-date periods for the 
         * initial fill of a prescription from the overall dispensing 
         * of the prescription. E.g. 'The first fill must be made 
         * within 1 year, all fills must be complete within 1.5 years'. 
         * (This attribute would be used for the '1 year'.)</p> <p>The 
         * date before which an initial dispense can be made against 
         * the prescription. If an initial fill has not been made 
         * against the prescription in this time-period, it may not be 
         * dispensed.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: FirstFillQuantity</summary>
         * 
         * <remarks>Un-merged Business Name: FirstFillQuantity 
         * Relationship: PORX_MT060160CA.InitialSupplyRequest.quantity 
         * Conformance/Cardinality: REQUIRED (0-1) 
         * <p>Prescription.coordinatingAmount</p> <p>Allows a limited 
         * quantity to be dispensed for a trial or for a synchronizing 
         * dose.</p> <p>The quantity of medication to be dispensed the 
         * first time the prescription is dispensed against.</p> 
         * Un-merged Business Name: FirstFillQuantity Relationship: 
         * PORX_MT010120CA.InitialSupplyRequest.quantity 
         * Conformance/Cardinality: REQUIRED (0-1) 
         * <p>Prescription.coordinatingAmount</p> <p>Allows a limited 
         * quantity to be dispensed for a trial or for a synchronizing 
         * dose.</p> <p>The quantity of medication to be dispensed the 
         * first time the prescription is dispensed against.</p> 
         * Un-merged Business Name: FirstFillQuantity Relationship: 
         * PORX_MT060340CA.InitialSupplyRequest.quantity 
         * Conformance/Cardinality: REQUIRED (0-1) 
         * <p>Prescription.coordinatingAmount</p> <p>Allows a limited 
         * quantity to be dispensed for a trial or for a synchronizing 
         * dose.</p> <p>The quantity of medication to be dispensed the 
         * first time the prescription is dispensed against.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"quantity"})]
        public PhysicalQuantity Quantity {
            get { return this.quantity.Value; }
            set { this.quantity.Value = value; }
        }

        /**
         * <summary>Business Name: FirstFillDaysSupply</summary>
         * 
         * <remarks>Un-merged Business Name: FirstFillDaysSupply 
         * Relationship: 
         * PORX_MT060160CA.InitialSupplyRequest.expectedUseTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Used when the 
         * prescriber cannot or does not wish to calculate the quantity 
         * necessary to last for the trial or synchronization time.</p> 
         * <p>The number of days that the first fill is expected to 
         * last, if the patient is compliant with the dispensing of the 
         * first fill and with administration of the prescription.</p> 
         * Un-merged Business Name: FirstFillDaysSupply Relationship: 
         * PORX_MT010120CA.InitialSupplyRequest.expectedUseTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Used when the 
         * prescriber cannot or does not wish to calculate the quantity 
         * necessary to last for the trial or synchronization time.</p> 
         * <p>The number of days that the first fill is expected to 
         * last, if the patient is compliant with the dispensing of the 
         * first fill and with administration of the prescription.</p> 
         * Un-merged Business Name: FirstFillDaysSupply Relationship: 
         * PORX_MT060340CA.InitialSupplyRequest.expectedUseTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Used when the 
         * prescriber cannot or does not wish to calculate the quantity 
         * necessary to last for the trial or synchronization time.</p> 
         * <p>The number of days that the first fill is expected to 
         * last, if the patient is compliant with the dispensing of the 
         * first fill and with administration of the prescription.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"expectedUseTime"})]
        public Interval<PlatformDate> ExpectedUseTime {
            get { return this.expectedUseTime.Value; }
            set { this.expectedUseTime.Value = value; }
        }

    }

}