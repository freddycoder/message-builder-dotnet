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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Interaction {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Si.Comt_mt300002ca;


    /**
     * <summary>Business Name: COMT_IN300201CA: Patient note query</summary>
     * 
     * <p>Requests retrieval of the notes that have been recorded 
     * against a particular patient, potentially filtered by note 
     * type and/or date.</p> Message: MCCI_MT002100CA.Message 
     * Control Act: QUQI_MT020000CA.ControlActEvent --> Payload: 
     * COMT_MT300002CA.ParameterList
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COMT_IN300201CA"})]
    public class PatientNoteQuery : HL7Message_1<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Merged.TriggerEvent_4<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Si.Comt_mt300002ca.GenericQueryParameters>>, IInteraction {


        public PatientNoteQuery() {
        }
    }

}