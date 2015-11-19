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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Interaction {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Mcci_mt002300ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Quqi_mt120006ab;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Immunization.Poiz_mt060140ab;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Immunization.Poiz_mt060150ab;


    /**
     * <summary>Business Name: POIZ_IN020020AB: Immunizations query 
     * response</summary>
     * 
     * <p>Returns detailed information about a patient's 
     * immunizations.</p> Message: MCCI_MT002300CA.Message Control 
     * Act: QUQI_MT120006AB.ControlActEvent --> Payload: 
     * POIZ_MT060150AB.Immunization --> Payload: 
     * POIZ_MT060140AB.ParameterList
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POIZ_IN020020AB"})]
    public class ImmunizationsQueryResponse : HL7Message<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Quqi_mt120006ab.TriggerEvent<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Immunization.Poiz_mt060150ab.Immunizations,Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Immunization.Poiz_mt060140ab.ImmunizationQueryParameters>>, IInteraction {


        public ImmunizationsQueryResponse() {
        }
    }

}