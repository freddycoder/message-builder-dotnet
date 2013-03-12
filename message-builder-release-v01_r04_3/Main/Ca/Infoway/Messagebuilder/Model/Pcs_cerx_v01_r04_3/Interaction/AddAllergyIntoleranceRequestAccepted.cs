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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Interaction {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged;


    /**
     * <summary>Business Name: REPC_IN000013CA: Add 
     * allergy/intolerance request accepted</summary>
     * 
     * <p>Indicates that the requested allergy or intolerance 
     * record has been successfully added to the patient's 
     * record.</p> Message: MCCI_MT000300CA.Message Control Act: 
     * MCAI_MT700220CA.ControlActEvent --> Payload: 
     * PORX_MT990010CA.ActEvent
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_IN000013CA"})]
    public class AddAllergyIntoleranceRequestAccepted : HL7Message_1<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Merged.TriggerEvent_2<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Pharmacy.Merged.ReferencedRecord>>, IInteraction {


        public AddAllergyIntoleranceRequestAccepted() {
        }
    }

}