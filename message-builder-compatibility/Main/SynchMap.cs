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
    public class SynchMap<K, V> : IDictionary<K, V>
    {
        private IDictionary<K, V> map;

        public SynchMap(IDictionary<K, V> map)
        {
            this.map = map;
        }

        #region IDictionary<K,V> Members

        void  IDictionary<K,V>.Add(K key, V value)
        {
            lock (this) { map.Add(key, value); }
        }

        bool  IDictionary<K,V>.ContainsKey(K key)
        {
            lock (this) { return map.ContainsKey(key); }
        }

        ICollection<K>  IDictionary<K,V>.Keys
        {
            get { lock (this) { return map.Keys; } }
        }

        bool  IDictionary<K,V>.Remove(K key)
        {
            lock (this) { return map.Remove(key); }
        }

        bool  IDictionary<K,V>.TryGetValue(K key, out V value)
        {
            lock (this) { return map.TryGetValue(key, out value); }
        }

        ICollection<V>  IDictionary<K,V>.Values
        {
            get { lock (this) { return map.Values; } }
        }

        V  IDictionary<K,V>.this[K key]
        {
            get { lock (this) { return map[key]; } }
            set { lock (this) { map[key] = value; ;  } }
        }

        #endregion

        #region ICollection<KeyValuePair<K,V>> Members

        void  ICollection<KeyValuePair<K,V>>.Add(KeyValuePair<K,V> item)
        {
            lock (this) { ((ICollection<KeyValuePair<K,V>>) map).Add(item); }
        }

        void  ICollection<KeyValuePair<K,V>>.Clear()
        {
            lock (this) { ((ICollection<KeyValuePair<K, V>>)map).Clear(); }
        }

        bool  ICollection<KeyValuePair<K,V>>.Contains(KeyValuePair<K,V> item)
        {
            lock (this) { return ((ICollection<KeyValuePair<K, V>>)map).Contains(item); }
        }

        void  ICollection<KeyValuePair<K,V>>.CopyTo(KeyValuePair<K,V>[] array, int arrayIndex)
        {
            lock (this) { ((ICollection<KeyValuePair<K, V>>)map).CopyTo(array, arrayIndex); }
        }

        int  ICollection<KeyValuePair<K,V>>.Count
        {
            get { lock (this) { return ((ICollection<KeyValuePair<K, V>>)map).Count; } }
        }

        bool  ICollection<KeyValuePair<K,V>>.IsReadOnly
        {
            get { lock (this) { return ((ICollection<KeyValuePair<K, V>>)map).IsReadOnly; } }
        }

        bool  ICollection<KeyValuePair<K,V>>.Remove(KeyValuePair<K,V> item)
        {
            lock (this) { return ((ICollection<KeyValuePair<K, V>>)map).Remove(item); }
        }

        #endregion

        #region IEnumerable<KeyValuePair<K,V>> Members

        IEnumerator<KeyValuePair<K,V>>  IEnumerable<KeyValuePair<K,V>>.GetEnumerator()
        {
            lock (this) { return ((IEnumerable<KeyValuePair<K,V>>) map).GetEnumerator(); }
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator  System.Collections.IEnumerable.GetEnumerator()
        {
            lock (this) { return ((System.Collections.IEnumerable) map).GetEnumerator(); }
        }

        #endregion
	}
}
