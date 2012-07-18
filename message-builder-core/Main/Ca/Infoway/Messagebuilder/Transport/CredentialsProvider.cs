using Ca.Infoway.Messagebuilder.Transport;

namespace Ca.Infoway.Messagebuilder.Transport
{
	/// <summary>Allows implementors to provide credentials.</summary>
	/// <remarks>Allows implementors to provide credentials.</remarks>
	/// <author>
	/// Intelliware Development
	/// sharpen.ignore - transport - TBD!
	/// </author>
	public interface CredentialsProvider
	{
		/// <summary>Obtain the credentials.</summary>
		/// <remarks>Obtain the credentials.</remarks>
		/// <returns>the current credentials</returns>
		Credentials GetCredentials();
	}
}
