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
namespace Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Porx_mt010110ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt050203ca;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt120600ca;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt141007ca;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Prescription</summary>
     * 
     * <p>Information pertaining to a prescriber's authorization 
     * for a device to be dispensed to a patient, as well as the 
     * instruction on when and how the device is to be used by the 
     * patient</p> <p>This is a 'core' class of the medication 
     * model and is important for understanding what devices the 
     * patient is intended to be receiving.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT010110CA.DeviceRequest"})]
    public class Prescription : MessagePartBean {

        private II id;
        private CS statusCode;
        private CV confidentialityCode;
        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt141007ca.DeviceProduct directTargetManufacturedProduct;
        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt050203ca.Patient subjectPatient;
        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Porx_mt010110ca.PriorDeviceRequest predecessorPriorDeviceRequest;
        private IList<Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged.PrescribedBecauseOf> reason;
        private BL preconditionVerificationEventCriterion;
        private IList<Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged.CoverageExtensions_1> coverageCoverage;
        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged.ProcedureRequest component1ProcedureRequest;
        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged.DispenseInstructions_1 component2SupplyRequest;
        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt120600ca.Notes subjectOfAnnotation;

        public Prescription() {
            this.id = new IIImpl();
            this.statusCode = new CSImpl();
            this.confidentialityCode = new CVImpl();
            this.reason = new List<Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged.PrescribedBecauseOf>();
            this.preconditionVerificationEventCriterion = new BLImpl(false);
            this.coverageCoverage = new List<Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged.CoverageExtensions_1>();
        }
        /**
         * <summary>Business Name: A: Prescription Number</summary>
         * 
         * <remarks>Relationship: PORX_MT010110CA.DeviceRequest.id 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>The Prescription 
         * Order Number is a globally unique number assigned to a 
         * prescription by the EHR/DIS irrespective of the source of 
         * the order</p><p>It is created by the EHR/DIS once the 
         * prescription has passed all edits and validation.</p> <p>The 
         * Prescription Order Number is a globally unique number 
         * assigned to a prescription by the EHR/DIS irrespective of 
         * the source of the order</p><p>It is created by the EHR/DIS 
         * once the prescription has passed all edits and 
         * validation.</p> <p>Allows for the situations where the order 
         * is originating from the DIS.</p><p>Allows prescriptions to 
         * be uniquely referenced.</p><p>Because this attribute is not 
         * used for prescriptions originating from a prescriber system, 
         * the element is optional.</p> <p>Allows for the situations 
         * where the order is originating from the DIS.</p><p>Allows 
         * prescriptions to be uniquely referenced.</p><p>Because this 
         * attribute is not used for prescriptions originating from a 
         * prescriber system, the element is optional.</p> <p>Allows 
         * for the situations where the order is originating from the 
         * DIS.</p><p>Allows prescriptions to be uniquely 
         * referenced.</p><p>Because this attribute is not used for 
         * prescriptions originating from a prescriber system, the 
         * element is optional.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: C:Prescription Status</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT010110CA.DeviceRequest.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>This denotes the 
         * state of the prescription in the lifecycle of the 
         * prescription. Valid statuses are: new, active, suspended, 
         * aborted, completed, obsolete and nullified. Use 'active' 
         * when registering a new prescription or converting a 
         * predetermination into a valid prescription.</p> <p>Indicates 
         * what actions are allowed to be performed against a 
         * prescription. This is a mandatory field because every 
         * prescription needs to be in some state.</p> <p>This will be 
         * "active" when submitting a new prescription. Any other code 
         * will cause a CODE_INVAL error issue to be returned.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: F:Prescription Masking Indicator</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT010110CA.DeviceRequest.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Communicates the 
         * intent of the patient to restrict access to their 
         * prescriptions. Provides support for additional 
         * confidentiality constraint, giving patients a level of 
         * control over their information. Valid values are: 'NORMAL' 
         * (denotes 'Not Masked'); and 'RESTRICTED' (denotes 'Masked'). 
         * The default is 'NORMAL' signifying 'Not Masked'.</p> 
         * <p>Prescription.masked</p> <p>Allows the patient to have 
         * discrete control over access to their prescription 
         * data.</p><p>The attribute is optional because not all 
         * systems will support masking.</p> <p>Allows the patient to 
         * have discrete control over access to their prescription 
         * data.</p><p>The attribute is optional because not all 
         * systems will support masking.</p> <p><strong>As SK does not 
         * implement record-level masking, this must be "Normal" or a 
         * CODE_INVAL error issue will be returned.</strong></p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public x_VeryBasicConfidentialityKind ConfidentialityCode {
            get { return (x_VeryBasicConfidentialityKind) this.confidentialityCode.Value; }
            set { this.confidentialityCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT010110CA.DirectTarget.manufacturedProduct</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"directTarget/manufacturedProduct"})]
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt141007ca.DeviceProduct DirectTargetManufacturedProduct {
            get { return this.directTargetManufacturedProduct; }
            set { this.directTargetManufacturedProduct = value; }
        }

        /**
         * <summary>Relationship: PORX_MT010110CA.Subject5.patient</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject/patient"})]
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt050203ca.Patient SubjectPatient {
            get { return this.subjectPatient; }
            set { this.subjectPatient = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT010110CA.Predecessor.priorDeviceRequest</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1) <div>This is 
         * the original prescription that is being</div> 
         * <p>renewed.&nbsp;</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"predecessor/priorDeviceRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Porx_mt010110ca.PriorDeviceRequest PredecessorPriorDeviceRequest {
            get { return this.predecessorPriorDeviceRequest; }
            set { this.predecessorPriorDeviceRequest = value; }
        }

        /**
         * <summary>Business Name: Prescribed Because Of</summary>
         * 
         * <remarks>Relationship: PORX_MT010110CA.DeviceRequest.reason 
         * Conformance/Cardinality: POPULATED (1-5) <div>Denotes the 
         * reason(s) for this specific</div> <div>prescription; it must 
         * not be interpreted as a</div> <div>permanent 
         * diagnosis.</div> <div>&nbsp;</div> <div>NOTE: Although at 
         * least one repetition must be</div> <div>sent, 
         * &ldquo;Nulls&rdquo; are allowed if there are no 
         * indications</div> <p>recorded against a 
         * prescription.&nbsp;&nbsp;&nbsp;</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reason"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged.PrescribedBecauseOf> Reason {
            get { return this.reason; }
        }

        /**
         * <summary>Business Name: Non-authoritative Indicator</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT010110CA.Precondition.verificationEventCriterion 
         * Conformance/Cardinality: POPULATED (1) <div>If present, 
         * indicates that the prescription is 
         * nonauthoritative.&nbsp;I.e. A paper copy must be 
         * viewed&nbsp;before the prescription can be 
         * dispensed.&nbsp;</div></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"precondition/verificationEventCriterion"})]
        public bool? PreconditionVerificationEventCriterion {
            get { return this.preconditionVerificationEventCriterion.Value; }
            set { this.preconditionVerificationEventCriterion.Value = value; }
        }

        /**
         * <summary>Relationship: PORX_MT010110CA.Coverage2.coverage</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"coverage/coverage"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged.CoverageExtensions_1> CoverageCoverage {
            get { return this.coverageCoverage; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT010110CA.Component1.procedureRequest</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component1/procedureRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged.ProcedureRequest Component1ProcedureRequest {
            get { return this.component1ProcedureRequest; }
            set { this.component1ProcedureRequest = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT010110CA.Component6.supplyRequest</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1) 
         * <p>&nbsp;Specification of how the prescribed device is to 
         * be</p> <div>dispensed to the patient.</div></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component2/supplyRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged.DispenseInstructions_1 Component2SupplyRequest {
            get { return this.component2SupplyRequest; }
            set { this.component2SupplyRequest = value; }
        }

        /**
         * <summary>Relationship: PORX_MT010110CA.Subject4.annotation</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf/annotation"})]
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt120600ca.Notes SubjectOfAnnotation {
            get { return this.subjectOfAnnotation; }
            set { this.subjectOfAnnotation = value; }
        }

    }

}