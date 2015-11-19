/**
 * Copyright 2013 Canada Health Infoway, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Author:        $LastChangedBy: jmis $
 * Last modified: $LastChangedDate: 2015-05-27 08:43:37 -0400 (Wed, 27 May 2015) $
 * Revision:      $LastChangedRevision: 9535 $
 */
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Util.Xml
{
	/// <summary>A variety of utility methods for manipulating nodes.</summary>
	/// <remarks>A variety of utility methods for manipulating nodes.</remarks>
	/// <author>Intelliware Development</author>
	public class NodeUtil
	{
		/// <summary>
		/// Scan all immediate children of a node, and append all
		/// text nodes into a string.
		/// </summary>
		/// <remarks>
		/// Scan all immediate children of a node, and append all
		/// text nodes into a string.  Consider the following example:
		/// 
		/// &lt;customer&gt;Joe Schmoe&lt;/customer&gt;
		/// 
		/// In this case, calling this method on the
		/// customer element returns "Joe Schmoe".
		/// </remarks>
		/// <param name="node">- the node to scan</param>
		/// <returns>- the text string</returns>
		public static string GetTextValue(XmlNode node)
		{
			return GetTextValue(node, false);
		}

		/// <summary>
		/// Scan all immediate children of a node, and append all
		/// text nodes into a string.
		/// </summary>
		/// <remarks>
		/// Scan all immediate children of a node, and append all
		/// text nodes into a string.  Consider the following example:
		/// 
		/// &lt;customer&gt;Joe Schmoe&lt;/customer&gt;
		/// 
		/// In this case, calling this method on the
		/// customer element returns "Joe Schmoe".
		/// </remarks>
		/// <param name="node">- the node to scan</param>
		/// <param name="recurse">
		/// - a flag to indicate whether or not to recurse into
		/// sub-elements
		/// </param>
		/// <returns>- the text string</returns>
		public static string GetTextValue(XmlNode node, bool recurse)
		{
			string text = null;
			if (node != null)
			{
				text = string.Empty;
				XmlNodeList textList = node.ChildNodes;
				foreach (XmlNode child in new XmlNodeListIterable(textList))
				{
					if (child.NodeType == System.Xml.XmlNodeType.Text || child.NodeType == System.Xml.XmlNodeType.CDATA)
					{
						text += ((XmlText)child).Data;
					}
					else
					{
						if (recurse && child.NodeType == System.Xml.XmlNodeType.Element)
						{
							text += GetTextValue(child, recurse);
						}
					}
				}
			}
			return text;
		}

		/// <summary>Treat the NodeList as a standard list.</summary>
		/// <remarks>Treat the NodeList as a standard list.</remarks>
		/// <param name="children">- the node list</param>
		/// <returns>- the list of nodes</returns>
		public static IList<XmlNode> AsList(XmlNodeList children)
		{
			IList<XmlNode> nodes = new List<XmlNode>();
			if (children != null)
			{
				foreach (XmlNode node in new XmlNodeListIterable(children))
				{
					nodes.Add(node);
				}
			}
			return nodes;
		}

		/// <summary>Get all children of a particular tag name as a list.</summary>
		/// <remarks>Get all children of a particular tag name as a list.</remarks>
		/// <param name="node">- the parent node</param>
		/// <param name="tagName">- the tag name to select</param>
		/// <returns>- the list of nodes</returns>
		public static IList<XmlNode> GetChildNodes(XmlNode node, string tagName)
		{
			if (node.NodeType != System.Xml.XmlNodeType.Element)
			{
				return CollUtils.EmptyList<XmlNode>();
			}
			else
			{
				return AsList(((XmlElement)node).GetElementsByTagName(tagName));
			}
		}

		/// <summary>Get all child elements of the given node as a list of elements.</summary>
		/// <remarks>Get all child elements of the given node as a list of elements.</remarks>
		/// <param name="node">- the node</param>
		/// <returns>- the list of child elements</returns>
		public static IList<XmlElement> ToElementList(XmlNode node)
		{
			IList<XmlElement> elements = new List<XmlElement>();
			XmlNodeList childNodes = node.ChildNodes;
			if (childNodes != null)
			{
				foreach (XmlNode childNode in new XmlNodeListIterable(childNodes))
				{
					if (childNode is XmlElement)
					{
						elements.Add((XmlElement)childNode);
					}
				}
			}
			return elements;
		}

		/// <summary>
		/// Get the local or tag name (depending on whether or not the DOM tree was
		/// parsed with namespace awareness.
		/// </summary>
		/// <remarks>
		/// Get the local or tag name (depending on whether or not the DOM tree was
		/// parsed with namespace awareness.
		/// </remarks>
		/// <param name="node">- the node/element</param>
		/// <returns>- the local name, if it is not blank; the tag name otherwise.</returns>
		public static string GetLocalOrTagName(XmlNode node)
		{
			return StringUtils.IsBlank(node.LocalName) ? node.Name : node.LocalName;
		}
	}
}
