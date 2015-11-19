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
using Ca.Infoway.Messagebuilder.Model.Mock;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "COCT_MT470000CA.ConsentEvent" })]
	public class ConsentEventBean : MessagePartBean, Identifiable
	{
		private const long serialVersionUID = -647607118325387652L;

		private II id = new IIImpl();

		private CD reasonCode = new CDImpl();

		private IdentifiedPersonBean patient;

		private ST signatureText = new STImpl();

		private InformDefinitionBean informDefinition;

		[Hl7XmlMappingAttribute("id")]
		public virtual Identifier Id
		{
            get {
                return this.id.Value;
            }
			set
			{
                this.id.Value = value;
			}
		}

		[Hl7XmlMappingAttribute("subject1/patient")]
		public virtual IdentifiedPersonBean GetPatient()
		{
			return patient;
		}

		public virtual void SetPatient(IdentifiedPersonBean patient)
		{
			this.patient = patient;
		}

		[Hl7XmlMappingAttribute("reasonCode")]
		public virtual ActConsentInformationAccessReason GetReasonCode()
		{
			return (ActConsentInformationAccessReason)this.reasonCode.Value;
		}

		public virtual void SetReasonCode(ActConsentInformationAccessReason reasonCode)
		{
			this.reasonCode.Value = reasonCode;
		}

		[Hl7XmlMappingAttribute("author2/signatureText")]
		public virtual string GetSignatureText()
		{
			return this.signatureText.Value;
		}

		public virtual void SetSignatureText(string signatureText)
		{
			this.signatureText.Value = signatureText;
		}

		[Hl7XmlMappingAttribute("subject2/informDefinition")]
		public virtual InformDefinitionBean GetInformDefinition()
		{
			return informDefinition;
		}

		public virtual void SetInformDefinition(InformDefinitionBean informDefinition)
		{
			this.informDefinition = informDefinition;
		}
	}
}
