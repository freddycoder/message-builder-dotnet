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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */
using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Platform;
using System.Collections;

namespace Ca.Infoway.Messagebuilder.Datatype.Impl
{
	/// <summary>A list that wraps the underlying   list of   datatype values (the "raw" values).</summary>
	/// <remarks>A list that wraps the underlying   list of   datatype values (the "raw" values).</remarks>
	/// <author><a href="http://www.intelliware.ca/">Intelliware Development</a></author>
	public class RawListWrapper<T, V> : IList<V> where T : BareANY
	{
		private readonly IList<T> original;

		private readonly Type originalElementType;

		public RawListWrapper(ICollection<T> original, Type originalElementType)
		{
			this.original = (IList<T>) original;
			this.originalElementType = originalElementType;
		}

		private T Wrap(object element)
		{
			BareANY bareAny = (BareANY) ClassUtil.NewInstance(originalElementType);
			BareANYImpl impl = (BareANYImpl) bareAny;
			impl.BareValue = element;
			return (T) bareAny;
		}

		private IList<V> ConvertToList()
		{
			IList<V> list = new List<V>();
			foreach (T originalElement in this.original)
			{
				BareANY any = (BareANY)originalElement;
				list.Add((V)any.BareValue);
			}
			return list;
		}

        int IList<V>.IndexOf(V item)
        {
			IList<V> list = ConvertToList();
			return list.IndexOf(item);
        }

        void IList<V>.Insert(int index, V item)
        {
			original.Insert(index, Wrap(item));
        }

        void IList<V>.RemoveAt(int index)
        {
			original.RemoveAt(index);
        }

        V IList<V>.this[int index]
        {
            get
            {
                return ConvertToList()[index];
            }
            set
            {
				original[index] = Wrap(value);
            }
        }

		// this method is found by reflection...
		public void Add(Object item) {
			original.Add(Wrap(item));
		}
        void ICollection<V>.Add(V item)
        {
            original.Add(Wrap(item));

            
        }

        void ICollection<V>.Clear()
        {
            original.Clear();
        }

        bool ICollection<V>.Contains(V item)
        {
            return original.Contains(Wrap(item));
        }

        void ICollection<V>.CopyTo(V[] array, int arrayIndex)
        {
            var arrayCopy = new T[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                arrayCopy[i] = Wrap(array[i]);
            }

            original.CopyTo(arrayCopy, arrayIndex);
        }

        int ICollection<V>.Count
        {
            get
            {
                return original.Count;
            }
        }

        bool ICollection<V>.IsReadOnly
        {
            get
            {
                return original.IsReadOnly;
            }
        }

        bool ICollection<V>.Remove(V item)
        {
            return original.Remove(Wrap(item));
        }

        IEnumerator<V> IEnumerable<V>.GetEnumerator()
        {
            return ConvertToList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ConvertToList().GetEnumerator();
        }

	}
}
