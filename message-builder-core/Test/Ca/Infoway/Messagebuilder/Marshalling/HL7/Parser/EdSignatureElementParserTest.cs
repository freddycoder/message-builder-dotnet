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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */


using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class EdSignatureElementParserTest : CeRxDomainValueTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			ED<string> ed = (ED<string>)new EdSignatureElementParser().Parse(CreateEdContext(), node, null);
			Assert.IsNull(ed.Value, "signature is null");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, ed.NullFlavor, "null flavor");
		}

		private ParseContext CreateEdContext()
		{
			return ParseContextImpl.Create("ED.SIGNATURE", typeof(string), SpecificationVersion.V02R02, null, null, null, null, null, 
				false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			TestInvalidNode(CreateNode("<something/>"));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTextNode()
		{
			TestInvalidNode(CreateNode("<something>signatureText</something>"));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseWrongChildNode()
		{
			TestInvalidNode(CreateNode("<something>" + "  <notSignature></notSignature>" + "</something>"));
		}

		/// <exception cref="System.Exception"></exception>
		public virtual void TestInvalidNode(XmlNode invalidNode)
		{
			XmlToModelResult xmlResult = new XmlToModelResult();
			string parseResult = (string)new EdSignatureElementParser().Parse(CreateEdContext(), invalidNode, xmlResult).BareValue;
			Assert.IsNull(parseResult, "parse result");
			Assert.AreEqual(2, xmlResult.GetHl7Errors().Count, "HL7 error count");
			Hl7Error hl7Error = xmlResult.GetHl7Errors()[0];
			Assert.AreEqual("Attribute mediaType must be included with a value of \"text/xml\" for ED.SIGNATURE", hl7Error.GetMessage
				(), "error message");
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, hl7Error.GetHl7ErrorCode(), "error message code");
			hl7Error = xmlResult.GetHl7Errors()[1];
			Assert.AreEqual("Expected ED.SIGNATURE node to have a child element named signature", hl7Error.GetMessage(), "error message"
				);
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, hl7Error.GetHl7ErrorCode(), "error message code");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidNode()
		{
			XmlNode node = CreateNode("<something mediaType=\"text/xml\">" + "  <signature>signatureText</signature>" + "</something>"
				);
			Assert.AreEqual("signatureText", new EdSignatureElementParser().Parse(CreateEdContext(), node, null).BareValue, "signature"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptySignatureNode()
		{
			XmlNode node = CreateNode("<something mediaType=\"text/xml\">" + "  <signature></signature>" + "</something>");
			Assert.AreEqual(string.Empty, new EdSignatureElementParser().Parse(CreateEdContext(), node, null).BareValue, "signature");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptySignatureNodeAgain()
		{
			XmlNode node = CreateNode("<something mediaType=\"text/xml\">" + "  <signature/>" + "</something>");
			Assert.AreEqual(string.Empty, new EdSignatureElementParser().Parse(CreateEdContext(), node, null).BareValue, "signature");
		}
	}
}
