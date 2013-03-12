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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ca.Infoway.Messagebuilder
{
    public static class TypeUtils
    {
        public static bool IsNullable<T>(Type type, T value)
        {
            Type t = typeof(T);

            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                Type[] ta = t.GetGenericArguments();

                return 1 == ta.Length && ta[0].Equals(type);
            }

            return false;
        }

        
        public static T Cast<T>(object o)
        {
            return (T) o; 
        }
        

        public static bool IsCast<T>(object o, out T value)
        {
            try
            {
                value = (T)o;
                return true;
            }
            catch (InvalidCastException)
            {
                value = default(T);
                return false;
            }
        }
    }
}
