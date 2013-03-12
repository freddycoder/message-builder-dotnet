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
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>Business Name: ParentPrescription</summary>
     * 
     * <remarks>PORX_MT060040CA.PriorSupplyRequest: Parent 
     * Prescription <p>This is the original prescription that is 
     * being renewed. The current prescription uses the original 
     * prescription as the basis for its information.</p> <p>Helps 
     * link prescriptions together, and subsequently indications 
     * for prescribing.</p> 
     * PORX_MT060340CA.PriorCombinedMedicationRequest: Parent 
     * Prescription <p>This is the original prescription that is 
     * being renewed. The current prescription uses the original 
     * prescription as the basis for its information.</p> <p>Helps 
     * link prescriptions together, and subsequently indications 
     * for prescribing.</p> 
     * PORX_MT060160CA.PriorCombinedMedicationRequest: Parent 
     * Prescription <p>This is the original prescription that is 
     * being renewed. The current prescription uses the original 
     * prescription as the basis for its information.</p> <p>Helps 
     * link prescriptions together, and subsequently indications 
     * for prescribing.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT010120CA.PriorCombinedMedicationRequest","PORX_MT060040CA.PriorSupplyRequest","PORX_MT060160CA.PriorCombinedMedicationRequest","PORX_MT060340CA.PriorCombinedMedicationRequest"})]
    public class ParentPrescription : MessagePartBean {

        private II id;

        public ParentPrescription() {
            this.id = new IIImpl();
        }
        /**
         * <summary>Business Name: PreviousPrescriptionOrderNumber</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * PreviousPrescriptionOrderNumber Relationship: 
         * PORX_MT010120CA.PriorCombinedMedicationRequest.id 
         * Conformance/Cardinality: MANDATORY (1) <p>A reference to a 
         * previous prescription which the current prescription 
         * replaces.</p> <p>New or Repeat (if present, then Repeat)</p> 
         * <p>Allows a prescription renewal (this prescription) to note 
         * the previous prescription id that was renewed;</p><p>Allows 
         * tracking a therapy across multiple renewal 
         * prescriptions.</p> <p>Allows a prescription renewal (this 
         * prescription) to note the previous prescription id that was 
         * renewed;</p><p>Allows tracking a therapy across multiple 
         * renewal prescriptions.</p> Un-merged Business Name: 
         * PreviousPrescriptionOrderNumber Relationship: 
         * PORX_MT060040CA.PriorSupplyRequest.id 
         * Conformance/Cardinality: MANDATORY (1) <p>A reference to a 
         * previous prescription which the current prescription 
         * replaces.</p> <p>New or Repeat (if present, then Repeat)</p> 
         * <p>Allows a prescription renewal (this prescription) to note 
         * the previous prescription id that was renewed;</p><p>Allows 
         * tracking a therapy across multiple renewal 
         * prescriptions.</p> <p>Allows a prescription renewal (this 
         * prescription) to note the previous prescription id that was 
         * renewed;</p><p>Allows tracking a therapy across multiple 
         * renewal prescriptions.</p> Un-merged Business Name: 
         * PreviousPrescriptionOrderNumber Relationship: 
         * PORX_MT060340CA.PriorCombinedMedicationRequest.id 
         * Conformance/Cardinality: MANDATORY (1) <p>A reference to a 
         * previous prescription which the current prescription 
         * replaces.</p> <p>New or Repeat (if present, then Repeat)</p> 
         * <p>Allows a prescription renewal (this prescription) to note 
         * the previous prescription id that was renewed;</p><p>Allows 
         * tracking a therapy across multiple renewal 
         * prescriptions.</p> <p>Allows a prescription renewal (this 
         * prescription) to note the previous prescription id that was 
         * renewed;</p><p>Allows tracking a therapy across multiple 
         * renewal prescriptions.</p> Un-merged Business Name: 
         * PreviousPrescriptionOrderNumber Relationship: 
         * PORX_MT060160CA.PriorCombinedMedicationRequest.id 
         * Conformance/Cardinality: MANDATORY (1) <p>A reference to a 
         * previous prescription which the current prescription 
         * replaces.</p> <p>New or Repeat (if present, then Repeat)</p> 
         * <p>Allows a prescription renewal (this prescription) to note 
         * the previous prescription id that was renewed;</p><p>Allows 
         * tracking a therapy across multiple renewal 
         * prescriptions.</p> <p>Allows a prescription renewal (this 
         * prescription) to note the previous prescription id that was 
         * renewed;</p><p>Allows tracking a therapy across multiple 
         * renewal prescriptions.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

    }

}