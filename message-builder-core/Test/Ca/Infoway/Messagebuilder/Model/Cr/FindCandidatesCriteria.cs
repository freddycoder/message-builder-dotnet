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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Model.Mock;

namespace Ca.Infoway.Messagebuilder.Model.Cr
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute("PRPA_MT101103CA.ParameterList")]
	public class FindCandidatesCriteria : PersonQueryCriteria
	{
		private const long serialVersionUID = -8159830797683245013L;

		private LIST<II, Identifier> identifiers = new LISTImpl<II, Identifier>(typeof(IIImpl));

		[Hl7BusinessNameAttribute("clientName")]
		private IList<PN> personNames = new List<PN>();

		[Hl7BusinessNameAttribute("clientGender")]
		private readonly CD gender = new CDImpl();

		[Hl7BusinessNameAttribute("clientAddress")]
		private IList<AD> addresses = new List<AD>();

		[Hl7BusinessNameAttribute("clientTelecom")]
		private IList<TEL> telecoms = new List<TEL>();

		[Hl7BusinessNameAttribute("clientDateOfBirth")]
		private readonly TS birthDate = new TSImpl();

		[Hl7XmlMappingAttribute("personBirthtime/value")]
		public virtual PlatformDate BirthDate
		{
			get
			{
				return this.birthDate.Value;
			}
			set
			{
				PlatformDate birthDate = value;
				this.birthDate.Value = birthDate;
			}
		}

		/// <summary>
		/// (Client Healthcare Identification Number And Or NonHealthcare Identification.
		/// Healthcare identiers may be assigned jurisdictionally or by care facility
		/// and/or non-healthcare identifiers for the Client (e.g.
		/// </summary>
		/// <remarks>
		/// (Client Healthcare Identification Number And Or NonHealthcare Identification.
		/// Healthcare identiers may be assigned jurisdictionally or by care facility
		/// and/or non-healthcare identifiers for the Client (e.g. Passport, SIN, DND,
		/// DIAND, Drivers License)
		/// Mandatory attribute supports the identification of the client.
		/// </remarks>
		[Hl7XmlMappingAttribute("clientId/value")]
		public virtual IList<Identifier> Identifiers
		{
			get
			{
				return this.identifiers.RawList();
			}
		}

		/// <summary>
		/// Client Name
		/// Name(s) for the Client.
		/// Mandatory attribute supports the identification of the client.
		/// </summary>
		[Hl7XmlMappingAttribute("personName/value")]
		public virtual IList<PersonName> PersonNames
		{
			get
			{
				return new RawListWrapper<PN, PersonName>(this.personNames, typeof(PNImpl));
			}
		}

		/// <summary>
		/// Client Address.
		/// Address(es) of the Client.
		/// Mandatory attribute supports the identification of the client.
		/// </summary>
		[Hl7XmlMappingAttribute("personAddress/value")]
		public virtual IList<PostalAddress> Addresses
		{
			get
			{
				return new RawListWrapper<AD, PostalAddress>(this.addresses, typeof(ADImpl));
			}
		}

		/// <summary>
		/// Client Telecom.
		/// Provides information about telecom.
		/// Mandatory attribute supports the identification of the client.
		/// </summary>
		[Hl7XmlMappingAttribute("personTelecom/value")]
		public virtual IList<TelecommunicationAddress> Telecoms
		{
			get
			{
				return new RawListWrapper<TEL, TelecommunicationAddress>(this.telecoms, typeof(TELImpl));
			}
		}

		[Hl7XmlMappingAttribute("administrativeGender/value")]
		public virtual AdministrativeGender Gender
		{
			get
			{
				return (AdministrativeGender)this.gender.Value;
			}
			set
			{
				AdministrativeGender gender = value;
				this.gender.Value = gender;
			}
		}
	}
}
