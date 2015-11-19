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
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "PRPA_MT101102CA.PersonalRelationship", "PRPA_MT101001CA.PersonalRelationship"
		, "PRPA_MT101002CA.PersonalRelationship" })]
	public class PersonalRelationshipBean : MessagePartBean
	{
		private const long serialVersionUID = -42113751918781255L;

		private CD roleType = new CDImpl();

		private II id = new IIImpl();

		private PN name = new PNImpl();

		[Hl7XmlMappingAttribute("code")]
		public virtual PersonalRelationshipRoleType GetRoleType()
		{
			return (PersonalRelationshipRoleType)this.roleType.Value;
		}

		public virtual void SetRoleType(PersonalRelationshipRoleType roleType)
		{
			this.roleType.Value = roleType;
		}

		[Hl7XmlMappingAttribute("relationshipHolder/id")]
		public virtual Identifier GetId()
		{
			return this.id.Value;
		}

		public virtual void SetId(Identifier id)
		{
			this.id.Value = id;
		}

		[Hl7XmlMappingAttribute("relationshipHolder/name")]
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
