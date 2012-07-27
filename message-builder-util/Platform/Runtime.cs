/**
 * Copyright 2012 Canada Health Infoway, Inc.
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
 * Last modified: $LastChangedDate: 2012-03-29 21:03:08 -0400 (Thu, 29 Mar 2012) $
 * Revision:      $LastChangedRevision: 5823 $
 */

using System;

namespace Ca.Infoway.Messagebuilder
{

	public class Runtime
	{

		public Runtime ()
		{
		}
		
		public static string GetProperty(string property) {
			if (property == "line.separator") {
				return System.Environment.NewLine;
            }
            else if (property != null && (property.StartsWith("messagebuilder.date.format.override.") || property.StartsWith("ignored.as.not.allowed"))) {
                return System.Environment.GetEnvironmentVariable(property);
            }
			throw new NotSupportedException(property);
		}

        public static void SetProperty(string property, string propertyValue)
        {
            if (property != null && (property.StartsWith("messagebuilder.date.format.override.") || property.StartsWith("ignored.as.not.allowed")))
            {
                System.Environment.SetEnvironmentVariable(property, propertyValue);
                return;
            }
            throw new NotImplementedException();
        }
        
        public static Type GetType(string typeName)
        {
			try {
                Type result = ILOG.J2CsMapping.Reflect.Helper.GetNativeType(StringUtils.Trim(typeName));
                if (result == null)
                {
                    throw new TypeLoadException("Unable to load type: " + typeName);
                } 
                else 
                {
				    return ILOG.J2CsMapping.Reflect.Helper.GetNativeType(StringUtils.Trim(typeName));
                }
			} catch (ArgumentNullException e) {
				throw new TypeLoadException("Unable to load type: " + typeName, e);				
			}
		}
		
		public static void PrintStackTrace(Exception e) {
			Console.WriteLine(e.ToString());
		}

    }
}
