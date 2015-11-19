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
using ILOG.J2CsMapping.Collections;

namespace Ca.Infoway.Messagebuilder
{
    public class EqualsBuilder
    {
        private bool equal;

        public EqualsBuilder()
        {
            equal = true;
        }

        public EqualsBuilder Append<T>(T lhs, T rhs)
        {
            if (equal)
                equal = (null != lhs ? lhs.Equals(rhs) : null == rhs);

            return this;
        }

        public EqualsBuilder Append<T> (ISet<T> lhs, ISet<T> rhs) {
            if (equal) {
                equal = SetEquals(lhs, rhs);
            }
            return this;
        }

        public EqualsBuilder Append<T>(IList<T> lhs, IList<T> rhs)
        {
            if (equal) {
                equal = ListEquals(lhs, rhs);
            }
            return this;
        }

        public EqualsBuilder Append<K,V>(IDictionary<K,V> lhs, IDictionary<K,V> rhs) {
            if (equal) {
                equal = DictionaryEquals(lhs, rhs);
            }
            return this;
        }

        private bool DictionaryEquals<K,V>(IDictionary<K,V> lhs, IDictionary<K,V> rhs) {
            if (BothSameReference(lhs, rhs)) {
                return true;
            }
            if (!CollectionEquals(lhs, rhs)) {
                return false;
            }
            foreach(K key in lhs.Keys) {
                if (!rhs.ContainsKey(key)) {
                    return false;
                }
                V lhsValue = lhs[key];
                V rhsValue = rhs[key];
                if (!BothNotNull(lhsValue, rhsValue)) {
                    return false;
                }
                if (!lhsValue.Equals(rhsValue)) {
                    return false;
                }
            }
            return true;
        }

        private bool SetEquals<T>(ISet<T> lhs, ISet<T> rhs) {
            if (BothSameReference(lhs, rhs)) {
                return true;
            }
            if (!CollectionEquals(lhs, rhs)) {
                return false;
            }
            return lhs.SetEquals(rhs);
        }

        private bool BothSameReference(object lhs, object rhs) {
            return lhs == rhs;
        }

        private bool BothNotNull(object lhs, object rhs) {
            if (lhs == null && rhs != null) {
                return false;
            }
            if (lhs != null && rhs == null) {
                return false;
            }
            return true;
        }

        private bool CollectionEquals<T>(ICollection<T> lhs, ICollection<T> rhs) {
            if (!BothNotNull(lhs, rhs)) {
                return false;
            }
            if (lhs.Count != rhs.Count) {
                return false;
            }
            return true;
        }

        private bool ListEquals<T>(IList<T> lhs, IList<T> rhs) {
            if (BothSameReference(lhs, rhs)) {
                return true;
            }
            if (!CollectionEquals(lhs, rhs)) {
                return false;
            }
            IEnumerator<T> e1 = lhs.GetEnumerator();
            IEnumerator<T> e2 = rhs.GetEnumerator();
            while (e1.MoveNext() && e2.MoveNext()) {
                if (!object.Equals(e1.Current, e2.Current)) {
                    return false;
                }
            }
            return true;
        }

        public EqualsBuilder AppendSuper(bool superEquals)
        {
            if (equal)
                equal = superEquals;

            return this;
        }

        public bool IsEquals()
        {
            return equal;
        }
    }
}
