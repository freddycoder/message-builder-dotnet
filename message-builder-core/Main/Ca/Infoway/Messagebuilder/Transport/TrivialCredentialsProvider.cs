using Ca.Infoway.Messagebuilder.Transport;

namespace Ca.Infoway.Messagebuilder.Transport
{
	/// <summary>A basic implementation of a CredentialsProvider.</summary>
	/// <remarks>A basic implementation of a CredentialsProvider. Holds credentials, and nothing more.</remarks>
	/// <author>
	/// Intelliware Development
	/// sharpen.ignore - transport - TBD!
	/// </author>
	public class TrivialCredentialsProvider : CredentialsProvider
	{
		private readonly Credentials credentials;

		/// <summary>Constructs a TrivialCredentialsProvider based on the provided Credentials.</summary>
		/// <remarks>Constructs a TrivialCredentialsProvider based on the provided Credentials.</remarks>
		/// <param name="credentials">the credentials to provide</param>
		public TrivialCredentialsProvider(Credentials credentials)
		{
			this.credentials = credentials;
		}

		/// <summary>Obtain the credentials.</summary>
		/// <remarks>Obtain the credentials.</remarks>
		/// <returns>the current credentials</returns>
		public virtual Credentials GetCredentials()
		{
			return this.credentials;
		}
	}
}
