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
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.Model.Pr
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "NLPN_MT100200CA.PasswordChange" })]
	public class PasswordChangeBean : MessagePartBean
	{
		private const long serialVersionUID = 3617565414992486010L;

		private ST text = new STImpl();

		[Hl7XmlMappingAttribute("text")]
		public virtual string Text
		{
			get
			{
				return this.text.Value;
			}
			set
			{
				string text = value;
				this.text.Value = text;
			}
		}
	}
}
