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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt600201ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Domainvalue;
    using System.Collections.Generic;


    /**
     * <p>Covered Person Identifier</p><p>(Assigned by carrier - 
     * root of OID)</p><p>= Subscriber+Dependents</p><p>Can be a 
     * single covered party,</p><p>an organization, an 
     * animal</p><p>or a group of patients</p><p>and/or a group of 
     * animals.</p><p>Covered party may be a patient who for the 
     * purposes of the invoice is a covered party.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT600201CA.CoveredPartyAsPatient"})]
    public class CoveredPartyAsPatient : MessagePartBean {

        private II id;
        private CV code;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt600201ca.ICoveredPartyAsPatientChoice coveredPartyAsPatientChoice;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.Subject> subjectOf;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.PersonalRelationship indirectAuthorityPersonalRelationship;

        public CoveredPartyAsPatient() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.subjectOf = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.Subject>();
        }
        /**
         * <summary>Business Name: Covered Party Identifier</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT600201CA.CoveredPartyAsPatient.id 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: Covered Party Relationship to Policy 
         * Holder</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT600201CA.CoveredPartyAsPatient.code 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public CoveredPartyRoleType Code {
            get { return (CoveredPartyRoleType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT600201CA.CoveredPartyAsPatient.coveredPartyAsPatientChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"coveredPartyAsPatientChoice"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt600201ca.ICoveredPartyAsPatientChoice CoveredPartyAsPatientChoice {
            get { return this.coveredPartyAsPatientChoice; }
            set { this.coveredPartyAsPatientChoice = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt600201ca.CoveredPartyAsPatientPerson CoveredPartyAsPatientChoiceAsCoveredPartyAsPatientPerson {
            get { return this.coveredPartyAsPatientChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt600201ca.CoveredPartyAsPatientPerson ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt600201ca.CoveredPartyAsPatientPerson) this.coveredPartyAsPatientChoice : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt600201ca.CoveredPartyAsPatientPerson) null; }
        }
        public bool HasCoveredPartyAsPatientChoiceAsCoveredPartyAsPatientPerson() {
            return (this.coveredPartyAsPatientChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt600201ca.CoveredPartyAsPatientPerson);
        }

        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt600201ca.CoveredPartyAsPatientAnimal CoveredPartyAsPatientChoiceAsCoveredPartyAsPatientAnimal {
            get { return this.coveredPartyAsPatientChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt600201ca.CoveredPartyAsPatientAnimal ? (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt600201ca.CoveredPartyAsPatientAnimal) this.coveredPartyAsPatientChoice : (Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt600201ca.CoveredPartyAsPatientAnimal) null; }
        }
        public bool HasCoveredPartyAsPatientChoiceAsCoveredPartyAsPatientAnimal() {
            return (this.coveredPartyAsPatientChoice is Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt600201ca.CoveredPartyAsPatientAnimal);
        }

        /**
         * <summary>Relationship: 
         * FICR_MT600201CA.CoveredPartyAsPatient.subjectOf</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-10)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.Subject> SubjectOf {
            get { return this.subjectOf; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT600201CA.IndirectAuthorithyOver.personalRelationship</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"indirectAuthority/personalRelationship"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.PersonalRelationship IndirectAuthorityPersonalRelationship {
            get { return this.indirectAuthorityPersonalRelationship; }
            set { this.indirectAuthorityPersonalRelationship = value; }
        }

    }

}