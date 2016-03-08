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
			TypeCode = typeCode;
			Code = code;
			Text = text;
		}

		[Hl7XmlMappingAttribute("code")]
		public virtual AcknowledgementDetailCode Code
		{
			get
			{
				return (AcknowledgementDetailCode)this.code.Value;
			}
			set
			{
				AcknowledgementDetailCode code = value;
				this.code.Value = code;
			}
		}

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

		[Hl7XmlMappingAttribute("location")]
		public virtual IList<string> Location
		{
			get
			{
				return this.location.RawList();
			}
		}

		[Hl7XmlMappingAttribute("typeCode")]
		public virtual AcknowledgementDetailType TypeCode
		{
			get
			{
				return (AcknowledgementDetailType)this.typeCode.Value;
			}
			set
			{
				AcknowledgementDetailType typeCode = value;
				this.typeCode.Value = typeCode;
			}
		}
	}
}
