using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class OnR2PropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new EnR2PropertyFormatter().Format(GetContext("name", "ON"), new ONImpl(null));
			Assert.AreEqual("<name nullFlavor=\"NI\"/>", result.Trim(), "named null format");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			EnR2PropertyFormatter formatter = new EnR2PropertyFormatter();
			OrganizationName organizationName = new OrganizationName();
			organizationName.AddNamePart(new EntityNamePart("Organization"));
			string result = formatter.Format(GetContext("name", "ON"), new ONImpl(organizationName));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("something in text node", "<name>Organization</name>", result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullMultipleNameParts()
		{
			EnR2PropertyFormatter formatter = new EnR2PropertyFormatter();
			OrganizationName organizationName = new OrganizationName();
			organizationName.AddNamePart(new EntityNamePart("prefix", OrganizationNamePartType.PREFIX));
			organizationName.AddNamePart(new EntityNamePart("Organization"));
			organizationName.AddNamePart(new EntityNamePart(",", OrganizationNamePartType.DELIMITER));
			organizationName.AddNamePart(new EntityNamePart("Inc", OrganizationNamePartType.SUFFIX));
			string result = formatter.Format(GetContext("name", "ON"), new ONImpl(organizationName));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("something in text node with goofy sub nodes", "<name><prefix>prefix</prefix>Organization<delimiter>,</delimiter><suffix>Inc</suffix></name>"
				, result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueReservedXmlChars()
		{
			EnR2PropertyFormatter formatter = new EnR2PropertyFormatter();
			OrganizationName organizationName = new OrganizationName();
			organizationName.AddNamePart(new EntityNamePart("<cats think they're > humans & dogs 99% of the time/>"));
			string result = formatter.Format(GetContext("name", "ON"), new ONImpl(organizationName));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("something in text node", "<name>&lt;cats think they&apos;re &gt; humans &amp; dogs 99% of the time/&gt;</name>"
				, result, true);
		}
	}
}
