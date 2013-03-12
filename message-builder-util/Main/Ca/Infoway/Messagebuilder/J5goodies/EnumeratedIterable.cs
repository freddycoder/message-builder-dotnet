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
 * Last modified: $LastChangedDate: 2013-03-01 17:48:17 -0500 (Fri, 01 Mar 2013) $
 * Revision:      $LastChangedRevision: 6663 $
 */

/// ---------------------------------------------------------------------------------------------------
///  This file was automatically generated by J2CS Translator (http://j2cstranslator.sourceforge.net/). 
///  Version 1.0.0                                                                                      
/// ---------------------------------------------------------------------------------------------------
 
namespace Ca.Infoway.Messagebuilder.J5goodies {
	
	using ILOG.J2CsMapping.Collections;
	using ILOG.J2CsMapping.Collections.Generics;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	
	public class EnumeratedIterable {
	
		internal class IteratorImpl<T> : IIterator<T> {
	
			private readonly IIterator<T> e;
	
			public IteratorImpl(IIterator<T> e_0) {
				this.e = e_0;
			}
	
			public virtual bool HasNext() {
				return e.HasNext();
			}
	
			public virtual T Next() {
				return e.Next();
			}
	
			public virtual void Remove() {
				throw new NotImplementedException("remove()");
			}
	
            #region AddedByTranslator
	
            object ILOG.J2CsMapping.Collections.IIterator.Next()
            {
                return this.Next();
            }

            #endregion
        }


        internal class IterableImpl<T> : IEnumerable<T> {
			private readonly IIterator<T> e;
	
			public IterableImpl(IIterator<T> e_0) {
				this.e = e_0;
			}
	
			public virtual  IIterator Iterator() {
				return new EnumeratedIterable.IteratorImpl<T>(e);
			}

            #region IEnumerable<T> Members

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                throw new NotImplementedException();
            }

            #endregion

            #region IEnumerable Members

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }

            #endregion
        }
	
		public static IEnumerable<T> Iterable<T>(IIterator<T> e_0) {
			return new EnumeratedIterable.IterableImpl<T>(e_0);
		}
	
	}
}
