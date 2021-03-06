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
 * Author:        $LastChangedBy: jmis $
 * Last modified: $LastChangedDate: 2015-09-15 11:09:53 -0400 (Tue, 15 Sep 2015) $
 * Revision:      $LastChangedRevision: 9796 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT400003CA.MaximumLimits","FICR_MT400004CA.MaximumLimits","FICR_MT490102CA.MaximumLimits"})]
    public class MaximumLimits : MessagePartBean {

        private INT repeatNumber;
        private PQ quantity;
        private IVL<TS, Interval<PlatformDate>> expectedUseTime;

        public MaximumLimits() {
            this.repeatNumber = new INTImpl();
            this.quantity = new PQImpl();
            this.expectedUseTime = new IVLImpl<TS, Interval<PlatformDate>>();
        }
        /**
         * <summary>Business Name: MaximumFillsPermitted</summary>
         * 
         * <remarks>Un-merged Business Name: MaximumFillsPermitted 
         * Relationship: FICR_MT490102CA.MaximumLimits.repeatNumber 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: MaximumFillsPermitted Relationship: 
         * FICR_MT400003CA.MaximumLimits.repeatNumber 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: MaximumFillsPermitted Relationship: 
         * FICR_MT400004CA.MaximumLimits.repeatNumber 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"repeatNumber"})]
        public int? RepeatNumber {
            get { return this.repeatNumber.Value; }
            set { this.repeatNumber.Value = value; }
        }

        /**
         * <summary>Business Name: MaximumQuantitySupply</summary>
         * 
         * <remarks>Un-merged Business Name: MaximumQuantitySupply 
         * Relationship: FICR_MT490102CA.MaximumLimits.quantity 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: MaximumQuantitySupply Relationship: 
         * FICR_MT400003CA.MaximumLimits.quantity 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: MaximumQuantitySupply Relationship: 
         * FICR_MT400004CA.MaximumLimits.quantity 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"quantity"})]
        public PhysicalQuantity Quantity {
            get { return this.quantity.Value; }
            set { this.quantity.Value = value; }
        }

        /**
         * <summary>Business Name: MaximumDaysSupply</summary>
         * 
         * <remarks>Un-merged Business Name: MaximumDaysSupply 
         * Relationship: FICR_MT490102CA.MaximumLimits.expectedUseTime 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: MaximumDaysSupply Relationship: 
         * FICR_MT400003CA.MaximumLimits.expectedUseTime 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: MaximumDaysSupply Relationship: 
         * FICR_MT400004CA.MaximumLimits.expectedUseTime 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"expectedUseTime"})]
        public Interval<PlatformDate> ExpectedUseTime {
            get { return this.expectedUseTime.Value; }
            set { this.expectedUseTime.Value = value; }
        }

    }

}