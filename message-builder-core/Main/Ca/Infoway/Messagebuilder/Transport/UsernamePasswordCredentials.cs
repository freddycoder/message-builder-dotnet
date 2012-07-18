using Ca.Infoway.Messagebuilder.Transport;

namespace Ca.Infoway.Messagebuilder.Transport
{
	/// <summary>A simple credentials implementation.</summary>
	/// <remarks>A simple credentials implementation. Stores username and password.</remarks>
	/// <author>
	/// Intelliware Development
	/// sharpen.ignore - transport - TBD!
	/// </author>
	public class UsernamePasswordCredentials : Credentials
	{
		private readonly string username;

		private readonly string password;

		/// <summary>Constructs a usernamePassword credential with the given username and password.</summary>
		/// <remarks>Constructs a usernamePassword credential with the given username and password.</remarks>
		/// <param name="username">the username/login id for the credentials</param>
		/// <param name="password">the plaintext password for the credentials</param>
		public UsernamePasswordCredentials(string username, string password)
		{
			this.username = username;
			this.password = password;
		}

		/// <summary>Obtains the username.</summary>
		/// <remarks>Obtains the username.</remarks>
		/// <returns>the username</returns>
		public virtual string GetUsername()
		{
			return this.username;
		}

		/// <summary>Obtains the password.</summary>
		/// <remarks>Obtains the password.</remarks>
		/// <returns>the plaintext password</returns>
		public virtual string GetPassword()
		{
			return this.password;
		}
	}
}
