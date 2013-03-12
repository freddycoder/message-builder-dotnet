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
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt001999ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt330000ca;


    /**
     * <summary>Business Name: POLB_IN361000CA: Find Laboratory 
     * Order Response</summary>
     * 
     * <p>This interaction is used in response to a lab order 
     * query.</p> Message: MCCI_MT002300CA.Message Control Act: 
     * QUQI_MT120006CA.ControlActEvent --> Payload: 
     * POLB_MT001999CA.RequestChoice ----> Payload Choice: 
     * POLB_MT001999CA.PlacerGroup ----> Payload Choice: 
     * POLB_MT001999CA.BatteryRequest ----> Payload Choice: 
     * POLB_MT001999CA.ObservationRequest --> Payload: 
     * POLB_MT330000CA.ParameterList
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POLB_IN361000CA"})]
    public class FindLaboratoryOrderResponse : HL7Message_1<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.TriggerEvent_6<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt001999ca.IRequestChoice,Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt330000ca.ParameterList>>, IInteraction {


        public FindLaboratoryOrderResponse() {
        }
    }

}