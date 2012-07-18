using Ca.Infoway.Messagebuilder.Xml.Service;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Xml.Service
{
	[TestFixture]
	public class MessageDefinitionServiceFactoryTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldProduceNonNullResult()
		{
			MessageDefinitionService service = new MockTestCaseMessageDefinitionService();
			Assert.IsNotNull(service, "service");
		}
	}
}
