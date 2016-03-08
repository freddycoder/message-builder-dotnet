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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */


using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "COCT_MT090310CA.AssignedDevice" })]
	public class AssignedDeviceBean : MessagePartBean
	{
		private const long serialVersionUID = 5659630456107426952L;

		private II id = new IIImpl();

		private ST assignedRepository = new STImpl();

		private ST representedRepositoryJurisdiction = new STImpl();

		[Hl7XmlMappingAttribute("id")]
		public virtual Identifier Id
		{
			get
			{
				return this.id.Value;
			}
			set
			{
				Identifier id = value;
				this.id.Value = id;
			}
		}

		[Hl7XmlMappingAttribute("assignedRepository/name")]
		public virtual string AssignedRepository
		{
			get
			{
				return this.assignedRepository.Value;
			}
			set
			{
				string assignedRepository = value;
				this.assignedRepository.Value = assignedRepository;
			}
		}

		[Hl7XmlMappingAttribute("representedRepositoryJurisdiction/name")]
		public virtual string RepresentedRepositoryJurisdiction
		{
			get
			{
				return this.representedRepositoryJurisdiction.Value;
			}
			set
			{
				string representedRepositoryJurisdiction = value;
				this.representedRepositoryJurisdiction.Value = representedRepositoryJurisdiction;
			}
		}
	}
}
