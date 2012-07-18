using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class SetStringPropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new SetPropertyFormatter().Format(new FormatContextImpl("blah", "SET<ST>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY), new SETImpl<ST, string>(typeof(STImpl), Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION
				));
			AssertXml("null", "<blah nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			string result = new SetPropertyFormatter().Format(new FormatContextImpl("blah", "SET<ST>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY), SETImpl<ANY<object>, object>.Create<ST, string>(typeof(STImpl), MakeSet("Fred", "Wilma")));
			AssertXml("non null", "<blah>Fred</blah><blah>Wilma</blah>", result);
		}
	}
}
