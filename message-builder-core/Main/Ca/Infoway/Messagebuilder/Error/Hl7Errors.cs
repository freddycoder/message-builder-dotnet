using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Error;

namespace Ca.Infoway.Messagebuilder.Error
{
	public interface Hl7Errors
	{
		bool IsValid();

		bool HasErrors();

		bool HasWarnings();

		void AddHl7Error(Hl7Error hl7Error);

		IList<Hl7Error> GetHl7Errors();
	}
}
