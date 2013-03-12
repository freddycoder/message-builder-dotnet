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
 * Last modified: $LastChangedDate: 2013-03-01 17:48:17 -0500 (Fri, 01 Mar 2013) $
 * Revision:      $LastChangedRevision: 6663 $
 */


using System;
using System.Text;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.J5goodies;

namespace Ca.Infoway.Messagebuilder
{


	public class GenericClassUtil
	{

		public static Type GetCollectionContentsType(BeanProperty property)
		{
			Type[] actualTypeArguments = property.Descriptor.GetGetMethod().GetGenericArguments();
			return actualTypeArguments != null && actualTypeArguments.Length > 0 ? actualTypeArguments[0] : null;
		}

		public static Object Instantiate(Type t, IDictionary<String,Type> templateArguments) {
			Type resolvedType = ResolveGenerics(t, templateArguments);
			return Activator.CreateInstance(resolvedType);
		}
		
		public static Object Instantiate(Type t, IList<TemplateArgument> templateArguments) {
			Type resolvedType = ResolveGenerics(t, templateArguments);
			return Activator.CreateInstance(resolvedType);
		}

		private static Type ResolveGenerics(Type t, IDictionary<String,Type> dictionary) {
			if (t.IsGenericType) {
				Type[] templateArguments = t.GetGenericArguments();
				Type[] arguments = new Type[templateArguments.Length];
				for (int i = 0, length = templateArguments.Length; i < length; i++) {
					String templateName = templateArguments[i].Name;
					if (dictionary.ContainsKey(templateName)) {
						arguments[i] = ResolveGenerics(dictionary[templateName], dictionary);
					} else {
						throw new System.ArgumentException("Missing parameter: " + templateName);
					}
				}
				return t.MakeGenericType(arguments);
			} else {
				return t;
			}
		}			
		
		private static Type ResolveGenerics(Type t, IList<TemplateArgument> templateArguments) {
			if (templateArguments == null || templateArguments.Count == 0) {
				return t;
			} else {
				Type[] arguments = new Type[templateArguments.Count];
				for (int i = 0, length = templateArguments.Count; i < length; i++) {
					TemplateArgument argument = templateArguments[i];
					arguments[i] = ResolveGenerics(argument.ArgumentType, argument.TemplateArguments);
				}
				return t.MakeGenericType(arguments);
			}
		}			
	}
}
