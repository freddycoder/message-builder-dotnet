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
 * Last modified: $LastChangedDate: 2013-10-04 20:09:29 -0300 (Fri, 04 Oct 2013) $
 * Revision:      $LastChangedRevision: 7938 $
 */
using System;
using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Terminology;
using Ca.Infoway.Messagebuilder.Terminology.Proxy;
using Ca.Infoway.Messagebuilder.Terminology.Codeset;
using Ca.Infoway.Messagebuilder.Terminology.Codeset.Dao;
using Ca.Infoway.Messagebuilder.Terminology.Codeset.Domain;

namespace Ca.Infoway.Messagebuilder
{
	/// <summary>Utility to register all vocabulary domains in a database (that have value sets of a specific version) against a database code resolver.
	/// 	</summary>
	/// <remarks>Utility to register all vocabulary domains in a database (that have value sets of a specific version) against a database code resolver.
	/// 	</remarks>
	/// <author>Intelliware Development</author>
	public class DatabaseCodeResolverRegistrationUtility
	{

		/// <summary>Convenience class to hold results of the registration utility.</summary>
		/// <remarks>Convenience class to hold results of the registration utility.</remarks>
		/// <author>Intelliware Development</author>
		public class DatabaseCodeResolverRegistrationUtilityResults
		{
			/// <summary>Domains that were not registered.</summary>
			/// <remarks>Domains that were not registered.</remarks>
			public ICollection<string> domainsFoundInDatabaseButNoMatchingInterface = new System.Collections.Generic.SortedSet<string
				>();

			/// <summary>Domains that were successfully registered.</summary>
			/// <remarks>Domains that were successfully registered.</remarks>
			public IDictionary<string, Type> domainsInDatabaseMappedToInterfacesUsedToRegister = new SortedList<string, Type>();

			/// <summary><inheritDoc></inheritDoc></summary>
			public override string ToString()
			{
				StringBuilder sb = new StringBuilder();
				sb.Append("Vocabulary Domains successfully registered:\n");
				foreach (KeyValuePair<string, Type> entry in this.domainsInDatabaseMappedToInterfacesUsedToRegister)
				{
					sb.Append(entry.Key).Append(" -> ").Append(entry.Value.FullName).Append("\n");
				}
				sb.Append("\nVocabulary Domains found in database but for which could NOT find a matching interface:\n");
				foreach (string domainString in this.domainsFoundInDatabaseButNoMatchingInterface)
				{
					sb.Append(domainString).Append("\n");
				}
				return sb.ToString();
			}

			internal DatabaseCodeResolverRegistrationUtilityResults(DatabaseCodeResolverRegistrationUtility _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly DatabaseCodeResolverRegistrationUtility _enclosing;
		}

		/// <summary>Find all domains that have value sets for the supplied version and register their matching MB interfaces against a database code resolver.
		/// 	</summary>
		/// <remarks>Find all domains that have value sets for the supplied version and register their matching MB interfaces against a database code resolver.
		/// 	</remarks>
		/// <param name="dao">the code set DAO</param>
		/// <param name="codeFactory">a code factory</param>
		/// <param name="version">the value set version being used</param>
		/// <param name="registry">a code resolver registry</param>
		/// <param name="releaseSpecificBasePackageName">base package name for the specific API release being targeted</param>
		/// <returns>the results of the registration process</returns>
		public virtual DatabaseCodeResolverRegistrationUtilityResults RegisterAll(CodeSetDao
			 dao, TypedCodeFactory codeFactory, string version, GenericCodeResolverRegistry 
			registry, string releaseSpecificBasePackageName)
		{
			DatabaseCodeResolverRegistrationUtilityResults results = new DatabaseCodeResolverRegistrationUtilityResults
				(this);
			ICollection<string> domainTypes = DetermineAllDomains(dao, version);
			IList<Type> domainInterfaces = FindAllMatchingDomainInterfaces(domainTypes, releaseSpecificBasePackageName, results);
			RegisterDomainsAgainstDatabaseCodeResolver(dao, codeFactory, version, registry, domainInterfaces);
			return results;
		}

