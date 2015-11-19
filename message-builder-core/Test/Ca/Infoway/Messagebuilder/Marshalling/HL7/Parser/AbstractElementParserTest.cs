using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class AbstractElementParserTest
	{
		[Test]
		public virtual void ShouldConvertSpecializationType()
		{
			AbstractElementParser parser = new _AbstractElementParser_39();
			Assert.AreEqual("ST", parser.ConvertSpecializationType("ST"));
			Assert.AreEqual("ST", parser.ConvertSpecializationType("ST.CA"));
			Assert.AreEqual("ST.LANG", parser.ConvertSpecializationType("ST.LANG"));
			Assert.AreEqual("LIST<ST>", parser.ConvertSpecializationType("LIST_ST.CA"));
			Assert.AreEqual("CV", parser.ConvertSpecializationType("CV"));
			Assert.AreEqual("CV", parser.ConvertSpecializationType("CV.CA"));
			Assert.AreEqual("RTO<PQ,PQ>", parser.ConvertSpecializationType("RTO_PQ_PQ"));
			Assert.AreEqual("RTO<PQ,PQ>", parser.ConvertSpecializationType("RTO_PQ.CA_PQ.CA"));
			Assert.AreEqual("SET<RTO<PQ,PQ>>", parser.ConvertSpecializationType("SET_RTO_PQ_PQ"));
			Assert.AreEqual("LIST<RTO<PQ,PQ>>", parser.ConvertSpecializationType("LIST_RTO_PQ_PQ"));
			Assert.AreEqual("RTO<MO,PQ>", parser.ConvertSpecializationType("RTO_MO_PQ"));
			Assert.AreEqual("II.PUBLIC", parser.ConvertSpecializationType("II.PUBLIC"));
			Assert.AreEqual("CV", parser.ConvertSpecializationType("cv.ca"));
			Assert.AreEqual("RTO<PQ,PQ>", parser.ConvertSpecializationType("rto_pq_pq"));
		}

		private sealed class _AbstractElementParser_39 : AbstractElementParser
		{
			public _AbstractElementParser_39()
			{
			}

			/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
			public override BareANY Parse(ParseContext context, IList<XmlNode> node, XmlToModelResult xmlToModelResult)
			{
				return null;
			}
		}
	}
}
