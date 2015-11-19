namespace Ca.Infoway.Messagebuilder.Datatype.Lang
{
	/// <summary>.NET base class.</summary>
	/// <remarks>
	/// .NET base class.
	/// Used to hold a difference value of a given type.
	/// </remarks>
	/// <author>Intelliware Development</author>
	public interface BareRatio
	{
		/// <summary>Returns the denominator.</summary>
		/// <remarks>Returns the denominator.</remarks>
		/// <returns>the denominator</returns>
		object BareDenominator
		{
			get;
		}

		/// <summary>Returns the numerator.</summary>
		/// <remarks>Returns the numerator.</remarks>
		/// <returns>the numerator</returns>
		object BareNumerator
		{
			get;
		}
	}
}
