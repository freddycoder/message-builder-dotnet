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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>Business Name: Exposures</summary>
     * 
     * <remarks>REPC_MT000005CA.ExposureEvent: Exposures 
     * <p>Communicates the cause of the adverse reaction.</p> 
     * <p>Incidence of the patient's exposure to (or contact with) 
     * with some material that might have caused the adverse 
     * reaction.</p><p>Examples of exposures include: Administering 
     * a substance (drug, food, etc) to the patient, Patient coming 
     * into contact with an environmental material, etc.</p> 
     * REPC_MT000006CA.ExposureEvent: Exposures <p>Communicates the 
     * cause of the adverse reaction.</p> <p>Incidence of the 
     * patient's exposure to (or contact with) with some material 
     * that might have caused the adverse reaction.</p><p>Examples 
     * of exposures include: Administering a substance (drug, food, 
     * etc) to the patient, Patient coming into contact with an 
     * environmental material, etc.</p> 
     * REPC_MT000001CA.ExposureEvent: Exposures <p>Communicates the 
     * cause of the adverse reaction.</p> <p>Incidence of the 
     * patient's exposure to (or contact with) with some material 
     * that might have caused the adverse reaction.</p><p>Examples 
     * of exposures include: Administering a substance (drug, food, 
     * etc) to the patient, Patient coming into contact with an 
     * environmental material, etc.</p> 
     * REPC_MT000012CA.ExposureEvent: Exposures <p>Communicates the 
     * cause of the adverse reaction.</p> <p>Incidence of the 
     * patient's exposure to (or contact with) with some material 
     * that might have caused the adverse reaction.</p><p>Examples 
     * of exposures include: Administering a substance (drug, food, 
     * etc) to the patient, Patient coming into contact with an 
     * environmental material, etc.</p> 
     * REPC_MT000009CA.ExposureEvent: Exposures <p>Communicates the 
     * cause of the adverse reaction.</p> <p>Incidence of the 
     * patient's exposure to (or contact with) with some material 
     * that might have caused the adverse reaction.</p><p>Examples 
     * of exposures include: Administering a substance (drug, food, 
     * etc) to the patient, Patient coming into contact with an 
     * environmental material, etc.</p> 
     * REPC_MT000013CA.ExposureEvent: Exposures <p>Communicates the 
     * cause of the adverse reaction.</p> <p>Incidence of the 
     * patient's exposure to (or contact with) with some material 
     * that might have caused the adverse reaction.</p><p>Examples 
     * of exposures include: Administering a substance (drug, food, 
     * etc) to the patient, Patient coming into contact with an 
     * environmental material, etc.</p> 
     * REPC_MT000002CA.ExposureEvent: Exposures <p>Communicates the 
     * cause of the adverse reaction.</p> <p>Incidence of the 
     * patient's exposure to (or contact with) with some material 
     * that might have caused the adverse reaction.</p><p>Examples 
     * of exposures include: Administering a substance (drug, food, 
     * etc) to the patient, Patient coming into contact with an 
     * environmental material, etc.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT000001CA.ExposureEvent","REPC_MT000002CA.ExposureEvent","REPC_MT000005CA.ExposureEvent","REPC_MT000006CA.ExposureEvent","REPC_MT000009CA.ExposureEvent","REPC_MT000012CA.ExposureEvent","REPC_MT000013CA.ExposureEvent"})]
    public class Exposures : MessagePartBean {

        private II id;
        private CV routeCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.AgentCategory consumableAdministrableMaterialAdministerableMaterialKind;

        public Exposures() {
            this.id = new IIImpl();
            this.routeCode = new CVImpl();
        }
        /**
         * <summary>Business Name: IncidenceIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: IncidenceIdentifier 
         * Relationship: REPC_MT000005CA.ExposureEvent.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows for 
         * drilling down to retrieve further information about the 
         * exposure</p> <p>Identifier of the exposure event that caused 
         * the adverse reaction. This could be an identifier for a 
         * prescription, immunization, or other active medication 
         * record.</p> Un-merged Business Name: IncidenceIdentifier 
         * Relationship: REPC_MT000006CA.ExposureEvent.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows for 
         * drilling down to retrieve further information about the 
         * exposure</p> <p>Identifier of the exposure event that caused 
         * the adverse reaction. This could be an identifier for a 
         * prescription, immunization, or other active medication 
         * record.</p> Un-merged Business Name: IncidenceIdentifier 
         * Relationship: REPC_MT000001CA.ExposureEvent.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows for 
         * drilling down to retrieve further information about the 
         * exposure</p> <p>Identifier of the record or order that 
         * caused the reaction. This could be an identifier for a 
         * prescription, immunization, or other active medication 
         * record.</p> Un-merged Business Name: IncidenceIdentifier 
         * Relationship: REPC_MT000009CA.ExposureEvent.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows for 
         * drilling down to retrieve further information about the 
         * exposure</p> <p>Identifier of the exposure event that caused 
         * the adverse reaction. This could be an identifier for a 
         * prescription, immunization, or other active medication 
         * record.</p> Un-merged Business Name: IncidenceIdentifier 
         * Relationship: REPC_MT000012CA.ExposureEvent.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows for 
         * drilling down to retrieve further information about the 
         * exposure</p> <p>Identifier of the exposure event that caused 
         * the adverse reaction. This could be an identifier for a 
         * prescription, immunization, or other active medication 
         * record.</p> Un-merged Business Name: IncidenceIdentifier 
         * Relationship: REPC_MT000013CA.ExposureEvent.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows for 
         * drilling down to retrieve further information about the 
         * exposure</p> <p>Identifier of the exposure event that caused 
         * the adverse reaction. This could be an identifier for a 
         * prescription, immunization, or other active medication 
         * record.</p> Un-merged Business Name: IncidenceIdentifier 
         * Relationship: REPC_MT000002CA.ExposureEvent.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows for 
         * drilling down to retrieve further information about the 
         * exposure</p> <p>Identifier of the exposure event that caused 
         * the adverse reaction. This could be an identifier for a 
         * prescription, immunization, or other active medication 
         * record.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: ExposureMethod</summary>
         * 
         * <remarks>Un-merged Business Name: ExposureMethod 
         * Relationship: REPC_MT000005CA.ExposureEvent.routeCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Helps evaluate 
         * the cause of the reaction.</p> <p>The method by which the 
         * patient was exposed to the substance.</p> Un-merged Business 
         * Name: ExposureMethod Relationship: 
         * REPC_MT000006CA.ExposureEvent.routeCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Helps evaluate 
         * the cause of the reaction.</p> <p>The method by which the 
         * patient was exposed to the substance.</p> Un-merged Business 
         * Name: ExposureMethod Relationship: 
         * REPC_MT000001CA.ExposureEvent.routeCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Helps evaluate 
         * the cause of the reaction.</p> <p>The method by which the 
         * patient was exposed to the substance.</p> Un-merged Business 
         * Name: ExposureMethod Relationship: 
         * REPC_MT000009CA.ExposureEvent.routeCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Helps evaluate 
         * the cause of the reaction.</p> <p>The method by which the 
         * patient was exposed to the substance.</p> Un-merged Business 
         * Name: ExposureMethod Relationship: 
         * REPC_MT000012CA.ExposureEvent.routeCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Helps evaluate 
         * the cause of the reaction.</p> <p>The method by which the 
         * patient was exposed to the substance.</p> Un-merged Business 
         * Name: ExposureMethod Relationship: 
         * REPC_MT000013CA.ExposureEvent.routeCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Helps evaluate 
         * the cause of the reaction.</p> <p>The method by which the 
         * patient was exposed to the substance.</p> Un-merged Business 
         * Name: ExposureMethod Relationship: 
         * REPC_MT000002CA.ExposureEvent.routeCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Helps evaluate 
         * the cause of the reaction.</p> <p>The method by which the 
         * patient was exposed to the substance.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"routeCode"})]
        public RouteOfAdministration RouteCode {
            get { return (RouteOfAdministration) this.routeCode.Value; }
            set { this.routeCode.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000005CA.AdministrableMaterial.administerableMaterialKind 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000006CA.AdministrableMaterial.administerableMaterialKind 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000001CA.AdministrableMaterial.administerableMaterialKind 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000009CA.AdministerableMaterial.administerableMaterialKind 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000012CA.AdministerableMaterial.administerableMaterialKind 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000013CA.AdministrableMaterial.administerableMaterialKind 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000002CA.AdministrableMaterial.administerableMaterialKind 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"consumable/administerableMaterial/administerableMaterialKind","consumable/administrableMaterial/administerableMaterialKind"})]
        [Hl7MapByPartType(Name="consumable", Type="REPC_MT000001CA.Consumable")]
        [Hl7MapByPartType(Name="consumable", Type="REPC_MT000002CA.Consumable")]
        [Hl7MapByPartType(Name="consumable", Type="REPC_MT000005CA.Consumable")]
        [Hl7MapByPartType(Name="consumable", Type="REPC_MT000006CA.Consumable")]
        [Hl7MapByPartType(Name="consumable", Type="REPC_MT000009CA.Consumable")]
        [Hl7MapByPartType(Name="consumable", Type="REPC_MT000012CA.Consumable")]
        [Hl7MapByPartType(Name="consumable", Type="REPC_MT000013CA.Consumable")]
        [Hl7MapByPartType(Name="consumable/administerableMaterial", Type="REPC_MT000009CA.AdministerableMaterial")]
        [Hl7MapByPartType(Name="consumable/administerableMaterial", Type="REPC_MT000012CA.AdministerableMaterial")]
        [Hl7MapByPartType(Name="consumable/administerableMaterial/administerableMaterialKind", Type="REPC_MT000009CA.MaterialKind")]
        [Hl7MapByPartType(Name="consumable/administerableMaterial/administerableMaterialKind", Type="REPC_MT000012CA.MaterialKind")]
        [Hl7MapByPartType(Name="consumable/administrableMaterial", Type="REPC_MT000001CA.AdministrableMaterial")]
        [Hl7MapByPartType(Name="consumable/administrableMaterial", Type="REPC_MT000002CA.AdministrableMaterial")]
        [Hl7MapByPartType(Name="consumable/administrableMaterial", Type="REPC_MT000005CA.AdministrableMaterial")]
        [Hl7MapByPartType(Name="consumable/administrableMaterial", Type="REPC_MT000006CA.AdministrableMaterial")]
        [Hl7MapByPartType(Name="consumable/administrableMaterial", Type="REPC_MT000013CA.AdministrableMaterial")]
        [Hl7MapByPartType(Name="consumable/administrableMaterial/administerableMaterialKind", Type="REPC_MT000001CA.MaterialKind")]
        [Hl7MapByPartType(Name="consumable/administrableMaterial/administerableMaterialKind", Type="REPC_MT000002CA.MaterialKind")]
        [Hl7MapByPartType(Name="consumable/administrableMaterial/administerableMaterialKind", Type="REPC_MT000005CA.MaterialKind")]
        [Hl7MapByPartType(Name="consumable/administrableMaterial/administerableMaterialKind", Type="REPC_MT000006CA.MaterialKind")]
        [Hl7MapByPartType(Name="consumable/administrableMaterial/administerableMaterialKind", Type="REPC_MT000013CA.MaterialKind")]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged.AgentCategory ConsumableAdministrableMaterialAdministerableMaterialKind {
            get { return this.consumableAdministrableMaterialAdministerableMaterialKind; }
            set { this.consumableAdministrableMaterialAdministerableMaterialKind = value; }
        }

    }

}