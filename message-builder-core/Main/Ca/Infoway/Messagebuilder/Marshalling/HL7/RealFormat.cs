namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	public interface RealFormat
	{
		int GetMaxDecimalPartLength();

		int GetMaxIntegerPartLength();

		int GetMaxValueLength();
	}
}
