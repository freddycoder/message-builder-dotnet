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
		public virtual Int32? GetMessageWaitingNumber()
		{
			return this.messageWaitingNumber.Value;
		}

		public virtual void SetMessageWaitingNumber(Int32? messageWaitingNumber)
		{
			this.messageWaitingNumber.Value = messageWaitingNumber;
		}

		[Hl7XmlMappingAttribute("messageWaitingPriorityCode")]
		public virtual MessageWaitingPriority GetMessageWaitingPriorityCode()
		{
			return (MessageWaitingPriority)this.messageWaitingPriorityCode.Value;
		}

		public virtual void SetMessageWaitingPriorityCode(MessageWaitingPriority messageWaitingPriorityCode)
		{
			this.messageWaitingPriorityCode.Value = messageWaitingPriorityCode;
		}

		[Hl7XmlMappingAttribute("acknowledgementDetail")]
		public virtual IList<AcknowledgementDetailBean> GetAcknowledgementDetails()
		{
			return this.acknowledgementDetails;
		}

		[Hl7XmlMappingAttribute("targetMessage/id")]
		public virtual Identifier GetTargetMessage()
		{
			return this.targetMessage.Value;
		}

		public virtual void SetTargetMessage(Identifier targetMessage)
		{
			this.targetMessage.Value = targetMessage;
		}

		[Hl7XmlMappingAttribute("typeCode")]
		public virtual AcknowledgementType GetAcknowledgementType()
		{
			return (AcknowledgementType)this.acknowledgementType.Value;
		}

		public virtual void SetAcknowledgementType(AcknowledgementType acknowledgementType)
		{
			this.acknowledgementType.Value = acknowledgementType;
		}
	}
}
