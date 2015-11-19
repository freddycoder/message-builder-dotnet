using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Xml;
using ILOG.J2CsMapping.Collections.Generics;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class TsCdaElementParserTest : MarshallingTestCase
	{
		private TsCdaElementParser parser = new TsCdaElementParser();

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestTsCda()
		{
			PlatformDate expectedDate = DateUtil.GetDate(2012, 4, 3);
			XmlNode node = CreateNode("<date value=\"20120503\"/>");
			ParseContext context = ParseContextImpl.Create("TSCDAR1", null, SpecificationVersion.R02_04_03, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY, Cardinality.Create("1"), null, true);
			BareANY parseResult = this.parser.Parse(context, Arrays.AsList(node), this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsTrue(parseResult is TSCDAR1);
			Assert.IsTrue(parseResult.BareValue is MbDate);
			Assert.AreEqual(expectedDate, ((MbDate)parseResult.BareValue).Value);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestSxcmTs()
		{
			PlatformDate expectedDate = DateUtil.GetDate(2012, 4, 3);
			XmlNode node = CreateNode("<date operator=\"E\" value=\"20120503\"/>");
			ParseContext context = ParseContextImpl.Create("SXCMTSCDAR1", null, SpecificationVersion.R02_04_03, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY, Cardinality.Create("1"), null, true);
			BareANY parseResult = this.parser.Parse(context, Arrays.AsList(node), this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsTrue(parseResult is SXCMTSCDAR1);
			Assert.IsTrue(parseResult.BareValue is MbDate);
			Assert.AreEqual(expectedDate, ((MbDate)parseResult.BareValue).Value);
		}
	}
}
