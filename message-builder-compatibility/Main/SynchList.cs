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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ca.Infoway.Messagebuilder
{
    public class SynchList<T> : IList<T>
    {
        private IList<T> list;


        public SynchList(IList<T> list)
        {
            this.list = list;
        }

        #region IList<T> Members

        int IList<T>.IndexOf(T item)
        {
            lock (this) { return list.IndexOf(item); }
        }

        void IList<T>.Insert(int index, T item)
        {
            lock (this) { list.Insert(index, item); }
        }

        void IList<T>.RemoveAt(int index)
        {
            lock (this) { list.RemoveAt(index); }
        }

        T IList<T>.this[int index]
        {
            get { lock (this) { return list[index]; } }
            set { lock (this) { list[index] = value; } }
        }

        #endregion

        #region ICollection<T> Members

        void ICollection<T>.Add(T item)
        {
            lock (this) { list.Add(item); }
        }

        void ICollection<T>.Clear()
        {
            lock (this) { list.Clear(); }
        }

        bool ICollection<T>.Contains(T item)
        {
            lock (this) { return list.Contains(item); }
        }

        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            lock (this) { list.CopyTo(array, arrayIndex); }
        }

        int ICollection<T>.Count
        {
            get { lock (this) { return list.Count(); } }
        }

        bool ICollection<T>.IsReadOnly
        {
            get { lock (this) { return list.IsReadOnly; } }
        }

        bool ICollection<T>.Remove(T item)
        {
            lock (this) { return list.Remove(item); }
        }

        #endregion

        #region IEnumerable<T> Members

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            lock (this) { return ((IEnumerable<T>) list).GetEnumerator(); }
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            lock (this) { return ((IEnumerable) list).GetEnumerator(); }
        }

        #endregion
    }
}
