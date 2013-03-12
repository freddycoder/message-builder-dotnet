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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Interaction {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Common.Merged;


    /**
     * <summary>Business Name: FICR_IN610102CA: Invoice Results, Rx</summary>
     * 
     * <p>The sender sends an Invoice Adjudication Results message 
     * containing the completed results of an Invoice Adjudication 
     * Request for Pharmacy services and/or products.</p> Message: 
     * MCCI_MT002300CA.Message Control Act: 
     * MCAI_MT700227CA.ControlActEvent --> Payload: 
     * FICR_MT610201CA.PaymentIntent
     */
    [Hl7PartTypeMappingAttribute(new string[] {"FICR_IN610102CA"})]
    public class InvoiceResultsRx : HL7Message_1<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Common.Merged.TriggerEvent_1<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Merged.PaymentIntent>>, IInteraction {


        public InvoiceResultsRx() {
        }
    }

}