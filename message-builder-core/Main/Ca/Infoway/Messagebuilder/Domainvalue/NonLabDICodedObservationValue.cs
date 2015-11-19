using Ca.Infoway.Messagebuilder.Domainvalue;

namespace Ca.Infoway.Messagebuilder.Domainvalue
{
	/// <summary>
	/// The non-laboratory, non-diagnostic imaging coded
	/// observation if no value is also required to convey the full
	/// meaning of the observation.
	/// </summary>
	/// <remarks>
	/// The non-laboratory, non-diagnostic imaging coded
	/// observation if no value is also required to convey the full
	/// meaning of the observation. When the Coded Observation Type
	/// represents only the observable, this represents the coded
	/// (non-numeric) result of that non-laboratory, non-diagnositic
	/// imaging coded observation. Examples of the former include
	/// "Decreased breath sounds", of the latter include an APGAR
	/// result, a functional assessment, etc. The value must not
	/// require a specific unit of measure.
	/// </remarks>
	public interface NonLabDICodedObservationValue : ObservationValue
	{
	}
}
