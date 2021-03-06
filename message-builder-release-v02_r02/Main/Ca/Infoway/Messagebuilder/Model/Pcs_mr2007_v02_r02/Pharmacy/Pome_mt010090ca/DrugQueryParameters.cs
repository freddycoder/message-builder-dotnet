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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pharmacy.Pome_mt010090ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Drug Query Parameters</summary>
     * 
     * <p>At least one of drug code or drug name must be 
     * specified</p> <p>Root class for query parameters</p> 
     * <p>Defines the set of parameters that may be used to filter 
     * the query response.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POME_MT010090CA.ParameterList"})]
    public class DrugQueryParameters : MessagePartBean {

        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pharmacy.Pome_mt010090ca.HasCharacteristic> drugCharacteristics;
        private CV drugCodeValue;
        private CV drugFormValue;
        private ST drugManufacturerNameValue;
        private ST drugNameValue;
        private CV drugRouteValue;

        public DrugQueryParameters() {
            this.drugCharacteristics = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pharmacy.Pome_mt010090ca.HasCharacteristic>();
            this.drugCodeValue = new CVImpl();
            this.drugFormValue = new CVImpl();
            this.drugManufacturerNameValue = new STImpl();
            this.drugNameValue = new STImpl();
            this.drugRouteValue = new CVImpl();
        }
        /**
         * <summary>Relationship: 
         * POME_MT010090CA.ParameterList.drugCharacteristics</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-5)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"drugCharacteristics"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pharmacy.Pome_mt010090ca.HasCharacteristic> DrugCharacteristics {
            get { return this.drugCharacteristics; }
        }

        /**
         * <summary>Business Name: B:Drug Code</summary>
         * 
         * <remarks>Relationship: POME_MT010090CA.DrugCode.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows the 
         * requester to retrieve drugs of certain abstraction only. 
         * These drug abstractions include: Manufactured drug, generic 
         * formulation, generic, therapeutic class, etc.</p> <p>An 
         * identifier that describes a drug at any level of the 
         * clinical drug hierarchy. The code may describe (point to) a 
         * Manufactured drug, generic drug formulation, generic drug, 
         * therapeutic classification, etc.</p><p>For example, using a 
         * therapeutic class code in the DrugCode parameter would 
         * return a list of all drugs that are within that class. 
         * Sending a drug name in the DrugName parameter would return a 
         * list of all drugs that have that name e.g. sending 
         * acetaminophen would return all of the acetaminophen products 
         * in the drug data base. By including the DoseForm, DoseRoute, 
         * DrugManufacturerName or DrugCharacteristic, the list could 
         * be further constrained.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"drugCode/value"})]
        public ClinicalDrug DrugCodeValue {
            get { return (ClinicalDrug) this.drugCodeValue.Value; }
            set { this.drugCodeValue.Value = value; }
        }

        /**
         * <summary>Business Name: D:Orderable Drug Form</summary>
         * 
         * <remarks>Relationship: POME_MT010090CA.DrugForm.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Useful filter for 
         * searching drugs. Allows the requester to specify the drug 
         * form of interest for the retrieval.</p> <p>Indicates the 
         * form in which the drug product must is manufactured.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"drugForm/value"})]
        public OrderableDrugForm DrugFormValue {
            get { return (OrderableDrugForm) this.drugFormValue.Value; }
            set { this.drugFormValue.Value = value; }
        }

        /**
         * <summary>Business Name: F:Drug Manufacturer Name</summary>
         * 
         * <remarks>Relationship: 
         * POME_MT010090CA.DrugManufacturerName.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for the 
         * retrieval of drug products based on the manufacturer.</p> 
         * <p>Manufacturer name search will be 'Starts with...' type of 
         * a search.</p> <p>The name of a drug manufacturer.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"drugManufacturerName/value"})]
        public String DrugManufacturerNameValue {
            get { return this.drugManufacturerNameValue.Value; }
            set { this.drugManufacturerNameValue.Value = value; }
        }

        /**
         * <summary>Business Name: C:Drug Name</summary>
         * 
         * <remarks>Relationship: POME_MT010090CA.DrugName.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Name may be the 
         * only identification of a drug known by many prescribers.</p> 
         * <p>The name assigned to a drug.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"drugName/value"})]
        public String DrugNameValue {
            get { return this.drugNameValue.Value; }
            set { this.drugNameValue.Value = value; }
        }

        /**
         * <summary>Business Name: E:Drug Route Code</summary>
         * 
         * <remarks>Relationship: POME_MT010090CA.DrugRoute.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows limiting 
         * the returned list of drugs to a single route.</p> <p>A 
         * filter based on how the drug should be introduced into the 
         * patient's body (e.g. Oral, topical, etc.)</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"drugRoute/value"})]
        public RouteOfAdministration DrugRouteValue {
            get { return (RouteOfAdministration) this.drugRouteValue.Value; }
            set { this.drugRouteValue.Value = value; }
        }

    }

}