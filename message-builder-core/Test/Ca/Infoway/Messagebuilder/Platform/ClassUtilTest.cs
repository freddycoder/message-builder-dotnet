using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Platform;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Platform
{
	[TestFixture]
	public class ClassUtilTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRecognizeGenerics()
		{
			Assert.IsTrue(ClassUtil.IsGeneric(typeof(IList<object>)), "list");
			Assert.IsFalse(ClassUtil.IsGeneric(typeof(string)), "string");
		}
	}
}
