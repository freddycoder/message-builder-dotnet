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
			Register(new BagPropertyFormatter(this));
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
			Register(new RealPropertyFormatter());
			Register(new RealConfPropertyFormatter());
			Register(new RealCoordPropertyFormatter());
			Register(new RtoMoPqPropertyFormatter());
			Register(new RtoPqPqPropertyFormatter());
			Register(new ScPropertyFormatter());
			Register(new SetPropertyFormatter(this));
			Register(new ListPropertyFormatter(this));
			Register(new StPropertyFormatter());
			Register(new TelPhonemailPropertyFormatter());
			Register(new TelUriPropertyFormatter());
			Register(new TnPropertyFormatter());
			Register(new TsFullDateWithTimePropertyFormatter());
			Register(new TsFullDatePropertyFormatter());
			Register(new TsFullDateTimePropertyFormatter());
			Register(new UrgPqPropertyFormatter());
			Register(new UrgTsPropertyFormatter());
			Register(new TsCdaPropertyFormatter());
			Register(new PivlTsCdaPropertyFormatter());
			Register(new IvlTsCdaPropertyFormatter());
		}
	}
}
