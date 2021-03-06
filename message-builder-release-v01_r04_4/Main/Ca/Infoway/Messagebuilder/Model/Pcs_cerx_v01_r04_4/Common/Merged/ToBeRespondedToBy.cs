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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>Business Name: ToBeRespondedToBy</summary>
     * 
     * <remarks>MCCI_MT102001CA.RespondTo: to be responded to by 
     * <p>In complex routing environments, the acknowledgements may 
     * need to be sent to a system other than the one which 
     * constructed the original message. This association is 
     * optional because not all environments will support responses 
     * to systems other than the original sender.</p> <p>Indicates 
     * the interaction that should receive the response to this 
     * interaction. Used when different from the sender of the 
     * original interaction.</p> MCCI_MT000100CA.RespondTo: to be 
     * responded to by <p>In complex routing environments, the 
     * acknowledgements may need to be sent to a system other than 
     * the one which constructed the original message. This 
     * association is optional because not all environments will 
     * support responses to systems other than the original 
     * sender.</p> <p>Indicates the interaction that should receive 
     * the response to this interaction. Used when different from 
     * the sender of the original interaction.</p> 
     * MCCI_MT000200CA.RespondTo: to be responded to by <p>In 
     * complex routing environments, the acknowledgements may need 
     * to be sent to a system other than the one which constructed 
     * the original message. This association is optional because 
     * not all environments will support responses to systems other 
     * than the original sender.</p> <p>Indicates the interaction 
     * that should receive the response to this interaction. Used 
     * when different from the sender of the original 
     * interaction.</p> MCCI_MT000300CA.RespondTo: to be responded 
     * to by <p>In complex routing environments, the 
     * acknowledgements may need to be sent to a system other than 
     * the one which constructed the original message. This 
     * association is optional because not all environments will 
     * support responses to systems other than the original 
     * sender.</p> <p>Indicates the interaction that should receive 
     * the response to this interaction. Used when different from 
     * the sender of the original interaction.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"MCCI_MT000100CA.RespondTo","MCCI_MT000200CA.RespondTo","MCCI_MT000300CA.RespondTo","MCCI_MT102001CA.RespondTo"})]
    public class ToBeRespondedToBy : MessagePartBean {

        private TEL telecom;
        private II deviceId;
        private II deviceAsAgentRepresentedOrganizationId;
        private II deviceAsLocatedEntityLocationId;

        public ToBeRespondedToBy() {
            this.telecom = new TELImpl();
            this.deviceId = new IIImpl();
            this.deviceAsAgentRepresentedOrganizationId = new IIImpl();
            this.deviceAsLocatedEntityLocationId = new IIImpl();
        }
        /**
         * <summary>Business Name: RespondToNetworkAddress</summary>
         * 
         * <remarks>Un-merged Business Name: RespondToNetworkAddress 
         * Relationship: MCCI_MT102001CA.RespondTo.telecom 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Needed when the 
         * address to respond to is different than that of the sender. 
         * This is optional because not all environments require 
         * network addresses.</p> <p>Indicates the address to send 
         * acknowledgments of this message to.</p> Un-merged Business 
         * Name: RespondToNetworkAddress Relationship: 
         * MCCI_MT000100CA.RespondTo.telecom Conformance/Cardinality: 
         * OPTIONAL (0-1) <p>Needed when the address to respond to is 
         * different than that of the sender. This is optional because 
         * not all environments require network addresses.</p> 
         * <p>Indicates the address to send acknowledgments of this 
         * message to.</p> Un-merged Business Name: 
         * RespondToNetworkAddress Relationship: 
         * MCCI_MT000200CA.RespondTo.telecom Conformance/Cardinality: 
         * OPTIONAL (0-1) <p>Needed when the address to respond to is 
         * different than that of the sender. This is optional because 
         * not all environments require network addresses.</p> 
         * <p>Indicates the address to send acknowledgments of this 
         * message to.</p> Un-merged Business Name: 
         * RespondToNetworkAddress Relationship: 
         * MCCI_MT000300CA.RespondTo.telecom Conformance/Cardinality: 
         * OPTIONAL (0-1) <p>Needed when the address to respond to is 
         * different than that of the sender. This is optional because 
         * not all environments require network addresses.</p> 
         * <p>Indicates the address to send acknowledgments of this 
         * message to.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"telecom"})]
        public TelecommunicationAddress Telecom {
            get { return this.telecom.Value; }
            set { this.telecom.Value = value; }
        }

        /**
         * <summary>Business Name: RespondToApplicationIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * RespondToApplicationIdentifier Relationship: 
         * MCCI_MT102001CA.Device3.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Allows unique identification and routing to 
         * the application to be responded to. This attribute is 
         * mandatory be cause it is the principal identifier of the 
         * application to respond to.</p> <p>The unique identifier of 
         * the applications to which responses should be sent. Only 
         * populated when different from the sending application 
         * id.</p> Un-merged Business Name: 
         * RespondToApplicationIdentifier Relationship: 
         * MCCI_MT000100CA.Device3.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Allows unique identification and routing to 
         * the application to be responded to. This attribute is 
         * mandatory be cause it is the principal identifier of the 
         * application to respond to.</p> <p>The unique identifier of 
         * the applications to which responses should be sent. Only 
         * populated when different from the sending application 
         * id.</p> Un-merged Business Name: 
         * RespondToApplicationIdentifier Relationship: 
         * MCCI_MT000200CA.Device3.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Allows unique identification and routing to 
         * the application to be responded to. This attribute is 
         * mandatory be cause it is the principal identifier of the 
         * application to respond to.</p> <p>The unique identifier of 
         * the applications to which responses should be sent. Only 
         * populated when different from the sending application 
         * id.</p> Un-merged Business Name: 
         * RespondToApplicationIdentifier Relationship: 
         * MCCI_MT000300CA.Device3.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Allows unique identification and routing to 
         * the application to be responded to. This attribute is 
         * mandatory be cause it is the principal identifier of the 
         * application to respond to.</p> <p>The unique identifier of 
         * the applications to which responses should be sent. Only 
         * populated when different from the sending application 
         * id.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"device/id"})]
        public Identifier DeviceId {
            get { return this.deviceId.Value; }
            set { this.deviceId.Value = value; }
        }

        /**
         * <summary>Business Name: RespondToOrganizationId</summary>
         * 
         * <remarks>Un-merged Business Name: RespondToOrganizationId 
         * Relationship: MCCI_MT102001CA.Organization3.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Needed for 
         * circumstances where the 'respond to' organization is 
         * different than the sending organization. This attribute is 
         * optional because not all environments require communicating 
         * this information.</p> <p>The unique identifier of the 
         * application who is to be responsible for responses to this 
         * message.</p> Un-merged Business Name: 
         * RespondToOrganizationId Relationship: 
         * MCCI_MT000100CA.Organization3.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Needed for circumstances where the 'respond 
         * to' organization is different than the sending organization. 
         * This attribute is optional because not all environments 
         * require communicating this information.</p> <p>The unique 
         * identifier of the application who is to be responsible for 
         * responses to this message.</p> Un-merged Business Name: 
         * RespondToOrganizationId Relationship: 
         * MCCI_MT000200CA.Organization3.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Needed for circumstances where the 'respond 
         * to' organization is different than the sending organization. 
         * This attribute is optional because not all environments 
         * require communicating this information.</p> <p>The unique 
         * identifier of the application who is to be responsible for 
         * responses to this message.</p> Un-merged Business Name: 
         * RespondToOrganizationId Relationship: 
         * MCCI_MT000300CA.Organization3.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Needed for circumstances where the 'respond 
         * to' organization is different than the sending organization. 
         * This attribute is optional because not all environments 
         * require communicating this information.</p> <p>The unique 
         * identifier of the application who is to be responsible for 
         * responses to this message.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"device/asAgent/representedOrganization/id"})]
        public Identifier DeviceAsAgentRepresentedOrganizationId {
            get { return this.deviceAsAgentRepresentedOrganizationId.Value; }
            set { this.deviceAsAgentRepresentedOrganizationId.Value = value; }
        }

        /**
         * <summary>Business Name: RespondToFacilityId</summary>
         * 
         * <remarks>Un-merged Business Name: RespondToFacilityId 
         * Relationship: MCCI_MT102001CA.Place3.id 
         * Conformance/Cardinality: MANDATORY (1) <p>May affect the 
         * routing of a message. This attribute is optional because not 
         * all environments require communicating this information.</p> 
         * <p>Indicates the clinic or other facility to which responses 
         * to this interaction should be sent.</p> Un-merged Business 
         * Name: RespondToFacilityId Relationship: 
         * MCCI_MT000100CA.Place3.id Conformance/Cardinality: MANDATORY 
         * (1) <p>May affect the routing of a message. This attribute 
         * is optional because not all environments require 
         * communicating this information.</p> <p>Indicates the clinic 
         * or other facility to which responses to this interaction 
         * should be sent.</p> Un-merged Business Name: 
         * RespondToFacilityId Relationship: MCCI_MT000200CA.Place3.id 
         * Conformance/Cardinality: MANDATORY (1) <p>May affect the 
         * routing of a message. This attribute is optional because not 
         * all environments require communicating this information.</p> 
         * <p>Indicates the clinic or other facility to which responses 
         * to this interaction should be sent.</p> Un-merged Business 
         * Name: RespondToFacilityId Relationship: 
         * MCCI_MT000300CA.Place3.id Conformance/Cardinality: MANDATORY 
         * (1) <p>May affect the routing of a message. This attribute 
         * is optional because not all environments require 
         * communicating this information.</p> <p>Indicates the clinic 
         * or other facility to which responses to this interaction 
         * should be sent.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"device/asLocatedEntity/location/id"})]
        public Identifier DeviceAsLocatedEntityLocationId {
            get { return this.deviceAsLocatedEntityLocationId.Value; }
            set { this.deviceAsLocatedEntityLocationId.Value = value; }
        }

    }

}