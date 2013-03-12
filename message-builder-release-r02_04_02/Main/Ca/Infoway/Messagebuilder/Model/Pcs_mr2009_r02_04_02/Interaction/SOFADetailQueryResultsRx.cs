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
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Qucr_mt830201ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged;


    /**
     * <summary>Business Name: QUCR_IN830102CA: SOFA Detail Query 
     * Results, Rx</summary>
     * 
     * <p>The sender sends a SOFA (Statement of Financial Activity) 
     * Detail Query Response message for Pharmacy services and/or 
     * products.The response is for detailed account activity 
     * information, including references to previously adjudicated 
     * Invoices.</p> Message: MCCI_MT002300CA.Message Control Act: 
     * QUQI_MT120008CA.ControlActEvent --> Payload: 
     * QUCR_MT830201CA.AdjudResultsGroup --> Payload: 
     * QUCR_MT820201CA.ParameterList
     */
    [Hl7PartTypeMappingAttribute(new string[] {"QUCR_IN830102CA"})]
    public class SOFADetailQueryResultsRx : HL7Message_1<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.TriggerEvent_6<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Qucr_mt830201ca.TypeOfSummary,Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.ParameterList_2>>, IInteraction {


        public SOFADetailQueryResultsRx() {
        }
    }

}