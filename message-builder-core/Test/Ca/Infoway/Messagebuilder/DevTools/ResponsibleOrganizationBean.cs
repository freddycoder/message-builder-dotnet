/**
 * Copyright 2012 Canada Health Infoway, Inc.
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
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.DevTools;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.DevTools
{
	[System.Serializable]
	public class ResponsibleOrganizationBean : MessagePartBean
	{
		private II receiverOrganizationIdentifier = new IIImpl();

		private ST responsibleOrganizationName = new STImpl();

		private IList<TerritorialAuthorityBean> territorialAuthority = new List<TerritorialAuthorityBean>();

		//@Hl7PartTypeMapping({"MCCI_MT002100CA.Organization","MCCI_MT002100CA.Organization2","MCCI_MT002200CA.Organization","MCCI_MT002200CA.Organization2","MCCI_MT002300CA.Organization","MCCI_MT002300CA.Organization2","MCCI_MT102001CA.Organization","MCCI_MT102001CA.Organization2","PRPA_MT202301CA.Organization","PRPA_MT202302CA.Organization","PRPA_MT202303CA.Organization","PRPM_MT306051CA.Organization"})
		//    @Hl7XmlMapping({"id"})
		public virtual Identifier GetReceiverOrganizationIdentifier()
		{
			return this.receiverOrganizationIdentifier.Value;
		}

		public virtual void SetReceiverOrganizationIdentifier(Identifier receiverOrganizationIdentifier)
		{
			this.receiverOrganizationIdentifier.Value = receiverOrganizationIdentifier;
		}

		//    @Hl7XmlMapping({"name"})
		public virtual string GetResponsibleOrganizationName()
		{
			return this.responsibleOrganizationName.Value;
		}

		public virtual void SetResponsibleOrganizationName(string responsibleOrganizationName)
		{
			this.responsibleOrganizationName.Value = responsibleOrganizationName;
		}

		//    @Hl7XmlMapping({"territorialAuthority"})
		public virtual IList<TerritorialAuthorityBean> GetTerritorialAuthority()
		{
			return this.territorialAuthority;
		}
	}
}
