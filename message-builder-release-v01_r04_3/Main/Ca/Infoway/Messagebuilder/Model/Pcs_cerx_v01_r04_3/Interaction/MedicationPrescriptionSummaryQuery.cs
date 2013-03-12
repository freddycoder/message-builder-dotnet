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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Interaction {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Quqi_mt020000ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged;


    /**
     * <summary>Business Name: PORX_IN060290CA: Medication 
     * prescription summary query</summary>
     * 
     * <p>Requests retrieval of basic information about all 
     * medication prescriptions provided to a single patient, 
     * optionally filtered by date and status.</p> Message: 
     * MCCI_MT000100CA.Message Control Act: 
     * QUQI_MT020000CA.ControlActEvent --> Payload: 
     * PORX_MT060130CA.ParameterList
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_IN060290CA"})]
    public class MedicationPrescriptionSummaryQuery : HL7Message_1<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Quqi_mt020000ca.TriggerEvent<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Merged.GenericQueryParameters>>, IInteraction {


        public MedicationPrescriptionSummaryQuery() {
        }
    }

}