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
	[Hl7PartTypeMappingAttribute(new string[] { "COCT_MT090107CA.AssignedPerson", "MCAI_MT700210CA.ResponsibleParty", "COCT_MT090102CA.AssignedEntity"
		, "COCT_MT090108CA.AssignedEntity" })]
	public class AssignedPersonBean : MessagePartBean, AssignedPerson
	{
		private const long serialVersionUID = 5659630456107426952L;

		private readonly SET<II, Identifier> ids = new SETImpl<II, Identifier>(typeof(IIImpl));

		private readonly CD code = new CDImpl();

		private readonly II licenseNumber = new IIImpl();

		private readonly PN name = new PNImpl();

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

		[Hl7XmlMappingAttribute("code")]
		public virtual HealthcareProviderRoleType GetCode()
		{
			return (HealthcareProviderRoleType)this.code.Value;
		}

		public virtual void SetCode(HealthcareProviderRoleType code)
		{
			this.code.Value = code;
		}

		[Hl7XmlMappingAttribute(new string[] { "representedPerson/asLicensedEntity/id", "assignedPerson/asHealthCareProvider/id" }
			)]
		public virtual Identifier GetLicenseNumber()
		{
			return this.licenseNumber.Value;
		}

		public virtual void SetLicenseNumber(Identifier licenseNumber)
		{
			this.licenseNumber.Value = licenseNumber;
		}

		[Hl7XmlMappingAttribute(new string[] { "representedPerson/name", "assignedPerson/name" })]
		public virtual PersonName GetName()
		{
			return this.name.Value;
		}

		public virtual void SetName(PersonName name)
		{
			this.name.Value = name;
		}
	}
}
