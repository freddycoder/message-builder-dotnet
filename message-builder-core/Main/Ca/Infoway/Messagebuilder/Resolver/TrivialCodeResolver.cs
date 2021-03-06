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

using Castle.Core.Interceptor;
using Castle.DynamicProxy;

namespace Ca.Infoway.Messagebuilder.Resolver {
	
	using Ca.Infoway.Messagebuilder;
	using Ca.Infoway.Messagebuilder.Domainvalue;
	using Ca.Infoway.Messagebuilder.J5goodies;
    using Ca.Infoway.Messagebuilder.Terminology;
	using ILOG.J2CsMapping.Reflect;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Reflection;
	using System.Runtime.CompilerServices;
	using System.Runtime.Serialization;
	
	/// <summary>
	/// The Class TrivialCodeResolver. Used to resolve a c that does not have any other resolver registered for its type. 
	/// </summary>
	///
	public class TrivialCodeResolver : CodeResolverImpl {
		
		private static ProxyGenerator PROXY_GENERATOR = new ProxyGenerator();
	
		private readonly MapOfMaps<Type, String, Code> map;
		private readonly ICollection<Type> emptyDomains;
		
		public TrivialCodeResolver() {
			this.map = new MapOfMaps<Type, String, Code>();
			this.emptyDomains = new HashSet<Type>();
		}
	
		[Serializable]
        internal class Handler : InvocationHandler, IInterceptor
        {
	
			private const long serialVersionUID = -8622581065197800993L;
	
			private readonly String code;
			private readonly String codeSystem;
			private readonly NullFlavor nullFlavor;
	
			public Handler(String code_0, String codeSystem_1) {
				this.code = code_0;
				this.codeSystem = codeSystem_1;
				this.nullFlavor = null;
			}
	
			public Handler(NullFlavor nullFlavor_0) {
				this.nullFlavor = nullFlavor_0;
				this.code = null;
				this.codeSystem = null;
			}
	
			public virtual  System.Object Invoke(Object arg0, MethodInfo method, Object[] arg2) {
				if ("get_CodeValue".Equals(method.Name)) {
					return this.code;
				} else if ("get_CodeSystem".Equals(method.Name)) {
					return this.codeSystem;
                }
                else if ("GetHashCode".Equals(method.Name))
                {
					return new HashCodeBuilder().Append(this.code).Append(this.codeSystem).Append(this.nullFlavor).ToHashCode();

				} else if ("Equals".Equals(method.Name) && arg2.Length == 1) {
					return IsEqualTo(arg2[0]);
				} else if ("ToString".Equals(method.Name)) {
					return this.code;
                }
                else if ("IsAccepted".Equals(method.Name))
                {
					return (Boolean?)("AA".Equals(code));
				} else {
					return null;
				}
			}
	
			public bool IsEqualTo(Object obj0) {
				if (obj0 == null) {
					return false;
				} else if (!(obj0   is  Code)) {
					return false;
				} else {
					Code that = (Code) obj0;
					EqualsBuilder builder = new EqualsBuilder();
					builder.Append(this.code, that.CodeValue);
					builder.Append(this.codeSystem, that.CodeSystem);
					builder.Append(this.nullFlavor, null);
					return builder.IsEquals();
				}
			}

		    public void Intercept(IInvocation invocation)
		    {
                invocation.ReturnValue = Invoke(invocation.InvocationTarget, invocation.Method, invocation.Arguments);
		    }
        }
	
		/// <summary>
		/// {@inheritDoc}
		/// </summary>
		///
		/* @SuppressWarnings("unchecked")*/
		public override T Lookup<T>(Type interfaceType, String code_0, String codeSystemOid) /* where T : Code */ {
			if (code_0 == null || this.emptyDomains.Contains(interfaceType)) {
				return  default(T)/* was: null */;
			} else if (this.map.ContainsKey(interfaceType, code_0)) {
				return (T) this.map.Get(interfaceType, code_0);
			} else if (this.map.ContainsKey(interfaceType, null)) {
				return (T) this.map.Get(interfaceType, code_0);
			} else
			{

			    var newProxyInstance = PROXY_GENERATOR.CreateInterfaceProxyWithoutTarget(interfaceType, new Handler(code_0, codeSystemOid));

			    
			    return (T) newProxyInstance;
			}
		}

		/// <summary>
		/// {@inheritDoc}
		/// </summary>
		///
		public override T Lookup<T>(Type interfaceType, String code_0, String codeSystemOid, bool ignoreCase) /* where T : Code */ {
            return Lookup<T>(interfaceType, code_0, codeSystemOid);
        }
	
		/// <summary>
		/// {@inheritDoc}
		/// </summary>
		///
		public override T Lookup<T>(Type interfaceType, String code_0) /* where T : Code */ {
			return this.Lookup<T>(interfaceType, code_0, null);
		}

        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        ///
        public override T Lookup<T>(Type interfaceType, String code_0, bool ignoreCase) /* where T : Code */ {
            return this.Lookup<T>(interfaceType, code_0, null);
        }
	
		/// <summary>
		/// Adds the domain value.
		/// </summary>
		///
		/// <param name="code_0">the c</param>
		/// <param name="interfaceType">the interface type</param>
		public void AddDomainValue(Code code, Type interfaceType) {
	    	if (code==null) {
	    		this.emptyDomains.Add(interfaceType);
	    	} else {
	    		this.map.Put(interfaceType, code != null ? code.CodeValue : null, code);
	    		this.emptyDomains.Remove(interfaceType);
	    	}
		}
	
	}
}
