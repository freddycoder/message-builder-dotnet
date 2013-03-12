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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Platform;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class IiPropertyFormatterTest : MarshallingTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForValidII()
		{
			Identifier ii = new Identifier("11.22.33.44", "extensionString");
			II iiHl7 = new IIImpl();
			iiHl7.DataType = StandardDataType.II_BUS;
			ModelToXmlResult modelToXmlResult = new ModelToXmlResult();
			FormatContextImpl context = new FormatContextImpl(modelToXmlResult, null, "name", "II", null, false, SpecificationVersion
				.R02_04_02, null, null, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(4, result.Count, "map size");
			Assert.IsTrue(modelToXmlResult.GetHl7Errors().IsEmpty(), "no errors");
			AssertKeyValuePairInMap(result, "root", "11.22.33.44");
			AssertKeyValuePairInMap(result, "extension", "extensionString");
			AssertKeyValuePairInMap(result, "use", "BUS");
			AssertKeyValuePairInMap(result, "specializationType", "II.BUS");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForII_InvalidSpecializationType()
		{
			Identifier ii = new Identifier("11.22.33.44", "extensionString");
			II iiHl7 = new IIImpl();
			iiHl7.DataType = StandardDataType.II_BUS_AND_VER;
			ModelToXmlResult modelToXmlResult = new ModelToXmlResult();
			FormatContextImpl context = new FormatContextImpl(modelToXmlResult, null, "name", "II", null, false, SpecificationVersion
				.R02_04_02, null, null, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(2, result.Count, "map size");
			Assert.IsFalse(modelToXmlResult.GetHl7Errors().IsEmpty(), "errors");
			Assert.AreEqual(1, modelToXmlResult.GetHl7Errors().Count);
			Assert.AreEqual("Invalid specializationType (II.BUS_AND_VER). Field being left as II without a specializationType.", modelToXmlResult
				.GetHl7Errors()[0].GetMessage());
			AssertKeyValuePairInMap(result, "root", "11.22.33.44");
			AssertKeyValuePairInMap(result, "extension", "extensionString");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForValidIICeRx()
		{
			Identifier ii = new Identifier("11.22.33.44", "extensionString");
			II iiHl7 = new IIImpl();
			ModelToXmlResult modelToXmlResult = new ModelToXmlResult();
			FormatContextImpl context = new FormatContextImpl(modelToXmlResult, null, "name", "II", null, false, SpecificationVersion
				.V01R04_3, null, null, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(2, result.Count, "map size");
			Assert.IsTrue(modelToXmlResult.GetHl7Errors().IsEmpty(), "no errors");
			AssertKeyValuePairInMap(result, "root", "11.22.33.44");
			AssertKeyValuePairInMap(result, "extension", "extensionString");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForValidII_TOKEN()
		{
			UUID randomUUID = UUID.RandomUUID();
			Identifier ii = new Identifier(randomUUID.ToString());
			II iiHl7 = new IIImpl();
			ModelToXmlResult modelToXmlResult = new ModelToXmlResult();
			FormatContextImpl context = new FormatContextImpl(modelToXmlResult, null, "name", "II.TOKEN", null, false, SpecificationVersion
				.R02_04_02, null, null, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(modelToXmlResult.GetHl7Errors().IsEmpty(), "no errors");
			AssertKeyValuePairInMap(result, "root", randomUUID.ToString());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForInvalidII_TOKEN()
		{
			Identifier ii = new Identifier("1.2.3.4");
			II iiHl7 = new IIImpl();
			ModelToXmlResult modelToXmlResult = new ModelToXmlResult();
			FormatContextImpl context = new FormatContextImpl(modelToXmlResult, null, "name", "II.TOKEN", null, false, SpecificationVersion
				.R02_04_02, null, null, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsFalse(modelToXmlResult.GetHl7Errors().IsEmpty());
			Assert.AreEqual(1, modelToXmlResult.GetHl7Errors().Count);
			Assert.AreEqual("root '1.2.3.4' should be a UUID.", modelToXmlResult.GetHl7Errors()[0].GetMessage());
			AssertKeyValuePairInMap(result, "root", "1.2.3.4");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForValidII_OID()
		{
			Identifier ii = new Identifier("11.22.33.44");
			II iiHl7 = new IIImpl();
			ModelToXmlResult modelToXmlResult = new ModelToXmlResult();
			FormatContextImpl context = new FormatContextImpl(modelToXmlResult, null, "name", "II.OID", null, false, SpecificationVersion
				.R02_04_02, null, null, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(2, result.Count, "map size");
			Assert.IsTrue(modelToXmlResult.GetHl7Errors().IsEmpty(), "no errors");
			AssertKeyValuePairInMap(result, "root", "11.22.33.44");
			AssertKeyValuePairInMap(result, "use", "BUS");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForInvalidII_OID_shouldNotHaveExtension()
		{
			Identifier ii = new Identifier("11.22.33.44", "shouldNotBeHere");
			II iiHl7 = new IIImpl();
			ModelToXmlResult modelToXmlResult = new ModelToXmlResult();
			FormatContextImpl context = new FormatContextImpl(modelToXmlResult, null, "name", "II.OID", null, false, SpecificationVersion
				.R02_04_02, null, null, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(3, result.Count, "map size");
			Assert.IsFalse(modelToXmlResult.GetHl7Errors().IsEmpty());
			Assert.AreEqual(1, modelToXmlResult.GetHl7Errors().Count);
			Assert.AreEqual("Attribute \"extension\" is not allowed for II.OID", modelToXmlResult.GetHl7Errors()[0].GetMessage());
			AssertKeyValuePairInMap(result, "root", "11.22.33.44");
			AssertKeyValuePairInMap(result, "extension", "shouldNotBeHere");
			AssertKeyValuePairInMap(result, "use", "BUS");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForInvalidII_OID_rootTooLong()
		{
			string tooLongRoot = "12345678900.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789.123456789";
			Identifier ii = new Identifier(tooLongRoot);
			II iiHl7 = new IIImpl();
			ModelToXmlResult modelToXmlResult = new ModelToXmlResult();
			FormatContextImpl context = new FormatContextImpl(modelToXmlResult, null, "name", "II.OID", null, false, SpecificationVersion
				.R02_04_02, null, null, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(2, result.Count, "map size");
			Assert.IsFalse(modelToXmlResult.GetHl7Errors().IsEmpty());
			Assert.AreEqual(1, modelToXmlResult.GetHl7Errors().Count);
			Assert.AreEqual("root '" + tooLongRoot + "' exceeds maximum allowed length of 200.", modelToXmlResult.GetHl7Errors()[0].GetMessage
				());
			AssertKeyValuePairInMap(result, "root", tooLongRoot);
			AssertKeyValuePairInMap(result, "use", "BUS");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForInvalidII_OID()
		{
			UUID randomUUID = UUID.RandomUUID();
			Identifier ii = new Identifier(randomUUID.ToString());
			II iiHl7 = new IIImpl();
			ModelToXmlResult modelToXmlResult = new ModelToXmlResult();
			FormatContextImpl context = new FormatContextImpl(modelToXmlResult, null, "name", "II.OID", null, false, SpecificationVersion
				.R02_04_02, null, null, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(2, result.Count, "map size");
			Assert.IsFalse(modelToXmlResult.GetHl7Errors().IsEmpty());
			Assert.AreEqual(1, modelToXmlResult.GetHl7Errors().Count);
			Assert.AreEqual("The oid, \"" + randomUUID.ToString() + "\" does not appear to be a valid oid", modelToXmlResult.GetHl7Errors
				()[0].GetMessage());
			AssertKeyValuePairInMap(result, "root", randomUUID.ToString());
			AssertKeyValuePairInMap(result, "use", "BUS");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForValidII_OID_MR2007()
		{
			Identifier ii = new Identifier("11.22.33.44");
			II iiHl7 = new IIImpl();
			ModelToXmlResult modelToXmlResult = new ModelToXmlResult();
			FormatContextImpl context = new FormatContextImpl(modelToXmlResult, null, "name", "II.OID", null, false, SpecificationVersion
				.V02R02, null, null, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(modelToXmlResult.GetHl7Errors().IsEmpty(), "no errors");
			AssertKeyValuePairInMap(result, "root", "11.22.33.44");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForValidII_BUS()
		{
			Identifier ii = new Identifier("11.22.33.44", "extensionString");
			II iiHl7 = new IIImpl();
			ModelToXmlResult modelToXmlResult = new ModelToXmlResult();
			FormatContextImpl context = new FormatContextImpl(modelToXmlResult, null, "name", "II.BUS", null, false, SpecificationVersion
				.R02_04_02, null, null, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(3, result.Count, "map size");
			Assert.IsTrue(modelToXmlResult.GetHl7Errors().IsEmpty(), "no errors");
			AssertKeyValuePairInMap(result, "root", "11.22.33.44");
			AssertKeyValuePairInMap(result, "extension", "extensionString");
			AssertKeyValuePairInMap(result, "use", "BUS");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForValidII_BUS_asUuid()
		{
			UUID randomUUID = UUID.RandomUUID();
			Identifier ii = new Identifier(randomUUID.ToString());
			II iiHl7 = new IIImpl();
			ModelToXmlResult modelToXmlResult = new ModelToXmlResult();
			FormatContextImpl context = new FormatContextImpl(modelToXmlResult, null, "name", "II.BUS", null, false, SpecificationVersion
				.R02_04_02, null, null, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(2, result.Count, "map size");
			Assert.IsTrue(modelToXmlResult.GetHl7Errors().IsEmpty(), "no errors");
			AssertKeyValuePairInMap(result, "root", randomUUID.ToString());
			AssertKeyValuePairInMap(result, "use", "BUS");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForValidII_VER()
		{
			UUID randomUUID = UUID.RandomUUID();
			Identifier ii = new Identifier(randomUUID.ToString());
			II iiHl7 = new IIImpl();
			ModelToXmlResult modelToXmlResult = new ModelToXmlResult();
			FormatContextImpl context = new FormatContextImpl(modelToXmlResult, null, "name", "II.VER", null, false, SpecificationVersion
				.R02_04_02, null, null, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(2, result.Count, "map size");
			Assert.IsTrue(modelToXmlResult.GetHl7Errors().IsEmpty(), "no errors");
			AssertKeyValuePairInMap(result, "root", randomUUID.ToString());
			AssertKeyValuePairInMap(result, "use", "VER");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForValidII_BUS_AND_VER()
		{
			Identifier ii = new Identifier("11.22.33.44", "extensionString");
			II iiHl7 = new IIImpl();
			iiHl7.DataType = StandardDataType.II_BUS;
			ModelToXmlResult modelToXmlResult = new ModelToXmlResult();
			FormatContextImpl context = new FormatContextImpl(modelToXmlResult, null, "name", "II.BUS_AND_VER", null, false, SpecificationVersion
				.R02_04_02, null, null, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(4, result.Count, "map size");
			Assert.IsTrue(modelToXmlResult.GetHl7Errors().IsEmpty(), "no errors");
			AssertKeyValuePairInMap(result, "root", "11.22.33.44");
			AssertKeyValuePairInMap(result, "extension", "extensionString");
			AssertKeyValuePairInMap(result, "use", "BUS");
			AssertKeyValuePairInMap(result, "specializationType", "II.BUS");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForII_BUS_AND_VER_InvalidSpecializationType()
		{
			Identifier ii = new Identifier("11.22.33.44", "extensionString");
			II iiHl7 = new IIImpl();
			iiHl7.DataType = StandardDataType.II_OID;
			ModelToXmlResult modelToXmlResult = new ModelToXmlResult();
			FormatContextImpl context = new FormatContextImpl(modelToXmlResult, null, "name", "II.BUS_AND_VER", null, false, SpecificationVersion
				.R02_04_02, null, null, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(4, result.Count, "map size");
			Assert.IsFalse(modelToXmlResult.GetHl7Errors().IsEmpty(), "errors");
			Assert.AreEqual(1, modelToXmlResult.GetHl7Errors().Count);
			Assert.AreEqual("Specialization type must be II.BUS or II.VER; II.BUS will be assumed. Invalid specialization type II.OID"
				, modelToXmlResult.GetHl7Errors()[0].GetMessage());
			AssertKeyValuePairInMap(result, "root", "11.22.33.44");
			AssertKeyValuePairInMap(result, "extension", "extensionString");
			AssertKeyValuePairInMap(result, "use", "BUS");
			AssertKeyValuePairInMap(result, "specializationType", "II.BUS");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForII_BUS_UnnecessarySpecializationType()
		{
			Identifier ii = new Identifier("11.22.33.44", "extensionString");
			II iiHl7 = new IIImpl();
			iiHl7.DataType = StandardDataType.II_OID;
			ModelToXmlResult modelToXmlResult = new ModelToXmlResult();
			FormatContextImpl context = new FormatContextImpl(modelToXmlResult, null, "name", "II.BUS", null, false, SpecificationVersion
				.R02_04_02, null, null, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(3, result.Count, "map size");
			Assert.IsFalse(modelToXmlResult.GetHl7Errors().IsEmpty(), "errors");
			Assert.AreEqual(1, modelToXmlResult.GetHl7Errors().Count);
			Assert.AreEqual("A specializationType should not be specified for non-abstract type: II.BUS", modelToXmlResult.GetHl7Errors
				()[0].GetMessage());
			AssertKeyValuePairInMap(result, "root", "11.22.33.44");
			AssertKeyValuePairInMap(result, "extension", "extensionString");
			AssertKeyValuePairInMap(result, "use", "BUS");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForValidII_PUBLIC()
		{
			Identifier ii = new Identifier("11.22.33.44", "extensionString");
			II iiHl7 = new IIImpl();
			ModelToXmlResult modelToXmlResult = new ModelToXmlResult();
			FormatContextImpl context = new FormatContextImpl(modelToXmlResult, null, "name", "II.PUBLIC", null, false, SpecificationVersion
				.R02_04_02, null, null, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(4, result.Count, "map size");
			Assert.IsTrue(modelToXmlResult.GetHl7Errors().IsEmpty(), "no errors");
			AssertKeyValuePairInMap(result, "root", "11.22.33.44");
			AssertKeyValuePairInMap(result, "extension", "extensionString");
			AssertKeyValuePairInMap(result, "use", "BUS");
			AssertKeyValuePairInMap(result, "displayable", "true");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForInvalidII_PUBLIC()
		{
			Identifier ii = new Identifier("11.22.33.44", "extensionStrngTooLong");
			II iiHl7 = new IIImpl();
			ModelToXmlResult modelToXmlResult = new ModelToXmlResult();
			FormatContextImpl context = new FormatContextImpl(modelToXmlResult, null, "name", "II.PUBLIC", null, false, SpecificationVersion
				.R02_04_02, null, null, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(4, result.Count, "map size");
			Assert.IsFalse(modelToXmlResult.GetHl7Errors().IsEmpty(), "errors");
			Assert.AreEqual(1, modelToXmlResult.GetHl7Errors().Count);
			Assert.AreEqual("extension 'extensionStrngTooLong' exceeds maximum allowed length of 20.", modelToXmlResult.GetHl7Errors(
				)[0].GetMessage());
			AssertKeyValuePairInMap(result, "root", "11.22.33.44");
			AssertKeyValuePairInMap(result, "extension", "extensionStrngTooLong");
			AssertKeyValuePairInMap(result, "use", "BUS");
			AssertKeyValuePairInMap(result, "displayable", "true");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForValidII_PUBLIC_MR2007()
		{
			Identifier ii = new Identifier("11.22.33.44", "extensionString");
			II iiHl7 = new IIImpl();
			ModelToXmlResult modelToXmlResult = new ModelToXmlResult();
			FormatContextImpl context = new FormatContextImpl(modelToXmlResult, null, "name", "II.PUBLIC", null, false, SpecificationVersion
				.V02R02, null, null, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(3, result.Count, "map size");
			Assert.IsTrue(modelToXmlResult.GetHl7Errors().IsEmpty(), "no errors");
			AssertKeyValuePairInMap(result, "root", "11.22.33.44");
			AssertKeyValuePairInMap(result, "extension", "extensionString");
			AssertKeyValuePairInMap(result, "displayable", "true");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForValidII_PUBLICVER()
		{
			Identifier ii = new Identifier("11.22.33.44", "extensionString", "a_version_string");
			II iiHl7 = new IIImpl();
			ModelToXmlResult modelToXmlResult = new ModelToXmlResult();
			FormatContextImpl context = new FormatContextImpl(modelToXmlResult, null, "name", "II.PUBLICVER", null, false, SpecificationVersion
				.R02_04_02, null, null, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(4, result.Count, "map size");
			Assert.IsTrue(modelToXmlResult.GetHl7Errors().IsEmpty(), "no errors");
			AssertKeyValuePairInMap(result, "root", "11.22.33.44");
			AssertKeyValuePairInMap(result, "extension", "extensionString");
			AssertKeyValuePairInMap(result, "version", "a_version_string");
			AssertKeyValuePairInMap(result, "displayable", "true");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForValidII_BUSVER()
		{
			Identifier ii = new Identifier("11.22.33.44", "extensionString", "a_version_string");
			II iiHl7 = new IIImpl();
			ModelToXmlResult modelToXmlResult = new ModelToXmlResult();
			FormatContextImpl context = new FormatContextImpl(modelToXmlResult, null, "name", "II.BUSVER", null, false, SpecificationVersion
				.R02_04_02, null, null, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(4, result.Count, "map size");
			Assert.IsTrue(modelToXmlResult.GetHl7Errors().IsEmpty(), "no errors");
			AssertKeyValuePairInMap(result, "root", "11.22.33.44");
			AssertKeyValuePairInMap(result, "extension", "extensionString");
			AssertKeyValuePairInMap(result, "version", "a_version_string");
			AssertKeyValuePairInMap(result, "use", "BUS");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsAllFilledIn()
		{
			Identifier ii = new Identifier("11.22.33.44", "extensionString");
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl(new ModelToXmlResult
				(), null, "name", null, null), ii, new IIImpl(ii));
			Assert.AreEqual(2, result.Count, "map size");
			AssertKeyValuePairInMap(result, "root", "11.22.33.44");
			AssertKeyValuePairInMap(result, "extension", "extensionString");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsAllFilledInIncludingSpecializationType()
		{
			Identifier ii = new Identifier("11.22.33.44", "extensionString");
			II iiHl7 = new IIImpl();
			iiHl7.DataType = StandardDataType.II_BUS;
			FormatContextImpl context = new FormatContextImpl(new ModelToXmlResult(), null, "name", "II.BUS_AND_VER", null, true, SpecificationVersion
				.R02_04_02, null, null, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(4, result.Count, "map size");
			AssertKeyValuePairInMap(result, "root", "11.22.33.44");
			AssertKeyValuePairInMap(result, "extension", "extensionString");
			AssertKeyValuePairInMap(result, "specializationType", "II.BUS");
			AssertKeyValuePairInMap(result, "use", "BUS");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsAllFilledInForIiPublicInMr2007()
		{
			Identifier ii = new Identifier("11.22.33.44", "extensionString");
			II iiHl7 = new IIImpl();
			iiHl7.DataType = StandardDataType.II_PUBLIC;
			FormatContextImpl context = new FormatContextImpl(new ModelToXmlResult(), null, "name", "II.PUBLIC", null, true, SpecificationVersion
				.V02R02, null, null, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(3, result.Count, "map size");
			AssertKeyValuePairInMap(result, "root", "11.22.33.44");
			AssertKeyValuePairInMap(result, "extension", "extensionString");
			AssertKeyValuePairInMap(result, "displayable", "true");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsAllFilledInForIiPublicInMr2009()
		{
			Identifier ii = new Identifier("11.22.33.44", "extensionString");
			II iiHl7 = new IIImpl();
			iiHl7.DataType = StandardDataType.II_PUBLIC;
			FormatContextImpl context = new FormatContextImpl(new ModelToXmlResult(), null, "name", "II.PUBLIC", null, true, SpecificationVersion
				.R02_04_03, null, null, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(4, result.Count, "map size");
			AssertKeyValuePairInMap(result, "root", "11.22.33.44");
			AssertKeyValuePairInMap(result, "extension", "extensionString");
			AssertKeyValuePairInMap(result, "displayable", "true");
			AssertKeyValuePairInMap(result, "use", "BUS");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsAllFilledInExcludingSpecializationTypeForCeRx()
		{
			Identifier ii = new Identifier("11.22.33.44", "extensionString");
			II iiHl7 = new IIImpl();
			iiHl7.DataType = StandardDataType.II;
			FormatContextImpl context = new FormatContextImpl(new ModelToXmlResult(), null, "name", "II", null, true, SpecificationVersion
				.V01R04_3, null, null, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(2, result.Count, "map size");
			AssertKeyValuePairInMap(result, "root", "11.22.33.44");
			AssertKeyValuePairInMap(result, "extension", "extensionString");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsAllFilledInExcludingSpecializationTypeForAB()
		{
			Identifier ii = new Identifier("11.22.33.44", "extensionString");
			II iiHl7 = new IIImpl();
			iiHl7.DataType = StandardDataType.II;
			FormatContextImpl context = new FormatContextImpl(new ModelToXmlResult(), null, "name", "II", null, true, SpecificationVersion
				.V02R02_AB, null, null, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(2, result.Count, "map size");
			AssertKeyValuePairInMap(result, "root", "11.22.33.44");
			AssertKeyValuePairInMap(result, "extension", "extensionString");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsAllFilledInWithTypeId()
		{
			Identifier ii = new Identifier("11.22.33.44", "extensionString");
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl(new ModelToXmlResult
				(), null, "name", null, null), ii, new IIImpl(ii));
			Assert.AreEqual(2, result.Count, "map size");
			AssertKeyValuePairInMap(result, "root", "11.22.33.44");
			AssertKeyValuePairInMap(result, "extension", "extensionString");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsRootNotFilled()
		{
			Identifier ii = new Identifier((string)null, "extension");
			ModelToXmlResult xmlResult = new ModelToXmlResult();
			IIImpl dataType = new IIImpl(ii);
			dataType.DataType = StandardDataType.II_BUS;
			new IiPropertyFormatter().Format(new FormatContextImpl(xmlResult, null, "name", "II.BUS", null), dataType);
			Assert.IsFalse(xmlResult.IsValid());
			Assert.AreEqual(1, xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("Attribute \"root\" must be specified for II.BUS", xmlResult.GetHl7Errors()[0].GetMessage());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsExtensionNotFilled()
		{
			Identifier ii = new Identifier("11.22.33.44", null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl(new ModelToXmlResult
				(), null, "name", null, null), ii, new IIImpl(ii));
			Assert.AreEqual(1, result.Count, "map size");
			AssertKeyValuePairInMap(result, "root", "11.22.33.44");
			AssertKeyNotInMap(result, "extension");
		}

		private void AssertKeyValuePairInMap(IDictionary<string, string> map, string key, string value)
		{
			Assert.IsTrue(map.ContainsKey(key), "key " + key + " as expected");
			Assert.AreEqual(value, map.SafeGet(key), "value for key " + key + " as expected");
		}

		private void AssertKeyNotInMap(IDictionary<string, string> map, string key)
		{
			Assert.IsTrue(!map.ContainsKey(key), "key " + key + " as expected");
		}
	}
}
