using Ca.Infoway.Messagebuilder;
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
			Register(new BagElementParser());
			Register(new BlElementParser());
			Register(new CsElementParser());
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
			Register(new ListElementParser());
			Register(new SetElementParser());
			Register(new MoElementParser());
			Register(new OnElementParser());
			Register(new PnElementParser());
			Register(new PqElementParser());
			Register(new RealElementParser());
			Register(new RtoQtyQtyElementParser());
			Register(new RtoPqPqElementParser());
			Register(new ScElementParser<Code>());
			Register(new StElementParser());
			Register(new TelElementParser());
			Register(new TnElementParser());
			Register(new TsElementParser());
			Register(new UrgPqElementParser());
		}

		public static Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.ParserRegistry GetInstance()
		{
			return instance;
		}
	}
}
