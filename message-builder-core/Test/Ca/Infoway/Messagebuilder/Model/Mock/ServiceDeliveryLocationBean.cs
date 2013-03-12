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
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Model;
using Ca.Infoway.Messagebuilder.Model.Mock;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "COCT_MT240002CA.ServiceDeliveryLocation", "COCT_MT240003CA.ServiceDeliveryLocation_V01R04_3_HOTFIX2"
		, "COCT_MT240003CA.ServiceDeliveryLocation", "COCT_MT240007CA.ServiceDeliveryLocation", "COCT_MT240012CA.ServiceDeliveryLocation_V02R02"
		, "PORX_MT010120CA.ServiceDeliveryLocation", "PORX_MT020060CA.ServiceDeliveryLocation", "PORX_MT020070CA.ServiceDeliveryLocation"
		, "PORX_MT060010CA.ServiceDeliveryLocation", "PORX_MT060040CA.ServiceDeliveryLocation", "PORX_MT060040CA.ServiceDeliveryLocation2"
		 })]
	public class ServiceDeliveryLocationBean : MessagePartBean, Recipient
	{
		private const long serialVersionUID = -1966956136012726201L;

		private II identifier = new IIImpl();

		private ST name = new STImpl();

		private AD addr = new ADImpl();

		private readonly SET<TEL, TelecommunicationAddress> telecom = new SETImpl<TEL, TelecommunicationAddress>(typeof(TELImpl));

		private CD code = new CDImpl();

		[Hl7XmlMappingAttribute("id")]
		public virtual Identifier GetIdentifier()
		{
			return this.identifier.Value;
		}

		public virtual void SetIdentifier(Identifier identifier)
		{
			this.identifier.Value = identifier;
		}

		[Hl7XmlMappingAttribute("location/name")]
		public virtual string GetName()
		{
			return this.name.Value;
		}

		public virtual void SetName(string name)
		{
			this.name.Value = name;
		}

		[Hl7XmlMappingAttribute("addr")]
		public virtual PostalAddress GetAddr()
		{
			return this.addr.Value;
		}

		public virtual void SetAddr(PostalAddress addr)
		{
			this.addr.Value = addr;
		}

		[Hl7XmlMappingAttribute("telecom")]
		public virtual ICollection<TelecommunicationAddress> GetTelecom()
		{
			return this.telecom.RawSet();
		}

		[Hl7XmlMappingAttribute("code")]
		public virtual ServiceDeliveryLocationRoleType GetCode()
		{
			return (ServiceDeliveryLocationRoleType)this.code.Value;
		}

		public virtual void SetCode(ServiceDeliveryLocationRoleType code)
		{
			this.code.Value = code;
		}
	}
}
