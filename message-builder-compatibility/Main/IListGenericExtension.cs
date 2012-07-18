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
    public static class IListGenericExtension
    {
        public static bool AddAll<T>(this IList<T> list, IEnumerable<T> e)
        {
            bool b = false;
            foreach (T t in e)
            {
                list.Add(t);
                b = true;
            }

            return b;
        }

        public static bool AddAll<T>(this IList<T> list, int index, IEnumerable<T> e)
        {
            bool b = false;
            foreach (T t in e)
            {
                list.Insert(index++, t);
                b = true;
            }

            return b;
        }

        public static int LastIndexOf<T>(this IList<T> list, T t)
        {
            for (int i = list.Count; 0 < i--; )
                if (null == t ? null == list[i] : t.Equals(list[i]))
                    return i;

            return -1;
        }

        public static bool RetainAll<T>(this IList<T> list, ICollection<T> c)
        {
            return RemRetAll(list, c, false);
        }

        public static bool RemoveAll<T>(this IList<T> list, ICollection<T> c)
        {
            return RemRetAll(list, c, true);
        }

        private static bool RemRetAll<T>(IList<T> list, ICollection<T> c, bool remove)
        {
            bool b = false;

            for (int i = list.Count; 0 < i--; )
            {
                if (remove == c.Contains(list[i]))
                {
                    list.RemoveAt(i);
                    b = true;
                }
            }

            return b;
        }

        public static IList<T> SubList<T>(this IList<T> list, int a, int z)
        {
            System.Collections.Generic.List<T> result = new System.Collections.Generic.List<T>(z - a);

            while (a < z)
                result.Add(list[a++]);

            return result;
        }
		
		public static void Remove<T>(this IList<T> list, int index) 
		{
			list.RemoveAt(index);
		}
		
		public static T[] ToArray<T>(this IList<T> coll) {
			return coll.ToArray(null);
		}
	
        public static T[] ToArray<T>(this IList<T> coll, T[] ignored)
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
