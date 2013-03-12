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
using Ca.Infoway.Messagebuilder.Model;
using Ca.Infoway.Messagebuilder.Model.Mock;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "COCT_MT050202CA.Patient", "COCT_MT050203CA.Patient", "COCT_MT050207CA.Patient"
		, "PRPA_MT101001CA.IdentifiedEntity", "PRPA_MT101002CA.IdentifiedEntity", "PRPA_MT101003CA.IdentifiedEntity", "PRPA_MT101102CA.IdentifiedEntity"
		, "PRPA_MT101104CA.IdentifiedEntity", "PRPA_MT101106CA.IdentifiedEntity" })]
	public class IdentifiedPersonBean : MessagePartBean
	{
		private const long serialVersionUID = 6526376510028522480L;

		private readonly SET<II, Identifier> ids = new SETImpl<II, Identifier>(typeof(IIImpl));

		private readonly AD address = new ADImpl();

		private readonly LIST<TEL, TelecommunicationAddress> telecom = new LISTImpl<TEL, TelecommunicationAddress>(typeof(TELImpl
			));

		private IndeterminatePersonBean indeterminatePerson = new IndeterminatePersonBean();

		private readonly CD statusCode = new CDImpl();

		private readonly IVL<TS, Interval<PlatformDate>> effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();

		private readonly CD confidentialityCode = new CDImpl();

		private ObservationEventMatchBean observationEventBean;

		[Hl7XmlMappingAttribute("id")]
		public virtual ICollection<Identifier> GetIds()
		{
			return this.ids.RawSet();
		}

		public virtual Identifier GetId()
		{
			return this.GetIds().IsEmpty() ? null : new List<Identifier>(this.GetIds())[0];
		}

		public virtual void SetId(Identifier id)
		{
			this.GetIds().Clear();
			this.GetIds().Add(id);
		}

		[Hl7XmlMappingAttribute("addr")]
		public virtual PostalAddress GetAddress()
		{
			return this.address.Value;
		}

		public virtual void SetAddress(PostalAddress address)
		{
			this.address.Value = address;
		}

		[Hl7XmlMappingAttribute("telecom")]
		public virtual IList<TelecommunicationAddress> GetTelecom()
		{
			return this.telecom.RawList();
		}

		[Hl7XmlMappingAttribute(new string[] { "patientPerson", "agentPerson", "identifiedPerson" })]
		public virtual IndeterminatePersonBean GetIndeterminatePerson()
		{
			return indeterminatePerson;
		}

		public virtual void SetIndeterminatePerson(IndeterminatePersonBean indeterminatePerson)
		{
			this.indeterminatePerson = indeterminatePerson;
		}

		[Hl7XmlMappingAttribute("statusCode")]
		public virtual RoleStatus GetStatusCode()
		{
			return (RoleStatus)this.statusCode.Value;
		}

		public virtual void SetStatusCode(RoleStatus statusCode)
		{
			this.statusCode.Value = statusCode;
		}

		[Hl7XmlMappingAttribute("effectiveTime")]
		public virtual Interval<PlatformDate> GetEffectiveTime()
		{
			return this.effectiveTime.Value;
		}

		public virtual void SetEffectiveTime(Interval<PlatformDate> effectiveTime)
		{
			this.effectiveTime.Value = effectiveTime;
		}

		[Hl7XmlMappingAttribute("confidentialityCode")]
		public virtual x_NormalRestrictedTabooConfidentialityKind GetConfidentialityCode()
		{
			return (x_NormalRestrictedTabooConfidentialityKind)this.confidentialityCode.Value;
		}

		public virtual void SetConfidentialityCode(x_NormalRestrictedTabooConfidentialityKind confidentialityCode)
		{
			this.confidentialityCode.Value = confidentialityCode;
		}

		[Hl7XmlMappingAttribute("subjectOf/observationEvent")]
		public virtual ObservationEventMatchBean GetObservationEventBean()
		{
			return observationEventBean;
		}

		public virtual void SetObservationEventBean(ObservationEventMatchBean observationEventBean)
		{
			this.observationEventBean = observationEventBean;
		}
	}
}
