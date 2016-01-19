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


using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Domainvalue;

namespace Ca.Infoway.Messagebuilder.Datatype.Lang
{
	public class IntervalFactory
	{
		/// <summary>Constructs an Interval using the supplied parameters.</summary>
		/// <remarks>Constructs an Interval using the supplied parameters.</remarks>
		/// <TBD></TBD>
		/// <param name="low">the low bound</param>
		/// <param name="high">the high bound</param>
		/// <returns>the constructed interval</returns>
		public static Interval<T> CreateLowHigh<T>(T low, T high)
		{
			return IntervalFactory.CreateLowHigh(low, high, null, null);
		}

		/// <summary>Constructs an Interval using the supplied parameters.</summary>
		/// <remarks>Constructs an Interval using the supplied parameters.</remarks>
		/// <TBD></TBD>
		/// <param name="low">the low bound</param>
		/// <param name="high">the high bound</param>
		/// <param name="lowNullFlavor"></param>
		/// <param name="highNullFlavor"></param>
		/// <returns>the constructed interval</returns>
		public static Interval<T> CreateLowHigh<T>(T low, T high, NullFlavor lowNullFlavor, NullFlavor highNullFlavor)
		{
			bool hasNullFlavor = lowNullFlavor != null || highNullFlavor != null;
			T average = hasNullFlavor ? default(T) : GenericMath.Average(low, high);
			Diff<T> diff = hasNullFlavor ? null : GenericMath.Diff(low, high);
			return new Interval<T>(low, high, average, diff, Representation.LOW_HIGH, lowNullFlavor, highNullFlavor, null);
		}

		/// <summary>Constructs an Interval using the supplied parameters.</summary>
		/// <remarks>Constructs an Interval using the supplied parameters.</remarks>
		/// <TBD></TBD>
		/// <param name="low">the low bound</param>
		/// <param name="width">the width as a Diff object</param>
		/// <returns>the constructed interval</returns>
		public static Interval<T> CreateLowWidth<T>(T low, Diff<T> width)
		{
			return IntervalFactory.CreateLowWidth(low, width, null);
		}

		/// <summary>Constructs an Interval using the supplied parameters.</summary>
		/// <remarks>Constructs an Interval using the supplied parameters.</remarks>
		/// <TBD></TBD>
		/// <param name="low">the low bound</param>
		/// <param name="width">the width as a Diff object</param>
		/// <param name="lowNullFlavor"></param>
		/// <returns>the constructed interval</returns>
		public static Interval<T> CreateLowWidth<T>(T low, Diff<T> width, NullFlavor lowNullFlavor)
		{
			T high = GenericMath.Add(low, width);
			return new Interval<T>(low, high, GenericMath.Average(low, high), width, Representation.LOW_WIDTH, lowNullFlavor, null, null
				);
		}

		/// <summary>Constructs an Interval using the supplied parameters.</summary>
		/// <remarks>Constructs an Interval using the supplied parameters.</remarks>
		/// <TBD></TBD>
		/// <param name="width">the width as a Diff object</param>
		/// <param name="high">the high bound</param>
		/// <returns>the constructed interval</returns>
		public static Interval<T> CreateWidthHigh<T>(Diff<T> width, T high)
		{
			return IntervalFactory.CreateWidthHigh(width, high, null);
		}

		/// <summary>Constructs an Interval using the supplied parameters.</summary>
		/// <remarks>Constructs an Interval using the supplied parameters.</remarks>
		/// <TBD></TBD>
		/// <param name="width">the width as a Diff object</param>
		/// <param name="high">the high bound</param>
		/// <param name="highNullFlavor"></param>
		/// <returns>the constructed interval</returns>
		public static Interval<T> CreateWidthHigh<T>(Diff<T> width, T high, NullFlavor highNullFlavor)
		{
			bool widthNull = (width == (Diff<T>)null);
			Diff<T> tempDiff = GenericMath.Diff(widthNull ? default(T) : width.Value, high);
			bool tempDiffNull = (tempDiff == (Diff<T>)null);
			T low = tempDiffNull ? default(T) : tempDiff.Value;
			return new Interval<T>(low, high, GenericMath.Average(low, high), width, Representation.WIDTH_HIGH, null, highNullFlavor, 
				null);
		}

		/// <summary>Constructs an Interval using the supplied parameters.</summary>
		/// <remarks>Constructs an Interval using the supplied parameters.</remarks>
		/// <TBD></TBD>
		/// <param name="centre">the centre bound</param>
		/// <param name="width">the width as a Diff object</param>
		/// <returns>the constructed interval</returns>
		public static Interval<T> CreateCentreWidth<T>(T centre, Diff<T> width)
		{
			return IntervalFactory.CreateCentreWidth(centre, width, null);
		}