		/// <summary>Determines all domain types that have value sets for the supplied version.</summary>
		/// <remarks>Determines all domain types that have value sets for the supplied version.</remarks>
		/// <param name="dao">the code set DAO</param>
		/// <param name="version">the value set version to use</param>
		/// <returns>the set of domain types as strings</returns>
		private ICollection<string> DetermineAllDomains(CodeSetDao dao, string version)
		{
			// use version to determine all applicable ValueSets
			IList<ValueSet> valueSets = dao.SelectValueSetsByVersion(version);
			// pull out all VocabularyDomains referenced by the value sets
			ICollection<string> domainTypes = new System.Collections.Generic.SortedSet<string>();
			foreach (ValueSet valueSet in valueSets)
			{
				ICollection<VocabularyDomain> vocabularyDomains = valueSet.VocabularyDomains;
				foreach (VocabularyDomain vocabularyDomain in vocabularyDomains)
				{
					domainTypes.Add(vocabularyDomain.Type);
				}
			}
			return domainTypes;
		}

		/// <summary>Find all domain interfaces that match the supplied domain types.</summary>
		/// <remarks>Find all domain interfaces that match the supplied domain types.</remarks>
		/// <param name="domainTypes">the domain types to match against interfaces</param>
		/// <param name="releaseSpecificBasePackageName">base package name for the specific API release being targeted</param>
		/// <param name="results">results object detailing what domains were registered and which could not be matched up to interfaces
		/// 	</param>
		/// <returns>the matching interfaces</returns>
		private IList<Type> FindAllMatchingDomainInterfaces(ICollection<string> domainTypes, string releaseSpecificBasePackageName
			, DatabaseCodeResolverRegistrationUtilityResults results)
		{
			// for each VocabularyDomain type, look for a matching interface
			IList<Type> domainInterfaces = new List<Type>();
			foreach (string domainType in domainTypes)
			{
				Type domainInterface = LookupDomainInterface(domainType, releaseSpecificBasePackageName);
				if (domainInterface != null)
				{
					domainInterfaces.Add(domainInterface);
					results.domainsInDatabaseMappedToInterfacesUsedToRegister[domainType] = domainInterface;
				}
				else
				{
					// need to log a problem
					results.domainsFoundInDatabaseButNoMatchingInterface.Add(domainType);
				}
			}
			return domainInterfaces;
		}

		/// <summary>For each VocabularyDomain type, looks for a matching interface in one of two places.</summary>
		/// <remarks>
		/// For each VocabularyDomain type, looks for a matching interface in one of two places.
		/// 1) ca.infoway.messagebuilder.domainvalue.XXXX
		/// 2) ca.infoway.messagebuilder.model.VER.domainvalue.XXXX (VER must be provided manually)
		/// </remarks>
		/// <param name="domainType">the domain type to look up</param>
		/// <param name="releaseSpecificBasePackageName">base package name for the specific API release being targeted</param>
		/// <returns>the mathcing domain interface, if any</returns>
		private Type LookupDomainInterface(string domainType, string releaseSpecificBasePackageName)
		{
			Type domainInterface = null;
			try
			{
				domainInterface = (Type)Ca.Infoway.Messagebuilder.Runtime.GetType("ca.infoway.messagebuilder.domainvalue." + domainType);
			}
			catch (TypeLoadException)
			{
				if (releaseSpecificBasePackageName != null)
				{
					try
					{
						domainInterface = (Type)Ca.Infoway.Messagebuilder.Runtime.GetType("ca.infoway.messagebuilder.model." + releaseSpecificBasePackageName
							 + ".domainvalue." + domainType);
					}
					catch (TypeLoadException)
					{
					}
				}
			}
			// do nothing
			return domainInterface;
		}

		/// <summary>Create a DB resolver from supplied parameters and register all found interfaces.</summary>
		/// <remarks>Create a DB resolver from supplied parameters and register all found interfaces.</remarks>
		/// <param name="dao">the code set DAO</param>
		/// <param name="codeFactory">a code factory</param>
		/// <param name="version">the value set version being used</param>
		/// <param name="registry">a code resolver registry</param>
		/// <param name="domainInterfaces">the domain interfaces to register resolvers for</param>
		private void RegisterDomainsAgainstDatabaseCodeResolver(CodeSetDao dao, TypedCodeFactory
			 codeFactory, string version, GenericCodeResolverRegistry registry, IList<Type> domainInterfaces)
		{
			CodeResolver dbResolver = new DatabaseCodeResolver(dao, codeFactory, version);
			foreach (Type domainInterface in domainInterfaces)
			{
				registry.RegisterResolver(domainInterface, dbResolver);
			}
		}
	}
}
