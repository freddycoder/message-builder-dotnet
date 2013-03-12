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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>Business Name: Includes</summary>
     * 
     * <remarks>PORX_MT060060CA.Component6: f:includes 
     * <p>Identifies the instructions for how the prescribed device 
     * should be dispensed to the patient.</p><p>An essential part 
     * of most prescriptions is the authorization to 
     * dispense.</p><p>The association is marked as Populated 
     * because the authorization to dispense is a critical portion 
     * of a prescription. However the association is allowed to be 
     * 'null' when the order is for a device which requires no 
     * dispense authorization, or when the patient already has 
     * sufficient supply of the device on hand to complete the 
     * therapy.</p> <p>Identifies the instructions for how the 
     * prescribed device should be dispensed to the patient.</p> 
     * PORX_MT020060CA.Component2: (no business name) <p>Component 
     * must be specified if the id is null and can not be specified 
     * if the id is not null.</p> PORX_MT060040CA.Component6: 
     * f:includes <p>An essential part of most prescriptions is the 
     * authorization to dispense.</p> <p>Identifies the 
     * instructions for how the prescribed device should be 
     * dispensed to the patient.</p> PORX_MT010110CA.Component6: 
     * f:includes <p>An essential part of most prescriptions is the 
     * authorization to dispense.</p> <p>Identifies the 
     * instructions for how the prescribed device should be 
     * dispensed to the patient.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT010110CA.Component6","PORX_MT020060CA.Component2","PORX_MT060040CA.Component6","PORX_MT060060CA.Component6"})]
    public class Component2_1 : MessagePartBean {

        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.DispenseInstructions_1 supplyRequest;

        public Component2_1() {
        }
        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060060CA.Component6.supplyRequest 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT020060CA.Component2.supplyRequest 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060040CA.Component6.supplyRequest 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT010110CA.Component6.supplyRequest 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"supplyRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.DispenseInstructions_1 SupplyRequest {
            get { return this.supplyRequest; }
            set { this.supplyRequest = value; }
        }

    }

}