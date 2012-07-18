using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class SetCdPropertyFormatterTest : FormatterTestCase
	{
		private SetPropertyFormatter formatter;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			this.formatter = new SetPropertyFormatter();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = this.formatter.Format(new FormatContextImpl("blah", "SET<CD>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY), new SETImpl<CD, Code>(typeof(CDImpl), Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION
				));
			AssertXml("null", "<blah nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNullNotMandatory()
		{
			string result = this.formatter.Format(new FormatContextImpl("blah", "SET<CD>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL), null);
			AssertXml("null", string.Empty, result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			string result = this.formatter.Format(new FormatContextImpl("blah", "SET<CD>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY), SETImpl<ANY<object>, object>.Create<CD, Code>(typeof(CDImpl), MakeSet(Ca.Infoway.Messagebuilder.Datatype.Lang.UnitsOfMeasureCaseSensitive
				.CENTIMETRE, Ca.Infoway.Messagebuilder.Datatype.Lang.UnitsOfMeasureCaseSensitive.KILOGRAM)));
			AssertXml("non null", "<blah code=\"cm\" codeSystem=\"2.16.840.1.113883.5.141\"/><blah code=\"kg\" codeSystem=\"2.16.840.1.113883.5.141\"/>"
				, result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueEmptySet()
		{
			string result = this.formatter.Format(new FormatContextImpl("blah", "SET<CD>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED), SETImpl<ANY<object>, object>.Create<CD, Code>(typeof(CDImpl), new HashSet<Code>()));
			AssertXml("non null", "<blah nullFlavor=\"NI\"/>", result);
		}
	}
}
