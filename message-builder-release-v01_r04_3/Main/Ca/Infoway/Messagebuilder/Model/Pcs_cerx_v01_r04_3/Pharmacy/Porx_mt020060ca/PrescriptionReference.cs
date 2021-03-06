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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Porx_mt020060ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt090107ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged;


    /**
     * <summary>Business Name: Prescription Reference</summary>
     * 
     * <p>The Prescriber Name must be specified only when the 
     * Prescription ID is Null</p> <p>Dispenses for electronically 
     * created prescriptions must reference the prescription.</p> 
     * <p>Information pertaining to the prescription for which a 
     * dispense is being created</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT020060CA.DeviceRequest"})]
    public class PrescriptionReference : MessagePartBean {

        private II id;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt090107ca.Provider responsiblePartyAssignedPerson;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged.RefusedBy author;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.DispenseInstructions_1 componentSupplyRequest;

        public PrescriptionReference() {
            this.id = new IIImpl();
        }
        /**
         * <summary>Business Name: D:Prescription Order Number</summary>
         * 
         * <remarks>Relationship: PORX_MT020060CA.DeviceRequest.id 
         * Conformance/Cardinality: REQUIRED (1) 
         * <p>Prescription.prescriptionNumber</p> 
         * <p>Prescription.prescriptionExternalKey</p> <p>D53(ID for 
         * the prescription assigned by pharmacy)</p> <p>D55(ID for the 
         * dispense event)</p> <p>D99.01</p> <p>X0101(id for 
         * prescription)</p> <p>ZDP.5</p> <p>ZDP.6</p> <p>ZDP.22</p> 
         * <p>ZRV.5</p> <p>DRU.080-01(extension)</p> 
         * <p>DRU.080-02(route)</p> <p>Claim.455-EM (route)</p> 
         * <p>Claim.402-D2 (extension)</p> <p>Claim.456-EN</p> 
         * <p>Claim.454-EK</p> <p>A_BillablePharmacyDispense</p> 
         * <p>Allows prescriptions to be uniquely referenced.</p><p>The 
         * ID is only 'populated' because in some cases the 
         * prescription will not yet exist electronically.</p> <p>The 
         * identifier of the prescription for which a dispense is 
         * beiing created.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT020060CA.ResponsibleParty3.assignedPerson</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/assignedPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt090107ca.Provider ResponsiblePartyAssignedPerson {
            get { return this.responsiblePartyAssignedPerson; }
            set { this.responsiblePartyAssignedPerson = value; }
        }

        /**
         * <summary>Relationship: PORX_MT020060CA.DeviceRequest.author</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged.RefusedBy Author {
            get { return this.author; }
            set { this.author = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT020060CA.Component2.supplyRequest</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component/supplyRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.DispenseInstructions_1 ComponentSupplyRequest {
            get { return this.componentSupplyRequest; }
            set { this.componentSupplyRequest = value; }
        }

    }

}