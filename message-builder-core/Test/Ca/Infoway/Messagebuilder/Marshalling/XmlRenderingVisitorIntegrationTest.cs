using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Model.Cr;
using Ca.Infoway.Messagebuilder.Model.Mock;
using Ca.Infoway.Messagebuilder.Terminology.Configurator;
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

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderCompleteSolution()
		{
			FindCandidatesQueryMessageBean message = new FindCandidatesQueryMessageBean();
			message.ControlActEventBean = new QueryControlActEventBean<FindCandidatesCriteria>(new FindCandidatesCriteria());
			message.ControlActEventBean.GetCriteria().BirthDate = DateUtil.GetDate(1966, 0, 5);
			XmlRenderingVisitor visitor = new XmlRenderingVisitor();
			new TealBeanRenderWalker(message, MockVersionNumber.MOCK_NEWFOUNDLAND, null, null, this.service).Accept(visitor);
			System.Console.Out.WriteLine(visitor.ToXml().GetXmlMessage());
		}
	}
}
