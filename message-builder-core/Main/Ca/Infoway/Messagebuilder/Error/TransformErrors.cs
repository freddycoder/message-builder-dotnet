using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Error;

namespace Ca.Infoway.Messagebuilder.Error
{
	public interface TransformErrors
	{
		bool IsValid();

		bool HasErrors();

		bool HasWarnings();

		//	public void addError(TransformError error);	// TODO: implement in some future age when the non-HL7 classes are more than just a facade
		IList<TransformError> GetErrors();
	}
}
