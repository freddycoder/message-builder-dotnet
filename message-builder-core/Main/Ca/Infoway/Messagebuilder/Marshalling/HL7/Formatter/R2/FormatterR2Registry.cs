using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	public class FormatterR2Registry : Registry<PropertyFormatter>
	{
		private static Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2.FormatterR2Registry instance = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2.FormatterR2Registry
			();

		public static Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2.FormatterR2Registry GetInstance()
		{
			return instance;
		}

		private FormatterR2Registry()
		{
		}

		protected override void RegisterAll()
		{
			Register(new AdR2PropertyFormatter());
			Register(new AnyR2PropertyFormatter());
			Register(new BlR2PropertyFormatter());
			Register(new BagR2PropertyFormatter(this));
			Register(new BxitCdR2PropertyFormatter());
			Register(new CdR2PropertyFormatter());
			Register(new CeR2PropertyFormatter());
			Register(new CrR2PropertyFormatter());
			Register(new CsR2PropertyFormatter());
			Register(new CvR2PropertyFormatter());
			Register(new EdPropertyFormatter(new TelR2PropertyFormatter(), true));
			Register(new EivlTsR2PropertyFormatter());
			Register(new EnR2PropertyFormatter());
			Register(new HxitCeR2PropertyFormatter());
			Register(new IiR2PropertyFormatter());
			Register(new IntR2PropertyFormatter());
			Register(new IvlIntR2PropertyFormatter());
			Register(new IvlMoR2PropertyFormatter());
			Register(new IvlPqR2PropertyFormatter());
			Register(new IvlRealR2PropertyFormatter());
			Register(new IvlTsR2PropertyFormatter());
			Register(new ListR2PropertyFormatter(this));
			Register(new MoR2PropertyFormatter());
			Register(new PivlTsR2PropertyFormatter());
			Register(new PqR2PropertyFormatter());
			Register(new PqrR2PropertyFormatter());
			Register(new RealR2PropertyFormatter());
			Register(new RtoMoPqR2PropertyFormatter());
			Register(new RtoPqPqR2PropertyFormatter());
			Register(new ScR2PropertyFormatter());
			Register(new SetR2PropertyFormatter(this));
			Register(new StR2PropertyFormatter());
			Register(new SxcmCdR2PropertyFormatter());
			Register(new TelR2PropertyFormatter());
			Register(new TsR2PropertyFormatter());
		}
	}
}
