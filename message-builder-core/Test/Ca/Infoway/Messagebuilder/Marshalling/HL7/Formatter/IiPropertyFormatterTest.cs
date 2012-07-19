using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class IiPropertyFormatterTest : MarshallingTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsAllFilledIn()
		{
			Identifier ii = new Identifier("rootString", "extensionString");
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl("name", null
				, null), ii, null);
			Assert.AreEqual(2, result.Count, "map size");
			AssertKeyValuePairInMap(result, "root", "rootString");
			AssertKeyValuePairInMap(result, "extension", "extensionString");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsAllFilledInIncludingSpecializationType()
		{
			Identifier ii = new Identifier("rootString", "extensionString");
			II iiHl7 = new IIImpl();
			iiHl7.DataType = StandardDataType.II_BUS;
			FormatContextImpl context = new FormatContextImpl("name", "II.BUS_AND_VER", null, true, SpecificationVersion.R02_04_02, null
				, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(4, result.Count, "map size");
			AssertKeyValuePairInMap(result, "root", "rootString");
			AssertKeyValuePairInMap(result, "extension", "extensionString");
			AssertKeyValuePairInMap(result, "specializationType", "II.BUS");
			AssertKeyValuePairInMap(result, "use", "BUS");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsAllFilledInForIiPublicInMr2007()
		{
			Identifier ii = new Identifier("rootString", "extensionString");
			II iiHl7 = new IIImpl();
			iiHl7.DataType = StandardDataType.II_PUBLIC;
			FormatContextImpl context = new FormatContextImpl("name", "II.PUBLIC", null, true, SpecificationVersion.V02R02, null, null
				);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(3, result.Count, "map size");
			AssertKeyValuePairInMap(result, "root", "rootString");
			AssertKeyValuePairInMap(result, "extension", "extensionString");
			AssertKeyValuePairInMap(result, "displayable", "true");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsAllFilledInForIiPublicInMr2009()
		{
			Identifier ii = new Identifier("rootString", "extensionString");
			II iiHl7 = new IIImpl();
			iiHl7.DataType = StandardDataType.II_PUBLIC;
			FormatContextImpl context = new FormatContextImpl("name", "II.PUBLIC", null, true, SpecificationVersion.R02_04_03, null, 
				null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(4, result.Count, "map size");
			AssertKeyValuePairInMap(result, "root", "rootString");
			AssertKeyValuePairInMap(result, "extension", "extensionString");
			AssertKeyValuePairInMap(result, "displayable", "true");
			AssertKeyValuePairInMap(result, "use", "BUS");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsAllFilledInExcludingSpecializationTypeForCeRx()
		{
			Identifier ii = new Identifier("rootString", "extensionString");
			II iiHl7 = new IIImpl();
			iiHl7.DataType = StandardDataType.II;
			FormatContextImpl context = new FormatContextImpl("name", "II", null, true, SpecificationVersion.V01R04_3, null, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(2, result.Count, "map size");
			AssertKeyValuePairInMap(result, "root", "rootString");
			AssertKeyValuePairInMap(result, "extension", "extensionString");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsAllFilledInExcludingSpecializationTypeForAB()
		{
			Identifier ii = new Identifier("rootString", "extensionString");
			II iiHl7 = new IIImpl();
			iiHl7.DataType = StandardDataType.II;
			FormatContextImpl context = new FormatContextImpl("name", "II", null, true, SpecificationVersion.V02R02_AB, null, null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(context, ii, iiHl7);
			Assert.AreEqual(2, result.Count, "map size");
			AssertKeyValuePairInMap(result, "root", "rootString");
			AssertKeyValuePairInMap(result, "extension", "extensionString");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsAllFilledInWithTypeId()
		{
			Identifier ii = new Identifier("rootString", "extensionString");
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl("name", null
				, null), ii, null);
			Assert.AreEqual(2, result.Count, "map size");
			AssertKeyValuePairInMap(result, "root", "rootString");
			AssertKeyValuePairInMap(result, "extension", "extensionString");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsRootNotFilled()
		{
			Identifier ii = new Identifier((string)null, "extension");
			string format = new IiPropertyFormatter().Format(new FormatContextImpl("name", null, null), new IIImpl(ii));
			Assert.IsTrue(format.Contains("<!-- WARNING:"), "result: " + format);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsExtensionNotFilled()
		{
			Identifier ii = new Identifier("rootString", null);
			IDictionary<string, string> result = new IiPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl("name", null
				, null), ii, null);
			Assert.AreEqual(1, result.Count, "map size");
			AssertKeyValuePairInMap(result, "root", "rootString");
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
