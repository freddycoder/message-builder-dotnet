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
 * Last modified: $LastChangedDate: 2011-05-17 11:48:36 -0400 (Tue, 17 May 2011) $
 * Revision:      $LastChangedRevision: 2666 $
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ca.Infoway.Messagebuilder
{
    public static class ICollectionGenericExtension
    {
        public static object[] Array<T>(this ICollection<T> coll)
        {
            if (null == coll)
                return null;

            object[] res = new object[coll.Count];

            int i = 0;
            foreach (T t in coll)
                res[i++] = t;

            return  res;
        }

        public static bool IsEmpty<T>(this ICollection<T> collection)
        {
            return  collection.Count == 0;
        }
		
        public static bool AddAll<T>(this ICollection<T> list, IEnumerable<T> e)
        {
            bool b = false;
            foreach (T t in e)
            {
                list.Add(t);
                b = true;
            }

            return b;
        }
		
		public static T[] ToArray<T>(this ICollection<T> coll) {
			return coll.ToArray(null);
		}
	
        public static T[] ToArray<T>(this ICollection<T> coll, T[] ignored)
        {
            if (null == coll)
                return null;

            T[] res = new T[coll.Count];

            int i = 0;
            foreach (T t in coll)
                res[i++] = t;

            return  res;
        }		

    }
}
