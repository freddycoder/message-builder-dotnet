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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt090107ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged;


    /**
     * <summary>Business Name: PrescriptionReference</summary>
     * 
     * <remarks>PORX_MT020070CA.SubstanceAdministrationRequest: 
     * Prescription Reference <p>The Prescriber Name must be 
     * specified only when the Prescription Order Number is 
     * Null.</p> <p>Dispenses for electronically created 
     * prescriptions must reference the prescription.</p> 
     * <p>Information pertaining to the prescription for which a 
     * dispense is being created</p> PORX_MT060010CA.SupplyRequest: 
     * Prescription Reference <p>Links a dispense with its parent 
     * prescription.</p> <p>A reference to the prescription order 
     * being dispensed</p> 
     * PORX_MT060090CA.SubstanceAdministrationRequest: Prescription 
     * Reference <p>Links a dispense with its parent 
     * prescription.</p> <p>A reference to the prescription order 
     * being dispensed</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT020070CA.SubstanceAdministrationRequest","PORX_MT060010CA.SupplyRequest","PORX_MT060090CA.SubstanceAdministrationRequest"})]
    public class PrescriptionReference : MessagePartBean {

        private II id;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt090107ca.Provider responsiblePartyAssignedPerson;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged.RefusedBy author;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.Component2 component;

        public PrescriptionReference() {
            this.id = new IIImpl();
        }
        /**
         * <summary>Business Name: PrescriptionOrderNumber</summary>
         * 
         * <remarks>Un-merged Business Name: PrescriptionOrderNumber 
         * Relationship: 
         * PORX_MT020070CA.SubstanceAdministrationRequest.id 
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
         * identifier of the prescription for which a dispense is being 
         * created.</p> Un-merged Business Name: 
         * PrescriptionOrderNumber Relationship: 
         * PORX_MT060010CA.SupplyRequest.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Allows prescriptions to be uniquely 
         * referenced and associated with the dispense.</p><p>The ID is 
         * mandatory because the DIS will always assign a Prescription 
         * Order Number.</p> <p>This is an identifier assigned to a 
         * specific device order. The number remains constant across 
         * the lifetime of the order, regardless of the number of 
         * providers or pharmacies involved in fulfilling the 
         * order.</p> Un-merged Business Name: PrescriptionOrderNumber 
         * Relationship: 
         * PORX_MT060090CA.SubstanceAdministrationRequest.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows 
         * prescriptions to be uniquely referenced and associated with 
         * the dispense.</p><p>The ID is mandatory because the DIS will 
         * always assign a Prescription Order Number.</p> <p>This is an 
         * identifier assigned to a specific medication order. The 
         * number remains constant across the lifetime of the order, 
         * regardless of the number of providers or pharmacies involved 
         * in fulfilling the order.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT020070CA.ResponsibleParty3.assignedPerson 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060010CA.ResponsibleParty3.assignedPerson 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060090CA.ResponsibleParty3.assignedPerson 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/assignedPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt090107ca.Provider ResponsiblePartyAssignedPerson {
            get { return this.responsiblePartyAssignedPerson; }
            set { this.responsiblePartyAssignedPerson = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT020070CA.SubstanceAdministrationRequest.author 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060010CA.SupplyRequest.author 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060090CA.SubstanceAdministrationRequest.author 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged.RefusedBy Author {
            get { return this.author; }
            set { this.author = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT020070CA.SubstanceAdministrationRequest.component 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.Component2 Component {
            get { return this.component; }
            set { this.component = value; }
        }

    }

}