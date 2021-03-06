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
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Porx_mt020060ca {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt120600ca;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Prescription Dispense</summary>
     * 
     * <p>This is the detailed information about a device dispense 
     * that has been performed on behalf a patient</p> 
     * <p>Dispensing is an integral part of the overall 
     * prescription process.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT020060CA.DeviceDispense"})]
    public class PrescriptionDispense : MessagePartBean {

        private II id;
        private SET<CV, Code> confidentialityCode;
        private BL subject;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.DeviceRequest_1 inFulfillmentOfDeviceRequest;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.ProcedureRequest component1ProcedureRequest;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.DispenseDetails component2SupplyEvent;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt120600ca.Notes subjectOfAnnotation;

        public PrescriptionDispense() {
            this.id = new IIImpl();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.subject = new BLImpl(false);
        }
        /**
         * <summary>Business Name: A:Prescription Dispense Number</summary>
         * 
         * <remarks>Relationship: PORX_MT020060CA.DeviceDispense.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Identifier 
         * assigned by the dispensing facility.</p> <p>Allows formal 
         * tracking of centrally recorded dispenses to local records 
         * for audit and related purposes.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: E:Prescription Masking Indicators</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT020060CA.DeviceDispense.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-2) <p>Communicates the 
         * intent that the dispense should be masked if it is created; 
         * If the dispense is masked, this makes the complete 
         * prescription and all dispenses masked.</p> <p>Can be used to 
         * set a mask for a new dispense, if present in a new dispense 
         * request.</p><p>Allows the patient to have discrete control 
         * over access to their prescription data.</p><p>Taboo allows 
         * the provider to request restricted access to patient or 
         * their care giver.</p><p>Constraint: Can&#226;&#128;&#153;t 
         * have both normal and one of the other codes 
         * simultaneously.</p><p>The attribute is optional because not 
         * all systems will support masking.</p> <p>Can be used to set 
         * a mask for a new dispense, if present in a new dispense 
         * request.</p><p>Allows the patient to have discrete control 
         * over access to their prescription data.</p><p>Taboo allows 
         * the provider to request restricted access to patient or 
         * their care giver.</p><p>Constraint: Can&#226;&#128;&#153;t 
         * have both normal and one of the other codes 
         * simultaneously.</p><p>The attribute is optional because not 
         * all systems will support masking.</p> <p>Can be used to set 
         * a mask for a new dispense, if present in a new dispense 
         * request.</p><p>Allows the patient to have discrete control 
         * over access to their prescription data.</p><p>Taboo allows 
         * the provider to request restricted access to patient or 
         * their care giver.</p><p>Constraint: Can&#226;&#128;&#153;t 
         * have both normal and one of the other codes 
         * simultaneously.</p><p>The attribute is optional because not 
         * all systems will support masking.</p> <p>Can be used to set 
         * a mask for a new dispense, if present in a new dispense 
         * request.</p><p>Allows the patient to have discrete control 
         * over access to their prescription data.</p><p>Taboo allows 
         * the provider to request restricted access to patient or 
         * their care giver.</p><p>Constraint: Can&#226;&#128;&#153;t 
         * have both normal and one of the other codes 
         * simultaneously.</p><p>The attribute is optional because not 
         * all systems will support masking.</p> <p>Can be used to set 
         * a mask for a new dispense, if present in a new dispense 
         * request.</p><p>Allows the patient to have discrete control 
         * over access to their prescription data.</p><p>Taboo allows 
         * the provider to request restricted access to patient or 
         * their care giver.</p><p>Constraint: Can&#226;&#128;&#153;t 
         * have both normal and one of the other codes 
         * simultaneously.</p><p>The attribute is optional because not 
         * all systems will support masking.</p> <p>If a dispense is 
         * masked, it implicitly masks the prescription being 
         * dispensed. (There's no point in masking a dispense if the 
         * prescription is unmasked.)</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_NormalRestrictedTabooConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_NormalRestrictedTabooConfidentialityKind>(); }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT020060CA.DeviceDispense.subject</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject"})]
        public bool? Subject {
            get { return this.subject.Value; }
            set { this.subject.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT020060CA.InFulfillmentOf1.deviceRequest</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"inFulfillmentOf/deviceRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.DeviceRequest_1 InFulfillmentOfDeviceRequest {
            get { return this.inFulfillmentOfDeviceRequest; }
            set { this.inFulfillmentOfDeviceRequest = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT020060CA.Component11.procedureRequest</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component1/procedureRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.ProcedureRequest Component1ProcedureRequest {
            get { return this.component1ProcedureRequest; }
            set { this.component1ProcedureRequest = value; }
        }

        /**
         * <summary>Relationship: PORX_MT020060CA.Component.supplyEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component2/supplyEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.DispenseDetails Component2SupplyEvent {
            get { return this.component2SupplyEvent; }
            set { this.component2SupplyEvent = value; }
        }

        /**
         * <summary>Relationship: PORX_MT020060CA.Subject7.annotation</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf/annotation"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt120600ca.Notes SubjectOfAnnotation {
            get { return this.subjectOfAnnotation; }
            set { this.subjectOfAnnotation = value; }
        }

    }

}