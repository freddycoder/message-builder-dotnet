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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Interaction {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Mcai_mt700210ca;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Mcci_mt000100ca;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Porx_mt990010ca;


    /**
     * <summary>Business Name: POIZ_IN010100CA: Retract 
     * immunization request</summary>
     * 
     * <remarks>Message: MCCI_MT000100CA.Message Control Act: 
     * MCAI_MT700210CA.ControlActEvent --> Payload: 
     * PORX_MT990010CA.ActEvent</remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POIZ_IN010100CA"})]
    public class RetractImmunizationRequest : HL7Message<Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Mcai_mt700210ca.TriggerEvent<Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Porx_mt990010ca.ReferencedRecord>>, IInteraction {


        public RetractImmunizationRequest() {
        }
    }

}