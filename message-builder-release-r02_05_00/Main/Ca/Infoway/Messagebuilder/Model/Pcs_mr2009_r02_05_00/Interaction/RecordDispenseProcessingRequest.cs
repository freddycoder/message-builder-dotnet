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
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Mcai_mt700210ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Mcci_mt002100ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pharmacy.Porx_mt020070ca;


    /**
     * <summary>Business Name: PORX_IN020190CA: Record dispense 
     * processing request</summary>
     * 
     * <p>Requests the recording in the patient record that a 
     * medication dispense processing (drug prep, packaging and 
     * contraindication checking) for a particular quantity of 
     * medication against a script has been performed and the 
     * medication is awaiting pickup</p> Message: 
     * MCCI_MT002100CA.Message Control Act: 
     * MCAI_MT700210CA.ControlActEvent --> Payload: 
     * PORX_MT020070CA.MedicationDispense
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_IN020190CA"})]
    public class RecordDispenseProcessingRequest : HL7Message<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Mcai_mt700210ca.TriggerEvent<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pharmacy.Porx_mt020070ca.PrescriptionDispense>>, IInteraction {


        public RecordDispenseProcessingRequest() {
        }
    }

}