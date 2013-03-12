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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Interaction {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Pharmacy.Merged;


    /**
     * <summary>Business Name: PORX_IN010110CA: Revise assigned 
     * dispense responsibility req. acc.</summary>
     * 
     * <p>Indicates that the responsibility for fulfilling the 
     * dispense portion of a prescription has been changed to the 
     * requested facility.</p> Message: MCCI_MT002300CA.Message 
     * Control Act: MCAI_MT700226CA.ControlActEvent --> Payload: 
     * PORX_MT060350CA.Prescription ----> Payload Choice: 
     * PORX_MT060340CA.CombinedMedicationRequest ----> Payload 
     * Choice: PORX_MT060040CA.DeviceRequest
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_IN010110CA"})]
    public class ReviseAssignedDispenseResponsibilityReqAcc : HL7Message_1<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.TriggerEvent_2<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Pharmacy.Merged.IPrescription>>, IInteraction {


        public ReviseAssignedDispenseResponsibilityReqAcc() {
        }
    }

}