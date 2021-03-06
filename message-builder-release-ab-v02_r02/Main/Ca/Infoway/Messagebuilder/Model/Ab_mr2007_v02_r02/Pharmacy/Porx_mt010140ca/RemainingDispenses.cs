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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Porx_mt010140ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt220100ca;


    /**
     * <summary>Business Name: Remaining Dispenses</summary>
     * 
     * <p>Indicates dispenses yet to be made against the 
     * prescription</p> <p>Allows updating the quantity remaining 
     * to be dispensed.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT010140CA.SupplyEvent"})]
    public class RemainingDispenses : MessagePartBean {

        private PQ quantity;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt220100ca.DrugProduct productMedication;

        public RemainingDispenses() {
            this.quantity = new PQImpl();
        }
        /**
         * <summary>Business Name: C:Remaining Quantity</summary>
         * 
         * <remarks>Relationship: PORX_MT010140CA.SupplyEvent.quantity 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates the 
         * remaining quantity to be dispensed.</p> <p>Used to adjust 
         * quantity asserted with the electronic version of a 
         * prescription when fills have been issued by non-electronic 
         * pharmacies. Particularly important when the electronic 
         * version is being made 'authoritative' again.</p> <p>The 
         * specified remaining fill quantity may never be greater than 
         * the remaining quantity recorded in the electronic system. If 
         * not specified, the quantity remaining will be left 
         * unchanged.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"quantity"})]
        public PhysicalQuantity Quantity {
            get { return this.quantity.Value; }
            set { this.quantity.Value = value; }
        }

        /**
         * <summary>Relationship: PORX_MT010140CA.Product.medication</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"product/medication"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt220100ca.DrugProduct ProductMedication {
            get { return this.productMedication; }
            set { this.productMedication = value; }
        }

    }

}