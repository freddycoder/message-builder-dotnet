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
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged;


    /**
     * <summary>Business Name: POLB_IN134001CA: Result Reject 
     * Response</summary>
     * 
     * <p>This interaction is a Result Reject Response. This is 
     * used by the receiver to reject a result</p> Message: 
     * MCCI_MT002300CA.Message Control Act: 
     * MCAI_MT700226CA.ControlActEvent --> Payload: 
     * COMT_MT001103CA.ActEvent
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POLB_IN134001CA"})]
    public class ResultRejectResponse : HL7Message_1<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.TriggerEvent_1<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.ActRequest>>, IInteraction {


        public ResultRejectResponse() {
        }
    }

}