using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Datatype.Lang
{
	[TestFixture]
	public class IntervalFactoryTest
	{
		[Test]
		public virtual void TestNullParameters()
		{
			IntervalFactory.CreateCentre((PlatformDate)null);
			IntervalFactory.CreateCentre((PlatformDate)null, (NullFlavor)null);
			IntervalFactory.CreateCentreHigh((PlatformDate)null, (PlatformDate)null);
			IntervalFactory.CreateCentreHigh((PlatformDate)null, (PlatformDate)null, (NullFlavor)null, (NullFlavor)null);
			IntervalFactory.CreateCentreWidth((PlatformDate)null, (Diff<PlatformDate>)null);
			IntervalFactory.CreateCentreWidth((PlatformDate)null, (Diff<PlatformDate>)null, (NullFlavor)null);
			IntervalFactory.CreateHigh((PlatformDate)null);
			IntervalFactory.CreateHigh((PlatformDate)null, (NullFlavor)null);
			IntervalFactory.CreateLow((PlatformDate)null);
			IntervalFactory.CreateLow((PlatformDate)null, (NullFlavor)null);
			IntervalFactory.CreateLowCentre((PlatformDate)null, (PlatformDate)null);
			IntervalFactory.CreateLowCentre((PlatformDate)null, (PlatformDate)null, (NullFlavor)null, (NullFlavor)null);
			IntervalFactory.CreateLowHigh((PlatformDate)null, (PlatformDate)null);
			IntervalFactory.CreateLowHigh((PlatformDate)null, (PlatformDate)null, (NullFlavor)null, (NullFlavor)null);
			IntervalFactory.CreateLowWidth((PlatformDate)null, (Diff<PlatformDate>)null);
			IntervalFactory.CreateLowWidth((PlatformDate)null, (Diff<PlatformDate>)null, (NullFlavor)null);
			IntervalFactory.CreateSimple((PlatformDate)null);
			IntervalFactory.CreateWidth((Diff<PlatformDate>)null);
			IntervalFactory.CreateWidthHigh((Diff<PlatformDate>)null, (PlatformDate)null);
			IntervalFactory.CreateWidthHigh((Diff<PlatformDate>)null, (PlatformDate)null, (NullFlavor)null);
		}
	}
}
