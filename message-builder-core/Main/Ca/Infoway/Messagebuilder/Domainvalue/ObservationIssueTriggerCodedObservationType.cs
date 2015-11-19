using Ca.Infoway.Messagebuilder.Domainvalue;

namespace Ca.Infoway.Messagebuilder.Domainvalue
{
	/// <summary>
	/// Distinguishes the kinds of coded observations that could
	/// be the trigger for clinical issue detection.
	/// </summary>
	/// <remarks>
	/// Distinguishes the kinds of coded observations that could
	/// be the trigger for clinical issue detection. These are
	/// observations that are not measurable, but instead can be
	/// defined with codes. Coded observation types include:
	/// Allergy, Intolerance, Medical Condition, Pregnancy ststus,
	/// etc.
	/// </remarks>
	public interface ObservationIssueTriggerCodedObservationType : ObservationType
	{
	}
}
