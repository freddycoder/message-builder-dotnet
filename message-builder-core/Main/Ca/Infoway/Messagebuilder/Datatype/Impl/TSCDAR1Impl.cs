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
    using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
    using Ca.Infoway.Messagebuilder.Domainvalue;

    /// <summary>
    /// HL7 datatype TS backed by a java Date. (this version for CDA/R1 usage)
    /// 
    /// A quantity specifying a point on the axis of natural time. A point in time is
    /// most often represented as a calendar expression.
    /// 
    /// Semantically, however, time is independent from calendars and best described
    /// by its relationship to elapsed time (measured as a physical quantity in the
    /// dimension of time). A TS plus an elapsed time yields another TS. Inversely, a
    /// TS minus another TS yields an elapsed time.
    /// 
    /// As nobody knows when time began, a TS is conceptualized as the amount of time
    /// that has elapsed from some arbitrary zero-point, called an epoch. Because
    /// there is no absolute zero-point on the time axis; natural time is a
    /// difference-scale quantity, where only differences are defined but no ratios.
    /// (For example, no TS is - absolutely speaking - "twice as late" as another
    /// TS.)
    /// 
    /// Given some arbitrary zero-point, one can express any point in time as an
    /// elapsed time measured from that offset. Such an arbitrary zero-point is
    /// called an epoch. This epoch-offset form is used as a semantic representation
    /// here, without implying that any system would have to implement TS in that
    /// way. Systems that do not need to compute distances between TSs will not need
    /// any other representation than a calendar expression literal.
    /// </summary>
    public class TSCDAR1Impl : QTYImpl<MbDate>, TSCDAR1
    {
        /// <summary>
        /// Constructs an empty TS.
        /// </summary>
        public TSCDAR1Impl() :
            this((MbDate)null)
        {
        }

        /// <summary>
        /// Constructs a TS using the given date.
        /// </summary>
        /// <param name="date">the initial value</param>
        public TSCDAR1Impl(MbDate date) :
            this(date, null)
        {
        }

        /// <summary>
        /// Constructs a TS using the given date and operator.
        /// </summary>
        /// <param name="date">the initial value</param>
        /// <param name="setOperator">the initial operator</param>
        public TSCDAR1Impl(MbDate date, SetOperator setOperator) :
            base(typeof(MbDate), date, null, StandardDataType.TS)
        {
        }

        /// <summary>
        /// Constructs a TS using the given null flavor.
        /// </summary>
        /// <param name="nullFlavor">a null flavor</param>
        public TSCDAR1Impl(NullFlavor nullFlavor) :
            base(typeof(MbDate), null, nullFlavor, StandardDataType.TS)
        {
        }
    }
}