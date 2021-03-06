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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */

/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    [Hl7PartTypeMappingAttribute(new string[] {"RCMR_MT000002AB.IntendedRecipient","RCMR_MT000210AB.IntendedRecipient","RCMR_MT000220AB.IntendedRecipient"})]
    public class IntendedRecipient : MessagePartBean {

        private PN assignedPersonName;
        private II representedOrganizationId;
        private ST representedOrganizationName;

        public IntendedRecipient() {
            this.assignedPersonName = new PNImpl();
            this.representedOrganizationId = new IIImpl();
            this.representedOrganizationName = new STImpl();
        }
        /**
         * <summary>Business Name: ProviderName</summary>
         * 
         * <remarks>Un-merged Business Name: ProviderName Relationship: 
         * RCMR_MT000220AB.Person.name Conformance/Cardinality: 
         * MANDATORY (1) <p>The name of the provider that authored, 
         * authenticated, transcriber or is the intended recipient of 
         * the clinical document.</p> Un-merged Business Name: 
         * ProviderName Relationship: RCMR_MT000002AB.Person.name 
         * Conformance/Cardinality: MANDATORY (1) <p>The name of the 
         * provider that authored, authenticated, transcriber or is the 
         * intended recipient of the clinical document.</p> Un-merged 
         * Business Name: ProviderName Relationship: 
         * RCMR_MT000210AB.Person.name Conformance/Cardinality: 
         * MANDATORY (1) <p>The name of the provider that authored, 
         * authenticated, transcriber or is the intended recipient of 
         * the clinical document.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"assignedPerson/name"})]
        public PersonName AssignedPersonName {
            get { return this.assignedPersonName.Value; }
            set { this.assignedPersonName.Value = value; }
        }

        /**
         * <summary>Business Name: OrganizationIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: OrganizationIdentifier 
         * Relationship: RCMR_MT000220AB.Organization.id 
         * Conformance/Cardinality: REQUIRED (1) <p>Included to 
         * maintain conformance with HL7 UV models. Sent as a 
         * nullFlavor of 'UNK' (Unknown) as this information is not 
         * captured in the Netcare document repositories.</p> <p>The 
         * identifier of the organization that is the intended 
         * recipient of the clinical document.</p> Un-merged Business 
         * Name: OrganizationIdentifier Relationship: 
         * RCMR_MT000002AB.Organization.id Conformance/Cardinality: 
         * REQUIRED (1) <p>Included to maintain conformance with HL7 UV 
         * models. Sent as a nullFlavor of 'UNK' (Unknown) as this 
         * information is not captured in the Netcare document 
         * repositories.</p> <p>The identifier of the organization that 
         * is the intended recipient of the clinical document.</p> 
         * Un-merged Business Name: OrganizationIdentifier 
         * Relationship: RCMR_MT000210AB.Organization.id 
         * Conformance/Cardinality: REQUIRED (1) <p>Included to 
         * maintain conformance with HL7 UV models. Sent as a 
         * nullFlavor of 'UNK' (Unknown) as this information is not 
         * captured in the Netcare document repositories.</p> <p>The 
         * identifier of the organization that is the intended 
         * recipient of the clinical document.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"representedOrganization/id"})]
        public Identifier RepresentedOrganizationId {
            get { return this.representedOrganizationId.Value; }
            set { this.representedOrganizationId.Value = value; }
        }

        /**
         * <summary>Business Name: OrganizationName</summary>
         * 
         * <remarks>Un-merged Business Name: OrganizationName 
         * Relationship: RCMR_MT000220AB.Organization.name 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The name of the 
         * facility or location that is the intended recipient of the 
         * clinical document.</p> Un-merged Business Name: 
         * OrganizationName Relationship: 
         * RCMR_MT000002AB.Organization.name Conformance/Cardinality: 
         * REQUIRED (0-1) <p>The name of the facility or location that 
         * is the intended recipient of the clinical document.</p> 
         * Un-merged Business Name: OrganizationName Relationship: 
         * RCMR_MT000210AB.Organization.name Conformance/Cardinality: 
         * REQUIRED (0-1) <p>The name of the facility or location that 
         * is the intended recipient of the clinical document.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"representedOrganization/name"})]
        public String RepresentedOrganizationName {
            get { return this.representedOrganizationName.Value; }
            set { this.representedOrganizationName.Value = value; }
        }

    }

}