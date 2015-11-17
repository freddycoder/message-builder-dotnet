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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt301010ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged;


    /**
     * <summary>Business Name: Inform Request</summary>
     * 
     * <p>The use case for including this class is for requesting 
     * routing of health information where the code equals the 
     * information type. Examples include ECG results, DI - 
     * Diagnostic Image interpretation reports, Lab Test Results 
     * Transcripts</p> <p>Class communicates request for routing of 
     * information to a provider or service delivery location.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPM_MT301010CA.InformRequest"})]
    public class InformRequest : MessagePartBean {

        private CV code;
        private CV subjectModeCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.ServiceDeliveryLocation subjectServiceDeliveryLocation;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt301010ca.IChoice indirectTargetChoice;

        public InformRequest() {
            this.code = new CVImpl();
            this.subjectModeCode = new CVImpl();
        }
        /**
         * <summary>Business Name: Inform Request Code</summary>
         * 
         * <remarks>Relationship: PRPM_MT301010CA.InformRequest.code 
         * Conformance/Cardinality: REQUIRED (1) <p>Populated - Allows 
         * providers to request that specific document(s) be routed 
         * from an SDL to them.</p> <p>A coded value denoting a 
         * specific document type that a provider expresses to have 
         * routed to them from the Service Delivery Location to which 
         * they are associated.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActInformRequestType Code {
            get { return (ActInformRequestType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Service Delivery Location 
         * Participation Mode</summary>
         * 
         * <remarks>Relationship: PRPM_MT301010CA.Subject.modeCode 
         * Conformance/Cardinality: REQUIRED (1) <p>Populated</p> <p>A 
         * code specifying the modality by which the Entity playing the 
         * Role is participating in the Act.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject/modeCode"})]
        public ParticipationMode SubjectModeCode {
            get { return (ParticipationMode) this.subjectModeCode.Value; }
            set { this.subjectModeCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PRPM_MT301010CA.Subject.serviceDeliveryLocation</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject/serviceDeliveryLocation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.ServiceDeliveryLocation SubjectServiceDeliveryLocation {
            get { return this.subjectServiceDeliveryLocation; }
            set { this.subjectServiceDeliveryLocation = value; }
        }

        /**
         * <summary>Relationship: PRPM_MT301010CA.IndirectTarget.choice</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"indirectTarget/choice"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt301010ca.IChoice IndirectTargetChoice {
            get { return this.indirectTargetChoice; }
            set { this.indirectTargetChoice = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.ServiceDeliveryLocation IndirectTargetChoiceAsServiceDeliveryLocation {
            get { return this.indirectTargetChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.ServiceDeliveryLocation ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.ServiceDeliveryLocation) this.indirectTargetChoice : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.ServiceDeliveryLocation) null; }
        }
        public bool HasIndirectTargetChoiceAsServiceDeliveryLocation() {
            return (this.indirectTargetChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.ServiceDeliveryLocation);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt301010ca.HealthcareProvider IndirectTargetChoiceAsHealthCareProvider {
            get { return this.indirectTargetChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt301010ca.HealthcareProvider ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt301010ca.HealthcareProvider) this.indirectTargetChoice : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt301010ca.HealthcareProvider) null; }
        }
        public bool HasIndirectTargetChoiceAsHealthCareProvider() {
            return (this.indirectTargetChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt301010ca.HealthcareProvider);
        }

    }

}