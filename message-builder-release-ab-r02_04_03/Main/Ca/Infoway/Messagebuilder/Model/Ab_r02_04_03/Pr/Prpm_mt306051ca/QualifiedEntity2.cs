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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Prpm_mt306051ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Merged;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"PRPM_MT306051CA.QualifiedEntity2"})]
    public class QualifiedEntity2 : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Prpm_mt306051ca.IRoleChoice {

        private SET<II, Identifier> id;
        private CV code;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Merged.PrinicpalPerson_2 qualifiedPrincipalPerson;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Prpm_mt306051ca.Organization qualificationGrantingOrganization;

        public QualifiedEntity2() {
            this.id = new SETImpl<II, Identifier>(typeof(IIImpl));
            this.code = new CVImpl();
        }
        /**
         * <summary>Business Name: Credentials Role Identifier</summary>
         * 
         * <remarks>Relationship: PRPM_MT306051CA.QualifiedEntity2.id 
         * Conformance/Cardinality: MANDATORY (1-50) <p>Mandatory 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>Unique identifier for the credential.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public ICollection<Identifier> Id {
            get { return this.id.RawSet(); }
        }

        /**
         * <summary>Business Name: Credentials Role Type</summary>
         * 
         * <remarks>Relationship: PRPM_MT306051CA.QualifiedEntity2.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports the identification of the healthcare 
         * provider</p> <p>If Credentials included in the message, then 
         * Role Type Must Exist.</p> <p>The type of credential.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public CertifiedEntityType Code {
            get { return (CertifiedEntityType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PRPM_MT306051CA.QualifiedEntity2.qualifiedPrincipalPerson</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"qualifiedPrincipalPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Merged.PrinicpalPerson_2 QualifiedPrincipalPerson {
            get { return this.qualifiedPrincipalPerson; }
            set { this.qualifiedPrincipalPerson = value; }
        }

        /**
         * <summary>Relationship: 
         * PRPM_MT306051CA.QualifiedEntity2.qualificationGrantingOrganization</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"qualificationGrantingOrganization"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Prpm_mt306051ca.Organization QualificationGrantingOrganization {
            get { return this.qualificationGrantingOrganization; }
            set { this.qualificationGrantingOrganization = value; }
        }

    }

}