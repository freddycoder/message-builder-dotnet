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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.DevTools
{
	[System.Serializable]
	public class ReceiverBean : MessagePartBean
	{
		private const long serialVersionUID = 20111117L;

		private TEL telecom = new TELImpl();

		private II deviceId = new IIImpl();

		private ST deviceName = new STImpl();

		private II deviceAgentAgentOrganizationId = new IIImpl();

		//@Hl7PartTypeMapping({"MCCI_MT002100CA.Receiver","MCCI_MT002200CA.Receiver","MCCI_MT002300CA.Receiver","MCCI_MT102001CA.Receiver"})
		/// <summary>
		/// ReceiverNetworkAddress
		/// JB:Receiver Network Address
		/// The address to which this message is being sent.
		/// soap:Header\wsa:To
		/// Indicates where the message should be sent.
		/// </summary>
		/// <remarks>
		/// ReceiverNetworkAddress
		/// JB:Receiver Network Address
		/// The address to which this message is being sent.
		/// soap:Header\wsa:To
		/// Indicates where the message should be sent. This is
		/// optional because not all environments require network
		/// addresses. It is mandatory when communicating using
		/// SOAP.
		/// </remarks>
		public virtual TelecommunicationAddress GetTelecom()
		{
			//    @Hl7XmlMapping({"telecom"})
			return this.telecom.Value;
		}

		public virtual void SetTelecom(TelecommunicationAddress telecom)
		{
			this.telecom.Value = telecom;
		}

		/// <summary>
		/// ReceiverApplicationIdentifier
		/// JA:Receiver Application Identifier
		/// The unique identifier of the application to which the
		/// message is being sent.
		/// soap:Header\wsa:To\@endpointID
		/// Used for routing and for verification that &quot;yes,
		/// this message is intended for me.&quot; This is mandatory
		/// because it is the key identifier of the receiving
		/// application.
		/// </summary>
		public virtual Identifier GetDeviceId()
		{
			//    @Hl7XmlMapping({"device/id"})
			return this.deviceId.Value;
		}

		public virtual void SetDeviceId(Identifier deviceId)
		{
			this.deviceId.Value = deviceId;
		}

		/// <summary>
		/// ReceiverApplicationName
		/// JE:Receiver Application Name
		/// Name of receiver application.
		/// Optional name of receiver application
		/// JE:Receiver Application Name
		/// Name of the receiver application.
		/// Optional name of the receiver application.
		/// JE:Receiver Application Name
		/// Name of receiver application.
		/// JE:Receiver Application Name
		/// Optional name of receiver application.
		/// Optional application name.
		/// </summary>
		public virtual string GetDeviceName()
		{
			//    @Hl7XmlMapping({"device/name"})
			return this.deviceName.Value;
		}

		public virtual void SetDeviceName(string deviceName)
		{
			this.deviceName.Value = deviceName;
		}

		/// <summary>
		/// ReceiverOrganizationIdentifier
		/// JK:Receiver Organization Identifier
		/// Name of receiver application.
		/// Identifier is the only non-structure attribute in this
		/// class and is therefore mandatory.
		/// </summary>
		/// <remarks>
		/// ReceiverOrganizationIdentifier
		/// JK:Receiver Organization Identifier
		/// Name of receiver application.
		/// Identifier is the only non-structure attribute in this
		/// class and is therefore mandatory. The agent association from
		/// the receiver device (application) to the agent role is
		/// optional.
		/// JK:Receiver Organization Identifier
		/// Receiver organization.
		/// The identifier of the receiver organization. This is
		/// the only non-structural attribute in this class and is
		/// therefore mandatory. Receiver organization is optional (as
		/// the scoper association from the receiver application is
		/// optional).
		/// JK:Receiver Organization Identifier
		/// Organization intended to receive this message
		/// Id is the only attribute in this class which is
		/// non-structural and is therefore mandatory. The agent
		/// association (from the receiver device) is optional.
		/// JK:Receiver Organization Identifier
		/// Unique identifier for the receiver organization.
		/// The identifier is the only non-structural attribute in
		/// this class and is therefore mandatory. The association from
		/// receiver device to agent is optional.
		/// </remarks>
		public virtual Identifier GetDeviceAgentAgentOrganizationId()
		{
			//    @Hl7XmlMapping({"device/agent/agentOrganization/id"})
			return this.deviceAgentAgentOrganizationId.Value;
		}

		public virtual void SetDeviceAgentAgentOrganizationId(Identifier deviceAgentAgentOrganizationId)
		{
			this.deviceAgentAgentOrganizationId.Value = deviceAgentAgentOrganizationId;
		}
	}
}
