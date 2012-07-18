using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
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
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsNullValue()
		{
			IDictionary<string, string> result = new CvPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl("name", null
				, null), null);
			Assert.AreEqual(0, result.Count, "map size");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairs()
		{
			// used as expected: an enumerated object is passed in
			IDictionary<string, string> result = new CvPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl("name", null
				, null), CeRxDomainTestValues.CENTIMETRE);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("code"), "key as expected");
			Assert.AreEqual("cm", result.SafeGet("code"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestHandlingOfTrivialCodes()
		{
			string result = new CvPropertyFormatter().Format(GetContext("name"), new CVImpl(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
				.NO_INFORMATION));
			Assert.AreEqual("<name nullFlavor=\"NI\"/>", StringUtils.Trim(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestHandlingOfSimpleCodes()
		{
			string result = new CvPropertyFormatter().Format(GetContext("name"), new CVImpl(CeRxDomainTestValues.CENTIMETRE));
			Assert.AreEqual("<name code=\"cm\"/>", StringUtils.Trim(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestOriginalTextAndNullFlavor()
		{
			CVImpl cv = new CVImpl(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION);
			cv.OriginalText = "some original text";
			string result = new CvPropertyFormatter().Format(GetContext("name"), cv);
			Assert.AreEqual("<name nullFlavor=\"NI\"><originalText>some original text</originalText></name>", StringUtils.Trim(result
				), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestOriginalText()
		{
			CVImpl cv = new CVImpl(null);
			cv.OriginalText = "some original text";
			string result = new CvPropertyFormatter().Format(GetContext("name"), cv);
			Assert.AreEqual("<name><originalText>some original text</originalText></name>", StringUtils.Trim(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNoValueAndOptional()
		{
			CVImpl cv = new CVImpl(null);
			string result = new CvPropertyFormatter().Format(new FormatContextImpl("name", null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL), cv);
			Assert.AreEqual(string.Empty, StringUtils.Trim(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNoValueAndMandatory()
		{
			CVImpl cv = new CVImpl(null);
			string result = new CvPropertyFormatter().Format(new FormatContextImpl("name", null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY), cv);
			string lineBreak = Runtime.GetProperty("line.separator");
			Assert.AreEqual("<!-- WARNING: name is a mandatory field, but no value is specified -->" + lineBreak + "<name/>", StringUtils
				.Trim(result), "result");
		}
	}
}
