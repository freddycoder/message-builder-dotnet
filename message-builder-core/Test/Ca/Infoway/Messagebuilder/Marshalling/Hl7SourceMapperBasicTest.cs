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
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Model.Mock;
using Ca.Infoway.Messagebuilder.Terminology;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Service;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[TestFixture]
	public class Hl7SourceMapperBasicTest
	{
		private static readonly string XML = "<sender typeCode=\"SND\" xmlns=\"urn:hl7-org:v3\" >" + "		<telecom value=\"http://987.654.321.0\" />"
			 + "		<device classCode=\"DEV\" determinerCode=\"INSTANCE\">" + "			<id extension=\"123\" root=\"2.16.840.1.113883.4.262.12\" use=\"BUS\" />"
			 + "			<manufacturerModelName>1.0</manufacturerModelName>" + "			<softwareName>Panacea Pharmacy</softwareName>" + "		</device>"
			 + "	</sender>";

		private static readonly string XML2 = "<observation classCode=\"OBS\" moodCode=\"EVN\" xmlns=\"urn:hl7-org:v3\" >" + "		<code code=\"3137-7\" codeSystem=\"1.2.3.4\" />"
			 + "		<statusCode code=\"completedINCORRECT\" />" + "		<value unit=\"mm\" value=\"5\" />" + "	</observation>";

		private XmlDocument document;

		private MessageDefinitionService service;

		private XmlElement element;

		private Hl7PartSource partSource;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			MockMessageBeanRegistry.Initialize();
			CodeResolverRegistry.Register(new EnumBasedCodeResolver(typeof(Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus
				)));
			CodeResolverRegistry.Register(new TrivialCodeResolver());
			this.service = new MockTestCaseMessageDefinitionService();
			this.document = GetSourceDocument(XML);
			this.element = this.document.DocumentElement;
			Hl7MessageSource rootSource = new Hl7MessageSource(MockVersionNumber.MOCK_NEWFOUNDLAND, this.document, null, null, this.service
				);
			this.partSource = rootSource.CreatePartSource(CreateRelationship("MCCI_MT002100CA.Sender"), element);
		}

		[NUnit.Framework.TearDown]
		public virtual void TearDown()
		{
			CodeResolverRegistry.UnregisterAll();
		}

		private Relationship CreateRelationship(string type)
		{
			Relationship relationship = new Relationship();
			relationship.Type = type;
			return relationship;
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldMapSenderAttributes()
		{
			Sender teal = (Sender)new Hl7SourceMapper().MapPartSourceToTeal(this.partSource, null);
			Assert.IsNotNull(teal, "teal");
			Assert.IsNotNull(teal.TelecommunicationAddress, "telecom");
			Assert.AreEqual("http://987.654.321.0", teal.TelecommunicationAddress.ToString(), "telecom number");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldMapSenderCollapsedAssociation()
		{
			Sender teal = (Sender)new Hl7SourceMapper().MapPartSourceToTeal(partSource, null);
			Assert.IsNotNull(teal, "teal");
			Assert.IsNotNull(teal.DeviceId, "device id");
			Assert.AreEqual(new Identifier("2.16.840.1.113883.4.262.12", "123"), teal.DeviceId, "id");
			Assert.AreEqual("1.0", teal.ManufacturerModelNumber, "model");
			Assert.AreEqual("Panacea Pharmacy", teal.SoftwareName, "model");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldMapObservationAttributes()
		{
			XmlDocument document2 = GetSourceDocument(XML2);
			XmlElement element2 = document2.DocumentElement;
			Hl7MessageSource rootSource2 = new Hl7MessageSource(MockVersionNumber.MOCK_NEWFOUNDLAND, document2, null, null, this.service
				);
			Hl7PartSource partSource2 = rootSource2.CreatePartSource(CreateRelationship("PORX_MT010120CA.QuantityObservationEvent"), 
				element2);
			QuantityObservationEventBean teal = (QuantityObservationEventBean)new Hl7SourceMapper().MapPartSourceToTeal(partSource2, 
				null);
			Assert.IsNotNull(teal, "teal");
			Assert.IsNotNull(teal.PatientMeasurementType, "code1");
			Assert.IsNotNull(teal.PatientMeasuredValue, "code2");
			XmlToModelResult result = partSource2.GetResult();
			Assert.IsNotNull(result, "result");
			Assert.AreEqual(2, result.GetHl7Errors().Count);
			Assert.AreEqual(Hl7ErrorCode.UNSUPPORTED_INTERACTION, result.GetHl7Errors()[0].GetHl7ErrorCode());
			Assert.AreEqual(Hl7ErrorCode.MANDATORY_FIELD_NOT_PROVIDED, result.GetHl7Errors()[1].GetHl7ErrorCode());
		}

		/// <exception cref="System.Exception"></exception>
		private XmlDocument GetSourceDocument(string xml)
		{
			return new DocumentFactory().CreateFromString(xml);
		}
	}
}
