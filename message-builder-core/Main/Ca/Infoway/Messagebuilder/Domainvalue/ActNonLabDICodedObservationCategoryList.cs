using Ca.Infoway.Messagebuilder.Domainvalue;

namespace Ca.Infoway.Messagebuilder.Domainvalue
{
	/// <summary>
	/// Provides high-level categorizations for clinical
	/// non-laboratory and non-DI coded observations that do not
	/// require numeric values with a specific unit of measure.
	/// </summary>
	/// <remarks>
	/// Provides high-level categorizations for clinical
	/// non-laboratory and non-DI coded observations that do not
	/// require numeric values with a specific unit of measure. For
	/// example, "Test Scores", "Signs", "Coded Physiological
	/// Characteristics", etc.
	/// </remarks>
	public interface ActNonLabDICodedObservationCategoryList : ActNonLabDIObservationCategoryList
	{
	}
}
