using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.DevTools;
using Ca.Infoway.Messagebuilder.Domainvalue;

namespace Ca.Infoway.Messagebuilder.DevTools
{
	public class ValueHolder
	{
		private Identifier id;

		private PlatformDate creationTime;

		private string securityText;

		private ResponseMode responseModeCode;

		private IList<Identifier> profileId = Ca.Infoway.Messagebuilder.CollUtils.SynchronizedList(new List<Identifier>());

		private ProcessingID processingCode;

		private ProcessingMode processingModeCode;

		private AcknowledgementCondition acceptAckCode;

		private ReceiverValueHolder receiver = new ReceiverValueHolder();

		private SenderValueHolder sender = new SenderValueHolder();

		private ToBeRespondedToByValueHolder respondTo = new ToBeRespondedToByValueHolder();

		private IList<RoutingInstructionLinesValueHolder> attentionLine = new List<RoutingInstructionLinesValueHolder>();

		public virtual Identifier GetId()
		{
			return this.id;
		}

		public virtual void SetId(Identifier messageIdentifier)
		{
			this.id = messageIdentifier;
		}

		public virtual PlatformDate GetCreationTime()
		{
			return this.creationTime;
		}

		public virtual void SetCreationTime(PlatformDate messageTimestamp)
		{
			this.creationTime = messageTimestamp;
		}

		public virtual string GetSecurityText()
		{
			return this.securityText;
		}

		public virtual void SetSecurityText(string securityToken)
		{
			this.securityText = securityToken;
		}

		public virtual ResponseMode GetResponseModeCode()
		{
			return this.responseModeCode;
		}

		public virtual void SetResponseModeCode(ResponseMode responseType)
		{
			this.responseModeCode = responseType;
		}

		public virtual IList<Identifier> GetProfileId()
		{
			return this.profileId;
		}

		public virtual ProcessingID GetProcessingCode()
		{
			return this.processingCode;
		}

		public virtual void SetProcessingCode(ProcessingID processingCode)
		{
			this.processingCode = processingCode;
		}

		public virtual ProcessingMode GetProcessingModeCode()
		{
			return this.processingModeCode;
		}

		public virtual void SetProcessingModeCode(ProcessingMode processingMode)
		{
			this.processingModeCode = processingMode;
		}

		public virtual AcknowledgementCondition GetAcceptAckCode()
		{
			return this.acceptAckCode;
		}

		public virtual void SetAcceptAckCode(AcknowledgementCondition desiredAcknowledgmentType)
		{
			this.acceptAckCode = desiredAcknowledgmentType;
		}

		public virtual ReceiverValueHolder GetReceiver()
		{
			return this.receiver;
		}

		public virtual void SetReceiver(ReceiverValueHolder receiver)
		{
			this.receiver = receiver;
		}

		public virtual SenderValueHolder GetSender()
		{
			return this.sender;
		}

		public virtual void SetSender(SenderValueHolder sender)
		{
			this.sender = sender;
		}

		public virtual ToBeRespondedToByValueHolder GetRespondTo()
		{
			return respondTo;
		}

		public virtual void SetRespondTo(ToBeRespondedToByValueHolder respondTo)
		{
			this.respondTo = respondTo;
		}

		// FIXME - TM (see RM19207) - this currently does not work due to the nature of MessageBeanFactory handling collections
		public virtual IList<RoutingInstructionLinesValueHolder> GetAttentionLine()
		{
			return attentionLine;
		}

		public virtual void SetAttentionLine(IList<RoutingInstructionLinesValueHolder> attentionLine)
		{
			this.attentionLine = attentionLine;
		}
	}
}
