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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Interaction {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Mcai_mt700220ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Mcci_mt000300ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Porx_mt990020ca;


    /**
     * <summary>Business Name: PORX_IN010120CA: Revise assigned 
     * dispense responsibility req ref</summary>
     * 
     * <p>Indicates that the request to change the facility 
     * responsible for fulfilling the dispense portion of a 
     * prescription has been refused.</p> Message: 
     * MCCI_MT000300CA.Message Control Act: 
     * MCAI_MT700220CA.ControlActEvent --> Payload: 
     * PORX_MT990020CA.ActRequest
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_IN010120CA"})]
    public class ReviseAssignedDispenseResponsibilityReqRef : HL7Message<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Mcai_mt700220ca.TriggerEvent<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Porx_mt990020ca.ReferencedRecord>>, IInteraction {


        public ReviseAssignedDispenseResponsibilityReqRef() {
        }
    }

}