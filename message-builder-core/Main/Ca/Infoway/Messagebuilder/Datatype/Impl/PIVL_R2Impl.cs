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
    /// R2 Periodic Interval of Time (PIVL) specializes SXCM. Backed by java datatype PeriodicIntervalTimeR2.
    /// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-PIVL
    /// Definition: An interval of time that recurs periodically. Periodic intervals
    /// have two properties, phase and period. The phase specifies the "interval
    /// prototype" that is repeated every period.
    /// </summary>
    public class PIVL_R2Impl : ANYImpl<PeriodicIntervalTimeR2>, PIVL_R2
    {
        /// <summary>
        /// Constructs an empty PIVL.
        /// </summary>
        public PIVL_R2Impl() :
            this((PeriodicIntervalTimeR2)null)
        {
        }

        /// <summary>
        /// Constructs a PIVL with the supplied value.
        /// </summary>
        /// <param name="defaultValue">initial value</param>
        public PIVL_R2Impl(PeriodicIntervalTimeR2 defaultValue) :
            base(typeof(PeriodicIntervalTimeR2), defaultValue, null, StandardDataType.PIVL_TS)
        {
        }

        /// <summary>
        /// Constructs a PIVL with the supplied null flavor.
        /// </summary>
        /// <param name="nullFlavor">a null flavor</param>
        public PIVL_R2Impl(NullFlavor nullFlavor) :
            base(typeof(PeriodicIntervalTimeR2), null, nullFlavor, StandardDataType.PIVL_TS)
        {
        }
    }
}