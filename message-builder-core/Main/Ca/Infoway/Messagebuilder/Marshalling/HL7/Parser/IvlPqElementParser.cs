using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[DataTypeHandler("IVL<PQ>")]
	internal class IvlPqElementParser : IvlElementParser<PhysicalQuantity>
	{
		public IvlPqElementParser() : this(false)
		{
		}

		public IvlPqElementParser(bool isUncertainRange) : base(isUncertainRange)
		{
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new IVLImpl<PQ, Interval<PhysicalQuantity>>();
		}
	}
}
