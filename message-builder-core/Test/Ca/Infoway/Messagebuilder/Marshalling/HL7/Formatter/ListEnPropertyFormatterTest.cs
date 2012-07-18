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
	public class ListEnPropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new ListPropertyFormatter().Format(new FormatContextImpl("name", "LIST<EN>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL), new LISTImpl<EN<EntityName>, EntityName>(typeof(ENImpl<EntityName>)));
			AssertXml("null", string.Empty, result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			string result = new ListPropertyFormatter().Format(new FormatContextImpl("name", "LIST<EN>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL), (BareANY)LISTImpl<ANY<object>, object>.Create<EN<EntityName>, EntityName>(typeof(ENImpl<EntityName>), CreateEntityNameList
				()));
			Assert.AreEqual("<name><family>Flinstone</family><given>Fred</given></name>" + SystemUtils.LINE_SEPARATOR + "<name><family>Flinstone</family><given>Wilma</given></name>"
				 + SystemUtils.LINE_SEPARATOR, result, "non null");
		}

		private IList<EntityName> CreateEntityNameList()
		{
			List<EntityName> result = new List<EntityName>();
			EntityName fred = CreateEntityName("Flinstone", "Fred");
			EntityName wilma = CreateEntityName("Flinstone", "Wilma");
			result.Add(fred);
			result.Add(wilma);
			return result;
		}

		private EntityName CreateEntityName(string familiyName, string givenName)
		{
			EntityName personName = new PersonName();
			IList<EntityNamePart> parts = personName.Parts;
			parts.Add(new EntityNamePart(familiyName, PersonNamePartType.FAMILY));
			parts.Add(new EntityNamePart(givenName, PersonNamePartType.GIVEN));
			return personName;
		}
	}
}
