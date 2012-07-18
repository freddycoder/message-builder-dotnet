using System.Collections.Generic;
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
	public class PnElementParserTest : MarshallingTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			PN pn = (PN)new PnElementParser().Parse(CreateContext(), node, null);
			Assert.IsNull(pn.Value, "PersonName");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, pn.NullFlavor, "null flavor");
		}

		private ParseContext CreateContext()
		{
			return ParserContextImpl.Create("PN", typeof(PersonName), SpecificationVersion.NEWFOUNDLAND, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			PersonName personName = (PersonName)new PnElementParser().Parse(null, node, null).BareValue;
			Assert.IsNotNull(personName, "PersonName");
			Assert.AreEqual(0, personName.Parts.Count, "number of name parts");
			Assert.AreEqual(0, personName.Uses.Count, "number of name uses");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseSimpleNameNode()
		{
			XmlNode node = CreateNode("<something use=\"L\">John Doe</something>");
			PersonName personName = (PersonName)new PnElementParser().Parse(null, node, null).BareValue;
			Assert.IsNotNull(personName, "PersonName");
			Assert.AreEqual(1, personName.Parts.Count, "number of name parts");
			Assert.AreEqual("John Doe", personName.Parts[0].Value, "name");
			Assert.IsNull(personName.Parts[0].Type);
			ICollection<EntityNameUse> uses = personName.Uses;
			Assert.AreEqual(1, uses.Count, "number of name uses");
			Assert.AreEqual("L", new List<EntityNameUse>(uses)[0].CodeValue, "name use");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParsePrefixes()
		{
			XmlNode node = CreateNode("<something>" + "  <prefix>Mr.</prefix>" + "</something>");
			PersonName personName = (PersonName)new PnElementParser().Parse(null, node, null).BareValue;
			Assert.AreEqual(1, personName.Parts.Count, "number of name parts");
			AssertNamePartAsExpected("prefix Mr", personName.Parts[0], PersonNamePartType.PREFIX, "Mr.", null);
			node = CreateNode("<something>" + "  <prefix>Mr.</prefix>" + "  <prefix>Mrs.</prefix>" + "</something>");
			personName = (PersonName)new PnElementParser().Parse(null, node, null).BareValue;
			Assert.AreEqual(2, personName.Parts.Count, "number of name partsd second time");
			AssertNamePartAsExpected("prefix Mr", personName.Parts[0], PersonNamePartType.PREFIX, "Mr.", null);
			AssertNamePartAsExpected("prefix Mrs", personName.Parts[1], PersonNamePartType.PREFIX, "Mrs.", null);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseAll()
		{
			XmlNode node = CreateNode("<something>" + "  <prefix>Mr.</prefix>" + "  <given qualifier=\"IN\">John</given>" + "  <given>Jimmy</given>"
				 + "  <family qualifier=\"IN\">Jones</family>" + "  <suffix>ESQ</suffix>" + "</something>");
			PersonName personName = (PersonName)new PnElementParser().Parse(null, node, null).BareValue;
			Assert.AreEqual(0, personName.Uses.Count, "number of name uses");
			Assert.AreEqual(5, personName.Parts.Count, "number of name parts");
			AssertNamePartAsExpected("prefix Mr", personName.Parts[0], PersonNamePartType.PREFIX, "Mr.", null);
			AssertNamePartAsExpected("given John", personName.Parts[1], PersonNamePartType.GIVEN, "John", "IN");
			AssertNamePartAsExpected("given Jimmy", personName.Parts[2], PersonNamePartType.GIVEN, "Jimmy", null);
			AssertNamePartAsExpected("family Jones", personName.Parts[3], PersonNamePartType.FAMILY, "Jones", "IN");
			AssertNamePartAsExpected("suffix ESQ", personName.Parts[4], PersonNamePartType.SUFFIX, "ESQ", null);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseAllPlusUntypedValue()
		{
			XmlNode node = CreateNode("<name use=\"L\">Prime Minister of Canada" + "  <family>Landry</family>" + "  <prefix>MR.</prefix>"
				 + "  <suffix>III</suffix>" + "  <given>Chris</given>" + "  <given>William</given>" + "  <given qualifier=\"IN\">A.</given>"
				 + "</name>");
			PersonName personName = (PersonName)new PnElementParser().Parse(null, node, null).BareValue;
			Assert.AreEqual(1, personName.Uses.Count, "number of name uses");
			Assert.AreEqual(7, personName.Parts.Count, "number of name parts");
			AssertNamePartAsExpected("Untyped Prime Minister of Canada", personName.Parts[0], null, "Prime Minister of Canada", null);
			AssertNamePartAsExpected("family Landry", personName.Parts[1], PersonNamePartType.FAMILY, "Landry", null);
			AssertNamePartAsExpected("prefix MR.", personName.Parts[2], PersonNamePartType.PREFIX, "MR.", null);
			AssertNamePartAsExpected("suffix III", personName.Parts[3], PersonNamePartType.SUFFIX, "III", null);
			AssertNamePartAsExpected("given Chris", personName.Parts[4], PersonNamePartType.GIVEN, "Chris", null);
			AssertNamePartAsExpected("given William", personName.Parts[5], PersonNamePartType.GIVEN, "William", null);
			AssertNamePartAsExpected("given A.", personName.Parts[6], PersonNamePartType.GIVEN, "A.", "IN");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseFailure()
		{
			XmlNode node = CreateNode("<something><monkey>prefix 1</monkey>Organization name<delimiter>,</delimiter><suffix>Inc</suffix></something>"
				);
			try
			{
				new PnElementParser().Parse(null, node, null);
				Assert.Fail("expected exception");
			}
			catch (XmlToModelTransformationException e)
			{
				Assert.AreEqual("Unexpected part of type: monkey", e.Message, "message");
			}
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyPrefix()
		{
			XmlNode node = CreateNode("<something>" + "  <prefix></prefix>" + "</something>");
			XmlToModelResult xmlResult = new XmlToModelResult();
			PersonName personName = (PersonName)new PnElementParser().Parse(null, node, xmlResult).BareValue;
			Assert.AreEqual(0, personName.Parts.Count, "number of name parts");
			Assert.AreEqual(1, xmlResult.GetHl7Errors().Count, "number of warnings");
			Assert.AreEqual("Expected PN child node \"prefix\" to have a text node", xmlResult.GetHl7Errors()[0].GetMessage(), "warnings"
				);
			Assert.AreEqual("/something/prefix", xmlResult.GetHl7Errors()[0].GetPath(), "warnings");
		}

		private void AssertNamePartAsExpected(string message, EntityNamePart namePart, NamePartType expectedType, string expectedValue
			, string expectedQualifier)
		{
			Assert.AreEqual(expectedType, namePart.Type, message + " type");
			Assert.AreEqual(expectedValue, namePart.Value, message + " value");
			Assert.AreEqual(expectedQualifier, namePart.Qualifier, message + " qualifier");
		}
	}
}
