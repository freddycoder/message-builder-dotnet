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
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged;


    /**
     * <summary>Business Name: REPC_IN000093CA: Patient discharge / 
     * care summary details query rsp</summary>
     * 
     * <p>Returns a specific discharge / care summary record by 
     * id</p> Message: MCCI_MT002300CA.Message Control Act: 
     * QUQI_MT120006CA.ControlActEvent --> Payload: 
     * REPC_MT220003CA.Document --> Payload: 
     * REPC_MT500006CA.ParameterList
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_IN000093CA"})]
    public class PatientDischargeCareSummaryDetailsQueryRsp : HL7Message_1<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.TriggerEvent_6<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.DischargeCareSummary,Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.QueryDefinition>>, IInteraction {


        public PatientDischargeCareSummaryDetailsQueryRsp() {
        }
    }

}