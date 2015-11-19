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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */
using System;
using System.IO;
using System.Xml;
using Platform.Xml.Parsers;

namespace Ca.Infoway.Messagebuilder.Util.Xml
{
	/// <summary>A utility that renders a DOM tree into a String representation.</summary>
	/// <remarks>A utility that renders a DOM tree into a String representation.</remarks>
	/// <author>Intelliware Development</author>
	public class XmlRenderer
	{
		private static XmlDocumentBuilderFactory documentFactory = XmlDocumentBuilderFactory.NewInstance();

		static XmlRenderer()
		{
			documentFactory.SetNamespaceAware(true);
		}

        //Special rendering for EncapsulatedData. May want to use saxon to be consistent with Java
        public static String RenderNodeEscaped(XmlNode node) {
            StringWriter writer = new StringWriter(System.Globalization.NumberFormatInfo.InvariantInfo);
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.ConformanceLevel = ConformanceLevel.Fragment;
            settings.NewLineChars = "\n";
            var xmlWriter = XmlWriter.Create(writer, settings);
            if (node.NodeType == XmlNodeType.Text || node.NodeType == XmlNodeType.CDATA) {
                xmlWriter.WriteString(node.InnerText);
            } else if (node.NodeType == XmlNodeType.Whitespace) {
                xmlWriter.WriteString(node.InnerText.ReplaceAll("\t", ""));
            } else {
                node.WriteTo(xmlWriter);
            }
            xmlWriter.Flush();
            return writer.ToString();
        }

		/// <exception cref="javax.xml.parsers.ParserConfigurationException"></exception>
		public static XmlDocument ObtainDocumentFromNode(XmlNode node, bool removeNamespaces)
		{
			XmlDocumentBuilder builder = documentFactory.NewDocumentBuilder();
			XmlDocument newDocument = builder.NewDocument();
			XmlNode importedNode = newDocument.ImportNode(node, true);
			newDocument.AppendChild(importedNode);
			// clear out any namespace that was brought along by the import (though this may not be desirable in all cases)
			if (removeNamespaces)
			{
				RenameNamespaceRecursive(importedNode, null);
			}
			return newDocument;
		}

		private static void RenameNamespaceRecursive(XmlNode node, string namespaze)
		{
			XmlDocument document = node.OwnerDocument;
            XmlNode newNode = node;
			if (node.NodeType == System.Xml.XmlNodeType.Element)
			{
				newNode = RenameNode(node, namespaze, node.Name);
			}
            XmlNodeList list = newNode.ChildNodes;
			for (int i = 0; i < list.Count; ++i)
			{
				RenameNamespaceRecursive(list.Item(i), namespaze);
			}
		}

        //Copied from stackoverlow
        private static XmlNode RenameNode(XmlNode node, string namespaceUri, string qualifiedName) {
            if (node.NodeType == XmlNodeType.Element) {
                XmlElement oldElement = (XmlElement)node;
                XmlElement newElement =
                node.OwnerDocument.CreateElement(qualifiedName, namespaceUri);
                while (oldElement.HasAttributes) {
                    newElement.SetAttributeNode(oldElement.RemoveAttributeNode(oldElement.Attributes[0]));
                }
                while (oldElement.HasChildNodes) {
                    newElement.AppendChild(oldElement.FirstChild);
                }
                if (oldElement.ParentNode != null) {
                    oldElement.ParentNode.ReplaceChild(newElement, oldElement);
                }
                return newElement;
            } else {
                return null;
            }
        }
	}
}
