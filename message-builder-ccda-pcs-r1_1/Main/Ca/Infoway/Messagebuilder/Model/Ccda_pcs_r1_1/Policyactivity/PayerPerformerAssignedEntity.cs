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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Policyactivity {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"PolicyActivity.PayerPerformerAssignedEntity"})]
    public class PayerPerformerAssignedEntity : MessagePartBean {

        private LIST<II, Identifier> id;
        private CE code;
        private AD addr;
        private TEL telecom;
        private Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.Organization_2 representedOrganization;

        public PayerPerformerAssignedEntity() {
            this.id = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.code = new CEImpl();
            this.addr = new ADImpl();
            this.telecom = new TELImpl();
        }
        /**
         * <summary>Relationship: 
         * PolicyActivity.PayerPerformerAssignedEntity.id</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public IList<Identifier> Id {
            get { return this.id.RawList(); }
        }

        /**
         * <summary>Relationship: 
         * PolicyActivity.PayerPerformerAssignedEntity.code</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public FinanciallyResponsiblePartyType Code {
            get { return (FinanciallyResponsiblePartyType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PolicyActivity.PayerPerformerAssignedEntity.addr</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"addr"})]
        public PostalAddress Addr {
            get { return this.addr.Value; }
            set { this.addr.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PolicyActivity.PayerPerformerAssignedEntity.telecom</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"telecom"})]
        public TelecommunicationAddress Telecom {
            get { return this.telecom.Value; }
            set { this.telecom.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PolicyActivity.PayerPerformerAssignedEntity.representedOrganization</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"representedOrganization"})]
        public Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.Organization_2 RepresentedOrganization {
            get { return this.representedOrganization; }
            set { this.representedOrganization = value; }
        }

    }

}