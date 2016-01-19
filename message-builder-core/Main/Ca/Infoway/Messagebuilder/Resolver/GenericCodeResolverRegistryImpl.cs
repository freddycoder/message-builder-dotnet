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
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Terminology;

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
	public class GenericCodeResolverRegistryImpl : GenericCodeResolverRegistry, CodeResolver
	{
		private IDictionary<Type, CodeResolver> resolvers = Ca.Infoway.Messagebuilder.CollUtils.SynchronizedMap(new Dictionary<Type
			, CodeResolver>());

		private CodeResolver instance;

		/// <summary>Lookup.</summary>
		/// <remarks>Lookup.</remarks>
		/// <TBD></TBD>
		/// <param name="type">the type</param>
		/// <returns>the collection</returns>
		public virtual ICollection<T> Lookup<T>(Type type) where T : Code
		{
			return GetResolver<T>(type).Lookup<T>(type);
		}

		/// <summary>Lookup.</summary>
		/// <remarks>Lookup.</remarks>
		/// <TBD></TBD>
		/// <param name="type">the type</param>
		/// <param name="code">the code</param>
		/// <returns>the t</returns>
		public virtual T Lookup<T>(Type type, string code) where T : Code
		{
			return GetResolver<T>(type).Lookup<T>(type, code);
		}

        /// <summary>Lookup.</summary>
        /// <remarks>Lookup.</remarks>
        /// <TBD></TBD>
        /// <param name="type">the type</param>
        /// <param name="code">the code</param>
        /// <param name="ignoreCase">ignore case when matching code</param>
        /// <returns>the t</returns>
        public virtual T Lookup<T>(Type type, string code, bool ignoreCase) where T : Code {
            return GetResolver<T>(type).Lookup<T>(type, code, ignoreCase);
        }

		/// <summary>Lookup.</summary>
		/// <remarks>Lookup.</remarks>
		/// <TBD></TBD>
		/// <param name="type">the type</param>
		/// <param name="code">the code</param>
		/// <param name="codeSystemOid">the code system oid</param>
		/// <returns>the t</returns>
		public virtual T Lookup<T>(Type type, string code, string codeSystemOid) where T : Code
		{
			return GetResolver<T>(type).Lookup<T>(type, code, codeSystemOid);
		}

        /// <summary>Lookup.</summary>
        /// <remarks>Lookup.</remarks>
        /// <TBD></TBD>
        /// <param name="type">the type</param>
        /// <param name="code">the code</param>
        /// <param name="codeSystemOid">the code system oid</param>
        /// <param name="ignoreCase">ignore case when matching code</param>
        /// <returns>the t</returns>
        public virtual T Lookup<T>(Type type, string code, string codeSystemOid, bool ignoreCase) where T : Code {
            return GetResolver<T>(type).Lookup<T>(type, code, codeSystemOid, ignoreCase);
        }

		/// <summary>Gets the resolver.</summary>
		/// <remarks>Gets the resolver.</remarks>
		/// <TBD></TBD>
		/// <param name="type">the type</param>
		/// <returns>the resolver</returns>
		public virtual CodeResolver GetResolver<T>(Type type) where T : Code
		{
			if (this.resolvers.ContainsKey(type))
			{
				return this.resolvers.SafeGet(type);
			}
			else
			{
                if (EnumPattern.IsEnum(type)) // or EnumPattern
				{
                    // not sure that this is the ideal behaviour here; do we want to return a resolver for something not registered?
                    // (though this *is* what happens when this.instance is not null)
					return new EnumBasedCodeResolver((Type)type);
				}
				else
				{
					if (this.instance == null)
					{
						throw new InvalidOperationException("No code resolver established for " + type.FullName + ".");
					}
					else
					{
						return this.instance;
					}
				}
			}
		}

		/// <summary>Checks if is initialized.</summary>
		/// <remarks>Checks if is initialized.</remarks>
		/// <returns>true, if is initialized</returns>
		public virtual bool IsInitialized()
		{
			return instance != null;
		}

		/// <summary>Register.</summary>
		/// <remarks>Register.</remarks>
		/// <param name="codeResolver">the code resolver</param>
		public virtual void Register(CodeResolver codeResolver)
		{
			instance = codeResolver;
		}

		/// <summary>Register resolver.</summary>
		/// <remarks>Register resolver.</remarks>
		/// <param name="type">the type</param>
		/// <param name="codeResolver">the code resolver</param>
		public virtual void RegisterResolver(Type type, CodeResolver codeResolver)
		{
			this.resolvers[type] = codeResolver;
		}

		/// <summary>Unregister all.</summary>
		/// <remarks>Unregister all.</remarks>
		public virtual void UnregisterAll()
		{
			this.instance = null;
			this.resolvers.Clear();
		}
	}
}
