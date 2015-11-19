using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class XmlToModelResultTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIsValid()
		{
			XmlToModelResult xmlResult = new XmlToModelResult();
			Assert.IsTrue(xmlResult.IsValid(), "is valid");
			xmlResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "monkey", "a.property.path"));
			Assert.IsFalse(xmlResult.IsValid(), "is not valid");
		}
	}
}
