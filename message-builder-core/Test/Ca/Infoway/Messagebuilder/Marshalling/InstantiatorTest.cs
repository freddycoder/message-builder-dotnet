using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[TestFixture]
	public class InstantiatorTest
	{
		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			MockMessageBeanRegistry.Initialize();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldFindUniqueTealBeanForHl7PartType()
		{
			Assert.IsTrue(Instantiator.GetInstance().InstantiateMessagePartBean(MockVersionNumber.MOCK_NEWFOUNDLAND, "MOCK_MT123456CA.SubType"
				, new Interaction()) is MockSubType, "instance of Sender");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldFindTealBeanWhenPartTypeHasVersionSuffix()
		{
			Assert.IsTrue(Instantiator.GetInstance().InstantiateMessagePartBean(MockVersionNumber.MOCK_NEWFOUNDLAND, "MOCK_MT123456CA.SubType_V02R02"
				, new Interaction()) is MockSubType, "instance of Sender");
		}
	}
}
