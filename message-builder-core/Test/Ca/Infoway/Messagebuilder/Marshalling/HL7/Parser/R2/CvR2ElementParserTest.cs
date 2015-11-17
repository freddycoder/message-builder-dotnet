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
 * Author:        $LastChangedBy: tmcgrady $
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
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
	public class CvR2ElementParserTest : MarshallingTestCase
	{
		private CvR2ElementParser parser;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public override void SetUp()
		{
			base.SetUp();
			CodeResolverRegistry.RegisterResolver(typeof(MockCharacters), new EnumBasedCodeResolver(typeof(MockEnum)));
			this.parser = new CvR2ElementParser();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\"/>");
			CV_R2<MockCharacters> cv = (CV_R2<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), 
				SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node
				, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(cv.Value, "value");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, cv.NullFlavor, "null flavor");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseOtherNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"OTH\"/>");
			CV_R2<MockCharacters> cv = (CV_R2<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), 
				SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node
				, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(cv.Value, "value");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER, cv.NullFlavor, "null flavor");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseCodeWithNullNode()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" nullFlavor=\"OTH\"/>");
			CV_R2<MockCharacters> cv = (CV_R2<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), 
				SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node
				, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("BARNEY", cv.Value.GetCodeValue(), "value");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER, cv.NullFlavor, "null flavor");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseCodeWithNullNodeAndCodeSystem()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" codeSystem=\"1.2.3.4.5\" nullFlavor=\"OTH\"/>");
			CV_R2<MockCharacters> cv = (CV_R2<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), 
				SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node
				, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("BARNEY", cv.Value.GetCodeValue(), "value");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER, cv.NullFlavor, "null flavor");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			CV_R2<MockCharacters> cv = (CV_R2<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), 
				SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, null, null, false), node
				, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(cv.Value, "empty node returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoCodeAttributeNode()
		{
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			CV_R2<MockCharacters> cv = (CV_R2<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), 
				SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node
				, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(cv.Value, "node with no code attribute returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalid()
		{
			XmlNode node = CreateNode("<something code=\"ER\" />");
			CV_R2<MockCharacters> cv = (CV_R2<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), 
				SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node
				, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.IsNull(cv.Value, "node with no code attribute returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidWithEmptyNullFavorAttributeValue()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" nullFlavor=\"\"/>");
			CV_R2<MockCharacters> cv = (CV_R2<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), 
				SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node
				, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("BARNEY", cv.Value.GetCodeValue(), "node with no code attribute returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidNullFavorAttributeValue()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NOT A VALID NULL FAVOR VALUE\"/>");
			this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
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
			CV_R2<MockCharacters> cv = (CV_R2<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), 
				SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node
				, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("BARNEY", cv.Value.GetCodeValue(), "node with no code attribute returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidFull()
		{
			XmlNode node = CreateNode("<something code=\"FRED\" codeSystem=\"1.2.3.4.5\" codeSystemName=\"aCsName\" codeSystemVersion=\"aCsVersion\" displayName=\"aDisplayName\">"
				 + "<originalText>some original text</originalText>" + "</something>");
			CV_R2<MockCharacters> cv = (CV_R2<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), 
				SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node
				, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid(), "valid");
			Assert.AreEqual(MockEnum.FRED, cv.Value.Code, "enum found properly");
			Assert.AreEqual("aCsName", cv.Value.CodeSystemName);
			Assert.AreEqual("aCsVersion", cv.Value.CodeSystemVersion);
			Assert.AreEqual("aDisplayName", cv.Value.DisplayName);
			Assert.AreEqual("some original text", cv.Value.OriginalText.Content);
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
			CV_R2<MockCharacters> cv = (CV_R2<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), 
				SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node
				, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(5, this.xmlResult.GetHl7Errors().Count, "error message count");
			Assert.IsNotNull(cv.Value, "main enum found");
			Assert.AreEqual("BARNEY", cv.Value.GetCodeValue(), "main code");
			Assert.AreEqual("1.2.3.4.5", cv.Value.GetCodeSystem(), "main code");
			Assert.AreEqual("aCsName", cv.Value.CodeSystemName);
			Assert.AreEqual("aCsVersion", cv.Value.CodeSystemVersion);
			Assert.AreEqual("aDisplayName", cv.Value.DisplayName);
			Assert.IsNull(cv.Value.Operator);
			Assert.IsNull(cv.Value.Value);
			Assert.IsNull(cv.Value.SimpleValue);
			Assert.AreEqual("some original text", cv.Value.OriginalText.Content);
			Assert.AreEqual(0, cv.Value.Translation.Count);
			Assert.AreEqual(0, cv.Value.Qualifier.Count);
		}

		// some tests for CO (identical to CV)
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidFullCo()
		{
			XmlNode node = CreateNode("<something code=\"FRED\" codeSystem=\"1.2.3.4.5\" codeSystemName=\"aCsName\" codeSystemVersion=\"aCsVersion\" displayName=\"aDisplayName\">"
				 + "<originalText>some original text</originalText>" + "</something>");
			CO<MockCharacters> co = (CO<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("CO", typeof(MockCharacters), SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid(), "valid");
			Assert.AreEqual(MockEnum.FRED, co.Value.Code, "enum found properly");
			Assert.AreEqual("aCsName", co.Value.CodeSystemName);
			Assert.AreEqual("aCsVersion", co.Value.CodeSystemVersion);
			Assert.AreEqual("aDisplayName", co.Value.DisplayName);
			Assert.AreEqual("some original text", co.Value.OriginalText.Content);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseFullCo()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" codeSystem=\"1.2.3.4.5\" codeSystemName=\"aCsName\" codeSystemVersion=\"aCsVersion\" displayName=\"aDisplayName\" value=\"1.2\" operator=\"P\">"
				 + "  some freeform text" + "  <originalText>some original text</originalText>" + "  <qualifier inverted=\"true\"><name code=\"cm\" codeSystem=\"1.2.3.4\"/><value code=\"normal\" codeSystem=\"2.16.840.1.113883.5.14\"/></qualifier>"
				 + "  <qualifier inverted=\"true\"><name code=\"M\" codeSystem=\"2.16.840.1.113883.5.1\"/><value code=\"ACT\" codeSystem=\"2.16.840.1.113883.5.6\"/></qualifier>"
				 + "  <translation code=\"M\" codeSystem=\"2.16.840.1.113883.5.1\" />" + "  <translation code=\"F\" codeSystem=\"2.16.840.1.113883.5.1\" />"
				 + "</something>");
			CO<MockCharacters> co = (CO<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("CO", typeof(MockCharacters), SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(5, this.xmlResult.GetHl7Errors().Count, "error message count");
			Assert.IsNotNull(co.Value, "main enum found");
			Assert.AreEqual("BARNEY", co.Value.GetCodeValue(), "main code");
			Assert.AreEqual("1.2.3.4.5", co.Value.GetCodeSystem(), "main code");
			Assert.AreEqual("aCsName", co.Value.CodeSystemName);
			Assert.AreEqual("aCsVersion", co.Value.CodeSystemVersion);
			Assert.AreEqual("aDisplayName", co.Value.DisplayName);
			Assert.IsNull(co.Value.Operator);
			Assert.IsNull(co.Value.Value);
			Assert.IsNull(co.Value.SimpleValue);
			Assert.AreEqual("some original text", co.Value.OriginalText.Content);
			Assert.AreEqual(0, co.Value.Translation.Count);
			Assert.AreEqual(0, co.Value.Qualifier.Count);
		}
	}
}
