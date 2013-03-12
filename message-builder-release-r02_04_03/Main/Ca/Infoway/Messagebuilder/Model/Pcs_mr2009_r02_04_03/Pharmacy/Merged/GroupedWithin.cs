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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Pharmacy.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: GroupedWithin</summary>
     * 
     * <remarks>POME_MT010040CA.SpecializedKind: grouped within 
     * <p>Exposes the drug hierarchy, allowing drill-down when 
     * prescribing and dispensing. Also indicates possibilities for 
     * substitution and can be important for detecting interactions 
     * such as allergies or duplicate therapy between 
     * closely-related drugs.</p> <p>Indicates the location of a 
     * medication in a particular abstract hierarchy. For example, 
     * what generic, generic formulation, or therapeutic class does 
     * the medication fall into.</p> 
     * POME_MT010100CA.SpecializedKind: grouped within <p>Exposes 
     * the drug hierarchy, allowing drill-down when prescribing and 
     * dispensing. Also indicates possibilities for substitution 
     * and can be important for detecting interactions such as 
     * allergies or duplicate therapy between closely-related 
     * drugs.</p> <p>Indicates the location of a medication in a 
     * particular abstract hierarchy. For example, what generic, 
     * generic formulation, or therapeutic class does the 
     * medication fall into.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POME_MT010040CA.SpecializedKind","POME_MT010100CA.SpecializedKind"})]
    public class GroupedWithin : MessagePartBean {

        private CV code;
        private CV generalizedMedicineClassCode;
        private ST generalizedMedicineClassName;

        public GroupedWithin() {
            this.code = new CVImpl();
            this.generalizedMedicineClassCode = new CVImpl();
            this.generalizedMedicineClassName = new STImpl();
        }
        /**
         * <summary>Business Name: DrugCategoryCode</summary>
         * 
         * <remarks>Un-merged Business Name: DrugCategoryCode 
         * Relationship: POME_MT010040CA.SpecializedKind.code 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Describes the 
         * relationship between two levels of drug products (e.g. Drug 
         * A is the generic for Drug B)</p> <p>A coded value denoting a 
         * specific level in the hierarchical definition of drugs.</p> 
         * Un-merged Business Name: DrugCategoryCode Relationship: 
         * POME_MT010100CA.SpecializedKind.code 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Describes the 
         * relationship between two levels of drug products (e.g. Drug 
         * A is the generic for Drug B)</p> <p>A coded value denoting a 
         * specific level in the hierarchical definition of drugs.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public MedicationGeneralizationRoleType Code {
            get { return (MedicationGeneralizationRoleType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: DrugCode</summary>
         * 
         * <remarks>Un-merged Business Name: DrugCode Relationship: 
         * POME_MT010040CA.MedicineClass.code Conformance/Cardinality: 
         * POPULATED (1) <p>Used to uniquely identify a particular drug 
         * product when prescribing/dispensing at a higher level of 
         * abstraction (e.g. generic drug, generic 
         * formulation).</p><p>This attribute is marked as 
         * &quot;populated&quot; as drug code should be available in 
         * most cases.</p> <p>A code that uniquely identifiers a drug 
         * within a specific drug identification scheme.</p> Un-merged 
         * Business Name: DrugCode Relationship: 
         * POME_MT010100CA.MedicineClass.code Conformance/Cardinality: 
         * POPULATED (1) <p>Used to uniquely identify a particular drug 
         * product when prescribing/dispensing at a higher level of 
         * abstraction (e.g. generic drug, generic 
         * formulation).</p><p>This attribute is marked as 
         * &quot;populated&quot; as a drug code should be available in 
         * most cases.</p> <p>An identifier for a drug at a higher 
         * level of abstraction.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"generalizedMedicineClass/code"})]
        public ClinicalDrug GeneralizedMedicineClassCode {
            get { return (ClinicalDrug) this.generalizedMedicineClassCode.Value; }
            set { this.generalizedMedicineClassCode.Value = value; }
        }

        /**
         * <summary>Business Name: DrugName</summary>
         * 
         * <remarks>Un-merged Business Name: DrugName Relationship: 
         * POME_MT010040CA.MedicineClass.name Conformance/Cardinality: 
         * POPULATED (1) <p>To display in dropdowns and for local 
         * searching.</p><p>This attribute is marked as 
         * &quot;populated&quot; as a drug name should be available in 
         * most cases.</p> <p>The name assigned to a drug within a 
         * specific drug identification scheme.</p> Un-merged Business 
         * Name: DrugName Relationship: 
         * POME_MT010100CA.MedicineClass.name Conformance/Cardinality: 
         * POPULATED (1) <p>To display in dropdowns and for local 
         * searching.</p><p>This attribute is marked as 
         * &quot;populated&quot; as drug name should be available in 
         * most cases.</p> <p>The name assigned to the drug at the 
         * higher level of abstraction.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"generalizedMedicineClass/name"})]
        public String GeneralizedMedicineClassName {
            get { return this.generalizedMedicineClassName.Value; }
            set { this.generalizedMedicineClassName.Value = value; }
        }

    }

}