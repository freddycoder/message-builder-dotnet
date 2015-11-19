using Ca.Infoway.Messagebuilder.Domainvalue;

namespace Ca.Infoway.Messagebuilder.Domainvalue
{
	/// <summary>
	/// An interpretation of an observation to indicate whether
	/// the result is considered normal or abnormal.
	/// </summary>
	/// <remarks>
	/// An interpretation of an observation to indicate whether
	/// the result is considered normal or abnormal. E.g. Abnormal,
	/// Low, High alert. Concepts in this category are mutually
	/// exclusive, i.e., at most one is allowed.
	/// </remarks>
	public interface ObservationInterpretationNormality : ObservationInterpretation
	{
	}
}
