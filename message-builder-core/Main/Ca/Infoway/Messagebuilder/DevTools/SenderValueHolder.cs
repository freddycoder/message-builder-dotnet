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
