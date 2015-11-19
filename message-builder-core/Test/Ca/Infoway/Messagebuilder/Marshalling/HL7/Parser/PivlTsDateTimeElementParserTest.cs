using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class PivlTsDateTimeElementParserTest : MarshallingTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParse()
		{
			XmlNode node = CreateNode("<periodicInterval><frequency><numerator value=\"3\"/><denominator value=\"1\" unit=\"d\"/></frequency></periodicInterval>"
				);
			PeriodicIntervalTime pivl = (PeriodicIntervalTime)new PivlTsDateTimeElementParser().Parse(CreateContext(), node, this.xmlResult
				).BareValue;
			Assert.IsNotNull(pivl, "null");
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(pivl.Operator);
			Assert.IsNull(pivl.Period);
			Assert.IsNull(pivl.Phase);
			Assert.IsNull(pivl.Value);
			Assert.AreEqual(Representation.FREQUENCY, pivl.Representation);
			Assert.AreEqual(new BigDecimal("1"), pivl.Quantity.Quantity, "qty");
			Assert.AreEqual("d", pivl.Quantity.Unit.CodeValue, "units");
			Assert.AreEqual((Int32?)3, pivl.Repetitions, "reps");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseFailsWithMissingElements()
		{
			XmlNode node = CreateNode("<periodicInterval><frequency></frequency></periodicInterval>");
			PeriodicIntervalTime pivl = (PeriodicIntervalTime)new PivlTsDateTimeElementParser().Parse(CreateContext(), node, this.xmlResult
				).BareValue;
			Assert.IsNull(pivl, "null");
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(2, this.xmlResult.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseFailsWithEmptyElements()
		{
			XmlNode node = CreateNode("<periodicInterval><frequency><numerator/><denominator/></frequency></periodicInterval>");
			PeriodicIntervalTime pivl = (PeriodicIntervalTime)new PivlTsDateTimeElementParser().Parse(CreateContext(), node, this.xmlResult
				).BareValue;
			Assert.IsNotNull(pivl, "null");
			Assert.IsNull(pivl.Repetitions);
			Assert.IsNull(pivl.Quantity);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(2, this.xmlResult.GetHl7Errors().Count);
		}

		private ParseContext CreateContext()
		{
			return ParseContextImpl.Create("PIVL<TS.DATETIME>", null, SpecificationVersion.R02_04_02, null, null, null, null, null, null
				, null, false);
		}
	}
}
