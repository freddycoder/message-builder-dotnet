using Ca.Infoway.Messagebuilder.DevTools;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Model.Cr;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml.Service;
using NUnit.Framework;
using Platform.Xml.Sax;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[TestFixture]
	public class MessageBeanTransformerImplTest
	{
		private MessageBeanTransformerImpl transformer;

		private DocumentFactory factory;

		private static readonly string MESSAGE = "/ca/infoway/messagebuilder/transport/mohawk/sample/findCandidatesQuery.xml";

		private static readonly string UNSUPPORTED_MESSAGE_XML = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<ABCD_IN123456CA ITSVersion=\"XML_1.0\">"
			 + "</ABCD_IN123456CA>";

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			MockMessageBeanRegistry.Initialize();
			CodeResolverRegistry.Register(new TrivialCodeResolver());
			this.transformer = new MessageBeanTransformerImpl(new MockTestCaseMessageDefinitionService(), RenderMode.PERMISSIVE);
			this.factory = new DocumentFactory();
		}

		[NUnit.Framework.TearDown]
		public virtual void TearDown()
		{
			CodeResolverRegistry.UnregisterAll();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldProduceRightResultForResponse()
		{
			XmlToModelResult result = this.transformer.TransformFromHl7(MockVersionNumber.MOCK_NEWFOUNDLAND, this.factory.CreateFromResource
				(new ClasspathResource(this.GetType(), MESSAGE)));
			Assert.IsNotNull(result, "result");
			Assert.IsNotNull(result.GetMessageObject(), "bean");
			Assert.IsTrue(result.GetMessageObject() is FindCandidatesQueryMessageBean, "bean type");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldReportUnsupportedInteraction()
		{
			XmlToModelResult result = this.transformer.TransformFromHl7(MockVersionNumber.MOCK_NEWFOUNDLAND, this.factory.CreateFromString
				(UNSUPPORTED_MESSAGE_XML));
			Assert.IsNotNull(result, "result");
			Assert.IsFalse(result.IsValid(), "bean");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldWriteValidXml()
		{
			FindCandidatesQueryMessageBean query = new FindCandidatesQueryMessageBean();
			new MessageBeanFactory(new DefaultValueHolder()).Populate(query);
			string xml = this.transformer.TransformToHl7(MockVersionNumber.MOCK_NEWFOUNDLAND, query).GetXmlMessage();
			AssertIsValidXml(xml);
		}

		private void AssertIsValidXml(string xml)
		{
			try
			{
				this.factory.CreateFromString(xml);
			}
			catch (SAXException e)
			{
				Assert.Fail(e.Message);
			}
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldCreateDefaultVersionCode()
		{
			FindCandidatesQueryMessageBean query = new FindCandidatesQueryMessageBean();
			new MessageBeanFactory(new DefaultValueHolder()).Populate(query);
			string xml = this.transformer.TransformToHl7(MockVersionNumber.MOCK_NEWFOUNDLAND, query).GetXmlMessage();
			Assert.IsTrue(xml.Contains("<versionCode code=\"V3-2007-05\"/>"), "version code");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldCreateDefaultInteractionId()
		{
			FindCandidatesQueryMessageBean query = new FindCandidatesQueryMessageBean();
			new MessageBeanFactory(new DefaultValueHolder()).Populate(query);
			string xml = this.transformer.TransformToHl7(MockVersionNumber.MOCK_NEWFOUNDLAND, query).GetXmlMessage();
			Assert.IsTrue(xml.Contains(" extension=\"PRPA_IN101103CA\" "), "interaction id");
		}
	}
}
