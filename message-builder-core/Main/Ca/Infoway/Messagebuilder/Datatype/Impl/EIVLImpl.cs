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
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;

    /// <summary>
    /// R2 datatype CE. Backed by a Code.
    /// </summary>
    public class EIVLImpl<EventRelatedPeriodicIntervalTime> : ANYImpl<EventRelatedPeriodicIntervalTime>, EIVL<EventRelatedPeriodicIntervalTime>
    {

        /// <summary>
        /// Constructs an empty EIVL.
        /// </summary>
        public EIVLImpl() :
            this(default(EventRelatedPeriodicIntervalTime), null, StandardDataType.EIVL_TS)
        {
        }

        /// <summary>
        /// Constructs an EIVL with the given value.
        /// </summary>
        /// <param name="defaultValue">an initial value</param>
        public EIVLImpl(EventRelatedPeriodicIntervalTime defaultValue) :
            this(defaultValue, null, StandardDataType.EIVL_TS)
        {
        }

        /// <summary>
        /// Constructs an EIVL with the given null flavor.
        /// </summary>
        /// <param name="nullFlavor">a null flavor</param>
        public EIVLImpl(NullFlavor nullFlavor) :
            this(default(EventRelatedPeriodicIntervalTime), nullFlavor, StandardDataType.EIVL_TS)
        {
        }

        /// <summary>
        /// Constructs an EIVL using the supplied parameters.
        /// </summary>
        /// <param name="value">an initial value</param>
        /// <param name="nullFlavor">a null flavor</param>
        /// <param name="dataType">an HL7 datatype</param>
        public EIVLImpl(EventRelatedPeriodicIntervalTime value, NullFlavor nullFlavor, StandardDataType dataType) :
            base(value, nullFlavor, dataType)
        {
        }
    }
}