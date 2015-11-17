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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Ficr_mt490101ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090108ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT490101CA.SpecialAuthorizationRequest"})]
    public class SpecialAuthorizationRequest : MessagePartBean {

        private II id;
        private CV code;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090108ca.HealthcareWorker authorAssignedEntity;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.Subject5> subject1;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Merged.ISpecialAuthorizationChoice_1 subject2SpecialAuthorizationChoice;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Merged.SpecialAuthorization fulfillmentSpecialAuthorization;

        public SpecialAuthorizationRequest() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.subject1 = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.Subject5>();
        }
        /**
         * <summary>Business Name: Special Authorization Request ID</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT490101CA.SpecialAuthorizationRequest.id 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: Special Authorization Request Type</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT490101CA.SpecialAuthorizationRequest.code 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActSpecialAuthorizationCode Code {
            get { return (ActSpecialAuthorizationCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT490101CA.Author2.assignedEntity</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt090108ca.HealthcareWorker AuthorAssignedEntity {
            get { return this.authorAssignedEntity; }
            set { this.authorAssignedEntity = value; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT490101CA.SpecialAuthorizationRequest.subject1</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-20)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject1"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.Subject5> Subject1 {
            get { return this.subject1; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT490101CA.Subject3.specialAuthorizationChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject2/specialAuthorizationChoice"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Merged.ISpecialAuthorizationChoice_1 Subject2SpecialAuthorizationChoice {
            get { return this.subject2SpecialAuthorizationChoice; }
            set { this.subject2SpecialAuthorizationChoice = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.ActiveMedication Subject2SpecialAuthorizationChoiceAsSubstanceAdministration {
            get { return this.subject2SpecialAuthorizationChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.ActiveMedication ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.ActiveMedication) this.subject2SpecialAuthorizationChoice : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.ActiveMedication) null; }
        }
        public bool HasSubject2SpecialAuthorizationChoiceAsSubstanceAdministration() {
            return (this.subject2SpecialAuthorizationChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.ActiveMedication);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Ficr_mt490101ca.DevicePassThru Subject2SpecialAuthorizationChoiceAsDevicePassThru {
            get { return this.subject2SpecialAuthorizationChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Ficr_mt490101ca.DevicePassThru ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Ficr_mt490101ca.DevicePassThru) this.subject2SpecialAuthorizationChoice : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Ficr_mt490101ca.DevicePassThru) null; }
        }
        public bool HasSubject2SpecialAuthorizationChoiceAsDevicePassThru() {
            return (this.subject2SpecialAuthorizationChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Ficr_mt490101ca.DevicePassThru);
        }

        /**
         * <summary>Relationship: 
         * FICR_MT490101CA.InFulfillmentOf.specialAuthorization</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"fulfillment/specialAuthorization"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Merged.SpecialAuthorization FulfillmentSpecialAuthorization {
            get { return this.fulfillmentSpecialAuthorization; }
            set { this.fulfillmentSpecialAuthorization = value; }
        }

    }

}