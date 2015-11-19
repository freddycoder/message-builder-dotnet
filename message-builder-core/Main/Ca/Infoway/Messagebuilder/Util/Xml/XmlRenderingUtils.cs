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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Util.Text;

namespace Ca.Infoway.Messagebuilder.Util.Xml
{
	/// <summary>Utilities for creating a string representation of XML.</summary>
	/// <remarks>Utilities for creating a string representation of XML.</remarks>
	/// <author>Intelliware Development</author>
	public class XmlRenderingUtils
	{
		public static readonly string SPACE = " ";

		public static readonly string QUOTE = "\"";

		public static readonly string EQUALS = "=";

		/// <summary>Create a XML start element.</summary>
		/// <remarks>Create a XML start element.</remarks>
		/// <param name="name">- the tag name.</param>
		/// <param name="indentLevel">- the indent level</param>
		/// <param name="close">- indicates whether or not close the element.</param>
		/// <param name="lineBreak">- indicates whether or not to include a line break</param>
		/// <returns>- the formatted result.</returns>
		public static string CreateStartElement(string name, int indentLevel, bool close, bool lineBreak)
		{
			return CreateStartElement(name, CollUtils.EmptyList<KeyValuePair<string, string>>(), indentLevel, close, lineBreak);
		}

		/// <summary>Create a XML start element.</summary>
		/// <remarks>Create a XML start element.</remarks>
		/// <param name="name">- the tag name.</param>
		/// <param name="nameSpace">- namespace of the tag name</param>
		/// <param name="indentLevel">- the indent level</param>
		/// <param name="close">- indicates whether or not close the element.</param>
		/// <param name="lineBreak">- indicates whether or not to include a line break</param>
		/// <returns>- the formatted result.</returns>
		public static string CreateStartElement(string name, string nameSpace, int indentLevel, bool close, bool lineBreak)
		{
			return CreateStartElement(name, nameSpace, CollUtils.EmptyList<KeyValuePair<string, string>>(), indentLevel, close, lineBreak
				);
		}

		/// <summary>Create a XML start element.</summary>
		/// <remarks>Create a XML start element.</remarks>
		/// <param name="name">- the tag name.</param>
		/// <param name="attributes">- an ordered collection of attributes (names and values) to render with the element</param>
		/// <param name="indentLevel">- the indent level</param>
		/// <param name="close">- indicates whether or not close the element.</param>
		/// <param name="lineBreak">- indicates whether or not to include a line break</param>
		/// <returns>- the formatted result.</returns>
		public static string CreateStartElement(string name, IList<KeyValuePair<string, string>> attributes, int indentLevel, bool
			 close, bool lineBreak)
		{
			return CreateStartElement(name, null, attributes, indentLevel, close, lineBreak);
		}

		/// <summary>Create a XML start element.</summary>
		/// <remarks>Create a XML start element.</remarks>
		/// <param name="name">- the tag name.</param>
		/// <param name="attributes">- a map of attributes (names and values) to render with the element</param>
		/// <param name="indentLevel">- the indent level</param>
		/// <param name="close">- indicates whether or not close the element.</param>
		/// <param name="lineBreak">- indicates whether or not to include a line break</param>
		/// <returns>- the formatted result.</returns>
		public static string CreateStartElement(string name, IDictionary<string, string> attributes, int indentLevel, bool close, 
			bool lineBreak)
		{
			return CreateStartElement(name, null, ToSortedList(attributes), indentLevel, close, lineBreak);
		}

		private static IList<KeyValuePair<string, string>> ToSortedList(IDictionary<string, string> attributes)
		{
			IList<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			if (attributes != null)
			{
				List<string> sortedList = new List<string>(attributes.Keys);
				sortedList.Sort();
				foreach (string key in sortedList)
				{
					list.Add(new KeyValuePair<string, string>(key, attributes.SafeGet(key)));
				}
			}
			return list;
		}

		/// <summary>Create a XML start element.</summary>
		/// <remarks>Create a XML start element.</remarks>
		/// <param name="name">- the tag name.</param>
		/// <param name="nameSpace">- namespace of the tag name</param>
		/// <param name="attributes">- an ordered collection of attributes (names and values) to render with the element</param>
		/// <param name="indentLevel">- the indent level</param>
		/// <param name="close">- indicates whether or not close the element.</param>
		/// <param name="lineBreak">- indicates whether or not to include a line break</param>
		/// <returns>- the formatted result.</returns>
		public static string CreateStartElement(string name, string nameSpace, IList<KeyValuePair<string, string>> attributes, int
			 indentLevel, bool close, bool lineBreak)
		{
			StringBuilder buffer = new StringBuilder();
			Indenter.IndentBuffer(buffer, indentLevel);
			buffer.Append("<");
			buffer.Append(name);
			if (nameSpace != null)
			{
				buffer.Append(" xmlns=\"" + nameSpace + "\"");
			}
			if (attributes != null)
			{
				foreach (KeyValuePair<string, string> attribute in attributes)
				{
					buffer.Append(SPACE);
					buffer.Append(attribute.Key);
					buffer.Append(EQUALS);
					buffer.Append(QUOTE);
					buffer.Append(XmlStringEscape.Escape(attribute.Value));
					buffer.Append(QUOTE);
				}
			}
			if (close)
			{
				buffer.Append("/");
			}
			buffer.Append(">");
			if (lineBreak)
			{
				buffer.Append(SystemUtils.LINE_SEPARATOR);
			}
			return buffer.ToString();
		}

		/// <summary>Create a closing element tag.</summary>
		/// <remarks>Create a closing element tag.</remarks>
		/// <param name="name">- the tag name</param>
		/// <param name="indentLevel">- the indent level</param>
		/// <param name="lineBreak">- a flag to indicate if a line break should terminate the tag</param>
		/// <returns>- the formatted result</returns>
		public static string CreateEndElement(string name, int indentLevel, bool lineBreak)
		{
			StringBuilder buffer = new StringBuilder();
			Indenter.IndentBuffer(buffer, indentLevel);
			buffer.Append("</");
			buffer.Append(name);
			buffer.Append(">");
			if (lineBreak)
			{
				buffer.Append(SystemUtils.LINE_SEPARATOR);
			}
			return buffer.ToString();
		}
	}
}
