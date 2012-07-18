using Ca.Infoway.Messagebuilder.Marshalling.HL7;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	public class RealCoordFormat : RealFormat
	{
		public RealCoordFormat()
		{
		}

		public virtual int GetMaxDecimalPartLength()
		{
			return 4;
		}

		public virtual int GetMaxIntegerPartLength()
		{
			return 1;
		}

		public virtual int GetMaxValueLength()
		{
			return 6;
		}
	}
}
