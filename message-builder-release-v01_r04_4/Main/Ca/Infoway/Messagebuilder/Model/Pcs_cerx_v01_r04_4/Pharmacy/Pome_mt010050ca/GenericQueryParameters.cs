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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Pome_mt010050ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>Business Name: Generic Query Parameters</summary>
     * 
     * <p>One and only one of Drug Code, Prescribing Indication 
     * Code, or Medication Document ID must be specified.</p> 
     * <p>Root class for query parameters.</p> <p>Defines the set 
     * of parameters that may be used to filter the query 
     * response.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POME_MT010050CA.ParameterList"})]
    public class GenericQueryParameters : MessagePartBean {

        private CV drugCodeValue;
        private II medicationDocumentIDValue;
        private CV medicationDocumentTypeValue;
        private CV prescribingDiagnosisCodeValue;
        private CV prescribingSymptomCodeValue;

        public GenericQueryParameters() {
            this.drugCodeValue = new CVImpl();
            this.medicationDocumentIDValue = new IIImpl();
            this.medicationDocumentTypeValue = new CVImpl();
            this.prescribingDiagnosisCodeValue = new CVImpl();
            this.prescribingSymptomCodeValue = new CVImpl();
        }
        /**
         * <summary>Business Name: B:Drug Code</summary>
         * 
         * <remarks>Relationship: POME_MT010050CA.DrugCode.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows the 
         * requester to retrieve drugs of certain abstraction only. 
         * These drug abstractions include: Manufactured drug, generic 
         * formulation, generic, therapeutic class, etc.</p> <p>An 
         * identifier for a type of drug. Types of drugs include: 
         * Manufactured drug, generic formulation, generic, therapeutic 
         * class, etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"drugCode/value"})]
        public ClinicalDrug DrugCodeValue {
            get { return (ClinicalDrug) this.drugCodeValue.Value; }
            set { this.drugCodeValue.Value = value; }
        }

        /**
         * <summary>Business Name: E:Medication Document ID</summary>
         * 
         * <remarks>Relationship: 
         * POME_MT010050CA.MedicationDocumentID.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Use of an 
         * identifier allows for a quick retrieval of the information 
         * of interest.</p> <p>Unique identifier for a particular 
         * medication document. This will reference a specific kind of 
         * documentation (e.g. DDI Monograph, Patient Education 
         * Monograph, Allergy Monograph, etc) created by a specific 
         * author organization (e.g. Health Canada, FDB, WHO, etc).</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"medicationDocumentID/value"})]
        public Identifier MedicationDocumentIDValue {
            get { return this.medicationDocumentIDValue.Value; }
            set { this.medicationDocumentIDValue.Value = value; }
        }

        /**
         * <summary>Business Name: D:Medication Document Type</summary>
         * 
         * <remarks>Relationship: 
         * POME_MT010050CA.MedicationDocumentType.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for the 
         * retrieval of all medication documents pertaining to a 
         * specific document category.</p> <p>Indicates that the result 
         * set is to be filtered to include only those medication 
         * documents pertaining to the specified document 
         * category.</p><p>Valid medication document categories 
         * include: Drug Monograph, Contraindication Monograph, 
         * Indication Protocol, etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"medicationDocumentType/value"})]
        public ActMedicationDocumentCode MedicationDocumentTypeValue {
            get { return (ActMedicationDocumentCode) this.medicationDocumentTypeValue.Value; }
            set { this.medicationDocumentTypeValue.Value = value; }
        }

        /**
         * <summary>Business Name: C:Prescribing Indication Diagnosis 
         * Code</summary>
         * 
         * <remarks>Relationship: 
         * POME_MT010050CA.PrescribingDiagnosisCode.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Useful for finding 
         * protocols and drug monographs associated with an 
         * indication</p> <p>Returns documents which relate to a 
         * particular diagnosis</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"prescribingDiagnosisCode/value"})]
        public DiagnosisValue PrescribingDiagnosisCodeValue {
            get { return (DiagnosisValue) this.prescribingDiagnosisCodeValue.Value; }
            set { this.prescribingDiagnosisCodeValue.Value = value; }
        }

        /**
         * <summary>Business Name: Prescribing Indication Symptom Code</summary>
         * 
         * <remarks>Relationship: 
         * POME_MT010050CA.PrescribingSymptomCode.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Useful for finding 
         * protocols and drug monographs associated with an 
         * indication</p> <p>Returns documents which relate to a 
         * particular symptom</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"prescribingSymptomCode/value"})]
        public SymptomValue PrescribingSymptomCodeValue {
            get { return (SymptomValue) this.prescribingSymptomCodeValue.Value; }
            set { this.prescribingSymptomCodeValue.Value = value; }
        }

    }

}