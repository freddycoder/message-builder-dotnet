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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Terminology;

namespace Ca.Infoway.Messagebuilder.Resolver
{
	public interface GenericCodeResolverRegistry : CodeResolver
	{
		/// <summary>Gets the resolver.</summary>
		/// <remarks>Gets the resolver.</remarks>
		/// <TBD></TBD>
		/// <param name="type">the type</param>
		/// <returns>the resolver</returns>
		CodeResolver GetResolver<T>(Type type) where T : Code;

		bool IsInitialized();

		/// <summary>Register.</summary>
		/// <remarks>Register.</remarks>
		/// <param name="codeResolver">the code resolver</param>
		void Register(CodeResolver codeResolver);

		/// <summary>Register resolver.</summary>
		/// <remarks>Register resolver.</remarks>
		/// <param name="type">the type</param>
		/// <param name="codeResolver">the code resolver</param>
		void RegisterResolver(Type type, CodeResolver codeResolver);

		void UnregisterAll();
	}
}
