using Ca.Infoway.Messagebuilder.Error;

namespace Ca.Infoway.Messagebuilder.Error
{
	public interface ErrorLogger
	{
		void LogError(Hl7ErrorCode errorCode, ErrorLevel errorLevel, string errorMessage);
	}
}
