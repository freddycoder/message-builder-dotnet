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
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Cr.Prpa_mt101101ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Cr.Prpa_mt101102ca;


    /**
     * <summary>Business Name: PRPA_IN101102CA: Get Demographics 
     * Query Response</summary>
     * 
     * <p>This interaction sends a response from a Person Registry 
     * with demographic information for a specific person 
     * identifier.</p> Message: MCCI_MT002300CA.Message Control 
     * Act: MFMI_MT700746CA.ControlActEvent --> Payload: 
     * PRPA_MT101102CA.IdentifiedEntity --> Payload: 
     * PRPA_MT101101CA.ParameterList
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPA_IN101102CA"})]
    public class GetDemographicsQueryResponse : HL7Message<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Mfmi_mt700746ca.TriggerEvent<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Cr.Prpa_mt101101ca.ParameterList,Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Cr.Prpa_mt101102ca.IdentifiedPerson>>, IInteraction {


        public GetDemographicsQueryResponse() {
        }
    }

}