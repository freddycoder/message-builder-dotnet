using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Platform;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Platform
{
	[TestFixture]
	public class NumberFormatterTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldFormatBigDecimal()
		{
			Assert.AreEqual("1.00", new NumberFormatter().Format(new BigDecimal("1.0"), 10, 2, true), "result");
			Assert.AreEqual("1", new NumberFormatter().Format(new BigDecimal("1.0"), 10, 2, false), "result");
			Assert.AreEqual("11.00", new NumberFormatter().Format(new BigDecimal("11111.0"), 5, 2, true), "result");
			// BCH: This result is questionable.  Confirm at a later date.
			Assert.AreEqual("11", new NumberFormatter().Format(new BigDecimal("11111.0"), 5, 2, false), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRound()
		{
			Assert.AreEqual("1.01", new NumberFormatter().Format(new BigDecimal("1.008"), 10, 2, true), "result");
		}
	}
}
