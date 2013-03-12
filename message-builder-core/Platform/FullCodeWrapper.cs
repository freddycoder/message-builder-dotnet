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
 * Last modified: $LastChangedDate: 2011-05-17 11:48:36 -0400 (Tue, 17 May 2011) $
 * Revision:      $LastChangedRevision: 2666 $
 */

using System;
using System.Reflection;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Castle.Core.Interceptor;
using Castle.DynamicProxy;
using ILOG.J2CsMapping.Reflect;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
    public class FullCodeWrapper 
    {
		
		private static ProxyGenerator PROXY_GENERATOR = new ProxyGenerator();

		public static Code Wrap<T>(Code code, String codeSystem) {
			return Wrap(typeof(T), code, codeSystem);
		}
		
        public static Code Wrap(Type t, Code code, String codeSystem)
        {
            var newProxyInstance = PROXY_GENERATOR.CreateInterfaceProxyWithoutTarget(t, new FullCodeHandler(code, codeSystem));
		    return (Code) newProxyInstance;
        }

    }

    public class FullCodeHandler : InvocationHandler, IInterceptor
    {

        private Code code;
        private NullFlavor nullFlavor;
        private String codeSystem;

        public FullCodeHandler(String codeSystem, NullFlavor nullFlavor)
        {
            this.code = null;
            this.codeSystem = codeSystem;
            this.nullFlavor = nullFlavor;
        }

        public FullCodeHandler(Code code, String codeSystem)
        {
            this.code = code;
            this.codeSystem = codeSystem;
            this.nullFlavor = null;
        }

        public object Invoke(object proxy, MethodInfo method, object[] args)
        {
            if ("get_CodeValue".Equals(method.Name))
            {
                return this.code == null ? null : method.Invoke(this.code, args);
            }
            else if ("get_CodeSystem".Equals(method.Name))
            {
                return this.codeSystem;
            }
            else if ("HasNullFlavor".Equals(method.Name))
            {
                return this.nullFlavor != null;
            }
            else if ("get_NullFlavor".Equals(method.Name))
            {
                return this.nullFlavor;
            }
            else if ("Equals".Equals(method.Name))
            {
                return false;
            }
            else if ("GetHashCode".Equals(method.Name))
            {
                return new HashCodeBuilder().Append(this.code).Append(this.codeSystem).Append(this.nullFlavor).ToHashCode();
            }
            else if ("ToString".Equals(method.Name))
            {
                return this.code;
                //return ToStringBuilder.reflectionToString(this);
            }
            else
            {
                return null;
            }
        }

        public void Intercept(IInvocation invocation)
        {
            invocation.ReturnValue = Invoke(invocation.InvocationTarget, invocation.Method, invocation.Arguments);
        }
    }
}
