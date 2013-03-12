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
using Ca.Infoway.Messagebuilder;
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
	[Hl7PartTypeMappingAttribute(new string[] { "MFMI_MT700711CA.Author", "QUQI_MT020000CA.Author", "MFMI_MT700751CA.Author", 
		"COCT_MT120600CA.Author", "MCAI_MT700210CA.Author", "PORX_MT020070CA.Author", "PORX_MT060010CA.Author6", "PORX_MT060040CA.Author"
		, "PORX_MT060040CA.Author4", "PORX_MT060060CA.Author", "PORX_MT060060CA.Author2", "PORX_MT060090CA.Author5", "PORX_MT980030CA.Author1"
		, "PORX_MT980030CA.Author2", "REPC_MT000005CA.Author", "REPC_MT000007CA.Author", "PORX_MT030040CA.Author2", "REPC_MT000017CA.Author"
		, "REPC_MT100001CA.Author", "REPC_MT210001CA.Author", "PORX_MT030040CA.Author", "PORX_MT020060CA.Author", "PORX_MT060190CA.Author2"
		, "PORX_MT060190CA.Author3" })]
	public class AuthorBean : MessagePartBean
	{
		private const long serialVersionUID = -7391826388673357574L;

		[Hl7BusinessNameAttribute("timeOfCreation")]
		private TS time = new TSImpl();

		private AssignedPersonBean assignedPerson = new AssignedPersonBean();

		private ST organizationName = new STImpl();

		private CD signatureCode = new CDImpl();

		[Hl7XmlMappingAttribute("time")]
		public virtual PlatformDate Time
		{
			get
			{
				return this.time.Value;
			}
			set
			{
				PlatformDate time = value;
				this.time.Value = time;
			}
		}

		[Hl7XmlMappingAttribute(new string[] { "authorPerson", "choice0", "changedBy", "assignedPerson", "actingPerson" })]
		public virtual AssignedPerson AuthorPerson
		{
			get
			{
				return this.assignedPerson;
			}
			set
			{
				AssignedPerson assignedPerson = value;
				if (assignedPerson is AssignedPersonBean)
				{
					this.assignedPerson = (AssignedPersonBean)assignedPerson;
				}
			}
		}

		[Hl7XmlMappingAttribute(new string[] { "assignedEntity/assignedOrganization/name" })]
		public virtual string OrganizationName
		{
			get
			{
				return this.organizationName.Value;
			}
			set
			{
				string organizationName = value;
				this.organizationName.Value = organizationName;
			}
		}

		[Hl7XmlMappingAttribute("signatureCode")]
		public virtual ParticipationSignature GetSignatureCode()
		{
			return (ParticipationSignature)this.signatureCode.Value;
		}

		public virtual void SetSignatureCode(ParticipationSignature signatureCode)
		{
			this.signatureCode.Value = signatureCode;
		}

		public virtual Identifier GetId()
		{
			return this.assignedPerson.GetId();
		}

		public virtual void SetId(Identifier identifier)
		{
			this.assignedPerson.SetId(identifier);
		}

		public virtual Identifier GetLicenseNumber()
		{
			return this.assignedPerson.GetLicenseNumber();
		}

		public virtual void SetLicenseNumber(Identifier identifier)
		{
			this.assignedPerson.SetLicenseNumber(identifier);
		}

		public virtual PersonName GetName()
		{
			return this.assignedPerson.GetName();
		}

		public virtual void SetName(PersonName personName)
		{
			this.assignedPerson.SetName(personName);
		}
	}
}
