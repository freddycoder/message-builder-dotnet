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
namespace Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Pome_mt010090ca;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>POME_MT010050CA.ParameterList: Generic Query 
     * Parameters</summary>
     * 
     * <p>One and only one of Drug Code, Prescribing Indication 
     * Code, or Medication Document ID must be specified.</p> 
     * <p>Defines the set of parameters that may be used to filter 
     * the query response.</p> <p>Root class for query 
     * parameters.</p> POME_MT010030CA.ParameterList: Drug Query 
     * Parameters <p>Defines the set of parameters that may be used 
     * to filter the query response.</p> <p>Root class for query 
     * parameters</p> POME_MT010090CA.ParameterList: Drug Query 
     * Parameters <p>At least one of drug code or drug name must be 
     * specified</p> <p>Defines the set of parameters that may be 
     * used to filter the query response.</p> <p>Root class for 
     * query parameters</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POME_MT010030CA.ParameterList","POME_MT010050CA.ParameterList","POME_MT010090CA.ParameterList"})]
    public class DrugQueryParameters : MessagePartBean {

        private CV drugCodeValue;
        private II medicationDocumentIDValue;
        private CV medicationDocumentTypeValue;
        private CV prescribingDiagnosisCodeValue;
        private CV prescribingSymptomCodeValue;
        private IList<Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Pome_mt010090ca.HasCharacteristic> drugCharacteristics;
        private CV drugFormValue;
        private ST drugManufacturerNameValue;
        private ST drugNameValue;
        private CV drugRouteValue;

        public DrugQueryParameters() {
            this.drugCodeValue = new CVImpl();
            this.medicationDocumentIDValue = new IIImpl();
            this.medicationDocumentTypeValue = new CVImpl();
            this.prescribingDiagnosisCodeValue = new CVImpl();
            this.prescribingSymptomCodeValue = new CVImpl();
            this.drugCharacteristics = new List<Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Pome_mt010090ca.HasCharacteristic>();
            this.drugFormValue = new CVImpl();
            this.drugManufacturerNameValue = new STImpl();
            this.drugNameValue = new STImpl();
            this.drugRouteValue = new CVImpl();
        }
        /**
         * <summary>Business Name: DrugCode</summary>
         * 
         * <remarks>Un-merged Business Name: DrugCode Relationship: 
         * POME_MT010050CA.DrugCode.value Conformance/Cardinality: 
         * MANDATORY (1) <p>An identifier for a type of drug. Types of 
         * drugs include: Manufactured drug, generic formulation, 
         * generic, therapeutic class, etc.</p> <p>Allows the requester 
         * to retrieve drugs of certain abstraction only. These drug 
         * abstractions include: Manufactured drug, generic 
         * formulation, generic, therapeutic class, etc.</p> Un-merged 
         * Business Name: DrugCode Relationship: 
         * POME_MT010030CA.DrugCode.value Conformance/Cardinality: 
         * MANDATORY (1) <p>An identifier for a specific drug product. 
         * Types of drugs identified by drug code include: Manufactured 
         * drug, generic formulation, generic, therapeutic class, 
         * etc.</p> <p>Allows the requester to retrieve detail 
         * information about a specific drug product.</p> Un-merged 
         * Business Name: DrugCode Relationship: 
         * POME_MT010090CA.DrugCode.value Conformance/Cardinality: 
         * MANDATORY (1) <p>An identifier that describes a drug at any 
         * level of the clinical drug hierarchy. The code may describe 
         * (point to) a Manufactured drug, generic drug formulation, 
         * generic drug, therapeutic classification, etc.</p><p>For 
         * example, using a therapeutic class code in the DrugCode 
         * parameter would return a list of all drugs that are within 
         * that class. Sending a drug name in the DrugName parameter 
         * would return a list of all drugs that have that name e.g. 
         * sending acetaminophen would return all of the acetaminophen 
         * products in the drug data base. By including the DoseForm, 
         * DoseRoute, DrugManufacturerName or DrugCharacteristic, the 
         * list could be further constrained.</p> <p>An identifier that 
         * describes a drug at any level of the clinical drug 
         * hierarchy. The code may describe (point to) a Manufactured 
         * drug, generic drug formulation, generic drug, therapeutic 
         * classification, etc.</p><p>For example, using a therapeutic 
         * class code in the DrugCode parameter would return a list of 
         * all drugs that are within that class. Sending a drug name in 
         * the DrugName parameter would return a list of all drugs that 
         * have that name e.g. sending acetaminophen would return all 
         * of the acetaminophen products in the drug data base. By 
         * including the DoseForm, DoseRoute, DrugManufacturerName or 
         * DrugCharacteristic, the list could be further 
         * constrained.</p> <p>Allows the requester to retrieve drugs 
         * of certain abstraction only. These drug abstractions 
         * include: Manufactured drug, generic formulation, generic, 
         * therapeutic class, etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"drugCode/value"})]
        public ClinicalDrug DrugCodeValue {
            get { return (ClinicalDrug) this.drugCodeValue.Value; }
            set { this.drugCodeValue.Value = value; }
        }

        /**
         * <summary>Business Name: MedicationDocumentID</summary>
         * 
         * <remarks>Un-merged Business Name: MedicationDocumentID 
         * Relationship: POME_MT010050CA.MedicationDocumentID.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Unique identifier 
         * for a particular medication document. This will reference a 
         * specific kind of documentation (e.g. DDI Monograph, Patient 
         * Education Monograph, Allergy Monograph, etc) created by a 
         * specific author organization (e.g. Health Canada, FDB, WHO, 
         * etc).</p> <p>Use of an identifier allows for a quick 
         * retrieval of the information of interest.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"medicationDocumentID/value"})]
        public Identifier MedicationDocumentIDValue {
            get { return this.medicationDocumentIDValue.Value; }
            set { this.medicationDocumentIDValue.Value = value; }
        }

        /**
         * <summary>Business Name: MedicationDocumentType</summary>
         * 
         * <remarks>Un-merged Business Name: MedicationDocumentType 
         * Relationship: POME_MT010050CA.MedicationDocumentType.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates that the 
         * result set is to be filtered to include only those 
         * medication documents pertaining to the specified document 
         * category.</p><p>Valid medication document categories 
         * include: Drug Monograph, Contraindication Monograph, 
         * Indication Protocol, etc.</p> <p>Indicates that the result 
         * set is to be filtered to include only those medication 
         * documents pertaining to the specified document 
         * category.</p><p>Valid medication document categories 
         * include: Drug Monograph, Contraindication Monograph, 
         * Indication Protocol, etc.</p> <p>Allows for the retrieval of 
         * all medication documents pertaining to a specific document 
         * category.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"medicationDocumentType/value"})]
        public ActMedicationDocumentCode MedicationDocumentTypeValue {
            get { return (ActMedicationDocumentCode) this.medicationDocumentTypeValue.Value; }
            set { this.medicationDocumentTypeValue.Value = value; }
        }

        /**
         * <summary>Business Name: PrescribingIndicationDiagnosisCode</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * PrescribingIndicationDiagnosisCode Relationship: 
         * POME_MT010050CA.PrescribingDiagnosisCode.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Returns documents 
         * which relate to a particular diagnosis</p> <p>Useful for 
         * finding protocols and drug monographs associated with an 
         * indication</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"prescribingDiagnosisCode/value"})]
        public DiagnosisValue PrescribingDiagnosisCodeValue {
            get { return (DiagnosisValue) this.prescribingDiagnosisCodeValue.Value; }
            set { this.prescribingDiagnosisCodeValue.Value = value; }
        }

        /**
         * <summary>Business Name: PrescribingIndicationSymptomCode</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * PrescribingIndicationSymptomCode Relationship: 
         * POME_MT010050CA.PrescribingSymptomCode.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Returns documents 
         * which relate to a particular symptom</p> <p>Useful for 
         * finding protocols and drug monographs associated with an 
         * indication</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"prescribingSymptomCode/value"})]
        public SymptomValue PrescribingSymptomCodeValue {
            get { return (SymptomValue) this.prescribingSymptomCodeValue.Value; }
            set { this.prescribingSymptomCodeValue.Value = value; }
        }

        /**
         * <summary>Business Name: HasCharacteristic</summary>
         * 
         * <remarks>Un-merged Business Name: HasCharacteristic 
         * Relationship: 
         * POME_MT010090CA.ParameterList.drugCharacteristics 
         * Conformance/Cardinality: REQUIRED (0-5) <p>&nbsp;Filters 
         * medications by their appearance.</p> <div>&nbsp;</div> 
         * <div>PIN does not contain drug characteristic</div> 
         * <div>information so if this field is specified, then a</div> 
         * <div>warning will be returned indicating that it is 
         * not</div> <p>used in the search.&nbsp;</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"drugCharacteristics"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Pome_mt010090ca.HasCharacteristic> DrugCharacteristics {
            get { return this.drugCharacteristics; }
        }

        /**
         * <summary>Business Name: OrderableDrugForm</summary>
         * 
         * <remarks>Un-merged Business Name: OrderableDrugForm 
         * Relationship: POME_MT010090CA.DrugForm.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates the form 
         * in which the drug product must is manufactured.</p> 
         * <p>Useful filter for searching drugs. Allows the requester 
         * to specify the drug form of interest for the retrieval.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"drugForm/value"})]
        public FDBDrugRoute DrugFormValue {
            get { return (FDBDrugRoute) this.drugFormValue.Value; }
            set { this.drugFormValue.Value = value; }
        }

        /**
         * <summary>Business Name: DrugManufacturerName</summary>
         * 
         * <remarks>Un-merged Business Name: DrugManufacturerName 
         * Relationship: POME_MT010090CA.DrugManufacturerName.value 
         * Conformance/Cardinality: MANDATORY (1) <p>The name of a drug 
         * manufacturer.</p> <p>Allows for the retrieval of drug 
         * products based on the manufacturer.</p> <p>Manufacturer name 
         * search will be 'Starts with...' type of a search.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"drugManufacturerName/value"})]
        public String DrugManufacturerNameValue {
            get { return this.drugManufacturerNameValue.Value; }
            set { this.drugManufacturerNameValue.Value = value; }
        }

        /**
         * <summary>Business Name: DrugName</summary>
         * 
         * <remarks>Un-merged Business Name: DrugName Relationship: 
         * POME_MT010090CA.DrugName.value Conformance/Cardinality: 
         * MANDATORY (1) <p>The name assigned to a drug.</p> <p>Name 
         * may be the only identification of a drug known by many 
         * prescribers.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"drugName/value"})]
        public String DrugNameValue {
            get { return this.drugNameValue.Value; }
            set { this.drugNameValue.Value = value; }
        }

        /**
         * <summary>Business Name: DrugRouteCode</summary>
         * 
         * <remarks>Un-merged Business Name: DrugRouteCode 
         * Relationship: POME_MT010090CA.DrugRoute.value 
         * Conformance/Cardinality: MANDATORY (1) <p>A filter based on 
         * how the drug should be introduced into the patient's body 
         * (e.g. Oral, topical, etc.)</p> <p>Allows limiting the 
         * returned list of drugs to a single route.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"drugRoute/value"})]
        public RouteOfAdministration DrugRouteValue {
            get { return (RouteOfAdministration) this.drugRouteValue.Value; }
            set { this.drugRouteValue.Value = value; }
        }

    }

}