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


    [Hl7PartTypeMappingAttribute(new string[] {"MCCI_MT000100CA.Receiver","MCCI_MT000200CA.Receiver","MCCI_MT000300CA.Receiver","MCCI_MT102001CA.Receiver"})]
    public class Receiver : MessagePartBean {

        private TEL telecom;
        private II deviceId;
        private II deviceAsAgentRepresentedOrganizationId;
        private II deviceAsLocatedEntityLocationId;

        public Receiver() {
            this.telecom = new TELImpl();
            this.deviceId = new IIImpl();
            this.deviceAsAgentRepresentedOrganizationId = new IIImpl();
            this.deviceAsLocatedEntityLocationId = new IIImpl();
        }
        /**
         * <summary>Business Name: ReceiverNetworkAddress</summary>
         * 
         * <remarks>Un-merged Business Name: ReceiverNetworkAddress 
         * Relationship: MCCI_MT000100CA.Receiver.telecom 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Indicates where 
         * the message should be sent. This is optional because not all 
         * environments require network addresses.</p> <p>The address 
         * to which this message is being sent.</p> Un-merged Business 
         * Name: ReceiverNetworkAddress Relationship: 
         * MCCI_MT000200CA.Receiver.telecom Conformance/Cardinality: 
         * OPTIONAL (0-1) <p>Indicates where the message should be 
         * sent. This is optional because not all environments require 
         * network addresses.</p> <p>The address to which this message 
         * is being sent.</p> Un-merged Business Name: 
         * ReceiverNetworkAddress Relationship: 
         * MCCI_MT102001CA.Receiver.telecom Conformance/Cardinality: 
         * POPULATED (1) <p>Indicates where the message should be sent. 
         * This is optional because not all environments require 
         * network addresses.</p> <p>The address to which this message 
         * is being sent.</p> Un-merged Business Name: 
         * ReceiverNetworkAddress Relationship: 
         * MCCI_MT000300CA.Receiver.telecom Conformance/Cardinality: 
         * OPTIONAL (0-1) <p>Indicates where the message should be 
         * sent. This is optional because not all environments require 
         * network addresses.</p> <p>The address to which this message 
         * is being sent.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"telecom"})]
        public TelecommunicationAddress Telecom {
            get { return this.telecom.Value; }
            set { this.telecom.Value = value; }
        }

        /**
         * <summary>Business Name: ReceiverApplicationIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * ReceiverApplicationIdentifier Relationship: 
         * MCCI_MT000100CA.Device2.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Used for routing and for verification that 
         * &quot;yes, this message is intended for me.&quot; This is 
         * mandatory because it is the key identifier of the receiving 
         * application.</p> <p>The unique identifier of the application 
         * to which the message is being sent.</p> Un-merged Business 
         * Name: ReceiverApplicationIdentifier Relationship: 
         * MCCI_MT000200CA.Device2.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Used for routing and for verification that 
         * &quot;yes, this message is intended for me.&quot; This is 
         * mandatory because it is the key identifier of the receiving 
         * application.</p> <p>The unique identifier of the application 
         * to which the message is being sent.</p> Un-merged Business 
         * Name: ReceiverApplicationIdentifier Relationship: 
         * MCCI_MT102001CA.Device2.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Used for routing and for verification that 
         * &quot;yes, this message is intended for me.&quot; This is 
         * mandatory because it is the key identifier of the receiving 
         * application.</p> <p>The unique identifier of the application 
         * to which the message is being sent.</p> Un-merged Business 
         * Name: ReceiverApplicationIdentifier Relationship: 
         * MCCI_MT000300CA.Device2.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Used for routing and for verification that 
         * &quot;yes, this message is intended for me.&quot; This is 
         * mandatory because it is the key identifier of the receiving 
         * application.</p> <p>The unique identifier of the application 
         * to which the message is being sent.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"device/id"})]
        public Identifier DeviceId {
            get { return this.deviceId.Value; }
            set { this.deviceId.Value = value; }
        }

        /**
         * <summary>Business Name: ReceiverOrganizationIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * ReceiverOrganizationIdentifier Relationship: 
         * MCCI_MT000100CA.Organization2.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Important when the eventual entity 
         * responsible for acting on an interaction may be reached 
         * through several routing steps. This attribute is optional 
         * because not all environments require communicating this 
         * information.</p> <p>The unique identifier of the 
         * organization with responsibility to act on the contents of 
         * this message.</p> Un-merged Business Name: 
         * ReceiverOrganizationIdentifier Relationship: 
         * MCCI_MT000200CA.Organization2.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Important when the eventual entity 
         * responsible for acting on an interaction may be reached 
         * through several routing steps. This attribute is optional 
         * because not all environments require communicating this 
         * information.</p> <p>The unique identifier of the 
         * organization with responsibility to act on the contents of 
         * this message.</p> Un-merged Business Name: 
         * ReceiverOrganizationIdentifier Relationship: 
         * MCCI_MT102001CA.Organization2.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Important when the eventual entity 
         * responsible for acting on an interaction may be reached 
         * through several routing steps. This attribute is optional 
         * because not all environments require communicating this 
         * information.</p> <p>The unique identifier of the 
         * organization with responsibility to act on the contents of 
         * this message.</p> Un-merged Business Name: 
         * ReceiverOrganizationIdentifier Relationship: 
         * MCCI_MT000300CA.Organization2.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Important when the eventual entity 
         * responsible for acting on an interaction may be reached 
         * through several routing steps. This attribute is optional 
         * because not all environments require communicating this 
         * information.</p> <p>The unique identifier of the 
         * organization with responsibility to act on the contents of 
         * this message.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"device/asAgent/representedOrganization/id"})]
        public Identifier DeviceAsAgentRepresentedOrganizationId {
            get { return this.deviceAsAgentRepresentedOrganizationId.Value; }
            set { this.deviceAsAgentRepresentedOrganizationId.Value = value; }
        }

        /**
         * <summary>Business Name: ReceiverFacilityIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: ReceiverFacilityIdentifier 
         * Relationship: MCCI_MT000100CA.Place2.id 
         * Conformance/Cardinality: MANDATORY (1) <p>May be used to 
         * assist in routing the message. This attribute is optional 
         * because not all environments require communicating this 
         * information.</p> <p>Identifies the facility expected to 
         * receive the message.</p> Un-merged Business Name: 
         * ReceiverFacilityIdentifier Relationship: 
         * MCCI_MT000200CA.Place2.id Conformance/Cardinality: MANDATORY 
         * (1) <p>May be used to assist in routing the message. This 
         * attribute is optional because not all environments require 
         * communicating this information.</p> <p>Identifies the 
         * facility expected to receive the message.</p> Un-merged 
         * Business Name: ReceiverFacilityIdentifier Relationship: 
         * MCCI_MT102001CA.Place2.id Conformance/Cardinality: MANDATORY 
         * (1) <p>May be used to assist in routing the message. This 
         * attribute is optional because not all environments require 
         * communicating this information.</p> <p>Identifies the 
         * facility expected to receive the message.</p> Un-merged 
         * Business Name: ReceiverFacilityIdentifier Relationship: 
         * MCCI_MT000300CA.Place2.id Conformance/Cardinality: MANDATORY 
         * (1) <p>May be used to assist in routing the message. This 
         * attribute is optional because not all environments require 
         * communicating this information.</p> <p>Identifies the 
         * facility expected to receive the message.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"device/asLocatedEntity/location/id"})]
        public Identifier DeviceAsLocatedEntityLocationId {
            get { return this.deviceAsLocatedEntityLocationId.Value; }
            set { this.deviceAsLocatedEntityLocationId.Value = value; }
        }

    }

}