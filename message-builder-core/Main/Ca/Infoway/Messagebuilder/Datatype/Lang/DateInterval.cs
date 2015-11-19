using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;

namespace Ca.Infoway.Messagebuilder.Datatype.Lang
{
	public class DateInterval : MbDate
	{
		private Ca.Infoway.Messagebuilder.Datatype.Lang.Interval<PlatformDate> interval;

		public DateInterval()
		{
		}

		public DateInterval(Ca.Infoway.Messagebuilder.Datatype.Lang.Interval<PlatformDate> actualInterval)
		{
			this.interval = actualInterval;
		}

		public virtual Ca.Infoway.Messagebuilder.Datatype.Lang.Interval<PlatformDate> Interval
		{
			get
			{
				return this.interval;
			}
			set
			{
				Ca.Infoway.Messagebuilder.Datatype.Lang.Interval<PlatformDate> interval = value;
				this.interval = interval;
			}
		}
	}
}
