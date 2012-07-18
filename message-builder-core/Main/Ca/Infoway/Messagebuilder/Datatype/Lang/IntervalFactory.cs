using Ca.Infoway.Messagebuilder.Datatype.Lang;

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
			return new Interval<T>(low, high, GenericMath.Average(low, high), GenericMath.Diff(low, high), Representation.LOW_HIGH);
		}

		/// <summary>Constructs an Interval using the supplied parameters.</summary>
		/// <remarks>Constructs an Interval using the supplied parameters.</remarks>
		/// <TBD></TBD>
		/// <param name="low">the low bound</param>
		/// <param name="width">the width as a Diff object</param>
		/// <returns>the constructed interval</returns>
		public static Interval<T> CreateLowWidth<T>(T low, Diff<T> width)
		{
			T high = GenericMath.Add(low, width);
			return new Interval<T>(low, high, GenericMath.Average(low, high), width, Representation.LOW_WIDTH);
		}

		/// <summary>Constructs an Interval using the supplied parameters.</summary>
		/// <remarks>Constructs an Interval using the supplied parameters.</remarks>
		/// <TBD></TBD>
		/// <param name="width">the width as a Diff object</param>
		/// <param name="high">the high bound</param>
		/// <returns>the constructed interval</returns>
		public static Interval<T> CreateWidthHigh<T>(Diff<T> width, T high)
		{
			T low = GenericMath.Diff(width.Value, high).Value;
			return new Interval<T>(low, high, GenericMath.Average(low, high), width, Representation.WIDTH_HIGH);
		}

		/// <summary>Constructs an Interval using the supplied parameters.</summary>
		/// <remarks>Constructs an Interval using the supplied parameters.</remarks>
		/// <TBD></TBD>
		/// <param name="centre">the centre bound</param>
		/// <param name="width">the width as a Diff object</param>
		/// <returns>the constructed interval</returns>
		public static Interval<T> CreateCentreWidth<T>(T centre, Diff<T> width)
		{
			T half = GenericMath.Half(width.Value);
			T low = GenericMath.Diff(half, centre).Value;
			T high = GenericMath.Add(low, width);
			return new Interval<T>(low, high, centre, width, Representation.CENTRE_WIDTH);
		}

		/// <summary>Constructs an Interval using the supplied parameters.</summary>
		/// <remarks>Constructs an Interval using the supplied parameters.</remarks>
		/// <TBD></TBD>
		/// <param name="low">the low bound</param>
		/// <returns>the constructed interval</returns>
		public static Interval<T> CreateLow<T>(T low)
		{
			return new Interval<T>(low, default(T), default(T), null, Representation.LOW);
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
			return new Interval<T>(default(T), high, default(T), null, Representation.HIGH);
		}

		/// <summary>Constructs an Interval using the supplied parameters.</summary>
		/// <remarks>Constructs an Interval using the supplied parameters.</remarks>
		/// <TBD></TBD>
		/// <param name="centre">the centre bound</param>
		/// <returns>the constructed interval</returns>
		public static Interval<T> CreateCentre<T>(T centre)
		{
			return new Interval<T>(default(T), default(T), centre, null, Representation.CENTRE);
		}

		/// <summary>Constructs a simple interval based on a single value.</summary>
		/// <remarks>Constructs a simple interval based on a single value.</remarks>
		/// <TBD></TBD>
		/// <param name="value">the simple value for the Interval</param>
		/// <returns>the constructed Interval</returns>
		public static Interval<T> CreateSimple<T>(T value)
		{
			return new Interval<T>(value);
		}
	}
}
