using System.Collections.Generic;

namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>
	/// A utility helper used to compare message part type names while ignoring a version
	/// suffix.
	/// </summary>
	/// <remarks>
	/// A utility helper used to compare message part type names while ignoring a version
	/// suffix.
	/// </remarks>
	/// <author>Intelliware Development</author>
	public class MessagePartVersionSuffixHelper
	{
		private static readonly string MESSAGE_PART_VERSION_SUFFIX_SEPARATOR = "_";

		/// <summary>Compare two message part types, while ignoring the suffix.</summary>
		/// <remarks>Compare two message part types, while ignoring the suffix.</remarks>
		/// <param name="type">= the type name</param>
		/// <param name="messagePartNames">- a list of message part names to compare against</param>
		/// <returns>true if a match is found; false otherwise</returns>
		public static bool MatchesDisregardingVersionSuffix(string type, IList<string> messagePartNames)
		{
			bool result = false;
			if (type != null)
			{
				foreach (string hl7PartType in messagePartNames)
				{
					if (MatchesDisregardingVersionSuffix(type, hl7PartType))
					{
						result = true;
						break;
					}
				}
			}
			return result;
		}

		/// <summary>Compare two message part type names, while ignoring the suffix.</summary>
		/// <remarks>Compare two message part type names, while ignoring the suffix.</remarks>
		/// <param name="type">= the type name</param>
		/// <param name="hl7PartType">- the type to compare against</param>
		/// <returns>true if a match is found; false otherwise</returns>
		public static bool MatchesDisregardingVersionSuffix(string type, string hl7PartType)
		{
			return type.StartsWith(hl7PartType + MESSAGE_PART_VERSION_SUFFIX_SEPARATOR);
		}
	}
}
