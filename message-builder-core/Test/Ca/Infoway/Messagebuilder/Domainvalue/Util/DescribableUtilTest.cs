using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Util
{
	[TestFixture]
	public class DescribableUtilTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestShouldConvertEnumLikeStrings()
		{
			Assert.AreEqual("My interesting value", DescribableUtil.GetDefaultDescription("MY_INTERESTING_VALUE"), "value");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestShouldHandleEmptyString()
		{
			Assert.AreEqual(string.Empty, DescribableUtil.GetDefaultDescription(string.Empty), "value");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestShouldHandleNull()
		{
			Assert.AreEqual(string.Empty, DescribableUtil.GetDefaultDescription(null), "value");
		}
	}
}
