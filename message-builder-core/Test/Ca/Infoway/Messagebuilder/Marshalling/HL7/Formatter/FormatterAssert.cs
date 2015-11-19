using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using ILOG.J2CsMapping.Collections.Generics;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	public class FormatterAssert : Assert
	{
		internal static void AssertInvalidUrlScheme(TestableAbstractValueNullFlavorPropertyFormatter<TelecommunicationAddress> formatter
			, Ca.Infoway.Messagebuilder.Domainvalue.URLScheme urlScheme, FormatContext context)
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = urlScheme;
			address.Address = "sometext";
			formatter.GetAttributeNameValuePairsForTest(context, address, new TELImpl());
			Assert.IsFalse(context.GetModelToXmlResult().IsValid());
			Assert.AreEqual(1, context.GetModelToXmlResult().GetHl7Errors().Count);
			Assert.IsTrue(context.GetModelToXmlResult().GetHl7Errors()[0].GetMessage().Contains("Scheme " + urlScheme.CodeValue + " is not valid"
				), "expected message");
		}

		/// <exception cref="System.Exception"></exception>
		internal static void AssertValidUrlScheme(TestableAbstractValueNullFlavorPropertyFormatter<TelecommunicationAddress> formatter
			, Ca.Infoway.Messagebuilder.Domainvalue.URLScheme urlScheme, FormatContext context, string expected)
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = urlScheme;
			address.Address = "someAddress";
			IDictionary<string, string> result = formatter.GetAttributeNameValuePairsForTest(context, address, new TELImpl());
			Assert.IsTrue(context.GetModelToXmlResult().IsValid());
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(expected + address.Address, result.SafeGet("value"), "value as expected");
		}

		public static void AssertContainsSame(string description, ICollection<string> expected, ICollection<string> actual)
		{
			Assert.AreEqual(expected.Count, actual.Count, description + " size");
			foreach (string s in expected)
			{
				actual.Remove(s);
			}
			Assert.AreEqual(0, actual.Count, description + " contains " + expected);
		}

		public static ICollection<string> ToSet(string attribute)
		{
			return new HashSet<string>(Arrays.AsList(StringUtils.Split(attribute)));
		}
	}
}
