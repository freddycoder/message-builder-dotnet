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
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Mfmi_mt700746ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Cr.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Cr.Prpa_mt101103ca;


    /**
     * <summary>Business Name: PRPA_IN101104CA: Find Candidates 
     * Response</summary>
     * 
     * <p>This interaction returns a list of candidates from a 
     * Person Registry that match a particular set of person 
     * demographics. The response may also include a score 
     * indicating the probability of match for each candidate.</p> 
     * Message: MCCI_MT002300CA.Message Control Act: 
     * MFMI_MT700746CA.ControlActEvent --> Payload: 
     * PRPA_MT101104CA.IdentifiedEntity --> Payload: 
     * PRPA_MT101103CA.ParameterList
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPA_IN101104CA"})]
    public class FindCandidatesResponse : HL7Message_1<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Mfmi_mt700746ca.TriggerEvent<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Cr.Prpa_mt101103ca.ParameterList,Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Cr.Merged.IdentifiedPerson>>, IInteraction {


        public FindCandidatesResponse() {
        }
    }

}