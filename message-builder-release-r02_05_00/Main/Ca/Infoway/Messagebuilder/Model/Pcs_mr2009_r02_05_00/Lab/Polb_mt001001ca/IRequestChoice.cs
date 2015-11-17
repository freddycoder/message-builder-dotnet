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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Polb_mt001001ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt011001ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt130001ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt090102ca;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"POLB_MT001001CA.RequestChoice"})]
    public interface IRequestChoice : Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.IFulfillmentChoice, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Polb_mt002000ca.IFulfillmentChoice {

        [Hl7XmlMappingAttribute(new string[] {"informationRecipient/recipientChoice"})]
        IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.IRecipientChoice> InformationRecipientRecipientChoice {
            get;
        }

        [Hl7XmlMappingAttribute(new string[] {"verifier/assignedEntity"})]
        IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt090102ca.HealthcareWorker> VerifierAssignedEntity {
            get;
        }

        [Hl7XmlMappingAttribute(new string[] {"occurrenceOf/actParentPointer"})]
        Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.ParentTest OccurrenceOfActParentPointer {
            get;
            set;
        }

        [Hl7XmlMappingAttribute(new string[] {"pertinentInformation/supportingClinicalObservationEvent"})]
        IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.SupportingClinicalInformation> PertinentInformationSupportingClinicalObservationEvent {
            get;
        }

        [Hl7XmlMappingAttribute(new string[] {"component1/labInitiatedOrderIndicator"})]
        Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.LabInitiatedOrderIndicator Component1LabInitiatedOrderIndicator {
            get;
            set;
        }

        [Hl7XmlMappingAttribute(new string[] {"component2/referralRedirectIndicator"})]
        Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.ReferralRedirectIndicator Component2ReferralRedirectIndicator {
            get;
            set;
        }

        [Hl7XmlMappingAttribute(new string[] {"component3/requestSortKey"})]
        Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.OrderSortKey Component3RequestSortKey {
            get;
            set;
        }

        [Hl7XmlMappingAttribute(new string[] {"component4/requestChoice"})]
        IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Polb_mt001001ca.IRequestChoice> Component4RequestChoice {
            get;
        }

        [Hl7XmlMappingAttribute(new string[] {"subjectOf1"})]
        IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.Includes> SubjectOf1 {
            get;
        }

        [Hl7XmlMappingAttribute(new string[] {"subjectOf2/controlActEvent"})]
        Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt130001ca.VersionInformation SubjectOf2ControlActEvent {
            get;
            set;
        }

        [Hl7XmlMappingAttribute(new string[] {"componentOf1/priorActRequest"})]
        Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.PriorTestRequest ComponentOf1PriorActRequest {
            get;
            set;
        }

        [Hl7XmlMappingAttribute(new string[] {"componentOf2/patientCareProvisionEvent"})]
        IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt011001ca.CareCompositions> ComponentOf2PatientCareProvisionEvent {
            get;
        }

    }

}