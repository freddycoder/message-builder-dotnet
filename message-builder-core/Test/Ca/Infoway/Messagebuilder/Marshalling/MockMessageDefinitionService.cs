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
