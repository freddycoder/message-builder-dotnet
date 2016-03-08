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


using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Model.Cr;
using Ca.Infoway.Messagebuilder.Model.Mock;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
using Ca.Infoway.Messagebuilder.Xml.Service;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[TestFixture]
	public class XmlRenderingVisitorIntegrationTest
	{
		private MessageDefinitionService service;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			MockMessageBeanRegistry.Initialize();
			this.service = new MockTestCaseMessageDefinitionService();
			DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();
		}

		[NUnit.Framework.TearDown]
		public virtual void TearDown()
		{
			CodeResolverRegistry.UnregisterAll();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderCompleteSolution()
		{
			FindCandidatesQueryMessageBean message = new FindCandidatesQueryMessageBean();
			message.ControlActEventBean = new QueryControlActEventBean<FindCandidatesCriteria>(new FindCandidatesCriteria());
			message.ControlActEventBean.GetCriteria().BirthDate = DateUtil.GetDate(1966, 0, 5);
			XmlRenderingVisitor visitor = new XmlRenderingVisitor(MockVersionNumber.MOCK_NEWFOUNDLAND);
			new TealBeanRenderWalker(message, MockVersionNumber.MOCK_NEWFOUNDLAND, null, null, this.service).Accept(visitor);
			System.Console.Out.WriteLine(visitor.ToXml().GetXmlMessage());
		}
	}
}
