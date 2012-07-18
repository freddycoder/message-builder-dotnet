namespace Ca.Infoway.Messagebuilder.DevTools
{
	public class RoutingInstructionLinesValueHolder
	{
		private string keyWordText;

		private string value;

		public virtual string GetKeyWordText()
		{
			return keyWordText;
		}

		public virtual void SetKeyWordText(string keyWordText)
		{
			this.keyWordText = keyWordText;
		}

		public virtual string GetValue()
		{
			return value;
		}

		public virtual void SetValue(string value)
		{
			this.value = value;
		}
	}
}
