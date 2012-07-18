/**
 * Copyright 2012 Canada Health Infoway, Inc.
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
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.DevTools;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.DevTools
{
	/// <summary>
	/// HL7 Message
	/// The root class of all messages.
	/// Conveys information about the interaction and how it is
	/// to be processed
	/// </summary>
	[System.Serializable]
	public class HL7MessageBean : MessagePartBean
	{
		private II messageIdentifier = new IIImpl();

		private TS messageTimestamp = new TSImpl();

		private ST securityToken = new STImpl();

		private CS responseType = new CSImpl();

		private II interactionType = new IIImpl();

		private LIST<II, Identifier> conformanceProfileIdentifiers = new LISTImpl<II, Identifier>(typeof(IIImpl));

		private CS processingCode = new CSImpl();

		private CS desiredAcknowledgmentType = new CSImpl();

		private ReceiverBean receiver;

		private ToBeRespondedToByBean respondTo;

		private SenderBean sender;

		private IList<RoutingInstructionLinesBean> attentionLine = new List<RoutingInstructionLinesBean>();

		//@Hl7PartTypeMapping({"MCCI_MT002100CA.Message"})
		//@Hl7RootType
		//<CAE> 
		//    private CAE controlActEvent;
		//    @Hl7XmlMapping({"id"})
		public virtual Identifier GetMessageIdentifier()
		{
			return this.messageIdentifier.Value;
		}

		public virtual void SetMessageIdentifier(Identifier messageIdentifier)
		{
			this.messageIdentifier.Value = messageIdentifier;
		}

		//    @Hl7XmlMapping({"creationTime"})
		public virtual PlatformDate GetMessageTimestamp()
		{
			return this.messageTimestamp.Value;
		}

		public virtual void SetMessageTimestamp(PlatformDate messageTimestamp)
		{
			this.messageTimestamp.Value = messageTimestamp;
		}

		//    @Hl7XmlMapping({"securityText"})
		public virtual string GetSecurityToken()
		{
			return this.securityToken.Value;
		}

		public virtual void SetSecurityToken(string securityToken)
		{
			this.securityToken.Value = securityToken;
		}

		//    @Hl7XmlMapping({"responseModeCode"})
		public virtual ResponseMode GetResponseType()
		{
			return (ResponseMode)this.responseType.Value;
		}

		public virtual void SetResponseType(ResponseMode responseType)
		{
			this.responseType.Value = responseType;
		}

		//    @Hl7XmlMapping({"interactionId"})
		public virtual Identifier GetInteractionType()
		{
			return this.interactionType.Value;
		}

		public virtual void SetInteractionType(Identifier interactionType)
		{
			this.interactionType.Value = interactionType;
		}

		//    @Hl7XmlMapping({"profileId"})
		public virtual IList<Identifier> GetConformanceProfileIdentifiers()
		{
			return this.conformanceProfileIdentifiers.RawList();
		}

		//    @Hl7XmlMapping({"processingCode"})
		public virtual ProcessingID GetProcessingCode()
		{
			return (ProcessingID)this.processingCode.Value;
		}

		public virtual void SetProcessingCode(ProcessingID processingCode)
		{
			this.processingCode.Value = processingCode;
		}

		//    @Hl7XmlMapping({"acceptAckCode"})
		public virtual AcknowledgementCondition GetDesiredAcknowledgmentType()
		{
			return (AcknowledgementCondition)this.desiredAcknowledgmentType.Value;
		}

		public virtual void SetDesiredAcknowledgmentType(AcknowledgementCondition desiredAcknowledgmentType)
		{
			this.desiredAcknowledgmentType.Value = desiredAcknowledgmentType;
		}

		//    @Hl7XmlMapping({"receiver"})
		public virtual ReceiverBean GetReceiver()
		{
			return this.receiver;
		}

		public virtual void SetReceiver(ReceiverBean receiver)
		{
			this.receiver = receiver;
		}

		//    @Hl7XmlMapping({"respondTo"})
		public virtual ToBeRespondedToByBean GetRespondTo()
		{
			return this.respondTo;
		}

		public virtual void SetRespondTo(ToBeRespondedToByBean respondTo)
		{
			this.respondTo = respondTo;
		}

		//    @Hl7XmlMapping({"sender"})
		public virtual SenderBean GetSender()
		{
			return this.sender;
		}

		public virtual void SetSender(SenderBean sender)
		{
			this.sender = sender;
		}

		//    @Hl7XmlMapping({"attentionLine"})
		public virtual IList<RoutingInstructionLinesBean> GetAttentionLine()
		{
			return this.attentionLine;
		}
		//    @Hl7XmlMapping({"controlActEvent"})
		//    public CAE getControlActEvent() {
		//        return this.controlActEvent;
		//    }
		//    public void setControlActEvent(CAE controlActEvent) {
		//        this.controlActEvent = controlActEvent;
		//    }
	}
}
