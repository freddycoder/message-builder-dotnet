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
