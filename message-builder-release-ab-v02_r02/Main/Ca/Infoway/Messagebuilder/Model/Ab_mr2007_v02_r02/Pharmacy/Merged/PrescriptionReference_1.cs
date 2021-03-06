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
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt090108ca;
    using System;


    /**
     * <summary>Business Name: PrescriptionReference</summary>
     * 
     * <remarks>PORX_MT060010CA.SupplyRequest: Prescription 
     * Reference <p>A reference to the prescription order being 
     * dispensed</p> <p>Links a dispense with its parent 
     * prescription.</p> 
     * PORX_MT060090CA.SubstanceAdministrationRequest: Prescription 
     * Reference <p>A reference to the prescription order being 
     * dispensed</p> <p>Links a dispense with its parent 
     * prescription.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060010CA.SupplyRequest","PORX_MT060090CA.SubstanceAdministrationRequest"})]
    public class PrescriptionReference_1 : MessagePartBean {

        private II id;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt090108ca.HealthcareWorker responsiblePartyAssignedEntity;
        private TS authorTime;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt090108ca.HealthcareWorker authorAssignedEntity;

        public PrescriptionReference_1() {
            this.id = new IIImpl();
            this.authorTime = new TSImpl();
        }
        /**
         * <summary>Business Name: PrescriptionOrderNumber</summary>
         * 
         * <remarks>Un-merged Business Name: PrescriptionOrderNumber 
         * Relationship: PORX_MT060010CA.SupplyRequest.id 
         * Conformance/Cardinality: MANDATORY (1) <p>This is an 
         * identifier assigned to a specific device order. The number 
         * remains constant across the lifetime of the order, 
         * regardless of the number of providers or pharmacies involved 
         * in fulfilling the order.</p> <p>Allows prescriptions to be 
         * uniquely referenced and associated with the 
         * dispense.</p><p>The ID is mandatory because the DIS will 
         * always assign a Prescription Order Number.</p> <p>Allows 
         * prescriptions to be uniquely referenced and associated with 
         * the dispense.</p><p>The ID is mandatory because the DIS will 
         * always assign a Prescription Order Number.</p> Un-merged 
         * Business Name: PrescriptionOrderNumber Relationship: 
         * PORX_MT060090CA.SubstanceAdministrationRequest.id 
         * Conformance/Cardinality: MANDATORY (1) <p>This is an 
         * identifier assigned to a specific medication order. The 
         * number remains constant across the lifetime of the order, 
         * regardless of the number of providers or pharmacies involved 
         * in fulfilling the order.</p> <p>Allows prescriptions to be 
         * uniquely referenced and associated with the 
         * dispense.</p><p>The ID is mandatory because the DIS will 
         * always assign a Prescription Order Number.</p> <p>Allows 
         * prescriptions to be uniquely referenced and associated with 
         * the dispense.</p><p>The ID is mandatory because the DIS will 
         * always assign a Prescription Order Number.</p></remarks>
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
         * PORX_MT060010CA.ResponsibleParty3.assignedEntity 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060090CA.ResponsibleParty3.assignedEntity 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt090108ca.HealthcareWorker ResponsiblePartyAssignedEntity {
            get { return this.responsiblePartyAssignedEntity; }
            set { this.responsiblePartyAssignedEntity = value; }
        }

        /**
         * <summary>Business Name: PrescriptionOrderDate</summary>
         * 
         * <remarks>Un-merged Business Name: PrescriptionOrderDate 
         * Relationship: PORX_MT060010CA.Author5.time 
         * Conformance/Cardinality: POPULATED (1) <p>The date at which 
         * the device was prescribed. This may differ from the date on 
         * which the prescription becomes effective. E.g. A 
         * prescription created today may not be valid to be dispensed 
         * or used for two weeks.</p> <p>Indicates when the action was 
         * performed, and may influence expiry dates for the 
         * order.</p><p>The attribute is populated because the creation 
         * date of the prescription shall always be known or absent for 
         * a reason.</p> <p>Indicates when the action was performed, 
         * and may influence expiry dates for the order.</p><p>The 
         * attribute is populated because the creation date of the 
         * prescription shall always be known or absent for a 
         * reason.</p> Un-merged Business Name: PrescriptionOrderDate 
         * Relationship: PORX_MT060090CA.Author5.time 
         * Conformance/Cardinality: POPULATED (1) <p>The date at which 
         * the drug was prescribed. This may differ from the date on 
         * which the prescription becomes effective. E.g. A 
         * prescription created today may not be valid to be dispensed 
         * or administered for two weeks.</p> <p>Indicates when the 
         * action was performed, and may influence expiry dates for the 
         * order.</p><p>The attribute is populated because the creation 
         * date of the prescription shall always be known or absent for 
         * a reason.</p> <p>Indicates when the action was performed, 
         * and may influence expiry dates for the order.</p><p>The 
         * attribute is populated because the creation date of the 
         * prescription shall always be known or absent for a 
         * reason.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author/time"})]
        public PlatformDate AuthorTime {
            get { return this.authorTime.Value; }
            set { this.authorTime.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060010CA.Author5.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060090CA.Author5.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt090108ca.HealthcareWorker AuthorAssignedEntity {
            get { return this.authorAssignedEntity; }
            set { this.authorAssignedEntity = value; }
        }

    }

}