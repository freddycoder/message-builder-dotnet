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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt306011ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Qualified Entity</summary>
     * 
     * <p>Roleclass required to provide additional information for 
     * the person responsible for providing healthcare services</p> 
     * <p>This role describes specific qualifications that may be 
     * held the provider as a result of training or experience, but 
     * having no legal force. Example: a medical degree or diploma. 
     * The current model does not include role attributes such as 
     * name, addr and telecom because there are no known use cases 
     * in this domain where this role is contactable.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPM_MT306011CA.QualifiedEntity"})]
    public class QualifiedEntity : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt306011ca.IRoleChoice {

        private SET<II, Identifier> id;
        private CV code;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private BL equivalenceInd;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Merged.PrinicpalPerson_2 qualifiedPrincipalPerson;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt306011ca.Organization qualificationGrantingOrganization;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Merged.Privilege> responsibleForPrivilege;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt306011ca.RelatedTo> relatedTo;

        public QualifiedEntity() {
            this.id = new SETImpl<II, Identifier>(typeof(IIImpl));
            this.code = new CVImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.equivalenceInd = new BLImpl();
            this.responsibleForPrivilege = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Merged.Privilege>();
            this.relatedTo = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt306011ca.RelatedTo>();
        }
        /**
         * <summary>Business Name: Expertise or Credentials Role 
         * Identifier</summary>
         * 
         * <remarks>Relationship: PRPM_MT306011CA.QualifiedEntity.id 
         * Conformance/Cardinality: REQUIRED (0-10) <p>Required 
         * attribute supports the identification of the healthcare 
         * provider credentials</p> <p>Unique identifier for the 
         * Expertise or Credential.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public ICollection<Identifier> Id {
            get { return this.id.RawSet(); }
        }

        /**
         * <summary>Business Name: Expertise or Credentials Role Type</summary>
         * 
         * <remarks>Relationship: PRPM_MT306011CA.QualifiedEntity.code 
         * Conformance/Cardinality: REQUIRED (1) <p>Populated attribute 
         * supports the identification of the healthcare provider 
         * credentials</p> <p>If Expertise or Credentials are included 
         * in the message, then Role Type Must Exist.</p> <p>A code for 
         * the degree or educational rank that the credential 
         * specifies. May also apply to an Expertise type.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public QualifiedRoleType Code {
            get { return (QualifiedRoleType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Expertise or Credentials Role 
         * Effective Date</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT306011CA.QualifiedEntity.effectiveTime 
         * Conformance/Cardinality: REQUIRED (1) <p>Populated attribute 
         * supports the identification of the healthcare provider 
         * credentials</p> <p>If Expertise or Credentials are included 
         * in the message, then Role Effective Date Must Exist</p> 
         * <p>The effective date of the provider expertise or 
         * credentials in the healthcare provider role.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: Credentials Equivalency Flag</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT306011CA.QualifiedEntity.equivalenceInd 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>The PRS uses a 
         * flag to indicate whether a credential for a provider 
         * obtained from an institution that is not a certified 
         * Canadian institution, is equivalent to a similar credential 
         * that is awarded by a certified Canadian institution.</p> 
         * <p>Colleges and other sources maintain information about 
         * equivalency of credentials in their own records, and this 
         * information is messaged. Therefore, there is benefit to 
         * adding the equivalency flag to message the fact that the 
         * source regards a given credential as equivalent to a local 
         * one.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"equivalenceInd"})]
        public bool? EquivalenceInd {
            get { return this.equivalenceInd.Value; }
            set { this.equivalenceInd.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PRPM_MT306011CA.QualifiedEntity.qualifiedPrincipalPerson</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"qualifiedPrincipalPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Merged.PrinicpalPerson_2 QualifiedPrincipalPerson {
            get { return this.qualifiedPrincipalPerson; }
            set { this.qualifiedPrincipalPerson = value; }
        }

        /**
         * <summary>Relationship: 
         * PRPM_MT306011CA.QualifiedEntity.qualificationGrantingOrganization</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"qualificationGrantingOrganization"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt306011ca.Organization QualificationGrantingOrganization {
            get { return this.qualificationGrantingOrganization; }
            set { this.qualificationGrantingOrganization = value; }
        }

        /**
         * <summary>Relationship: 
         * PRPM_MT306011CA.ResponsibleParty.privilege</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleFor/privilege"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Merged.Privilege> ResponsibleForPrivilege {
            get { return this.responsibleForPrivilege; }
        }

        /**
         * <summary>Relationship: PRPM_MT306011CA.RoleChoice.relatedTo</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-100)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"relatedTo"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pr.Prpm_mt306011ca.RelatedTo> RelatedTo {
            get { return this.relatedTo; }
        }

    }

}