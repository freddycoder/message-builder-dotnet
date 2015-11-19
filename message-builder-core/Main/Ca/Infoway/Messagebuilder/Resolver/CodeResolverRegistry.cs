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
using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Terminology;
using ILOG.J2CsMapping.Util;

namespace Ca.Infoway.Messagebuilder.Resolver
{
	/// <summary>This class functions is generally used in one of two ways.</summary>
	/// <remarks>
	/// This class functions is generally used in one of two ways.  Either:
	/// 
	/// Register one monolithic Code Resolver that handles all lookup requests.
	/// (This approach is currently used by the HealthWatch project, and their
	/// resolver is backed by a database, and is sometimes used in test cases,
	/// in which case we're usually using the TrivialCodeResolver).
	/// To use this approach, a project should call the
	/// register(codeResolver) method and set the instance
	/// static variable.
	/// Register one resolver for each domain interface (This approach is currently used
	/// by the eReferrals and Panacea projects).
	/// 
	/// Additionally, this class can automatically resolve:
	/// 
	/// enums; and
	/// classes that follow the enum pattern (having static constants -- see, for
	/// example the Country class
	/// 
	/// In both cases the class or enum must implement the Code interface.
	/// </remarks>
	/// <author>Intelliware Development</author>
	public abstract class CodeResolverRegistry
	{
        private static readonly System.Threading.ThreadLocal<VersionNumber> threadLocalVersion = new System.Threading.ThreadLocal<VersionNumber>();

        private static readonly System.Threading.ThreadLocal<GenericCodeResolverRegistry> threadLocalCodeResolverRegistryOverride = new System.Threading.ThreadLocal
			<GenericCodeResolverRegistry>();

		private static readonly IDictionary<VersionNumber, GenericCodeResolverRegistry> registryMap = new Dictionary<VersionNumber
			, GenericCodeResolverRegistry>();

		private static readonly GenericCodeResolverRegistry _defaultRegistry = new GenericCodeResolverRegistryImpl();

		// the "default" registry that will be used if no other registry can be found 
		// all transform/validator calls should set version in TLS
		public static void SetThreadLocalVersion(VersionNumber version)
		{
			threadLocalVersion.Value = version;
		}

		public static void ClearThreadLocalVersion()
		{
			threadLocalVersion.Value = null;
		}

		// transform/validator calls *may* provide a code resolver registry override in TLS
		public static void SetThreadLocalCodeResolverRegistryOverride(GenericCodeResolverRegistry registryOverride)
		{
			threadLocalCodeResolverRegistryOverride.Value = registryOverride;
		}

		public static void ClearThreadLocalCodeResolverRegistryOverride()
		{
			threadLocalCodeResolverRegistryOverride.Value = null;
		}

		/// <summary>Store a CodeResolverRegistry to be used for a specific HL7v3 release version.</summary>
		/// <remarks>
		/// Store a CodeResolverRegistry to be used for a specific HL7v3 release version. Passing in a null value for the registry will
		/// remove any existing registry for the supplied version.
		/// </remarks>
		/// <param name="version">the version for which the supplied code resolver registry should be used</param>
		/// <param name="registry">the code resolver registry to use for this version</param>
		/// <returns>returns true if there was a code resolver registry already registered for this version</returns>
		public static bool RegisterCodeResolverRegistryForVersion(VersionNumber version, GenericCodeResolverRegistry registry)
		{
			bool result = (version == null ? false : registryMap.ContainsKey(version));
			if (registry == null)
			{
                if (version != null)
                {
				    registryMap.Remove(version);
				    return result;
                }
			}
            if (version != null) 
            {
			    registryMap[version] = registry;
            }
			return result;
		}

		/// <summary>Retrieves the CodeResolverRegistry used for a specific HL7v3 release version, if one has been stored for that version.
		/// 	</summary>
		/// <remarks>Retrieves the CodeResolverRegistry used for a specific HL7v3 release version, if one has been stored for that version. Otherwise, returns null.
		/// 	</remarks>
		/// <param name="version">the version for which the supplied code resolver registry should be used</param>
		/// <returns>registry the code resolver registry to use for this version</returns>
		public static GenericCodeResolverRegistry GetCodeResolverRegistryForVersion(VersionNumber version)
		{
			return GetRegistryFromMap(version);
		}

