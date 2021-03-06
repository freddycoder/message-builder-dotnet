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
 * Author:        $LastChangedBy: jmis $
 * Last modified: $LastChangedDate: 2015-09-15 10:16:16 -0400 (Tue, 15 Sep 2015) $
 * Revision:      $LastChangedRevision: 9772 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Interaction {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Comt_mt001101ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Mcai_mt700210ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Mcci_mt002100ca;


    /**
     * <summary>Business Name: PORX_IN010060CA: Record refusal to 
     * dispense request</summary>
     * 
     * <p>Requests that the specified &quot;&quot;refusal to 
     * fill&quot;&quot; note be recorded against the identified 
     * prescription.</p> Message: MCCI_MT002100CA.Message Control 
     * Act: MCAI_MT700210CA.ControlActEvent --> Payload: 
     * COMT_MT001101CA.ActRequest
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_IN010060CA"})]
    public class RecordRefusalToDispenseRequest : HL7Message<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Mcai_mt700210ca.TriggerEvent<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Comt_mt001101ca.ReferencedRecord>>, IInteraction {


        public RecordRefusalToDispenseRequest() {
        }
    }

}