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
	/// HL7Message
	/// MCCI_MT002300CA.Message: HL7 Message
	/// The root class of all messages.
	/// Conveys information about the interaction and how it
	/// is to be processed
	/// MCCI_MT002100CA.Message: HL7 Message
	/// The root class of all messages.
	/// Conveys information about the interaction and how it
	/// is to be processed
	/// </summary>
	[System.Serializable]
	public class HL7Message_1Bean : MessagePartBean
	{
		private const long serialVersionUID = 20111117L;

		private II id = new IIImpl();

		private TS creationTime = new TSImpl();

		private ST securityText = new STImpl();

		private CS responseModeCode = new CSImpl();

		private II interactionId = new IIImpl();

		private LIST<II, Identifier> profileId = new LISTImpl<II, Identifier>(typeof(IIImpl));

		private CS processingCode = new CSImpl();

		private CS acceptAckCode = new CSImpl();

		private ReceiverBean receiver;

		private ToBeRespondedToByBean respondTo;

		private SenderBean sender;

		private IList<RoutingInstructionLinesBean> attentionLine = new List<RoutingInstructionLinesBean>();

		private CS processingModeCode = new CSImpl();

		//@Hl7PartTypeMapping({"MCCI_MT002100CA.Message","MCCI_MT002300CA.Message"})
		//@Hl7RootType
		//    private AcknowledgementBean acknowledgement;
		//    private CAE controlActEvent;
		/// <summary>
		/// MessageIdentifier
		/// A:Message Identifier
		/// A unique identifier for the message.
		/// soap:Header\wsa:MessageID
		/// Allows detection of duplicate messages, and allows
		/// tying acknowledgments to the message they are acknowledging.
		/// </summary>
		/// <remarks>
		/// MessageIdentifier
		/// A:Message Identifier
		/// A unique identifier for the message.
		/// soap:Header\wsa:MessageID
		/// Allows detection of duplicate messages, and allows
		/// tying acknowledgments to the message they are acknowledging.
		/// The attribute is therefore mandatory.
		/// </remarks>
		public virtual Identifier GetId()
		{
			//    @Hl7XmlMapping({"id"})
			return this.id.Value;
		}

		public virtual void SetId(Identifier id)
		{
			this.id.Value = id;
		}

		/// <summary>
		/// MessageTimestamp
		/// G:Message Timestamp
		/// Indicates the time this particular message instance
		/// was constructed.
		/// Allows identification of how current the information
		/// in a message is.
		/// </summary>
		/// <remarks>
		/// MessageTimestamp
		/// G:Message Timestamp
		/// Indicates the time this particular message instance
		/// was constructed.
		/// Allows identification of how current the information
		/// in a message is. Also provides a baseline for identifying
		/// the time-zone of other times within the message. As a
		/// result, the attribute is mandatory.
		/// </remarks>
		public virtual PlatformDate GetCreationTime()
		{
			//    @Hl7XmlMapping({"creationTime"})
			return this.creationTime.Value;
		}

		public virtual void SetCreationTime(PlatformDate creationTime)
		{
			this.creationTime.Value = creationTime;
		}

		/// <summary>
		/// SecurityToken
		/// H:Security Token
		/// A locally-defined field used to maintain a session,
		/// identify a user, and/or perform some other function related
		/// to authenticating the message source.
		/// Allows jurisdictions and applications to communicate
		/// authentication and session information.
		/// </summary>
		/// <remarks>
		/// SecurityToken
		/// H:Security Token
		/// A locally-defined field used to maintain a session,
		/// identify a user, and/or perform some other function related
		/// to authenticating the message source.
		/// Allows jurisdictions and applications to communicate
		/// authentication and session information. The attribute is
		/// optional because not all jurisdictions will require this
		/// capability.
		/// </remarks>
		public virtual string GetSecurityText()
		{
			//    @Hl7XmlMapping({"securityText"})
			return this.securityText.Value;
		}

		public virtual void SetSecurityText(string securityText)
		{
			this.securityText.Value = securityText;
		}

		/// <summary>
		/// ResponseType
		/// DA: Response Type
		/// Identifies whether the application level response is
		/// desired immediately (as a direct acknowledgement), on a
		/// deferred basis (as a subsequent independent interaction) or
		/// via queue using polling.
		/// soap:Header\wsa:Action (after the second underscore,
		/// if any, D otherwise)
		/// Essential to determining receiver behavior and
		/// therefore mandatory.
		/// DA: Response Type
		/// Identifies whether the response is desired immediately
		/// (as a direct acknowledgement), on a deferred basis (as a
		/// subsequent independent interaction) or via queue using
		/// polling.
		/// soap:Header\wsa:Action (after the second underscore,
		/// if any, D otherwise)
		/// Essential to determining receiver behavior and
		/// therefore mandatory.
		/// </summary>
		public virtual ResponseMode GetResponseModeCode()
		{
			//    @Hl7XmlMapping({"responseModeCode"})
			return (ResponseMode)this.responseModeCode.Value;
		}

		public virtual void SetResponseModeCode(ResponseMode responseModeCode)
		{
			this.responseModeCode.Value = responseModeCode;
		}

		/// <summary>
		/// InteractionType
		/// B:Interaction Type
		/// Indicates the interaction conveyed by this
		/// message.
		/// soap:Header\wsa:Action (after urn:hl7-org:v3: and
		/// before the second underscore, if any)
		/// Identifies what the receiving application should do,
		/// and how the message should be validated.
		/// </summary>
		/// <remarks>
		/// InteractionType
		/// B:Interaction Type
		/// Indicates the interaction conveyed by this
		/// message.
		/// soap:Header\wsa:Action (after urn:hl7-org:v3: and
		/// before the second underscore, if any)
		/// Identifies what the receiving application should do,
		/// and how the message should be validated. The attribute is
		/// therefore mandatory.
		/// </remarks>
		public virtual Identifier GetInteractionId()
		{
			//    @Hl7XmlMapping({"interactionId"})
			return this.interactionId.Value;
		}

		public virtual void SetInteractionId(Identifier interactionId)
		{
			this.interactionId.Value = interactionId;
		}

		/// <summary>
		/// ConformanceProfileIdentifiers
		/// F:Conformance Profile Identifiers
		/// Identifies the conformance profile(s) this message
		/// complies with.
		/// Indicates any additional validation that may be
		/// appropriate.
		/// </summary>
		/// <remarks>
		/// ConformanceProfileIdentifiers
		/// F:Conformance Profile Identifiers
		/// Identifies the conformance profile(s) this message
		/// complies with.
		/// Indicates any additional validation that may be
		/// appropriate. Also influences what extensions can be
		/// processed.
		/// </remarks>
		public virtual IList<Identifier> GetProfileId()
		{
			//    @Hl7XmlMapping({"profileId"})
			return this.profileId.RawList();
		}

		/// <summary>
		/// ProcessingCode
		/// DB:Processing Code
		/// Indicates whether this message is intended to be
		/// processed as production, test or debug message.
		/// soap:Header\wsa:To\(portion between second-last \ and
		/// third-last \)
		/// Indicates how the message should be handled and is
		/// therefore mandatory.
		/// </summary>
		public virtual ProcessingID GetProcessingCode()
		{
			//    @Hl7XmlMapping({"processingCode"})
			return (ProcessingID)this.processingCode.Value;
		}

		public virtual void SetProcessingCode(ProcessingID processingCode)
		{
			this.processingCode.Value = processingCode;
		}

		/// <summary>
		/// DesiredAcknowledgmentType
		/// E:Desired Acknowledgment Type
		/// Indicates how the message is expected to be
		/// acknowledged.
		/// Provides support for immediate, deferred and polling
		/// mode and distinguishes which mode is desired.
		/// </summary>
		/// <remarks>
		/// DesiredAcknowledgmentType
		/// E:Desired Acknowledgment Type
		/// Indicates how the message is expected to be
		/// acknowledged.
		/// Provides support for immediate, deferred and polling
		/// mode and distinguishes which mode is desired. The attribute
		/// is therefore mandatory.
		/// When using SOAP, this attribute MUST be set to NE
		/// (Never). (Accept acknowledgements are handled via the
		/// transport protocol, not HL7.)
		/// </remarks>
		public virtual AcknowledgementCondition GetAcceptAckCode()
		{
			//    @Hl7XmlMapping({"acceptAckCode"})
			return (AcknowledgementCondition)this.acceptAckCode.Value;
		}

		public virtual void SetAcceptAckCode(AcknowledgementCondition acceptAckCode)
		{
			this.acceptAckCode.Value = acceptAckCode;
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

		//    @Hl7XmlMapping({"acknowledgement"})
		//    public AcknowledgementBean getAcknowledgement() {
		//        return this.acknowledgement;
		//    }
		//    public void setAcknowledgement(AcknowledgementBean acknowledgement) {
		//        this.acknowledgement = acknowledgement;
		//    }
		//
		////    @Hl7XmlMapping({"controlActEvent"})
		//    public CAE getControlActEvent() {
		//        return this.controlActEvent;
		//    }
		//    public void setControlActEvent(CAE controlActEvent) {
		//        this.controlActEvent = controlActEvent;
		//    }
		/// <summary>
		/// ProcessingMode
		/// Processing Mode
		/// This attribute defines whether the message is being
		/// sent in current processing, archive mode, initial load mode,
		/// restore from archive mode
		/// Describes the mode of processing.
		/// </summary>
		/// <remarks>
		/// ProcessingMode
		/// Processing Mode
		/// This attribute defines whether the message is being
		/// sent in current processing, archive mode, initial load mode,
		/// restore from archive mode
		/// Describes the mode of processing. For example current
		/// processing, archive mode, initial load mode, restore from
		/// archive mode.
		/// </remarks>
		public virtual ProcessingMode GetProcessingModeCode()
		{
			//    @Hl7XmlMapping({"processingModeCode"})
			return (ProcessingMode)this.processingModeCode.Value;
		}

		public virtual void SetProcessingModeCode(ProcessingMode processingModeCode)
		{
			this.processingModeCode.Value = processingModeCode;
		}
	}
}