		/// <summary>Constructs an Interval using the supplied parameters.</summary>
		/// <remarks>Constructs an Interval using the supplied parameters.</remarks>
		/// <TBD></TBD>
		/// <param name="centre">the centre bound</param>
		/// <param name="width">the width as a Diff object</param>
		/// <param name="centreNullFlavor"></param>
		/// <returns>the constructed interval</returns>
		public static Interval<T> CreateCentreWidth<T>(T centre, Diff<T> width, NullFlavor centreNullFlavor)
		{
			bool widthNull = (width == (Diff<T>)null);
			T half = GenericMath.Half(widthNull ? default(T) : width.Value);
			Diff<T> tempDiff = GenericMath.Diff(half, centre);
			bool tempDiffNull = (tempDiff == (Diff<T>)null);
			T low = tempDiffNull ? default(T) : tempDiff.Value;
			T high = GenericMath.Add(low, width);
			return new Interval<T>(low, high, centre, width, Representation.CENTRE_WIDTH, null, null, centreNullFlavor);
		}

		/// <summary>Constructs an Interval using the supplied parameters.</summary>
		/// <remarks>Constructs an Interval using the supplied parameters.</remarks>
		/// <param name="low"></param>
		/// <param name="centre"></param>
		/// <returns>the constructed interval</returns>
		public static Interval<T> CreateLowCentre<T>(T low, T centre)
		{
			return IntervalFactory.CreateLowCentre(low, centre, null, null);
		}

		/// <summary>Constructs an Interval using the supplied parameters.</summary>
		/// <remarks>Constructs an Interval using the supplied parameters.</remarks>
		/// <param name="low"></param>
		/// <param name="centre"></param>
		/// <param name="lowNullFlavor"></param>
		/// <param name="centreNullFlavor"></param>
		/// <returns>the constructed interval</returns>
		public static Interval<T> CreateLowCentre<T>(T low, T centre, NullFlavor lowNullFlavor, NullFlavor centreNullFlavor)
		{
			Diff<T> tempDiff = GenericMath.Diff(low, centre);
			bool tempDiffNull = (tempDiff == (Diff<T>)null);
			T halfDiff = tempDiffNull ? default(T) : tempDiff.Value;
			T high = GenericMath.Add(centre, halfDiff);
			Diff<T> width = GenericMath.Diff(low, high);
			return new Interval<T>(low, high, centre, width, Representation.LOW_CENTER, lowNullFlavor, null, centreNullFlavor);
		}

		/// <summary>Constructs an Interval using the supplied parameters.</summary>
		/// <remarks>Constructs an Interval using the supplied parameters.</remarks>
		/// <param name="centre"></param>
		/// <param name="high"></param>
		/// <returns>the constructed interval</returns>
		public static Interval<T> CreateCentreHigh<T>(T centre, T high)
		{
			return IntervalFactory.CreateCentreHigh(centre, high, null, null);
		}

		/// <summary>Constructs an Interval using the supplied parameters.</summary>
		/// <remarks>Constructs an Interval using the supplied parameters.</remarks>
		/// <param name="centre"></param>
		/// <param name="high"></param>
		/// <param name="centreNullFlavor"></param>
		/// <param name="highNullFlavor"></param>
		/// <returns>the constructed interval</returns>
		public static Interval<T> CreateCentreHigh<T>(T centre, T high, NullFlavor centreNullFlavor, NullFlavor highNullFlavor)
		{
			Diff<T> tempDiff = GenericMath.Diff(centre, high);
			bool tempDiffNull = (tempDiff == (Diff<T>)null);
			T halfDiff = tempDiffNull ? default(T) : tempDiff.Value;
			Diff<T> tempDiff2 = GenericMath.Diff(halfDiff, centre);
			bool tempDiff2Null = (tempDiff2 == (Diff<T>)null);
			T low = tempDiff2Null ? default(T) : tempDiff2.Value;
			Diff<T> width = GenericMath.Diff(low, high);
			return new Interval<T>(low, high, centre, width, Representation.CENTRE_HIGH, null, highNullFlavor, centreNullFlavor);
		}

		/// <summary>Constructs an Interval using the supplied parameters.</summary>
		/// <remarks>Constructs an Interval using the supplied parameters.</remarks>
		/// <TBD></TBD>
		/// <param name="low">the low bound</param>
		/// <returns>the constructed interval</returns>
		public static Interval<T> CreateLow<T>(T low)
		{
			return IntervalFactory.CreateLow(low, null);
		}

		/// <summary>Constructs an Interval using the supplied parameters.</summary>
		/// <remarks>Constructs an Interval using the supplied parameters.</remarks>
		/// <TBD></TBD>
		/// <param name="low">the low bound</param>
		/// <param name="lowNullFlavor"></param>
		/// <returns>the constructed interval</returns>
		public static Interval<T> CreateLow<T>(T low, NullFlavor lowNullFlavor)
		{
			return new Interval<T>(low, default(T), default(T), null, Representation.LOW, lowNullFlavor, null, null);
		}

		/// <summary>Constructs an Interval using the supplied parameters.</summary>
		/// <remarks>Constructs an Interval using the supplied parameters.</remarks>
		/// <TBD></TBD>
		/// <param name="width">the width as a Diff object</param>
		/// <returns>the constructed interval</returns>
		public static Interval<T> CreateWidth<T>(Diff<T> width)
		{
			return new Interval<T>(default(T), default(T), default(T), width, Representation.WIDTH);
		}

