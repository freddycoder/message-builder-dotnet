using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class OnPropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new OnPropertyFormatter().Format(GetContext("name"), new ONImpl(null));
			Assert.AreEqual("<name nullFlavor=\"NI\"/>", result.Trim(), "named null format");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			OnPropertyFormatter formatter = new OnPropertyFormatter();
			OrganizationName organizationName = new OrganizationName();
			organizationName.AddNamePart(new EntityNamePart("Organization"));
			string result = formatter.Format(GetContext("name"), new ONImpl(organizationName));
			Assert.AreEqual("<name>Organization</name>", result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullMultipleNameParts()
		{
			OnPropertyFormatter formatter = new OnPropertyFormatter();
			OrganizationName organizationName = new OrganizationName();
			organizationName.AddNamePart(new EntityNamePart("prefix", OrganizationNamePartType.PREFIX));
			organizationName.AddNamePart(new EntityNamePart("Organization"));
			organizationName.AddNamePart(new EntityNamePart(",", OrganizationNamePartType.DELIMITER));
			organizationName.AddNamePart(new EntityNamePart("Inc", OrganizationNamePartType.SUFFIX));
			string result = formatter.Format(GetContext("name"), new ONImpl(organizationName));
			Assert.AreEqual("<name><prefix>prefix</prefix>Organization<delimiter>,</delimiter><suffix>Inc</suffix></name>", result.Trim
				(), "something in text node with goofy sub nodes");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueReservedXmlChars()
		{
			OnPropertyFormatter formatter = new OnPropertyFormatter();
			OrganizationName organizationName = new OrganizationName();
			organizationName.AddNamePart(new EntityNamePart("<cats think they're > humans & dogs 99% of the time/>"));
			string result = formatter.Format(GetContext("name"), new ONImpl(organizationName));
			Assert.AreEqual("<name>&lt;cats think they&apos;re &gt; humans &amp; dogs 99% of the time/&gt;</name>".Trim(), result.Trim
				(), "something in text node");
		}
	}
}
