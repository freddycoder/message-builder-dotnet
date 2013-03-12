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
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pharmacy.Porx_mt060080ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pharmacy.Porx_mt060100ca;


    /**
     * <summary>Business Name: PORX_IN060280CA: Medication 
     * prescription fills query response</summary>
     * 
     * <p>Returns basic information about all medication dispenses 
     * performed against a particular prescription referenced by 
     * id.</p> Message: MCCI_MT002300CA.Message Control Act: 
     * QUQI_MT120006CA.ControlActEvent --> Payload: 
     * PORX_MT060100CA.MedicationDispense --> Payload: 
     * PORX_MT060080CA.ParameterList
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_IN060280CA"})]
    public class MedicationPrescriptionFillsQueryResponse : HL7Message_1<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Merged.TriggerEvent_5<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pharmacy.Porx_mt060100ca.Dispense,Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pharmacy.Porx_mt060080ca.GenericQueryParameters>>, IInteraction {


        public MedicationPrescriptionFillsQueryResponse() {
        }
    }

}