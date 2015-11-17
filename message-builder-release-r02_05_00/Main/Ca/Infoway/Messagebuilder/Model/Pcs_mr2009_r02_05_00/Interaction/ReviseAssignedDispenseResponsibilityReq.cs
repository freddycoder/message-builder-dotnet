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
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Mcai_mt700211ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Mcci_mt002100ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pharmacy.Porx_mt010140ca;


    /**
     * <summary>Business Name: PORX_IN010100CA: Revise assigned 
     * dispense responsibility req</summary>
     * 
     * <p>Requests that responsibility for filling the dispense 
     * portion of a script be changed to specified facility. Null 
     * flavor=&quot;&quot;Not Applicable&quot;&quot;: no facility 
     * has responsibility. Null 
     * flavor=&quot;&quot;Unknown&quot;&quot;: transferred outside 
     * the list of registered facilities.</p> Message: 
     * MCCI_MT002100CA.Message Control Act: 
     * MCAI_MT700211CA.ControlActEvent --> Payload: 
     * PORX_MT010140CA.SupplyRequest
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_IN010100CA"})]
    public class ReviseAssignedDispenseResponsibilityReq : HL7Message<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Mcai_mt700211ca.TriggerEvent<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pharmacy.Porx_mt010140ca.DispenseInstructions>>, IInteraction {


        public ReviseAssignedDispenseResponsibilityReq() {
        }
    }

}