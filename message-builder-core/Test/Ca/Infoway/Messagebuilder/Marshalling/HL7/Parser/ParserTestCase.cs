using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	public abstract class ParserTestCase : CeRxDomainValueTestCase
	{
		protected virtual IList<XmlNode> AsList(XmlNodeList list)
		{
			IList<XmlNode> result = new List<XmlNode>();
			for (int i = 0,  length = list == null ? 0 : list.Count; i < length; i++)
			{
				result.Add(list.Item(i));
			}
			return result;
		}
	}
}
