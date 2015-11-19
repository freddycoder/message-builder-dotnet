using Ca.Infoway.Messagebuilder;

namespace Ca.Infoway.Messagebuilder.Domainvalue
{
	/// <summary>
	/// This attribute defines whether the message is being sent
	/// in current processing, archive mode, initial load mode,
	/// restore from archive mode, etc.
	/// </summary>
	/// <remarks>
	/// This attribute defines whether the message is being sent
	/// in current processing, archive mode, initial load mode,
	/// restore from archive mode, etc.
	/// </remarks>
	public interface ProcessingMode : Code
	{
	}
}
