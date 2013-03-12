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
using Ca.Infoway.Messagebuilder.Model.Mock;
using Ca.Infoway.Messagebuilder.Terminology;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Service;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[TestFixture]
	public class Hl7SourceMapperAssociationTest
	{
		private static readonly string XML = "<sender typeCode=\"SND\" xmlns=\"urn:hl7-org:v3\" >" + "		<telecom value=\"http://987.654.321.0\" />"
			 + "		<device classCode=\"DEV\" determinerCode=\"INSTANCE\">" + "			<id extension=\"123\" root=\"2.16.840.1.113883.4.262.12\" use=\"BUS\" />"
			 + "			<manufacturerModelName>1.0</manufacturerModelName>" + "			<softwareName>Panacea Pharmacy</softwareName>" + "		</device>"
			 + "	</sender>";

		private XmlDocument document;

		private MessageDefinitionService service;

		private XmlElement element;

		private Hl7PartSource partSource;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			MockMessageBeanRegistry.Initialize();
			CodeResolverRegistry.Register(new TrivialCodeResolver());
			this.service = new MockTestCaseMessageDefinitionService();
			this.document = GetSourceDocument();
			Hl7MessageSource rootSource = new Hl7MessageSource(MockVersionNumber.MOCK_NEWFOUNDLAND, document, null, null, this.service
				);
			this.element = this.document.DocumentElement;
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
		public virtual void ShouldMapSender()
		{
			Sender teal = (Sender)new Hl7SourceMapper().MapPartSourceToTeal(this.partSource, null);
			Assert.IsNotNull(teal, "teal");
			Assert.AreEqual(new Identifier("2.16.840.1.113883.4.262.12", "123"), teal.DeviceId, "device id");
			Assert.IsNull(teal.DeviceName, "device name");
			Assert.AreEqual("1.0", teal.ManufacturerModelNumber, "model number");
			Assert.IsNull(teal.SendingOrganizationIdentifier, "sending org id");
			Assert.AreEqual("Panacea Pharmacy", teal.SoftwareName, "software name");
			Assert.AreEqual("987.654.321.0", teal.TelecommunicationAddress.Address, "address");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.URLScheme.HTTP.CodeValue, teal.TelecommunicationAddress.UrlScheme
				.CodeValue, "address scheme");
		}

		/// <exception cref="System.Exception"></exception>
		private XmlDocument GetSourceDocument()
		{
			return new DocumentFactory().CreateFromString(XML);
		}
	}
}
