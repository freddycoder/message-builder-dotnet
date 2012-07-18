using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	public class FormatterRegistry : Registry<PropertyFormatter>
	{
		private static Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatterRegistry instance = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatterRegistry
			();

		public static Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatterRegistry GetInstance()
		{
			return instance;
		}

		private FormatterRegistry()
		{
		}

		protected override void RegisterAll()
		{
			Register(new AdBasicPropertyFormatter());
			Register(new AdPropertyFormatter());
			Register(new AnyPropertyFormatter());
			Register(new BagPropertyFormatter());
			Register(new BlPropertyFormatter());
			Register(new GtsBoundedPivlFormatter());
			Register(new CdPropertyFormatter());
			Register(new CsPropertyFormatter());
			Register(new CvPropertyFormatter());
			Register(new EdPropertyFormatter());
			Register(new EdSignaturePropertyFormatter());
			Register(new EnPropertyFormatter());
			Register(new IiPropertyFormatter());
			Register(new IntPropertyFormatter());
			Register(new IntNonNegPropertyFormatter());
			Register(new IntPosPropertyFormatter());
			Register(new IvlIntPropertyFormatter());
			Register(new IvlPqPropertyFormatter());
			Register(new IvlTsPropertyFormatter());
			Register(new PivlTsPropertyFormatter());
			Register(new MoPropertyFormatter());
			Register(new OnPropertyFormatter());
			Register(new PnPropertyFormatter());
			Register(new PqPropertyFormatter());
			Register(new PqBasicPropertyFormatter());
			Register(new PqDrugPropertyFormatter());
			Register(new PqHeightWeightPropertyFormatter());
			Register(new RealConfPropertyFormatter());
			Register(new RealCoordPropertyFormatter());
			Register(new RtoQtyQtyPropertyFormatter());
			Register(new RtoPqPqPropertyFormatter());
			Register(new ScPropertyFormatter());
			Register(new SetPropertyFormatter());
			Register(new ListPropertyFormatter());
			Register(new StPropertyFormatter());
			RegisterTelPhonemailFormatter();
			RegisterTelUriFormatter();
			Register(new TnPropertyFormatter());
			Register(new TsFullDatePropertyFormatter());
			Register(new TsFullDateTimePropertyFormatter());
			Register(new UrgPqPropertyFormatter());
		}

		private void RegisterTelPhonemailFormatter()
		{
			if (IsLenientFormatting())
			{
				Register(new LenientTelPhonemailPropertyFormatter());
			}
			else
			{
				Register(new TelPhonemailPropertyFormatter());
			}
		}

		private void RegisterTelUriFormatter()
		{
			if (IsLenientFormatting())
			{
				Register(new LenientTelUriPropertyFormatter());
			}
			else
			{
				Register(new TelUriPropertyFormatter());
			}
		}

		private bool IsLenientFormatting()
		{
			return true;
		}
		//BooleanUtils.toBoolean(System.getProperty("lenientCeRxFormatter", "true"))
	}
}
