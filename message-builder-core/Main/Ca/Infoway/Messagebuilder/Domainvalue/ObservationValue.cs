using Ca.Infoway.Messagebuilder;

namespace Ca.Infoway.Messagebuilder.Domainvalue
{
	/// <summary>
	/// This domain is the root domain to which all
	/// HL7-recognized value sets for the Observation.value
	/// attribute will be linked when Observation.value has a coded
	/// data type.
	/// </summary>
	/// <remarks>
	/// This domain is the root domain to which all
	/// HL7-recognized value sets for the Observation.value
	/// attribute will be linked when Observation.value has a coded
	/// data type.
	/// </remarks>
	public interface ObservationValue : Code
	{
	}
}
