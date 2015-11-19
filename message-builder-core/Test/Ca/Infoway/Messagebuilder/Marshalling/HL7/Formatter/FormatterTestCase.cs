using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
using ILOG.J2CsMapping.Collections.Generics;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	public abstract class FormatterTestCase
	{
		[SetUp]
		public virtual void FormatterTestCaseSetup()
		{
			DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();
			result = new ModelToXmlResult();
		}

		//NUnit does not create a new instance for each test method
		[TearDown]
		public virtual void FormatterTestCaseTearDown()
		{
			CodeResolverRegistry.UnregisterAll();
			this.result.ClearErrors();
		}

		protected ModelToXmlResult result;

		protected virtual void AssertXml(string description, string expected, string actual)
		{
			AssertXml(description, expected, actual, false);
		}

		protected virtual void AssertXml(string description, string expected, string actual, bool ignoreWhitespace)
		{
			if (actual.Contains("<!--"))
			{
				string first = StringUtils.SubstringBefore(actual, "<!--");
				string rest = StringUtils.SubstringAfter(StringUtils.SubstringAfter(actual, "<!--"), "-->");
				actual = first + rest;
			}
			Assert.AreEqual(WhitespaceUtil.NormalizeWhitespace(expected, ignoreWhitespace), WhitespaceUtil.NormalizeWhitespace(actual
				, ignoreWhitespace), description);
		}

		/// <exception cref="ILOG.J2CsMapping.Util.ParseException"></exception>
		protected virtual PlatformDate ParseDate(string date)
		{
			return DateUtils.ParseDate(date, new string[] { "yyyy-MM-dd", "yyyy-MM-dd'T'HH:mm:ss" });
		}

		protected virtual FormatContext GetContext(string name)
		{
			return GetContext(name, null);
		}

		protected virtual FormatContext GetContext(string name, string type)
		{
			return GetContext(name, type, SpecificationVersion.R02_04_03);
		}

		protected virtual FormatContext GetContext(string name, string type, VersionNumber version)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.result, null, name, type, null, null
				, false, version, null, null, null, false);
		}

		protected ICollection<Code> MakeSet(params Code[] codes)
		{
			return new System.Collections.Generic.SortedSet<Code>(Arrays.AsList(codes));
		}

		protected ICollection<string> MakeSet(params string[] strings)
		{
			return new System.Collections.Generic.SortedSet<string>(Arrays.AsList(strings));
		}

		protected IList<TelecommunicationAddress> MakeTelecommunicationAddressList(params string[] strings)
		{
			IList<TelecommunicationAddress> result = new List<TelecommunicationAddress>();
			foreach (string s in strings)
			{
				TelecommunicationAddress address = new TelecommunicationAddress();
				address.Address = s;
				address.UrlScheme = CeRxDomainTestValues.MAILTO;
				result.Add(address);
			}
			return result;
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

		protected virtual string AddLineSeparator(string value)
		{
			return value + SystemUtils.LINE_SEPARATOR;
		}

		protected virtual string RemoveErrorComments(string result)
		{
			return System.Text.RegularExpressions.Regex.Replace(result, "<!--(.*?)-->" + SystemUtils.LINE_SEPARATOR, string.Empty);
		}
	}
}
