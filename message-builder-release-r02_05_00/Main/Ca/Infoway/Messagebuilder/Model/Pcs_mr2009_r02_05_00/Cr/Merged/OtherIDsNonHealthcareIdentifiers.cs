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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Cr.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Domainvalue;
    using System;


    /**
     * <summary>Business Name: OtherIDsNonHealthcareIdentifiers</summary>
     * 
     * <remarks>PRPA_MT101104CA.OtherIDs: Other IDs Non Healthcare 
     * Identifiers <p>Provides the ability to capture additional 
     * client identifiers that are not healthcare specific</p> 
     * <p>Identifiers used for the focal person by other 
     * organizations are sent in the OtherIDs class. The other 
     * organization can be sent in the E_Organization Entity 
     * Class</p> PRPA_MT101002CA.OtherIDs: Other IDs Non Healthcare 
     * Identifiers <p>Provides the ability to capture additional 
     * client identifiers that are not healthcare specific</p> 
     * <p>Identifiers used for the focal person by other 
     * organizations are sent in the OtherIDs class. The other 
     * organization can be sent in the E_Organization Entity 
     * Class</p> PRPA_MT101106CA.OtherIDs: Other IDs Non Healthcare 
     * Identifiers <p>Provides the ability to capture additional 
     * client identifiers that are not healthcare specific</p> 
     * <p>Identifiers used for the focal person by other 
     * organizations are sent in the OtherIDs class. The other 
     * organization can be sent in the E_Organization Entity 
     * Class</p> PRPA_MT101102CA.OtherIDs: Other IDs Non Healthcare 
     * Identifiers <p>Provides the ability to capture additional 
     * client identifiers that are not healthcare specific</p> 
     * <p>Identifiers used for the focal person by other 
     * organizations are sent in the OtherIDs class. The other 
     * organization can be sent in the E_Organization Entity 
     * Class</p> PRPA_MT101001CA.OtherIDs: Other IDs Non Healthcare 
     * Identifiers <p>Provides the ability to capture additional 
     * client identifiers that are not healthcare specific</p> 
     * <p>Identifiers used for the focal person by other 
     * organizations are sent in the OtherIDs class. The other 
     * organization can be sent in the E_Organization Entity 
     * Class</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPA_MT101001CA.OtherIDs","PRPA_MT101002CA.OtherIDs","PRPA_MT101102CA.OtherIDs","PRPA_MT101104CA.OtherIDs","PRPA_MT101106CA.OtherIDs"})]
    public class OtherIDsNonHealthcareIdentifiers : MessagePartBean {

        private II id;
        private CV code;
        private II assigningIdOrganizationId;
        private ST assigningIdOrganizationName;

        public OtherIDsNonHealthcareIdentifiers() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.assigningIdOrganizationId = new IIImpl();
            this.assigningIdOrganizationName = new STImpl();
        }
        /**
         * <summary>Business Name: NonHealthcareIdentification</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * NonHealthcareIdentification Relationship: 
         * PRPA_MT101104CA.OtherIDs.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Mandatory attribute supports the 
         * identification of the client</p> <p>Other non-healthcare 
         * identifiers for the Client (e.g. Drivers License, RCMP, DND, 
         * Social Insurance Number)</p> Un-merged Business Name: 
         * NonHealthcareIdentification Relationship: 
         * PRPA_MT101002CA.OtherIDs.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Mandatory attribute supports the 
         * identification of the client</p> <p>Other non-healthcare 
         * identifiers for the Client (e.g. Passport, SIN, DND, DIAND, 
         * Drivers License)</p> Un-merged Business Name: 
         * NonHealthcareIdentification Relationship: 
         * PRPA_MT101106CA.OtherIDs.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Mandatory attribute supports the 
         * identification of the client</p> <p>Other non-healthcare 
         * identifiers for the Client (e.g. Drivers License, RCMP, DND, 
         * Social Insurance Number)</p> Un-merged Business Name: 
         * NonHealthcareIdentification Relationship: 
         * PRPA_MT101102CA.OtherIDs.id Conformance/Cardinality: 
         * REQUIRED (1) <p>Populated attribute supports the 
         * identification of the client</p> <p>Other non-healthcare 
         * identifiers for the Client (e.g. Drivers License, RCMP, DND, 
         * Social Insurance Number)</p> Un-merged Business Name: 
         * NonHealthcareIdentification Relationship: 
         * PRPA_MT101001CA.OtherIDs.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Mandatory attribute supports the 
         * identification of the client</p> <p>Other non-healthcare 
         * identifiers for the Client (e.g. Passport, SIN, DND, DIAND, 
         * Drivers License)</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: NonHealthcareIdentificationCode</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * NonHealthcareIdentificationCode Relationship: 
         * PRPA_MT101104CA.OtherIDs.code Conformance/Cardinality: 
         * REQUIRED (1) <p>Populated attribute supports the 
         * identification of the client</p> <p>A pan Canadian code 
         * further specifying the kind of Role such as Drivers License, 
         * RCMP, DND, Social Insurance Number</p> Un-merged Business 
         * Name: NonHealthcareIdentificationCode Relationship: 
         * PRPA_MT101002CA.OtherIDs.code Conformance/Cardinality: 
         * REQUIRED (1) <p>Populated attribute supports the 
         * identification of the client</p> <p>A pan Canadian code 
         * further specifying the kind of Role such as Drivers License, 
         * RCMP, DND, Social Insurance Number</p> Un-merged Business 
         * Name: NonHealthcareIdentificationCode Relationship: 
         * PRPA_MT101106CA.OtherIDs.code Conformance/Cardinality: 
         * REQUIRED (1) <p>Populated attribute supports the 
         * identification of the client</p> <p>A pan Canadian code 
         * further specifying the kind of Role such as Drivers License, 
         * RCMP, DND, Social Insurance Number</p> Un-merged Business 
         * Name: NonHealthcareIdentificationCode Relationship: 
         * PRPA_MT101102CA.OtherIDs.code Conformance/Cardinality: 
         * REQUIRED (1) <p>Populated attribute supports the 
         * identification of the client</p> <p>A pan Canadian code 
         * further specifying the kind of Role such as Drivers License, 
         * RCMP, DND, Social Insurance Number</p> Un-merged Business 
         * Name: NonHealthcareIdentificationCode Relationship: 
         * PRPA_MT101001CA.OtherIDs.code Conformance/Cardinality: 
         * REQUIRED (1) <p>Populated attribute supports the 
         * identification of the client</p> <p>A pan Canadian code 
         * further specifying the kind of Role such as Drivers License, 
         * RCMP, DND, Social Insurance Number</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public OtherIdentifiersRoleType Code {
            get { return (OtherIdentifiersRoleType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: NonHealthcareOrganizationIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * NonHealthcareOrganizationIdentifier Relationship: 
         * PRPA_MT101104CA.IdOrganization.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Mandatory attribute supports the 
         * identification of the organization assigning the identifier 
         * to the client</p> <p>Unique identifier for the organization 
         * that assigned the non-healthcare identifier for the 
         * client.</p> Un-merged Business Name: 
         * NonHealthcareOrganizationIdentifier Relationship: 
         * PRPA_MT101002CA.IdOrganization.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Mandatory attribute supports the 
         * identification of the organization assigning the identifier 
         * to the client</p> <p>Unique identifier for the organization 
         * that assigned the non-healthcare identifier for the 
         * client.</p> Un-merged Business Name: 
         * NonHealthcareOrganizationIdentifier Relationship: 
         * PRPA_MT101106CA.IdOrganization.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Mandatory attribute supports the 
         * identification of the organization assigning the identifier 
         * to the client</p> <p>Unique identifier for the organization 
         * that assigned the non-healthcare identifier for the 
         * client.</p> Un-merged Business Name: 
         * NonHealthcareOrganizationIdentifier Relationship: 
         * PRPA_MT101102CA.IdOrganization.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Mandatory attribute supports the 
         * identification of the organization assigning the identifier 
         * to the client</p> <p>Unique identifier for the organization 
         * that assigned the non-healthcare identifier for the 
         * client.</p> Un-merged Business Name: 
         * NonHealthcareOrganizationIdentifier Relationship: 
         * PRPA_MT101001CA.IdOrganization.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Mandatory attribute supports the 
         * identification of the organization assigning the identifier 
         * to the client</p> <p>Unique identifier for the organization 
         * that assigned the non-healthcare identifier for the 
         * client.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"assigningIdOrganization/id"})]
        public Identifier AssigningIdOrganizationId {
            get { return this.assigningIdOrganizationId.Value; }
            set { this.assigningIdOrganizationId.Value = value; }
        }

        /**
         * <summary>Business Name: NonHealthcareOrganizationName</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * NonHealthcareOrganizationName Relationship: 
         * PRPA_MT101104CA.IdOrganization.name Conformance/Cardinality: 
         * REQUIRED (1) <p>Populated attribute supports the 
         * identification of the organization assigning the identifier 
         * to the client</p> <p>A name for the non-healthcare 
         * organization</p> Un-merged Business Name: 
         * NonHealthcareOrganizationName Relationship: 
         * PRPA_MT101002CA.IdOrganization.name Conformance/Cardinality: 
         * REQUIRED (1) <p>Populated attribute supports the 
         * identification of the organization assigning the identifier 
         * to the client</p> <p>A name for the non-healthcare 
         * organization</p> Un-merged Business Name: 
         * NonHealthcareOrganizationName Relationship: 
         * PRPA_MT101106CA.IdOrganization.name Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Populated attribute supports the 
         * identification of the organization assigning the identifier 
         * to the client</p> <p>A name for the non-healthcare 
         * organization</p> Un-merged Business Name: 
         * NonHealthcareOrganizationName Relationship: 
         * PRPA_MT101102CA.IdOrganization.name Conformance/Cardinality: 
         * REQUIRED (1) <p>Populated attribute supports the 
         * identification of the organization assigning the identifier 
         * to the client</p> <p>A name for the non-healthcare 
         * organization</p> Un-merged Business Name: 
         * NonHealthcareOrganizationName Relationship: 
         * PRPA_MT101001CA.IdOrganization.name Conformance/Cardinality: 
         * REQUIRED (1) <p>Populated attribute supports the 
         * identification of the organization assigning the identifier 
         * to the client</p> <p>A name for the non-healthcare 
         * organization</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"assigningIdOrganization/name"})]
        public String AssigningIdOrganizationName {
            get { return this.assigningIdOrganizationName.Value; }
            set { this.assigningIdOrganizationName.Value = value; }
        }

    }

}