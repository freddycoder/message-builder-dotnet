/**
 * Copyright 2012 Canada Health Infoway, Inc.
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
 * Last modified: $LastChangedDate: 2011-05-17 11:48:36 -0400 (Tue, 17 May 2011) $
 * Revision:      $LastChangedRevision: 2666 $
 */

using System;
using System.Xml;
using Ca.Infoway.Messagebuilder.Transport;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Platform.Xml.Sax;

namespace Ca.Infoway.Messagebuilder.Transport
{
	/// <summary>A basic implementation of a message that can be sent across a transport layer.</summary>
	/// <remarks>
	/// A basic implementation of a message that can be sent across a transport layer. Allows the message to be accessed as
	/// a string or as a Document.
	/// Must make use of static creation methods in order to construct a SimpleRequestMessage.
	/// </remarks>
	/// <author>
	/// <a href="http://www.intelliware.ca/">Intelliware Development</a>
	/// sharpen.ignore - transport - TBD!
	/// </author>
	public class SimpleRequestMessage : RequestMessage
	{
		private readonly string message;

		private readonly XmlDocument document;

		private SimpleRequestMessage(string message, XmlDocument document)
		{
			this.message = message;
			this.document = document;
		}

		/// <summary>Obtains the message's interaction id.</summary>
		/// <remarks>Obtains the message's interaction id.</remarks>
		/// <returns>the message's interaction id</returns>
		/// <exception cref="TransportLayerException">if the message's interaction id could not be determined</exception>
		/// <exception cref="Ca.Infoway.Messagebuilder.Transport.TransportLayerException"></exception>
		public virtual string GetInteractionId()
		{
			return NodeUtil.GetLocalOrTagName(this.document.DocumentElement);
		}

		/// <summary>Obtains the message as a DOM, converting the underlying structure if necessary (i.e.</summary>
		/// <remarks>Obtains the message as a DOM, converting the underlying structure if necessary (i.e. string -&gt; DOM).</remarks>
		/// <returns>the underlying message in a DOM structure</returns>
		/// <exception cref="TransportLayerException">if there were problems creating the DOM</exception>
		/// <exception cref="Ca.Infoway.Messagebuilder.Transport.TransportLayerException"></exception>
		public virtual XmlDocument GetMessageAsDocument()
		{
			return this.document;
		}

		/// <summary>Obtains the message as a string, converting the underlying structure if necessary (i.e.</summary>
		/// <remarks>Obtains the message as a string, converting the underlying structure if necessary (i.e. DOM -&gt; string).</remarks>
		/// <returns>the underlying message rendered as a string</returns>
		/// <exception cref="TransportLayerException">if a string representation of the message could not be constructed</exception>
		/// <exception cref="Ca.Infoway.Messagebuilder.Transport.TransportLayerException"></exception>
		public virtual string GetMessageAsString()
		{
			return this.message;
		}

		/// <summary>Create a message object based on a string.</summary>
		/// <remarks>Create a message object based on a string.</remarks>
		/// <param name="message">the message as a string</param>
		/// <returns>the constructed message object</returns>
		/// <exception cref="TransportLayerException">if the message could not be converted into a Document</exception>
		/// <exception cref="Ca.Infoway.Messagebuilder.Transport.TransportLayerException"></exception>
		public static RequestMessage Create(string message)
		{
			try
			{
				XmlDocument document = new DocumentFactory().CreateFromString(message);
				return new Ca.Infoway.Messagebuilder.Transport.SimpleRequestMessage(message, document);
			}
			catch (SAXException e)
			{
	    		throw new TransportLayerException("Problem parsing string representation of an XML message: " + e.Message);
			}
		}

		/// <summary>Create a message object based on a Document.</summary>
		/// <remarks>Create a message object based on a Document.</remarks>
		/// <param name="message">the message as a Document</param>
		/// <returns>the constructed message object</returns>
		/// <exception cref="TransportLayerException">if the message could not be rendered as a string</exception>
		/// <exception cref="Ca.Infoway.Messagebuilder.Transport.TransportLayerException"></exception>
		public static RequestMessage Create(XmlDocument message)
		{
//			return null;
			try
			{
				return new Ca.Infoway.Messagebuilder.Transport.SimpleRequestMessage(message == null ? null : message.InnerXml, message);
			}
			catch (Exception e)
			{
				throw new TransportLayerException("Problem rendering document to XML: " + e.Message);
			}
		}

		/// <summary>Create a message object based on a Document and string representation.</summary>
		/// <remarks>Create a message object based on a Document and string representation.</remarks>
		/// <param name="messageAsDocument">the message as a Document</param>
		/// <param name="messageAsString">the message as a string</param>
		/// <returns>the constructed message object</returns>
		/// <exception cref="TransportLayerException">if the message could not be constructed</exception>
		/// <exception cref="Ca.Infoway.Messagebuilder.Transport.TransportLayerException"></exception>
		public static RequestMessage Create(XmlDocument messageAsDocument, string messageAsString)
		{
			return new Ca.Infoway.Messagebuilder.Transport.SimpleRequestMessage(messageAsString, messageAsDocument);
		}
	}
}
