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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Interaction {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Porx_mt060340ca;


    /**
     * <summary>Business Name: PORX_IN060260CA: Medication 
     * prescription detail query response</summary>
     * 
     * <p>Returns detailed information about a single medication 
     * prescription referenced by id, optionally including detailed 
     * dispense information.</p> Message: MCCI_MT002300CA.Message 
     * Control Act: QUQI_MT120006CA.ControlActEvent --> Payload: 
     * PORX_MT060340CA.CombinedMedicationRequest --> Payload: 
     * PORX_MT060280CA.ParameterList
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_IN060260CA"})]
    public class MedicationPrescriptionDetailQueryResponse : HL7Message_1<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.TriggerEvent_6<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Porx_mt060340ca.Prescription,Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Merged.DrugPrescriptionDetailQueryParameters>>, IInteraction {


        public MedicationPrescriptionDetailQueryResponse() {
        }
    }

}