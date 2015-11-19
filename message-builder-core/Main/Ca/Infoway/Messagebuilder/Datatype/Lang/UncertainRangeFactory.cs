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
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;

namespace Ca.Infoway.Messagebuilder.Datatype.Lang
{
	public class UncertainRangeFactory
	{
		/// <summary>Constructs an uncertain range (low/high).</summary>
		/// <remarks>Constructs an uncertain range (low/high).</remarks>
		/// <TBD></TBD>
		/// <param name="low">lower bound</param>
		/// <param name="high">upper bound</param>
		/// <returns>the constructed uncertain range</returns>
		public static UncertainRange<T> CreateLowHigh<T>(T low, T high)
		{
			return new UncertainRange<T>(low, high, GenericMath.Average(low, high), GenericMath.Diff(low, high), Representation.LOW_HIGH
				);
		}

		/// <summary>Constructs an uncertain range (low/width).</summary>
		/// <remarks>Constructs an uncertain range (low/width).</remarks>
		/// <TBD></TBD>
		/// <param name="low">lower bound</param>
		/// <param name="width">size of width</param>
		/// <returns>the constructed uncertain range</returns>
		public static UncertainRange<T> CreateLowWidth<T>(T low, Diff<T> width)
		{
			T high = GenericMath.Add(low, width);
			return new UncertainRange<T>(low, high, GenericMath.Average(low, high), width, Representation.LOW_WIDTH);
		}

		/// <summary>Constructs an uncertain range (width/high).</summary>
		/// <remarks>Constructs an uncertain range (width/high).</remarks>
		/// <TBD></TBD>
		/// <param name="width">size of width</param>
		/// <param name="high">higher bound</param>
		/// <returns>the constructed uncertain range</returns>
		public static UncertainRange<T> CreateWidthHigh<T>(Diff<T> width, T high)
		{
			T low = GenericMath.Diff(width.Value, high).Value;
			return new UncertainRange<T>(low, high, GenericMath.Average(low, high), width, Representation.WIDTH_HIGH);
		}

		/// <summary>Constructs an uncertain range (centre/width).</summary>
		/// <remarks>Constructs an uncertain range (centre/width).</remarks>
		/// <TBD></TBD>
		/// <param name="centre">centre bound</param>
		/// <param name="width">size of width</param>
		/// <returns>the constructed uncertain range</returns>
		public static UncertainRange<T> CreateCentreWidth<T>(T centre, Diff<T> width)
		{
			T half = GenericMath.Half(width.Value);
			T low = GenericMath.Diff(half, centre).Value;
			T high = GenericMath.Add(low, width);
			return new UncertainRange<T>(low, high, centre, width, Representation.CENTRE_WIDTH);
		}

		/// <summary>Constructs an uncertain range (centre/high).</summary>
		/// <remarks>Constructs an uncertain range (centre/high).</remarks>
		/// <TBD></TBD>
		/// <param name="center">center bound</param>
		/// <param name="high">higher bound</param>
		/// <returns>the constructed uncertain range</returns>
		public static UncertainRange<T> CreateCentreHigh<T>(T center, T high)
		{
			T half = GenericMath.Diff(center, high).Value;
			T low = GenericMath.Diff(half, center).Value;
			return new UncertainRange<T>(low, high, center, GenericMath.Diff(low, high), Representation.CENTRE_HIGH);
		}

		/// <summary>Constructs an uncertain range (low).</summary>
		/// <remarks>Constructs an uncertain range (low).</remarks>
		/// <TBD></TBD>
		/// <param name="low">lower bound</param>
		/// <returns>the constructed uncertain range</returns>
		public static UncertainRange<T> CreateLow<T>(T low)
		{
			return new UncertainRange<T>(low, default(T), default(T), null, Representation.LOW);
		}

		/// <summary>Constructs an uncertain range (low/centre).</summary>
		/// <remarks>Constructs an uncertain range (low/centre).</remarks>
		/// <TBD></TBD>
		/// <param name="low">lower bound</param>
		/// <param name="center">center bound</param>
		/// <returns>the constructed uncertain range</returns>
		public static UncertainRange<T> CreateLowCenter<T>(T low, T center)
		{
			return new UncertainRange<T>(low, default(T), center, null, Representation.LOW_CENTER);
		}

		/// <summary>Constructs an uncertain range (width).</summary>
		/// <remarks>Constructs an uncertain range (width).</remarks>
		/// <TBD></TBD>
		/// <param name="diff">the width diff</param>
		/// <returns>the constructed uncertain range</returns>
		public static UncertainRange<T> CreateWidth<T>(Diff<T> diff)
		{
			return new UncertainRange<T>(default(T), default(T), default(T), diff, Representation.WIDTH);
		}

		/// <summary>Constructs an uncertain range (high).</summary>
		/// <remarks>Constructs an uncertain range (high).</remarks>
		/// <TBD></TBD>
		/// <param name="high">higher bound</param>
		/// <returns>the constructed uncertain range</returns>
		public static UncertainRange<T> CreateHigh<T>(T high)
		{
			return new UncertainRange<T>(default(T), high, default(T), null, Representation.HIGH);
		}

		/// <summary>Constructs an uncertain range (centre).</summary>
		/// <remarks>Constructs an uncertain range (centre).</remarks>
		/// <TBD></TBD>
		/// <param name="centre">centre bound</param>
		/// <returns>the constructed uncertain range</returns>
		public static UncertainRange<T> CreateCentre<T>(T centre)
		{
			return new UncertainRange<T>(default(T), default(T), centre, null, Representation.CENTRE);
		}
	}
}
