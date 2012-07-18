using System.Xml;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Model.Cr;
using Ca.Infoway.Messagebuilder.Terminology;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml.Service;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[TestFixture]
	public class Hl7SourceMapperMessageBeanTest
	{
		private static readonly string QUERY_RESPONSE_MESSAGE_FILE = "/ca/infoway/messagebuilder/transport/mohawk/sample/findCandidatesQuery.xml";

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

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldMapPatientReferralSummariesQueryResponseMessageBean()
		{
			XmlToModelResult xmlResult = new Hl7SourceMapper().MapToTeal(this.messageSource);
			FindCandidatesQueryMessageBean teal = (FindCandidatesQueryMessageBean)xmlResult.GetMessageObject();
			Assert.IsNotNull(teal, "message Bean");
			Assert.AreEqual("1ee83ff1-08ab-4fe7-b573-ea777e9bad51", teal.MessageIdentifier.Root, "id");
			Assert.AreEqual("P", teal.ProcessingCode.CodeValue, "processingId");
			Assert.AreEqual("Panacea Pharmacy", teal.Sender.SoftwareName, "sender.softwareName");
			Assert.AreEqual("987.654.321.0", teal.Sender.TelecommunicationAddress.Address, "sender.telecommunicationAddress");
			Assert.IsNotNull(teal.Receiver.DeviceId, "receiver.deviceId");
			Assert.AreEqual("123.255.255.10", teal.Receiver.TelecommunicationAddress.Address, "receiver.telecommunicationAddress");
			Assert.AreEqual("PRPA_TE101103CA", teal.ControlActEventBean.Code.CodeValue, "controlActEvent.code");
			Assert.AreEqual("J", teal.ControlActEventBean.QueryByParameter.ParameterList.PersonNames[0].GivenName, "criteria first name"
				);
			Assert.AreEqual("Smith", teal.ControlActEventBean.QueryByParameter.ParameterList.PersonNames[0].FamilyName, "criteria last name"
				);
		}

		/// <exception cref="System.Exception"></exception>
		private XmlDocument GetSourceDocument()
		{
			return new DocumentFactory().CreateFromResource(new ClasspathResource(this.GetType(), QUERY_RESPONSE_MESSAGE_FILE));
		}
	}
}
