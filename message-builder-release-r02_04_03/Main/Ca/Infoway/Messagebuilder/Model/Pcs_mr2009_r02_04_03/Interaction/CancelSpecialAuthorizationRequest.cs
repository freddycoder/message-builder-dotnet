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
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Mcai_mt700211ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged;


    /**
     * <summary>Business Name: FICR_IN400005CA: Cancel Special 
     * Authorization Request</summary>
     * 
     * <p>The Cancel Special Authorization Request is submitted to 
     * cancel processing of a previously submitted Special 
     * Authorization Request. This interaction is typically 
     * submitted when a provider determines that the requirement 
     * for an SA Request is no longer appropriate.</p> Message: 
     * MCCI_MT002100CA.Message Control Act: 
     * MCAI_MT700211CA.ControlActEvent --> Payload: 
     * COMT_MT001101CA.ActRequest
     */
    [Hl7PartTypeMappingAttribute(new string[] {"FICR_IN400005CA"})]
    public class CancelSpecialAuthorizationRequest : HL7Message_1<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Mcai_mt700211ca.TriggerEvent<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.ActRequest>>, IInteraction {


        public CancelSpecialAuthorizationRequest() {
        }
    }

}