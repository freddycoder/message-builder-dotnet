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


/// ---------------------------------------------------------------------------------------------------
///  This file was automatically generated by J2CS Translator (http://j2cstranslator.sourceforge.net/). 
///  Version 1.0.0                                                                                      
/// ---------------------------------------------------------------------------------------------------
 
namespace Ca.Infoway.Messagebuilder.J5goodies {
	
	using Ca.Infoway.Messagebuilder;
	using ILOG.J2CsMapping.Collections;
	using ILOG.J2CsMapping.Collections.Generics;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	using System.Xml;
 	
	/// <summary>
	/// A utility to make XPath operations easier.
	/// This utility supports both namespace-based and non-namespaced based operations. 
	/// If the provided node was created with a namespace-aware parser, then you must use the
	/// namespace version of these methods.
	/// For example:
	/// <pre>
	/// NodeList list = new XPathHelper().getNodes(document, 
	/// "//x:myElement", "urn:mySchema.example.org");
	/// </pre>
	/// In this example, the "x" prefix acts as a simple marker for the namespace; it 
	/// doesn't matter what the name of the prefix is.
	/// </summary>
	///
	public class XPathHelper {
	
        /*
		public class NamespaceContextImpl : NamespaceContext {
	
			private readonly String ns;
	
			public NamespaceContextImpl(String ns) {
				this.ns = ns;
			}
	
			public virtual  System.String GetNamespaceURI(String prefix) {
				return this.ns;
			}
	
			public virtual  System.String GetPrefix(String namespaceURI) {
				throw new NotSupportedException();
			}
	
			/* @SuppressWarnings("unchecked")* /
			public virtual  IIterator GetPrefixes(String namespaceURI) {
				throw new NotSupportedException();
			}
	
		}
*/
	
		public XmlNode GetSingleNode(XmlNode bs, String xpathExpression) {
			XmlDocument document = bs.OwnerDocument;
			return document.SelectSingleNode(xpathExpression);
		}

        public XmlNodeList GetNodes(XmlNode bs, string xpathExpression, string prefix, string namespaze) {
            XmlDocument document = bs is XmlDocument ? (XmlDocument)bs : bs.OwnerDocument;
            XmlNamespaceManager nameSpaceManager = new XmlNamespaceManager(document.NameTable);
            nameSpaceManager.AddNamespace(prefix, namespaze);
            return bs.SelectNodes(xpathExpression, nameSpaceManager);
        }

        public string GetAttributeValue(XmlNode bs, string xpathExpresion, string namespaze)
        {
            XmlAttribute attr = (XmlAttribute) bs.SelectSingleNode(xpathExpresion);
            return attr == null ? null : attr.Value;
        }
    }
}
