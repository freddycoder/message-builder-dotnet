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
using Ca.Infoway.Messagebuilder.Model.Mock;
using Ca.Infoway.Messagebuilder.Platform;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[Hl7PartTypeMappingAttribute(new string[] { "MFMI_MT700711CA.Subject2", "MFMI_MT700716CA.Subject2" })]
	public class RegistrationRequestBean<RR>
	{
		private const long serialVersionUID = -6919002674167520092L;

		private readonly ICollection<ReplacementOfBean> priorRegistrations = new LinkedSet<ReplacementOfBean>();

		protected AssignedDeviceBean assignedDevice;

		protected RR record;

		[Hl7XmlMappingAttribute("registrationRequest/subject/registeredRole")]
		public virtual RR Record
		{
			get
			{
				return this.record;
			}
			set
			{
				RR record = value;
				this.record = record;
			}
		}

		[Hl7XmlMappingAttribute("registrationRequest/custodian/assignedDevice")]
		public virtual AssignedDeviceBean AssignedDevice
		{
			get
			{
				return this.assignedDevice;
			}
			set
			{
				AssignedDeviceBean custodian = value;
				this.assignedDevice = custodian;
			}
		}

		[Hl7XmlMappingAttribute("registrationRequest/replacementOf")]
		public virtual ICollection<ReplacementOfBean> PriorRegistrations
		{
			get
			{
				return priorRegistrations;
			}
		}
	}
}
