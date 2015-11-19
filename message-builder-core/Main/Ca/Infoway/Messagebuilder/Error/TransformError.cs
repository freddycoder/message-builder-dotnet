using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Error
{
	public class TransformError
	{
		private readonly Hl7Error error;

		private readonly ErrorCode errorCode;

		public TransformError(Hl7Error error)
		{
			this.error = error;
			this.errorCode = Ca.Infoway.Messagebuilder.Error.TransformError.TransformCode(error.GetHl7ErrorCode());
		}

		public virtual ErrorCode GetErrorCode()
		{
			return this.errorCode;
		}

		public virtual ErrorLevel GetErrorLevel()
		{
			return this.error.GetHl7ErrorLevel();
		}

		public virtual string GetMessage()
		{
			return this.error.GetMessage();
		}

		public virtual string GetPath()
		{
			return this.error.GetPath();
		}

		public virtual string GetBeanPath()
		{
			return this.error.GetBeanPath();
		}

		public override string ToString()
		{
			return this.error.ToString();
		}

		public static ErrorCode TransformCode(Hl7ErrorCode hl7ErrorCode)
		{
			if (hl7ErrorCode == null)
			{
				return null;
			}
			IList<ErrorCode> values = EnumPattern.Values<ErrorCode>();
			string name = hl7ErrorCode.Name;
			for (int i = 0; i < values.Count; i++)
			{
				if (StringUtils.Equals(values[i].Name, name))
				{
					return values[i];
				}
			}
			return null;
		}
	}
}
