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
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Model.Pr;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml.Service;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[TestFixture]
	public class Hl7SourceMapperRequestMessageBeanTest
	{
		private static readonly string XML = "<NLPN_IN100200CA xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"urn:hl7-org:v3\" ITSVersion=\"XML_1.0\">"
			 + "    <id root=\"1ee83ff1-08ab-4fe7-b573-ea777e9bad51\"/>" + "    <creationTime value=\"20080625141610-0500\"/>" + "    <responseModeCode code=\"I\"/>"
			 + "    <versionCode code=\"V3-2007-05\"/>" + "    <interactionId extension=\"NLPN_IN100200CA\" root=\"2.16.840.1.113883.1.6\" displayable=\"true\" />"
			 + "    <processingCode code=\"P\"/>" + "    <processingModeCode code=\"T\"/>" + "    <acceptAckCode code=\"AL\"/>" + "    <receiver typeCode=\"RCV\">"
			 + "      <telecom value=\"http://123.456.789.10\"/>" + "      <device classCode=\"DEV\" determinerCode=\"INSTANCE\">" +
			 "        <id extension=\"123\" root=\"1.2.3\" use=\"BUS\"/>" + "      </device>" + "    </receiver>" + "    <sender typeCode=\"SND\">"
			 + "      <telecom value=\"http://987.654.321.0\"/>" + "      <device classCode=\"DEV\" determinerCode=\"INSTANCE\">" + 
			"        <id extension=\"123\" root=\"1.2.3\" use=\"BUS\"/>" + "        <manufacturerModelName>1.0</manufacturerModelName>"
			 + "        <softwareName>Panacea Pharmacy</softwareName>" + "      </device>" + "    </sender>" + "    <controlActEvent classCode=\"CACT\" moodCode=\"EVN\">"
			 + "      <id extension=\"8141234\" root=\"2.16.840.1.113883.1.6\" use=\"BUS\"/>" + "      <code code=\"NLPN_TE100200CA\" codeSystem=\"2.16.840.1.113883.5.4\"/>"
			 + "      <statusCode code=\"completed\"/>" + "      <effectiveTime>" + "        <low value=\"20080918\"/>" + "        <high nullFlavor=\"NI\"/>"
			 + "      </effectiveTime>" + "      <author typeCode=\"AUT\" contextControlCode=\"AP\">" + "        <time value=\"20080625141610-0500\"/>"
			 + "       <assignedEntity1 classCode=\"ASSIGNED\">" + "          <id extension=\"EHR ID EXT\" root=\"2.16.840.1.113883.4.267\" displayable=\"true\"/>"
			 + "          <assignedPerson classCode=\"PSN\" determinerCode=\"INSTANCE\">" + "            <name use=\"L\"><given>Jane</given><family>Doe</family></name>"
			 + "            <asHealthCareProvider classCode=\"PROV\">" + "              <id extension=\"55555\" root=\"2.16.840.1.113883.4.268\" displayable=\"true\" />"
			 + "            </asHealthCareProvider>" + "          </assignedPerson>" + "        </assignedEntity1>" + "      </author>"
			 + "      <location typeCode=\"LOC\" contextControlCode=\"AP\">" + "        <serviceDeliveryLocation classCode=\"SDLOC\">"
			 + "          <id extension=\"1\" root=\"2.16.124.113620.1.1.11111\" displayable=\"true\" />" + "          <location classCode=\"PLC\" determinerCode=\"INSTANCE\">"
			 + "            <name>Intelliware&apos;s Pharmacy</name>" + "          </location>" + "        </serviceDeliveryLocation>"
			 + "      </location>" + "      <subject typeCode=\"SUBJ\" contextControlCode=\"ON\" contextConductionInd=\"false\">" + 
			"        <registrationRequest classCode=\"REG\" moodCode=\"RQO\">" + "          <statusCode code=\"active\"/>" + "          <subject typeCode=\"SBJ\" contextControlCode=\"AN\">"
			 + "            <passwordChange classCode=\"ACT\" moodCode=\"RQO\">" + "              <text>newPassw0rd</text>" + "            </passwordChange>"
			 + "          </subject>" + "          <custodian typeCode=\"CST\" contextControlCode=\"AP\">" + "            <assignedDevice classCode=\"ASSIGNED\">"
			 + "              <id extension=\"444\" root=\"1.2.3.4.5\" use=\"BUS\" />" + "              <assignedRepository classCode=\"DEV\" determinerCode=\"INSTANCE\">"
			 + "                <name>Panacea</name>" + "              </assignedRepository>" + "              <representedRepositoryJurisdiction classCode=\"STATE\" determinerCode=\"INSTANCE\">"
			 + "                <name>somewhere</name>" + "              </representedRepositoryJurisdiction>" + "            </assignedDevice>"
			 + "          </custodian>" + "        </registrationRequest>" + "      </subject>" + "    </controlActEvent>" + "</NLPN_IN100200CA>";

		private XmlDocument document;

		private MessageDefinitionService service;

		private Hl7MessageSource messageSource;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			MockMessageBeanRegistry.Initialize();
			CodeResolverRegistry.Register(new TrivialCodeResolver());
			this.document = GetSourceDocument();
			this.service = new MockTestCaseMessageDefinitionService();
			this.messageSource = new Hl7MessageSource(MockVersionNumber.MOCK_NEWFOUNDLAND, this.document, null, null, service);
		}

		[NUnit.Framework.TearDown]
		public virtual void TearDown()
		{
			CodeResolverRegistry.UnregisterAll();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldMapRequestMessageBean()
		{
			XmlToModelResult xmlToJavaResult = new Hl7SourceMapper().MapToTeal(this.messageSource);
			UpdatePasswordRequestMessageBean teal = (UpdatePasswordRequestMessageBean)xmlToJavaResult.GetMessageObject();
			Assert.IsNotNull(teal, "message Bean");
			Assert.IsTrue(xmlToJavaResult.GetHl7Errors().IsEmpty());
			Assert.AreEqual("NLPN_TE100200CA", teal.ControlActEventBean.Code.CodeValue, "controlActEvent.code");
			Assert.AreEqual("Panacea", teal.ControlActEventBean.RegistrationBean.AssignedDevice.AssignedRepository, "assignedDevice.assignedRespository"
				);
			Assert.AreEqual("somewhere", teal.ControlActEventBean.RegistrationBean.AssignedDevice.RepresentedRepositoryJurisdiction, 
				"assignedDevice.representedRepositoryJurisdiction");
			Assert.AreEqual("newPassw0rd", teal.ControlActEventBean.RegistrationBean.Record.Text, "password text");
		}

		/// <exception cref="System.Exception"></exception>
		private XmlDocument GetSourceDocument()
		{
			return new DocumentFactory().CreateFromString(XML);
		}
	}
}
