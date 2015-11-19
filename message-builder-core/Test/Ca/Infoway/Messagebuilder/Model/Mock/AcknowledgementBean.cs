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
