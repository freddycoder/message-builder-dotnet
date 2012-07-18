using Ca.Infoway.Messagebuilder.Domainvalue;

namespace Ca.Infoway.Messagebuilder.Domainvalue
{
	/// <summary>
	/// Distinguishes between the kinds of measurable
	/// observations that could be the trigger for clinical issue
	/// detection.
	/// </summary>
	/// <remarks>
	/// Distinguishes between the kinds of measurable
	/// observations that could be the trigger for clinical issue
	/// detection. Measurable observation types include: Lab
	/// Results, Height, Weight.
	/// </remarks>
	public interface ObservationIssueTriggerMeasuredObservationType : ObservationType
	{
	}
}
