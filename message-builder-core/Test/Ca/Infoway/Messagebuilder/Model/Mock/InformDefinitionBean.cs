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
using Ca.Infoway.Messagebuilder.Model;
using Ca.Infoway.Messagebuilder.Model.Mock;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "COCT_MT470000CA.InformDefinition" })]
	public class InformDefinitionBean : MessagePartBean
	{
		private const long serialVersionUID = -377645382168732286L;

		private IList<InformationAccessTypeBean> actDefinitions = new List<InformationAccessTypeBean>();

		private Recipient recipient;

		[Hl7XmlMappingAttribute("subject")]
		public virtual IList<InformationAccessTypeBean> GetActDefinitions()
		{
			return actDefinitions;
		}

		public virtual void SetActDefinitions(IList<InformationAccessTypeBean> actDefinitions)
		{
			this.actDefinitions = actDefinitions;
		}

		[Hl7XmlMappingAttribute("receiver/recipient")]
		public virtual Recipient GetRecipient()
		{
			return recipient;
		}

		public virtual void SetRecipient(Recipient recipient)
		{
			this.recipient = recipient;
		}
	}
}
