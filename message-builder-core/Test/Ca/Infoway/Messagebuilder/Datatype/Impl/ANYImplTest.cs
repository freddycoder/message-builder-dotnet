using Ca.Infoway.Messagebuilder.Datatype.Impl;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Datatype.Impl
{
	[TestFixture]
	public class ANYImplTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TwoNullFlavorsAreNeverEqual()
		{
			ANYImpl<string> anyImpl1 = new ANYImplTest.BarDataType(this);
			anyImpl1.NullFlavor = Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.ASKED_BUT_UNKNOWN;
			ANYImpl<string> anyImpl2 = new ANYImplTest.BarDataType(this);
			anyImpl2.NullFlavor = Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.ASKED_BUT_UNKNOWN;
			Assert.IsFalse(anyImpl1.Equals(anyImpl2));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TwoH7ValuesAreEqualWhenTheyAreNotNullFlavorsAndTheirValuesAreEqual()
		{
			ANYImpl<string> anyImpl1 = new ANYImplTest.BarDataType(this);
			anyImpl1.Value = "same";
			ANYImpl<string> anyImpl2 = new ANYImplTest.BarDataType(this);
			anyImpl2.Value = "same";
			Assert.IsTrue(anyImpl1.Equals(anyImpl2));
		}

		internal class BarDataType : ANYImpl<string>
		{
			internal BarDataType(ANYImplTest _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ANYImplTest _enclosing;
		}
	}
}
