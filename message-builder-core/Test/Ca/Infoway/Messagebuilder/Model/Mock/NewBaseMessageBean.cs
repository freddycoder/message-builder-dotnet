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
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	public abstract class NewBaseMessageBean : MessagePartBean, IInteraction
	{
		private const long serialVersionUID = -510232459510481417L;

		private II messageIdentifier = new IIImpl();

		private TS messageTimestamp = new TSImpl();

		private ST securityToken = new STImpl();

		private CS responseType = new CSImpl();

		private II interactionType = new IIImpl();

		private LIST<II, Identifier> conformanceProfileIdentifiers = new LISTImpl<II, Identifier>(typeof(IIImpl));

		private CS processingCode = new CSImpl();

		private CS processingMode = new CSImpl();

		private CS desiredAcknowledgmentType = new CSImpl();

		private Ca.Infoway.Messagebuilder.Model.Mock.Receiver receiver;

		private Ca.Infoway.Messagebuilder.Model.Mock.Sender sender;

		[Hl7XmlMappingAttribute(new string[] { "id" })]
		public virtual Identifier MessageIdentifier
		{
			get
			{
				return this.messageIdentifier.Value;
			}
			set
			{
				Identifier messageIdentifier = value;
				this.messageIdentifier.Value = messageIdentifier;
			}
		}

		[Hl7XmlMappingAttribute(new string[] { "creationTime" })]
		public virtual PlatformDate MessageTimestamp
		{
			get
			{
				return this.messageTimestamp.Value;
			}
			set
			{
				PlatformDate messageTimestamp = value;
				this.messageTimestamp.Value = messageTimestamp;
			}
		}

		[Hl7XmlMappingAttribute(new string[] { "securityText" })]
		public virtual string SecurityToken
		{
			get
			{
				return this.securityToken.Value;
			}
			set
			{
				string securityToken = value;
				this.securityToken.Value = securityToken;
			}
		}

		[Hl7XmlMappingAttribute(new string[] { "responseModeCode" })]
		public virtual ResponseMode ResponseType
		{
			get
			{
				return (ResponseMode)this.responseType.Value;
			}
			set
			{
				ResponseMode responseType = value;
				this.responseType.Value = responseType;
			}
		}

		[Hl7XmlMappingAttribute(new string[] { "interactionId" })]
		public virtual Identifier InteractionType
		{
			get
			{
				return this.interactionType.Value;
			}
			set
			{
				Identifier interactionType = value;
				this.interactionType.Value = interactionType;
			}
		}

		[Hl7XmlMappingAttribute(new string[] { "profileId" })]
		public virtual IList<Identifier> GetConformanceProfileIdentifiers()
		{
			return this.conformanceProfileIdentifiers.RawList();
		}

		[Hl7XmlMappingAttribute(new string[] { "processingCode" })]
		public virtual ProcessingID ProcessingCode
		{
			get
			{
				return (ProcessingID)this.processingCode.Value;
			}
			set
			{
				ProcessingID processingCode = value;
				this.processingCode.Value = processingCode;
			}
		}

		[Hl7XmlMappingAttribute(new string[] { "acceptAckCode" })]
		public virtual AcknowledgementCondition DesiredAcknowledgmentType
		{
			get
			{
				return (AcknowledgementCondition)this.desiredAcknowledgmentType.Value;
			}
			set
			{
				AcknowledgementCondition desiredAcknowledgmentType = value;
				this.desiredAcknowledgmentType.Value = desiredAcknowledgmentType;
			}
		}

		[Hl7XmlMappingAttribute(new string[] { "receiver" })]
		public virtual Ca.Infoway.Messagebuilder.Model.Mock.Receiver Receiver
		{
			get
			{
				return this.receiver;
			}
			set
			{
				Ca.Infoway.Messagebuilder.Model.Mock.Receiver receiver = value;
				this.receiver = receiver;
			}
		}

		[Hl7XmlMappingAttribute(new string[] { "sender" })]
		public virtual Ca.Infoway.Messagebuilder.Model.Mock.Sender Sender
		{
			get
			{
				return this.sender;
			}
			set
			{
				Ca.Infoway.Messagebuilder.Model.Mock.Sender sender = value;
				this.sender = sender;
			}
		}

		[Hl7XmlMappingAttribute(new string[] { "processingModeCode" })]
		public virtual Ca.Infoway.Messagebuilder.Domainvalue.ProcessingMode ProcessingMode
		{
			get
			{
				return (Ca.Infoway.Messagebuilder.Domainvalue.ProcessingMode)this.processingMode.Value;
			}
			set
			{
				Ca.Infoway.Messagebuilder.Domainvalue.ProcessingMode processingMode = value;
				this.processingMode.Value = processingMode;
			}
		}
	}
}
