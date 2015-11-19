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
    public class HashCodeBuilder
    {
        private int hash;
        private int mult;

        public HashCodeBuilder()
        {
            hash = 17;
            mult = 37;
        }

        public HashCodeBuilder(int initialNonZeroOddNumber, int multiplierNonZeroOddNumber)
        {
            hash = initialNonZeroOddNumber;
            mult = multiplierNonZeroOddNumber;
        }

        public HashCodeBuilder Append<T>(T value)
        {
            if (null != value)
                hash += mult * value.GetHashCode();

            return this;
        }

        public HashCodeBuilder Append<T>(T[] array)
        {
            if (null != array)
                foreach (T e in array)
                    if (null != e)
                        hash += mult * e.GetHashCode();

            return this;
        }

        public HashCodeBuilder Append<T>(ISet<T> set) {
            return Append((ICollection<T>)set);
        }

        public HashCodeBuilder Append<T>(IList<T> list) {
            return Append((ICollection<T>)list);
        }

        public HashCodeBuilder Append<K,V>(IDictionary<K,V> dictionary) {
            if (dictionary != null) {
                foreach(K key in dictionary.Keys) {
                    hash += mult * key.GetHashCode();
                    V value = dictionary[key];
                    if (value != null) {
                        hash += mult * value.GetHashCode();
                    }
                }
            }
            return this;
        }

        public HashCodeBuilder Append<T>(ICollection<T> collection) {
            if (null != collection) {
                foreach (T e in collection) {
                    if (null != e) {
                        hash += mult * e.GetHashCode();
                    }
                }
            }
            return this;
        }

        public HashCodeBuilder AppendSuper(int superValue)
        {
            hash += mult * superValue;

            return this;
        }

        public int ToHashCode()
        {
            return hash;
        }

        public override int GetHashCode()
        {
            return hash;
        }
    }
}
