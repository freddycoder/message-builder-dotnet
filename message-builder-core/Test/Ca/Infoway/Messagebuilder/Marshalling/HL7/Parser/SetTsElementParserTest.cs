using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class SetTsElementParserTest : ParserTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParse()
		{
			XmlNode node = CreateNode("<top>" + "<something value=\"20000407123059\" />" + "<something value=\"20020628010101\" />" +
				 "</top>");
			BareANY result = new SetElementParser(ParserRegistry.GetInstance()).Parse(ParseContextImpl.Create("SET<TS>", null, SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("1-5"), null, false), 
				AsList(node.ChildNodes), new XmlToModelResult());
			ICollection<PlatformDate> set = ((SET<TS, PlatformDate>)result).RawSet();
			Assert.IsNotNull(set, "null");
			Assert.AreEqual(2, set.Count, "size");
			PlatformDate expectedCalendar = DateUtil.GetDate(2000, 3, 7, 12, 30, 59, 0);
			Assert.IsTrue(set.Contains(expectedCalendar), "first date");
			expectedCalendar = DateUtil.GetDate(2002, 5, 28, 1, 1, 1, 0);
			Assert.IsTrue(set.Contains(expectedCalendar), "second date");
		}
	}
}
