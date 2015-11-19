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
 * Last modified: $LastChangedDate: 2014-01-23 14:24:29 -0500 (Thu, 23 Jan 2014) $
 * Revision:      $LastChangedRevision: 8362 $
 */


using System;
using System.Collections;
using System.Collections.Generic;

namespace Ca.Infoway.Messagebuilder.Platform
{

	public class LinkedSet<T> : ICollection<T>, IEquatable<LinkedSet<T>>
	{
		private LinkedList<T> list;
		
		public LinkedSet() 
		{
			this.list = new LinkedList<T>();
		}
		public LinkedSet(IEnumerable<T> content) 
		{
			this.list = new LinkedList<T>();
			foreach (T t in content) {
				this.list.AddLast(t);
			}
		}
		
		public int Count {
			get { return this.list.Count; }
		}

		public bool IsReadOnly {
			get { return false; }
		}
		
		public void Add(T t) {
			if (!this.list.Contains(t)) {
				this.list.AddLast(t);
			}
		}
		public bool Remove(T t) {
			return this.list.Remove(t);
		}
		public void CopyTo(T[] t, int i) {
			this.list.CopyTo(t, i);
		}
		public void Clear() {
			this.list.Clear();
		}
		public bool Contains(T t) {
			return this.list.Contains(t);
		}
		IEnumerator IEnumerable.GetEnumerator() {
			return this.list.GetEnumerator();
		}
		IEnumerator<T> IEnumerable<T>.GetEnumerator() {
			return this.list.GetEnumerator();
		}
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is LinkedSet<T>))
            {
                return false;
            }
            return this.Equals((LinkedSet<T>)obj);
        }
        public bool Equals(LinkedSet<T> that)
        {
            if (this.list.Count != that.list.Count) {
                return false;
            }
            int count = 0;
            T[] otherList = that.list.ToArray();
            foreach (T item in this.list)
            {
                if (!item.Equals(otherList[count])) {
                    return false;
                }
                count++;
            }

            return true;
        }

	}
}
