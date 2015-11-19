using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using Ca.Infoway.Messagebuilder.Platform;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class IiR2PropertyFormatterTest : MarshallingTestCase
	{
		private class TestableIiR2PropertyFormatter : IiR2PropertyFormatter, TestableAbstractValueNullFlavorPropertyFormatter<Identifier
			>
		{
			public virtual IDictionary<string, string> GetAttributeNameValuePairsForTest(FormatContext context, Identifier t, BareANY
				 bareAny)
			{
				return base.GetAttributeNameValuePairs(context, t, bareAny);
			}
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForValidII()
		{
			Identifier ii = new Identifier("11.22.33.44", "extensionString");
			ii.AssigningAuthorityName = "aaName";
			ii.Displayable = "d_true";
			II iiHl7 = new IIImpl();
			iiHl7.DataType = StandardDataType.II;
			ModelToXmlResult modelToXmlResult = new ModelToXmlResult();
			Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(modelToXmlResult, null, "name", "II", null, null, false, SpecificationVersion.R02_04_02, null, null, null, false);
			IDictionary<string, string> result = new IiR2PropertyFormatterTest.TestableIiR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(context, ii, iiHl7);
			Assert.AreEqual(4, result.Count, "map size");
			Assert.IsTrue(modelToXmlResult.GetHl7Errors().IsEmpty(), "no errors");
			AssertKeyValuePairInMap(result, "root", "11.22.33.44");
			AssertKeyValuePairInMap(result, "extension", "extensionString");
			AssertKeyValuePairInMap(result, "assigningAuthorityName", "aaName");
			AssertKeyValuePairInMap(result, "displayable", "d_true");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForValidIICeRx()
		{
			Identifier ii = new Identifier("11.22.33.44", "extensionString");
			II iiHl7 = new IIImpl();
			ModelToXmlResult modelToXmlResult = new ModelToXmlResult();
			Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(modelToXmlResult, null, "name", "II", null, null, false, SpecificationVersion.V01R04_3, null, null, null, false);
			IDictionary<string, string> result = new IiR2PropertyFormatterTest.TestableIiR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(context, ii, iiHl7);
			Assert.AreEqual(2, result.Count, "map size");
			Assert.IsTrue(modelToXmlResult.GetHl7Errors().IsEmpty(), "no errors");
			AssertKeyValuePairInMap(result, "root", "11.22.33.44");
			AssertKeyValuePairInMap(result, "extension", "extensionString");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForValidIIAsUuid()
		{
			UUID randomUUID = UUID.RandomUUID();
			Identifier ii = new Identifier(randomUUID.ToString());
			II iiHl7 = new IIImpl();
			ModelToXmlResult modelToXmlResult = new ModelToXmlResult();
			Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(modelToXmlResult, null, "name", "II", null, null, false, SpecificationVersion.R02_04_02, null, null, null, false);
			IDictionary<string, string> result = new IiR2PropertyFormatterTest.TestableIiR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(context, ii, iiHl7);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(modelToXmlResult.GetHl7Errors().IsEmpty(), "no errors");
			AssertKeyValuePairInMap(result, "root", randomUUID.ToString());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForInvalidIIAsUuid()
		{
			UUID randomUUID = UUID.RandomUUID();
			string root = randomUUID.ToString() + "_zyx";
			Identifier ii = new Identifier(root);
			II iiHl7 = new IIImpl();
			ModelToXmlResult modelToXmlResult = new ModelToXmlResult();
			Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(modelToXmlResult, null, "name", "II", null, null, false, SpecificationVersion.R02_04_02, null, null, null, false);
			IDictionary<string, string> result = new IiR2PropertyFormatterTest.TestableIiR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(context, ii, iiHl7);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsFalse(modelToXmlResult.GetHl7Errors().IsEmpty());
			Assert.AreEqual(1, modelToXmlResult.GetHl7Errors().Count);
			Assert.AreEqual("root '" + root + "' must conform to be either a UUID, RUID, or OID.", modelToXmlResult.GetHl7Errors()[0]
				.GetMessage());
			AssertKeyValuePairInMap(result, "root", root);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForValidIIAsOid()
		{
			Identifier ii = new Identifier("11.22.33.44");
			II iiHl7 = new IIImpl();
			ModelToXmlResult modelToXmlResult = new ModelToXmlResult();
			Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(modelToXmlResult, null, "name", "II", null, null, false, SpecificationVersion.R02_04_02, null, null, null, false);
			IDictionary<string, string> result = new IiR2PropertyFormatterTest.TestableIiR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(context, ii, iiHl7);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(modelToXmlResult.GetHl7Errors().IsEmpty(), "no errors");
			AssertKeyValuePairInMap(result, "root", "11.22.33.44");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForInvalidIIAsOid()
		{
			Identifier ii = new Identifier("311.22.33.44");
			II iiHl7 = new IIImpl();
			ModelToXmlResult modelToXmlResult = new ModelToXmlResult();
			Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(modelToXmlResult, null, "name", "II", null, null, false, SpecificationVersion.R02_04_02, null, null, null, false);
			IDictionary<string, string> result = new IiR2PropertyFormatterTest.TestableIiR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(context, ii, iiHl7);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsFalse(modelToXmlResult.IsValid(), "one error");
			Assert.AreEqual(1, modelToXmlResult.GetHl7Errors().Count, "one error");
			AssertKeyValuePairInMap(result, "root", "311.22.33.44");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsAllFilledIn()
		{
			Identifier ii = new Identifier("11.22.33.44", "extensionString");
			IDictionary<string, string> result = new IiR2PropertyFormatterTest.TestableIiR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(new ModelToXmlResult(), null, "name", null, null
				, null, false), ii, new IIImpl(ii));
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
			dataType.DataType = StandardDataType.II;
			new IiR2PropertyFormatterTest.TestableIiR2PropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(xmlResult, null, "name", "II", null, null, false), dataType);
			Assert.IsFalse(xmlResult.IsValid());
			Assert.AreEqual(1, xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("Attribute \"root\" must be specified for II", xmlResult.GetHl7Errors()[0].GetMessage());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsExtensionNotFilled()
		{
			Identifier ii = new Identifier("11.22.33.44", null);
			IDictionary<string, string> result = new IiR2PropertyFormatterTest.TestableIiR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(new ModelToXmlResult(), null, "name", null, null
				, null, false), ii, new IIImpl(ii));
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
