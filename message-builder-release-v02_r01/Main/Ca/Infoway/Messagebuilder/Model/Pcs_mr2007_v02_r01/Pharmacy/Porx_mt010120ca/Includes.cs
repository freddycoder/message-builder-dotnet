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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Porx_mt010120ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Merged;
    using System;


    /**
     * <summary>Business Name: g:includes</summary>
     * 
     * <p>Allows patient height and weight to be conveyed to the 
     * pharmacy for dosage calculation or verification</p><p>The 
     * additional repetitions are to allow for capturing of 
     * additional concepts beyond height and weight without 
     * impacting the message structure should future versions of 
     * the specification allow.</p> <p>Indicates other patient 
     * information that is an important consideration for the 
     * prescription. This information is limited to height and 
     * weight.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT010120CA.PertinentInformation"})]
    public class Includes : MessagePartBean {

        private BL contextConductionInd;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Merged.PrescriptionPatientMeasurements quantityObservationEvent;

        public Includes() {
            this.contextConductionInd = new BLImpl();
        }
        /**
         * <summary>Relationship: 
         * PORX_MT010120CA.PertinentInformation.contextConductionInd</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"contextConductionInd"})]
        public bool? ContextConductionInd {
            get { return this.contextConductionInd.Value; }
            set { this.contextConductionInd.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT010120CA.PertinentInformation.quantityObservationEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"quantityObservationEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Merged.PrescriptionPatientMeasurements QuantityObservationEvent {
            get { return this.quantityObservationEvent; }
            set { this.quantityObservationEvent = value; }
        }

    }

}