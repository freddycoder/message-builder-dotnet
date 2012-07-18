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
