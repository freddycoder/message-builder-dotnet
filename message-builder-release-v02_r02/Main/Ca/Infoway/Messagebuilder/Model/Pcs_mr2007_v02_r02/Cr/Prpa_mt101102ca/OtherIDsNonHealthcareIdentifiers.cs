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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Cr.Prpa_mt101102ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Other IDs Non Healthcare Identifiers</summary>
     * 
     * <p>Provides the ability to capture additional client 
     * identifiers that are not healthcare specific</p> 
     * <p>Identifiers used for the focal person by other 
     * organizations are sent in the OtherIDs class. The other 
     * organization can be sent in the E_Organization Entity 
     * Class</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPA_MT101102CA.OtherIDs"})]
    public class OtherIDsNonHealthcareIdentifiers : MessagePartBean {

        private SET<II, Identifier> id;
        private CV code;
        private II scopingIdOrganizationId;
        private ST scopingIdOrganizationName;

        public OtherIDsNonHealthcareIdentifiers() {
            this.id = new SETImpl<II, Identifier>(typeof(IIImpl));
            this.code = new CVImpl();
            this.scopingIdOrganizationId = new IIImpl();
            this.scopingIdOrganizationName = new STImpl();
        }
        /**
         * <summary>Business Name: NonHealthcare Identification</summary>
         * 
         * <remarks>Relationship: PRPA_MT101102CA.OtherIDs.id 
         * Conformance/Cardinality: POPULATED (1) <p>Populated 
         * attribute supports the identification of the client</p> 
         * <p>Other non-healthcare identifiers for the Client (e.g. 
         * Drivers License, RCMP, DND, Social Insurance Number)</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public ICollection<Identifier> Id {
            get { return this.id.RawSet(); }
        }

        /**
         * <summary>Business Name: NonHealthcare Identification Code</summary>
         * 
         * <remarks>Relationship: PRPA_MT101102CA.OtherIDs.code 
         * Conformance/Cardinality: POPULATED (1) <p>Populated 
         * attribute supports the identification of the client</p> <p>A 
         * pan Canadian code further specifying the kind of Role such 
         * as Drivers License, RCMP, DND, Social Insurance Number</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public OtherIDsRoleCode Code {
            get { return (OtherIDsRoleCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: NonHealthcare Organization 
         * Identifier</summary>
         * 
         * <remarks>Relationship: PRPA_MT101102CA.IdOrganization.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports the identification of the organization 
         * assigning the identifier to the client</p> <p>Unique 
         * identifier for the organization that assigned the 
         * non-healthcare identifier for the client.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"scopingIdOrganization/id"})]
        public Identifier ScopingIdOrganizationId {
            get { return this.scopingIdOrganizationId.Value; }
            set { this.scopingIdOrganizationId.Value = value; }
        }

        /**
         * <summary>Business Name: NonHealthcare Organization Name</summary>
         * 
         * <remarks>Relationship: PRPA_MT101102CA.IdOrganization.name 
         * Conformance/Cardinality: POPULATED (1) <p>Populated 
         * attribute supports the identification of the organization 
         * assigning the identifier to the client</p> <p>A name for the 
         * non-healthcare organization</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"scopingIdOrganization/name"})]
        public String ScopingIdOrganizationName {
            get { return this.scopingIdOrganizationName.Value; }
            set { this.scopingIdOrganizationName.Value = value; }
        }

    }

}