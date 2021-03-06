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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Porx_mt030040ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged;


    /**
     * <summary>Business Name: Dispense Instructions</summary>
     * 
     * <p>Sets the parameters within which the dispenser must 
     * operate in dispensing the medication to the patient.</p> 
     * <p>Specification of how the prescribed medication is to be 
     * dispensed to the patient. Dispensed instruction information 
     * includes the quantity to be dispensed, how often the 
     * quantity is to be dispensed, etc.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT030040CA.SupplyRequest"})]
    public class DispenseInstructions : MessagePartBean {

        private CS statusCode;
        private PQ quantity;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.TargetedToPharmacy location;

        public DispenseInstructions() {
            this.statusCode = new CSImpl();
            this.quantity = new PQImpl();
        }
        /**
         * <summary>Business Name: A:Prescription Dispense Indicator</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT030040CA.SupplyRequest.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows a 
         * prescriber to say &quot;Finish what you have on hand, but 
         * don't get any more.&quot;</p><p>Because the status should 
         * always be known, this element is mandatory.</p> <p>This 
         * generally mirrors the status for the prescription, but in 
         * some circumstances may be changed to 'aborted' while the 
         * prescription is still active. When this occurs, it means the 
         * prescription may no longer be dispensed, though it may still 
         * be administered.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: B:Total Prescribed Quantity</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT030040CA.SupplyRequest.quantity 
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
         * <summary>Relationship: 
         * PORX_MT030040CA.SupplyRequest.location</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.TargetedToPharmacy Location {
            get { return this.location; }
            set { this.location = value; }
        }

    }

}