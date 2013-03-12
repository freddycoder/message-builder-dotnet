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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Interaction {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Merged;


    /**
     * <summary>Business Name: FICR_IN620102CA: Invoice Nullify 
     * Request, Rx</summary>
     * 
     * <p>The sender sends an Invoice Nullify Request message to 
     * request the nullification of a previously submitted Invoice 
     * Adjudication Request for Pharmacy services and/or 
     * products.</p> Message: MCCI_MT002100CA.Message Control Act: 
     * MCAI_MT700211CA.ControlActEvent --> Payload: 
     * FICR_MT620000CA.InvoiceElementGroup
     */
    [Hl7PartTypeMappingAttribute(new string[] {"FICR_IN620102CA"})]
    public class InvoiceNullifyRequestRx : HL7Message_1<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Merged.TriggerEvent_1<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Merged.SubmittedInvoiceGroup>>, IInteraction {


        public InvoiceNullifyRequestRx() {
        }
    }

}