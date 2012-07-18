using System.Xml;

namespace Ca.Infoway.Messagebuilder.Xml.Util
{
	/// <summary>A utility to determine if an XML node is in the HL7 namespace.</summary>
	/// <remarks>A utility to determine if an XML node is in the HL7 namespace.</remarks>
	/// <author>Intelliware Development</author>
	public class NamespaceUtil
	{
		private static readonly string HL7_NAMESPACE_URI = "urn:hl7-org:v3";

		/// <summary>Determine if the node in the HL7 namespace.</summary>
		/// <remarks>Determine if the node in the HL7 namespace.</remarks>
		/// <param name="node">- the node being considered</param>
		/// <returns>true if the node is part of the HL7 namespace; false otherwise</returns>
		public static bool IsHl7Node(XmlNode node)
		{
			if (HL7_NAMESPACE_URI.Equals(node.NamespaceURI))
			{
				return true;
			}
			else
			{
				if (node is XmlAttribute && (node.NamespaceURI == null || node.NamespaceURI == string.Empty))
				{
					return HL7_NAMESPACE_URI.Equals(((XmlAttribute)node).OwnerElement.NamespaceURI);
				}
				else
				{
					return false;
				}
			}
		}
	}
}
