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
 * Author:        $LastChangedBy: jmis $
 * Last modified: $LastChangedDate: 2015-09-15 11:09:53 -0400 (Tue, 15 Sep 2015) $
 * Revision:      $LastChangedRevision: 9796 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt500201ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Domainvalue;
    using System.Collections.Generic;


    /**
     * <summary>FICR_MT510201CA.CoveredPartyAsPatient: (no business 
     * name)</summary>
     * 
     * <p>Covered Person Identifier</p><p>(Assigned by carrier - 
     * root of OID)</p><p>= Subscriber+Dependents</p><p>Can be a 
     * single covered party,</p><p>an organization, an 
     * animal</p><p>or a group of patients</p><p>and/or a group of 
     * animals.</p><p>Covered party may be a patient who for the 
     * purposes of the invoice is a covered party.</p> 
     * FICR_MT610201CA.CoveredPartyAsPatient: (no business name) 
     * <p>Covered Person Identifier</p><p>(Assigned by carrier - 
     * root of OID)</p><p>= Subscriber+Dependents</p><p>Can be a 
     * single covered party,</p><p>an organization, an 
     * animal</p><p>or a group of patients</p><p>and/or a group of 
     * animals.</p><p>Covered party may be a patient who for the 
     * purposes of the invoice is a covered party.</p> 
     * FICR_MT500201CA.CoveredPartyAsPatient: (no business name) 
     * <p>Covered Person Identifier</p><p>(Assigned by carrier - 
     * root of OID)</p><p>= Subscriber+Dependents</p><p>Can be a 
     * single covered party,</p><p>an organization, an 
     * animal</p><p>or a group of patients</p><p>and/or a group of 
     * animals.</p><p>Covered party may be a patient who for the 
     * purposes of the invoice is a covered party.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT500201CA.CoveredPartyAsPatient","FICR_MT510201CA.CoveredPartyAsPatient","FICR_MT610201CA.CoveredPartyAsPatient"})]
    public class CoveredPartyAsPatient : MessagePartBean {

        private II id;
        private CV code;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.PersonalRelationship indirectAuthorityPersonalRelationship;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt500201ca.ICoveredPartyAsPatientChoice coveredPartyAsPatientChoice;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.Subject> subjectOf;

        public CoveredPartyAsPatient() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.subjectOf = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.Subject>();
        }
        /**
         * <summary>Business Name: CoveredPartyIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: CoveredPartyIdentifier 
         * Relationship: FICR_MT510201CA.CoveredPartyAsPatient.id 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: CoveredPartyIdentifier Relationship: 
         * FICR_MT610201CA.CoveredPartyAsPatient.id 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: CoveredPartyIdentifier Relationship: 
         * FICR_MT500201CA.CoveredPartyAsPatient.id 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: RelationshipToPolicyHolder</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT510201CA.CoveredPartyAsPatient.code 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: RelationshipToPolicyHolder Relationship: 
         * FICR_MT610201CA.CoveredPartyAsPatient.code 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: CoveredPartyRelationshipToPolicyHolder Relationship: 
         * FICR_MT500201CA.CoveredPartyAsPatient.code 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public CoveredPartyRoleType Code {
            get { return (CoveredPartyRoleType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT510201CA.IndirectAuthorithyOver.personalRelationship 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * FICR_MT610201CA.IndirectAuthorithyOver.personalRelationship 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * FICR_MT500201CA.IndirectAuthorithyOver.personalRelationship 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"indirectAuthority/personalRelationship"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.PersonalRelationship IndirectAuthorityPersonalRelationship {
            get { return this.indirectAuthorityPersonalRelationship; }
            set { this.indirectAuthorityPersonalRelationship = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT500201CA.CoveredPartyAsPatient.coveredPartyAsPatientChoice 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"coveredPartyAsPatientChoice"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt500201ca.ICoveredPartyAsPatientChoice CoveredPartyAsPatientChoice {
            get { return this.coveredPartyAsPatientChoice; }
            set { this.coveredPartyAsPatientChoice = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT500201CA.CoveredPartyAsPatient.subjectOf 
         * Conformance/Cardinality: REQUIRED (0-10)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.Subject> SubjectOf {
            get { return this.subjectOf; }
        }

    }

}