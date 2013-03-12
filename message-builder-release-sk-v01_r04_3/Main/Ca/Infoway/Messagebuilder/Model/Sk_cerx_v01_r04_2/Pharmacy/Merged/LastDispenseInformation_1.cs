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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: LastDispenseInformation</summary>
     * 
     * <remarks>PORX_MT060160CA.SupplyEventLastSummary: Last 
     * Dispense Information <p>Provides summary information about 
     * the most recent dispense event performed against the 
     * prescription</p> <p>Useful in understanding the status of a 
     * prescription and in planning for renewals.</p> 
     * PORX_MT060190CA.SupplyEventLastSummary: Last Dispense 
     * Information <p>Provides summary information about the most 
     * recent dispense event performed against the prescription</p> 
     * <p>Useful in understanding the status of a prescription and 
     * in planning for renewals.</p> 
     * PORX_MT060340CA.SupplyEventLastSummary: Last Dispense 
     * Information <p>Provides summary information about the most 
     * recent dispense event performed against the prescription</p> 
     * <p>Useful in understanding the status of a prescription and 
     * in planning for renewals.</p> 
     * PORX_MT030040CA.SupplyEventLastSummary: Last Dispense 
     * Information <p>Provides summary information about the most 
     * recent dispense event performed against the prescription</p> 
     * <p>Useful in understanding the status of a prescription and 
     * in planning for renewals.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT030040CA.SupplyEventLastSummary","PORX_MT060160CA.SupplyEventLastSummary","PORX_MT060190CA.SupplyEventLastSummary","PORX_MT060340CA.SupplyEventLastSummary"})]
    public class LastDispenseInformation_1 : MessagePartBean {

        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private PQ quantity;

        public LastDispenseInformation_1() {
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.quantity = new PQImpl();
        }
        /**
         * <summary>Business Name: LastDispensePickupDate</summary>
         * 
         * <remarks>Un-merged Business Name: LastDispensePickupDate 
         * Relationship: 
         * PORX_MT060160CA.SupplyEventLastSummary.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Indicates the 
         * most recent date on which a dispense on the prescription was 
         * picked up.</p> <p>Useful in determining when a prescription 
         * will next need to be dispensed. Also provides an indication 
         * of compliance.</p> Un-merged Business Name: 
         * LastDispensePickupDate Relationship: 
         * PORX_MT060190CA.SupplyEventLastSummary.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Indicates the 
         * most recent date on which a dispense on the prescription was 
         * picked up.</p> <p>Useful in determining when a prescription 
         * will next need to be dispensed. Also provides an indication 
         * of compliance.</p> Un-merged Business Name: 
         * LastDispensePickupDate Relationship: 
         * PORX_MT030040CA.SupplyEventLastSummary.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Indicates the 
         * most recent date on which a dispense on the prescription was 
         * picked up.</p> <p>Useful in determining when a prescription 
         * will next need to be dispensed. Also provides an indication 
         * of compliance.</p> Un-merged Business Name: 
         * LastDispensePickupDate Relationship: 
         * PORX_MT060340CA.SupplyEventLastSummary.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Indicates the 
         * most recent date on which a dispense on the prescription was 
         * picked up.</p> <p>Useful in determining when a prescription 
         * will next need to be dispensed. Also provides an indication 
         * of compliance.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: LastQuantityDispensed</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060160CA.SupplyEventLastSummary.quantity 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates the most 
         * recent quantity of the drug that was picked up for the 
         * prescription.</p> <p>Useful in determining the amount of 
         * medication that a patient should have on-hand. Also provides 
         * an indication of compliance.</p><p>Because the quantity 
         * should always be known if the last dispense is known, this 
         * attribute is mandatory.</p> <p>Useful in determining the 
         * amount of medication that a patient should have on-hand. 
         * Also provides an indication of compliance.</p><p>Because the 
         * quantity should always be known if the last dispense is 
         * known, this attribute is mandatory.</p> Un-merged Business 
         * Name: LastDispenseQuantity Relationship: 
         * PORX_MT060190CA.SupplyEventLastSummary.quantity 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates the most 
         * recent quantity of the drug that was picked up for the 
         * prescription.</p> <p>Useful in determining amount of 
         * medication that a patient should have on-hand. Also provides 
         * an indication of compliance.</p><p>Because the quantity 
         * should always be known if the last dispense is known, this 
         * attribute is mandatory.</p> <p>Useful in determining amount 
         * of medication that a patient should have on-hand. Also 
         * provides an indication of compliance.</p><p>Because the 
         * quantity should always be known if the last dispense is 
         * known, this attribute is mandatory.</p> Un-merged Business 
         * Name: LastQuantityDispensed Relationship: 
         * PORX_MT030040CA.SupplyEventLastSummary.quantity 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates the most 
         * recent quantity of the drug that was picked up for the 
         * prescription.</p> <p>Useful in determining amount of 
         * medication that a patient should have on-hand. Also provides 
         * an indication of compliance.</p><p>If the most recent 
         * dispense information is known, the quantity must be known 
         * and therefore is mandatory</p> <p>Useful in determining 
         * amount of medication that a patient should have on-hand. 
         * Also provides an indication of compliance.</p><p>If the most 
         * recent dispense information is known, the quantity must be 
         * known and therefore is mandatory</p> Un-merged Business 
         * Name: LastQuantityDispensed Relationship: 
         * PORX_MT060340CA.SupplyEventLastSummary.quantity 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates the most 
         * recent quantity of the drug that was picked up for the 
         * prescription.</p> <p>Useful in determining amount of 
         * medication that a patient should have on-hand. Also provides 
         * an indication of compliance.</p><p>Because the quantity 
         * should always be known if the last dispense is known, this 
         * attribute is mandatory.</p> <p>Useful in determining amount 
         * of medication that a patient should have on-hand. Also 
         * provides an indication of compliance.</p><p>Because the 
         * quantity should always be known if the last dispense is 
         * known, this attribute is mandatory.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"quantity"})]
        public PhysicalQuantity Quantity {
            get { return this.quantity.Value; }
            set { this.quantity.Value = value; }
        }

    }

}