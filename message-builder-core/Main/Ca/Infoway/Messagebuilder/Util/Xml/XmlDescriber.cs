using System.Collections.Generic;
using System.Text;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Util.Xml
{
	/// <summary>Some utilities for describing XML elements.</summary>
	/// <remarks>Some utilities for describing XML elements.</remarks>
	/// <author>Intelliware Development</author>
	public class XmlDescriber
	{
		/// <summary>A utility that creates an XPath-like path for a particular node.</summary>
		/// <remarks>A utility that creates an XPath-like path for a particular node.</remarks>
		/// <param name="node">- the node being described.</param>
		/// <returns>- the xpath location of the node.</returns>
		public static string DescribePath(XmlNode node)
		{
			if (node == null)
			{
				return StringUtils.EMPTY;
			}
			else
			{
				if (node is XmlAttribute)
				{
					return DescribePath(((XmlAttribute)node).OwnerElement) + "/@" + ((XmlAttribute)node).Name;
				}
				else
				{
					if (node is XmlElement)
					{
						return DescribePath(node.ParentNode) + "/" + DescribeElement((XmlElement)node);
					}
					else
					{
						return StringUtils.EMPTY;
					}
				}
			}
		}

		/// <summary>
		/// A utility to provide an element name, with an index number if it is a
		/// repeating element.
		/// </summary>
		/// <remarks>
		/// A utility to provide an element name, with an index number if it is a
		/// repeating element.
		/// </remarks>
		/// <param name="node">- the element</param>
		/// <returns>- an XML-like repesentation of the element.</returns>
		private static string DescribeElement(XmlElement node)
		{
			string index = StringUtils.EMPTY;
			if (HasSiblingOfSameName(node))
			{
				index = GetStringIndexOf(node);
			}
			return NodeUtil.GetLocalOrTagName(((XmlElement)node)) + index;
		}

		private static string GetStringIndexOf(XmlElement start)
		{
			return "[" + GetIndexOf(start) + "]";
		}

		/// <summary>
		/// A utility to determine which repetition of a particular element name this
		/// element represents.
		/// </summary>
		/// <remarks>
		/// A utility to determine which repetition of a particular element name this
		/// element represents.  This method is used to create an xpath-like index for
		/// repeating elements.
		/// </remarks>
		/// <param name="start">- the element</param>
		/// <returns>- the index.</returns>
		public static int GetIndexOf(XmlElement start)
		{
			int count = 1;
			for (XmlNode node = start.PreviousSibling; node != null; node = node.PreviousSibling)
			{
				if (HasSameName(start, node))
				{
					count++;
				}
			}
			return count;
		}

		private static bool HasSiblingOfSameName(XmlElement node)
		{
			int count = 0;
			if (node.ParentNode is XmlElement)
			{
				XmlNodeList childs = node.ParentNode.ChildNodes;
				for (int i = 0; i < childs.Count; i++)
				{
					XmlNode child = childs.Item(i);
					if (HasSameName(node, child))
					{
						count++;
					}
					if (count > 1)
					{
						break;
					}
				}
				return count > 1;
			}
			else
			{
				return false;
			}
		}

		private static bool HasSameName(XmlElement node, XmlNode child)
		{
			return child.NodeType == System.Xml.XmlNodeType.Element && StringUtils.Equals(NodeUtil.GetLocalOrTagName((XmlElement)child
				), NodeUtil.GetLocalOrTagName((XmlElement)node));
		}

		/// <summary>A utility that creates a representation of the element and its attributes.</summary>
		/// <remarks>
		/// A utility that creates a representation of the element and its attributes.
		/// This representation would typically be used in error messages to help the
		/// user recognize which element is a problem.
		/// </remarks>
		/// <param name="element">- the element</param>
		/// <returns>- an XML-like repesentation of the element.</returns>
		public static string DescribeSingleElement(XmlElement element)
		{
			StringBuilder builder = new StringBuilder();
			builder.Append("<").Append(NodeUtil.GetLocalOrTagName(element));
			XmlAttributeCollection attributes = element.Attributes;
			List<string> set = new List<string>();
			for (int i = 0,  length = attributes == null ? 0 : attributes.Count; i < length; i++)
			{
				XmlAttribute item = (XmlAttribute)attributes.Item(i);
				set.Add(item.Name);
			}
			set.Sort();
			foreach (string name in set)
			{
				XmlAttribute item = (XmlAttribute)attributes.GetNamedItem(name);
				builder.Append(" ").Append(NodeUtil.GetLocalOrTagName(item)).Append("=\"").Append(XmlStringEscape.Escape(item.Value)).Append
					("\"");
			}
			if (element.HasChildNodes)
			{
				builder.Append(">");
			}
			else
			{
				builder.Append("/>");
			}
			return builder.ToString();
		}
	}
}