		// for testing purposes only
		internal static GenericCodeResolverRegistry GetDefaultRegistry()
		{
			return _defaultRegistry;
		}

		/// <summary>Removes all code resolver registries stored by HL7v3 release version.</summary>
		/// <remarks>Removes all code resolver registries stored by HL7v3 release version.</remarks>
		public static void RemoveAllRegistries()
		{
			registryMap.Clear();
		}

		/// <returns>the registry for the version being used in the current thread. If none found, returns the default registry.</returns>
		internal static GenericCodeResolverRegistry GetRegistry()
		{
			// if an override code resolver registry has been specified it will be returned regardless of other settings 
			if (threadLocalCodeResolverRegistryOverride.Value != null)
			{
				return threadLocalCodeResolverRegistryOverride.Value;
			}
			// otherwise, returns the code resolver registry stored under the HL7v3 version being used by the current thread
			// if no registries found, return the default code resolver registry
			VersionNumber currentlySpecifiedVersion = threadLocalVersion.Value;
            GenericCodeResolverRegistry versionRegistry = (currentlySpecifiedVersion == null ? null : GetRegistryFromMap(currentlySpecifiedVersion));
			return versionRegistry == null ? _defaultRegistry : versionRegistry;
		}

		internal static GenericCodeResolverRegistry GetRegistryFromMap(VersionNumber versionToLookup)
		{
            if (registryMap.ContainsKey(versionToLookup)) {
                return registryMap[versionToLookup];
            }
            return null;
		}

        /// <summary>
        /// Lookup.
		/// </summary>
		///
		/// <param name="T"> the generic type</param>
		/// <param name="type">the type</param>
		/// <returns>the collection</returns>
		public static ICollection<T> Lookup<T>(Type type)  where T : Code {
			return GetRegistry().Lookup<T>(type);
		}
	
		/// <summary>Lookup.</summary>
		/// <remarks>Lookup.</remarks>
		/// <TBD></TBD>
		/// <param name="type">the type</param>
		/// <param name="code">the code</param>
		/// <returns>the t</returns>
		public static T Lookup<T>(string code) where T : Code
		{
			System.Type type = typeof(T);
			return GetRegistry().Lookup<T>(type, code);
		}

		/// <summary>
        /// Lookup. Defaults to case insensitive.
		/// </summary>
		///
		/// <param name="T"> the generic type</param>
		/// <param name="type">the type</param>
		/// <param name="code">the c</param>
		/// <returns>the t</returns>
		public static T Lookup<T>(Type type, String code)  where T : Code {
			return GetRegistry().Lookup<T>(type, code);
		}

		public static Code Lookup(Type type, String code) {
			return GetRegistry().Lookup<Code>(type, code);
		}

        /// <summary>
        /// Lookup code, logging a warning if a code is found that doesn't match case.
        /// </summary>
        /// <typeparam name="T">the generic type</typeparam>
        /// <param name="type">the type</param>
        /// <param name="code">the code</param>
        /// <param name="logger">an error logger</param>
        /// <returns>the t</returns>
        public static T LookupWarningOnCaseMismatch<T>(Type type, String code, ErrorLogger logger) where T : Code {
            T result = GetRegistry().Lookup<T>(type, code, false); //exact match
            if (result == null) {
                // now try to find a match while ignoring case
                result = GetRegistry().Lookup<T>(type, code, true);
                if (result != null) {
                    logger.LogError(
                        Hl7ErrorCode.CODE_MATCH_ONLY_WHEN_IGNORING_CASE, 
                        ErrorLevel.WARNING,
                        "A match for code " + code + " of type " + type.Name + 
                        " was found only when ignoring case (" + result.CodeValue + ").");
                }
            }
            return result;
        }

        /// <summary>
        /// Lookup
        /// </summary>
        /// <typeparam name="T">the generic type</typeparam>
        /// <param name="type">the type</param>
        /// <param name="code">the code</param>
        /// <param name="ignoreCase">ignore case when matching code</param>
        /// <returns>the t</returns>
        public static T Lookup<T>(Type type, String code, bool ignoreCase) where T : Code {
            return GetRegistry().Lookup<T>(type, code, true);
        }
		
