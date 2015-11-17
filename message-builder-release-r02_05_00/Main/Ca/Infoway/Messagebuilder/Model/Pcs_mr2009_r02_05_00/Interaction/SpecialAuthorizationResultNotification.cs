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
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Claims.Ficr_mt400003ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Mcai_mt700211ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Mcci_mt002100ca;


    /**
     * <summary>Business Name: FICR_IN400011CA: Special 
     * Authorization Result Notification</summary>
     * 
     * <p>Indicates that adjudication of a previously pended 
     * Special Authorization has been completed. The Special 
     * Authorization Request status will either be 
     * &quot;&quot;active&quot;&quot; if approved or 
     * &quot;&quot;aborted&quot;&quot; if not approved.</p> 
     * Message: MCCI_MT002100CA.Message Control Act: 
     * MCAI_MT700211CA.ControlActEvent --> Payload: 
     * FICR_MT400003CA.SpecialAuthorizationRequest
     */
    [Hl7PartTypeMappingAttribute(new string[] {"FICR_IN400011CA"})]
    public class SpecialAuthorizationResultNotification : HL7Message<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Mcai_mt700211ca.TriggerEvent<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Claims.Ficr_mt400003ca.SpecialAuthorizationRequest>>, IInteraction {


        public SpecialAuthorizationResultNotification() {
        }
    }

}