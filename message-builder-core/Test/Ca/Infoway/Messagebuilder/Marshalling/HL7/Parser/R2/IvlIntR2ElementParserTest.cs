using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using ILOG.J2CsMapping.Collections.Generics;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[TestFixture]
	public class IvlIntR2ElementParserTest : CeRxDomainValueTestCase
	{
		private XmlToModelResult result;

		private ElementParser parser;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public override void SetUp()
		{
			base.SetUp();
			this.result = new XmlToModelResult();
			this.parser = new IvlIntR2ElementParser();
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private Interval<Int32?> Parse(XmlNode node)
		{
			BareANY ivl = this.parser.Parse(ParseContextImpl.Create("IVL<INT>", typeof(Interval<object>), SpecificationVersion.V02R02
				, null, null, null, null, null, false), Arrays.AsList(node), this.result);
			return (Interval<Int32?>)(ivl.BareValue);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseSimpleWithOperator()
		{
			XmlNode node = CreateNode("<range operator=\"A\" value=\"221\" />");
			Interval<Int32?> interval = Parse(node);
			Assert.IsTrue(this.result.IsValid());
			Assert.IsNotNull(interval, "null");
			Assert.AreEqual(221, interval.Value);
			Assert.AreEqual(SetOperator.INTERSECT, interval.Operator);
			Assert.AreEqual(Representation.SIMPLE, interval.Representation, "representation");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseSimpleWithDefaultOperator()
		{
			XmlNode node = CreateNode("<range value=\"221\" />");
			Interval<Int32?> interval = Parse(node);
			Assert.IsTrue(this.result.IsValid());
			Assert.IsNotNull(interval, "null");
			Assert.AreEqual(221, interval.Value);
			Assert.AreEqual(SetOperator.INCLUDE, interval.Operator);
			Assert.AreEqual(Representation.SIMPLE, interval.Representation, "representation");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseLowHighWithInclusive()
		{
			XmlNode node = CreateNode("<range><low inclusive=\"false\" value=\"123\" /><high value=\"567\" inclusive=\"false\" /></range>"
				);
			Interval<Int32?> interval = Parse(node);
			Assert.IsTrue(this.result.IsValid());
			Assert.IsNotNull(interval, "null");
			Assert.AreEqual(123, interval.Low, "low");
			Assert.AreEqual(false, interval.LowInclusive, "low incl");
			Assert.AreEqual(567, interval.High, "high");
			Assert.AreEqual(false, interval.HighInclusive, "high incl");
			Assert.AreEqual(345, interval.Centre, "centre");
			Assert.AreEqual(567 - 123, interval.Width.Value, "width");
			Assert.AreEqual(Representation.LOW_HIGH, interval.Representation, "representation");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseLowHighWithBadInclusive()
		{
			XmlNode node = CreateNode("<range><low inclusive=\"xyz\" value=\"123\" /><high value=\"567\" inclusive=\"true\" /></range>"
				);
			Interval<Int32?> interval = Parse(node);
			Assert.IsTrue(this.result.IsValid());
			Assert.IsNotNull(interval, "null");
			Assert.AreEqual(123, interval.Low, "low");
			Assert.AreEqual(false, interval.LowInclusive, "low incl");
			Assert.AreEqual(567, interval.High, "high");
			Assert.AreEqual(true, interval.HighInclusive, "high incl");
			Assert.AreEqual(345, interval.Centre, "centre");
			Assert.AreEqual(567 - 123, interval.Width.Value, "width");
			Assert.AreEqual(Representation.LOW_HIGH, interval.Representation, "representation");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseLowHighWithoutInclusive()
		{
			XmlNode node = CreateNode("<range><low value=\"123\" /><high value=\"567\" /></range>");
			Interval<Int32?> interval = Parse(node);
			Assert.IsTrue(this.result.IsValid());
			Assert.IsNotNull(interval, "null");
			Assert.AreEqual(123, interval.Low, "low");
			Assert.AreEqual(true, interval.LowInclusive, "low incl");
			Assert.AreEqual(567, interval.High, "high");
			Assert.AreEqual(true, interval.HighInclusive, "high incl");
			Assert.AreEqual(345, interval.Centre, "centre");
			Assert.AreEqual(567 - 123, interval.Width.Value, "width");
			Assert.AreEqual(Representation.LOW_HIGH, interval.Representation, "representation");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseCentreWidth()
		{
			XmlNode node = CreateNode("<range><center value=\"15\" /><width value=\"10\" /></range>");
			Interval<Int32?> interval = Parse(node);
			Assert.IsTrue(this.result.IsValid());
			Assert.IsNotNull(interval, "null");
			Assert.AreEqual(10, interval.Low, "low");
			Assert.AreEqual(20, interval.High, "high");
			Assert.AreEqual(15, interval.Centre, "centre");
			Assert.AreEqual(10, interval.Width.Value, "width");
			Assert.AreEqual(Representation.CENTRE_WIDTH, interval.Representation, "representation");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseCentreWidthWithRounding()
		{
			XmlNode node = CreateNode("<range><center value=\"15\" /><width value=\"9\" /></range>");
			Interval<Int32?> interval = Parse(node);
			Assert.IsTrue(this.result.IsValid());
			Assert.IsNotNull(interval, "null");
			Assert.AreEqual(11, interval.Low, "low");
			Assert.AreEqual(20, interval.High, "high");
			Assert.AreEqual(15, interval.Centre, "centre");
			Assert.AreEqual(9, interval.Width.Value, "width");
			Assert.AreEqual(Representation.CENTRE_WIDTH, interval.Representation, "representation");
		}
	}
}
