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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Interaction {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Mcci_mt000300ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Quqi_mt120000ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Porx_mt060240ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Porx_mt060300ca;


    /**
     * <summary>Business Name: PORX_IN060500CA: Unfilled 
     * prescriptions query response</summary>
     * 
     * <p>Returns basic information about all prescriptions 
     * provided to a single patient which have not yet been 
     * dispensed, optionally filtered by date and status.</p> 
     * Message: MCCI_MT000300CA.Message Control Act: 
     * QUQI_MT120000CA.ControlActEvent --> Payload: 
     * PORX_MT060300CA.Prescription ----> Payload Choice: 
     * PORX_MT030040CA.CombinedMedicationRequest ----> Payload 
     * Choice: PORX_MT060060CA.DevicePrescription --> Payload: 
     * PORX_MT060240CA.ParameterList
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_IN060500CA"})]
    public class UnfilledPrescriptionsQueryResponse : HL7Message<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Quqi_mt120000ca.TriggerEvent<Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Porx_mt060300ca.IPrescription,Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Porx_mt060240ca.UnfilledPrescriptionQueryParameters>>, IInteraction {


        public UnfilledPrescriptionsQueryResponse() {
        }
    }

}