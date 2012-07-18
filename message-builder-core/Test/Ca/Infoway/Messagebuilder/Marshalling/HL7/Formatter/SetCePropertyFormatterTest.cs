using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class SetCePropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new SetPropertyFormatter().Format(new FormatContextImpl("blah", "SET<CE>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY), new SETImpl<CE, Code>(typeof(CEImpl), Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION
				));
			AssertXml("null", "<blah nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			string result = new SetPropertyFormatter().Format(new FormatContextImpl("blah", "SET<CE>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY), SETImpl<ANY<object>, object>.Create<CE, Code>(typeof(CEImpl), MakeSet(Ca.Infoway.Messagebuilder.Datatype.Lang.UnitsOfMeasureCaseSensitive
				.CENTIMETRE, Ca.Infoway.Messagebuilder.Datatype.Lang.UnitsOfMeasureCaseSensitive.KILOGRAM)));
			AssertXml("non null", "<blah code=\"cm\" codeSystem=\"2.16.840.1.113883.5.141\"/><blah code=\"kg\" codeSystem=\"2.16.840.1.113883.5.141\"/>"
				, result);
		}
	}
}
