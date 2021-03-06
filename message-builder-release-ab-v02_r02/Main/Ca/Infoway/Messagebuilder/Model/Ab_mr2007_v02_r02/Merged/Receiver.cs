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
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    [Hl7PartTypeMappingAttribute(new string[] {"MCCI_MT000100CA.Receiver","MCCI_MT000300CA.Receiver","MCCI_MT002100CA.Receiver","MCCI_MT002200CA.Receiver","MCCI_MT102001CA.Receiver"})]
    public class Receiver : MessagePartBean {

        private TEL telecom;
        private II deviceId;
        private ST deviceName;
        private II deviceAgentAgentOrganizationId;
        private II deviceAsLocatedEntityLocationId;

        public Receiver() {
            this.telecom = new TELImpl();
            this.deviceId = new IIImpl();
            this.deviceName = new STImpl();
            this.deviceAgentAgentOrganizationId = new IIImpl();
            this.deviceAsLocatedEntityLocationId = new IIImpl();
        }
        /**
         * <summary>Business Name: ReceiverNetworkAddress</summary>
         * 
         * <remarks>Un-merged Business Name: ReceiverNetworkAddress 
         * Relationship: MCCI_MT000100CA.Receiver.telecom 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>The address to 
         * which this message is being sent.</p> <p>Indicates where the 
         * message should be sent. This is optional because not all 
         * environments require network addresses.</p> Un-merged 
         * Business Name: ReceiverNetworkAddress Relationship: 
         * MCCI_MT102001CA.Receiver.telecom Conformance/Cardinality: 
         * OPTIONAL (0-1) <p>The address to which this message is being 
         * sent.</p> <p>soap:Header\wsa:To</p> <p>Indicates where the 
         * message should be sent. This is optional because not all 
         * environments require network addresses. It is mandatory when 
         * communicating using SOAP.</p> Un-merged Business Name: 
         * ReceiverNetworkAddress Relationship: 
         * MCCI_MT000300CA.Receiver.telecom Conformance/Cardinality: 
         * OPTIONAL (0-1) <p>The address to which this message is being 
         * sent.</p> <p>Indicates where the message should be sent. 
         * This is optional because not all environments require 
         * network addresses.</p> Un-merged Business Name: 
         * ReceiverNetworkAddress Relationship: 
         * MCCI_MT002100CA.Receiver.telecom Conformance/Cardinality: 
         * OPTIONAL (0-1) <p>The address to which this message is being 
         * sent.</p> <p>soap:Header\wsa:To</p> <p>Indicates where the 
         * message should be sent. This is optional because not all 
         * environments require network addresses. It is mandatory when 
         * communicating using SOAP.</p> Un-merged Business Name: 
         * ReceiverNetworkAddress Relationship: 
         * MCCI_MT002200CA.Receiver.telecom Conformance/Cardinality: 
         * OPTIONAL (0-1) <p>The address to which this message is being 
         * sent.</p> <p>soap:Header\wsa:To</p> <p>Indicates where the 
         * message should be sent. This is optional because not all 
         * environments require network addresses. It is mandatory when 
         * communicating using SOAP.</p></remarks>
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
         * MANDATORY (1) <p>The unique identifier of the application to 
         * which the message is being sent.</p> <p>Used for routing and 
         * for verification that &quot;yes, this message is intended 
         * for me.&quot; This is mandatory because it is the key 
         * identifier of the receiving application.</p> Un-merged 
         * Business Name: ReceiverApplicationIdentifier Relationship: 
         * MCCI_MT102001CA.Device2.id Conformance/Cardinality: 
         * MANDATORY (1) <p>The unique identifier of the application to 
         * which the message is being sent.</p> 
         * <p>soap:Header\wsa:To\@endpointID</p> <p>Used for routing 
         * and for verification that &quot;yes, this message is 
         * intended for me.&quot; This is mandatory because it is the 
         * key identifier of the receiving application.</p> Un-merged 
         * Business Name: ReceiverApplicationIdentifier Relationship: 
         * MCCI_MT000300CA.Device2.id Conformance/Cardinality: 
         * MANDATORY (1) <p>The unique identifier of the application to 
         * which the message is being sent.</p> <p>Used for routing and 
         * for verification that &quot;yes, this message is intended 
         * for me.&quot; This is mandatory because it is the key 
         * identifier of the receiving application.</p> Un-merged 
         * Business Name: ReceiverApplicationIdentifier Relationship: 
         * MCCI_MT002100CA.Device2.id Conformance/Cardinality: 
         * MANDATORY (1) <p>The unique identifier of the application to 
         * which the message is being sent.</p> 
         * <p>soap:Header\wsa:To\@endpointID</p> <p>Used for routing 
         * and for verification that &quot;yes, this message is 
         * intended for me.&quot; This is mandatory because it is the 
         * key identifier of the receiving application.</p> Un-merged 
         * Business Name: ReceiverApplicationIdentifier Relationship: 
         * MCCI_MT002200CA.Device2.id Conformance/Cardinality: 
         * MANDATORY (1) <p>The unique identifier of the application to 
         * which the message is being sent.</p> 
         * <p>soap:Header\wsa:To\@endpointID</p> <p>Used for routing 
         * and for verification that &quot;yes, this message is 
         * intended for me.&quot; This is mandatory because it is the 
         * key identifier of the receiving application.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"device/id"})]
        public Identifier DeviceId {
            get { return this.deviceId.Value; }
            set { this.deviceId.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: ReceiverApplicationName</summary>
         * 
         * <remarks>Relationship: MCCI_MT102001CA.Device2.name 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Name of receiver 
         * application.</p> Un-merged Business Name: 
         * ReceivingApplicationName Relationship: 
         * MCCI_MT002100CA.Device2.name Conformance/Cardinality: 
         * OPTIONAL (0-1) <p>Name of the receiving application.</p> 
         * <p>Optional name of the receiving application.</p> Un-merged 
         * Business Name: ReceiverApplicationName Relationship: 
         * MCCI_MT002200CA.Device2.name Conformance/Cardinality: 
         * OPTIONAL (0-1) <p>Name of receiver application.</p> 
         * <p>Optional name of receiver application</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"device/name"})]
        public String DeviceName {
            get { return this.deviceName.Value; }
            set { this.deviceName.Value = value; }
        }

        /**
         * <summary>Business Name: ReceiverOrganizationIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * ReceiverOrganizationIdentifier Relationship: 
         * MCCI_MT000100CA.Organization2.id Conformance/Cardinality: 
         * MANDATORY (1) <p>The unique identifier of the organization 
         * with responsibility to act on the contents of this 
         * message.</p> <p>Important when the eventual entity 
         * responsible for acting on an interaction may be reached 
         * through several routing steps. This attribute is optional 
         * because not all environments require communicating this 
         * information.</p> Un-merged Business Name: 
         * ReceiverOrganizationIdentifier Relationship: 
         * MCCI_MT102001CA.Organization2.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Name of receiver application.</p> 
         * <p>Identifier is the only non-structure attribute in this 
         * class and is therefore mandatory. The agent association from 
         * the receiver device (application) to the agent role is 
         * optional.</p> Un-merged Business Name: 
         * ReceiverOrganizationIdentifier Relationship: 
         * MCCI_MT000300CA.Organization2.id Conformance/Cardinality: 
         * MANDATORY (1) <p>The unique identifier of the organization 
         * with responsibility to act on the contents of this 
         * message.</p> <p>Important when the eventual entity 
         * responsible for acting on an interaction may be reached 
         * through several routing steps. This attribute is optional 
         * because not all environments require communicating this 
         * information.</p> Un-merged Business Name: 
         * ReceiverOrganizationIdentifier Relationship: 
         * MCCI_MT002100CA.Organization.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Unique identifier for the receiver 
         * organization.</p> <p>The identifier is the only 
         * non-structural attribute in this class and is therefore 
         * mandatory. The association from receiver device to agent is 
         * optional.</p> Un-merged Business Name: 
         * ReceiverOrganizationIdentifier Relationship: 
         * MCCI_MT002200CA.Organization2.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Receiver organization.</p> <p>The 
         * identifier of the receiver organization. This is the only 
         * non-structural attribute in this class and is therefore 
         * mandatory. Receiver organization is optional (as the scoper 
         * association from the receiver application is optional).</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"device/agent/agentOrganization/id","device/asAgent/representedOrganization/id"})]
        [Hl7MapByPartType(Name="device", Type="MCCI_MT000100CA.Device2")]
        [Hl7MapByPartType(Name="device", Type="MCCI_MT000300CA.Device2")]
        [Hl7MapByPartType(Name="device", Type="MCCI_MT002100CA.Device2")]
        [Hl7MapByPartType(Name="device", Type="MCCI_MT002200CA.Device2")]
        [Hl7MapByPartType(Name="device", Type="MCCI_MT102001CA.Device2")]
        [Hl7MapByPartType(Name="device/agent", Type="MCCI_MT002100CA.Agent")]
        [Hl7MapByPartType(Name="device/agent", Type="MCCI_MT002200CA.Agent2")]
        [Hl7MapByPartType(Name="device/agent", Type="MCCI_MT102001CA.Agent2")]
        [Hl7MapByPartType(Name="device/agent/agentOrganization", Type="MCCI_MT002100CA.Organization")]
        [Hl7MapByPartType(Name="device/agent/agentOrganization", Type="MCCI_MT002200CA.Organization2")]
        [Hl7MapByPartType(Name="device/agent/agentOrganization", Type="MCCI_MT102001CA.Organization2")]
        [Hl7MapByPartType(Name="device/asAgent", Type="MCCI_MT000100CA.Agent2")]
        [Hl7MapByPartType(Name="device/asAgent", Type="MCCI_MT000300CA.Agent2")]
        [Hl7MapByPartType(Name="device/asAgent/representedOrganization", Type="MCCI_MT000100CA.Organization2")]
        [Hl7MapByPartType(Name="device/asAgent/representedOrganization", Type="MCCI_MT000300CA.Organization2")]
        public Identifier DeviceAgentAgentOrganizationId {
            get { return this.deviceAgentAgentOrganizationId.Value; }
            set { this.deviceAgentAgentOrganizationId.Value = value; }
        }

        /**
         * <summary>Business Name: ReceiverFacilityIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: ReceiverFacilityIdentifier 
         * Relationship: MCCI_MT000100CA.Place2.id 
         * Conformance/Cardinality: POPULATED (1) <p>Identifies the 
         * facility expected to receive the message.</p> <p>May be used 
         * to assist in routing the message. This attribute is optional 
         * because not all environments require communicating this 
         * information.</p> Un-merged Business Name: 
         * ReceiverFacilityIdentifier Relationship: 
         * MCCI_MT000300CA.Place2.id Conformance/Cardinality: MANDATORY 
         * (1) <p>Identifies the facility expected to receive the 
         * message.</p> <p>May be used to assist in routing the 
         * message. This attribute is optional because not all 
         * environments require communicating this information.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"device/asLocatedEntity/location/id"})]
        public Identifier DeviceAsLocatedEntityLocationId {
            get { return this.deviceAsLocatedEntityLocationId.Value; }
            set { this.deviceAsLocatedEntityLocationId.Value = value; }
        }

    }

}