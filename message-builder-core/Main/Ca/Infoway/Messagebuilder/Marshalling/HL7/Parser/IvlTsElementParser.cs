using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[DataTypeHandler("IVL<TS>")]
	internal class IvlTsElementParser : IvlElementParser<PlatformDate>
	{
		public IvlTsElementParser() : this(false)
		{
		}

		public IvlTsElementParser(bool isUncertainRange) : base(isUncertainRange)
		{
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new IVLImpl<TS, Interval<PlatformDate>>();
		}
	}
}
