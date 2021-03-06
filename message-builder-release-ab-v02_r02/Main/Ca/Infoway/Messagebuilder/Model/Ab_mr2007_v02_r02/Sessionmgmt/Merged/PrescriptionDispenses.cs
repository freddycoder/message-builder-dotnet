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
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt090107ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt120600ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Porx_mt980030ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Porx_mt980040ca;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: PrescriptionDispenses</summary>
     * 
     * <remarks>PORX_MT060340CA.MedicationDispense: Prescription 
     * Dispenses <p>Reported Issue is only permitted if Issue 
     * Indicator is not present</p><p>Annotation is only permitted 
     * if Annotation Indicator is not present</p> <p>Reported Issue 
     * is only permitted if Issue Indicator is not 
     * present</p><p>Annotation is only permitted if Annotation 
     * Indicator is not present</p> <p>This is the detailed 
     * information about a medication dispense that has been 
     * performed on behalf of a patient.</p> 
     * <p>A_BillablePharmacyDispense</p> <p>Dispensing is an 
     * integral part of the overall medication process.</p> 
     * PORX_MT060160CA.MedicationDispense: Prescription Dispenses 
     * <p>Reported Issue is only permitted if Issue Indicator is 
     * not present and vice versa</p><p>Annotation is only 
     * permitted if Annotation Indicator is not present and vice 
     * versa</p> <p>Reported Issue is only permitted if Issue 
     * Indicator is not present and vice versa</p><p>Annotation is 
     * only permitted if Annotation Indicator is not present and 
     * vice versa</p> <p>This is the detailed information about a 
     * medication dispense that has been performed on behalf of a 
     * patient.</p> <p>A_BillablePharmacyDispense</p> <p>Dispensing 
     * is an integral part of the overall medication process.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060160CA.MedicationDispense","PORX_MT060340CA.MedicationDispense"})]
    public class PrescriptionDispenses : MessagePartBean {

        private II id;
        private CS statusCode;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt090107ca.Provider responsiblePartyAssignedPerson;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt090107ca.Provider performerAssignedPerson;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.TargetedToPharmacy location;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Porx_mt980040ca.AdministrationInstructions> component2DosageInstruction;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.Substitution component3SubstitutionMade;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Merged.SupplyEvent component1SupplyEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Merged.StatusChanges> subjectOf1ControlActEvent;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt120600ca.Notes> subjectOf4Annotation;
        private BL subjectOf3DetectedIssueIndicator;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Porx_mt980030ca.Issues> subjectOf5DetectedIssueEvent;
        private BL subjectOf2AnnotationIndicator;

        public PrescriptionDispenses() {
            this.id = new IIImpl();
            this.statusCode = new CSImpl();
            this.component2DosageInstruction = new List<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Porx_mt980040ca.AdministrationInstructions>();
            this.subjectOf1ControlActEvent = new List<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Merged.StatusChanges>();
            this.subjectOf4Annotation = new List<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt120600ca.Notes>();
            this.subjectOf3DetectedIssueIndicator = new BLImpl(false);
            this.subjectOf5DetectedIssueEvent = new List<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Porx_mt980030ca.Issues>();
            this.subjectOf2AnnotationIndicator = new BLImpl(false);
        }
        /**
         * <summary>Business Name: PrescriptionDispenseNumber</summary>
         * 
         * <remarks>Un-merged Business Name: PrescriptionDispenseNumber 
         * Relationship: PORX_MT060340CA.MedicationDispense.id 
         * Conformance/Cardinality: MANDATORY (1) <p>The Prescription 
         * Dispense Number is a globally unique number assigned to a 
         * dispense (single fill) by the EHR/DIS irrespective of the 
         * source of the dispense.</p><p>It is created by the EHR/DIS 
         * once the dispense has passed all edits and validation.</p> 
         * <p>The Prescription Dispense Number is a globally unique 
         * number assigned to a dispense (single fill) by the EHR/DIS 
         * irrespective of the source of the dispense.</p><p>It is 
         * created by the EHR/DIS once the dispense has passed all 
         * edits and validation.</p> 
         * <p>DispensedItem.dispensedItemKey</p><p>DispensedItem.externalKey</p><p>D53(ID 
         * for the prescription assigned by pharmacy)</p><p>D55(ID for 
         * the dispense 
         * event)</p><p>D99.01</p><p>ZDP.5</p><p>ZDP.6</p><p>ZDP.22</p><p>ZRV.5</p><p>DRU.080-01(extension)</p><p>DRU.080-02(route)</p><p>Claim.455-EM 
         * (route)</p><p>Claim.402-D2 
         * (extension)</p><p>Claim.456-EN</p><p>Claim.454-EK</p><p>A_BillablePharmacyDispense</p> 
         * <p>DispensedItem.dispensedItemKey</p><p>DispensedItem.externalKey</p><p>D53(ID 
         * for the prescription assigned by pharmacy)</p><p>D55(ID for 
         * the dispense 
         * event)</p><p>D99.01</p><p>ZDP.5</p><p>ZDP.6</p><p>ZDP.22</p><p>ZRV.5</p><p>DRU.080-01(extension)</p><p>DRU.080-02(route)</p><p>Claim.455-EM 
         * (route)</p><p>Claim.402-D2 
         * (extension)</p><p>Claim.456-EN</p><p>Claim.454-EK</p><p>A_BillablePharmacyDispense</p> 
         * <p>DispensedItem.dispensedItemKey</p><p>DispensedItem.externalKey</p><p>D53(ID 
         * for the prescription assigned by pharmacy)</p><p>D55(ID for 
         * the dispense 
         * event)</p><p>D99.01</p><p>ZDP.5</p><p>ZDP.6</p><p>ZDP.22</p><p>ZRV.5</p><p>DRU.080-01(extension)</p><p>DRU.080-02(route)</p><p>Claim.455-EM 
         * (route)</p><p>Claim.402-D2 
         * (extension)</p><p>Claim.456-EN</p><p>Claim.454-EK</p><p>A_BillablePharmacyDispense</p> 
         * <p>DispensedItem.dispensedItemKey</p><p>DispensedItem.externalKey</p><p>D53(ID 
         * for the prescription assigned by pharmacy)</p><p>D55(ID for 
         * the dispense 
         * event)</p><p>D99.01</p><p>ZDP.5</p><p>ZDP.6</p><p>ZDP.22</p><p>ZRV.5</p><p>DRU.080-01(extension)</p><p>DRU.080-02(route)</p><p>Claim.455-EM 
         * (route)</p><p>Claim.402-D2 
         * (extension)</p><p>Claim.456-EN</p><p>Claim.454-EK</p><p>A_BillablePharmacyDispense</p> 
         * <p>DispensedItem.dispensedItemKey</p><p>DispensedItem.externalKey</p><p>D53(ID 
         * for the prescription assigned by pharmacy)</p><p>D55(ID for 
         * the dispense 
         * event)</p><p>D99.01</p><p>ZDP.5</p><p>ZDP.6</p><p>ZDP.22</p><p>ZRV.5</p><p>DRU.080-01(extension)</p><p>DRU.080-02(route)</p><p>Claim.455-EM 
         * (route)</p><p>Claim.402-D2 
         * (extension)</p><p>Claim.456-EN</p><p>Claim.454-EK</p><p>A_BillablePharmacyDispense</p> 
         * <p>DispensedItem.dispensedItemKey</p><p>DispensedItem.externalKey</p><p>D53(ID 
         * for the prescription assigned by pharmacy)</p><p>D55(ID for 
         * the dispense 
         * event)</p><p>D99.01</p><p>ZDP.5</p><p>ZDP.6</p><p>ZDP.22</p><p>ZRV.5</p><p>DRU.080-01(extension)</p><p>DRU.080-02(route)</p><p>Claim.455-EM 
         * (route)</p><p>Claim.402-D2 
         * (extension)</p><p>Claim.456-EN</p><p>Claim.454-EK</p><p>A_BillablePharmacyDispense</p> 
         * <p>DispensedItem.dispensedItemKey</p><p>DispensedItem.externalKey</p><p>D53(ID 
         * for the prescription assigned by pharmacy)</p><p>D55(ID for 
         * the dispense 
         * event)</p><p>D99.01</p><p>ZDP.5</p><p>ZDP.6</p><p>ZDP.22</p><p>ZRV.5</p><p>DRU.080-01(extension)</p><p>DRU.080-02(route)</p><p>Claim.455-EM 
         * (route)</p><p>Claim.402-D2 
         * (extension)</p><p>Claim.456-EN</p><p>Claim.454-EK</p><p>A_BillablePharmacyDispense</p> 
         * <p>DispensedItem.dispensedItemKey</p><p>DispensedItem.externalKey</p><p>D53(ID 
         * for the prescription assigned by pharmacy)</p><p>D55(ID for 
         * the dispense 
         * event)</p><p>D99.01</p><p>ZDP.5</p><p>ZDP.6</p><p>ZDP.22</p><p>ZRV.5</p><p>DRU.080-01(extension)</p><p>DRU.080-02(route)</p><p>Claim.455-EM 
         * (route)</p><p>Claim.402-D2 
         * (extension)</p><p>Claim.456-EN</p><p>Claim.454-EK</p><p>A_BillablePharmacyDispense</p> 
         * <p>DispensedItem.dispensedItemKey</p><p>DispensedItem.externalKey</p><p>D53(ID 
         * for the prescription assigned by pharmacy)</p><p>D55(ID for 
         * the dispense 
         * event)</p><p>D99.01</p><p>ZDP.5</p><p>ZDP.6</p><p>ZDP.22</p><p>ZRV.5</p><p>DRU.080-01(extension)</p><p>DRU.080-02(route)</p><p>Claim.455-EM 
         * (route)</p><p>Claim.402-D2 
         * (extension)</p><p>Claim.456-EN</p><p>Claim.454-EK</p><p>A_BillablePharmacyDispense</p> 
         * <p>DispensedItem.dispensedItemKey</p><p>DispensedItem.externalKey</p><p>D53(ID 
         * for the prescription assigned by pharmacy)</p><p>D55(ID for 
         * the dispense 
         * event)</p><p>D99.01</p><p>ZDP.5</p><p>ZDP.6</p><p>ZDP.22</p><p>ZRV.5</p><p>DRU.080-01(extension)</p><p>DRU.080-02(route)</p><p>Claim.455-EM 
         * (route)</p><p>Claim.402-D2 
         * (extension)</p><p>Claim.456-EN</p><p>Claim.454-EK</p><p>A_BillablePharmacyDispense</p> 
         * <p>DispensedItem.dispensedItemKey</p><p>DispensedItem.externalKey</p><p>D53(ID 
         * for the prescription assigned by pharmacy)</p><p>D55(ID for 
         * the dispense 
         * event)</p><p>D99.01</p><p>ZDP.5</p><p>ZDP.6</p><p>ZDP.22</p><p>ZRV.5</p><p>DRU.080-01(extension)</p><p>DRU.080-02(route)</p><p>Claim.455-EM 
         * (route)</p><p>Claim.402-D2 
         * (extension)</p><p>Claim.456-EN</p><p>Claim.454-EK</p><p>A_BillablePharmacyDispense</p> 
         * <p>DispensedItem.dispensedItemKey</p><p>DispensedItem.externalKey</p><p>D53(ID 
         * for the prescription assigned by pharmacy)</p><p>D55(ID for 
         * the dispense 
         * event)</p><p>D99.01</p><p>ZDP.5</p><p>ZDP.6</p><p>ZDP.22</p><p>ZRV.5</p><p>DRU.080-01(extension)</p><p>DRU.080-02(route)</p><p>Claim.455-EM 
         * (route)</p><p>Claim.402-D2 
         * (extension)</p><p>Claim.456-EN</p><p>Claim.454-EK</p><p>A_BillablePharmacyDispense</p> 
         * <p>DispensedItem.dispensedItemKey</p><p>DispensedItem.externalKey</p><p>D53(ID 
         * for the prescription assigned by pharmacy)</p><p>D55(ID for 
         * the dispense 
         * event)</p><p>D99.01</p><p>ZDP.5</p><p>ZDP.6</p><p>ZDP.22</p><p>ZRV.5</p><p>DRU.080-01(extension)</p><p>DRU.080-02(route)</p><p>Claim.455-EM 
         * (route)</p><p>Claim.402-D2 
         * (extension)</p><p>Claim.456-EN</p><p>Claim.454-EK</p><p>A_BillablePharmacyDispense</p> 
         * <p>DispensedItem.dispensedItemKey</p><p>DispensedItem.externalKey</p><p>D53(ID 
         * for the prescription assigned by pharmacy)</p><p>D55(ID for 
         * the dispense 
         * event)</p><p>D99.01</p><p>ZDP.5</p><p>ZDP.6</p><p>ZDP.22</p><p>ZRV.5</p><p>DRU.080-01(extension)</p><p>DRU.080-02(route)</p><p>Claim.455-EM 
         * (route)</p><p>Claim.402-D2 
         * (extension)</p><p>Claim.456-EN</p><p>Claim.454-EK</p><p>A_BillablePharmacyDispense</p> 
         * <p>DispensedItem.dispensedItemKey</p><p>DispensedItem.externalKey</p><p>D53(ID 
         * for the prescription assigned by pharmacy)</p><p>D55(ID for 
         * the dispense 
         * event)</p><p>D99.01</p><p>ZDP.5</p><p>ZDP.6</p><p>ZDP.22</p><p>ZRV.5</p><p>DRU.080-01(extension)</p><p>DRU.080-02(route)</p><p>Claim.455-EM 
         * (route)</p><p>Claim.402-D2 
         * (extension)</p><p>Claim.456-EN</p><p>Claim.454-EK</p><p>A_BillablePharmacyDispense</p> 
         * <p>DispensedItem.dispensedItemKey</p><p>DispensedItem.externalKey</p><p>D53(ID 
         * for the prescription assigned by pharmacy)</p><p>D55(ID for 
         * the dispense 
         * event)</p><p>D99.01</p><p>ZDP.5</p><p>ZDP.6</p><p>ZDP.22</p><p>ZRV.5</p><p>DRU.080-01(extension)</p><p>DRU.080-02(route)</p><p>Claim.455-EM 
         * (route)</p><p>Claim.402-D2 
         * (extension)</p><p>Claim.456-EN</p><p>Claim.454-EK</p><p>A_BillablePharmacyDispense</p> 
         * <p>Allows for the referencing of a specific dispense 
         * record.</p><p>Identifier for a dispensed record is needed so 
         * that dispenses may be uniquely referenced. Thus the 
         * mandatory requirement.</p> <p>Allows for the referencing of 
         * a specific dispense record.</p><p>Identifier for a dispensed 
         * record is needed so that dispenses may be uniquely 
         * referenced. Thus the mandatory requirement.</p> Un-merged 
         * Business Name: PrescriptionDispenseNumber Relationship: 
         * PORX_MT060160CA.MedicationDispense.id 
         * Conformance/Cardinality: MANDATORY (1) <p>The Prescription 
         * Dispense Number is a globally unique number assigned to a 
         * dispense (single fill) by the EHR/DIS irrespective of the 
         * source of the dispense.</p><p>It is created by the EHR/DIS 
         * once the dispense has passed all edits and validation.</p> 
         * <p>The Prescription Dispense Number is a globally unique 
         * number assigned to a dispense (single fill) by the EHR/DIS 
         * irrespective of the source of the dispense.</p><p>It is 
         * created by the EHR/DIS once the dispense has passed all 
         * edits and validation.</p> 
         * <p>DispensedItem.dispensedItemKey</p><p>Dispen
         * ... [rest of documentation truncated due to excessive length]
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: DispenseStatus</summary>
         * 
         * <remarks>Un-merged Business Name: DispenseStatus 
         * Relationship: PORX_MT060340CA.MedicationDispense.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates the 
         * status of the dispense record created on the EHR/DIS. If 
         * 'Active' it means that the dispense has been processed but 
         * not yet given to the patient. If 'Complete', it indicates 
         * that the medication has been delivered to the patient.</p> 
         * <p>Important in understanding what medication the patient 
         * actually has on hand, thus the attribute is mandatory. May 
         * also influence the ability of a different pharmacy to 
         * dispense the medication.</p> Un-merged Business Name: 
         * DispenseStatus Relationship: 
         * PORX_MT060160CA.MedicationDispense.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates the 
         * status of the dispense record created on the EHR/DIS. If 
         * Active it means that the dispense has been processed but not 
         * yet given to the patient. If Complete, it indicates that the 
         * medication has been delivered to the patient.</p> 
         * <p>Important in understanding what medication the patient 
         * actually has on hand, thus the attribute is mandatory. May 
         * also influence the ability of a different pharmacy to 
         * dispense the medication.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060340CA.ResponsibleParty4.assignedPerson 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060160CA.ResponsibleParty3.assignedPerson 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/assignedPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt090107ca.Provider ResponsiblePartyAssignedPerson {
            get { return this.responsiblePartyAssignedPerson; }
            set { this.responsiblePartyAssignedPerson = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060340CA.Performer3.assignedPerson 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060160CA.Performer3.assignedPerson 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"performer/assignedPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt090107ca.Provider PerformerAssignedPerson {
            get { return this.performerAssignedPerson; }
            set { this.performerAssignedPerson = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060340CA.MedicationDispense.location 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060160CA.MedicationDispense.location 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.TargetedToPharmacy Location {
            get { return this.location; }
            set { this.location = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060340CA.Component11.dosageInstruction 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060160CA.Component11.dosageInstruction 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component1/dosageInstruction","component2/dosageInstruction"})]
        [Hl7MapByPartType(Name="component1", Type="PORX_MT060340CA.Component11")]
        [Hl7MapByPartType(Name="component1/dosageInstruction", Type="PORX_MT980040CA.DosageInstruction")]
        [Hl7MapByPartType(Name="component2", Type="PORX_MT060160CA.Component11")]
        [Hl7MapByPartType(Name="component2/dosageInstruction", Type="PORX_MT980040CA.DosageInstruction")]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Porx_mt980040ca.AdministrationInstructions> Component2DosageInstruction {
            get { return this.component2DosageInstruction; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060340CA.Component13.substitutionMade 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060160CA.Component13.substitutionMade 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component2/substitutionMade","component3/substitutionMade"})]
        [Hl7MapByPartType(Name="component2", Type="PORX_MT060340CA.Component13")]
        [Hl7MapByPartType(Name="component2/substitutionMade", Type="PORX_MT060340CA.SubstitutionMade")]
        [Hl7MapByPartType(Name="component3", Type="PORX_MT060160CA.Component13")]
        [Hl7MapByPartType(Name="component3/substitutionMade", Type="PORX_MT060160CA.SubstitutionMade")]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.Substitution Component3SubstitutionMade {
            get { return this.component3SubstitutionMade; }
            set { this.component3SubstitutionMade = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: PORX_MT060340CA.Component.supplyEvent 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060160CA.Component.supplyEvent 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component1/supplyEvent","component3/supplyEvent"})]
        [Hl7MapByPartType(Name="component1", Type="PORX_MT060160CA.Component")]
        [Hl7MapByPartType(Name="component1/supplyEvent", Type="PORX_MT060160CA.SupplyEvent")]
        [Hl7MapByPartType(Name="component3", Type="PORX_MT060340CA.Component")]
        [Hl7MapByPartType(Name="component3/supplyEvent", Type="PORX_MT060340CA.SupplyEvent")]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Merged.SupplyEvent Component1SupplyEvent {
            get { return this.component1SupplyEvent; }
            set { this.component1SupplyEvent = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060340CA.Subject10.controlActEvent 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060160CA.Subject.controlActEvent 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf1/controlActEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Merged.StatusChanges> SubjectOf1ControlActEvent {
            get { return this.subjectOf1ControlActEvent; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: PORX_MT060340CA.Subject7.annotation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060160CA.Subject7.annotation Conformance/Cardinality: 
         * POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2/annotation","subjectOf4/annotation"})]
        [Hl7MapByPartType(Name="subjectOf2", Type="PORX_MT060340CA.Subject7")]
        [Hl7MapByPartType(Name="subjectOf2/annotation", Type="COCT_MT120600CA.Annotation")]
        [Hl7MapByPartType(Name="subjectOf4", Type="PORX_MT060160CA.Subject7")]
        [Hl7MapByPartType(Name="subjectOf4/annotation", Type="COCT_MT120600CA.Annotation")]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt120600ca.Notes> SubjectOf4Annotation {
            get { return this.subjectOf4Annotation; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060340CA.Subject13.detectedIssueIndicator 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060160CA.Subject13.detectedIssueIndicator 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf3/detectedIssueIndicator"})]
        public bool? SubjectOf3DetectedIssueIndicator {
            get { return this.subjectOf3DetectedIssueIndicator.Value; }
            set { this.subjectOf3DetectedIssueIndicator.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060340CA.Subject6.detectedIssueEvent 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060160CA.Subject6.detectedIssueEvent 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf4/detectedIssueEvent","subjectOf5/detectedIssueEvent"})]
        [Hl7MapByPartType(Name="subjectOf4", Type="PORX_MT060340CA.Subject6")]
        [Hl7MapByPartType(Name="subjectOf4/detectedIssueEvent", Type="PORX_MT980030CA.DetectedIssueEvent")]
        [Hl7MapByPartType(Name="subjectOf5", Type="PORX_MT060160CA.Subject6")]
        [Hl7MapByPartType(Name="subjectOf5/detectedIssueEvent", Type="PORX_MT980030CA.DetectedIssueEvent")]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Porx_mt980030ca.Issues> SubjectOf5DetectedIssueEvent {
            get { return this.subjectOf5DetectedIssueEvent; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060340CA.Subject12.annotationIndicator 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060160CA.Subject12.annotationIndicator 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2/annotationIndicator","subjectOf5/annotationIndicator"})]
        [Hl7MapByPartType(Name="subjectOf2", Type="PORX_MT060160CA.Subject12")]
        [Hl7MapByPartType(Name="subjectOf2/annotationIndicator", Type="PORX_MT060160CA.AnnotationIndicator")]
        [Hl7MapByPartType(Name="subjectOf5", Type="PORX_MT060340CA.Subject12")]
        [Hl7MapByPartType(Name="subjectOf5/annotationIndicator", Type="PORX_MT060340CA.AnnotationIndicator")]
        public bool? SubjectOf2AnnotationIndicator {
            get { return this.subjectOf2AnnotationIndicator.Value; }
            set { this.subjectOf2AnnotationIndicator.Value = value; }
        }

    }

}