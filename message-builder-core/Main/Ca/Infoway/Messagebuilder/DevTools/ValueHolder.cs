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

		// FIXME - TM - this currently does not work due to the nature of MessageBeanFactory handling collections
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
