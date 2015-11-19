using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	public abstract class ParserTestCase : CeRxDomainValueTestCase
	{
		protected virtual IList<XmlNode> AsList(XmlNodeList list)
		{
			IList<XmlNode> result = new List<XmlNode>();
			if (list != null)
			{
				foreach (XmlNode childNode in new XmlNodeListIterable(list))
				{
					result.Add(childNode);
				}
			}
			return result;
		}
	}
}
