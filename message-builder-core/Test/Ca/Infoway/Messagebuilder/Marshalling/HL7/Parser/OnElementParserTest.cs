using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class OnElementParserTest : CeRxDomainValueTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			ON on = (ON)new OnElementParser().Parse(CreateContext(), node, null);
			Assert.IsNull(on.Value, "OrganizationName");
			Assert.IsTrue(on.HasNullFlavor(), "has null flavor");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, on.NullFlavor, "NI null flavor"
				);
		}

		private ParseContext CreateContext()
		{
			return ParseContextImpl.Create("ON", typeof(OrganizationName), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			ON on = (ON)new OnElementParser().Parse(CreateContext(), node, null);
			OrganizationName organizationName = on.Value;
			Assert.IsNotNull(organizationName, "OrganizationName");
			Assert.AreEqual(0, organizationName.Parts.Count, "number of name parts");
			Assert.AreEqual(0, organizationName.Uses.Count, "number of name uses");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoWeirdParts()
		{
			XmlNode node = CreateNode("<something>Organization name</something>");
			OrganizationName organizationName = (OrganizationName)new OnElementParser().Parse(CreateContext(), node, null).BareValue;
			Assert.AreEqual(1, organizationName.Parts.Count, "number of name parts");
			AssertNamePartAsExpected("name", organizationName.Parts[0], null, "Organization name");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseAll()
		{
			XmlNode node = CreateNode("<something><prefix>prefix 1</prefix>Organization name<delimiter>,</delimiter><suffix>Inc</suffix></something>"
				);
			OrganizationName organizationName = (OrganizationName)new OnElementParser().Parse(CreateContext(), node, null).BareValue;
			Assert.AreEqual(0, organizationName.Uses.Count, "number of name uses");
			Assert.AreEqual(4, organizationName.Parts.Count, "number of name parts");
			AssertNamePartAsExpected("prefix prefix 1", organizationName.Parts[0], OrganizationNamePartType.PREFIX, "prefix 1");
			AssertNamePartAsExpected("name", organizationName.Parts[1], null, "Organization name");
			AssertNamePartAsExpected("delimiter comma", organizationName.Parts[2], OrganizationNamePartType.DELIMITER, ",");
			AssertNamePartAsExpected("suffix Inc", organizationName.Parts[3], OrganizationNamePartType.SUFFIX, "Inc");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseFailure()
		{
			XmlNode node = CreateNode("<something><monkey>prefix 1</monkey>Organization name<delimiter>,</delimiter><suffix>Inc</suffix></something>"
				);
			try
			{
				new OnElementParser().Parse(CreateContext(), node, null);
				Assert.Fail("expected exception");
			}
			catch (XmlToModelTransformationException e)
			{
				Assert.AreEqual("Unexpected part of type: monkey", e.Message, "message");
			}
		}

		private void AssertNamePartAsExpected(string message, EntityNamePart namePart, NamePartType expectedType, string expectedValue
			)
		{
			Assert.AreEqual(expectedType, namePart.Type, message + " type");
			Assert.AreEqual(expectedValue, namePart.Value, message + " value");
		}
	}
}
