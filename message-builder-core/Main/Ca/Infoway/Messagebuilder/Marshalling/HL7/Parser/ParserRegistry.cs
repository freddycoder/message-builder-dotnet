using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	public class ParserRegistry : Registry<ElementParser>
	{
		private static Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.ParserRegistry instance = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.ParserRegistry
			();

		private ParserRegistry()
		{
		}

		protected override void RegisterAll()
		{
			Register(new AdElementParser());
			Register(new AnyElementParser());
			Register(new BagElementParser(this));
			Register(new BlElementParser());
			Register(new CvElementParser());
			Register(new EdElementParser());
			Register(new EdSignatureElementParser());
			Register(new EnElementParser());
			Register(new IiElementParser());
			Register(new IntElementParser());
			Register(new GtsBoundedPivlElementParser());
			Register(new PivlTsElementParser());
			Register(new PivlTsDateTimeElementParser());
			Register(new IvlIntElementParser());
			Register(new IvlPqElementParser());
			Register(new IvlTsElementParser());
			Register(new ListElementParser(this));
			Register(new SetElementParser(this));
			Register(new MoElementParser());
			Register(new OnElementParser());
			Register(new PnElementParser());
			Register(new PqElementParser());
			Register(new RealElementParser());
			Register(new RtoPqPqElementParser());
			Register(new RtoMoPqElementParser());
			Register(new ScElementParser());
			Register(new StElementParser());
			Register(new TelElementParser());
			Register(new TnElementParser());
			Register(new TsElementParser());
			Register(new UrgPqElementParser());
			Register(new UrgTsElementParser());
			Register(new TsCdaElementParser());
			Register(new PivlTsCdaElementParser());
			Register(new IvlTsCdaElementParser());
		}

		public static Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.ParserRegistry GetInstance()
		{
			return instance;
		}
	}
}
