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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Pome_mt010040ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt270010ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Recommended Administration 
     * Instructions</summary>
     * 
     * <p>Gives guidance to prescribers on how the drug might 
     * be/should be used</p> <p>This comprises the route of 
     * administration, maximum/minimum daily dose, and overall use 
     * instructions for the drug.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POME_MT010040CA.AdministrationGuideline"})]
    public class RecommendedAdministrationInstructions : MessagePartBean {

        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Pome_mt010040ca.Patient subjectPatient;
        private ST authorAssignedEntityAssignedOrganizationName;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt270010ca.AdministrationInstructions> optionDosageInstruction;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.BecauseOf> reason;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Pome_mt010040ca.PatientCharacteristics> preconditionObservationEventCriterion;

        public RecommendedAdministrationInstructions() {
            this.authorAssignedEntityAssignedOrganizationName = new STImpl();
            this.optionDosageInstruction = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt270010ca.AdministrationInstructions>();
            this.reason = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.BecauseOf>();
            this.preconditionObservationEventCriterion = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Pome_mt010040ca.PatientCharacteristics>();
        }
        /**
         * <summary>Relationship: POME_MT010040CA.Subject.patient</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject/patient"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Pome_mt010040ca.Patient SubjectPatient {
            get { return this.subjectPatient; }
            set { this.subjectPatient = value; }
        }

        /**
         * <summary>Business Name: Recommending Authority Name</summary>
         * 
         * <remarks>Relationship: POME_MT010040CA.Organization4.name 
         * Conformance/Cardinality: MANDATORY (1) <p>The source of a 
         * recommendation may influence prescriber's willingness to use 
         * the recommended dose and is therefore mandatory</p> 
         * <p>Indicates the name of the organization or agency that 
         * created the dosage recommendation</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author/assignedEntity/assignedOrganization/name"})]
        public String AuthorAssignedEntityAssignedOrganizationName {
            get { return this.authorAssignedEntityAssignedOrganizationName.Value; }
            set { this.authorAssignedEntityAssignedOrganizationName.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * POME_MT010040CA.Option.dosageInstruction</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"option/dosageInstruction"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt270010ca.AdministrationInstructions> OptionDosageInstruction {
            get { return this.optionDosageInstruction; }
        }

        /**
         * <summary>Relationship: 
         * POME_MT010040CA.AdministrationGuideline.reason</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-250)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reason"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.BecauseOf> Reason {
            get { return this.reason; }
        }

        /**
         * <summary>Relationship: 
         * POME_MT010040CA.Precondition.observationEventCriterion</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"precondition/observationEventCriterion"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Pome_mt010040ca.PatientCharacteristics> PreconditionObservationEventCriterion {
            get { return this.preconditionObservationEventCriterion; }
        }

    }

}