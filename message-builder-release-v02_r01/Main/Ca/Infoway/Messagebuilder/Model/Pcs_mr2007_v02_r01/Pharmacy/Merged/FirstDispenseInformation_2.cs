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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: FirstDispenseInformation</summary>
     * 
     * <remarks>PORX_MT060060CA.SupplyEventFirstSummary: First 
     * Dispense Information <p>Useful in understanding the status 
     * of a prescription and in planning for renewals.</p> 
     * <p>Provides summary information about the first dispense 
     * event on the prescription</p> 
     * PORX_MT060040CA.SupplyEventFirstSummary: First Dispense 
     * Information <p>Useful in understanding the status of a 
     * prescription and in planning for renewals.</p> <p>Provides 
     * summary information about the first dispense event on the 
     * prescription</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060040CA.SupplyEventFirstSummary","PORX_MT060060CA.SupplyEventFirstSummary"})]
    public class FirstDispenseInformation_2 : MessagePartBean {

        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private INT quantity;

        public FirstDispenseInformation_2() {
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.quantity = new INTImpl();
        }
        /**
         * <summary>Business Name: FirstDispensePickupDate</summary>
         * 
         * <remarks>Un-merged Business Name: FirstDispensePickupDate 
         * Relationship: 
         * PORX_MT060060CA.SupplyEventFirstSummary.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Useful in 
         * establishing start of therapy.</p><p>Important information 
         * for compliance.</p> <p>Indicates when the first dispense 
         * against the prescription was picked up.</p> Un-merged 
         * Business Name: FirstDispensePickupDate Relationship: 
         * PORX_MT060040CA.SupplyEventFirstSummary.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Useful in 
         * establishing start of therapy.</p><p>Important information 
         * for compliance.</p> <p>Indicates when the first dispense 
         * against the prescription was picked up.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: FirstQuantityDispensed</summary>
         * 
         * <remarks>Un-merged Business Name: FirstQuantityDispensed 
         * Relationship: 
         * PORX_MT060060CA.SupplyEventFirstSummary.quantity 
         * Conformance/Cardinality: MANDATORY (1) <p>Usually 
         * establishes trial quantities for a 
         * prescription.</p><p>Because the quantity should always be 
         * known if the first dispense is known, this attribute is 
         * mandatory.</p> <p>Indicates the number of devices first 
         * dispensed on the prescription.</p> Un-merged Business Name: 
         * FirstQuantityDispensed Relationship: 
         * PORX_MT060040CA.SupplyEventFirstSummary.quantity 
         * Conformance/Cardinality: MANDATORY (1) <p>Usually 
         * establishes trial quantities for a prescription. If the 
         * first dispense is known, then the quantity must be known, 
         * thus the element is mandatory.</p> <p>Indicates the amount 
         * of device first dispensed on the prescription.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"quantity"})]
        public int? Quantity {
            get { return this.quantity.Value; }
            set { this.quantity.Value = value; }
        }

    }

}