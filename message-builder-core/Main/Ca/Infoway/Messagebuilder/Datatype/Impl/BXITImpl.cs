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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */

namespace Ca.Infoway.Messagebuilder.Datatype.Impl
{
    using Ca.Infoway.Messagebuilder.Domainvalue;

    public class BXITImpl<T> : ANYImpl<T>, BXIT<T> 
    {
        /// <summary>
        /// Constructs an empty SXCM.
        /// </summary>
        public BXITImpl() :
            this(default(T))
        {
        }

        /// <summary>
        /// Constructs an SXCM using the supplied value.
        /// </summary>
        /// <param name="defaultValue">the initial value</param>
        public BXITImpl(T defaultValue) :
            base(defaultValue == null ? null : typeof(T), defaultValue, null, StandardDataType.BXIT_CD)
        {
        }

        /// <summary>
        /// Constructs an SXCM with the supplied null flavor.
        /// </summary>
        /// <param name="nullFlavor">a null flavor</param>
        public BXITImpl(NullFlavor nullFlavor) :
            base(null, default(T), nullFlavor, StandardDataType.BXIT_CD)
        {
        }
    }
}