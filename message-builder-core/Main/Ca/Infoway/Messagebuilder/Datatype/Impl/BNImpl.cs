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


namespace Ca.Infoway.Messagebuilder.Datatype.Impl
{
    using System;
    using Ca.Infoway.Messagebuilder.Domainvalue;

    /// <summary>
    /// HL7 datatype BN. Backed by a Boolean.
    /// BL stands for the values of two-valued logic.
    /// A BN value can be either true or false, and may not be NULL.
    /// </summary>
    public class BNImpl : ANYImpl<Boolean?>, BN
    {
        /// <summary>
        /// Constructs an empty BL.
        /// </summary>
        public BNImpl()
            : this((Boolean?)null)
        {
        }

        /// <summary>
        /// Constructs a BL with the given value.
        /// </summary>
        /// <param name="defaultValue">an initial value</param>
        public BNImpl(Boolean? defaultValue) :
            base(typeof(Boolean), defaultValue, null, StandardDataType.BN) {
        }

        /// <summary>
        /// Constructs an BL with the given null flavor.
        /// </summary>
        /// <param name="nullFlavor">a null flavor</param>
        public BNImpl(NullFlavor nullFlavor) :
            base(typeof(Boolean), null, nullFlavor, StandardDataType.BN)
        {
        }
    }
}