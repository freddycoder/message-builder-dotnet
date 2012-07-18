using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using ILOG.J2CsMapping.Collections.Generics;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	public abstract class FormatterTestCase
	{
		protected virtual void AssertXml(string description, string expected, string actual)
		{
			if (actual.Contains("<!--"))
			{
				string first = StringUtils.SubstringBefore(actual, "<!--");
				string rest = StringUtils.SubstringAfter(StringUtils.SubstringAfter(actual, "<!--"), "-->");
				actual = first + rest;
			}
			Assert.AreEqual(WhitespaceUtil.NormalizeWhitespace(expected), WhitespaceUtil.NormalizeWhitespace(actual), description);
		}

		/// <exception cref="ILOG.J2CsMapping.Util.ParseException"></exception>
		protected virtual PlatformDate ParseDate(string date)
		{
			return DateUtils.ParseDate(date, new string[] { "yyyy-MM-dd", "yyyy-MM-dd'T'HH:mm:ss" });
		}

		protected virtual FormatContext GetContext(string name)
		{
			return new FormatContextImpl(name, null, null);
		}

		protected ICollection<Code> MakeSet(params Code[] codes)
		{
            return new System.Collections.Generic.SortedSet<Code>(Arrays.AsList(codes));
		}

		protected ICollection<string> MakeSet(params string[] strings)
		{
            return new System.Collections.Generic.SortedSet<string>(Arrays.AsList(strings));
		}

		protected ICollection<TelecommunicationAddress> MakeTelecommunicationAddressSet(params string[] strings)
		{
			ICollection<TelecommunicationAddress> result = new HashSet<TelecommunicationAddress>();
			foreach (string s in strings)
			{
				TelecommunicationAddress address = new TelecommunicationAddress();
				address.Address = s;
				address.UrlScheme = CeRxDomainTestValues.MAILTO;
				result.Add(address);
			}
			return result;
		}
	}
}
