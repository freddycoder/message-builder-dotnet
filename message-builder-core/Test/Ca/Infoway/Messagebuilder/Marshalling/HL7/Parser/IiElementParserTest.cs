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
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Platform;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class IiElementParserTest : CeRxDomainValueTestCase
	{
		private XmlToModelResult result;

		private static readonly IiValidationUtils II_VALIDATION_UTILS = new IiValidationUtils();

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public override void SetUp()
		{
			base.SetUp();
			this.result = new XmlToModelResult();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II.BUS"), node, this.result);
			Assert.IsNotNull(ii, "null result");
			Assert.IsTrue(ii.HasNullFlavor(), "has null flavor");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, ii.NullFlavor, "NI null flavor"
				);
			Assert.IsTrue(this.result.IsValid());
		}

		private ParseContext CreateContext(string type)
		{
			return CreateContext(type, SpecificationVersion.V02R02);
		}

		private ParseContext CreateContext(string type, SpecificationVersion version)
		{
			return ParseContextImpl.Create(type, null, version, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, 
				null, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			// errors should be: 1) use must be BUS 2) root is mandatory 
			XmlNode node = CreateNode("<something/>");
			new IiElementParser().Parse(CreateContext("II.BUS"), node, this.result);
			Assert.IsFalse(result.IsValid(), "result");
			Assert.AreEqual(2, this.result.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoValueAttributeNode()
		{
			// errors should be: 1) use must be BUS 2) root is mandatory 
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			new IiElementParser().Parse(CreateContext("II.BUS"), node, this.result);
			Assert.IsFalse(result.IsValid(), "result");
			Assert.AreEqual(2, this.result.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidOneAttribute()
		{
			UUID uuid = UUID.RandomUUID();
			XmlNode node = CreateNode("<something root=\"" + uuid.ToString() + "\" use=\"BUS\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II.BUS"), node, this.result);
			AssertResultAsExpected(ii.Value, uuid.ToString(), null);
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidIiBus()
		{
			XmlNode node = CreateNode("<something root=\"1.222.333\" extension=\"extensionValue\" use=\"BUS\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II.BUS"), node, this.result);
			AssertResultAsExpected(ii.Value, "1.222.333", "extensionValue");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidIiBusAndVerAsBus()
		{
			XmlNode node = CreateNode("<something root=\"1.222.333\" extension=\"extensionValue\" use=\"BUS\" specializationType=\"II.BUS\" />"
				);
			II ii = (II)new IiElementParser().Parse(CreateContext("II.BUS_AND_VER"), node, this.result);
			AssertResultAsExpected(ii.Value, "1.222.333", "extensionValue");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidIiBusAndVerAsVer()
		{
			UUID uuid = UUID.RandomUUID();
			XmlNode node = CreateNode("<something root=\"" + uuid.ToString() + "\" use=\"VER\" specializationType=\"II.VER\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II.BUS_AND_VER"), node, this.result);
			AssertResultAsExpected(ii.Value, uuid.ToString(), null);
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidIiBusAndVerDefaultToIiBus()
		{
			XmlNode node = CreateNode("<something root=\"1.222.333\" extension=\"extensionValue\" use=\"BUS\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II.BUS_AND_VER"), node, this.result);
			AssertResultAsExpected(ii.Value, "1.222.333", "extensionValue");
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, this.result.GetHl7Errors()[0].GetHl7ErrorCode());
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().Contains("Specialization type must be II.BUS or II.VER; II.BUS will be assumed. "
				));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidIiBusAndVerDefaultToIiBusAsABestGuess()
		{
			XmlNode node = CreateNode("<something root=\"1.222.333\" extension=\"extensionValue\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II.BUS_AND_VER"), node, this.result);
			AssertResultAsExpected(ii.Value, "1.222.333", "extensionValue");
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(2, this.result.GetHl7Errors().Count);
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, this.result.GetHl7Errors()[0].GetHl7ErrorCode());
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().Contains("Specialization type must be II.BUS or II.VER; II.BUS will be assumed. "
				));
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, this.result.GetHl7Errors()[1].GetHl7ErrorCode());
			Assert.IsTrue(this.result.GetHl7Errors()[1].GetMessage().Contains("use"));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidIiBusAndVerDefaultToIiVer()
		{
			UUID uuid = UUID.RandomUUID();
			XmlNode node = CreateNode("<something root=\"" + uuid.ToString() + "\" use=\"VER\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II.BUS_AND_VER"), node, this.result);
			AssertResultAsExpected(ii.Value, uuid.ToString(), null);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, this.result.GetHl7Errors()[0].GetHl7ErrorCode());
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().Contains("Specialization type must be II.BUS or II.VER; II.VER will be assumed. "
				));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidIiBusVer()
		{
			XmlNode node = CreateNode("<something root=\"1.222.333\" extension=\"extensionValue\" use=\"BUS\" version=\"1\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II.BUSVER"), node, this.result);
			AssertResultAsExpected(ii.Value, "1.222.333", "extensionValue");
			Assert.AreEqual("1", ii.Value.Version, "version");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidIiPublicVer()
		{
			XmlNode node = CreateNode("<something root=\"1.222.333\" extension=\"extensionValue\" version=\"1\" displayable=\"true\" />"
				);
			II ii = (II)new IiElementParser().Parse(CreateContext("II.PUBLICVER"), node, this.result);
			AssertResultAsExpected(ii.Value, "1.222.333", "extensionValue");
			Assert.AreEqual("1", ii.Value.Version, "version");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidIiToken()
		{
			UUID uuid = UUID.RandomUUID();
			XmlNode node = CreateNode("<something root=\"" + uuid.ToString() + "\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II.TOKEN"), node, this.result);
			AssertResultAsExpected(ii.Value, uuid.ToString(), null);
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidIiTokenBadUuid()
		{
			UUID uuid = UUID.RandomUUID();
			XmlNode node = CreateNode("<something root=\"" + uuid.ToString() + "garbage\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II.TOKEN"), node, this.result);
			AssertResultAsExpected(ii.Value, uuid.ToString() + "garbage", null);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, this.result.GetHl7Errors()[0].GetHl7ErrorCode());
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().Contains("should be a UUID"));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidIiVer()
		{
			UUID uuid = UUID.RandomUUID();
			XmlNode node = CreateNode("<something root=\"" + uuid.ToString() + "\" use=\"VER\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II.VER"), node, this.result);
			AssertResultAsExpected(ii.Value, uuid.ToString(), null);
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidIiOid()
		{
			XmlNode node = CreateNode("<something root=\"111.222.333\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II.OID"), node, this.result);
			AssertResultAsExpected(ii.Value, "111.222.333", null);
			Assert.AreEqual(typeof(Identifier), ii.Value.GetType(), "type");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidIiOid()
		{
			XmlNode node = CreateNode("<something root=\"not_an_oid\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II.OID"), node, this.result);
			AssertResultAsExpected(ii.Value, "not_an_oid", null);
			Assert.AreEqual(typeof(Identifier), ii.Value.GetType(), "type");
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, this.result.GetHl7Errors()[0].GetHl7ErrorCode());
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().Contains("does not appear to be a valid oid"));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidIiOidForMR2009()
		{
			XmlNode node = CreateNode("<something root=\"111.222.333\" use=\"BUS\" />");
			ParseContext context = CreateContext("II.OID", SpecificationVersion.R02_04_03);
			II ii = (II)new IiElementParser().Parse(context, node, this.result);
			AssertResultAsExpected(ii.Value, "111.222.333", null);
			Assert.AreEqual(typeof(Identifier), ii.Value.GetType(), "type");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidIiOidForMR2009()
		{
			XmlNode node = CreateNode("<something root=\"111.222.333\" use=\"BSU\" />");
			ParseContext context = CreateContext("II.OID", SpecificationVersion.R02_04_03);
			II ii = (II)new IiElementParser().Parse(context, node, this.result);
			AssertResultAsExpected(ii.Value, "111.222.333", null);
			Assert.AreEqual(typeof(Identifier), ii.Value.GetType(), "type");
			Assert.IsFalse(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidMultipleAttributesDifferentOrder()
		{
			XmlNode node = CreateNode("<something use=\"BUS\" extension=\"extensionValue\"  root=\"1.2.2.1\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II.BUS"), node, this.result);
			AssertResultAsExpected(ii.Value, "1.2.2.1", "extensionValue");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidMultipleAttributesPlusExtra()
		{
			XmlNode node = CreateNode("<something extra=\"extraValue\" root=\"2.1.2.1\" extension=\"extensionValue\" displayable=\"true\" />"
				);
			II ii = (II)new IiElementParser().Parse(CreateContext("II.PUBLIC"), node, this.result);
			AssertResultAsExpected(ii.Value, "2.1.2.1", "extensionValue");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidMissingSpecializationType()
		{
			// TM/BM - decided that validating for SpecializationType for the II case caused CHI and users more grief than benefit (LATER: TM - code does not agree with this statement!)
			XmlNode node = CreateNode("<something root=\"1.3.1.2\" extension=\"extensionValue\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II"), node, this.result);
			AssertResultAsExpected(ii.Value, "1.3.1.2", "extensionValue");
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, this.result.GetHl7Errors()[0].GetHl7ErrorCode());
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().Contains("Missing specializationType"));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidUnknownSpecializationType()
		{
			XmlNode node = CreateNode("<something root=\"1.3.1.2\" extension=\"extensionValue\" specializationType=\"II.DOES_NOT_EXIST\" />"
				);
			II ii = (II)new IiElementParser().Parse(CreateContext("II"), node, this.result);
			AssertResultAsExpected(ii.Value, "1.3.1.2", "extensionValue");
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, this.result.GetHl7Errors()[0].GetHl7ErrorCode());
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().Contains("Invalid specializationType"));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidMissingSpecializationTypeForCeRx()
		{
			XmlNode node = CreateNode("<something root=\"1.2.3.4\" extension=\"extensionValue\" />");
			ParseContext context = CreateContext("II", SpecificationVersion.V01R04_3);
			II ii = (II)new IiElementParser().Parse(context, node, this.result);
			AssertResultAsExpected(ii.Value, "1.2.3.4", "extensionValue");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidMissingSpecializationTypeForAB()
		{
			XmlNode node = CreateNode("<something root=\"1.2.3.3\" extension=\"extensionValue\" />");
			ParseContext context = CreateContext("II", SpecificationVersion.V02R02_AB);
			II ii = (II)new IiElementParser().Parse(context, node, this.result);
			AssertResultAsExpected(ii.Value, "1.2.3.3", "extensionValue");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidMissingSpecializationTypeForAB()
		{
			XmlNode node = CreateNode("<something root=\"1.2.3.3\" extension=\"extensionValue\" use=\"BUS\" />");
			ParseContext context = CreateContext("II.BUS_AND_VER", SpecificationVersion.V02R02_AB);
			II ii = (II)new IiElementParser().Parse(context, node, this.result);
			AssertResultAsExpected(ii.Value, "1.2.3.3", "extensionValue");
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, this.result.GetHl7Errors()[0].GetHl7ErrorCode());
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().Contains("specialization type"));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidSpecializationType()
		{
			XmlNode node = CreateNode("<something root=\"1.2.3.4\" extension=\"extensionValue\" specializationType=\"II.BUS\" use=\"BUS\" />"
				);
			II ii = (II)new IiElementParser().Parse(CreateContext("II"), node, this.result);
			AssertResultAsExpected(ii.Value, "1.2.3.4", "extensionValue");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidIiPublicForMr2007()
		{
			XmlNode node = CreateNode("<something root=\"1.2.3.4\" extension=\"extensionValue\" displayable=\"true\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II.PUBLIC"), node, this.result);
			AssertResultAsExpected(ii.Value, "1.2.3.4", "extensionValue");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidIiPublicForMr2007()
		{
			XmlNode node = CreateNode("<something root=\"1.2.3.4\" extension=\"extensionValue\" displayable=\"true\" use=\"BUS\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II.PUBLIC"), node, this.result);
			AssertResultAsExpected(ii.Value, "1.2.3.4", "extensionValue");
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, this.result.GetHl7Errors()[0].GetHl7ErrorCode());
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().Contains("should not include"));
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().Contains("'use'"));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidIiPublicForMr2009()
		{
			XmlNode node = CreateNode("<something root=\"1.2.3.4\" extension=\"extensionValue\" displayable=\"true\" use=\"BUS\" />");
			ParseContext context = CreateContext("II.PUBLIC", SpecificationVersion.R02_04_03);
			II ii = (II)new IiElementParser().Parse(context, node, this.result);
			AssertResultAsExpected(ii.Value, "1.2.3.4", "extensionValue");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidIiPublicForMr2009()
		{
			XmlNode node = CreateNode("<something root=\"1.2.3.4\" extension=\"extensionValue\" displayable=\"true\" />");
			ParseContext context = CreateContext("II.PUBLIC", SpecificationVersion.R02_04_03);
			II ii = (II)new IiElementParser().Parse(context, node, this.result);
			AssertResultAsExpected(ii.Value, "1.2.3.4", "extensionValue");
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, this.result.GetHl7Errors()[0].GetHl7ErrorCode());
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().Contains("requires the attribute use=\"BUS\""));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidIiBusWithMaxRootLength()
		{
			string maxLengthRoot = "123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.1234567890";
			XmlNode node = CreateNode("<something root=\"" + maxLengthRoot + "\" extension=\"extensionValue\" use=\"BUS\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II.BUS"), node, this.result);
			AssertResultAsExpected(ii.Value, maxLengthRoot, "extensionValue");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidIiBusWithMaxRootLengthPlusOne()
		{
			string maxLengthRootPlusOne = "0" + "123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.1234567890";
			XmlNode node = CreateNode("<something root=\"" + maxLengthRootPlusOne + "\" extension=\"extensionValue\" use=\"BUS\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II.BUS"), node, this.result);
			AssertResultAsExpected(ii.Value, maxLengthRootPlusOne, "extensionValue");
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, this.result.GetHl7Errors()[0].GetHl7ErrorCode());
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().Contains("exceeds maximum allowed length"));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidIiBusWithMaxExtensionLength()
		{
			string maxExtension = "12345678901234567890";
			XmlNode node = CreateNode("<something root=\"1.2.3.3\" extension=\"" + maxExtension + "\" use=\"BUS\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II.BUS"), node, this.result);
			AssertResultAsExpected(ii.Value, "1.2.3.3", maxExtension);
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidIiBusWithMaxExtensionLengthPlusOne()
		{
			string maxExtensionPlusOne = "0" + "12345678901234567890";
			XmlNode node = CreateNode("<something root=\"1.2.3.3\" extension=\"" + maxExtensionPlusOne + "\" use=\"BUS\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II.BUS"), node, this.result);
			AssertResultAsExpected(ii.Value, "1.2.3.3", maxExtensionPlusOne);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, this.result.GetHl7Errors()[0].GetHl7ErrorCode());
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().Contains("exceeds maximum allowed length"));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidIiBusWithMaxRootLengthForCeRx()
		{
			string maxLengthRoot = "123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.1234567890";
			XmlNode node = CreateNode("<something root=\"" + maxLengthRoot + "\" extension=\"extensionValue\" use=\"BUS\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II.BUS", SpecificationVersion.V01R04_3), node, this.result);
			AssertResultAsExpected(ii.Value, maxLengthRoot, "extensionValue");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidIiBusWithMaxRootLengthPlusOneForCeRx()
		{
			string maxLengthRootPlusOne = "0" + "123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.1234567890.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.1234567890";
			XmlNode node = CreateNode("<something root=\"" + maxLengthRootPlusOne + "\" extension=\"extensionValue\" use=\"BUS\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II.BUS", SpecificationVersion.V01R04_3), node, this.result);
			AssertResultAsExpected(ii.Value, maxLengthRootPlusOne, "extensionValue");
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, this.result.GetHl7Errors()[0].GetHl7ErrorCode());
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().Contains("exceeds maximum allowed length"));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidIiBusWithSuperfluousSpecializationType()
		{
			XmlNode node = CreateNode("<something root=\"11.22.33\" specializationType=\"II.BUS\" extension=\"extensionValue\" use=\"BUS\" />"
				);
			II ii = (II)new IiElementParser().Parse(CreateContext("II.BUS", SpecificationVersion.R02_04_02), node, this.result);
			AssertResultAsExpected(ii.Value, "11.22.33", "extensionValue");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidIiBusWithIncorrectSuperfluousSpecializationType()
		{
			XmlNode node = CreateNode("<something root=\"11.22.33\" specializationType=\"II.VER\" extension=\"extensionValue\" use=\"BUS\" />"
				);
			II ii = (II)new IiElementParser().Parse(CreateContext("II.BUS", SpecificationVersion.R02_04_02), node, this.result);
			AssertResultAsExpected(ii.Value, "11.22.33", "extensionValue");
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().StartsWith("A specializationType should not be specified for non-abstract type: II.BUS"
				));
		}

		private void AssertResultAsExpected(Identifier result, string rootValue, string extensionValue)
		{
			Assert.IsNotNull(result, "populated result returned");
			if (rootValue == null)
			{
				Assert.IsNull(result.Root, "null root");
			}
			else
			{
				Assert.AreEqual(rootValue, result.Root, "root");
			}
			if (extensionValue == null)
			{
				Assert.IsNull(result.Extension, "null extension");
			}
			else
			{
				Assert.AreEqual(extensionValue, result.Extension, "extension");
			}
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIsOid()
		{
			AssertOid("1.2.3");
			AssertNotOid("1.2.3.");
			AssertNotOid("1.2.3..4");
			AssertNotOid(".2.3.4");
			AssertOid("1.22.33.456");
			AssertOid("1.22.3.456.333.23231.123");
			AssertOid("1.22.3.456.333.23231.0");
		}

		private void AssertOid(string oid)
		{
			Assert.IsTrue(II_VALIDATION_UTILS.IsOid(oid), oid);
		}

		private void AssertNotOid(string oid)
		{
			Assert.IsFalse(II_VALIDATION_UTILS.IsOid(oid), oid);
		}
	}
}
