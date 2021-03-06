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


/// ---------------------------------------------------------------------------------------------------
///  This file was automatically generated by J2CS Translator (http://j2cstranslator.sourceforge.net/). 
///  Version 1.0.0                                                                                      
/// ---------------------------------------------------------------------------------------------------
 
namespace Ca.Infoway.Messagebuilder.Datatype.Lang {

    using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
    using Ca.Infoway.Messagebuilder.Domainvalue;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	
	/// <summary>
	/// Uncertain Range.
	/// This data type is used when a continuous range needs to be expressed. 
    /// Recommended to use the UncertainRangeFactory class for object creation.
	/// For URG&lt;TS.DATE&gt; This data type is used when an occurrence is tied to a specific date, 
	/// but the actual date is not known, merely the range of dates within which the date falls. 
	/// This differs from IVL&lt;TS.DATE&gt; in that it refers to a single occurrence rather than a period 
	/// covering multiple days.
	/// For URG&lt;PQ.x&gt;: This is used to express a single quantity whose specific value is not known, but 
	/// whose upper and lower bounds are known. The URG data type already places implicit constraints on 
	/// probability. Outside the range, probability is 0, within the range, probability is unknown. PQ.x 
	/// implies any of the PQ.x data types in the specification (e.g. PQ.LAB, PQ.DISTANCE), not the PQ data type by itself.                             
	/// </summary>
	///
	/// <param name="T"> the underlying urg's   datatype (eg. Date)</param>
	public class UncertainRange<T> : Interval<T> {

        /// <summary>
        /// Constructs an uncertain range.
        /// Recommended to use the UncertainRangeFactory class for object creation.
        /// </summary>
        ///
        /// <param name="interval">an interval</param>
        public UncertainRange(Interval<T> interval)
            : this(interval.Low, interval.High, interval.Centre, interval.Width, interval.Representation, interval.LowNullFlavor, interval.HighNullFlavor, interval.CentreNullFlavor)
        {
        }

        /// <summary>
        /// Constructs an uncertain range.
        /// Recommended to use the UncertainRangeFactory class for object creation.
        /// </summary>
        ///
        /// <param name="interval">an interval</param>
        /// <param name="lowInclusive">lowInclusive</param>
        /// <param name="highInclusive">highInclusive</param>
        public UncertainRange(Interval<T> interval, Boolean? lowInclusive, Boolean? highInclusive)
            : this(interval.Low, interval.High, interval.Centre, interval.Width, interval.Representation, interval.LowNullFlavor, interval.HighNullFlavor, interval.CentreNullFlavor, lowInclusive, highInclusive)
        {
        }

        /// <summary>
        /// Constructs an uncertain range.
        /// Recommended to use the UncertainRangeFactory class for object creation.
        /// </summary>
        ///
        /// <param name="low">lower bound</param>
        /// <param name="high">upper bound</param>
        /// <param name="centre">middle bound</param>
        /// <param name="width">size of width</param>
        /// <param name="representation">the type of range</param>
        public UncertainRange(T low, T high, T centre, Diff<T> width, Representation representation)
            : this(low, high, centre, width, representation, null, null, null)
        {
        }

        /// <summary>
        /// Constructs an uncertain range.
        /// Recommended to use the UncertainRangeFactory class for object creation.
        /// </summary>
        ///
        /// <param name="low">lower bound</param>
        /// <param name="high">upper bound</param>
        /// <param name="centre">middle bound</param>
        /// <param name="width">size of width</param>
        /// <param name="representation">the type of range</param>
        /// <param name="lowInclusive">lowInclusive</param>
        /// <param name="highInclusive">highInclusive</param>
        public UncertainRange(T low, T high, T centre, Diff<T> width, Representation representation, Boolean? lowInclusive, Boolean? highInclusive)
            : this(low, high, centre, width, representation, null, null, null, lowInclusive, highInclusive)
        {
        }

        /// <summary>
        /// Constructs an uncertain range.
        /// Recommended to use the UncertainRangeFactory class for object creation.
        /// </summary>
        ///
        /// <param name="low">lower bound</param>
        /// <param name="high">upper bound</param>
        /// <param name="centre">middle bound</param>
        /// <param name="width">size of width</param>
        /// <param name="representation">the type of range</param>
        /// <param name="lowNullFLavor">lowNullFLavor</param>
        /// <param name="highNullFLavor">highNullFLavor</param>
        /// <param name="centreNullFLavor">centreNullFLavor</param>
        public UncertainRange(T low, T high, T centre, Diff<T> width, Representation representation, NullFlavor lowNullFlavor, NullFlavor highNullFlavor, NullFlavor centreNullFlavor)
            : this(low, high, centre, width, representation, lowNullFlavor, highNullFlavor, centreNullFlavor, null, null)
        {
        }

        /// <summary>
        /// Constructs an uncertain range.
        /// Recommended to use the UncertainRangeFactory class for object creation.
        /// </summary>
        ///
        /// <param name="low">lower bound</param>
        /// <param name="high">upper bound</param>
        /// <param name="centre">middle bound</param>
        /// <param name="width">size of width</param>
        /// <param name="representation">the type of range</param>
        /// <param name="lowNullFLavor">lowNullFLavor</param>
        /// <param name="highNullFLavor">highNullFLavor</param>
        /// <param name="centreNullFLavor">centreNullFLavor</param>
        /// <param name="lowInclusive">lowInclusive</param>
        /// <param name="highInclusive">highInclusive</param>
        public UncertainRange(T low, T high, T centre, Diff<T> width, Representation representation, NullFlavor lowNullFlavor, NullFlavor highNullFlavor, NullFlavor centreNullFlavor, Boolean? lowInclusive, Boolean? highInclusive)
            : base(low, high, centre, width, representation, lowNullFlavor, highNullFlavor, centreNullFlavor)
        {
            base.LowInclusive = lowInclusive;
            base.HighInclusive = highInclusive;
        }
    }
}
