using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// Currently this is a copy of the CS test, since the class is identical
	/// to the CS class.
	/// </summary>
	/// <remarks>
	/// Currently this is a copy of the CS test, since the class is identical
	/// to the CS class. This will likely change in the future.
	/// </remarks>
	[TestFixture]
	public class CvPropertyFormatterTest : FormatterTestCase
	{
		private class TestableCvPropertyFormatter : CvPropertyFormatter, TestableAbstractValueNullFlavorPropertyFormatter<Code>
		{
			public virtual IDictionary<string, string> GetAttributeNameValuePairsForTest(FormatContext context, Code t, BareANY bareAny
				)
			{
				return base.GetAttributeNameValuePairs(context, t, bareAny);
			}
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsNullValue()
		{
			IDictionary<string, string> result = new CvPropertyFormatterTest.TestableCvPropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.result, null, "name", null, null, null, 
				false, SpecificationVersion.R02_04_02, null, null, CodingStrength.CNE, false), null, null);
			Assert.AreEqual(0, result.Count, "map size");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairs()
		{
			// used as expected: an enumerated object is passed in
			IDictionary<string, string> result = new CvPropertyFormatterTest.TestableCvPropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.result, null, "name", null, null, null, 
				false, SpecificationVersion.R02_04_02, null, null, CodingStrength.CNE, false), CeRxDomainTestValues.CENTIMETRE, null);
			Assert.AreEqual(2, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("code"), "key as expected");
			Assert.AreEqual("cm", result.SafeGet("code"), "value as expected");
			Assert.IsTrue(result.ContainsKey("codeSystem"), "key as expected");
			Assert.AreEqual("1.2.3.4", result.SafeGet("codeSystem"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestHandlingOfTrivialCodes()
		{
			string result = new CvPropertyFormatterTest.TestableCvPropertyFormatter().Format(GetContext("name"), new CVImpl(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
				.NO_INFORMATION));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name nullFlavor=\"NI\"/>", StringUtils.Trim(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestHandlingOfSimpleCodes()
		{
			string result = new CvPropertyFormatterTest.TestableCvPropertyFormatter().Format(GetContext("name"), new CVImpl(CeRxDomainTestValues
				.CENTIMETRE));
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().StartsWith("Could not locate a registered domain type to match "
				));
			Assert.AreEqual("<name code=\"cm\" codeSystem=\"1.2.3.4\"/>", StringUtils.Trim(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestHandlingOfSimpleCodesWithDisplayNameNotForBC()
		{
			CVImpl cvImpl = new CVImpl(CeRxDomainTestValues.CENTIMETRE);
			cvImpl.DisplayName = "testDisplayName";
			string result = new CvPropertyFormatterTest.TestableCvPropertyFormatter().Format(GetContext("name", StandardDataType.CV.Type
				), cvImpl);
			Assert.AreEqual(2, this.result.GetHl7Errors().Count);
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().StartsWith("Could not locate a registered domain type to match "
				));
			Assert.AreEqual("CV should not include the 'displayName' property", this.result.GetHl7Errors()[1].GetMessage());
			Assert.AreEqual("<name code=\"cm\" codeSystem=\"1.2.3.4\" displayName=\"testDisplayName\"/>", StringUtils.Trim(result), "result"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestHandlingOfSimpleCodesWithDisplayNameForBC()
		{
			CVImpl cvImpl = new CVImpl(CeRxDomainTestValues.CENTIMETRE);
			cvImpl.DisplayName = "testDisplayName";
			FormatContext context = GetContext("name", StandardDataType.CV.Type, SpecificationVersion.V02R04_BC);
			string result = new CvPropertyFormatterTest.TestableCvPropertyFormatter().Format(context, cvImpl);
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().StartsWith("Could not locate a registered domain type to match "
				));
			Assert.AreEqual("<name code=\"cm\" codeSystem=\"1.2.3.4\" displayName=\"testDisplayName\"/>", StringUtils.Trim(result), "result"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestHandlingOfSimpleCodesWithDisplayNameForBCWithNullFlavor()
		{
			CVImpl cvImpl = new CVImpl(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NOT_APPLICABLE);
			cvImpl.DisplayName = "testDisplayName";
			FormatContext context = GetContext("name", StandardDataType.CV.Type, SpecificationVersion.V02R04_BC);
			string result = new CvPropertyFormatterTest.TestableCvPropertyFormatter().Format(context, cvImpl);
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual("CV should not include the 'displayName' property (when a nullFlavor)", this.result.GetHl7Errors()[0].GetMessage
				());
			Assert.AreEqual("<name displayName=\"testDisplayName\" nullFlavor=\"NA\"/>", StringUtils.Trim(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestOriginalTextAndNullFlavor()
		{
			CVImpl cv = new CVImpl(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION);
			cv.OriginalText = "some original text";
			string result = new CvPropertyFormatterTest.TestableCvPropertyFormatter().Format(GetContext("name"), cv);
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name nullFlavor=\"NI\"><originalText>some original text</originalText></name>", StringUtils.Trim(result
				), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestOriginalText()
		{
			CVImpl cv = new CVImpl(null);
			cv.OriginalText = "some original text";
			string result = new CvPropertyFormatterTest.TestableCvPropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "CV", null, null, false, SpecificationVersion.R02_04_03, null, null, CodingStrength.CWE, false
				), cv);
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name><originalText>some original text</originalText></name>", StringUtils.Trim(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNoValueAndOptional()
		{
			CVImpl cv = new CVImpl(null);
			string result = new CvPropertyFormatterTest.TestableCvPropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, false, SpecificationVersion
				.R02_04_02, null, null, CodingStrength.CNE, false), cv);
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual(string.Empty, StringUtils.Trim(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNoValueAndMandatory()
		{
			CVImpl cv = new CVImpl(null);
			string result = new CvPropertyFormatterTest.TestableCvPropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, null, false, SpecificationVersion
				.R02_04_02, null, null, CodingStrength.CNE, false), cv);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual("<name/>", StringUtils.Trim(result), "result");
		}
	}
}
