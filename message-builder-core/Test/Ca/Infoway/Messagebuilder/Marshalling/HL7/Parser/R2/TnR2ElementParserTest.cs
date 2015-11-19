using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[TestFixture]
	public class TnR2ElementParserTest : CeRxDomainValueTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			TN tn = (TN)new TnR2ElementParser().Parse(CreateContext(), node, null);
			Assert.IsNull(tn.Value, "null returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, tn.NullFlavor, "null flavor");
		}

		private ParseContext CreateContext()
		{
			return ParseContextImpl.Create("TN", typeof(TrivialName), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			TrivialName result = (TrivialName)new TnR2ElementParser().Parse(null, node, null).BareValue;
			Assert.IsNotNull(result, "empty node");
			Assert.IsNull(result.Name, "empty node value");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTextNode()
		{
			XmlNode node = CreateNode("<something>text value</something>");
			TrivialName result = (TrivialName)new TnR2ElementParser().Parse(null, node, null).BareValue;
			Assert.AreEqual("text value", result.Name, "proper text returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTextNodeWithAttributes()
		{
			XmlNode node = CreateNode("<something representation=\"TXT\" mediaType=\"text/plain\">text value</something>");
			TrivialName result = (TrivialName)new TnR2ElementParser().Parse(null, node, null).BareValue;
			Assert.AreEqual("text value", result.Name, "proper text returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTooManyChildNodes()
		{
			XmlNode node = CreateNode("<something>" + "<monkey/>" + "<shines/>" + "</something>");
			new TnR2ElementParser().Parse(CreateContext(), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(2, this.xmlResult.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNotATextNode()
		{
			XmlNode node = CreateNode("<something>" + "<monkey/>" + "</something>");
			new TnR2ElementParser().Parse(CreateContext(), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestUsesNoUse()
		{
			XmlNode node = CreateNode("<something/>");
			TrivialName result = (TrivialName)new TnR2ElementParser().Parse(null, node, null).BareValue;
			Assert.AreEqual(0, result.Uses.Count, "zero uses");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestUsesOneUse()
		{
			XmlNode node = CreateNode("<something use=\"L\"/>");
			TrivialName result = (TrivialName)new TnR2ElementParser().Parse(null, node, null).BareValue;
			Assert.AreEqual(1, result.Uses.Count, "one use");
			Assert.IsTrue(result.Uses.Contains(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL), "contains LEGAL use"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestUsesMultipleUses()
		{
			XmlNode node = CreateNode("<something use=\"L C P\"/>");
			TrivialName result = (TrivialName)new TnR2ElementParser().Parse(null, node, null).BareValue;
			Assert.AreEqual(3, result.Uses.Count, "one use");
			Assert.IsTrue(result.Uses.Contains(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL), "contains LEGAL use"
				);
			Assert.IsTrue(result.Uses.Contains(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LICENSE), "contains LICENSE use"
				);
			Assert.IsTrue(result.Uses.Contains(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.PSEUDONYM), "contains PSEUDONYM use"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestUsesUnknownUse()
		{
			XmlNode node = CreateNode("<something use=\"XXX\"/>");
			TrivialName result = (TrivialName)new TnR2ElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue;
			Assert.AreEqual(0, result.Uses.Count, "no uses");
		}
	}
}
