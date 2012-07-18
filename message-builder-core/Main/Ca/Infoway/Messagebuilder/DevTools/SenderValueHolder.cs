using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;

namespace Ca.Infoway.Messagebuilder.DevTools
{
	public class SenderValueHolder
	{
		private TelecommunicationAddress telecom;

		private Identifier deviceId;

		private string deviceName;

		private string deviceDesc;

		private Interval<PlatformDate> deviceExistenceTime;

		private string deviceManufacturerModelName;

		private string deviceSoftwareName;

		private Identifier deviceAgentAgentOrganizationId;

		public virtual TelecommunicationAddress GetTelecom()
		{
			return telecom;
		}

		public virtual void SetTelecom(TelecommunicationAddress telecom)
		{
			this.telecom = telecom;
		}

		public virtual Identifier GetDeviceId()
		{
			return deviceId;
		}

		public virtual void SetDeviceId(Identifier deviceId)
		{
			this.deviceId = deviceId;
		}

		public virtual string GetDeviceName()
		{
			return deviceName;
		}

		public virtual void SetDeviceName(string deviceName)
		{
			this.deviceName = deviceName;
		}

		public virtual string GetDeviceDesc()
		{
			return deviceDesc;
		}

		public virtual void SetDeviceDesc(string deviceDesc)
		{
			this.deviceDesc = deviceDesc;
		}

		public virtual Interval<PlatformDate> GetDeviceExistenceTime()
		{
			return deviceExistenceTime;
		}

		public virtual void SetDeviceExistenceTime(Interval<PlatformDate> deviceExistenceTime)
		{
			this.deviceExistenceTime = deviceExistenceTime;
		}

		public virtual string GetDeviceManufacturerModelName()
		{
			return deviceManufacturerModelName;
		}

		public virtual void SetDeviceManufacturerModelName(string deviceManufacturerModelName)
		{
			this.deviceManufacturerModelName = deviceManufacturerModelName;
		}

		public virtual string GetDeviceSoftwareName()
		{
			return deviceSoftwareName;
		}

		public virtual void SetDeviceSoftwareName(string deviceSoftwareName)
		{
			this.deviceSoftwareName = deviceSoftwareName;
		}

		public virtual Identifier GetDeviceAgentAgentOrganizationId()
		{
			return deviceAgentAgentOrganizationId;
		}

		public virtual void SetDeviceAgentAgentOrganizationId(Identifier deviceAgentAgentOrganizationId)
		{
			this.deviceAgentAgentOrganizationId = deviceAgentAgentOrganizationId;
		}
	}
}
