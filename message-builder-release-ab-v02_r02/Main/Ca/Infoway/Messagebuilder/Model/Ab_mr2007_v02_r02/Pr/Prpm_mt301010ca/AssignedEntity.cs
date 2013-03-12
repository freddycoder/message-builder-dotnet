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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pr.Prpm_mt301010ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pr.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Assigned Entity</summary>
     * 
     * <p>The role class, assigned entity, captures the critical 
     * information of the provider playing the role of interest. 
     * This includes an identifier for the role, mailing address, 
     * phone number, and the time within which the role is played 
     * (may be open ended). The scoping organization, which may be 
     * omitted if not needed, provides the organizational context 
     * for the entity that actually plays the role. For example, 
     * the role scoper will normally be the party that assigns the 
     * identifier for the role.</p> <p>Roleclass required to 
     * provide additional information for the person responsible 
     * for providing healthcare services within a specific 
     * healthcare setting</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPM_MT301010CA.AssignedEntity"})]
    public class AssignedEntity : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pr.Prpm_mt301010ca.IRoleChoice {

        private IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pr.Merged.Privilege> responsibleForPrivilege;
        private II id;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pr.Prpm_mt301010ca.RelatedTo> relatedTo;
        private CV code;
        private LIST<PN, PersonName> name;
        private LIST<AD, PostalAddress> addr;
        private LIST<TEL, TelecommunicationAddress> telecom;
        private CS statusCode;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pr.Merged.PrinicpalPerson_1 assignedPrincipalPerson;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pr.Prpm_mt301010ca.Organization representedOrganization;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pr.Merged.ActDefinitionOrEventName_1> performanceActDefinitionOrEvent;

        public AssignedEntity() {
            this.responsibleForPrivilege = new List<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pr.Merged.Privilege>();
            this.id = new IIImpl();
            this.relatedTo = new List<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pr.Prpm_mt301010ca.RelatedTo>();
            this.code = new CVImpl();
            this.name = new LISTImpl<PN, PersonName>(typeof(PNImpl));
            this.addr = new LISTImpl<AD, PostalAddress>(typeof(ADImpl));
            this.telecom = new LISTImpl<TEL, TelecommunicationAddress>(typeof(TELImpl));
            this.statusCode = new CSImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.performanceActDefinitionOrEvent = new List<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pr.Merged.ActDefinitionOrEventName_1>();
        }
        /**
         * <summary>Relationship: 
         * PRPM_MT301010CA.ResponsibleParty.privilege</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleFor/privilege"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pr.Merged.Privilege> ResponsibleForPrivilege {
            get { return this.responsibleForPrivilege; }
        }

        /**
         * <summary>Business Name: Functional Role Identifier</summary>
         * 
         * <remarks>Relationship: PRPM_MT301010CA.AssignedEntity.id 
         * Conformance/Cardinality: POPULATED (1) <p>Identifies 
         * specific functional role that a provider may play within an 
         * organization.</p> <p>Populated attribute supports the 
         * identification of the healthcare provider</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Relationship: PRPM_MT301010CA.RoleChoice.relatedTo</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-100)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"relatedTo"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pr.Prpm_mt301010ca.RelatedTo> RelatedTo {
            get { return this.relatedTo; }
        }

        /**
         * <summary>Business Name: Functional Role Type</summary>
         * 
         * <remarks>Relationship: PRPM_MT301010CA.AssignedEntity.code 
         * Conformance/Cardinality: MANDATORY (1) <p>The code 
         * identifying the specific functional role.</p> <p>Mandatory 
         * attribute supports the identification of the healthcare 
         * provider</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public AssignedRoleType Code {
            get { return (AssignedRoleType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Functional Role Name</summary>
         * 
         * <remarks>Relationship: PRPM_MT301010CA.AssignedEntity.name 
         * Conformance/Cardinality: POPULATED (1-5) <p>The 
         * provider&#226;&#128;&#153;s name pertaining to the specific 
         * functional role.</p> <p>Populated attribute supports the 
         * identification of the healthcare provider</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"name"})]
        public IList<PersonName> Name {
            get { return this.name.RawList(); }
        }

        /**
         * <summary>Business Name: Functional Role Address</summary>
         * 
         * <remarks>Relationship: PRPM_MT301010CA.AssignedEntity.addr 
         * Conformance/Cardinality: REQUIRED (0-5) <p>Address of the 
         * provider when playing the functional role.</p> <p>Required 
         * attribute supports the identification of the healthcare 
         * provider</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"addr"})]
        public IList<PostalAddress> Addr {
            get { return this.addr.RawList(); }
        }

        /**
         * <summary>Business Name: Functional Role Telecom</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT301010CA.AssignedEntity.telecom 
         * Conformance/Cardinality: REQUIRED (0-5) <p>Telecom of the 
         * provider when playing the functional role.</p> <p>Required 
         * attribute supports the identification of the healthcare 
         * provider</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"telecom"})]
        public IList<TelecommunicationAddress> Telecom {
            get { return this.telecom.RawList(); }
        }

        /**
         * <summary>Business Name: Functional Role Status Code</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT301010CA.AssignedEntity.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>The status of the 
         * provider in the functional role i.e. Active</p> <p>Mandatory 
         * attribute supports the identification of the healthcare 
         * provider</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public RoleStatus StatusCode {
            get { return (RoleStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: Functional Role Effective Date</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT301010CA.AssignedEntity.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The effective 
         * date of the provider in the functional role.</p> <p>Required 
         * attribute supports the identification of the healthcare 
         * provider</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PRPM_MT301010CA.AssignedEntity.assignedPrincipalPerson</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"assignedPrincipalPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pr.Merged.PrinicpalPerson_1 AssignedPrincipalPerson {
            get { return this.assignedPrincipalPerson; }
            set { this.assignedPrincipalPerson = value; }
        }

        /**
         * <summary>Relationship: 
         * PRPM_MT301010CA.AssignedEntity.representedOrganization</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"representedOrganization"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pr.Prpm_mt301010ca.Organization RepresentedOrganization {
            get { return this.representedOrganization; }
            set { this.representedOrganization = value; }
        }

        /**
         * <summary>Relationship: 
         * PRPM_MT301010CA.PrimaryPerformer3.actDefinitionOrEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"performance/actDefinitionOrEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pr.Merged.ActDefinitionOrEventName_1> PerformanceActDefinitionOrEvent {
            get { return this.performanceActDefinitionOrEvent; }
        }

    }

}