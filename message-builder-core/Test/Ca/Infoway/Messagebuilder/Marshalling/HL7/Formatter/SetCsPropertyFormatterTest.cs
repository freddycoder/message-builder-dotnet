using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class SetCsPropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new SetPropertyFormatter().Format(new FormatContextImpl("blah", "SET<CS>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY), new SETImpl<CS, Code>(typeof(CSImpl), Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION
				));
			AssertXml("null", "<blah nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			string result = new SetPropertyFormatter().Format(new FormatContextImpl("blah", "SET<CS>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY), SETImpl<ANY<object>, object>.Create<CS, Code>(typeof(CSImpl), MakeSet(Ca.Infoway.Messagebuilder.Datatype.Lang.UnitsOfMeasureCaseSensitive
				.CENTIMETRE, Ca.Infoway.Messagebuilder.Datatype.Lang.UnitsOfMeasureCaseSensitive.KILOGRAM)));
			AssertXml("non null", "<blah code=\"cm\"/><blah code=\"kg\"/>", result);
		}
	}
}
