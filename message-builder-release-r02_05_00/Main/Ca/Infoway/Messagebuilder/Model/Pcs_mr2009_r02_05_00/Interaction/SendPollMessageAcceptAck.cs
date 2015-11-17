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
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Mcci_mt002200ca;


    /**
     * <summary>Business Name: MCCI_IN100003CA: Send Poll Message 
     * Accept Ack</summary>
     * 
     * <p>Communication level acknowledgement that polled message 
     * received. Note: This interaction is invoked, where 
     * appropriate, as a receiver responsibility.</p> Message: 
     * MCCI_MT002200CA.Message
     */
    [Hl7PartTypeMappingAttribute(new string[] {"MCCI_IN100003CA"})]
    public class SendPollMessageAcceptAck : HL7Message, IInteraction {


        public SendPollMessageAcceptAck() {
        }
    }

}