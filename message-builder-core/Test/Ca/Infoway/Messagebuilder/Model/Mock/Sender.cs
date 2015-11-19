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
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "MCCI_MT002100CA.Sender", "MCCI_MT002300CA.Sender", "MCCI_MT000100CA.Sender", 
		"MCCI_MT102001CA.Sender", "MCCI_MT000300CA.Sender" })]
	public class Sender : MessagePartBean
	{
		private const long serialVersionUID = 6418261934692624819L;

		[Hl7BusinessNameAttribute("sendingNetworkAddress")]
		private TEL telecommunicationAddress = new TELImpl();

		[Hl7BusinessNameAttribute("sendingApplicationIdentifier")]
		private II deviceId = new IIImpl();

		[Hl7BusinessNameAttribute("sendingApplicationName")]
		private ST deviceName = new STImpl();

		[Hl7BusinessNameAttribute("sendingApplicationSoftwareName")]
		private ST softwareName = new STImpl();

		[Hl7BusinessNameAttribute("sendingSoftwareVersionNumber")]
		private ST manufacturerModelNumber = new STImpl();

		[Hl7BusinessNameAttribute("sendingOrganizationIdentifier")]
		private II sendingOrganizationIdentifier = new IIImpl();

		[Hl7XmlMappingAttribute("device/id")]
		public virtual Identifier DeviceId
		{
			get
			{
				return this.deviceId.Value;
			}
			set
			{
				Identifier deviceId = value;
				this.deviceId.Value = deviceId;
			}
		}

		[Hl7XmlMappingAttribute("device/name")]
		public virtual string DeviceName
		{
			get
			{
				return this.deviceName.Value;
			}
			set
			{
				string deviceName = value;
				this.deviceName.Value = deviceName;
			}
		}

		[Hl7XmlMappingAttribute("device/softwareName")]
		public virtual string SoftwareName
		{
			get
			{
				return this.softwareName.Value;
			}
			set
			{
				string softwareName = value;
				this.softwareName.Value = softwareName;
			}
		}

		[Hl7XmlMappingAttribute("device/manufacturerModelName")]
		public virtual string ManufacturerModelNumber
		{
			get
			{
				return this.manufacturerModelNumber.Value;
			}
			set
			{
				string manufacturerModelNumber = value;
				this.manufacturerModelNumber.Value = manufacturerModelNumber;
			}
		}

		[Hl7XmlMappingAttribute("telecom")]
		public virtual Ca.Infoway.Messagebuilder.Datatype.Lang.TelecommunicationAddress TelecommunicationAddress
		{
			get
			{
				return this.telecommunicationAddress.Value;
			}
			set
			{
				Ca.Infoway.Messagebuilder.Datatype.Lang.TelecommunicationAddress telecommunicationsAddress = value;
				this.telecommunicationAddress.Value = telecommunicationsAddress;
			}
		}

		[Hl7XmlMappingAttribute("device/agent/agentOrganization/id")]
		public virtual Identifier SendingOrganizationIdentifier
		{
			get
			{
				return this.sendingOrganizationIdentifier.Value;
			}
			set
			{
				Identifier sendingOrganizationIdentifier = value;
				this.sendingOrganizationIdentifier.Value = sendingOrganizationIdentifier;
			}
		}
	}
}
