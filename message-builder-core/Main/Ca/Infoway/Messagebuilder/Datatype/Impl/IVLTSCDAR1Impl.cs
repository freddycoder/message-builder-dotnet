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
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;

    /// <summary>
    /// HL7 datatype IVL. Backed by the java datatype DateInterval. (this version for CDA/R1 usage)
    /// This data type is used when a continuous range needs to be expressed.
    /// </summary>
    public class IVLTSCDAR1Impl : QTYImpl<DateInterval>, IVLTSCDAR1
    {
        /// <summary>
        /// Constructs an empty INT.
        /// </summary>
        public IVLTSCDAR1Impl() :
            this((DateInterval)null)
        {
        }

        /// <summary>
        /// Constructs an INT with the given initial value.
        /// </summary>
        /// <param name="defaultValue">an initial value</param>
        public IVLTSCDAR1Impl(DateInterval defaultValue) :
            base(typeof(DateInterval), defaultValue, null, StandardDataType.IVL_TS)
        {
        }

        /// <summary>
        /// Constructs an INT with the given null flavor.
        /// </summary>
        /// <param name="nullFlavor">a null flavor</param>
        public IVLTSCDAR1Impl(NullFlavor nullFlavor) :
            base(typeof(DateInterval), null, nullFlavor, StandardDataType.IVL_TS)
        {
        }
    }
}