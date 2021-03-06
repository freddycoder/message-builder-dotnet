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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Interaction {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Mcci_mt002100ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Quqi_mt020002ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt310000ca;


    /**
     * <summary>Business Name: POLB_IN354005CA: Request Query Lab 
     * Results Provider or Location</summary>
     * 
     * <p>This interaction is used to query lab results from a lab 
     * system, by location or provider.</p> Message: 
     * MCCI_MT002100CA.Message Control Act: 
     * QUQI_MT020002CA.ControlActEvent --> Payload: 
     * POLB_MT310000CA.ParameterList
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POLB_IN354005CA"})]
    public class RequestQueryLabResultsProviderOrLocation : HL7Message<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Quqi_mt020002ca.TriggerEvent<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt310000ca.ParameterList>>, IInteraction {


        public RequestQueryLabResultsProviderOrLocation() {
        }
    }

}