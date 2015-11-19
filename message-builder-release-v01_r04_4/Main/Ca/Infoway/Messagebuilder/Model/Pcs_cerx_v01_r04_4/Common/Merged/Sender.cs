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
    using System;


    [Hl7PartTypeMappingAttribute(new string[] {"MCCI_MT000100CA.Sender","MCCI_MT000200CA.Sender","MCCI_MT000300CA.Sender","MCCI_MT102001CA.Sender"})]
    public class Sender : MessagePartBean {

        private TEL telecom;
        private II deviceId;
        private ST deviceName;
        private ST deviceDesc;
        private IVL<TS, Interval<PlatformDate>> deviceExistenceTime;
        private ST deviceManufacturerModelName;
        private ST deviceSoftwareName;
        private II deviceAsAgentRepresentedOrganizationId;
        private II deviceAsLocatedEntityLocationId;

        public Sender() {
            this.telecom = new TELImpl();
            this.deviceId = new IIImpl();
            this.deviceName = new STImpl();
            this.deviceDesc = new STImpl();
            this.deviceExistenceTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.deviceManufacturerModelName = new STImpl();
            this.deviceSoftwareName = new STImpl();
            this.deviceAsAgentRepresentedOrganizationId = new IIImpl();
            this.deviceAsLocatedEntityLocationId = new IIImpl();
        }
        /**
         * <summary>Business Name: SendingNetworkAddress</summary>
         * 
         * <remarks>Un-merged Business Name: SendingNetworkAddress 
         * Relationship: MCCI_MT000300CA.Sender.telecom 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>May be important 
         * for sender validation. Usually also the address to which 
         * responses are sent. This is optional because not all 
         * environments require network addresses.</p> <p>The network 
         * address of the application which sent the message.</p> 
         * Un-merged Business Name: SendingNetworkAddress Relationship: 
         * MCCI_MT102001CA.Sender.telecom Conformance/Cardinality: 
         * POPULATED (1) <p>May be important for sender validation. 
         * Usually also the address to which responses are sent. This 
         * is optional because not all environments require network 
         * addresses.</p> <p>The network address of the application 
         * which sent the message.</p> Un-merged Business Name: 
         * SendingNetworkAddress Relationship: 
         * MCCI_MT000100CA.Sender.telecom Conformance/Cardinality: 
         * OPTIONAL (0-1) <p>May be important for sender validation. 
         * Usually also the address to which responses are sent. This 
         * is optional because not all environments require network 
         * addresses.</p> <p>The network address of the application 
         * which sent the message.</p> Un-merged Business Name: 
         * SendingNetworkAddress Relationship: 
         * MCCI_MT000200CA.Sender.telecom Conformance/Cardinality: 
         * OPTIONAL (0-1) <p>May be important for sender validation. 
         * Usually also the address to which responses are sent. This 
         * is optional because not all environments require network 
         * addresses.</p> <p>The network address of the application 
         * which sent the message.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"telecom"})]
        public TelecommunicationAddress Telecom {
            get { return this.telecom.Value; }
            set { this.telecom.Value = value; }
        }

        /**
         * <summary>Business Name: SendingApplicationIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * SendingApplicationIdentifier Relationship: 
         * MCCI_MT000300CA.Device1.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Because this is the key identifier of where 
         * the message is intended to go, this attribute is 
         * mandatory.</p> <p>The unique identifier of the application 
         * or system to whom the message is being routed.</p> Un-merged 
         * Business Name: SendingApplicationIdentifier Relationship: 
         * MCCI_MT102001CA.Device1.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Because this is the key identifier of where 
         * the message is intended to go, this attribute is 
         * mandatory.</p> <p>The unique identifier of the application 
         * or system to whom the message is being routed.</p> Un-merged 
         * Business Name: SendingApplicationIdentifier Relationship: 
         * MCCI_MT000100CA.Device1.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Because this is the key identifier of where 
         * the message is coming from, this attribute is mandatory.</p> 
         * <p>The unique identifier of the application or system from 
         * where the message is being sent.</p> Un-merged Business 
         * Name: SendingApplicationIdentifier Relationship: 
         * MCCI_MT000200CA.Device1.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Because this is the key identifier of where 
         * the message is intended to go, this attribute is 
         * mandatory.</p> <p>The unique identifier of the application 
         * or system to whom the message is being routed.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"device/id"})]
        public Identifier DeviceId {
            get { return this.deviceId.Value; }
            set { this.deviceId.Value = value; }
        }

        /**
         * <summary>Business Name: SendingApplicationName</summary>
         * 
         * <remarks>Un-merged Business Name: SendingApplicationName 
         * Relationship: MCCI_MT000300CA.Device1.name 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Provides useful 
         * information when debugging.</p> <p>This is the name 
         * associated with the system or application sending the 
         * message.</p> Un-merged Business Name: SendingApplicationName 
         * Relationship: MCCI_MT102001CA.Device1.name 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Provides useful 
         * information when debugging.</p> <p>This is the name 
         * associated with the system or application sending the 
         * message.</p> Un-merged Business Name: SendingApplicationName 
         * Relationship: MCCI_MT000100CA.Device1.name 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Provides useful 
         * information when debugging.</p> <p>This is the name 
         * associated with the system or application sending the 
         * message.</p> Un-merged Business Name: SendingApplicationName 
         * Relationship: MCCI_MT000200CA.Device1.name 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Provides useful 
         * information when debugging.</p> <p>This is the name 
         * associated with the system or application sending the 
         * message.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"device/name"})]
        public String DeviceName {
            get { return this.deviceName.Value; }
            set { this.deviceName.Value = value; }
        }

        /**
         * <summary>Business Name: 
         * SendingApplicationConfigurationInformation</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * SendingApplicationConfigurationInformation Relationship: 
         * MCCI_MT000300CA.Device1.desc Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Provides additional information that may 
         * assist in debugging interactions.</p> <p>Provides additional 
         * information about the configuration of the sending 
         * application. Useful when debugging.</p> Un-merged Business 
         * Name: SendingApplicationConfigurationInformation 
         * Relationship: MCCI_MT102001CA.Device1.desc 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Provides 
         * additional information that may assist in debugging 
         * interactions.</p> <p>Provides additional information about 
         * the configuration of the sending application. Useful when 
         * debugging.</p> Un-merged Business Name: 
         * SendingApplicationConfigurationInformation Relationship: 
         * MCCI_MT000100CA.Device1.desc Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Provides additional information that may 
         * assist in debugging interactions.</p> <p>Provides additional 
         * information about the configuration of the sending 
         * application. Useful when debugging.</p> Un-merged Business 
         * Name: SendingApplicationConfigurationInformation 
         * Relationship: MCCI_MT000200CA.Device1.desc 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Provides 
         * additional information that may assist in debugging 
         * interactions.</p> <p>Provides additional information about 
         * the configuration of the sending application. Useful when 
         * debugging.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"device/desc"})]
        public String DeviceDesc {
            get { return this.deviceDesc.Value; }
            set { this.deviceDesc.Value = value; }
        }

        /**
         * <summary>Business Name: SendingApplicationVersionDate</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * SendingApplicationVersionDate Relationship: 
         * MCCI_MT000300CA.Device1.existenceTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Can help to 
         * isolate the source of a problem when debugging.</p> 
         * <p>Indicates the last time the sending application was 
         * modified or reconfigured.</p> Un-merged Business Name: 
         * SendingApplicationVersionDate Relationship: 
         * MCCI_MT102001CA.Device1.existenceTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Can help to 
         * isolate the source of a problem when debugging.</p> 
         * <p>Indicates the last time the sending application was 
         * modified or reconfigured.</p> Un-merged Business Name: 
         * SendingApplicationVersionDate Relationship: 
         * MCCI_MT000100CA.Device1.existenceTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Can help to 
         * isolate the source of a problem when debugging.</p> 
         * <p>Indicates the last time the sending application was 
         * modified or reconfigured.</p> Un-merged Business Name: 
         * SendingApplicationVersionDate Relationship: 
         * MCCI_MT000200CA.Device1.existenceTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Can help to 
         * isolate the source of a problem when debugging.</p> 
         * <p>Indicates the last time the sending application was 
         * modified or reconfigured.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"device/existenceTime"})]
        public Interval<PlatformDate> DeviceExistenceTime {
            get { return this.deviceExistenceTime.Value; }
            set { this.deviceExistenceTime.Value = value; }
        }

        /**
         * <summary>Business Name: SendingSoftwareVersionNumber</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * SendingSoftwareVersionNumber Relationship: 
         * MCCI_MT000300CA.Device1.manufacturerModelName 
         * Conformance/Cardinality: REQUIRED (0-1) <p>May be used to 
         * filter messages based on the compliance testing of the 
         * sending software.</p> <p>Indicates the version number of the 
         * piece of software used to construct the message.</p> 
         * Un-merged Business Name: SendingSoftwareVersionNumber 
         * Relationship: MCCI_MT102001CA.Device1.manufacturerModelName 
         * Conformance/Cardinality: REQUIRED (0-1) <p>May be used to 
         * filter messages based on the compliance testing of the 
         * sending software.</p> <p>Indicates the version number of the 
         * piece of software used to construct the message.</p> 
         * Un-merged Business Name: SendingSoftwareVersionNumber 
         * Relationship: MCCI_MT000100CA.Device1.manufacturerModelName 
         * Conformance/Cardinality: REQUIRED (0-1) <p>May be used to 
         * filter messages based on the compliance testing of the 
         * sending software.</p> <p>Indicates the version number of the 
         * piece of software used to construct the message.</p> 
         * Un-merged Business Name: SendingSoftwareVersionNumber 
         * Relationship: MCCI_MT000200CA.Device1.manufacturerModelName 
         * Conformance/Cardinality: REQUIRED (0-1) <p>May be used to 
         * filter messages based on the compliance testing of the 
         * sending software.</p> <p>Indicates the version number of the 
         * piece of software used to construct the message.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"device/manufacturerModelName"})]
        public String DeviceManufacturerModelName {
            get { return this.deviceManufacturerModelName.Value; }
            set { this.deviceManufacturerModelName.Value = value; }
        }

        /**
         * <summary>Business Name: SendingApplicationSoftwareName</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * SendingApplicationSoftwareName Relationship: 
         * MCCI_MT000300CA.Device1.softwareName 
         * Conformance/Cardinality: REQUIRED (0-1) <p>May be used to 
         * filter messages based on sending application compliance 
         * testing.</p> <p>Indicates the name of the software used to 
         * construct the message.</p> Un-merged Business Name: 
         * SendingApplicationSoftwareName Relationship: 
         * MCCI_MT102001CA.Device1.softwareName 
         * Conformance/Cardinality: REQUIRED (0-1) <p>May be used to 
         * filter messages based on sending application compliance 
         * testing.</p> <p>Indicates the name of the software used to 
         * construct the message.</p> Un-merged Business Name: 
         * SendingApplicationSoftwareName Relationship: 
         * MCCI_MT000100CA.Device1.softwareName 
         * Conformance/Cardinality: REQUIRED (0-1) <p>May be used to 
         * filter messages based on sending application compliance 
         * testing.</p> <p>Indicates the name of the software used to 
         * construct the message.</p> Un-merged Business Name: 
         * SendingApplicationSoftwareName Relationship: 
         * MCCI_MT000200CA.Device1.softwareName 
         * Conformance/Cardinality: REQUIRED (0-1) <p>May be used to 
         * filter messages based on sending application compliance 
         * testing.</p> <p>Indicates the name of the software used to 
         * construct the message.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"device/softwareName"})]
        public String DeviceSoftwareName {
            get { return this.deviceSoftwareName.Value; }
            set { this.deviceSoftwareName.Value = value; }
        }

        /**
         * <summary>Business Name: SendingOrganizationIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * SendingOrganizationIdentifier Relationship: 
         * MCCI_MT000300CA.Organization1.id Conformance/Cardinality: 
         * MANDATORY (1) <p>May be used for routing/filtering purposes. 
         * Also allows tracking of the original responsible party for 
         * messages which may undergo multiple routing or translation 
         * steps. This attribute is optional because not all 
         * environments require communicating this information.</p> 
         * <p>Uniquely identifies the legal entity responsible for the 
         * content of the message.</p> Un-merged Business Name: 
         * SendingOrganizationIdentifier Relationship: 
         * MCCI_MT102001CA.Organization1.id Conformance/Cardinality: 
         * MANDATORY (1) <p>May be used for routing/filtering purposes. 
         * Also allows tracking of the original responsible party for 
         * messages which may undergo multiple routing or translation 
         * steps. This attribute is optional because not all 
         * environments require communicating this information.</p> 
         * <p>Uniquely identifies the legal entity responsible for the 
         * content of the message.</p> Un-merged Business Name: 
         * SendingOrganizationIdentifier Relationship: 
         * MCCI_MT000100CA.Organization1.id Conformance/Cardinality: 
         * MANDATORY (1) <p>May be used for routing/filtering purposes. 
         * Also allows tracking of the original responsible party for 
         * messages which may undergo multiple routing or translation 
         * steps. This attribute is optional because not all 
         * environments require communicating this information.</p> 
         * <p>Uniquely identifies the legal entity responsible for the 
         * content of the message.</p> Un-merged Business Name: 
         * SendingOrganizationIdentifier Relationship: 
         * MCCI_MT000200CA.Organization1.id Conformance/Cardinality: 
         * MANDATORY (1) <p>May be used for routing/filtering purposes. 
         * Also allows tracking of the original responsible party for 
         * messages which may undergo multiple routing or translation 
         * steps. This attribute is optional because not all 
         * environments require communicating this information.</p> 
         * <p>Uniquely identifies the legal entity responsible for the 
         * content of the message.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"device/asAgent/representedOrganization/id"})]
        public Identifier DeviceAsAgentRepresentedOrganizationId {
            get { return this.deviceAsAgentRepresentedOrganizationId.Value; }
            set { this.deviceAsAgentRepresentedOrganizationId.Value = value; }
        }

        /**
         * <summary>Business Name: SendingFacilityIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: SendingFacilityIdentifier 
         * Relationship: MCCI_MT000300CA.Place1.id 
         * Conformance/Cardinality: MANDATORY (1) <p>May be used for 
         * routing, or for configuration control. This attribute is 
         * optional because not all environments require communicating 
         * this information.</p> <p>The unique identifier of the 
         * hospital, clinic or other facility which constructed the 
         * message.</p> Un-merged Business Name: 
         * SendingFacilityIdentifier Relationship: 
         * MCCI_MT102001CA.Place1.id Conformance/Cardinality: MANDATORY 
         * (1) <p>May be used for routing, or for configuration 
         * control. This attribute is optional because not all 
         * environments require communicating this information.</p> 
         * <p>The unique identifier of the hospital, clinic or other 
         * facility which constructed the message.</p> Un-merged 
         * Business Name: SendingFacilityIdentifier Relationship: 
         * MCCI_MT000100CA.Place1.id Conformance/Cardinality: MANDATORY 
         * (1) <p>May be used for routing, or for configuration 
         * control. This attribute is optional because not all 
         * environments require communicating this information.</p> 
         * <p>The unique identifier of the hospital, clinic or other 
         * facility which constructed the message.</p> Un-merged 
         * Business Name: SendingFacilityIdentifier Relationship: 
         * MCCI_MT000200CA.Place1.id Conformance/Cardinality: MANDATORY 
         * (1) <p>May be used for routing, or for configuration 
         * control. This attribute is optional because not all 
         * environments require communicating this information.</p> 
         * <p>The unique identifier of the hospital, clinic or other 
         * facility which constructed the message.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"device/asLocatedEntity/location/id"})]
        public Identifier DeviceAsLocatedEntityLocationId {
            get { return this.deviceAsLocatedEntityLocationId.Value; }
            set { this.deviceAsLocatedEntityLocationId.Value = value; }
        }

    }

}