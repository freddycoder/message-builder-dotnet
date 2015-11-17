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
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Comt_mt001101ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Mcai_mt700226ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Mcci_mt002300ca;


    /**
     * <summary>Business Name: PORX_IN010070CA: Record refusal to 
     * dispense request accepted</summary>
     * 
     * <p>Indicates that the requested &quot;&quot;refusal to 
     * fill&quot;&quot; note has been recorded against the 
     * identified prescription.</p> Message: 
     * MCCI_MT002300CA.Message Control Act: 
     * MCAI_MT700226CA.ControlActEvent --> Payload: 
     * COMT_MT001101CA.ActRequest
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_IN010070CA"})]
    public class RecordRefusalToDispenseRequestAccepted : HL7Message<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Mcai_mt700226ca.TriggerEvent<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Comt_mt001101ca.ReferencedRecord>>, IInteraction {


        public RecordRefusalToDispenseRequestAccepted() {
        }
    }

}