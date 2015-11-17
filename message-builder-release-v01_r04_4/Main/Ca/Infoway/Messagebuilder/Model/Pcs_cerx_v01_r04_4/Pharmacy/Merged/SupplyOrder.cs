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
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt090107ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Merged;


    /**
     * <summary>PORX_MT060020CA.SupplyRequest: Prescription 
     * Reference</summary>
     * 
     * <p>Links a dispense with its parent prescription.</p> <p>A 
     * reference to the prescription order being dispensed</p> 
     * PORX_MT020050CA.SupplyRequest: Supply Order <p>Ensures that 
     * dispenses to offices (non-patient identifiable dispenses) 
     * follow the normal dispensing rules.</p> <p>Identification of 
     * the supply information. This prescription will have a supply 
     * order portion but no administration part.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT020050CA.SupplyRequest","PORX_MT060020CA.SupplyRequest"})]
    public class SupplyOrder : MessagePartBean {

        private II id;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt090107ca.Provider responsiblePartyAssignedPerson;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Merged.PrescribedBy author;

        public SupplyOrder() {
            this.id = new IIImpl();
        }
        /**
         * <summary>Business Name: PrescriptionIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: PrescriptionIdentifier 
         * Relationship: PORX_MT060020CA.SupplyRequest.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows 
         * prescriptions to be uniquely referenced and associated with 
         * the dispense.</p><p>The ID is mandatory because the DIS 
         * would always assign a Prescription Number.</p> <p>This is an 
         * identifier assigned to a specific device order. The number 
         * remains constant across the lifetime of the order, 
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
         * PORX_MT060020CA.ResponsibleParty2.assignedPerson 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT020050CA.ResponsibleParty.assignedPerson 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/assignedPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt090107ca.Provider ResponsiblePartyAssignedPerson {
            get { return this.responsiblePartyAssignedPerson; }
            set { this.responsiblePartyAssignedPerson = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: PORX_MT060020CA.SupplyRequest.author 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT020050CA.SupplyRequest.author 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Merged.PrescribedBy Author {
            get { return this.author; }
            set { this.author = value; }
        }

    }

}