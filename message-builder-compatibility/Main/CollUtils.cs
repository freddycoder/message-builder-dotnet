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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2011-12-21 14:34:58 -0500 (Wed, 21 Dec 2011) $
 * Revision:      $LastChangedRevision: 3164 $
 */

using System;
using System.Collections;
using System.Collections.Generic;
using ILOG.J2CsMapping.Collections.Generics;


namespace Ca.Infoway.Messagebuilder
{
    public static class CollUtils
    {
		public static IList<object> EMPTY_LIST = new List<object>();
		
		public static IList<T> EmptyList<T>() {
			return new List<T>();
		}

        public static bool IsEmpty<T>(ICollection<T> c)
        {
            return null == c ? true : 0 == c.Count;
        }

        public static bool IsNotEmpty<T>(ICollection<T> c)
        {
            return !IsEmpty<T>(c);
        }

        public static bool IsEmpty(ICollection c)
        {
            return null == c ? true : 0 == c.Count;
        }

        public static bool IsNotEmpty(ICollection c)
        {
            return !IsEmpty(c);
        }

        public static void Reverse<T>(IList<T> list)
        {
            for (int a = 0, z = list.Count - 1; a < z; )
            {
                T t = list[a];
                list[a++] = list[z];
                list[z--] = t;
            }
        }

        public static IList<T> SynchronizedList<T>(IList<T> list)
        {
            return new SynchList<T>(list);
        }

        public static IDictionary<K,V> SynchronizedMap<K,V>(IDictionary<K,V> map)
        {
            return new SynchMap<K,V>(map);
        }

        public static ILOG.J2CsMapping.Collections.Generics.ISet<T> SynchronizedSet<T>(ILOG.J2CsMapping.Collections.Generics.ISet<T> @set)
        {
            return new SynchSet<T>(@set);
        }

        public static IIterator<T> CreateUnmodifiableIterator<T>(IIterator<T> i)
        {
            return new UnmodifiableIterator<T>(i);
        }

        public static IListIterator<T> CreateUnmodifiableListIterator<T>(IListIterator<T> i)
        {
            return new UnmodifiableListIterator<T>(i);
        }

        private class UnmodifiableIterator<T> : IIterator<T>
        {
            private IIterator<T> i;

            public UnmodifiableIterator(IIterator<T> i) { this.i = i; }

            public bool HasNext() { return i.HasNext(); }

            public T Next() { return i.Next(); }

            object ILOG.J2CsMapping.Collections.IIterator.Next() { return (object) i.Next(); }

            public void Remove() { throw new InvalidOperationException("Remove"); }
        }

        private class UnmodifiableListIterator<T> : IListIterator<T>
        {
            private IListIterator<T> i;

            public UnmodifiableListIterator(IListIterator<T> i) { this.i = i; }

            public bool HasNext() { return i.HasNext(); }

            public T Next() { return i.Next(); }

            object ILOG.J2CsMapping.Collections.IIterator.Next() { return (object)i.Next(); }

            public void Remove() { throw new InvalidOperationException("Remove"); }

            public void Add(T x) { throw new InvalidOperationException("Add"); }

            public bool HasPrevious() { return i.HasPrevious(); }

            public int NextIndex() { return i.NextIndex(); }

            public T Previous() { return i.Previous(); }

            public int PreviousIndex() { return i.PreviousIndex(); }

            public void Set(T x) { throw new InvalidOperationException("Set"); }
        }

        public static ILOG.J2CsMapping.Collections.Generics.ISet<T> CreateUnmodifiableSet<T>(ILOG.J2CsMapping.Collections.Generics.ISet<T> s)
        {
            return new UnmodifiabeSet<T>(s);
        }

        private class UnmodifiabeSet<T> : ILOG.J2CsMapping.Collections.Generics.ISet<T>
        {
            ILOG.J2CsMapping.Collections.Generics.ISet<T> s;

            public UnmodifiabeSet(ILOG.J2CsMapping.Collections.Generics.ISet<T> s) { this.s = s; }

            public bool Add(T e)
            {
                throw new InvalidOperationException("Add");
            }

            public bool AddAll(ICollection<T> c)
            {
                throw new NotImplementedException();
            }

            public bool ContainsAll(ICollection<T> c)
            {
                return s.ContainsAll(c);
            }

            public bool RemoveAll(ICollection<T> c)
            {
                throw new InvalidOperationException("RemoveAll");
            }

            public bool RetainAll(ICollection<T> c)
            {
                throw new InvalidOperationException("RetainAll");
            }

            public T[] ToArray(T[] arr)
            {
                return s.ToArray(arr);
            }

            public T[] ToArray()
            {
                return s.ToArray();
            }

            void ICollection<T>.Add(T item)
            {
                throw new InvalidOperationException("Add");
            }

            public void Clear()
            {
                throw new InvalidOperationException("Clear");
            }

            public bool Contains(T item)
            {
                return s.Contains(item);
            }

            public void CopyTo(T[] array, int arrayIndex)
            {
                s.CopyTo(array, arrayIndex);
            }

            public int Count
            {
                get { return s.Count; }
            }

            public bool IsReadOnly
            {
                get { return true; }
            }

            public bool Remove(T item)
            {
                throw new InvalidOperationException("Remove");
            }

            public IEnumerator<T> GetEnumerator()
            {
                return s.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return s.GetEnumerator();
            }
        }
    
        public static IDictionary<T, V> CreateUnmodifiableDictionary<T, V>(IDictionary<T, V> dictionary)
        {
            return dictionary;
        }
	
	}
}
