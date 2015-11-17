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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Interaction {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Mcci_mt002300ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Quqi_mt120006ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pharmacy.Porx_mt060280ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pharmacy.Porx_mt060340ca;


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
    public class MedicationPrescriptionDetailQueryResponse : HL7Message<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Quqi_mt120006ca.TriggerEvent<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pharmacy.Porx_mt060340ca.Prescription,Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pharmacy.Porx_mt060280ca.DrugPrescriptionDetailQueryParameters>>, IInteraction {


        public MedicationPrescriptionDetailQueryResponse() {
        }
    }

}