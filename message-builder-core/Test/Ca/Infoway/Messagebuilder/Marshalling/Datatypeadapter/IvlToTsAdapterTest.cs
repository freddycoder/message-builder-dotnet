using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter;
using Ca.Infoway.Messagebuilder.Resolver;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter
{
	[TestFixture]
	public class IvlToTsAdapterTest
	{
		private IvlToTsAdapter adapter;

		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			this.adapter = new IvlToTsAdapter();
			CodeResolverRegistry.Register(new TrivialCodeResolver());
		}

		[NUnit.Framework.TearDown]
		public virtual void TearDown()
		{
			CodeResolverRegistry.UnregisterAll();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldMatch()
		{
			Assert.IsTrue(this.adapter.CanAdapt(StandardDataType.IVL_FULL_DATE.Type, typeof(TS)), "FULL_DATE_IVL");
			Assert.IsTrue(this.adapter.CanAdapt(StandardDataType.IVL_FULL_DATE_WITH_TIME.Type, typeof(TS)), "IVL_FULL_DATE_WITH_TIME"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldAdaptCorrectly()
		{
			IVLImpl<TS, Interval<PlatformDate>> ivl = new IVLImpl<TS, Interval<PlatformDate>>(IntervalFactory.CreateLow<PlatformDate>
				(new PlatformDate()));
			BareANY adapted = this.adapter.Adapt(typeof(TS), ivl);
			Assert.IsTrue(adapted is TS);
			Assert.AreEqual(((TS)adapted).Value, ivl.Value.Low, "low");
		}
	}
}