		/// <summary>Constructs an Interval using the supplied parameters.</summary>
		/// <remarks>Constructs an Interval using the supplied parameters.</remarks>
		/// <TBD></TBD>
		/// <param name="high">the high bound</param>
		/// <returns>the constructed interval</returns>
		public static Interval<T> CreateHigh<T>(T high)
		{
			return IntervalFactory.CreateHigh(high, null);
		}

		/// <summary>Constructs an Interval using the supplied parameters.</summary>
		/// <remarks>Constructs an Interval using the supplied parameters.</remarks>
		/// <TBD></TBD>
		/// <param name="high">the high bound</param>
		/// <param name="highNullFlavor"></param>
		/// <returns>the constructed interval</returns>
		public static Interval<T> CreateHigh<T>(T high, NullFlavor highNullFlavor)
		{
			return new Interval<T>(default(T), high, default(T), null, Representation.HIGH, null, highNullFlavor, null);
		}

		/// <summary>Constructs an Interval using the supplied parameters.</summary>
		/// <remarks>Constructs an Interval using the supplied parameters.</remarks>
		/// <TBD></TBD>
		/// <param name="centre">the centre bound</param>
		/// <returns>the constructed interval</returns>
		public static Interval<T> CreateCentre<T>(T centre)
		{
			return IntervalFactory.CreateCentre(centre, null);
		}

		/// <summary>Constructs an Interval using the supplied parameters.</summary>
		/// <remarks>Constructs an Interval using the supplied parameters.</remarks>
		/// <TBD></TBD>
		/// <param name="centre">the centre bound</param>
		/// <param name="centreNullFlavor"></param>
		/// <returns>the constructed interval</returns>
		public static Interval<T> CreateCentre<T>(T centre, NullFlavor centreNullFlavor)
		{
			return new Interval<T>(default(T), default(T), centre, null, Representation.CENTRE, null, null, centreNullFlavor);
		}

		/// <summary>Constructs a simple interval based on a single value.</summary>
		/// <remarks>Constructs a simple interval based on a single value.</remarks>
		/// <TBD></TBD>
		/// <param name="value">the simple value for the Interval</param>
		/// <returns>the constructed Interval</returns>
		public static Interval<T> CreateSimple<T>(T value)
		{
			return new Interval<T>(value, null);
		}

		/// <summary>Constructs a simple interval based on a single value and an operator.</summary>
		/// <remarks>Constructs a simple interval based on a single value and an operator.</remarks>
		/// <TBD></TBD>
		/// <param name="value">the simple value for the Interval</param>
		/// <param name="operator">the operator for the Interval</param>
		/// <returns>the constructed Interval</returns>
		public static Interval<T> CreateSimple<T>(T value, SetOperator @operator)
		{
			return new Interval<T>(value, @operator);
		}

		/// <summary>Converts an UncertainRange into an Interval.</summary>
		/// <remarks>
		/// Converts an UncertainRange into an Interval.
		/// Note that the new Interval will lose any high/low inclusive data from the range.
		/// </remarks>
		/// <param name="the">uncertain range</param>
		/// <returns>an Interval that corresponds to the range</returns>
		public static Interval<T> CreateFromUncertainRange<T>(UncertainRange<T> urg)
		{
			return new Interval<T>(urg.Low, urg.High, urg.Centre, urg.Width, urg.Representation, urg.LowNullFlavor, urg.HighNullFlavor
				, urg.CentreNullFlavor);
		}

		public static Interval<MbDate> CreateMbDateInterval(Interval<PlatformDate> dateInterval)
		{
			MbDate low = Convert(dateInterval.Low);
			MbDate high = Convert(dateInterval.High);
			MbDate centre = Convert(dateInterval.Centre);
			Diff<MbDate> width = Convert(dateInterval.Width);
			return new Interval<MbDate>(low, high, centre, width, dateInterval.Representation, dateInterval.LowNullFlavor, dateInterval
				.HighNullFlavor, dateInterval.CentreNullFlavor, Convert(dateInterval.Value), dateInterval.Operator, dateInterval.LowInclusive
				, dateInterval.HighInclusive);
		}

		private static Diff<MbDate> Convert(Diff<PlatformDate> dateDiff)
		{
			if (dateDiff == null)
			{
				return null;
			}
			Diff<MbDate> mbDateDiff;
			if (dateDiff is DateDiff)
			{
				mbDateDiff = new MbDateDiff(Convert(dateDiff.Value), ((DateDiff)dateDiff).ValueAsPhysicalQuantity);
			}
			else
			{
				mbDateDiff = new Diff<MbDate>(Convert(dateDiff.Value));
			}
			if (dateDiff.HasNullFlavor())
			{
				mbDateDiff.NullFlavor = dateDiff.NullFlavor;
			}
			return mbDateDiff;
		}

		private static MbDate Convert(PlatformDate date)
		{
			return date == null ? null : new MbDate(date);
		}
	}
}
