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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pharmacy.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: RemainingDispenseInformation</summary>
     * 
     * <remarks>PORX_MT060040CA.SupplyEventFutureSummary: Remaining 
     * Dispense Information <p>At least one of quantity and 
     * repeatNumber must be specified.</p> <p>Useful in 
     * understanding the status of a prescription and in planning 
     * for renewals.</p> <p>Provides summary information about what 
     * dispenses remain to be performed against the 
     * prescription</p> PORX_MT060060CA.SupplyEventFutureSummary: 
     * Remaining Dispense Information <p>At least one of quantity 
     * and repeatNumber must be specified.</p> <p>Useful in 
     * understanding the status of a prescription and in planning 
     * for renewals.</p> <p>Provides summary information about what 
     * dispenses remain to be performed against the 
     * prescription</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060040CA.SupplyEventFutureSummary","PORX_MT060060CA.SupplyEventFutureSummary"})]
    public class RemainingDispenseInformation_2 : MessagePartBean {

        private INT repeatNumber;
        private INT quantity;

        public RemainingDispenseInformation_2() {
            this.repeatNumber = new INTImpl();
            this.quantity = new INTImpl();
        }
        /**
         * <summary>Business Name: FillsRemaining</summary>
         * 
         * <remarks>Un-merged Business Name: FillsRemaining 
         * Relationship: 
         * PORX_MT060040CA.SupplyEventFutureSummary.repeatNumber 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Indicates the 
         * number of dispenses that may still occur.</p> <p>Indicates 
         * the number of remaining dispenses estimated, assuming that 
         * each fill is equal to the quantity prescribed for a single 
         * fill, rounding up.</p> Un-merged Business Name: 
         * FillsRemaining Relationship: 
         * PORX_MT060060CA.SupplyEventFutureSummary.repeatNumber 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Indicates the 
         * number of dispenses that may still occur.</p> <p>Indicates 
         * the number of remaining dispenses estimated, assuming that 
         * each fill is equal to the quantity prescribed for a single 
         * fill, rounding up.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"repeatNumber"})]
        public int? RepeatNumber {
            get { return this.repeatNumber.Value; }
            set { this.repeatNumber.Value = value; }
        }

        /**
         * <summary>Business Name: RemainingTotalQuantity</summary>
         * 
         * <remarks>Un-merged Business Name: RemainingTotalQuantity 
         * Relationship: 
         * PORX_MT060040CA.SupplyEventFutureSummary.quantity 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Indicates how 
         * much can still be dispensed.</p> <p>Indicates the total 
         * remaining undispensed quantity authorized against the 
         * prescription.</p> Un-merged Business Name: 
         * RemainingTotalQuantity Relationship: 
         * PORX_MT060060CA.SupplyEventFutureSummary.quantity 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Indicates how 
         * much can still be dispensed.</p> <p>Indicates the total 
         * remaining undispensed quantity authorized against the 
         * prescription.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"quantity"})]
        public int? Quantity {
            get { return this.quantity.Value; }
            set { this.quantity.Value = value; }
        }

    }

}