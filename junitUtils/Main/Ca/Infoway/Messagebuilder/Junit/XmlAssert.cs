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
 * Author:        $LastChangedBy: tmcgrady $
 * Last modified: $LastChangedDate: 2013-03-01 17:48:17 -0500 (Fri, 01 Mar 2013) $
 * Revision:      $LastChangedRevision: 6663 $
 */

using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.JUnit;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.JUnit
{
	public class XmlAssert : Assert
	{
		internal class XmlTree
		{
			private XmlDocument document;

			private XmlElement currentNode;

			public XmlTree(XmlDocument document)
			{
				this.document = document;
				this.currentNode = null;
			}

			public virtual object Elements()
			{
				return null;
			}

			public virtual XmlElement NextElement()
			{
				if (this.document != null)
				{
					this.currentNode = this.document.DocumentElement;
					this.document = null;
				}
				else
				{
					XmlElement temp = NextChildElement();
					if (temp == null)
					{
						temp = NextSiblingElement();
					}
					if (temp == null)
					{
						temp = NextSiblingOfAncestor();
					}
					this.currentNode = temp;
				}
				return this.currentNode;
			}

			private XmlElement NextSiblingOfAncestor()
			{
				return NextSiblingOfAncestor(this.currentNode);
			}

			private XmlElement NextSiblingOfAncestor(XmlElement element)
			{
				if (element.ParentNode.NodeType == System.Xml.XmlNodeType.Element)
				{
					XmlElement result = NextSiblingElement(element.ParentNode);
					if (result == null)
					{
						return NextSiblingOfAncestor((XmlElement)element.ParentNode);
					}
					else
					{
						return result;
					}
				}
				else
				{
					return null;
				}
			}

			private XmlElement NextSiblingElement()
			{
				return NextSiblingElement(this.currentNode);
			}

			private XmlElement NextSiblingElement(XmlNode node)
			{
				while (true)
				{
					node = node.NextSibling;
					if (node == null || node.NodeType == System.Xml.XmlNodeType.Element)
					{
						break;
					}
				}
				return (XmlElement)node;
			}

			private XmlElement NextChildElement()
			{
				XmlElement result = null;
				if (this.currentNode.HasChildNodes)
				{
					XmlNodeList children = this.currentNode.ChildNodes;
					for (int i = 0; i < children.Count; i++)
					{
						if (children.Item(i).NodeType == System.Xml.XmlNodeType.Element)
						{
							result = (XmlElement)children.Item(i);
							break;
						}
					}
				}
				return result;
			}

			public virtual string Describe()
			{
				return Describe(this.currentNode);
			}

			private string Describe(XmlNode node)
			{
				if (node is XmlElement)
				{
					return Describe(node.ParentNode) + "/" + GetLocalOrTagName(((XmlElement)node));
				}
				else
				{
					return string.Empty;
				}
			}

			public virtual bool IsLeaf()
			{
				if (this.currentNode.HasChildNodes && this.currentNode.ChildNodes.Count == 1 && (this.currentNode.FirstChild.NodeType == 
					System.Xml.XmlNodeType.Text || this.currentNode.FirstChild.NodeType == System.Xml.XmlNodeType.CDATA))
				{
					return true;
				}
				else
				{
					return !this.currentNode.HasChildNodes;
				}
			}
		}

		public static void AssertTreeEquals(XmlDocument expected, XmlDocument xml)
		{
			AssertTreeEquals(new XmlAssert.XmlTree(expected), new XmlAssert.XmlTree(xml));
		}

		private static void AssertTreeEquals(XmlAssert.XmlTree expected, XmlAssert.XmlTree actual)
		{
			IList<string> checkedActualAttributes;
			for (XmlElement expectedNode = expected.NextElement(); expectedNode != null; expectedNode = expected.NextElement())
			{
				XmlElement actualNode = actual.NextElement();
				Assert.IsNotNull(actualNode, "expected a node " + expected.Describe());
				Assert.AreEqual(GetLocalOrTagName(expectedNode), GetLocalOrTagName(actualNode), expected.Describe());
				Assert.AreEqual(StringUtils.TrimToEmpty(expectedNode.NamespaceURI), StringUtils.TrimToEmpty(actualNode.NamespaceURI), expected
					.Describe() + " xmlns");
				XmlAttributeCollection actualAttributes = actualNode.Attributes;
				checkedActualAttributes = new List<string>();
				for (int i = 0; i < actualAttributes.Count; i++)
				{
					checkedActualAttributes.Add(((XmlAttribute)actualAttributes.Item(i)).Name);
				}
				XmlAttributeCollection expectedAttributes = expectedNode.Attributes;
				for (int i = 0; i < expectedAttributes.Count; i++)
				{
					XmlAttribute attr = (XmlAttribute)expectedAttributes.Item(i);
					if (!attr.Name.StartsWith("xmlns"))
					{
						Assert.AreEqual(attr.Value, actualNode.GetAttribute(attr.Name), expected.Describe() + "/@" + attr.Name);
					}
					checkedActualAttributes.Remove(attr.Name);
				}
				Assert.IsTrue(checkedActualAttributes.Count == 0, "Extra attributes present in actual node: " + actual.Describe() + ", " 
					+ StringUtils.Join(checkedActualAttributes, ", "));
				if (expected.IsLeaf())
				{
					Assert.AreEqual(GetTextValue(expectedNode, false).Trim(), GetTextValue(actualNode, false).Trim(), expected.Describe() + "/text()"
						);
					if (expectedNode.FirstChild != null && actualNode.FirstChild != null)
					{
						Assert.AreEqual(expectedNode.FirstChild.NodeType, actualNode.FirstChild.NodeType, expected.Describe() + " nodeType");
					}
				}
			}
			AssertHasNoMoreElements(actual);
		}

		private static void AssertHasNoMoreElements(XmlAssert.XmlTree tree)
		{
			if (tree.Elements() != null)
			{
				XmlElement next = tree.NextElement();
				Assert.IsNull(next, "more elements: " + tree.Describe());
			}
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
		private static string GetLocalOrTagName(XmlNode node)
		{
			return StringUtils.IsBlank(node.LocalName) ? node.Name : node.LocalName;
		}

		/// <summary>
		/// Scan all immediate children of a node, and append all
		/// text nodes into a string.
		/// </summary>
		/// <remarks>
		/// Scan all immediate children of a node, and append all
		/// text nodes into a string.  Consider the following example:
		/// <pre>
		/// &lt;customer&gt;Joe Schmoe&lt;/customer&gt;
		/// </pre>
		///   In this case, calling this method on the
		/// <code>customer</code> element returns "Joe Schmoe".
		/// </remarks>
		/// <param name="node">- the node to scan</param>
		/// <param name="recurse">
		/// - a flag to indicate whether or not to recurse into
		/// sub-elements
		/// </param>
		/// <returns>- the text string</returns>
		private static string GetTextValue(XmlNode node, bool recurse)
		{
			string text = null;
			if (node != null)
			{
				text = string.Empty;
				XmlNodeList textList = node.ChildNodes;
				for (int i = 0; i < textList.Count; i++)
				{
					XmlNode child = textList.Item(i);
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
	}
}
