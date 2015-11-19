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
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Resolver;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class CsElementParserTest : MarshallingTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public override void SetUp()
		{
			base.SetUp();
			CodeResolverRegistry.RegisterResolver(typeof(MockCharacters), new EnumBasedCodeResolver(typeof(MockEnum)));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\"/>");
			CD acknowledgementCondition = (CD)new CvElementParser().Parse(ParseContextImpl.Create("CS", typeof(MockCode), SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsTrue(acknowledgementCondition.HasNullFlavor());
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, acknowledgementCondition.NullFlavor
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseContainsCodeSystem()
		{
			XmlNode node = CreateNode("<something code=\"ER\" codeSystem=\"1.2.3.4\" />");
			CD cs = (CD)new CvElementParser().Parse(ParseContextImpl.Create("CS", typeof(MockCode), SpecificationVersion.V02R02, null
				, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid(), "valid");
			Assert.IsNotNull(cs, "cs");
			Assert.IsNotNull(cs.Value, "code");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseContainsDisplayName()
		{
			XmlNode node = CreateNode("<something code=\"ER\" displayName=\"Error\" />");
			CD cs = (CD)new CvElementParser().Parse(ParseContextImpl.Create("CS", typeof(MockCode), SpecificationVersion.V02R02, null
				, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid(), "valid");
			Assert.IsNotNull(cs, "cs");
			Assert.IsNotNull(cs.Value, "code");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseContainsCodeSystemName()
		{
			XmlNode node = CreateNode("<something code=\"ER\" codeSystemName=\"My code system\" />");
			CD cs = (CD)new CvElementParser().Parse(ParseContextImpl.Create("CS", typeof(MockCode), SpecificationVersion.V02R02, null
				, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid(), "valid");
			Assert.IsNotNull(cs, "cs");
			Assert.IsNotNull(cs.Value, "code");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseContainsOriginalText()
		{
			XmlNode node = CreateNode("<something code=\"ER\"><originalText>My original text</originalText></something>");
			CD cs = (CD)new CvElementParser().Parse(ParseContextImpl.Create("CS", typeof(MockCode), SpecificationVersion.V02R02, null
				, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid(), "valid");
			Assert.IsNotNull(cs, "cs");
			Assert.IsNotNull(cs.Value, "code");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			CD cs = (CD)new CvElementParser().Parse(ParseContextImpl.Create("CS", typeof(MockCode), SpecificationVersion.V02R02, null
				, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.IsNull(cs.Value, "empty node returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoCodeAttributeNode()
		{
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			CD cs = (CD)new CvElementParser().Parse(ParseContextImpl.Create("CS", typeof(MockCode), SpecificationVersion.V02R02, null
				, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.IsNull(cs.Value, "node with no code attribute returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValid()
		{
			XmlNode node = CreateNode("<something code=\"ER\" />");
			CD cs = (CD)new CvElementParser().Parse(ParseContextImpl.Create("CS", typeof(MockCode), SpecificationVersion.V02R02, null
				, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("ER", cs.Value.CodeValue, "node with code attribute returns value");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidEnumCode()
		{
			XmlNode node = CreateNode("<something code=\"FRED\" />");
			CD cs = (CD)new CvElementParser().Parse(ParseContextImpl.Create("CS", typeof(MockCharacters), SpecificationVersion.V02R02
				, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(MockEnum.FRED, cs.Value, "enum found properly");
			Assert.AreEqual(0, this.xmlResult.GetHl7Errors().Count, "error message count");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidEnumCode()
		{
			XmlNode node = CreateNode("<something code=\"ER\" />");
			CD cs = (CD)new CvElementParser().Parse(ParseContextImpl.Create("CS", typeof(MockCharacters), SpecificationVersion.V02R02
				, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.IsNull(cs.Value, "bogus enum not found");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "error message count");
			Assert.AreEqual("The code, \"ER\", in element <something> is not a valid value for domain type \"MockCharacters\"", this.
				xmlResult.GetHl7Errors()[0].GetMessage(), "error message");
			Assert.AreEqual(Hl7ErrorCode.VALUE_NOT_IN_CODE_SYSTEM, this.xmlResult.GetHl7Errors()[0].GetHl7ErrorCode(), "error type");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTooManyChildNodes()
		{
			XmlNode node = CreateNode("<something>" + "<monkey/>" + "</something>");
			CD cs = (CD)new CvElementParser().Parse(ParseContextImpl.Create("CS", typeof(MockCode), SpecificationVersion.V02R02, null
				, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.IsNull(cs.Value, "empty node with children returns null");
		}
	}
}
