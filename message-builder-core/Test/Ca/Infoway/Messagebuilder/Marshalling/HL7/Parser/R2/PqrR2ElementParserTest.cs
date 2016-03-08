/**
 * Copyright 2013 Canada Health Infoway, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */


using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using Ca.Infoway.Messagebuilder.Resolver;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[TestFixture]
	public class PqrR2ElementParserTest : MarshallingTestCase
	{
		private PqrR2ElementParser parser;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public override void SetUp()
		{
			base.SetUp();
			CodeResolverRegistry.RegisterResolver(typeof(MockCharacters), new EnumBasedCodeResolver(typeof(MockEnum)));
			this.parser = new PqrR2ElementParser();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\"/>");
			PQR<MockCharacters> pqr = (PQR<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("PQR", typeof(MockCharacters), SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(pqr.Value, "value");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, pqr.NullFlavor, "null flavor"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseOtherNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"OTH\"/>");
			PQR<MockCharacters> pqr = (PQR<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("PQR", typeof(MockCharacters), SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(pqr.Value, "value");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER, pqr.NullFlavor, "null flavor");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseCodeWithNullNode()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" nullFlavor=\"OTH\"/>");
			PQR<MockCharacters> pqr = (PQR<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("PQR", typeof(MockCharacters), SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("BARNEY", pqr.Value.GetCodeValue(), "value");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER, pqr.NullFlavor, "null flavor");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseCodeWithNullNodeAndCodeSystem()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" codeSystem=\"1.2.3.4.5\" nullFlavor=\"OTH\"/>");
			PQR<MockCharacters> pqr = (PQR<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("PQR", typeof(MockCharacters), SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("BARNEY", pqr.Value.GetCodeValue(), "value");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER, pqr.NullFlavor, "null flavor");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			PQR<MockCharacters> pqr = (PQR<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("PQR", typeof(MockCharacters), SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(pqr.Value, "empty node returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoCodeAttributeNode()
		{
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			PQR<MockCharacters> pqr = (PQR<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("PQR", typeof(MockCharacters), SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(pqr.Value, "node with no code attribute returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalid()
		{
			XmlNode node = CreateNode("<something code=\"ER\" />");
			PQR<MockCharacters> pqr = (PQR<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("PQR", typeof(MockCharacters), SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.IsNull(pqr.Value, "node with no code attribute returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidWithEmptyNullFavorAttributeValue()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" nullFlavor=\"\"/>");
			PQR<MockCharacters> pqr = (PQR<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("PQR", typeof(MockCharacters), SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("BARNEY", pqr.Value.GetCodeValue(), "node with no code attribute returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidNullFavorAttributeValue()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NOT A VALID NULL FAVOR VALUE\"/>");
			this.parser.Parse(ParseContextImpl.Create("PQR", typeof(MockCharacters), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "warning message count");
		}

		// invalid NF
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidWithInvalidNullFavorAttributeValue()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" nullFlavor=\"NOT A VALID NULL FAVOR VALUE\"/>");
			PQR<MockCharacters> pqr = (PQR<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("PQR", typeof(MockCharacters), SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("BARNEY", pqr.Value.GetCodeValue(), "node with no code attribute returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidFull()
		{
			XmlNode node = CreateNode("<something code=\"FRED\" codeSystem=\"1.2.3.4.5\" codeSystemName=\"aCsName\" codeSystemVersion=\"aCsVersion\" displayName=\"aDisplayName\" value=\"1.2\">"
				 + "<originalText>some original text</originalText>" + "</something>");
			PQR<MockCharacters> pqr = (PQR<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("PQR", typeof(MockCharacters), SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid(), "valid");
			Assert.AreEqual(MockEnum.FRED, pqr.Value.Code, "enum found properly");
			Assert.AreEqual("aCsName", pqr.Value.CodeSystemName);
			Assert.AreEqual("aCsVersion", pqr.Value.CodeSystemVersion);
			Assert.AreEqual("aDisplayName", pqr.Value.DisplayName);
			Assert.AreEqual("some original text", pqr.Value.OriginalText.Content);
			Assert.AreEqual(new BigDecimal("1.2"), pqr.Value.Value);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseFull()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" codeSystem=\"1.2.3.4.5\" codeSystemName=\"aCsName\" codeSystemVersion=\"aCsVersion\" displayName=\"aDisplayName\" value=\"1.2\" operator=\"P\">"
				 + "  some freeform text" + "  <originalText>some original text</originalText>" + "  <qualifier inverted=\"true\"><name code=\"cm\" codeSystem=\"1.2.3.4\"/><value code=\"normal\" codeSystem=\"2.16.840.1.113883.5.14\"/></qualifier>"
				 + "  <qualifier inverted=\"true\"><name code=\"M\" codeSystem=\"2.16.840.1.113883.5.1\"/><value code=\"ACT\" codeSystem=\"2.16.840.1.113883.5.6\"/></qualifier>"
				 + "  <translation code=\"M\" codeSystem=\"2.16.840.1.113883.5.1\" />" + "  <translation code=\"F\" codeSystem=\"2.16.840.1.113883.5.1\" />"
				 + "</something>");
			PQR<MockCharacters> pqr = (PQR<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("PQR", typeof(MockCharacters), SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(4, this.xmlResult.GetHl7Errors().Count, "error message count");
			Assert.IsNotNull(pqr.Value, "main enum found");
			Assert.AreEqual("BARNEY", pqr.Value.GetCodeValue(), "main code");
			Assert.AreEqual("1.2.3.4.5", pqr.Value.GetCodeSystem(), "main code");
			Assert.AreEqual("aCsName", pqr.Value.CodeSystemName);
			Assert.AreEqual("aCsVersion", pqr.Value.CodeSystemVersion);
			Assert.AreEqual("aDisplayName", pqr.Value.DisplayName);
			Assert.IsNull(pqr.Value.Operator);
			Assert.AreEqual(new BigDecimal("1.2"), pqr.Value.Value);
			Assert.IsNull(pqr.Value.SimpleValue);
			Assert.AreEqual("some original text", pqr.Value.OriginalText.Content);
			Assert.AreEqual(0, pqr.Value.Translation.Count);
			Assert.AreEqual(0, pqr.Value.Qualifier.Count);
		}
	}
}
