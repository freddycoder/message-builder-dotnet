/**
 * Copyright 2013 Canada Health Infoway, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Author:        $LastChangedBy: tmcgrady $
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
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
			return ParserContextImpl.Create("ON", typeof(OrganizationName), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED);
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
			AssertNamePartAsExpected("delimiter comma", organizationName.Parts[2], OrganizationNamePartType.DELIMETER, ",");
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
