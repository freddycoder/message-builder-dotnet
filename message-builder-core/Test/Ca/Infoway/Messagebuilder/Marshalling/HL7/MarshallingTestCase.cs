using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Terminology;
using Ca.Infoway.Messagebuilder.Util.Xml;
using ILOG.J2CsMapping.Text;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	public abstract class MarshallingTestCase
	{
		protected static readonly string FULL_DATE_TIME = "yyyy-MM-dd'T'HH:mm:ss";

		protected static readonly string FULL_DATE = "yyyy-MM-dd";

		protected XmlToModelResult xmlResult;

		protected TrivialCodeResolver resolver;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			this.resolver = new TrivialCodeResolver();
			CodeResolverRegistry.Register(resolver);
			this.xmlResult = new XmlToModelResult();
		}

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.TearDown]
		public virtual void TearDown()
		{
			CodeResolverRegistry.UnregisterAll();
		}

		/// <exception cref="org.xml.sax.SAXException"></exception>
		protected virtual XmlNode CreateNode(string @string)
		{
			return new DocumentFactory().CreateFromString(@string).DocumentElement;
		}

		protected static void AssertXml(string description, string expected, string actual)
		{
			if (actual.Contains("<!--"))
			{
				string first = StringUtils.SubstringBefore(actual, "<!--");
				string rest = StringUtils.SubstringAfter(StringUtils.SubstringAfter(actual, "<!--"), "-->");
				actual = first + rest;
			}
			Assert.AreEqual(FormatXml(expected), FormatXml(System.Text.RegularExpressions.Regex.Replace(actual, "\\s+<", "<")), description
				);
		}

		private static string FormatXml(string value)
		{
			return System.Text.RegularExpressions.Regex.Replace(value, "><", ">" + SystemUtils.LINE_SEPARATOR + "<").Trim();
		}

		protected virtual void AssertDateEquals(string description, string pattern, PlatformDate expected, PlatformDate actual)
		{
			Assert.IsNotNull(actual, description + " not null");
			DateFormat format = DateUtil.Instance(pattern);
			Assert.AreEqual(format.Format(expected), format.Format(actual), description);
		}
	}
}
