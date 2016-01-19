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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */


using ILOG.J2CsMapping.Collections.Generics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Platform;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Service;
using Ca.Infoway.Messagebuilder.Xml.Util;

namespace Ca.Infoway.Messagebuilder.Xml.Service
{
	/// <summary>A base class for the message defintion service.</summary>
	/// <remarks>A base class for the message defintion service.</remarks>
	/// <author>Intelliware Development</author>
	public abstract class BaseMessageDefinitionService : MessageDefinitionService
	{
		protected IList<MessageSet> messageSets;

        /// <summary>
        /// Get the list of message sets.
        /// </summary>
        ///
        /// <returns>- the message sets</returns>
        protected internal IList<MessageSet> MessageSets
        {
            /// <summary>
            /// Get the list of message sets.
            /// </summary>
            ///
            /// <returns>- the message sets</returns>
            get
            {
                if (!Initialized())
                {
                    Initialize();
                }
                return this.messageSets;
            }
        }


        private bool Initialized()
        {
            return this.messageSets != null;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Initialize()
        {
            System.Console.WriteLine("About to init message service");
            if (!Initialized())
            {
                MessageSetMarshaller marshaller = new MessageSetMarshaller();

                IList<MessageSet> list = new List<MessageSet>();
                /* foreach */
                foreach (var resourcePair in Names)
                {
                    System.Console.WriteLine("List of names:" + resourcePair.Name);
                }
                foreach (var resourcePair in Names)
                {
                    System.Console.WriteLine(resourcePair.Name + "." + resourcePair.Assembly.FullName);
                    Stream input = ResourceLoader.GetResource(resourcePair.Assembly, resourcePair.Name);
                    if (input == null)
                    {
                        System.Console.WriteLine("Input is null!!");
                    }
                    try
                    {
                        ILOG.J2CsMapping.Collections.Generics.Collections.Add(list, marshaller.Unmarshall(input));
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Could not read " + resourcePair.Name, e);
                    }
                    finally
                    {
                        IOUtils.CloseQuietly(input);
                    }
                }
                this.messageSets = ILOG.J2CsMapping.Collections.Generics.Collections.UnmodifiableList(list);
            }
        }

        /// <summary>
        /// Get the names.
        /// </summary>
        ///
        /// <returns>- the names</returns>
        protected abstract IList<ResourcePair> Names
        {
            /// <summary>
            /// Get the names.
            /// </summary>
            ///
            /// <returns>- the names</returns>
            get;
        }

		/// <summary>Get an interaction by name and version.</summary>
		/// <remarks>Get an interaction by name and version.</remarks>
		/// <param name="version">- the version</param>
		/// <param name="type">- the type name</param>
		/// <returns>the interaction</returns>
		public virtual Interaction GetInteraction(VersionNumber version, string type)
		{
			return GetInteraction(version == null ? null : version.VersionLiteral, type);
		}

		/// <summary>Get an interaction by name and version.</summary>
		/// <remarks>Get an interaction by name and version.</remarks>
		/// <param name="version">- the version</param>
		/// <param name="type">- the type name</param>
		/// <returns>the interaction</returns>
		private Interaction GetInteraction(string version, string type)
		{
			MessageSet messageSet = FindMessageSet(version);
			if (messageSet == null)
			{
				return null;
			}
			return new MessageSetUtils(messageSet).GetInteraction(type);
		}

		/// <summary>Get a message part by name and version.</summary>
		/// <remarks>Get a message part by name and version.</remarks>
		/// <param name="version">- the version</param>
		/// <param name="type">- the type name</param>
		/// <returns>the message part</returns>
		public virtual MessagePart GetMessagePart(VersionNumber version, string type)
		{
			return GetMessagePart(version == null ? null : version.VersionLiteral, type);
		}

		/// <summary>Get a message part by name and version.</summary>
		/// <remarks>Get a message part by name and version.</remarks>
		/// <param name="version">- the version</param>
		/// <param name="type">- the type name</param>
		/// <returns>the message part</returns>
		private MessagePart GetMessagePart(string version, string type)
		{
			MessageSet messageSet = FindMessageSet(version);
			if (messageSet == null)
			{
				return null;
			}
			return new MessageSetUtils(messageSet).GetMessagePart(type);
		}

		/// <summary>Get all interactions across all versions.</summary>
		/// <remarks>Get all interactions across all versions.</remarks>
		/// <param name="includeDuplicateInteractionsWithChangedBusinessNames">
		/// 
		/// - a flag indicating whether or not to include duplicates
		/// </param>
		/// <returns>the interactions</returns>
		public virtual IList<Interaction> GetAllInteractions(bool includeDuplicateInteractionsWithChangedBusinessNames)
		{
			SortedList<string, Interaction> map = new SortedList<string, Interaction>();
			foreach (MessageSet messageSet in MessageSets)
			{
				if (includeDuplicateInteractionsWithChangedBusinessNames)
				{
					ICollection<Interaction> interactions = messageSet.Interactions.Values;
					foreach (Interaction interaction in interactions)
					{
						string key = interaction.Name + interaction.BusinessName;
                        ILOG.J2CsMapping.Collections.Generics.Collections.Put(map, (System.String)(key), (Ca.Infoway.Messagebuilder.Xml.Interaction)(interaction));
					}
				}
				else
				{
                    ILOG.J2CsMapping.Collections.Generics.Collections.PutAll(map, messageSet.Interactions);
                }
			}
			return new List<Interaction>(map.Values);
		}

		/// <summary>Get all interactions for a particular version of the specification.</summary>
		/// <remarks>Get all interactions for a particular version of the specification.</remarks>
		/// <param name="version">- the version</param>
		/// <returns>the interactions</returns>
		public virtual IList<Interaction> GetAllInteractions(VersionNumber version)
		{
			return GetAllInteractions(version == null ? null : version.VersionLiteral);
		}

		/// <summary>Get all message parts for a particular version of the specification.</summary>
		/// <remarks>Get all message parts for a particular version of the specification.</remarks>
		/// <param name="version">- the version</param>
		/// <returns>the message parts</returns>
		public virtual ICollection<MessagePart> GetAllMessageParts(VersionNumber version)
		{
			MessageSet messageSet = FindMessageSet(version);
			if (messageSet == null)
			{
				return new List<MessagePart>();
			}
			return new MessageSetUtils(messageSet).GetAllMessageParts();
		}

		/// <summary>Get all interactions for a particular version of the specification.</summary>
		/// <remarks>Get all interactions for a particular version of the specification.</remarks>
		/// <param name="version">- the version</param>
		/// <returns>the interactions</returns>
		private IList<Interaction> GetAllInteractions(string version)
		{
			MessageSet messageSet = FindMessageSet(version);
			if (messageSet == null)
			{
				return new List<Interaction>();
			}
			return new MessageSetUtils(messageSet).GetAllInteractions();
		}

		/// <summary>Get the supported versions.</summary>
		/// <remarks>Get the supported versions.</remarks>
		/// <returns>- the supported versions</returns>
		public virtual ICollection<string> SupportedVersions
		{
			get
			{
                ILOG.J2CsMapping.Collections.Generics.ISet<String> versions = new ILOG.J2CsMapping.Collections.Generics.SortedSet<System.String>();
                foreach (MessageSet messageSet in MessageSets)
				{
                    String version = messageSet.Version;
                    ILOG.J2CsMapping.Collections.Generics.Collections.Add(versions, version);
                }
				return versions;
			}
		}

		/// <summary>Get all the versions known by this service.</summary>
		/// <remarks>Get all the versions known by this service.</remarks>
		/// <param name="type">- the interaction type name</param>
		/// <returns>the versions</returns>
		public virtual ICollection<string> GetSupportedVersionsForInteraction(string type)
		{
            ILOG.J2CsMapping.Collections.Generics.ISet<String> versions = new ILOG.J2CsMapping.Collections.Generics.SortedSet<System.String>();
            ICollection<String> allSupportedVersions = SupportedVersions;
            foreach (String version in allSupportedVersions)
			{
				if (GetInteraction(version, type) != null)
				{
                    ILOG.J2CsMapping.Collections.Generics.Collections.Add(versions, version);
                }
			}
			return versions;
		}

		/// <summary>Get all the message parts for a particular interaction and version.</summary>
		/// <remarks>Get all the message parts for a particular interaction and version.</remarks>
		/// <param name="interaction">- the interaction</param>
		/// <param name="version">- the version</param>
		/// <returns>- the message parts</returns>
		public virtual IDictionary<string, MessagePart> GetAllMessageParts(Interaction interaction, VersionNumber version)
		{
			MessageSet messageSet = FindMessageSet(version);
			if (messageSet == null)
			{
				return null;
			}
			return new MessageSetUtils(messageSet).GetAllMessageParts(interaction);
		}

		/// <summary>Get all the root message parts for all message sets.</summary>
		/// <remarks>Get all the root message parts for all message sets.</remarks>
		/// <returns>- the message parts</returns>
		public virtual IList<MessagePart> GetAllRootMessageParts()
		{
			IList<MessagePart> allRootParts = new List<MessagePart>();
			foreach (MessageSet messageSet in MessageSets)
			{
				allRootParts.AddAll(new MessageSetUtils(messageSet).GetAllRootMessageParts());
			}
			return allRootParts;
		}

		/// <summary>Get all the root message parts for a specific message set.</summary>
		/// <remarks>Get all the root message parts for a specific message set.</remarks>
		/// <param name="version"></param>
		/// <returns>- the message parts</returns>
		public virtual IList<MessagePart> GetAllRootMessageParts(VersionNumber version)
		{
			MessageSet messageSet = FindMessageSet(version);
			if (messageSet == null)
			{
				return new List<MessagePart>();
			}
			return new MessageSetUtils(messageSet).GetAllRootMessageParts();
		}

		/// <summary>Get all the message parts that a particular root message part references.</summary>
		/// <remarks>Get all the message parts that a particular root message part references.</remarks>
		/// <param name="messagePart">- the messagePart</param>
		/// <param name="version">- the version</param>
		/// <returns>- the message parts</returns>
		public virtual IDictionary<string, MessagePart> GetAllRelatedMessageParts(MessagePart messagePart, VersionNumber version)
		{
			MessageSet messageSet = FindMessageSet(version);
			if (messageSet == null)
			{
				return new Dictionary<string, MessagePart>();
			}
			return new MessageSetUtils(messageSet).GetAllRelatedMessageParts(messagePart);
		}

        /// <summary>
        /// Determine if the message set for the given version has been generated for R2 data types.
        /// </summary>
        public virtual bool IsR2(VersionNumber version)
        {
            MessageSet messageSet = FindMessageSet(version);
            return messageSet == null ? false : messageSet.GeneratedAsR2;
        }

        /// <summary>
        /// Determine if the message set for the given version defines CDA documents.
        /// </summary>
        public virtual bool IsCda(VersionNumber version)
        {
            MessageSet messageSet = FindMessageSet(version);
            return messageSet == null ? false : messageSet.Cda;
        }

        public virtual ConstrainedDatatype GetConstraints(VersionNumber version, string constrainedType)
        {
            if (constrainedType != null)
            {
                MessageSet messageSet = FindMessageSet(version);
                if (messageSet != null)
                {
                    return messageSet.GetConstrainedDatatype(constrainedType);
                }
            }
            return null;
        }

        public virtual IList<SchematronContext> GetAllSchematronContexts(VersionNumber version)
        {
            MessageSet messageSet = FindMessageSet(version);
            if (messageSet != null)
            {
                return messageSet.SchematronContexts;
            }
            return CollUtils.EmptyList<SchematronContext>();
        }

        public virtual IList<PackageLocation> GetAllPackageLocations(VersionNumber version)
        {
            IList<PackageLocation> packageLocations = new List<PackageLocation>();
            MessageSet messageSet = FindMessageSet(version);
            if (messageSet != null)
            {
                packageLocations.AddAll(messageSet.PackageLocations.Values);
            }
            return packageLocations;
        }

		private MessageSet FindMessageSet(VersionNumber version)
		{
			return FindMessageSet(version == null ? null : version.VersionLiteral);
		}

		private MessageSet FindMessageSet(string version)
		{
			MessageSet result = null;
			foreach (MessageSet messageSet in MessageSets)
			{
				if (messageSet.Version.Equals(version))
				{
					result = messageSet;
					if (result != null)
					{
						break;
					}
				}
			}
			return result;
		}
	}
}
