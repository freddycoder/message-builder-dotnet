using Ca.Infoway.Messagebuilder;

namespace Ca.Infoway.Messagebuilder.Datatype.Lang
{
	public class MbDate
	{
		private PlatformDate value;

		public MbDate()
		{
		}

		public MbDate(PlatformDate value)
		{
			this.value = value;
		}

		public virtual PlatformDate Value
		{
			get
			{
				return value;
			}
			set
			{
				this.value = value;
			}
		}
	}
}
