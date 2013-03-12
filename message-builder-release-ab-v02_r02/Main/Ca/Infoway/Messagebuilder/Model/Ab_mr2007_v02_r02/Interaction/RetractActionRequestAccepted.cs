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
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Interaction {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Mcci_mt002300ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Merged;


    /**
     * <summary>Business Name: COMT_IN600002CA: Retract action 
     * request accepted</summary>
     * 
     * <remarks>Message: MCCI_MT002300CA.Message Control Act: 
     * MCAI_MT700226CA.ControlActEvent --> Payload: 
     * COMT_MT001103CA.ActEvent</remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COMT_IN600002CA"})]
    public class RetractActionRequestAccepted : HL7Message<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Merged.TriggerEvent_1<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Merged.ReferencedRecord>>, IInteraction {


        public RetractActionRequestAccepted() {
        }
    }

}