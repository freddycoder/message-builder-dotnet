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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Util.Text;

namespace Ca.Infoway.Messagebuilder.Xml.Util
{
	/// <summary>
	/// A utility to format a valid XML comment, used for displaying
	/// XML warnings.
	/// </summary>
	/// <remarks>
	/// A utility to format a valid XML comment, used for displaying
	/// XML warnings.
	/// </remarks>
	/// <author>Intelliware Development</author>
	public class XmlWarningRenderer
	{
		public static string MESSAGEBUILDER_OUTPUT_WARNINGS_IN_GENERATED_XML = "messagebuilder.output.warnings.in.generated.xml";

		public static string MESSAGEBUILDER_OUTPUT_WARNINGS_IN_GENERATED_XML_DEFAULT = "true";

		private bool outputWarnings;

		public XmlWarningRenderer()
		{
			string outputWarningsPropertyValue = Runtime.GetProperty(MESSAGEBUILDER_OUTPUT_WARNINGS_IN_GENERATED_XML);
			if (outputWarningsPropertyValue == null)
			{
				outputWarningsPropertyValue = MESSAGEBUILDER_OUTPUT_WARNINGS_IN_GENERATED_XML_DEFAULT;
			}
			this.outputWarnings = Ca.Infoway.Messagebuilder.BooleanUtils.ValueOf(outputWarningsPropertyValue);
		}

		public virtual string CreateWarning(int indentLevel, string text)
		{
			return CreateWarning(indentLevel, text, "WARNING");
		}

		public virtual string CreateWarning(int indentLevel, string text, string errorLevel)
		{
			return CreateLog(errorLevel, indentLevel, text);
		}

		public virtual string CreateLog(string logLevel, int indentLevel, string text)
		{
			return this.outputWarnings ? Indenter.Indent("<!-- " + logLevel + (StringUtils.IsBlank(logLevel) ? string.Empty : ": ") +
				 XmlStringEscape.Escape(text) + " -->" + SystemUtils.LINE_SEPARATOR, indentLevel) : StringUtils.EMPTY;
		}
	}
}
