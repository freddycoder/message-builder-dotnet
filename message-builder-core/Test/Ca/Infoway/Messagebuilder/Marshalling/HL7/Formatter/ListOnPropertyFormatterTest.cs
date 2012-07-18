using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class ListOnPropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new ListPropertyFormatter().Format(new FormatContextImpl("name", "LIST<ON>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL), new LISTImpl<ON, OrganizationName>(typeof(ONImpl)));
			AssertXml("null", string.Empty, result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNullMandatory()
		{
			string result = new ListPropertyFormatter().Format(new FormatContextImpl("blah", "LIST<ON>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY), (BareANY)new LISTImpl<ON, OrganizationName>(typeof(ONImpl), Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
				.NO_INFORMATION));
			AssertXml("null", "<blah nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			string result = new ListPropertyFormatter().Format(new FormatContextImpl("name", "LIST<ON>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY), LISTImpl<ANY<object>, object>.Create<ON, OrganizationName>(typeof(ONImpl), CreateOrganizationNameList()));
			Assert.AreEqual("<name>Organization 1</name>" + SystemUtils.LINE_SEPARATOR + "<name>Organization 2</name>" + SystemUtils.
				LINE_SEPARATOR, result, "non null");
		}

		private IList<OrganizationName> CreateOrganizationNameList()
		{
			List<OrganizationName> result = new List<OrganizationName>();
			result.Add(CreateOrganizationName("Organization 1"));
			result.Add(CreateOrganizationName("Organization 2"));
			return result;
		}

		private OrganizationName CreateOrganizationName(string name)
		{
			OrganizationName organizationName = new OrganizationName();
			IList<EntityNamePart> parts = organizationName.Parts;
			parts.Add(new EntityNamePart(name));
			return organizationName;
		}
	}
}
