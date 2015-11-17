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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Ra.Rcmr_mt010001ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt910107ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Ra.Merged;


    /**
     * <summary>Business Name: b:consented to by</summary>
     * 
     * <p>Consent can be provided by the patient or representative 
     * or be overridden by a provider. It is important to know 
     * which occurred for audit purposes.</p> <p>Indicates that the 
     * consent was provided by the patient or representative.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"RCMR_MT010001CA.Author"})]
    public class ConsentedToBy : MessagePartBean {

        private CV modeCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Ra.Merged.IConsenter consenter;

        public ConsentedToBy() {
            this.modeCode = new CVImpl();
        }
        /**
         * <summary>Business Name: Patient Consent Mechanism</summary>
         * 
         * <remarks>Relationship: RCMR_MT010001CA.Author.modeCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Verbal consents 
         * may trigger a higher level of auditing.</p> <p>Indicates 
         * whether the patient's consent is written or verbal.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"modeCode"})]
        public x_PhysicalVerbalParticipationMode ModeCode {
            get { return (x_PhysicalVerbalParticipationMode) this.modeCode.Value; }
            set { this.modeCode.Value = value; }
        }

        /**
         * <summary>Relationship: RCMR_MT010001CA.Author.consenter</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"consenter"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Ra.Merged.IConsenter Consenter {
            get { return this.consenter; }
            set { this.consenter = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Ra.Merged.Patient ConsenterAsPatient {
            get { return this.consenter is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Ra.Merged.Patient ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Ra.Merged.Patient) this.consenter : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Ra.Merged.Patient) null; }
        }
        public bool HasConsenterAsPatient() {
            return (this.consenter is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Ra.Merged.Patient);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt910107ca.RelatedPerson ConsenterAsPersonalRelationship {
            get { return this.consenter is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt910107ca.RelatedPerson ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt910107ca.RelatedPerson) this.consenter : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt910107ca.RelatedPerson) null; }
        }
        public bool HasConsenterAsPersonalRelationship() {
            return (this.consenter is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Coct_mt910107ca.RelatedPerson);
        }

    }

}