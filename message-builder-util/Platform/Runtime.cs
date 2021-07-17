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


using ILOG.J2CsMapping.Reflect;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ca.Infoway.Messagebuilder
{

	public class Runtime
	{

        private static Dictionary<string, string> propertyCache = new Dictionary<string, string>();

		static Runtime ()
		{
            propertyCache["line.separator"] = System.Environment.NewLine;
		}
		
		public static string GetProperty(string property) {
			if (propertyCache.ContainsKey(property)) {
				return propertyCache.SafeGet(property);
            }
            else if (property != null && isMessageBuilderProperty(property)) {
                string value = System.Environment.GetEnvironmentVariable(property);
                propertyCache[property] = value;
                return value;
            }
			throw new NotSupportedException(property);
		}

        public static void SetProperty(string property, string propertyValue)
        {
            if (property != null && isMessageBuilderProperty(property)) {
                propertyCache[property] = propertyValue;
                System.Environment.SetEnvironmentVariable(property, propertyValue);
                return;
            }
            throw new NotImplementedException();
        }

        public static void ClearProperty(string property)
        {
            if (property != null && isMessageBuilderProperty(property)) {
                propertyCache.Remove(property);
                System.Environment.SetEnvironmentVariable(property, null);
                return;
            }
            throw new NotImplementedException();
        }

        private static Dictionary<string, Type> _typeCache = new Dictionary<string, Type>();
        public static Type GetType(string typeName)
        {
			try {
                if (_typeCache.TryGetValue(typeName, out var cachedResult))
                {
                    return cachedResult;
                }
                Type result = GetNativeType(StringUtils.Trim(typeName));
                if (result == null)
                {
                    throw new TypeLoadException($"Unable to load type: {typeName}");
                }
                else
                {
                    try
                    {
                        _typeCache.Add(typeName, result);
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine($"Failed to cache {typeName}. Reason: {e}");
                    }
				    return result;
                }
			} catch (ArgumentNullException e) {
                throw new TypeLoadException($"Unable to load type: {typeName}", e);
			}
		}

        private static bool isMessageBuilderProperty(string property)
        {
            if (property.StartsWith("messagebuilder.date.format.override."))
            {
                return true;
            }
            else if (property.ToLower().Equals("ignored.as.not.allowed"))
            {
                return true;
            }
            else if (property.ToLower().Equals("messagebuilder.abstract.ts.ignore.specializationtype.error"))
            {
                return true;
            }
            else if (property.ToLower().Equals("messagebuilder.output.warnings.in.generated.xml"))
            {
                return true;
            }
            else if (property.ToLower().Equals("messagebuilder.suppress.xsi.nil.on.nullflavor"))
            {
                return true;
            }
            return false;
        }

        public static Type GetNativeType(string className) => GetNativeType(Assembly.GetExecutingAssembly(), className);

        public static Type GetNativeType(Assembly a, string className)
        {
            Type type1 = a.GetType(className);
            if (type1 != null)
                return type1;
            int length1 = className.LastIndexOf(".");
            if (length1 > 0)
            {
                string str = className.Substring(length1 + 1);
                string name = className.Substring(0, length1) + "+" + str;
                Type type2 = a.GetType(name);
                if (type2 != null)
                    return type2;
            }
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type type2 = assembly.GetType(className);
                if (type2 == null)
                {
                    int length2 = className.LastIndexOf(".");
                    if (length2 > 0)
                    {
                        string str = className.Substring(length2 + 1);
                        string name = className.Substring(0, length2) + "+" + str;
                        Type type3 = assembly.GetType(name);
                        if (type3 != null)
                            return type3;
                    }
                }
                if (type2 != null)
                    return type2;
            }
            if (AssemblyScanner.Self == null)
            {
                AssemblyScanner.Initialize();
                AssemblyScanner.Self = new AssemblyScanner();
            }
            return AssemblyScanner.Self.Resolve(className);
        }
    }
}
