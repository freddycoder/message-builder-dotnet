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
using System.Linq;
using System.Text;
using ILOG.J2CsMapping.Collections.Generics;

namespace Ca.Infoway.Messagebuilder
{
    public class SynchSet<T> : ILOG.J2CsMapping.Collections.Generics.ISet<T>
    {
        private ILOG.J2CsMapping.Collections.Generics.ISet<T> set;

        public SynchSet(ILOG.J2CsMapping.Collections.Generics.ISet<T> set) 
        { 
			this.set = set;
		}

        #region IExtendedCollection<T> Members

        bool IExtendedCollection<T>.Add(T e)
        {
            lock (this) { return set.Add(e); }
        }

        bool IExtendedCollection<T>.AddAll(ICollection<T> c)
        {
            lock (this) { return set.AddAll(c); }
        }

        bool IExtendedCollection<T>.ContainsAll(ICollection<T> c)
        {
            lock (this) { return set.ContainsAll(c); }
        }

        bool IExtendedCollection<T>.RemoveAll(ICollection<T> c)
        {
            lock (this) { return set.RemoveAll(c); }
        }

        bool IExtendedCollection<T>.RetainAll(ICollection<T> c)
        {
            lock (this) { return set.RetainAll(c); }
        }

        T[] IExtendedCollection<T>.ToArray(T[] arr)
        {
            lock (this) { return set.ToArray(arr); }
        }

        T[] IExtendedCollection<T>.ToArray()
        {
            lock (this) { return set.ToArray(); }
        }

        #endregion

        #region ICollection<T> Members

        void ICollection<T>.Add(T item)
        {
            lock (this) { set.Add(item); }
        }

        void ICollection<T>.Clear()
        {
            lock (this) { set.Clear(); }
        }

        bool ICollection<T>.Contains(T item)
        {
            lock (this) { return set.Contains(item); }
        }

        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            lock (this) { set.CopyTo(array, arrayIndex); }
        }

        int ICollection<T>.Count
        {
            get { lock (this) { return set.Count(); } }
        }

        bool ICollection<T>.IsReadOnly
        {
            get { lock (this) { return set.IsReadOnly; } }
        }

        bool ICollection<T>.Remove(T item)
        {
            lock (this) { return set.Remove(item); }
        }

        #endregion

        #region IEnumerable<T> Members

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            lock (this) { return ((IEnumerable<T>) set).GetEnumerator(); }
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            lock (this) { return ((IEnumerable) set).GetEnumerator(); }
        }

        #endregion
    }
}
