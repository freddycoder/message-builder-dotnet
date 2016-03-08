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


using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.DevTools;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.DevTools
{
	/// <summary>
	/// Territorial Authority
	/// RoleClass necessary to support the Jurisdiction within
	/// which the scoping organization exists
	/// Supports business requirement to provide additional
	/// information regarding the jurisdication within the scoping
	/// organization exists.
	/// </summary>
	[System.Serializable]
	public class TerritorialAuthorityBean : MessagePartBean
	{
		private CV territorialAuthorityType = new CVImpl();

		private TerritorialAuthorityBean partTerritorialAuthority;

		private CV jurisdictionType = new CVImpl();

		//@Hl7PartTypeMapping({"PRPM_MT306051CA.TerritorialAuthority"})
		//    @Hl7XmlMapping({"code"})
		public virtual Code GetTerritorialAuthorityType()
		{
			return (Code)this.territorialAuthorityType.Value;
		}

		public virtual void SetTerritorialAuthorityType(Code territorialAuthorityType)
		{
			this.territorialAuthorityType.Value = territorialAuthorityType;
		}

		//    @Hl7XmlMapping({"part/territorialAuthority"})
		public virtual TerritorialAuthorityBean GetPartTerritorialAuthority()
		{
			return this.partTerritorialAuthority;
		}

		public virtual void SetPartTerritorialAuthority(TerritorialAuthorityBean partTerritorialAuthority)
		{
			this.partTerritorialAuthority = partTerritorialAuthority;
		}

		//    @Hl7XmlMapping({"territory/code"})
		public virtual Code GetJurisdictionType()
		{
			return (Code)this.jurisdictionType.Value;
		}

		public virtual void SetJurisdictionType(Code jurisdictionType)
		{
			this.jurisdictionType.Value = jurisdictionType;
		}
	}
}
