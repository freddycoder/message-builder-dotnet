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
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Model;
using Ca.Infoway.Messagebuilder.Model.Mock;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	public class ControlActEventBean : MessagePartBean
	{
		private const long serialVersionUID = 6665317827119227996L;

		[Hl7BusinessNameAttribute("eventIdentifier")]
		private readonly II eventId = new IIImpl();

		[Hl7BusinessNameAttribute("eventType")]
		private readonly CD code = new CDImpl();

		private readonly CD statusCode = new CDImpl();

		private readonly TS effectiveTime = new TSImpl();

		private AuthorBean author;

		private readonly IList<DetectedIssueBean> issues = new List<DetectedIssueBean>();

		private ServiceDeliveryLocationBean location;

		private AssignedPersonBean responsibleParty;

		private readonly CD reasonCode = new CDImpl();

		private AssignedPersonBean dataEnterer;

		[Hl7XmlMappingAttribute("id")]
		public virtual Identifier GetEventId()
		{
			return this.eventId.Value;
		}

		public virtual void SetEventId(Identifier eventId)
		{
			this.eventId.Value = eventId;
		}

		[Hl7XmlMappingAttribute("code")]
		public virtual HL7TriggerEventCode Code
		{
			get
			{
				return (HL7TriggerEventCode)this.code.Value;
			}
			set
			{
				HL7TriggerEventCode code = value;
				this.code.Value = code;
			}
		}

		[Hl7XmlMappingAttribute("statusCode")]
		public virtual ActStatus GetStatusCode()
		{
			return (ActStatus)this.statusCode.Value;
		}

		public virtual void SetStatusCode(ActStatus statusCode)
		{
			this.statusCode.Value = statusCode;
		}

		public virtual Interval<PlatformDate> GetEffectiveTimeAsInterval()
		{
			return this.effectiveTime.Null ? null : IntervalFactory.CreateLow<PlatformDate>(this.effectiveTime.Value);
		}

		public virtual void SetEffectiveTimeAsInterval(Interval<PlatformDate> date)
		{
			this.effectiveTime.Value = date == null ? null : date.Low;
		}

		[Hl7XmlMappingAttribute("effectiveTime")]
		public virtual PlatformDate GetEffectiveTime()
		{
			return this.effectiveTime.Value;
		}

		public virtual void SetEffectiveTime(PlatformDate date)
		{
			this.effectiveTime.Value = date;
		}

		[Hl7XmlMappingAttribute("author")]
		public virtual AuthorBean GetAuthor()
		{
			return this.author;
		}

		public virtual void SetAuthor(AuthorBean author)
		{
			this.author = author;
		}

		[Hl7XmlMappingAttribute(new string[] { "subjectOf1/detectedIssueEvent", "subjectOf/detectedIssueEvent" })]
		public virtual IList<DetectedIssueBean> GetIssues()
		{
			return this.issues;
		}

		[Hl7XmlMappingAttribute("location/serviceDeliveryLocation")]
		public virtual ServiceDeliveryLocationBean GetLocation()
		{
			return this.location;
		}

		public virtual void SetLocation(ServiceDeliveryLocationBean location)
		{
			this.location = location;
		}

		[Hl7XmlMappingAttribute(new string[] { "responsibleParty/assignedPerson", "responsibleParty/assignedEntity" })]
		public virtual AssignedPersonBean GetResponsibleParty()
		{
			return this.responsibleParty;
		}

		public virtual void SetResponsibleParty(AssignedPersonBean responsibleParty)
		{
			this.responsibleParty = responsibleParty;
		}

		[Hl7XmlMappingAttribute("reasonCode")]
		public virtual ControlActReason GetReasonCode()
		{
			return (ControlActReason)this.reasonCode.Value;
		}

		public virtual void SetReasonCode(ControlActReason reasonCode)
		{
			this.reasonCode.Value = reasonCode;
		}

		[Hl7XmlMappingAttribute("dataEnterer/assignedPerson")]
		public virtual AssignedPersonBean GetDataEnterer()
		{
			return dataEnterer;
		}

		public virtual void SetDataEnterer(AssignedPersonBean dataEnterer)
		{
			this.dataEnterer = dataEnterer;
		}
	}
}
