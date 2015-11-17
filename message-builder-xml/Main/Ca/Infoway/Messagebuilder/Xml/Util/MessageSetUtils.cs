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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Xml.Util
{
	public class MessageSetUtils
	{
		private readonly MessageSet messageSet;

		public MessageSetUtils(MessageSet messageSet)
		{
			this.messageSet = messageSet;
		}

		public virtual Interaction GetInteraction(string type)
		{
			return this.messageSet.Interactions.SafeGet(type);
		}

		public virtual MessagePart GetMessagePart(string type)
		{
			return this.messageSet.GetMessagePart(type);
		}

		public virtual ICollection<MessagePart> GetAllMessageParts()
		{
			return this.messageSet.AllMessageParts;
		}

		public virtual IList<Interaction> GetAllInteractions()
		{
			SortedList<string, Interaction> map = new SortedList<string, Interaction>(this.messageSet.Interactions);
			return new List<Interaction>(map.Values);
		}

		public virtual IList<MessagePart> GetAllRootMessageParts()
		{
			IList<MessagePart> allRootParts = new List<MessagePart>();
			foreach (PackageLocation packageLocation in this.messageSet.PackageLocations.Values)
			{
				MessagePart rootMessagePart = this.GetMessagePart(packageLocation.RootType);
				if (rootMessagePart != null)
				{
					allRootParts.Add(rootMessagePart);
				}
			}
			return allRootParts;
		}

		public virtual IDictionary<string, MessagePart> GetAllMessageParts(Interaction interaction)
		{
			IDictionary<string, MessagePart> allParts = new SortedList<string, MessagePart>();
			if (interaction != null)
			{
				// supertype
				AddMessagePartsFromType(allParts, interaction.SuperTypeName);
				AddMessagePartsFromArguments(allParts, interaction.Arguments);
			}
			return allParts;
		}

		public virtual IDictionary<string, MessagePart> GetAllRelatedMessageParts(MessagePart messagePart)
		{
			return GetAllRelatedMessageParts(messagePart.Name);
		}

		public virtual IDictionary<string, MessagePart> GetAllRelatedMessageParts(string messagePart)
		{
			IDictionary<string, MessagePart> allParts = new SortedList<string, MessagePart>();
			AddMessagePartsFromType(allParts, messagePart);
			return allParts;
		}

		private void AddMessagePartsFromType(IDictionary<string, MessagePart> allParts, string superTypeName)
		{
			MessagePart messagePart = this.GetMessagePart(superTypeName);
			if (!allParts.ContainsKey(superTypeName))
			{
				allParts[superTypeName] = messagePart;
				if (messagePart.IsAbstract && !messagePart.SpecializationChilds.IsEmpty())
				{
					AddMessagePartsFromSpecializationChilds(allParts, messagePart.SpecializationChilds);
				}
				AddMessagePartsFromRelationships(allParts, messagePart.Relationships);
			}
		}

		private void AddMessagePartsFromArguments(IDictionary<string, MessagePart> allParts, IList<Argument> arguments)
		{
			if (arguments != null)
			{
				foreach (Argument argument in arguments)
				{
					MessagePart messagePart = this.GetMessagePart(argument.Name);
					if (!allParts.ContainsKey(messagePart.Name))
					{
						allParts[messagePart.Name] = messagePart;
						if (messagePart.IsAbstract && !messagePart.SpecializationChilds.IsEmpty())
						{
							AddMessagePartsFromSpecializationChilds(allParts, messagePart.SpecializationChilds);
						}
						AddMessagePartsFromRelationships(allParts, messagePart.Relationships);
						AddMessagePartsFromArguments(allParts, argument.Arguments);
					}
				}
			}
		}

		private void AddMessagePartsFromRelationships(IDictionary<string, MessagePart> allParts, IList<Relationship> relationships
			)
		{
			foreach (Relationship relationship in relationships)
			{
				string type = relationship.Type;
				if (type != null)
				{
					MessagePart messagePart = this.GetMessagePart(type);
					if (messagePart != null)
					{
						if (!allParts.ContainsKey(messagePart.Name))
						{
							allParts[messagePart.Name] = messagePart;
							if (messagePart.IsAbstract && !messagePart.SpecializationChilds.IsEmpty())
							{
								AddMessagePartsFromSpecializationChilds(allParts, messagePart.SpecializationChilds);
							}
							AddMessagePartsFromRelationships(allParts, messagePart.Relationships);
						}
					}
				}
				if (relationship.Choice)
				{
					AddMessagePartsFromRelationships(allParts, relationship.Choices);
				}
			}
		}

		private void AddMessagePartsFromSpecializationChilds(IDictionary<string, MessagePart> allParts, IList<SpecializationChild
			> specializationChilds)
		{
			foreach (SpecializationChild specializationChild in specializationChilds)
			{
				if (specializationChild != null && specializationChild.Name != null)
				{
					MessagePart messagePart = this.GetMessagePart(specializationChild.Name);
					if (messagePart != null && messagePart.Name != null)
					{
						if (!allParts.ContainsKey(messagePart.Name))
						{
							allParts[messagePart.Name] = messagePart;
							if (messagePart.IsAbstract && !messagePart.SpecializationChilds.IsEmpty())
							{
								AddMessagePartsFromSpecializationChilds(allParts, messagePart.SpecializationChilds);
							}
							AddMessagePartsFromRelationships(allParts, messagePart.Relationships);
						}
					}
				}
			}
		}
	}
}
