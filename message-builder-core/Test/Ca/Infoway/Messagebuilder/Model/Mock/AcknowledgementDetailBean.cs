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
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "MCCI_MT002300CA.AcknowledgementDetail" })]
	public class AcknowledgementDetailBean : MessagePartBean
	{
		private const long serialVersionUID = -6328334018535930961L;

		private readonly CD typeCode = new CDImpl();

		private readonly CD code = new CDImpl();

		private readonly ST text = new STImpl();

		private LIST<ST, string> location = new LISTImpl<ST, string>(typeof(STImpl));

		public AcknowledgementDetailBean()
		{
		}

		public AcknowledgementDetailBean(AcknowledgementDetailType typeCode, AcknowledgementDetailCode code, string text)
		{
			SetTypeCode(typeCode);
			SetCode(code);
			SetText(text);
		}

		[Hl7XmlMappingAttribute("code")]
		public virtual AcknowledgementDetailCode GetCode()
		{
			return (AcknowledgementDetailCode)this.code.Value;
		}

		public virtual void SetCode(AcknowledgementDetailCode code)
		{
			this.code.Value = code;
		}

		[Hl7XmlMappingAttribute("text")]
		public virtual string GetText()
		{
			return this.text.Value;
		}

		public virtual void SetText(string text)
		{
			this.text.Value = text;
		}

		[Hl7XmlMappingAttribute("location")]
		public virtual IList<string> GetLocation()
		{
			return this.location.RawList();
		}

		[Hl7XmlMappingAttribute("typeCode")]
		public virtual AcknowledgementDetailType GetTypeCode()
		{
			return (AcknowledgementDetailType)this.typeCode.Value;
		}

		public virtual void SetTypeCode(AcknowledgementDetailType typeCode)
		{
			this.typeCode.Value = typeCode;
		}
	}
}
