using Ca.Infoway.Messagebuilder.Domainvalue;

namespace Ca.Infoway.Messagebuilder.Domainvalue
{
	/// <summary>
	/// Identifies the type for a non-lab measured observation
	/// with values requiring a specific unit of measure.
	/// </summary>
	/// <remarks>
	/// Identifies the type for a non-lab measured observation
	/// with values requiring a specific unit of measure. E.g.pulse
	/// rate, angle of range of motion, blood pressure, etc.
	/// </remarks>
	public interface NonLabDIMeasuredObservationType : NonLabDIObservationType
	{
	}
}
