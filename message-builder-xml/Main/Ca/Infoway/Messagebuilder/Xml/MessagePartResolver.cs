using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>A tool that can locate message parts.</summary>
	/// <remarks>A tool that can locate message parts.</remarks>
	/// <author>Intelliware Development</author>
	public interface MessagePartResolver
	{
		/// <summary>Find a message part by name.</summary>
		/// <remarks>Find a message part by name.</remarks>
		/// <param name="type">- the name of message type to retrieve.</param>
		/// <returns>- the message part</returns>
		MessagePart GetMessagePart(string type);

		/// <summary>Find the root type of a package location.</summary>
		/// <remarks>Find the root type of a package location.</remarks>
		/// <param name="packageLocationName">- the name of the package location.</param>
		/// <returns>- the root type of the package location.</returns>
		string GetPackageLocationRootType(string packageLocationName);
	}
}
