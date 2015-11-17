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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Interaction {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Common.Mcci_mt002100ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Common.Mfmi_mt700717ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Cr.Prpa_mt101003ab;


    /**
     * <summary>Business Name: PRPA_IN101999AB: AB Person Nullified 
     * Notification</summary>
     * 
     * <p>This interaction has been constrained for use in Alberta. 
     * This interaction occurs after an erroneously entered person 
     * record is nullified in a person registry. An informer sends 
     * to a tracker enough information to identify the nullified 
     * record.</p> Message: MCCI_MT002100CA.Message Control Act: 
     * MFMI_MT700717CA.ControlActEvent --> Payload: 
     * PRPA_MT101003AB.IdentifiedEntity
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPA_IN101999AB"})]
    public class ABPersonNullifiedNotification : HL7Message<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Common.Mfmi_mt700717ca.TriggerEvent<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Cr.Prpa_mt101003ab.IdentifiedPerson>>, IInteraction {


        public ABPersonNullifiedNotification() {
        }
    }

}