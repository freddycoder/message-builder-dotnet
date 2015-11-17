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
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Mcci_mt002300ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Mfmi_mt700746ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt306050ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt306051ca;


    /**
     * <summary>Business Name: PRPM_IN306051CA: Provider Associated 
     * Identifiers Query Response</summary>
     * 
     * <p>This interaction is used to respond to a Provider 
     * Associated Identifiers Query interaction and will contain 
     * the requested records from the provider registry system.</p> 
     * Message: MCCI_MT002300CA.Message Control Act: 
     * MFMI_MT700746CA.ControlActEvent --> Payload: 
     * PRPM_MT306051CA.RoleChoice ----> Payload Choice: 
     * PRPM_MT306051CA.AssignedEntity ----> Payload Choice: 
     * PRPM_MT306051CA.QualifiedEntity ----> Payload Choice: 
     * PRPM_MT306051CA.HealthCareProvider --> Payload: 
     * PRPM_MT306050CA.ParameterList
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPM_IN306051CA"})]
    public class ProviderAssociatedIdentifiersQueryResponse : HL7Message<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Mfmi_mt700746ca.TriggerEvent<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt306050ca.ParameterList,Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt306051ca.IRoleChoice>>, IInteraction {


        public ProviderAssociatedIdentifiersQueryResponse() {
        }
    }

}