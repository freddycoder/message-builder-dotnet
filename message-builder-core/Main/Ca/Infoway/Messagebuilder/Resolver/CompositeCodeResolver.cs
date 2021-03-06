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


/// ---------------------------------------------------------------------------------------------------
///  This file was automatically generated by J2CS Translator (http://j2cstranslator.sourceforge.net/). 
///  Version 1.0.0                                                                                      
/// ---------------------------------------------------------------------------------------------------

namespace Ca.Infoway.Messagebuilder.Resolver {
	
	using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Terminology;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	
	/// <summary>
	/// The Class CompositeCodeResolver. A c resolver made up of a combination of other c resolvers.
	/// </summary>
	///
	public class CompositeCodeResolver : CodeResolverImpl {
	
		private readonly CodeResolver[] resolvers;
	
		/// <summary>
		/// Instantiates a new composite c resolver.
		/// </summary>
		///
		/// <param name="resolvers_0">the resolvers</param>
		public CompositeCodeResolver(params CodeResolver[] resolvers_0) {
			this.resolvers = resolvers_0;
		}
	
		/// <summary>
		/// {@inheritDoc}
		/// </summary>
		///
		public override ICollection<T> Lookup<T>(Type type) /* where T : Code */ {
			IList<T> result = new List<T>();
			/* foreach */
			foreach (CodeResolver resolver  in  this.resolvers) {
				ICollection<T> collection = resolver.Lookup<T>(type);
				if (collection != null) {
					ILOG.J2CsMapping.Collections.Generics.Collections.AddAll(collection,result);
				}
			}
			return result;
		}

        public override T Lookup<T>(Type type, String code)  /* where T : Code */ {
            return Lookup<T>(type, code, true);
        }
	
		/// <summary>
		/// {@inheritDoc}
		/// </summary>
		///
		public override T Lookup<T>(Type type, String code, bool ignoreCase) /* where T : Code */ {
			Object result = null;
			/* foreach */
			foreach (CodeResolver resolver  in  this.resolvers) {
				Object obj0 = resolver.Lookup<T>(type, code, ignoreCase);
				if (obj0 != null) {
					result = obj0;
					break;
				}
			}
			return (T) result;
		}

        public override T Lookup<T>(Type type, String code, String codeSystemOid) /* where T : Code */ {
            return Lookup<T>(type, code, codeSystemOid, true);
        }
	
		/// <summary>
		/// {@inheritDoc}
		/// </summary>
		///
		public override T Lookup<T>(Type type, String code, String codeSystemOid, bool ignoreCase) /* where T : Code */ {
			Object result = null;
			/* foreach */
			foreach (CodeResolver resolver  in  this.resolvers) {
				Object obj0 = resolver.Lookup<T>(type, code, codeSystemOid, ignoreCase);
				if (obj0 != null) {
					result = obj0;
					break;
				}
			}
			return (T) result;
		}
	}
}
