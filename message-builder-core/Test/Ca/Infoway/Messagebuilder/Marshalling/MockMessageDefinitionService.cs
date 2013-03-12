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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Service;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class MockMessageDefinitionService : MessageDefinitionService
	{
		private IDictionary<string, MessagePart> parts = new Dictionary<string, MessagePart>();

		private IDictionary<string, Interaction> interactions = new Dictionary<string, Interaction>();

		public virtual IList<Interaction> GetAllInteractions(bool includeDuplicateInteractionsWithChangedBusinessNames)
		{
			return null;
		}

		public virtual IList<Interaction> GetAllInteractions(VersionNumber version)
		{
			return null;
		}

		public virtual IDictionary<string, MessagePart> GetAllMessageParts(Interaction interaction, VersionNumber version)
		{
			return null;
		}

		public virtual Interaction GetInteraction(VersionNumber version, string type)
		{
			return this.interactions.SafeGet(type);
		}

		public virtual MessagePart GetMessagePart(VersionNumber version, string type)
		{
			return this.parts.SafeGet(type);
		}

		public virtual ICollection<string> SupportedVersions
		{
			get
			{
				return null;
			}
		}

		public virtual ICollection<string> GetSupportedVersionsForInteraction(string type)
		{
			return null;
		}

		public virtual void AddPart(string type, MessagePart part)
		{
			this.parts[type] = part;
		}

		public virtual void AddInteraction(string type, Interaction interaction)
		{
			this.interactions[type] = interaction;
		}

		public virtual IDictionary<string, MessagePart> GetAllRelatedMessageParts(MessagePart messagePart, VersionNumber version)
		{
			throw new NotSupportedException();
		}

		public virtual IList<MessagePart> GetAllRootMessageParts()
		{
			throw new NotSupportedException();
		}

		public virtual IList<MessagePart> GetAllRootMessageParts(VersionNumber version)
		{
			throw new NotSupportedException();
		}
	}
}