		/// <summary>
        /// Lookup. Defaults to case insensitive.
		/// </summary>
		///
		/// <param name="T"> the generic type</param>
		/// <param name="type">the type</param>
		/// <param name="code">the c</param>
		/// <param name="codeSystemOid">the c system oid</param>
		/// <returns>the t</returns>
		public static T Lookup<T>(Type type, String code, String codeSystemOid)  where T : Code {
			return GetRegistry().Lookup<T>(type, code, codeSystemOid);
		}

        /// <summary>
        /// Lookup.
        /// </summary>
        ///
        /// <param name="T"> the generic type</param>
        /// <param name="type">the type</param>
        /// <param name="code">the c</param>
        /// <param name="codeSystemOid">the c system oid</param>
        /// <param name="logger">an error logger</param>
        /// <returns>the t</returns>
        public static T LookupWarningOnCaseMismatch<T>(Type type, String code, String codeSystemOid, ErrorLogger logger) where T : Code {
            T result = GetRegistry().Lookup<T>(type, code, codeSystemOid, false); //exact match
            if (result == null) {
                // now try to find a match while ignoring case
                result = GetRegistry().Lookup<T>(type, code, codeSystemOid, true);
                if (result != null) {
                    logger.LogError(
                        Hl7ErrorCode.CODE_MATCH_ONLY_WHEN_IGNORING_CASE,
                        ErrorLevel.WARNING,
                        "A match for code " + code + " of type " + type.Name +
                        " was found only when ignoring case (" + result.CodeValue + ").");
                }
            }
            return result;
        }

        /// <summary>
        /// Lookup.
        /// </summary>
        ///
        /// <param name="T"> the generic type</param>
        /// <param name="type">the type</param>
        /// <param name="code">the c</param>
        /// <param name="codeSystemOid">the c system oid</param>
        /// <param name="ignoreCase">ignore case when matching code</param>
        /// <returns>the t</returns>
        public static T Lookup<T>(Type type, String code, String codeSystemOid, bool ignoreCase) where T : Code {
            return GetRegistry().Lookup<T>(type, code, codeSystemOid, ignoreCase);
        }

		/// <summary>Lookup.</summary>
		/// <remarks>Lookup.</remarks>
		/// <TBD></TBD>
		/// <param name="type">the type</param>
		/// <param name="code">the code</param>
		/// <param name="codeSystemOid">the code system oid</param>
		/// <returns>the t</returns>
		public static T Lookup<T>(string code, string codeSystemOid) where T : Code
		{
			System.Type type = typeof(T);
			return GetRegistry().Lookup<T>(type, code, codeSystemOid);
		}

		/// <summary>Gets the resolver.</summary>
		/// <remarks>Gets the resolver.</remarks>
		/// <TBD></TBD>
		/// <param name="type">the type</param>
		/// <returns>the resolver</returns>
		public static CodeResolver GetResolver<T>() where T : Code
		{
			System.Type type = typeof(T);
			return GetRegistry().GetResolver<T>(type);
		}

        public static CodeResolver GetResolver(Type type)
        {
            return GetRegistry().GetResolver<Code>(type);
        }

        /// <summary>Checks if the DEFAULT code resolver registry is initialized.</summary>
		/// <remarks>Checks if the DEFAULT code resolver registry is initialized.</remarks>
		/// <returns>true, if is initialized</returns>
		public static bool IsInitialized()
		{
			return _defaultRegistry.IsInitialized();
		}

		/// <summary>Register a code resolver in the DEFAULT code resolver registry.</summary>
		/// <remarks>Register a code resolver in the DEFAULT code resolver registry.</remarks>
		/// <param name="codeResolver">the code resolver</param>
		public static void Register(CodeResolver codeResolver)
		{
			_defaultRegistry.Register(codeResolver);
		}

		/// <summary>Register a code resolver in the DEFAULT code resolver registry.</summary>
		/// <remarks>Register a code resolver in the DEFAULT code resolver registry.</remarks>
		/// <param name="type">the type</param>
		/// <param name="codeResolver">the code resolver</param>
		public static void RegisterResolver(Type type, CodeResolver codeResolver)
		{
			_defaultRegistry.RegisterResolver(type, codeResolver);
		}

		/// <summary>Unregister all code resolvers in the DEFAULT code resolver registry.</summary>
		/// <remarks>Unregister all code resolvers in the DEFAULT code resolver registry.</remarks>
		public static void UnregisterAll()
		{
			_defaultRegistry.UnregisterAll();
		}
	}
}
