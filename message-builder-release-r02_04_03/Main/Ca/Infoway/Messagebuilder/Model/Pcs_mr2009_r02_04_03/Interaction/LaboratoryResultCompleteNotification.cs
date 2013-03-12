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
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Mcai_mt700210ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt004999ca;


    /**
     * <summary>Business Name: POLB_IN224200CA: Laboratory Result 
     * Complete Notification</summary>
     * 
     * <p>This interaction is a Result Complete without Receiver 
     * Responsibilities (i.e., the sending system utilizes messages 
     * that do not require application-level responses). This 
     * interaction signals completion of the result as well as 
     * completion of the Filler's Promise for the result</p> 
     * Message: MCCI_MT002100CA.Message Control Act: 
     * MCAI_MT700210CA.ControlActEvent --> Payload: 
     * POLB_MT004999CA.ResultInstancePayloadChoice ----> Payload 
     * Choice: POLB_MT004000CA.ResultChoice ----> Payload Choice: 
     * POLB_MT004100CA.ObservationReport ----> Payload Choice: 
     * POLB_MT004200CA.ObservationChoice
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POLB_IN224200CA"})]
    public class LaboratoryResultCompleteNotification : HL7Message_1<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Mcai_mt700210ca.TriggerEvent<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt004999ca.IResultInstancePayloadChoice>>, IInteraction {


        public LaboratoryResultCompleteNotification() {
        }
    }

}