using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using ILOG.J2CsMapping.Collections.Generics;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	public class FormatterAssert : Assert
	{
		internal static void AssertInvalidUrlScheme(AbstractValueNullFlavorPropertyFormatter<TelecommunicationAddress> formatter, 
			Ca.Infoway.Messagebuilder.Domainvalue.URLScheme urlScheme)
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = urlScheme;
			try
			{
				formatter.GetAttributeNameValuePairs(new FormatContextImpl("name", null, null), address);
				Assert.Fail("expected exception");
			}
			catch (ModelToXmlTransformationException e)
			{
				Assert.IsTrue(e.Message.Contains("URLScheme " + urlScheme.CodeValue + " is not supported"), "expected message");
			}
		}

		/// <exception cref="System.Exception"></exception>
		internal static void AssertValidUrlScheme(AbstractValueNullFlavorPropertyFormatter<TelecommunicationAddress> formatter, Ca.Infoway.Messagebuilder.Domainvalue.URLScheme
			 urlScheme, string expected)
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = urlScheme;
			IDictionary<string, string> result = formatter.GetAttributeNameValuePairs(new FormatContextImpl("name", null, null), address
				);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(expected, result.SafeGet("value"), "value as expected");
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
