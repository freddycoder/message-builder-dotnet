using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[TestFixture]
	public class OnR2ElementParserTest : CeRxDomainValueTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			ON on = (ON)new OnR2ElementParser().Parse(CreateContext(), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
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
			ON on = (ON)new OnR2ElementParser().Parse(CreateContext(), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
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
			OrganizationName organizationName = (OrganizationName)new OnR2ElementParser().Parse(CreateContext(), node, this.xmlResult
				).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(1, organizationName.Parts.Count, "number of name parts");
			AssertNamePartAsExpected("name", organizationName.Parts[0], null, "Organization name");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseAll()
		{
			XmlNode node = CreateNode("<something>" + "<prefix>prefix 1</prefix>" + "Organization name" + "<delimiter>,</delimiter>" 
				+ "<suffix>Inc</suffix>" + "<validTime><low value=\"20060403\"/><high value=\"20131127\"/></validTime>" + "</something>"
				);
			OrganizationName organizationName = (OrganizationName)new OnR2ElementParser().Parse(CreateContext(), node, this.xmlResult
				).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(0, organizationName.Uses.Count, "number of name uses");
			Assert.AreEqual(4, organizationName.Parts.Count, "number of name parts");
			Assert.IsNotNull(organizationName.ValidTime);
			Assert.AreEqual(DateUtil.GetDate(2006, 3, 3), organizationName.ValidTime.Low);
			Assert.AreEqual(DateUtil.GetDate(2013, 10, 27), organizationName.ValidTime.High);
			AssertNamePartAsExpected("prefix prefix 1", organizationName.Parts[0], OrganizationNamePartType.PREFIX, "prefix 1");
			AssertNamePartAsExpected("name", organizationName.Parts[1], null, "Organization name");
			AssertNamePartAsExpected("delimiter comma", organizationName.Parts[2], OrganizationNamePartType.DELIMITER, ",");
			AssertNamePartAsExpected("suffix Inc", organizationName.Parts[3], OrganizationNamePartType.SUFFIX, "Inc");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseAllWithValidTimeIncorrectlyPlaced()
		{
			XmlNode node = CreateNode("<something>" + "<prefix>prefix 1</prefix>" + "<validTime><low value=\"20060403\"/><high value=\"20131127\"/></validTime>"
				 + "Organization name" + "<delimiter>,</delimiter>" + "<suffix>Inc</suffix>" + "</something>");
			OrganizationName organizationName = (OrganizationName)new OnR2ElementParser().Parse(CreateContext(), node, this.xmlResult
				).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.IsTrue(this.xmlResult.GetHl7Errors()[0].GetMessage().Contains("validTime"));
			Assert.AreEqual(0, organizationName.Uses.Count, "number of name uses");
			Assert.AreEqual(4, organizationName.Parts.Count, "number of name parts");
			Assert.IsNotNull(organizationName.ValidTime);
			Assert.AreEqual(DateUtil.GetDate(2006, 3, 3), organizationName.ValidTime.Low);
			Assert.AreEqual(DateUtil.GetDate(2013, 10, 27), organizationName.ValidTime.High);
			AssertNamePartAsExpected("prefix prefix 1", organizationName.Parts[0], OrganizationNamePartType.PREFIX, "prefix 1");
			AssertNamePartAsExpected("name", organizationName.Parts[1], null, "Organization name");
			AssertNamePartAsExpected("delimiter comma", organizationName.Parts[2], OrganizationNamePartType.DELIMITER, ",");
			AssertNamePartAsExpected("suffix Inc", organizationName.Parts[3], OrganizationNamePartType.SUFFIX, "Inc");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseAllWithLsQualifier()
		{
			XmlNode node = CreateNode("<name>" + "  <prefix qualifier=\"LS\">IncCo</prefix>" + "</name>");
			OrganizationName orgName = (OrganizationName)new OnR2ElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsTrue(orgName.Uses.IsEmpty());
			Assert.AreEqual(1, orgName.Parts.Count, "number of name parts");
			AssertNamePartAsExpected("prefix", orgName.Parts[0], OrganizationNamePartType.PREFIX, "IncCo");
			Assert.AreEqual(orgName.Parts[0].Qualifier.CodeValue, "LS");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseDisallowedPartType()
		{
			XmlNode node = CreateNode("<something><prefix>prefix 1</prefix>Organization name<delimiter>,</delimiter><given>Inc</given></something>"
				);
			OrganizationName organizationName = (OrganizationName)new OnR2ElementParser().Parse(CreateContext(), node, this.xmlResult
				).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.IsTrue(this.xmlResult.GetHl7Errors()[0].GetMessage().Contains("given"));
			Assert.AreEqual(0, organizationName.Uses.Count, "number of name uses");
			Assert.AreEqual(3, organizationName.Parts.Count, "number of name parts");
			AssertNamePartAsExpected("prefix prefix 1", organizationName.Parts[0], OrganizationNamePartType.PREFIX, "prefix 1");
			AssertNamePartAsExpected("name", organizationName.Parts[1], null, "Organization name");
			AssertNamePartAsExpected("delimiter comma", organizationName.Parts[2], OrganizationNamePartType.DELIMITER, ",");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseFailure()
		{
			XmlNode node = CreateNode("<something><monkey>prefix 1</monkey>Organization name<delimiter>,</delimiter><suffix>Inc</suffix></something>"
				);
			new OnR2ElementParser().Parse(CreateContext(), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.IsTrue(this.xmlResult.GetHl7Errors()[0].GetMessage().Contains("monkey"));
		}

		private void AssertNamePartAsExpected(string message, EntityNamePart namePart, NamePartType expectedType, string expectedValue
			)
		{
			Assert.AreEqual(expectedType, namePart.Type, message + " type");
			Assert.AreEqual(expectedValue, namePart.Value, message + " value");
		}
	}
}
