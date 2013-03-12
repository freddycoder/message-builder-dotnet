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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Interaction {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt004999ca;


    /**
     * <summary>Business Name: POLB_IN364000CA: Laboratory Results 
     * Query Response</summary>
     * 
     * <p>This interaction is used in response to a lab result 
     * query.</p> Message: MCCI_MT002300CA.Message Control Act: 
     * QUQI_MT120006CA.ControlActEvent --> Payload: 
     * POLB_MT004999CA.ResultInstancePayloadChoice ----> Payload 
     * Choice: POLB_MT004000CA.ResultChoice ----> Payload Choice: 
     * POLB_MT004100CA.ObservationReport ----> Payload Choice: 
     * POLB_MT004200CA.ObservationChoice --> Payload: 
     * POLB_MT310000CA.ParameterList
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POLB_IN364000CA"})]
    public class LaboratoryResultsQueryResponse : HL7Message_1<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.TriggerEvent_6<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt004999ca.IResultInstancePayloadChoice,Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Merged.ParameterList>>, IInteraction {


        public LaboratoryResultsQueryResponse() {
        }
    }

}