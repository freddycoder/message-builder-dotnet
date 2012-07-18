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
 * Last modified: $LastChangedDate: 2011-05-17 11:48:36 -0400 (Tue, 17 May 2011) $
 * Revision:      $LastChangedRevision: 2666 $
 */

using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "PRPA_MT101002CA.LanguageCommunication", "PRPA_MT101001CA.LanguageCommunication"
		 })]
	public class LanguageCommunicationBean : MessagePartBean
	{
		private const long serialVersionUID = 2510745260687171285L;

		private readonly CD languageCode = new CDImpl();

		public LanguageCommunicationBean()
		{
		}

		public LanguageCommunicationBean(HumanLanguage languageCode, bool preferenceInd)
		{
			SetLanguageCode(languageCode);
		}

		[Hl7XmlMappingAttribute("languageCode")]
		public virtual HumanLanguage GetLanguageCode()
		{
			return (HumanLanguage)this.languageCode.Value;
		}

		public virtual void SetLanguageCode(HumanLanguage languageCode)
		{
			this.languageCode.Value = languageCode;
		}
	}
}
