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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Model.Common;
using Ca.Infoway.Messagebuilder.Model.Cr;
using Ca.Infoway.Messagebuilder.Model.Mock;
using Ca.Infoway.Messagebuilder.Platform;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml.Service;
using Ca.Infoway.Messagebuilder.Xml.Validator;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[TestFixture]
	public class TealBeanRenderWalkerIntegrationTest
	{
		private TealBeanRenderWalker walker;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			CodeResolverRegistry.Register(new TrivialCodeResolver());
		}

		[NUnit.Framework.TearDown]
		public virtual void TearDown()
		{
			CodeResolverRegistry.UnregisterAll();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderASimpleHl7Message()
		{
			GenericResponseMessageBean tealBean = new GenericResponseMessageBean();
			MessageBeanBuilderSupport.PopulateMoreBetterStandardValues(tealBean);
			tealBean.Acknowledgement.AcknowledgementDetails.Add(CreateDetail(Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode
				.SYNTAX_ERROR, "I hate you", Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailType.ERROR));
			tealBean.Acknowledgement.AcknowledgementDetails.Add(CreateDetail(Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode
				.UNKNOWN_SENDER, "Unauthorized user", Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailType.ERROR));
			XmlRenderingVisitor visitor = new XmlRenderingVisitor();
			this.walker = new TealBeanRenderWalker(tealBean, MockVersionNumber.MOCK_MR2009, null, null, new MockTestCaseMessageDefinitionService
				());
			this.walker.Accept(visitor);
			string xml = visitor.ToXml().GetXmlMessage();
			System.Console.Out.WriteLine(xml);
			AssertValidHl7Message(xml);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderASimpleMessageWithTemplates()
		{
			FindCandidatesQueryMessageBean tealBean = new FindCandidatesQueryMessageBean();
			tealBean.ControlActEventBean = new QueryControlActEventBean<FindCandidatesCriteria>();
			tealBean.ControlActEventBean.QueryByParameter.ParameterList = new FindCandidatesCriteria();
			MessageBeanBuilderSupport.PopulateMoreBetterStandardValues(tealBean);
			tealBean.ControlActEventBean.Code = Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode.FIND_CANDIDATES_QUERY;
			this.walker = new TealBeanRenderWalker(tealBean, MockVersionNumber.MOCK_MR2009, null, null, new MockTestCaseMessageDefinitionService
				());
			AuthorBean author = new AuthorBean();
			author.Time = new PlatformDate();
			author.Id = new Identifier("1.2.3.4", "authorExtension");
			tealBean.ControlActEventBean.Author = author;
			tealBean.ControlActEventBean.QueryId = new Identifier(UUID.RandomUUID().ToString());
			tealBean.ControlActEventBean.EventId = new Identifier(UUID.RandomUUID().ToString());
			tealBean.ControlActEventBean.GetCriteria().Gender = Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender.MALE;
			XmlRenderingVisitor visitor = new XmlRenderingVisitor();
			this.walker.Accept(visitor);
			string xml = visitor.ToXml().GetXmlMessage();
			System.Console.Out.WriteLine(xml);
			AssertValidHl7Message(xml);
		}

		private AcknowledgementDetailBean CreateDetail(Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode 
			code, string text, Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailType type)
		{
			return new AcknowledgementDetailBean(type, code, text);
		}

		/// <exception cref="Platform.Xml.Sax.SAXException"></exception>
		private void AssertValidHl7Message(string xml)
		{
			XmlDocument document = new DocumentFactory().CreateFromString(xml);
			MessageValidatorResult result = new MessageValidatorImpl(new MockTestCaseMessageDefinitionService()).Validate(document, MockVersionNumber
				.MOCK_MR2009);
			foreach (Hl7Error error in result.GetHl7Errors())
			{
				Assert.Fail(error.ToString());
			}
		}
	}
}
