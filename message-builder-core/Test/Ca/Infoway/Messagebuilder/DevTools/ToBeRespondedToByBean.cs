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
	public class ToBeRespondedToByBean : MessagePartBean
	{
		private const long serialVersionUID = 20111117L;

		private TEL telecom = new TELImpl();

		private II deviceId = new IIImpl();

		//@Hl7PartTypeMapping({"MCCI_MT002100CA.RespondTo","MCCI_MT002200CA.RespondTo","MCCI_MT002300CA.RespondTo","MCCI_MT102001CA.RespondTo"})
		/// <summary>
		/// RespondToNetworkAddress
		/// KB:Respond to Network Address
		/// Indicates the address to send acknowledgments of this
		/// message to.
		/// soap:Header\wsa:ReplyTo
		/// Needed when the address to respond to is different
		/// than that of the sender.
		/// </summary>
		/// <remarks>
		/// RespondToNetworkAddress
		/// KB:Respond to Network Address
		/// Indicates the address to send acknowledgments of this
		/// message to.
		/// soap:Header\wsa:ReplyTo
		/// Needed when the address to respond to is different
		/// than that of the sender. This is optional because not all
		/// environments require network addresses. It is required when
		/// communicating using SOAP.
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
		/// RespondToApplicationIdentifier
		/// KA:Respond to Application Identifier
		/// The unique identifier of the applications to which
		/// responses should be sent.
		/// </summary>
		/// <remarks>
		/// RespondToApplicationIdentifier
		/// KA:Respond to Application Identifier
		/// The unique identifier of the applications to which
		/// responses should be sent. Only populated when different from
		/// the sending application id.
		/// soap:Header\wsa:ReplyTo\@endpointID
		/// Allows unique identification and routing to the
		/// application to be responded to. This attribute is mandatory
		/// be cause it is the principal identifier of the application
		/// to respond to.
		/// </remarks>
		public virtual Identifier GetDeviceId()
		{
			//    @Hl7XmlMapping({"device/id"})
			return this.deviceId.Value;
		}

		public virtual void SetDeviceId(Identifier deviceId)
		{
			this.deviceId.Value = deviceId;
		}
	}
}
