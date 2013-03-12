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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>POME_MT010100CA.Content: dispensed in</summary>
     * 
     * <p>A_BillablePharmacyDispense</p> <p>May influence 
     * prescribing quantities, and also allows conveying 
     * instructions with respect to special packaging such as 
     * compliance packaging.</p> <p>Information about how the 
     * dispensed drug is or should be contained</p> 
     * COCT_MT220200CA.Content: drug dispensed in <p>Must specify 
     * at least one of Drug Package quantity and Drug Container 
     * Type.</p> <p>A_BillablePharmacyDispense</p> <p>May influence 
     * prescribing quantities, and also allows conveying 
     * instructions with respect to special packaging such as 
     * compliance packaging.</p> <p>Information about how the 
     * dispensed drug is or should be contained</p> 
     * POME_MT010040CA.Content: dispensed in 
     * <p>A_BillablePharmacyDispense</p> <p>May influence 
     * prescribing quantities, and also allows conveying 
     * instructions with respect to special packaging such as 
     * compliance packaging.</p> <p>Information about how the 
     * dispensed drug is or should be contained</p> 
     * COCT_MT220210CA.Content: drug dispensed in <p>Must specify 
     * at least one of Drug Package quantity and Drug Container 
     * Type.</p> <p>A_BillablePharmacyDispense</p> <p>May influence 
     * prescribing quantities, and also allows conveying 
     * instructions with respect to special packaging such as 
     * compliance packaging.</p> <p>Information about how the 
     * dispensed drug is or should be contained</p> 
     * COCT_MT220110CA.Content: dispensed in <p>Must specify at 
     * least one of Drug Package quantity and Drug Container 
     * Type;</p> <p>A_BillablePharmacyDispense</p> <p>May influence 
     * prescribing quantities, and also allows conveying 
     * instructions with respect to special packaging such as 
     * compliance packaging.</p> <p>Information about how the 
     * dispensed drug is or should be contained</p> 
     * COCT_MT220100CA.Content: dispensed in <p>Must specify at 
     * least one of Drug Package quantity and Drug Container 
     * Type</p> <p>A_BillablePharmacyDispense</p> <p>May influence 
     * prescribing quantities, and also allows conveying 
     * instructions with respect to special packaging such as 
     * compliance packaging.</p> <p>Information about how the 
     * dispensed drug is or should be contained</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT220100CA.Content","COCT_MT220110CA.Content","COCT_MT220200CA.Content","COCT_MT220210CA.Content","POME_MT010040CA.Content","POME_MT010100CA.Content"})]
    public class DispensedIn : MessagePartBean {

        private PQ quantity;
        private CV containerPackagedMedicineFormCode;

        public DispensedIn() {
            this.quantity = new PQImpl();
            this.containerPackagedMedicineFormCode = new CVImpl();
        }
        /**
         * <summary>Un-merged Business Name: DrugPackageQuantity</summary>
         * 
         * <remarks>Relationship: COCT_MT220200CA.Content.quantity 
         * Conformance/Cardinality: REQUIRED (0-1) <p>ZDP.10.2.2</p> 
         * <p>ZDP.9.2.2</p> <p>Sometimes ordering and dispensing is by 
         * package rather than individual units, and package is 
         * important in calculating total amount supplied.</p> <p>The 
         * quantity of the medication dosage form contained in the 
         * package given or to be given to the patient.</p> Un-merged 
         * Business Name: PackageQuantity Relationship: 
         * POME_MT010100CA.Content.quantity Conformance/Cardinality: 
         * REQUIRED (0-1) <p>ZDP.10.2.2</p> <p>ZDP.9.2.2</p> 
         * <p>Sometimes ordering and dispensing is by package rather 
         * than individual units, and package is important in 
         * calculating total amount supplied.</p> <p>The quantity of 
         * the medication dosage form contained in the package given or 
         * to be given to the patient.</p> Un-merged Business Name: 
         * PackageQuantity Relationship: 
         * POME_MT010040CA.Content.quantity Conformance/Cardinality: 
         * REQUIRED (0-1) <p>ZDP.10.2.2</p> <p>ZDP.9.2.2</p> 
         * <p>Sometimes ordering and dispensing is by package rather 
         * than individual units, and package is important in 
         * calculating total amount supplied.</p> <p>The quantity of 
         * the medication dosage form contained in the package given or 
         * to be given to the patient.</p> Un-merged Business Name: 
         * DrugPackageQuantity Relationship: 
         * COCT_MT220210CA.Content.quantity Conformance/Cardinality: 
         * REQUIRED (0-1) <p>ZDP.10.2.2</p> <p>ZDP.9.2.2</p> 
         * <p>Sometimes ordering and dispensing is by package rather 
         * than individual units, and package is important in 
         * calculating total amount supplied.</p> <p>The quantity of 
         * the medication dosage form contained in the package given or 
         * to be given to the patient.</p> Un-merged Business Name: 
         * DrugPackageQuantity Relationship: 
         * COCT_MT220110CA.Content.quantity Conformance/Cardinality: 
         * REQUIRED (0-1) <p>ZDP.10.2.2</p> <p>ZDP.9.2.2</p> 
         * <p>Sometimes ordering and dispensing is by package rather 
         * than individual units, and package is important in 
         * calculating total amount supplied.</p> <p>The quantity of 
         * the medication dosage form contained in the package given or 
         * to be given to the patient.</p> Un-merged Business Name: 
         * DrugPackageQuantity Relationship: 
         * COCT_MT220100CA.Content.quantity Conformance/Cardinality: 
         * REQUIRED (0-1) <p>ZDP.10.2.2</p> <p>ZDP.9.2.2</p> 
         * <p>Sometimes ordering and dispensing is by package rather 
         * than individual units, and package is important in 
         * calculating total amount supplied.</p> <p>The quantity of 
         * the medication dosage form contained in the package given or 
         * to be given to the patient.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"quantity"})]
        public PhysicalQuantity Quantity {
            get { return this.quantity.Value; }
            set { this.quantity.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: DrugContainerType</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT220200CA.PackagedMedicine.formCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Many insurance 
         * plans require that a prescriber specifically authorize the 
         * use of compliance packaging before it will be covered by the 
         * plan.</p> <p>A coded value denoting a specific kind of a 
         * container. Used to identify a requirement for a particular 
         * type of compliance packaging</p> Un-merged Business Name: 
         * ContainerType Relationship: 
         * POME_MT010100CA.PackagedMedicine.formCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Many insurance 
         * plans require that a prescriber specifically authorize the 
         * use of compliance packaging before it will be covered by the 
         * plan.</p> <p>A coded value denoting a specific kind of a 
         * container. Used to identify a requirement for a particular 
         * type of compliance packaging</p> Un-merged Business Name: 
         * ContainerType Relationship: 
         * POME_MT010040CA.PackagedMedicine.formCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Many insurance 
         * plans require that a prescriber specifically authorize the 
         * use of compliance packaging before it will be covered by the 
         * plan.</p> <p>A coded value denoting a specific kind of a 
         * container. Used to identify a requirement for a particular 
         * type of compliance packaging</p> Un-merged Business Name: 
         * DrugContainerType Relationship: 
         * COCT_MT220210CA.PackagedMedicine.formCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Many insurance 
         * plans require that a prescriber specifically authorize the 
         * use of compliance packaging before it will be covered by the 
         * plan.</p> <p>A coded value denoting a specific kind of a 
         * container. Used to identify a requirement for a particular 
         * type of compliance packaging</p> Un-merged Business Name: 
         * DrugContainerType Relationship: 
         * COCT_MT220110CA.PackagedMedicine.formCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Many insurance 
         * plans require that a prescriber specifically authorize the 
         * use of compliance packaging before it will be covered by the 
         * plan.</p> <p>A coded value denoting a specific kind of a 
         * container. Used to identify a requirement for a particular 
         * type of compliance packaging</p> Un-merged Business Name: 
         * DrugContainerType Relationship: 
         * COCT_MT220100CA.PackagedMedicine.formCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Many insurance 
         * plans require that a prescriber specifically authorize the 
         * use of compliance packaging before it will be covered by the 
         * plan.</p> <p>A coded value denoting a specific kind of a 
         * container. Used to identify a requirement for a particular 
         * type of compliance packaging</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"containerPackagedMedicine/formCode"})]
        public CompliancePackageEntityType ContainerPackagedMedicineFormCode {
            get { return (CompliancePackageEntityType) this.containerPackagedMedicineFormCode.Value; }
            set { this.containerPackagedMedicineFormCode.Value = value; }
        }

    }

}