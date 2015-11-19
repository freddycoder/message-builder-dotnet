using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Util
{
	[TestFixture]
	public class DomainTypeHelperTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldSanitizeDomainName()
		{
			Assert.AreEqual("NonPersonLivingSubject", DomainTypeHelper.Sanitize("Non-personLivingSubject"), "1");
			Assert.AreEqual("HL7TriggerEventCode", DomainTypeHelper.Sanitize("HL7TriggerEventCode"), "2");
			Assert.AreEqual("x_VeryBasicConfidentialityKind", DomainTypeHelper.Sanitize("x_VeryBasicConfidentialityKind"), "3");
		}
	}
}
