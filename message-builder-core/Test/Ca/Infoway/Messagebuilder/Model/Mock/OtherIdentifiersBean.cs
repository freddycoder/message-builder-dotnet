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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "PRPA_MT101102CA.OtherIDs", "PRPA_MT101001CA.OtherIDs", "PRPA_MT101002CA.OtherIDs"
		 })]
	public class OtherIdentifiersBean : MessagePartBean
	{
		private const long serialVersionUID = 3230221453725587616L;

		private readonly SET<II, Identifier> ids = new SETImpl<II, Identifier>(typeof(IIImpl));

		private readonly CD code = new CDImpl();

		private readonly II organizationId = new IIImpl();

		private readonly ST organizationName = new STImpl();

		[Hl7XmlMappingAttribute(new string[] { "id" })]
		public virtual ICollection<Identifier> GetIds()
		{
			return this.ids.RawSet();
		}

		public virtual Identifier GetId()
		{
			return this.GetIds().IsEmpty() ? null : this.GetIds().GetEnumerator().Current;
		}

		[Hl7XmlMappingAttribute(new string[] { "code" })]
		public virtual OtherIdentifierRoleType GetCode()
		{
			return (OtherIdentifierRoleType)this.code.Value;
		}

		public virtual void SetCode(OtherIdentifierRoleType code)
		{
			this.code.Value = code;
		}

		[Hl7XmlMappingAttribute(new string[] { "scopingIdOrganization/id", "assigningIdOrganization/id" })]
		public virtual Identifier GetOrganizationId()
		{
			return this.organizationId.Value;
		}

		public virtual void SetOrganizationId(Identifier organizationId)
		{
			this.organizationId.Value = organizationId;
		}

		[Hl7XmlMappingAttribute(new string[] { "scopingIdOrganization/name", "assigningIdOrganization/name" })]
		public virtual string GetOrganizationName()
		{
			return this.organizationName.Value;
		}

		public virtual void SetOrganizationName(string organizationName)
		{
			this.organizationName.Value = organizationName;
		}
	}
}
