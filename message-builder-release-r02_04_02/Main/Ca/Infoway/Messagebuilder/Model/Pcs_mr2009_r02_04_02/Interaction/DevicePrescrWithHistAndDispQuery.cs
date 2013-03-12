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


    /**
     * <summary>Business Name: PORX_IN060010CA: Device prescr. with 
     * hist. and disp. query</summary>
     * 
     * <p>Requests retrieval of detailed information about a single 
     * identified device prescription, including history of changes 
     * and all fulfilling dispense events.</p> Message: 
     * MCCI_MT002100CA.Message Control Act: 
     * QUQI_MT020000CA.ControlActEvent --> Payload: 
     * PORX_MT060280CA.ParameterList
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_IN060010CA"})]
    public class DevicePrescrWithHistAndDispQuery : HL7Message_1<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.TriggerEvent_5<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Merged.DrugPrescriptionDetailQueryParameters>>, IInteraction {


        public DevicePrescrWithHistAndDispQuery() {
        }
    }

}