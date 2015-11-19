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
	[Hl7PartTypeMappingAttribute(new string[] { "MFMI_MT700716CA.ReplacementOf" })]
	public class ReplacementOfBean : MessagePartBean
	{
		private const long serialVersionUID = -4042017390746338658L;

		private readonly II id = new IIImpl();

		private readonly CD roleClass = new CDImpl(Ca.Infoway.Messagebuilder.Domainvalue.Payload.RoleClass.ROLE);

		[Hl7XmlMappingAttribute("priorRegistration/subject/priorRegisteredRole/id")]
		public virtual Identifier GetId()
		{
			return this.id.Value;
		}

		[Hl7XmlMappingAttribute("priorRegistration/subject/priorRegisteredRole/classCode")]
		public virtual RoleClass GetRoleClass()
		{
			return (RoleClass)this.roleClass.Value;
		}

		public virtual void SetId(Identifier id)
		{
			this.id.Value = id;
		}

		public virtual void SetRoleClass(RoleClass roleClass)
		{
			this.roleClass.Value = roleClass;
		}
	}
}
