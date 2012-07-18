using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class SetRtoPqPqElementParserTest : ParserTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParse()
		{
			XmlNode node = CreateNode("<top>" + "<something>" + "<numerator unit=\"mg\" value=\"1000\" />" + "<denominator unit=\"d\" value=\"1\" />"
				 + "</something>" + "<something>" + "<numerator unit=\"mg\" value=\"1001\"	/>" + "<denominator unit=\"d\" value=\"2\" />"
				 + "</something>" + "</top>");
			BareANY result = new SetElementParser().Parse(ParserContextImpl.Create("SET<RTO<PQ.DRUG,PQ.TIME>>", null, SpecificationVersion
				.V01R04_2_SK, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY), AsList(node.ChildNodes), null);
			ICollection<Ratio<PhysicalQuantity, PhysicalQuantity>> set = ((SET<RTO<PhysicalQuantity, PhysicalQuantity>, Ratio<PhysicalQuantity
				, PhysicalQuantity>>)result).RawSet();
			Assert.IsNotNull(set, "null");
			Assert.AreEqual(2, set.Count, "size");
			bool foundFirst = false;
			bool foundSecond = false;
			foreach (Ratio<PhysicalQuantity, PhysicalQuantity> ratio in set)
			{
				if (ratio.Numerator.Quantity.Value == 1000 && ratio.Denominator.Quantity.Value == 1)
				{
					foundFirst = true;
				}
				else
				{
					if (ratio.Numerator.Quantity.Value == 1001 && ratio.Denominator.Quantity.Value == 2)
					{
						foundSecond = true;
					}
				}
			}
			Assert.IsTrue(foundFirst);
			Assert.IsTrue(foundSecond);
		}
	}
}
