using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class EnElementParserTest : MarshallingTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			EN<EntityName> en = (EN<EntityName>)new EnElementParser().Parse(CreateContext(), node, this.xmlResult);
			Assert.IsNull(en.Value, "entity name");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, en.NullFlavor, "null flavor");
		}

		private ParseContext CreateContext()
		{
			return ParserContextImpl.Create("EN", typeof(EntityName), SpecificationVersion.NEWFOUNDLAND, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			EntityName entityName = (EntityName)new EnElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue;
			Assert.IsNotNull(entityName, "entity name");
			Assert.AreEqual(0, entityName.Parts.Count, "number of name parts");
			Assert.AreEqual(0, entityName.Uses.Count, "number of name uses");
			Assert.IsTrue(entityName is TrivialName, "returned class");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTrivialName()
		{
			XmlNode node = CreateNode("<something>trivial name</something>");
			EntityName entityName = (EntityName)new EnElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue;
			Assert.IsNotNull(entityName, "entity name");
			Assert.AreEqual(1, entityName.Parts.Count, "number of name parts");
			AssertNamePartAsExpected("name", entityName.Parts[0], null, "trivial name");
			Assert.IsTrue(entityName is TrivialName, "returned class");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseOrganizationName()
		{
			XmlNode node = CreateNode("<something>trivial name<suffix>Inc</suffix></something>");
			EntityName entityName = (EntityName)new EnElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue;
			Assert.IsNotNull(entityName, "entity name");
			Assert.AreEqual(2, entityName.Parts.Count, "number of name parts");
			AssertNamePartAsExpected("name", entityName.Parts[0], null, "trivial name");
			AssertNamePartAsExpected("suffix", entityName.Parts[1], OrganizationNamePartType.SUFFIX, "Inc");
			Assert.IsTrue(entityName is OrganizationName, "returned class");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParsePersonName()
		{
			XmlNode node = CreateNode("<something><given>Steve</given><family>Shaw</family><suffix>Inc</suffix></something>");
			EntityName entityName = (EntityName)new EnElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue;
			Assert.IsNotNull(entityName, "entity name");
			Assert.AreEqual(3, entityName.Parts.Count, "number of name parts");
			AssertNamePartAsExpected("given", entityName.Parts[0], PersonNamePartType.GIVEN, "Steve");
			AssertNamePartAsExpected("family", entityName.Parts[1], PersonNamePartType.FAMILY, "Shaw");
			AssertNamePartAsExpected("suffix", entityName.Parts[2], PersonNamePartType.SUFFIX, "Inc");
			Assert.IsTrue(entityName is PersonName, "returned class");
		}

		private void AssertNamePartAsExpected(string message, EntityNamePart namePart, NamePartType expectedType, string expectedValue
			)
		{
			Assert.AreEqual(expectedType, namePart.Type, message + " type");
			Assert.AreEqual(expectedValue, namePart.Value, message + " value");
		}
	}
}
