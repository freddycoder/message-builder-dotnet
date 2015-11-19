using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Error;

namespace Ca.Infoway.Messagebuilder.Xml.Validator
{
	public class CdaValidatorResult
	{
		private readonly IList<TransformError> transformErrors;

		public CdaValidatorResult() : this(new List<TransformError>())
		{
		}

		public CdaValidatorResult(IList<TransformError> transformErrors)
		{
			this.transformErrors = transformErrors;
		}

		public virtual IList<TransformError> GetErrors()
		{
			return this.transformErrors;
		}
	}
}
