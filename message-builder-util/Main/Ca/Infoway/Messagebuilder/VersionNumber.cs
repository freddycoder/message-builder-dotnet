using Ca.Infoway.Messagebuilder;

namespace Ca.Infoway.Messagebuilder
{
	/// <summary>An interface usable by any class that provides a version number/id.</summary>
	/// <remarks>An interface usable by any class that provides a version number/id.</remarks>
	public interface VersionNumber
	{
		/// <summary>Gets the version literal.</summary>
		/// <remarks>Gets the version literal.</remarks>
		/// <returns>the version literal</returns>
		string VersionLiteral
		{
			get;
		}

		VersionNumber GetBaseVersion();
	}
}
