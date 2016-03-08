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


using System;
using System.Collections.Generic;
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
	[Hl7PartTypeMappingAttribute(new string[] { "MCCI_MT002300CA.Acknowledgement", "MCCI_MT002200CA.Acknowledgement" })]
	public class AcknowledgementBean : MessagePartBean
	{
		private const long serialVersionUID = -4392983646493404789L;

		[Hl7BusinessNameAttribute("acknowledgedMessageId")]
		private II targetMessage = new IIImpl();

		[Hl7BusinessNameAttribute("acknowledgementCode")]
		private CD acknowledgementType = new CDImpl();

		[Hl7BusinessNameAttribute("numberOfWaitingMessages")]
		private INT messageWaitingNumber = new INTImpl();

		[Hl7BusinessNameAttribute("messageWaitingPriority")]
		private CD messageWaitingPriorityCode = new CDImpl();

		[Hl7BusinessNameAttribute("acknowledgementDetail")]
		private readonly IList<AcknowledgementDetailBean> acknowledgementDetails = new List<AcknowledgementDetailBean>();

		[Hl7XmlMappingAttribute("messageWaitingNumber")]
		public virtual Int32? MessageWaitingNumber
		{
			get
			{
				return this.messageWaitingNumber.Value;
			}
			set
			{
				Int32? messageWaitingNumber = value;
				this.messageWaitingNumber.Value = messageWaitingNumber;
			}
		}

		[Hl7XmlMappingAttribute("messageWaitingPriorityCode")]
		public virtual MessageWaitingPriority MessageWaitingPriorityCode
		{
			get
			{
				return (MessageWaitingPriority)this.messageWaitingPriorityCode.Value;
			}
			set
			{
				MessageWaitingPriority messageWaitingPriorityCode = value;
				this.messageWaitingPriorityCode.Value = messageWaitingPriorityCode;
			}
		}

		[Hl7XmlMappingAttribute("acknowledgementDetail")]
		public virtual IList<AcknowledgementDetailBean> AcknowledgementDetails
		{
			get
			{
				return this.acknowledgementDetails;
			}
		}

		[Hl7XmlMappingAttribute("targetMessage/id")]
		public virtual Identifier TargetMessage
		{
			get
			{
				return this.targetMessage.Value;
			}
			set
			{
				Identifier targetMessage = value;
				this.targetMessage.Value = targetMessage;
			}
		}

		[Hl7XmlMappingAttribute("typeCode")]
		public virtual Ca.Infoway.Messagebuilder.Domainvalue.AcknowledgementType AcknowledgementType
		{
			get
			{
				return (Ca.Infoway.Messagebuilder.Domainvalue.AcknowledgementType)this.acknowledgementType.Value;
			}
			set
			{
				Ca.Infoway.Messagebuilder.Domainvalue.AcknowledgementType acknowledgementType = value;
				this.acknowledgementType.Value = acknowledgementType;
			}
		}
	}
}
